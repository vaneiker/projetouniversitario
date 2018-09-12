using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using WSVirtualOffice.Models;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.blinsurance;
using System.IO;
using WSVirtualOffice.Models.codes;

namespace WSVirtualOffice
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            loadstartupdata();
        }

        private void loadstartupdata()
        {
            DataVOUniversalDataContext newdb = Program.getDbConnection();

            try
            {
                //Program.db = new DataVOUniversal(System.Configuration.ConfigurationManager.ConnectionStrings["illustratorConnectionString"].ConnectionString);

                var userdata1 = from item1 in newdb.userdets
                                select item1;
                Program.userlist = userdata1.ToList();

                Program.lookupdatalist = new List<lookupdatadet>();

                var lookdata = from item1 in newdb.lookupdatadets
                               orderby item1.tablename, item1.lookupcaption
                               select item1;

                foreach (lookupdatadet item1 in lookdata)
                {
                    Program.lookupdatalist.Add(item1);
                }


                var userdetaildata = (from user in newdb.userdets
                                      from userdetails in newdb.userdetaildets
                                      where (user.userid == userdetails.userid)
                                      select new Userdata(user.userid, userdetails.FirstName, userdetails.LastName, userdetails.homeIntCode, userdetails.homeAreacode, userdetails.homephoneno));

                Program.userdetailslist = userdetaildata.ToList();

                // end login screen
                var users = from user in newdb.userdets
                            orderby user.userid
                            select user;
                Program.userlist = new List<userdet>();
                foreach (userdet user in users)
                {
                    Program.userlist.Add(user);
                }
                var occupations = from item in newdb.occupationtypedets
                                  orderby item.occupationtypecode
                                  select item;

                Program.occtypeslist = new List<occupationtypedet>();
                foreach (occupationtypedet occ in occupations)
                {
                    Program.occtypeslist.Add(occ);
                }


                var professions = from item in newdb.professiontypedets
                                  orderby item.professiontypecode
                                  select item;

                Program.professiontypeslist = new List<professiontypedet>();
                foreach (professiontypedet profess in professions)
                {
                    Program.professiontypeslist.Add(profess);
                }
                var rolename = from item in newdb.roledets
                               orderby item.roleno
                               select item;

                Program.rolelist = new List<roledet>();
                foreach (roledet item in rolename)
                {
                    Program.rolelist.Add(item);
                }

                var usertypes = from item in newdb.usertypedets
                                orderby item.usertypecode
                                select item;

                Program.usertypelist = new List<usertypedet>();
                foreach (usertypedet item in usertypes)
                {
                    Program.usertypelist.Add(item);
                }

                var genders = from item in newdb.genderdets
                              orderby item.gendercode
                              select item;

                Program.genderlist = new List<genderdet>();
                foreach (genderdet item in genders)
                {
                    Program.genderlist.Add(item);
                }



                var phonetypes = from item in newdb.phonetypedets
                                 orderby item.phonetypecode
                                 select item;

                Program.phonetypelist = new List<phonetypedet>();
                foreach (phonetypedet item in phonetypes)
                {
                    Program.phonetypelist.Add(item);
                }



                var emailtypes = from item in newdb.emailtypedets
                                 orderby item.emailtypecode
                                 select item;

                Program.emailtypelist = new List<emailtypedet>();
                foreach (emailtypedet item in emailtypes)
                {
                    Program.emailtypelist.Add(item);
                }


                var maritalstatuses = from item in newdb.maritalstatusdets
                                      orderby item.maritalstatuscode
                                      select item;

                Program.maritalstatuslist = new List<maritalstatusdet>();
                foreach (maritalstatusdet item in maritalstatuses)
                {
                    Program.maritalstatuslist.Add(item);
                }

                var referraltypes = from item in newdb.referraltypedets
                                    orderby item.referraltypecode
                                    select item;

                Program.referraltypeslist = new List<referraltypedet>();
                foreach (referraltypedet item in referraltypes)
                {
                    Program.referraltypeslist.Add(item);
                }


                var mortalitys = from mortality in newdb.mortalityvaluesdets
                                 orderby mortality.age
                                 select mortality;

                Program.mortalitydata = new mortalityvaluesdet[mortalitys.Count()];
                int i = -1;
                foreach (mortalityvaluesdet mortality in mortalitys)
                {
                    i++;
                    Program.mortalitydata[i] = mortality;

                }

                var actrisks = from actrisk in newdb.activityrisktypedets
                               orderby actrisk.activityrisktypeno
                               select actrisk;

                foreach (activityrisktypedet actrisk in actrisks)
                {
                    Program.actrisklist.Add(actrisk);
                }



                var healthrisks = from healthrisk in newdb.healthrisktypedets
                                  orderby healthrisk.healthrisktypeno
                                  select healthrisk;


                foreach (healthrisktypedet healthrisk in healthrisks)
                {
                    Program.healthrisklist.Add(healthrisk);
                }


                var investprofiles = from investprofile in newdb.investmentprofiledets
                                     orderby investprofile.investmentprofilecode
                                     select investprofile;

                foreach (investmentprofiledet investprofile in investprofiles)
                {
                    Program.investprofilelist.Add(investprofile);
                }

                var calcobtypes = from item in newdb.calculatetypeobdets
                                  orderby item.calculatetypeob
                                  select item;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (calculatetypeobdet item in calcobtypes)
                {
                    Program.calcobtypeslist.Add(item);

                }

                var comms = from comm in newdb.commissiondets
                            orderby comm.yearno
                            select comm;
                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (commissiondet comm in comms)
                {
                    Program.commissionlist.Add(comm);
                }

                var frequencies = from frequency in newdb.frequencytypedets
                                  orderby frequency.frequencytypecode
                                  select frequency;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (frequencytypedet frequency in frequencies)
                {
                    Program.frequencylist.Add(frequency);

                }

                var freqcosts = from frequency in newdb.frequencycostdets
                                orderby frequency.productcode
                                select frequency;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (frequencycostdet frequency in freqcosts)
                {
                    Program.freqcostlist.Add(frequency);
                }


                var curdata = from item in newdb.currencydets
                              orderby item.@class
                              select item;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (currencydet item in curdata)
                {
                    Program.currencylist.Add(item);
                }


                var prodcan = from item in newdb.productcanceldets
                              orderby item.productcode
                              select item;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (productcanceldet item in prodcan)
                {
                    Program.cancelist.Add(item);
                }


                var prodcandetails = from item in newdb.productcanceldetailsdets
                                     orderby item.productcancelno
                                     select item;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (productcanceldetailsdet item in prodcandetails)
                {
                    Program.canceldetailslist.Add(item);
                }



                var prodcur = from item in newdb.productcurrencydets
                              orderby item.productcode
                              select item;

                //Program.mortalitydata = new mortalityvaluesdet[100];
                //int i = -1;
                foreach (productcurrencydet item in prodcur)
                {
                    Program.prodcurlist.Add(item);
                }


                var investprofiles1 = from investprofile in newdb.vwinvestmentprofilevalues
                                      orderby investprofile.investmentprofilecode
                                      select investprofile;


                foreach (vwinvestmentprofilevalue investprofile in investprofiles1)
                {
                    Program.investprofilevalueslist.Add(investprofile);
                }


                var contrtypes = from contr in newdb.contributiontypedets
                                 orderby contr.contributiontypecode
                                 select contr;


                foreach (contributiontypedet item in contrtypes)
                {
                    Program.contrtypeslist.Add(item);
                }



                var calctypes = from calc in newdb.calculatetypedets
                                orderby calc.calculatetypecode
                                select calc;


                foreach (calculatetypedet item in calctypes)
                {
                    Program.calctypeslist.Add(item);
                }



                var products = from product in newdb.productdets
                               orderby product.productcode
                               select product;


                foreach (productdet item in products)
                {
                    Program.productslist.Add(item);
                }


                var relations = from rel in newdb.relationshiptypedets
                                orderby rel.relationshiptypecode
                                select rel;


                foreach (relationshiptypedet item in relations)
                {
                    Program.relationslist.Add(item);
                }


                var entitys = from ent in newdb.entitytypedets
                              orderby ent.entitytypecode
                              select ent;


                foreach (entitytypedet item in entitys)
                {
                    Program.entitylist.Add(item);
                }


                var plangroups = from pg in newdb.plangroupdets
                                 orderby pg.plangroupcode
                                 select pg;


                foreach (plangroupdet item in plangroups)
                {
                    Program.plangroupslist.Add(item);
                }



                var idtypes = from idt in newdb.identificationtypedets
                              orderby idt.identificationtypecode
                              select idt;


                foreach (identificationtypedet item in idtypes)
                {
                    Program.idtypeslist.Add(item);
                }


                var ruledata = from item in newdb.ruleparametervaluesdets
                               orderby item.ruleparameterno
                               select item;


                foreach (ruleparametervaluesdet item in ruledata)
                {
                    Program.rulevalueslist.Add(item);
                }


                var actrisksddl = from item in newdb.actrisks
                                  orderby item.activityrisktypeno
                                  select item;


                foreach (actrisk item in actrisksddl)
                {
                    Program.actrisksddl.Add(item.activityrisktype);
                }


                var healthrisksddl = from item in newdb.healthrisks
                                     orderby item.healthrisktypeno
                                     select item;


                foreach (healthrisk item in healthrisksddl)
                {
                    Program.healthrisksddl.Add(item.healthrisktype);
                }

                var contrtypeslife = from item in newdb.contributiontypeslifes
                                     select item;


                foreach (contributiontypeslife item in contrtypeslife)
                {
                    Program.contributiontypeslife.Add(item.contributiontype);
                }

                var calctypeslife = from item in newdb.calculatetypeslifes
                                    select item;


                foreach (calculatetypeslife item in calctypeslife)
                {
                    Program.calculatetypeslife.Add(item.calculatetype);
                }


                var contrtypesterm = from item in newdb.contributiontypesterms
                                     select item;


                foreach (contributiontypesterm item in contrtypesterm)
                {
                    Program.contributiontypesterm.Add(item.contributiontype);
                }

                var calctypesterm = from item in newdb.calculatetypesterms
                                    select item;


                foreach (calculatetypesterm item in calctypesterm)
                {
                    Program.calculatetypesterm.Add(item.calculatetype);
                }


                var contrtypesred = from item in newdb.contributiontypesreds
                                    select item;


                foreach (contributiontypesred item in contrtypesred)
                {
                    Program.contributiontypesred.Add(item.contributiontype);
                }

                var calctypesred = from item in newdb.calculatetypesreds
                                   select item;


                foreach (calculatetypesred item in calctypesred)
                {
                    Program.calculatetypesred.Add(item.calculatetype);
                }


                var comps = from item in newdb.companydets
                            select item;


                foreach (companydet item in comps)
                {
                    Program.companieslist.Add(item);
                }

                /*
                var occtypes = from occ in Program.db.occupationtypedets
                               orderby occ.occupationtypecode
                               select occ;


                foreach (occupationtypedet item in occtypes)
                {
                    Program.occtypeslist.Add(item);
                }

                var profestypes = from pr in Program.db.professiontypedets
                                  orderby pr.professiontypecode
                                  select pr;


                foreach (professiontypedet item in profestypes)
                {
                    Program.professiontypeslist.Add(item);
                }
                */

                var countries = from ct in newdb.countrydets
                                orderby ct.countryno
                                select ct;


                foreach (countrydet item in countries)
                {
                    Program.countrieslist.Add(item);
                }

                var plantypes = from pt in newdb.plantypedets
                                orderby pt.plantypecode
                                select pt;


                foreach (plantypedet item in plantypes)
                {
                    Program.plantypeslist.Add(item);
                }


                var plantypesred = from pt in newdb.plantypedets
                                   where pt.retirement == 'Y'
                                   orderby pt.plantypecode
                                   select pt;


                foreach (plantypedet item in plantypesred)
                {
                    Program.plantypesred.Add(item.plantype);
                }


                var plantypesterm = from pt in newdb.plantypedets
                                    where pt.terminsurance == 'Y'
                                    orderby pt.plantypecode
                                    select pt;


                foreach (plantypedet item in plantypesterm)
                {
                    Program.plantypesterm.Add(item.plantype);
                }


                var plantypeslife = from pt in newdb.plantypedets
                                    where pt.life == 'Y'
                                    orderby pt.plantypecode
                                    select pt;


                foreach (plantypedet item in plantypeslife)
                {
                    Program.plantypeslife.Add(item.plantype);
                }
                Program.invcomparelist = new List<invprofilecompareratesdet>();
                foreach (invprofilecompareratesdet item in newdb.invprofilecompareratesdets)
                {
                    Program.invcomparelist.Add(item);
                }

                var surrenders = from item in newdb.surrenderpenaltydets
                                 select item;

                foreach (surrenderpenaltydet item in surrenders)
                {
                    Program.surrenderpenaltylist.Add(item);
                }
                var examlist = from item in newdb.examdets
                               orderby item.examcode
                               select item;
                foreach (examdet item in examlist)
                {
                    Program.examslist.Add(item);
                }
                var examconds = from item in newdb.examconditionsdets
                                orderby item.sno
                                select item;
                foreach (examconditionsdet item in examconds)
                {
                    Program.examconditionslist.Add(item);
                }


                Program.lookupdatalist = new List<lookupdatadet>();

                var lookdata1 = from item1 in newdb.lookupdatadets
                                orderby item1.tablename, item1.lookupcaption
                                select item1;

                foreach (lookupdatadet item1 in lookdata)
                {
                    Program.lookupdatalist.Add(item1);
                }


                var registerstatustype = from item in newdb.agentstatusdets
                                         orderby item.statuscode
                                         select item;

                Program.registertypeslist = new List<agentstatusdet>();
                foreach (agentstatusdet item in registerstatustype)
                {
                    Program.registertypeslist.Add(item);
                }

                var approval = from item in newdb.approvaltypedets
                               orderby item.approvaltypeno
                               select item;

                Program.approvallist = new List<approvaltypedet>();
                foreach (approvaltypedet item in approval)
                {
                    Program.approvallist.Add(item);
                }



                systemdet sysdata = (from item in newdb.systemdets
                                     select item).SingleOrDefault();


                Program.systemno = sysdata.systemno.Value;

                Langdata.loadLangfiles(Server.MapPath("~/"));



                //spanish
                Program.spanishLangData = new List<Propdata>();
                String str = Server.MapPath("~/language/messages_es.properties");
                TextReader tr1 = new StreamReader(str, System.Text.Encoding.Default);

                while ((str = tr1.ReadLine()) != null)
                {
                    string[] temp = str.Split('=');
                    String name = "";
                    String value = "";

                    if (temp.Length >= 1)
                        name = str.Split('=')[0];

                    if (temp.Length >= 2)
                        value = str.Split('=')[1];

                    Propdata p1 = new Propdata();
                    p1.name = name;
                    p1.value = value;
                    p1.value = value.Replace("\\r\\n", "\r\n");
                    Program.spanishLangData.Add(p1);
                }
                //french
                Program.frenchLangData = new List<Propdata>();
                str = Server.MapPath("~/language/messages_fr.properties");
                tr1 = new StreamReader(str, System.Text.Encoding.Default);

                while ((str = tr1.ReadLine()) != null)
                {
                    string[] temp = str.Split('=');
                    String name = "";
                    String value = "";

                    if (temp.Length >= 1)
                        name = str.Split('=')[0];

                    if (temp.Length >= 2)
                        value = str.Split('=')[1];

                    Propdata p1 = new Propdata();
                    p1.name = name;
                    p1.value = value;
                    p1.value = value.Replace("\\r\\n", "\r\n");
                    Program.frenchLangData.Add(p1);
                }

                //portuguese
                Program.portugueseLangData = new List<Propdata>();
                str = Server.MapPath("~/language/messages_pt.properties");
                tr1 = new StreamReader(str, System.Text.Encoding.Default);

                while ((str = tr1.ReadLine()) != null)
                {
                    string[] temp = str.Split('=');
                    String name = "";
                    String value = "";

                    if (temp.Length >= 1)
                        name = str.Split('=')[0];

                    if (temp.Length >= 2)
                        value = str.Split('=')[1];

                    Propdata p1 = new Propdata();
                    p1.name = name;
                    p1.value = value;
                    p1.value = value.Replace("\\r\\n", "\r\n");
                    Program.portugueseLangData.Add(p1);
                }

                //chinese
                Program.chineseLangData = new List<Propdata>();
                str = Server.MapPath("~/language/messages_zh.properties");
                tr1 = new StreamReader(str, System.Text.Encoding.Default);

                while ((str = tr1.ReadLine()) != null)
                {
                    string[] temp = str.Split('=');
                    String name = "";
                    String value = "";

                    if (temp.Length >= 1)
                        name = str.Split('=')[0];

                    if (temp.Length >= 2)
                        value = str.Split('=')[1];

                    Propdata p1 = new Propdata();
                    p1.name = name;
                    p1.value = value;
                    p1.value = value.Replace("\\r\\n", "\r\n");
                    Program.chineseLangData.Add(p1);
                }

                Program.annuityperiodlist = new List<annuityperioddet>();
                Program.annuityperiodlist = (from item in newdb.annuityperioddets select item).ToList();

                Program.defermentperiodlist = new List<defermentperioddet>();
                Program.defermentperiodlist = (from item in newdb.defermentperioddets select item).ToList();


                
                Program.wsactivityrisktypelist = (from item in newdb.activityrisktypedets
                                                  select new WSActivityrisktype { activityrisktypename = item.activityrisktype, activityrisktypeno = item.activityrisktypeno, productcode = item.productcode }).ToList();
                Program.wsdefermentperiodlist = (from item in newdb.defermentperioddets
                                                  select new WSDefermentPeriod { period = item.period, productcode = item.productcode }).ToList();
                Program.wsAnnuityperiodlist = (from item in newdb.annuityperioddets
                                                 select new WSAnnuityPeriod { period = item.period, productcode = item.productcode }).ToList();

                Program.wsclasscodelist = (from item in newdb.currencydets
                                         select new WSClasscodeData { currencycode = item.currencycode, currency = item.currency,classcode=item.@class.ToString()}).ToList();


                Program.wscompanylist = (from item in newdb.companiesdets
                                                  select new WSCompany { company_name = item.company_name, company_id = item.company_id}).ToList();
                Program.wsplangrouplist = (from item in newdb.plangroupdets
                                           select new WSPlanGroup { plangroup = item.plangroup, plangroupcode = item.plangroupcode }).Where(j => j.plangroupcode != 'O' && j.plangroupcode!='F').ToList();


                Program.wscountrylist = (from item in newdb.countrydets
                                         select new WSCountry { countryname = item.countryname, countryno = item.countryno }).Where(j => j.countryno != 300).ToList();

                Program.wsfrequncytypelist = (from item in newdb.frequencytypedets
                                                  select new WSFrequencytype{ frequencytypename = item.frequencytype, frequencytypecode = item.frequencytypecode.ToString() }).ToList();

                Program.wsgenderlist = (from item in newdb.genderdets
                                                  select new WSGender{ gendername = item.gendername, gendercode= item.gendercode.ToString()}).ToList();

                Program.wshealthrisktypelist = (from item in newdb.healthrisktypedets
                                                  select new WSHealthrisktype{ healthrisktypename = item.healthrisktype, healthrisktypeno = item.healthrisktypeno, productcode = item.productcode }).ToList();

                Program.wsinvestmentprofilelist = (from item in newdb.investmentprofiledets
                                                  select new WSInvestmentprofile { investmentprofilename = item.investmentprofile, investmentprofilecode = item.investmentprofilecode.ToString()}).ToList();

                Program.wsmaritalstatuslist = (from item in newdb.maritalstatusdets 
                                               select new WSMaritalStatus { maritalstatusname = item.maritalstatus, maritalstatuscode = item.maritalstatuscode.ToString() }).Where(j=>j.maritalstatuscode != "E").ToList();


                Program.wsproductlist = (from item in newdb.productdets
                                         select new WSProduct { productname = item.product, productcode = item.productcode.ToString(), company_id = item.company_id, isfixed = item.@fixed.ToString(), isrefund = item.isrefund.ToString(), plangroupcode=item.plangroupcode.ToString() }).ToList();


                Program.wscalculatetypelist = (from item in newdb.calculatetypedets
                                         select new WSCalculatetype { calculatetypename = item.calculatetype, calculatetypecode = item.calculatetypecode.ToString() }).ToList();

                Program.wscontributiontypelist = (from item in newdb.contributiontypedets
                                                  select new WSContributionType { contributiontype = item.contributiontype, contributiontypecode = item.contributiontypecode.ToString() }).ToList();

                Program.wsplantypelist = (from item in newdb.plantypedets
                                               select new WSPlantype { plantypename = item.plantype, plantypecode = item.plantypecode.ToString(),education=item.education.ToString(),life=item.life.ToString(),retirement=item.retirement.ToString(),terminsurance=item.terminsurance.ToString() }).ToList();

                

            }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //newdb.Dispose();
            }
        }
    }
}