using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KSI.Cobranza.Web.Models;
using KSI.Cobranza.Web.Models.ViewModels;
using KSI.Cobranza.Web.Common;
using System.IO;
using System.Globalization;

namespace KSI.Cobranza.Web.Controllers
{
    public class ProcessController : BaseController
    {
        public List<AttachedFilesViewModels> TempDataAttachedFilesViewModels = new List<AttachedFilesViewModels>();

        public List<AttachedFilesViewModels> oTemDataNoteAttachedFiles
        {
            get
            {
                return Session["TempDataAttachedFilesViewModels"] == null ?
                    new List<AttachedFilesViewModels>() :
                    Session["TempDataAttachedFilesViewModels"] as List<AttachedFilesViewModels>;
            }

            set
            {
                List<AttachedFilesViewModels> tempList = null;

                if (value != null)
                {
                    tempList = new List<AttachedFilesViewModels>(Session["TempDataAttachedFilesViewModels"] != null ?
                      ((List<AttachedFilesViewModels>)Session["TempDataAttachedFilesViewModels"]) :
                      new List<AttachedFilesViewModels>());
                    tempList.AddRange(value);
                }

                Session["TempDataAttachedFilesViewModels"] = tempList;
            }
        }

        private ProcessModel _oProcessModel { get; set; }

        public ProcessController()
        {
            _oProcessModel = new Lazy<ProcessModel>().Value;
        }

        // GET: Process

        public ActionResult Index(string data)
        {
            var model = new ProcessViewModels();

            var objDataReqeuest = string.Empty;
            if (!string.IsNullOrEmpty(data))
            {
                objDataReqeuest = Utility.URLDecrypt(data.Replace(" ", "+"));
                var dataResult = Utility.deserializeJSON<dataRequest>(objDataReqeuest);
                var baseModel = new BaseModel();

                ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
                {
                    Key = o.Key,
                    Value = o.Value
                }).ToList();

                model = _oProcessModel.GetProcessModel(dataResult);

                var DataPayment = _oProcessModel.GetReceipOfPayment(dataResult.accountId);
                var AccountRow = DataPayment.FirstOrDefault();

                ViewBag.Account = dataResult.account;
                ViewBag.AccountNumber = model.LoanInformationViewModels.AccountId;
                ViewBag.LoanNumber = model.LoanInformationViewModels.LoanNumber;
                ViewBag.LoanStatusName = model.LoanInformationViewModels.LoanStatusName;
                ViewBag.AccountName = model.LoanInformationViewModels.fullName;

                ViewBag.BaseURL = string.Concat("/Process/Index/", System.Web.HttpContext.Current.Request.Url.Query, "&Page=");
            }
            else
                return RedirectToAction("Index", "Home", new SearchViewModels());

            return View(model);
        }

        public PartialViewResult GetCodeudorPersonalInformation(long? Id)
        {
            var model = new PersonalInformationViewModels
                {
                    phones = new List<Phone>(0),
                    emails = new List<EmailAddress>(0)
                };

            model = _oProcessModel.GetPersonalInformation(Id);

            return PartialView("_PersonalInformation", model);
        }

        public PartialViewResult _ContactPhone(long? CustomerId)
        {
            var model = GetDataPhone(CustomerId);
            return
                PartialView(model);
        }

        public PartialViewResult _ContactEmailAddress(long? CustomerId)
        {
            var model = GetDataEmail(CustomerId);
            return
              PartialView(model);
        }

        public void CheckPrimaryPhone(long? CustomerId, int Id)
        {
            _oProcessModel.SetCustomerPrimaryPhone(CustomerId, Id);
        }

        public void CheckPrimaryEmail(long? CustomerId, int Id)
        {
            _oProcessModel.SetCustomerPrimaryEmail(CustomerId, Id);
        }

        public PartialViewResult _GuaranteeList(long? AccountId)
        {
            return
                PartialView(GetDataGuarantee(AccountId));
        }

        public PartialViewResult _LoanInformation(long? quotationId, int? loanNumber, long? accountId)
        {
            var model = _oProcessModel.GetLoanDetail(null, null, accountId);

            return
                PartialView(model);
        }

        public PartialViewResult _VehicleInformation(long? AccountId)
        {
            return
                PartialView(GetDataGuarantee(AccountId));
        }

        public PartialViewResult _VehicleDetail(long? CollateralId)
        {
            var model = _oProcessModel.GetVehicleDetail(CollateralId);
            return
                PartialView(model);
        }

        public PartialViewResult _CodeudorInformation(long? AccountId)
        {
            var model = new List<codeudor>(0);
            model = _oProcessModel.GetCodeudor(AccountId).ToList();
            if (model.Any())
            {
                var Record = model.FirstOrDefault();
                ViewBag.AccountNumber = Record.account;
                ViewBag.Id = Record.accountId;
                ViewBag.Status = Record.accountStatusName;
                ViewBag.AccountName = Record.accountName;
                ViewBag.Customer = Record.Fullname;
            }
            //Infrastructure.Repositories.cardnetservice.CardnetServiceRepository a = new Infrastructure.Repositories.cardnetservice.CardnetServiceRepository();
            //var A = a.SetPaymentCardnet("4761340000000037", "21", "10", "799", 100, 10, "test", "app"); 
            return
                PartialView(model);
        }

        public PartialViewResult _PolicyInformation(long? AccountId)
        {
            var model = _oProcessModel.GetPolicyInfomation(AccountId);

            return
                PartialView(model);
        }

        public PartialViewResult _PaymentPlan(long? AccountId)
        {
            var model = _oProcessModel.GetPaymentPlan(AccountId);
            var DataAccount = _oProcessModel.GetReceipOfPayment(AccountId);
            var AccountRow = DataAccount.FirstOrDefault();
            var LoanData = _oProcessModel.GetLoanDetail(null, null, AccountId);


            ViewBag.AccountNumber = LoanData.AccountId;
            ViewBag.LoanNumber = LoanData.LoanNumber;
            ViewBag.AccountName = LoanData.fullName;
            return
                PartialView(model);
        }

        public PartialViewResult _ReceipOfPayment(long? AccountId, string[] filters = null)
        {
            var model = _oProcessModel.GetReceipOfPayment(AccountId);

            if (filters != null)
            {
                filters = filters.Where(o => o != "0").ToArray();
                if (filters.Length > 0)
                    model = model.Where(x => filters.Contains(x.transactionReasonId.ToString())).ToList();
            }

            var baseModel = new BaseModel();

            ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            }).ToList();

            return
                PartialView(model);
        }

        public PartialViewResult _frmPhone(long? Id)
        {
            var model = _oProcessModel.GetPhoneModel(Id);
            return
                PartialView(model);
        }

        public PartialViewResult _frmEmail(long? Id)
        {
            var model = _oProcessModel.GetEmailModel(Id);

            return
                PartialView(model);
        }

        public PartialViewResult SetEmail(EmailAddress EmailAddress)
        {
            var model = _oProcessModel.GetEmailModel(null);

            if (ModelState.IsValid)
            {
                EmailAddress.Usuario = vUsr;
                var result = _oProcessModel.SetEmail(EmailAddress);
            }

            return
                PartialView("_frmEmail", model);
        }

        public PartialViewResult SetPhone(Phone phone)
        {
            if (ModelState.IsValid)
            {
                phone.Number = phone.Number.Replace("(", "").Replace(")", "-");
                phone.AreaCoede = phone.Number.Substring(0, 3);
                phone.Number = phone.Number.Substring(4, 8);
                phone.Usuario = vUsr;
                var result = _oProcessModel.SetPhone(phone);
            }

            var model = _oProcessModel.GetPhoneModel(null);
            return
                PartialView("_frmPhone", model);
        }

        public PartialViewResult _ProjectedStatement(Nullable<long> accountId = null)
        {
            var DataAccount = _oProcessModel.GetReceipOfPayment(accountId);
            var LoanData = _oProcessModel.GetLoanDetail(null, null, accountId);
            var AccountRow = DataAccount.FirstOrDefault();

            ViewBag.AccountNumber = LoanData.AccountId;
            ViewBag.LoanNumber = LoanData.LoanNumber;
            ViewBag.AccountName = LoanData.fullName;
            ViewBag.FilterDayDefault = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:MM/dd/yyyy}", DateTime.Now);

            var ProjectedAmounts = _oProcessModel.GetProjectStatement(accountId, DateTime.Now, 3, 0);

            var OutStandingAmount = ProjectedAmounts.FirstOrDefault(o => o.Description.Contains("Saldo Total a Pagar"));
            if (OutStandingAmount != null)
                ViewBag.OutStandingBalance = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", Convert.ToDecimal(OutStandingAmount.Value));
            else
                ViewBag.OutStandingBalance = 0;

            return PartialView();
        }

        public PartialViewResult _GridProjectedStatement(Nullable<long> accountId = null, Nullable<System.DateTime> dateStatement = null, Nullable<int> idTipo = null, Nullable<decimal> montoPago = null)
        {
            var model = _oProcessModel.GetProjectStatement(accountId, dateStatement, idTipo, montoPago).ToList();
            model = model.Select(o => new paymentProjection
            {
                Description = o.Description,
                TipoSaldo = o.TipoSaldo,
                Value = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", Convert.ToDecimal(o.Value))
            }).ToList();

            var OutStandingAmount = model.FirstOrDefault(o => o.Description.Contains("Saldo Total a Pagar"));
            if (OutStandingAmount != null)
                ViewBag.OutStandingBalance = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:0,0.00}", OutStandingAmount.Value);
            else
                ViewBag.OutStandingBalance = 0;

            return PartialView(model);
        }

        public PartialViewResult _GridReceipOfPayment(long? AccountId, string[] filters = null)
        {
            var model = _oProcessModel.GetReceipOfPayment(AccountId);
            var AccountRow = model.FirstOrDefault();

            if (filters != null)
            {
                filters = filters.Where(o => o != "0").ToArray();
                if (filters.Length > 0)
                {
                    model = model.Where(x => filters.Contains(x.transactionReasonId.ToString())).ToList();
                }
            }

            var baseModel = new BaseModel();

            ViewBag.TransactionReasons = baseModel.GetDropDown(Enums.DropDownType.transactionreason).Select(o => new BaseViewModels.KeyValue
            {
                Key = o.Key,
                Value = o.Value
            }).ToList();

            return
                PartialView(model);
        }

        public PartialViewResult _PaymentProcess(long? AccountId, string Account)
        {
            var model = _oProcessModel.GetPaymentProcessModel(AccountId);
            model.Account = Account;
            return
                PartialView(model);
        }

        public PartialViewResult SetPaymentProcess(PaymentProcessViewModels model)
        {
            var modelTemp = _oProcessModel.GetPaymentProcessModel(model.AccountId);
            model.Years = modelTemp.Years;
            model.CardTypes = modelTemp.CardTypes;

            if (ModelState.IsValid)
            {
                Nullable<long> creditDebitDirectPaymentId = null;
                Nullable<long> accountId = model.AccountId;
                Nullable<int> cardTypeId = model.CardTypeId;
                Nullable<int> directPaymentStatusId = Enums.DirectPaymentStatus.PendienteProcesar.ToInt();
                string cardNumber = model.CardNumber;
                var start = model.CardNumber.Length - 4;
                string lastFourDigits = model.CardNumber.Substring(start, 4);
                string cardName = model.CardTypeDesc;
                Nullable<int> yearExpiration = model.CardExpirationYear;
                Nullable<int> monthExpiration = model.CardExpirationMonth;
                Nullable<decimal> quotaAmount = model.share;
                Nullable<decimal> balance = model.Balance;
                Nullable<decimal> amountPaid = model.AmountReceivable;
                Nullable<System.DateTime> datePaid = DateTime.Now;
                Nullable<System.DateTime> dateProcessedCard = null;
                Nullable<System.DateTime> dateProcessedEasybank = null;
                string authorizationNumber = string.Empty;
                string receiptNumberEasybank = string.Empty;
                Nullable<int> userId = vUsr.UserID;
                string userName = vUsr.UserLogin;

                //Llamar el metodo de pago CardNet 
                var startYear = yearExpiration.GetValueOrDefault().ToString().Length - 2;
                var YearLastTwoDigits = yearExpiration.GetValueOrDefault().ToString().Substring(startYear, 2);
                var resultApplyCardnetPayment = _oProcessModel.ApplyPaymentCardNet(cardNumber,
                                                                                   YearLastTwoDigits,
                                                                                   monthExpiration.GetValueOrDefault().ToString(),
                                                                                   model.CVV,
                                                                                   amountPaid.GetValueOrDefault(),
                                                                                   0,
                                                                                   userName,
                                                                                   "CobranzaApp"
                                                                                   );

                if (resultApplyCardnetPayment.Result && resultApplyCardnetPayment._jsonResult.ResponseCode == "00")
                {
                    authorizationNumber = resultApplyCardnetPayment.AuthorizationCode;
                    model.authorizationNumber = authorizationNumber;
                    dateProcessedCard = DateTime.Now;
                    model.ModelErrorList.Add(string.Format("El pago se aplico exitosamente en el procesador de pagos Numero de autorización : {0}", authorizationNumber));

                    //Llamar el metodo de pago Easy Bank
                    var ApplyResult = _oProcessModel.ApplyPaymentEasyBank(model.Account, amountPaid.GetValueOrDefault(), 10);
                    if (!ApplyResult.Success)
                    {
                        model.ModelErrorList.Add("No se pudo aplicar el pago en Easy Bank");
                        model.ModelErrorList.AddRange(ApplyResult.ModelErrorList);
                        model.ModelErrorList.Add(ApplyResult.ErrorMessage);
                        model.ErrosInJsonFormat = Utility.serializeToJSON(model.ModelErrorList);
                        model.hasError = true;
                    }
                    else
                    {
                        receiptNumberEasybank = ApplyResult.NoRecibo.ToString();
                        model.receiptNumberEasybank = receiptNumberEasybank;
                        dateProcessedEasybank = DateTime.Now;
                        model.ModelErrorList.Add("El pago se creo exitosamente en Easy Bank");
                        model.ErrosInJsonFormat = Utility.serializeToJSON(model.ModelErrorList);
                    }
                }
                else
                {
                    var msgResponseCardNet = string.Empty;
                    if (!resultApplyCardnetPayment.Result && resultApplyCardnetPayment._jsonResult != null)
                        msgResponseCardNet = string.Format("Respuesta No : {0} <br> Mensaje de Respuesta {1}", resultApplyCardnetPayment._jsonResult.ResponseCode, resultApplyCardnetPayment._jsonResult.ResponseMSG);
                    else
                        msgResponseCardNet = "Error procesando pago en el procesador de pagos, Error :" + string.Join("<br>", resultApplyCardnetPayment.ModelErrorList.ToArray());

                    model.ModelErrorList.Add(msgResponseCardNet);
                    model.ErrosInJsonFormat = Utility.serializeToJSON(model.ModelErrorList);
                    model.hasError = true;
                }

                //Guardar en la base de de datos loan
                var result = _oProcessModel.SetPaymentProcess(
                      creditDebitDirectPaymentId,
                      accountId,
                      cardTypeId,
                      directPaymentStatusId,
                      cardNumber,
                      lastFourDigits,
                      cardName,
                      yearExpiration,
                      monthExpiration,
                      quotaAmount,
                      balance,
                      amountPaid,
                      datePaid,
                      dateProcessedCard,
                      dateProcessedEasybank,
                      authorizationNumber,
                      receiptNumberEasybank,
                      userId,
                      userName
                    );
            }
            else
            {
                var Errors = GetErrorsFromModel();
                model.ModelErrorList.AddRange(Errors);
                model.ErrosInJsonFormat = Utility.serializeToJSON(model.ModelErrorList);
                model.hasError = true;
            }

            return
                PartialView("_PaymentProcess", model);
        }

        public PartialViewResult _GetPartialTemplate(string PartialViewName)
        {
            PartialViewName = string.Concat("_THTemplate_", PartialViewName);

            return
                 PartialView(PartialViewName);
        }

        public JsonResult GetProjectStatement(Nullable<long> accountId = null, Nullable<System.DateTime> dateStatement = null, Nullable<int> idTipo = null, Nullable<decimal> montoPago = null)
        {
            var model = _oProcessModel.GetProjectStatement(accountId, dateStatement, idTipo, montoPago).ToList();
            return
                Json(model, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _GridCases(Nullable<long> relatedContactId, Nullable<long> accountId, string CustomerName, string LoanNumber)
        {
            var model = _oProcessModel.GetCasesViewModel(relatedContactId, accountId, null, null, CustomerName, LoanNumber).Cases;
            return
                PartialView(model);
        }

        public PartialViewResult _Notes(Nullable<long> relatedContactId, Nullable<long> accountId, string CustomerName, string LoanNumber)
        {
            var model = _oProcessModel.GetCasesViewModel(relatedContactId, accountId, null, null, CustomerName, LoanNumber);
            return
                  PartialView(model);
        }

        public PartialViewResult _CasesDetail(long? relatedContactId,
                                              Nullable<int> meetingTypeId,
                                              Nullable<int> meetingSubTypeId,
                                              Nullable<int> meetingCaseId,
                                              Nullable<int> meetingCaseNoteId,
                                              string LoanNumber
                                              )
        {
            var URLBase = "http://" + System.Web.HttpContext.Current.Request.Url.Authority + "{0}/{1}";

            Func<string, string> EncodingUrl = (url) =>
            {
                return System.Web.HttpUtility.UrlEncode(url);
            };

            var model = _oProcessModel.GetCasesDetailViewModel(relatedContactId,
                                                               meetingTypeId,
                                                               meetingSubTypeId,
                                                               meetingCaseId,
                                                               meetingCaseNoteId,
                                                               URLBase,
                                                               LoanNumber,
                                                               EncodingUrl
                                                               ).CasesDetailViewModels;
            return
                  PartialView(model);
        }

        public PartialViewResult GeAttechedNoteFiles()
        {
            var model = oTemDataNoteAttachedFiles;
            return
                PartialView("_MeetingAttachedFiles", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void LoadFileNote(FormCollection frm)
        {
            var LoanNumber = frm["LoanNumber"].ToString();
            HttpPostedFileBase file = this.HttpContext.Request.Files.Get("fFileNote");
            var PathRoot = Server.MapPath("~/" + FileFolderDocs);

            //Crear carpeta de prestamo
            var DirectoryPath = string.Concat(PathRoot, @"\", LoanNumber);
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);

            if (file != null)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var sizeInMB = ((decimal)(file.ContentLength / 1024)) / 1024;
                    var fileName = Utility.GetSerialId() + Path.GetFileName(file.FileName);
                    var path = Path.Combine(DirectoryPath, fileName);
                    file.SaveAs(path);

                    var MaxId = oTemDataNoteAttachedFiles.Any() ? oTemDataNoteAttachedFiles.Max(c => c.Id) : 0;
                    var nextId = MaxId + 1;

                    var itemFile = new AttachedFilesViewModels
                    {
                        Id = nextId,
                        LoanNumber = LoanNumber,
                        DocumentTypeId = int.Parse(frm["DocumentTypeId"].ToString()),
                        DocumentGroupId = int.Parse(frm["DocumentGroupId"].ToString()),
                        documentGroupName = frm["documentGroupName"].ToString(),
                        DocumentTypeDesc = frm["DocumentTypeDesc"].ToString(),
                        FileName = fileName,
                        DocumentPath = path,
                        sizeFile = sizeInMB
                    };

                    TempDataAttachedFilesViewModels.Add(itemFile);
                    oTemDataNoteAttachedFiles = TempDataAttachedFilesViewModels;
                }
            }
        }

        [HttpPost]
        public PartialViewResult SetMeegintNote(MeetingNoteViewModels model)
        {
            if (ModelState.IsValid)
            {
                long? relatedContactId = model.relatedContactId;
                int? meetingTypeId = model.ServiceId;
                int? meetingSubTypeId = model.SubServiceId;
                int? meetingCaseId = model.meetingCaseId;
                long? accountId = model.accountId;
                int? meetingStatusId = model.CasesStatusId;
                int? reasonId = model.ContactReasonId;
                int? departmentId = null;
                int? categoryId = model.CategoryId;
                long? caseNumber = model.CaseId;
                DateTime? meetingDate = DateTime.Now;
                string meetingShortNote = "";
                int? callAssignedId = null;
                string notifiedToEmail = null;
                bool? notified = null;
                int? attemptNo = null;
                bool? isActive = true;
                int? userId = base.GetCurrentUserID();
                Nullable<System.DateTime> meetingClosedDate = null;
                Nullable<int> queueId = null;
                string userName = base.GetCurrentUserName();

                //1.- Crear el caso
                var MeetingCaseId = _oProcessModel.SetMeetingCase(relatedContactId, meetingTypeId, meetingSubTypeId, meetingCaseId, accountId, meetingStatusId, reasonId, departmentId, categoryId,
                                                                  caseNumber, meetingDate, meetingShortNote, callAssignedId, notifiedToEmail, notified, attemptNo, isActive, userId, userName, meetingClosedDate, queueId);


                //2.- Crear la nota
                var CaseNoteId = _oProcessModel.SetMeetingNote(relatedContactId,
                                                               meetingTypeId,
                                                               meetingSubTypeId,
                                                               (meetingCaseId.HasValue) ? meetingCaseId : MeetingCaseId,
                                                               model.meetingCaseNoteId,
                                                               model.PriorityId,
                                                               model.ChannelServiceId,
                                                               model.originatedById,
                                                               model.Note,
                                                               isActive,
                                                               userId,
                                                               userName);



                switch (model.ChannelServiceId)
                {
                    case 2:
                        //Guardar la llamada seleccionada
                        //var KeyCalls = Utility.deserializeJSON<List<Utility.ItemCalls>>(model.CallsSelected);
                        var KeyCalls = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Utility.ItemCalls>>(model.CallsSelected);
                        foreach (var KeyCall in KeyCalls)
                        {
                            var ResultSetMeetinsCaseCall = _oProcessModel.SetMeetingCall(relatedContactId,
                                                                                         meetingTypeId,
                                                                                         meetingSubTypeId,
                                                                                         MeetingCaseId,
                                                                                         (int)CaseNoteId,
                                                                                         null,
                                                                                         TimeSpan.Parse(KeyCall.CallDuration),
                                                                                         KeyCall.CallStart,
                                                                                         KeyCall.CallStop,
                                                                                         KeyCall.DialedNumber,
                                                                                         KeyCall.Extension,
                                                                                         KeyCall.FileName,
                                                                                         KeyCall.FileLocation,
                                                                                         KeyCall.CallLogID.ToString(),
                                                                                         KeyCall.UserID.ToString(),
                                                                                         KeyCall.FirstName,
                                                                                         KeyCall.LastName,
                                                                                         isActive,
                                                                                         userId,
                                                                                         userName
                                                                                         );
                        }

                        break;
                    case 1:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                        //Guardar los archivos adjuntos
                        if (oTemDataNoteAttachedFiles != null)
                        {
                            string comments = "";
                            foreach (var item in oTemDataNoteAttachedFiles)
                            {
                                //Guardar en la base de datos
                                var ResultSetMettingCaseFile = _oProcessModel.SetMettingCaseFile(relatedContactId,
                                                                                                 meetingTypeId,
                                                                                                 meetingSubTypeId,
                                                                                                 MeetingCaseId,
                                                                                                 (int?)CaseNoteId,
                                                                                                 null,
                                                                                                 item.DocumentGroupId,
                                                                                                 item.DocumentPath,
                                                                                                 item.FileName,
                                                                                                 comments,
                                                                                                 isActive,
                                                                                                 userId,
                                                                                                 userName,
                                                                                                 item.sizeFile
                                                                                                );
                            }

                            oTemDataNoteAttachedFiles = null;
                        }
                        break;
                }
            }
            else
            {
                var Errors = GetErrorsFromModel();
                model.ModelErrorList.AddRange(Errors);
                model.ErrosInJsonFormat = Utility.serializeToJSON(model.ModelErrorList);
                model.hasError = true;
            }

            var modelresult = _oProcessModel.GetMeetingModel(model.relatedContactId, model.CustomerName, model.LoanNumber, model.accountId);
            return
                PartialView(modelresult);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void LoadFile(FormCollection frm)
        {
            var LoanNumber = frm["LoanNumber"].ToString();
            HttpPostedFileBase file = this.HttpContext.Request.Files.Get("fFile");
            var PathRoot = Server.MapPath("~/" + FileFolderDocs);

            //Crear carpeta de prestamo
            var DirectoryPath = string.Concat(PathRoot, @"\", LoanNumber);
            if (!Directory.Exists(DirectoryPath))
                Directory.CreateDirectory(DirectoryPath);

            if (file != null)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Utility.GetSerialId() + Path.GetFileName(file.FileName);
                    var path = Path.Combine(DirectoryPath, fileName);
                    file.SaveAs(path);
                    Nullable<long> templateSentRelatedFileId = frm["templateSentRelatedFileId"] != "" ? long.Parse(frm["templateSentRelatedFileId"].ToString()) : (long?)null;
                    Nullable<long> templateSentId = long.Parse(frm["templateSentId"].ToString());

                    Nullable<long> templateId = long.Parse(frm["SelectedTemplateId"].ToString());
                    Nullable<long> accountId = long.Parse(frm["accountId"].ToString());

                    Nullable<int> documentTypeGroupId = int.Parse(frm["DocumentTypeId"].ToString());
                    string documentPath = string.Concat(LoanNumber, @"\", fileName);
                    string documentName = file.FileName;
                    string comments = "";
                    Nullable<bool> isActive = true;
                    Nullable<int> userId = base.GetCurrentUserID();
                    string userName = base.GetCurrentUserName();
                    var sizeInMB = ((decimal)(file.ContentLength / 1024)) / 1024;
                    Nullable<decimal> sizeFile = sizeInMB;

                    //Guardar el registro de este archivo en la base de datos
                    var result = _oProcessModel.SetTemplateRelatedFile(templateSentRelatedFileId,
                                                                       templateSentId,
                                                                       documentTypeGroupId,
                                                                       documentPath,
                                                                       documentName,
                                                                       comments,
                                                                       isActive,
                                                                       userId,
                                                                       userName,
                                                                       sizeFile
                                                                       );
                }
            }
        }

        [HttpPost]
        public JsonResult SetTemplateHeader(long? templateSentId,
                                            short? templateId,
                                            long? accountId,
                                            DateTime? sendDate,
                                            string documentPath,
                                            string documentName,
                                            string emails,
                                            string comments,
                                            bool? isActive,
                                            bool? isSendToClient,
                                            bool? isSendToOffice,
                                            bool? isSendToAgent,
                                            int? caseDepartmentID,
                                            DateTime? caseDate,
                                            TimeSpan? caseHour,
                                            string caseComment,
                                            long? caseNo,
                                            long? EntityId = null
            )
        {
            var dataCustomer = _oProcessModel.GetCustomerInfo(EntityId);

            Nullable<int> userId = base.GetCurrentUserID();
            string userName = base.GetCurrentUserName();

            //Salvar el header del template generado
            var result = _oProcessModel.SetTemplate(templateSentId,
                                                    templateId,
                                                    accountId,
                                                    dataCustomer.clientId,
                                                    sendDate,
                                                    dataCustomer.FullName,
                                                    documentPath,
                                                    documentName,
                                                    emails,
                                                    comments,
                                                    isActive,
                                                    isSendToClient,
                                                    isSendToOffice,
                                                    isSendToAgent,
                                                    caseDepartmentID,
                                                    caseDate,
                                                    caseHour,
                                                    caseComment,
                                                    caseNo,
                                                    userId,
                                                    userName
                                                   ).entity;

            return
                 Json(result, JsonRequestBehavior.AllowGet);

        }


        public PartialViewResult _MakeNote(long? CustomerId, string CustomerName, string LoanNumber, long? accountId)
        {
            var model = _oProcessModel.GetMeetingModel(CustomerId, CustomerName, LoanNumber, accountId);
            return
                PartialView(model);
        }

        [HttpPost]
        public JsonResult DeleteFileNote(int Id)
        {
            JsonResult result;
            try
            {
                var recordToDelete = oTemDataNoteAttachedFiles.FirstOrDefault(file => file.Id == Id);
                System.IO.File.Delete(recordToDelete.DocumentPath);
                oTemDataNoteAttachedFiles.Remove(recordToDelete);
                result = Json(new { HasError = false, Message = "Exito" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                result = Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            return
                result;
        }

        public PartialViewResult _Email()
        {
            var model = _oProcessModel.GetAttachedFilesViewModels();
            return
                PartialView(model);
        }

        public PartialViewResult _PhoneCall()
        {
            var model = _oProcessModel.GetPhoneCall(base.CallRexPath, base.isDebug);
            return
                PartialView(model);
        }

        /// <summary>
        /// Validar los archivos adjuntos
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="accountId"></param>
        /// <param name="templateSentId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CanUploadFile(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId)
        {
            var data = _oProcessModel.ValidateAttachment(templateId, accountId, templateSentId, QuantityUploadDocs, LimitUploadDocsInMb);
            return
                  Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult _PdfViewer(string TemplateType, double MontoApagar, long AccountId, DateTime dateStatement, string LoanType, string NumeroCuota, bool IsPreview = true)
        {
            //Obtener el template a mostrar
            var BynaryFile = _oProcessModel.GetDocumentFromTH(TemplateType, Server.MapPath("~/"), MontoApagar, AccountId, dateStatement, LoanType, NumeroCuota, IsPreview).Item2;
            var PdfBase64 = Convert.ToBase64String(BynaryFile);
            var model = new Tuple<string, string>(string.Format("data:application/pdf;base64,{0}", PdfBase64), "100%");
            return
                PartialView(model);
        }

        public PartialViewResult _AttachedFiles(Nullable<long> templateId, Nullable<long> accountId, Nullable<long> templateSentId)
        {
            var model = _oProcessModel.GeAttachedFiles(templateId, accountId, templateSentId);
            return
                  PartialView(model);
        }

        [HttpPost]
        public JsonResult DeleteFile(Nullable<long> templateSentId, Nullable<long> Id)
        {
            var PathRoot = FileFolderDocs;
            var deleteResult = _oProcessModel.DeleteRelateFile(templateSentId, Id);
            _oProcessModel.DeleteRelatedFileFromDisk(string.Concat(Server.MapPath("~/"), @"\", PathRoot, @"\", deleteResult.entity.DocumentPath));
            return Json(deleteResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public EmptyResult SetCorrespondences(CorrespondenceViewModels model)
        {
            var MontoApagar = model.MontoApagar.GetValueOrDefault();
            var StartDate = model.StartDate.GetValueOrDefault();
            var LoanType = model.LoanType;
            var ListEmail = new List<string>(0);

            //Cliente primario
            if (model.HasSelectedPrimaryCustomer)
                ListEmail.Add(model.PrimaryCustomer);

            //Cliente Secundario
            if (model.HasSelectedSecundaryCustomer)
                ListEmail.Add(model.SecundaryCustomer);

            //Agente secundario
            if (model.HasSelectedPrimaryAgent)
                ListEmail.Add(model.PrimaryAgent);

            //Oficina
            if (model.HasSelectedOffice)
                ListEmail.Add(model.Office);

            //Proveedor
            if (model.HasSelectedProvider)
                ListEmail.Add(model.Provider);

            //Extra
            if (model.HasSelectedExtra)
                ListEmail.Add(model.Extra);

            //Departamento
            if (model.HasSelectedDepartment)
                ListEmail.Add(model.Department);

            var Emails = "";
            if (ListEmail.Any())
                Emails = string.Join(",", ListEmail.ToArray());

            var dataAttachment = _oProcessModel.GeAttachedFiles(model.SelectedTemplateId, model.accountId, model.RooTemplateSentId);

            var result = _oProcessModel.GetDocumentFromTH("COBBalanceDeSaldo",
                                                           Server.MapPath("~/"),
                                                           MontoApagar,
                                                           model.accountId.GetValueOrDefault(),
                                                           StartDate,
                                                           LoanType,
                                                           model.NumeroCuota,
                                                           false,
                                                           Emails,
                                                           PathAttachmentTHKSI,
                                                           dataAttachment
                                                           );


            //Actualizar el header
            SetTemplateHeader(model.RooTemplateSentId,
                              model.SelectedTemplateId,
                              model.accountId,
                              DateTime.Now,
                              null,
                              null,
                              Emails,
                              "",
                              false,
                              model.SendPrincipalCustomer,
                              model.SendPrincipalOffice,
                              model.SendPrincipalAgent,
                              model.TracingTypeId,
                              model.TracingDate,
                              !string.IsNullOrEmpty(model.Tracinghour) ? TimeSpan.Parse(model.Tracinghour) : (TimeSpan?)null,
                              model.CaseNumber.HasValue ? model.CaseNumber.GetValueOrDefault().ToString(CultureInfo.InvariantCulture) : null,
                              null
                              );

            return new EmptyResult();

        }

        public PartialViewResult _Correspondences(long? AccountId, long? CustomerId)
        {
            var model = _oProcessModel.GetLoanCorrespondence(AccountId);
            model.CustomerId = CustomerId;
            model.accountId = AccountId;
            return
                PartialView(model);
        }

        public PartialViewResult ShowPDF(string PathFile)
        {
            PathFile = string.Concat(FileFolderDocs, @"/", System.Web.HttpUtility.UrlDecode(PathFile).Replace(@"\", "/"));
            var Url = string.Concat("http://", System.Web.HttpContext.Current.Request.Url.Authority, "/", PathFile);
            var model = new Tuple<string, string>(Url, "816px");
            return
                PartialView("_PdfViewer", model);
        }

        public JsonResult GetDataCase(long? CaseNumber)
        {
            var data = _oProcessModel.GetCasesViewModel(null, null, CaseNumber, null);
            return
                Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSubServiceType(int ServiceId)
        {
            var data = _oProcessModel.GetDropDown(Enums.DropDownType.CallMeetingSubType, ServiceId);
            return
                Json(data, JsonRequestBehavior.AllowGet);
        }

        #region Get Data
        public GuaranteeViewModels GetDataGuarantee(long? AccountId)
        {
            var model = new GuaranteeViewModels { GuaranteeList = _oProcessModel.GetLoanGuarantee(AccountId), vehicleInformationDetail = new List<BaseViewModels.KeyValue>(0) };
            return
                 model;
        }

        public IEnumerable<Phone> GetDataPhone(long? CustomerId)
        {
            var data = _oProcessModel.GetPhones(CustomerId);
            return data;
        }

        public IEnumerable<EmailAddress> GetDataEmail(long? CustomerId)
        {
            var data = _oProcessModel.GetEmails(CustomerId);
            return data;
        }

        [HttpPost]
        public ActionResult GetMotnhs(int Year)
        {
            var result = _oProcessModel.GetMonhts(Year);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Cobranza
        public PartialViewResult _Collections(long? AccountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT, string account)
        {
            var data = _oProcessModel.GetCollection(AccountId, PaidF, PaidT, DebtF, DebtT);
            data.Account = account;
            return
              PartialView(data);
        }

        public PartialViewResult _CollectionsHistoryPaymentGrid(long? accountId, DateTime? PaidF, DateTime? PaidT, DateTime? DebtF, DateTime? DebtT)
        {
            var data = _oProcessModel.GetCollectionHistoryPayment(accountId, PaidF, PaidT, DebtF, DebtT).ToList();
            return
              PartialView("_CollectionsHistoryPaymentGrid", data);
        }

        public PartialViewResult _CollectionsDomiciliationGrid(long? accountId)
        {
            var data = _oProcessModel.GetCardDomitiliation(accountId);
            ModelState.Clear();
            return
              PartialView(data);
        }

        public PartialViewResult _CollectionsPayments(long? accountId)
        {
            var data = _oProcessModel.GetCollectionsPayments(accountId);

            ModelState.Clear();
            return
              PartialView(data);
        }

        public PartialViewResult _CardDomiciliation(string dataRequest)
        {
            var data = Utility.deserializeJSON<dataRequest>(Utility.URLDecrypt(dataRequest));
            var model = _oProcessModel.GetCardDomitiliation(data.accountId);
            model.CustomerId = data.CustomerId.GetValueOrDefault();
            model.AccountId = data.accountId.GetValueOrDefault();
            return PartialView(model);
        }
        public PartialViewResult _EditCardDomiciliation(string dataRequest)
        {
            var data = Utility.deserializeJSON<dataRequestCard>(Utility.URLDecrypt(dataRequest));
            var model = _oProcessModel.GetEditCardDomitiliationViewModel(data.accountId, data.clientId, data.CardTypeId, data.LastFourDigits);
            model.CustomerId = data.clientId.GetValueOrDefault();
            model.AccountId = data.accountId.GetValueOrDefault();
            return PartialView("_CardDomiciliation", model);
        }

        [HttpPost]
        public ActionResult SetDomicliation(CardDomitiliationViewModel cardDomitiliationViewModel)
        {
            if (ModelState.IsValid)
            {

                var ExpirationDateYYMM = string.Concat(cardDomitiliationViewModel.CardExpirationYear.ToString().Substring(2, 2), cardDomitiliationViewModel.CardExpirationMonth.ToString().Length == 1 ? "0" + cardDomitiliationViewModel.CardExpirationMonth.ToString() : cardDomitiliationViewModel.CardExpirationMonth.ToString());
                _oProcessModel.SetCardDomiciliation(cardDomitiliationViewModel.CustomerId,
                                                   cardDomitiliationViewModel.CardTypeId,
                                                   cardDomitiliationViewModel.LastFourDigits,
                                                   cardDomitiliationViewModel.CardNumber,
                                                   null,
                                                   null,
                                                   cardDomitiliationViewModel.CardHolder,
                                                   ExpirationDateYYMM,
                                                   cardDomitiliationViewModel.StatusId == 1,
                                                   GetCurrentUserID().GetValueOrDefault(),
                                                   cardDomitiliationViewModel.AccountId,
                                                   null,
                                                   null,
                                                   null,
                                                   null,
                                                    cardDomitiliationViewModel.StatusId == 1
                                                   );
            }

            //var data = _oProcessModel.GetCardDomitiliation(cardDomitiliationViewModel.AccountId);

            return new EmptyResult();
        }
        #endregion

    }
}