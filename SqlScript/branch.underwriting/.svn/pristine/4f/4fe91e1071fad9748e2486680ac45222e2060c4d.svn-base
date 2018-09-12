using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WSVirtualOffice.Models.wsdata;
using WSVirtualOffice.Models.blinsurance;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models;
using WSVirtualOffice.Models.codes;

namespace WSVirtualOffice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QuotesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select QuotesService.svc or QuotesService.svc.cs at the Solution Explorer and start debugging.
    public class QuotesService : IQuotesService
    {

        public WSTermResult getTermModel(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);
            if (errorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = planerrorslist;
                return result;
            }
            List<WSValidationError> ridererrorslist = WSRider.getRidersValidationErrorsList(riderslist, partins, custplan, customer);
            if (ridererrorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = ridererrorslist;
                return result;
            }

            /* INHABILITADO HASTA REVISAR LOGICA CON IDELEON y DVURGAIT
            List<WSValidationError> riderAgeList = WSCustomer.getCustomerAgeValidationList(customer, riderslist, custplan);
            if (riderAgeList.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = riderAgeList;
                return result;
            }
            */

            //Bmarroquin 15-03-2017 Validar sumas de FE
            List<WSValidationError> riderFEList = WSCustomer.getRider_FE_ValidationList(customer, riderslist, custplan);
            if (riderFEList.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = riderFEList;
                return result;
            }
            //Fin Bmarroquin 15-03-2017

            if (custplan.productcode == "LGT" || custplan.productcode == "SNT")
            {
                IMaintermfixedLS termfixed = new IMaintermfixedLS(customer, custplan, riderslist, partins);
                return WSTermResult.getTermResultLS(termfixed, customer, custplan, riderslist, partins);
            }
            else
            {
                IMaintermfixed termfixed = new IMaintermfixed(customer, custplan, riderslist, partins);
                return WSTermResult.getTermResult(termfixed, customer, custplan, riderslist, partins);
            }
            
        }

        public WSTermResult getTermModelIllustration(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            var initReport = new WSReport();
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);
            if (errorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = planerrorslist;
                return result;
            }
            List<WSValidationError> ridererrorslist = WSRider.getRidersValidationErrorsList(riderslist, partins, custplan, customer);
            if (ridererrorslist.Count > 0)
            {
                WSTermResult result = new WSTermResult();
                result.errorslist = ridererrorslist;
                return result;
            }

            if (custplan.productcode == "LGT" || custplan.productcode == "SNT")
            {
                IMaintermfixedLS termfixed = new IMaintermfixedLS(customer, custplan, riderslist, partins);
                WSTermResult termresult = WSTermResult.getTermResultIllustrtaionLS(termfixed, customer, custplan, riderslist, partins);
                byte[] pdfresult = WSReport.showIllustrationTERMfixedLS(termresult, customer, custplan, termfixed, riderslist, partins);
                if (pdfresult != null)
                {
                    termresult.illuspdf = pdfresult;
                }
                //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
                return termresult;
            }
            else
            {
                IMaintermfixed termfixed = new IMaintermfixed(customer, custplan, riderslist, partins);
                WSTermResult termresult = WSTermResult.getTermResultIllustrtaion(termfixed, customer, custplan, riderslist, partins);
                byte[] pdfresult = WSReport.showIllustrationTERMfixed(termresult, customer, custplan, termfixed, riderslist, partins, true);
                if (pdfresult != null)
                {
                    termresult.illuspdf = pdfresult;
                }
                //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
                return termresult;
            }

            //return new WSTermResult(termfixed);
        }

        public WSLifeResult getLifeModel(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = planerrorslist;
                return result;
            }
            List<WSValidationError> ridererrorslist = WSRider.getRidersValidationErrorsList(riderslist, partins, custplan, customer);
            if (ridererrorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = ridererrorslist;
                return result;
            }
            

            //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
            return lifecalculate(customer, custplan, riderslist, partins);
            //return new WSTermResult(termfixed);
        }
        public static WSLifeResult lifecalculate(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
            if (insmaindata.planerror == true)
            {
                WSLifeResult liferesult = new WSLifeResult();
                List<WSValidationError> calcerrorslist = new List<WSValidationError>();
                calcerrorslist.Add(new WSValidationError() { errorfield = "", errormessage = insmaindata.planerrordata, errormessageespanol = "", errortype = WSErrorType.IS_BLANK, value = "" });
                liferesult.errorslist = calcerrorslist;
                return liferesult;
            }
            WSLifeResult res = WSLifeResult.getLifeResult(insmaindata, customer, custplan, riderslist, partins);
            if (res.errorslist.Count() > 0)
            {
                if (res.errorslist[0].errormessage.Contains("Premium should be greater than"))
                {
                    custplan.calculatetypecode = "V";
                    custplan.premiumamount = res.errorslist[0].value != null ? Numericdata.getDoublevalue(res.errorslist[0].value) : custplan.premiumamount;
                    custplan.insuredamount = res.insuredamount;

                    return lifecalculate(customer, custplan, riderslist, partins);
                }
            }
            else
            {

                return res;
            }
            return res;
        }

        public WSLifeResult getLifeModelIllustration(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = planerrorslist;
                return result;
            }
            List<WSValidationError> ridererrorslist = WSRider.getRidersValidationErrorsList(riderslist, partins, custplan, customer);
            if (ridererrorslist.Count > 0)
            {
                WSLifeResult result = new WSLifeResult();
                result.errorslist = ridererrorslist;
                return result;
            }



            return lifeseeillustration(customer, custplan, riderslist, partins);
            
            //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
          
            //return new WSTermResult(termfixed);
        }
        public static WSLifeResult lifeseeillustration(WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {

            IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
            if (insmaindata.planerror == true)
            {
                WSLifeResult liferesult = new WSLifeResult();
                List<WSValidationError> calcerrorslist = new List<WSValidationError>();
                calcerrorslist.Add(new WSValidationError() { errorfield = "", errormessage = insmaindata.planerrordata, errormessageespanol = "", errortype = WSErrorType.IS_BLANK, value = "" });
                liferesult.errorslist = calcerrorslist;
                return liferesult;
            }


            WSLifeResult res = WSLifeResult.getLifeResultIllustration(insmaindata, customer, custplan, riderslist, partins);

            if (res.errorslist.Count() > 0)
            {
                if (res.errorslist[0].errormessage.Contains("Premium should be greater than"))
                {
                    custplan.calculatetypecode = "V";
                    custplan.premiumamount = res.errorslist[0].value != null ? Numericdata.getDoublevalue(res.errorslist[0].value) : custplan.premiumamount;
                    custplan.insuredamount = res.insuredamount;

                    return lifeseeillustration(customer, custplan, riderslist, partins);
                }
            }
            else
            {
                
                byte[] pdfresult = WSReport.showIllustrationLife(res, customer, custplan, insmaindata, riderslist, partins);
                if (pdfresult != null)
                {
                    res.illuspdf = pdfresult;
                }
                return res;
            }
            return res;
        }
        public WSAnnuityResult getAnnuityModel(WSCustomer customer, WSCustomerPlan custplan)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSAnnuityResult result = new WSAnnuityResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSAnnuityResult result = new WSAnnuityResult();
                result.errorslist = planerrorslist;
                return result;
            }

            bool isFixed = Productdata.isFixed(custplan.productcode);
            if (isFixed == false)
            {
                IMaineduretire eduretire = new IMaineduretire(customer, custplan);

                return WSAnnuityGrowthResult.getAnnuityGrowthResult(eduretire, customer, custplan);
            }
            else
            {
                //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
                IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(customer, custplan);

                //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
                return WSAnnuityFixedResult.getAnnuityFixedResult(eduretirefixed, customer, custplan);
                //return new WSTermResult(termfixed);
            }
            //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);

        }
        public WSAnnuityResult getAnnuityModelIllustration(WSCustomer customer, WSCustomerPlan custplan)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSAnnuityResult result = new WSAnnuityResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSAnnuityResult result = new WSAnnuityResult();
                result.errorslist = planerrorslist;
                return result;
            }

            bool isFixed = Productdata.isFixed(custplan.productcode);
            if (isFixed == false)
            {
                IMaineduretire eduretire = new IMaineduretire(customer, custplan);
                WSAnnuityResult annresult = WSAnnuityGrowthResult.getAnnuityGrowthResultIllustration(eduretire, customer, custplan);
                byte[] pdfresult = WSReport.showIllustrationRED(annresult, customer, custplan, eduretire);
                if (pdfresult != null)
                {
                    annresult.illuspdf = pdfresult;
                }
                return annresult;
            }
            else
            {
                //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
                IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(customer, custplan);
                WSAnnuityResult annresult = WSAnnuityFixedResult.getAnnuityFixedResult(eduretirefixed, customer, custplan);
                byte[] pdfresult = WSReport.showIllustrationREDfixed(annresult, customer, custplan, eduretirefixed);
                if (pdfresult != null)
                {
                    annresult.illuspdf = pdfresult;
                }
                //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
                return annresult;
                //return new WSTermResult(termfixed);
            }
            //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);

        }
        public WSCompareIllusResult getCompareIllustration(List<WSCompareCustomer> custplans)
        { 
            WSCompareIllusResult comparresult = new WSCompareIllusResult();
            Boolean errors=false;
            comparresult.list = new List<List<WSValidationError>>();
            int count = 0;
            foreach (WSCompareCustomer illuscust in custplans)
            {
                if (illuscust != null)
                {
                    count++;
                }
            }
            if (count >= 2 && count <= 4)
            {
                foreach (WSCompareCustomer illuscust in custplans)
                {
                    if (illuscust!=null)
                    {
                        char planfamily = Productdata.getPlangroupcode(illuscust.custplan.productcode);
                        if (planfamily == Plangroups.EDUCATION || planfamily == Plangroups.RETIREMENT)
                        {
                            WSAnnuityResult result = getAnnuityModel(illuscust.customer, illuscust.custplan);
                            comparresult.list.Add(result.errorslist != null ? result.errorslist : new List<WSValidationError>());
                            //if (result.errorslist != null)
                            //{
                            //    errors = result.errorslist.Count() > 0 ? true : false;
                            //    if (errors)
                            //    {
                            //        return comparresult;
                            //    }
                            //}
                        }
                        else if (planfamily == Plangroups.LIFE)
                        {
                            WSLifeResult result = getLifeModel(illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                            comparresult.list.Add(result.errorslist != null ? result.errorslist : new List<WSValidationError>());
                            //if (result.errorslist != null)
                            //{
                            //    errors = result.errorslist.Count() > 0 ? true : false;
                            //    if (errors)
                            //    {
                            //        return comparresult;
                            //    }
                            //}
                        }
                        else if (planfamily == Plangroups.TERMINSURANCE)
                        {
                            WSTermResult result = getTermModel(illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                            comparresult.list.Add(result.errorslist != null ? result.errorslist : new List<WSValidationError>());
                            //if (result.errorslist != null)
                            //{
                            //    errors = result.errorslist.Count() > 0 ? true : false;
                            //    if (errors)
                            //    {
                            //        return comparresult;
                            //    }
                            //}
                        }

                    }
                }
                if(comparresult.list!=null)
                {
                    foreach(List<WSValidationError> errs in comparresult.list)
                    {
                        if (errs != null)
                        {
                            if (errs.Count > 0)
                                return comparresult;
                        }
                    }

                }
                    WSCompareReport.compareIllustrations(custplans);

                    foreach (WSCompareCustomer illuscust in custplans)
                    {
                        if (illuscust != null)
                        {
                            char planfamily = Productdata.getPlangroupcode(illuscust.custplan.productcode);
                            if (planfamily == Plangroups.EDUCATION || planfamily == Plangroups.RETIREMENT)
                            {

                                WSCustomerPlan custplan = illuscust.custplan;
                                WSCustomer customer = illuscust.customer;
                                bool isFixed = Productdata.isFixed(custplan.productcode);
                                if (isFixed == false)
                                {
                                    IMaineduretire eduretire = new IMaineduretire(customer, custplan);
                                    WSAnnuityResult annresult = WSAnnuityGrowthResult.getAnnuityGrowthResultIllustration(eduretire, customer, custplan);
                                    comparresult.result = WSCompareReport.showIllustrationRED(annresult, customer, custplan, eduretire);
                                }
                                else
                                {
                                    IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(customer, custplan);
                                    WSAnnuityResult annresult = WSAnnuityFixedResult.getAnnuityFixedResult(eduretirefixed, customer, custplan);
                                    comparresult.result = WSCompareReport.showIllustrationREDfixed(annresult, customer, custplan, eduretirefixed);
                                }
                            }
                            else if (planfamily == Plangroups.LIFE)
                            {
                                IMainInsuranceData insmaindata = new IMainInsuranceData(illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                WSLifeResult lifeillusresult = WSLifeResult.getLifeResultIllustration(insmaindata, illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                comparresult.result = WSCompareReport.showIllustrationLife(lifeillusresult, illuscust.customer, illuscust.custplan, insmaindata, illuscust.riderslist, illuscust.partins);

                            }
                            else if (planfamily == Plangroups.TERMINSURANCE)
                            {
                                if (illuscust.custplan.productcode.Equals("LGT") || illuscust.custplan.productcode.Equals("SNT"))
                                {
                                    IMaintermfixedLS termfixed = new IMaintermfixedLS(illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                    WSTermResult termresult = WSTermResult.getTermResultIllustrtaionLS(termfixed, illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                    comparresult.result = WSCompareReport.showIllustrationTERMfixedLS(termresult, illuscust.customer, illuscust.custplan, termfixed, illuscust.riderslist, illuscust.partins);
                                }
                                else
                                {
                                    IMaintermfixed termfixed = new IMaintermfixed(illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                    WSTermResult termresult = WSTermResult.getTermResultIllustrtaion(termfixed, illuscust.customer, illuscust.custplan, illuscust.riderslist, illuscust.partins);
                                    comparresult.result = WSCompareReport.showIllustrationTERMfixed(termresult, illuscust.customer, illuscust.custplan, termfixed, illuscust.riderslist, illuscust.partins);
                                }
                            }
                            //else if (planfamily == Plangroups.FUNERAL)
                            //{
                            //    WSFuneralResult result = getFuneralModel(illuscust.customer, (WSCustomerPlanFuneral)illuscust.custplan);
                            //    comparresult.list.Add(result.errorslist != null ? result.errorslist : new List<WSValidationError>());
                            //    errors = result.errorslist.Count() > 0 ? true : false;
                            //    if (errors)
                            //    {
                            //        return comparresult;
                            //    }
                            //    else
                            //    {
                            //        //comparresult.result = WSCompareReport.showIllustrationRED;
                            //    }
                            //}               


                        }

                    }
                
            }
            else
            {
                comparresult.error = new WSValidationError() { errorfield = "", errormessage = "Select atleast two illustrations and not more than four", errormessageespanol = "Seleccione lo menos dos ilustraciones", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "", rangefromvalue = 2, rangetovalue = 4 };
            
            }
            //comparresult.error = new WSValidationError() { errorfield = "", errormessage = "Select atleast two illustrations", errormessageespanol = "", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "",rangefromvalue=2,rangetovalue=4 };
            return comparresult;
        }
        /*
        public WSAnnuityGrowthResult getAnnuityGrowthModel(WSCustomer customer, WSCustomerPlanAnnuity custplan)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSAnnuityGrowthResult result = new WSAnnuityGrowthResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSAnnuityGrowthResult result = new WSAnnuityGrowthResult();
                result.errorslist = planerrorslist;
                return result;
            }
            //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
            IMaineduretire eduretire = new IMaineduretire(customer, custplan);
            
            //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
            return WSAnnuityGrowthResult.getAnnuityGrowthResult(eduretire, customer, custplan);
            //return new WSTermResult(termfixed);
        }

        public WSAnnuityFixedResult getAnnuityFixedModel(WSCustomer customer, WSCustomerPlanAnnuity custplan)
        {
            WSCustomerPlan.setDefaultValues(custplan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, custplan);

            if (errorslist.Count > 0)
            {
                WSAnnuityFixedResult result = new WSAnnuityFixedResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, custplan);
            if (planerrorslist.Count > 0)
            {
                WSAnnuityFixedResult result = new WSAnnuityFixedResult();
                result.errorslist = planerrorslist;
                return result;
            }
            //IMainInsuranceData insmaindata = new IMainInsuranceData(customer, custplan, riderslist, partins);
            IMaineduretirefixed eduretirefixed = new IMaineduretirefixed(customer, custplan);

            //IEnumerable<examconditionsdet> exams2 = Examconditions.getExams(Numericdata.getIntegervalue(spouseAge), spouseGender, spouseMaritalstatus, Numericdata.getDecimalvalue(calculateTotalInsuredamount('O').ToString()), productcode, custplan.@class);
            return WSAnnuityFixedResult.getAnnuityFixedResult(eduretirefixed, customer, custplan);
            //return new WSTermResult(termfixed);
        }*/

        public WSFuneralResult getFuneralModel(WSCustomer customer, WSCustomerPlanFuneral plan)
        {
            WSCustomerPlan.setDefaultValues(plan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, plan);
            if (errorslist.Count > 0)
            {
                WSFuneralResult result = new WSFuneralResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, plan);
            if (planerrorslist.Count > 0)
            {
                WSFuneralResult result = new WSFuneralResult();
                result.errorslist = planerrorslist;
                return result;
            }

            IMainfuneral funeral = new IMainfuneral(customer, plan);
            return WSFuneralResult.getFuneralResult(funeral, customer, plan);
        }
        public WSFuneralResult getFuneralModelIllustration(WSCustomer customer, WSCustomerPlanFuneral plan)
        {
            WSCustomerPlan.setDefaultValues(plan);

            List<WSValidationError> errorslist = WSCustomer.getCustomerValidationErrorsList(customer, plan);
            if (errorslist.Count > 0)
            {
                WSFuneralResult result = new WSFuneralResult();
                result.errorslist = errorslist;
                return result;
            }

            List<WSValidationError> planerrorslist = WSCustomerPlan.getCustomerValidationErrorsList(customer, plan);
            if (planerrorslist.Count > 0)
            {
                WSFuneralResult result = new WSFuneralResult();
                result.errorslist = planerrorslist;
                return result;
            }

            IMainfuneral funeral = new IMainfuneral(customer, plan);
            WSFuneralResult funresult = WSFuneralResult.getFuneralResultIllustration(funeral, customer, plan);
            byte[] pdfresult = WSReport.showIllustrationFUNERALfixed(funresult, customer, plan, funeral, true);
            if (pdfresult != null)
            {
                funresult.illuspdf = pdfresult;
            }
            return funresult;
        }
        public List<WSPlantype> getPlanTypeList()
        {
            return Program.wsplantypelist;
        }


        public List<WSCalculatetype> getCalculateTypeList()
        {
            return Program.wscalculatetypelist;
        }
        public List<WSContributionType> getContributionTypeList()
        {
            return Program.wscontributiontypelist;
        }
        public List<WSYesNo> getYesNoList()
        {
            return WSYesNo.getWSYesNoList();
        }

        public List<WSRidertype> getRiderTypeList()
        {
            return WSRidertype.getWSriderTypesList();
        }

        public List<WSActivityrisktype> getActivityRiskTypeList()
        {
            return Program.wsactivityrisktypelist;
        }

        public List<WSDefermentPeriod> getDefermentPeriodList()
        {
            return Program.wsdefermentperiodlist;
        }
        public List<WSAnnuityPeriod> getAnnuityPeriodList()
        {
            return Program.wsAnnuityperiodlist;
        }
        public List<WSClasscodeData> getClasscodeList()
        {

            return Program.wsclasscodelist;
        }


        public List<WSCompany> getCompanyList()
        {
            return Program.wscompanylist;
        }
        public List<WSPlanGroup> getPlangroupList()
        {
            return Program.wsplangrouplist;
        }

        public List<WSCountry> getCountryList()
        {
            return Program.wscountrylist;

        }


        public List<WSFrequencytype> getFrequencyTypeList()
        {
            return Program.wsfrequncytypelist;
        }


        public List<WSGender> getGenderList()
        {

            return Program.wsgenderlist;
        }


        public List<WSHealthrisktype> getHealthRiskTypeList()
        {

            return Program.wshealthrisktypelist;
        }


        public List<WSInvestmentprofile> getInvestmentprofileList()
        {
            return Program.wsinvestmentprofilelist;
        }


        public List<WSMaritalStatus> getMaritalstatusList()
        {
            return Program.wsmaritalstatuslist;
        }


        public List<WSProduct> getProductList()
        {
            return Program.wsproductlist;
        }

        public double GetGoalSeek(double InitialContribution, int Frequency, int ContributionPeriod, double PremiumAmount)
        {
            double RopAmount = 0;
            RopAmount = InitialContribution + (Frequency * ContributionPeriod * Math.Floor(PremiumAmount));

            return RopAmount;
        }
    }
}
