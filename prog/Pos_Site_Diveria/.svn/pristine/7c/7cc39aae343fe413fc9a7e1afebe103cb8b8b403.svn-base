using Newtonsoft.Json;
using STL.POS.Data;
using STL.POS.Frontend.Web.Helpers;
using STL.POS.WsProxy;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using Microsoft.Reporting.WebForms;
using STL.POS.PlexysProxy;
using STL.POS.PlexysProxy.PlexisService;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using STL.POS.Frontend.Web.Controllers;

namespace STL.POS.Frontend.Web.Areas.Salud.Controllers
{
    public class PoSSaludController :  BaseController
    {
        private CoreProxy coreProxy;
        private ProxyClient plexysProxy;
        private Mutex dailyNumberSyncMutex = new Mutex();
        private const int MIN_AGE_PERSON = 18;
        private const int MAX_AGE_PERSON = 74;
        private const int MAX_AGE_STUDENT = 24;

        private CultureInfo culture = CultureInfo.CreateSpecificCulture("es-US");

        public PoSSaludController(PosModel da, CoreProxy cp, ProxyClient ppc):base(da)
        {
            dataAccess = da;
            coreProxy = cp;
            plexysProxy = ppc;
        }

        // GET: Salud/PoSSalud
        [PosAuthorize]
        public ActionResult Index()
        {
            //ViewBag.CurrentUser = User.Identity.Name;
            //var user = (from u in dataAccess.Users
            //            where u.Username == User.Identity.Name
            //            select u).FirstOrDefault();
            //ViewBag.IsUserVO = false;// = user.UserOrigin == UserOrigins.VO;

            return View();
        }

        #region [Quotation methods]

        [AjaxHandleError]
        [PosAuthorize]
        public ActionResult GetAvailableQuotations()
        {
            var username = User.Identity.Name;

            var daysFromLastModif = Convert.ToInt32(dataAccess.GetParameter(Parameter.PARAMETER_KEY_DAYS_LAST_MODIF_QUOTATION, "30").Value);
            var date = DateTime.Now.AddDays(-1 * daysFromLastModif);

            var quotations = (from q in dataAccess.Quotations.OfType<QuotationSalud>()
                              where q.LastModified > date
                              && q.Status == QuotationStatus.InProgress
                              && q.User.Username == username
                              orderby q.Created descending, q.QuotationDailyNumber descending
                              select q).ToList().Select(q => new { id = q.Id, quotationNumber = q.QuotationNumber }).ToArray();

            return Json(quotations, JsonRequestBehavior.AllowGet);
        }

        [AjaxHandleError]
        [PosAuthorize]
        public ActionResult GetFullQuotation(int quotationId)
        {
            var quotation = (from q in dataAccess.Quotations.OfType<QuotationSalud>().Include("Persons.City").Include("Persons.WorkCity")
                             //.Include("Persons.Nationality").Include("Persons.WorkNationality")
                             .Include("TermType")
                             where q.Id == quotationId
                             select q).FirstOrDefault() as QuotationSalud;

            var json = new JsonNetResult();
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.Data = quotation;
            return json;
        }

        [AjaxHandleError]
        [HttpPost]
        [PosAuthorize]
        public ActionResult SaveQuotation(int? quotationId,
            string persons,
            string payment,
            string planType,
            string plan,
            decimal? deductible,
            string startDate,
            string endDate,
            decimal? totalPrime,
            decimal? totalIsc,
            decimal? totalDiscount,
            int? discountPercentage
            )
        {
            bool isNewQuotation = !quotationId.HasValue;
            QuotationSalud quotation;
            var currDate = DateTime.Now;
            if (isNewQuotation)
            {
                quotation = new QuotationSalud();
                quotation.Created = currDate;
                quotation.ProductNumber = Constants.PRODUCT_NUMBER_AUTO;
                quotation.BusinessLine = dataAccess.BusinessLines.First(f=> f.Id == Constants.BUSINESSLINE_ID_SALUD);
                quotation.CardnetPaymentStatus = QuotationCardnetStatus.NotSent;
                isNewQuotation = true;

                var user = (from u in dataAccess.Users
                            where u.Username == User.Identity.Name
                            select u).FirstOrDefault();
                quotation.User = user;
                dataAccess.Quotations.Add(quotation);
            }
            else
            {
                quotation = dataAccess.Quotations.OfType<QuotationSalud>()
                    .Include("Persons.Nationality")
                    .Include("TermType")
                    .FirstOrDefault(q => q.Id == quotationId);
            }

            quotation.LastModified = currDate;

            quotation.PlanType = planType;
            quotation.Plan = plan;
            quotation.Deductible = deductible;

            quotation.StartDate = DateTime.Parse(startDate, culture);
            quotation.EndDate = DateTime.Parse(endDate, culture);

            dynamic paymentObj = JsonConvert.DeserializeObject(payment);

            quotation.PaymentFrequencyId = paymentObj.applicant.frequency;
            quotation.PaymentFrequency = paymentObj.applicant.frequency + " pago";
            quotation.PaymentWay = paymentObj.applicant.wayToPay;
            quotation.ISCPercentage = paymentObj.iscPercentage;
            quotation.DiscountPercentage = paymentObj.currentDiscountPercentage;
            quotation.AchAccountHolderGovId = paymentObj.ach.achAccountHolderGovernmentId;
            quotation.AchBankRoutingNumber = paymentObj.ach.achBankRoutingNumber;
            quotation.AchName = paymentObj.ach.name;
            quotation.AchNumber = paymentObj.ach.number;
            quotation.AchType = (AchAccountType)Convert.ToInt32(paymentObj.ach.type);
            quotation.AmountToPayEnteredByUser = Convert.ToDecimal(paymentObj.amountToPayEntered);

            quotation.Currency = dataAccess.Currencies.First(d => d.Id == Currency.ID_PESO_REP_DOMINICANA);
            quotation.CurrencySymbol = quotation.Currency.Symbol;

            var newPersons = SavePersons(quotation, persons);

            var principal = quotation.Persons.First(p => p.IsPrincipal);

            var id = principal.IdentificationNumber + principal.DateOfBirth.ToString("ddMMyyyy");
            quotation.User = CheckUser(id, principal.FirstName, principal.FirstSurname, principal.Email);

            quotation.PrincipalFullName = principal.GetFullName();
            quotation.PrincipalIdentificationNumber = principal.IdentificationNumber;
            quotation.QuotationProduct = quotation.GetQuotationProduct();

            if (discountPercentage.HasValue)
                quotation.DiscountPercentage = discountPercentage;

            quotation.TotalISC = totalIsc;
            quotation.TotalPrime = totalPrime;
            quotation.TotalDiscount = totalDiscount;

            try
            {
                dailyNumberSyncMutex.WaitOne();
                if (isNewQuotation)
                {
                    quotation.QuotationDailyNumber = GetNewDailyQuotationNumber();
                    quotation.QuotationNumber = quotation.ProductNumber + quotation.Created.ToString("yyyyMMdd") + quotation.QuotationDailyNumber.ToString().PadLeft(4, '0');
                }
                dataAccess.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dailyNumberSyncMutex.ReleaseMutex();
            }

            //Gather data of new objects:
            //Persons
            var personsIds = from c in newPersons
                             select new { tempId = c.Key, id = c.Value.Id };

            return Json(new { quotationId = quotation.Id, updatePersons = personsIds }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetRates(int plan, int deducible, string persons)
        {
            try
            {
                var personsDeserialized = JsonConvert.DeserializeObject<List<dynamic>>(persons);

                //{ id: 'Mismo', name: 'Mismo' },
                //        { id: 'Esposa', name: 'Esposa' },
                //        { id: 'Esposo', name: 'Esposo' },
                //        { id: 'Hija', name: 'Hija' },
                //        { id: 'Hijo', name: 'Hijo' },
                //        { id: 'Madre', name: 'Madre' },
                //        { id: 'Padre', name: 'Padre' },
                //        { id: 'Suegra', name: 'Suegra' },
                //        { id: 'Suegro', name: 'Suegro' }]),

                var principal = personsDeserialized.Where(p => p.relationship == "Mismo").FirstOrDefault();
                var spouse = personsDeserialized.Where(p => p.relationship == "Compañero de Vida" || p.relationship == "Cónyuge").FirstOrDefault();
                var children = personsDeserialized.Where(p => p.relationship == "Hija" || p.relationship == "Hijo");

                var parameter = new GetRatesParameters();
                parameter.DeducibleId = plexysProxy.GetDeducibleIdFromAmount(deducible);
                parameter.ZoneId = 2; //Now fixed to dominican republic
                parameter.ProductId = plan;

                var principalData = new PrincipalData();
                var birth = DateTime.Parse((string)principal.dateOfBirth, culture);
                principalData.Age = GetAge(birth);
                principalData.Height = decimal.Parse(principal.height.ToString());
                principalData.Smoker = principal.smoker;
                principalData.Transplant = false;
                principalData.Weight = int.Parse(principal.weight.ToString());
                principalData.Maternity = principal.adicComplications;
                principalData.Transplant = principal.adicTransplant;
                parameter.Principal = principalData;

                if (spouse != null)
                {
                    var spouseData = new PrincipalData();
                    birth = DateTime.Parse((string)spouse.dateOfBirth, culture);
                    spouseData.Age = GetAge(birth);
                    spouseData.Height = decimal.Parse(spouse.height.ToString());
                    spouseData.Smoker = spouse.smoker;
                    spouseData.Transplant = false;
                    spouseData.Weight = int.Parse(spouse.weight.ToString());
                    spouseData.Maternity = spouse.adicComplications;
                    spouseData.Transplant = spouse.adicTransplant;
                    parameter.Spouse = spouseData;
                }

                parameter.ChildrenAmount = children.Count();
                if (parameter.ChildrenAmount > 0)
                {
                    var childData = new ChildData();

                    if (parameter.ChildrenAmount == 1)
                    {
                        childData.TransplantChild1 = true;
                    }
                    if (parameter.ChildrenAmount == 2)
                    {
                        childData.TransplantChild1 = true;
                        childData.TransplantChild2 = true;
                    }
                    if (parameter.ChildrenAmount >= 3)
                    {
                        childData.TransplantChild1 = true;
                        childData.TransplantChild2 = true;
                        childData.TransplantChild3Plus = true;
                    }
                    parameter.ChildData = childData;
                }

                var rates = plexysProxy.GetRates(parameter);
                return Json(new
                {
                    principal = new { id = Convert.ToInt32(principal.id), amount = rates.PrincipalRate },
                    spouse = spouse == null ? null : new { id = Convert.ToInt32(spouse.id), amount = rates.SpouseRate },
                    amountPerChild = children.Count() == 0 ? 0 : rates.ChildrenRate / children.Count(),
                    total = rates.TotalRate
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { total = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        private static int GetAge(DateTime birthday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            return age;
        }

        #endregion

        #region [Helper Methods]

        //#if !DEBUG
        //        [OutputCache(Duration = 86400, VaryByParam = "none")]
        //#endif
        public ActionResult GetLimitsAge(bool isSon = false, bool isStudent = false)
        {
            return Json(new { min = isSon ? 0 : MIN_AGE_PERSON, max = isSon ? (isStudent ? MAX_AGE_STUDENT : MIN_AGE_PERSON) : MAX_AGE_PERSON }, JsonRequestBehavior.AllowGet);
        }

        private Dictionary<int, PersonHealth> SavePersons(QuotationSalud quotation, string persons)
        {
            //Persons
            var updatedPersons = JsonConvert.DeserializeObject<List<dynamic>>(persons);

            PersonHealth dbPerson;
            var dictionary = new Dictionary<int, PersonHealth>();

            if (quotation.Persons == null)
                quotation.Persons = new List<PersonHealth>();

            //Delete
            var deleted = (from per in quotation.Persons
                           where !(updatedPersons.Where(d => (int)d.id > 0).Select(d => (int)d.id).Contains(per.Id))
                           select per).ToList();

            foreach (var per in deleted)
            {
                quotation.Persons.Remove(per);
                dataAccess.Persons.Remove(per);
            }

            //create
            var newPersons = updatedPersons.Where(u => u.id < 0);
            foreach (var per in newPersons)
            {
                dbPerson = new PersonHealth();
                dataAccess.Persons.Add(dbPerson);
                quotation.Persons.Add(dbPerson);
                MapPersonToDB(per, dbPerson);
                dictionary.Add((int)per.id, dbPerson);
                dbPerson.Id = 0;
            }

            //Update
            var personsToUpdate = updatedPersons.Where(u => u.id > 0);
            foreach (var drv in personsToUpdate)
            {
                int id = drv.id;
                dbPerson = quotation.Persons.FirstOrDefault(d => d.Id == id);
                MapPersonToDB(drv, dbPerson);
            }
            return dictionary;

            //End persons
        }

        private void MapPersonToDB(dynamic newPersonData, PersonHealth personToUpdate)
        {
            personToUpdate.FirstName = newPersonData.firstName;
            personToUpdate.SecondName = newPersonData.secondName;
            personToUpdate.FirstSurname = newPersonData.firstSurname;
            personToUpdate.SecondSurname = newPersonData.secondSurname;
            personToUpdate.Email = newPersonData.email1;
            personToUpdate.Email2 = newPersonData.email2;
            personToUpdate.Email3 = newPersonData.email3;
            personToUpdate.PhoneNumber = newPersonData.phoneNumber;
            personToUpdate.DateOfBirth = DateTime.Parse((string)newPersonData.dateOfBirth, culture);
            personToUpdate.IsPrincipal = newPersonData.titular;
            personToUpdate.Sex = newPersonData.selectedSex;
            personToUpdate.Relationship = newPersonData.relationship;
            personToUpdate.Prime = newPersonData.totalPrime;
            if (personToUpdate.IsPrincipal)
            {
                personToUpdate.Income = newPersonData.income;
                personToUpdate.IsStudent = null;
            }
            else
            {
                personToUpdate.Income = null;
                if (personToUpdate.Relationship == "Hijo" || personToUpdate.Relationship == "Hija")
                    personToUpdate.IsStudent = newPersonData.student;
                else
                    personToUpdate.IsStudent = null;
            }

            {
                var cityId = ((string)newPersonData.cityId).Split('-');
                var dregId = Convert.ToInt32(cityId[0]);
                var stprovId = Convert.ToInt32(cityId[1]);
                var ctyId = Convert.ToUInt32(cityId[2]);
                var city = (from c in dataAccess.ST_GLOBAL_CITY
                            where c.Domesticreg_Id == dregId
                            && c.State_Prov_Id == stprovId
                            && c.City_Id == ctyId
                            select c).FirstOrDefault();
                personToUpdate.City = city;
            }
            if (((string)newPersonData.workCityId) != null)
            {
                var workCityId = ((string)newPersonData.workCityId).Split('-');
                var dregId = Convert.ToInt32(workCityId[0]);
                var stprovId = Convert.ToInt32(workCityId[1]);
                var ctyId = Convert.ToUInt32(workCityId[2]);
                var city = (from c in dataAccess.ST_GLOBAL_CITY
                            where c.Domesticreg_Id == dregId
                            && c.State_Prov_Id == stprovId
                            && c.City_Id == ctyId
                            select c).FirstOrDefault();
                personToUpdate.WorkCity = city;
            }
            else
                personToUpdate.WorkCity = null;

            //Additional information
            personToUpdate.Address = newPersonData.address;
            personToUpdate.Mobile = newPersonData.mobile;
            personToUpdate.WorkPhone = newPersonData.workPhone;
            personToUpdate.MaritalStatus = newPersonData.maritalStatus;
            personToUpdate.PartnerName = newPersonData.partnerName;
            personToUpdate.Job = newPersonData.job;
            personToUpdate.Company = newPersonData.company;
            personToUpdate.YearsInCompany = newPersonData.yearsInCompany;
            personToUpdate.WorkAddress = newPersonData.workAddress;
            personToUpdate.IsSmoker = newPersonData.smoker ?? false;
            personToUpdate.IsHighPressure = newPersonData.highPressure ?? false;
            personToUpdate.IsExtremeAthlete = newPersonData.extremeSport ?? false;

            personToUpdate.Complication = newPersonData.adicComplications ?? false;
            personToUpdate.Transplant = newPersonData.adicTransplant ?? false;

            personToUpdate.Weight = newPersonData.weight;
            personToUpdate.Height = newPersonData.height;
            personToUpdate.Condition1 = newPersonData.preexistingCondition >= 1 ? newPersonData.condition1 : null;
            personToUpdate.Condition1Description = newPersonData.preexistingCondition >= 1 ? newPersonData.condition1Description : null;
            personToUpdate.Condition2 = newPersonData.preexistingCondition >= 2 ? newPersonData.condition2 : null;
            personToUpdate.Condition2Description = newPersonData.preexistingCondition >= 2 ? newPersonData.condition2Description : null;
            personToUpdate.Condition3 = newPersonData.preexistingCondition >= 3 ? newPersonData.condition3 : null;
            personToUpdate.Condition3Description = newPersonData.preexistingCondition >= 3 ? newPersonData.condition3Description : null;

            ST_GLOBAL_COUNTRY nationality = null;
            if (newPersonData["countryId"] != null)
            {
                int nationalityId = (int)newPersonData.countryId;
                if (nationalityId != 0)
                {
                    nationality = (from c in dataAccess.ST_GLOBAL_COUNTRY
                                   where c.Global_Country_Id == nationalityId
                                   select c).FirstOrDefault();
                }
            }
            personToUpdate.Nationality = nationality;

            ST_GLOBAL_COUNTRY wNationality = null;
            if (newPersonData["workCountryId"] != null)
            {
                int nationalityId = (int)newPersonData.workCountryId;
                if (nationalityId != 0)
                {
                    wNationality = (from c in dataAccess.ST_GLOBAL_COUNTRY
                                    where c.Global_Country_Id == nationalityId
                                    select c).FirstOrDefault();
                }
            }
            personToUpdate.WorkNationality = wNationality;

        }

        private int GetNewDailyQuotationNumber()
        {
            var maxDb = (from q in dataAccess.Quotations
                         where DbFunctions.TruncateTime(q.Created) == DbFunctions.TruncateTime(DateTime.Now)
                         orderby q.QuotationDailyNumber descending
                         select q).FirstOrDefault();

            if (maxDb != null)
                return maxDb.QuotationDailyNumber + 1;
            else
                return 0;
        }

        #endregion

        #region [Reports]

        [AjaxHandleError]
        [HttpGet]
        public JsonResult ReporteCotizacionSalud(int nroCotizacion)
        {
            byte[] result;
            byte[] cotizacion = System.IO.File.ReadAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "/Reports/QuotationPrevSalud.rdlc");


            using (var renderer = new WebReportRenderer(cotizacion, "Cotizacion.pdf"))
            {

                var QuotationDetail = dataAccess.GetQuotationDetailSaludQP(nroCotizacion);
                var Persons = dataAccess.GetPersonsQP(nroCotizacion);

                renderer.ReportInstance.DataSources.Add(new ReportDataSource("QuotationDetail", QuotationDetail));
                renderer.ReportInstance.DataSources.Add(new ReportDataSource("Persons", Persons));


                renderer.ReportInstance.EnableExternalImages = true;

                result = renderer.RenderToBytesPDF();
            }

            string path = "/Tmp/Cotizacion.pdf";
            System.IO.File.WriteAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + path, result);
            return Json(new { reportName = path }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EnviarReporteEmail(string destinatarios, int idCotizacion, string reportName)
        {
            List<string> destinatariosList = JsonConvert.DeserializeObject<List<string>>(destinatarios);

            destinatariosList.RemoveAll(s => string.IsNullOrWhiteSpace(s));

            if (!destinatariosList.Any() || !SendEmailHelper.ValidAddresses(destinatariosList))
                return Json(new { error = "Una o más direcciones de correo no tienen el formato correcto." }, JsonRequestBehavior.AllowGet);

            var subject = dataAccess.GetParameter(Parameter.PARAMETER_KEY_REPORT_EMAIL_SUBJECT, "Reporte").Value;
            var body = dataAccess.GetParameter(Parameter.PARAMETER_KEY_REPORT_EMAIL_BODY, "Se adjunta el reporte solicitado.").Value;
            var sender = dataAccess.GetParameter(Parameter.PARAMETER_KEY_EMAIL_SENDER, "internet@atlantica.do").Value;

            //Si no recibo el directorio por parámetro, creo el reporte
            if (string.IsNullOrWhiteSpace(reportName))
            {
                var reporte = ReporteCotizacionSalud(idCotizacion);
                reportName = (string)reporte.Data.GetType().GetProperty("reportName").GetValue(reporte.Data, null);
            }

            SendEmailHelper.SendMail(sender, destinatariosList, subject, body, System.AppDomain.CurrentDomain.BaseDirectory + reportName);

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintReport(string sourceFile)
        {
            var pdfLocalFilePath = System.AppDomain.CurrentDomain.BaseDirectory + sourceFile;

            var path = "/Tmp/" + Path.GetRandomFileName() + ".pdf";
            var outputLocalFilePath = System.AppDomain.CurrentDomain.BaseDirectory + path;
            using (var outputStream = new FileStream(outputLocalFilePath, FileMode.CreateNew))
            {
                //outputStream.Flush();
                PdfReader reader = new PdfReader(pdfLocalFilePath);
                int pageCount = reader.NumberOfPages;
                Rectangle pageSize = reader.GetPageSize(1);

                // Set up Writer 
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, outputStream);

                document.Open();
                document.AddAuthor("Atlantica");

                //Copy each page 
                PdfContentByte content = writer.DirectContent;

                for (int i = 0; i < pageCount; i++)
                {
                    document.NewPage();
                    // page numbers are one based 
                    PdfImportedPage page = writer.GetImportedPage(reader, i + 1);
                    // x and y correspond to position on the page 
                    content.AddTemplate(page, 0, 0);
                }

                // Inert Javascript to print the document after a fraction of a second to allow time to become visible.
                //string jsText = @"this.print\({bUI:true,bSilent:false,bShrinkToFit:true}\);";

                string jsTextNoWait = "var pp = this.getPrintParams();pp.interactive = pp.constants.interactionLevel.full;this.print(pp);";
                PdfAction js = PdfAction.JavaScript(jsTextNoWait, writer);
                //writer.AddJavaScript(js);
                PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
                writer.SetOpenAction(action);
                writer.SetAdditionalAction(PdfWriter.DID_PRINT, PdfAction.JavaScript("self.close())", writer));


                document.Close();
            }

            return Json(new { reportName = path }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}