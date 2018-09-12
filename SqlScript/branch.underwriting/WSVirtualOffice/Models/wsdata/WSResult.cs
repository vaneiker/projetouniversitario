using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSResult
    {
        public double insuredamount { get; set; }
        public double annualpremiumamount { get; set; }
        public double periodicpremiumamount { get; set; }
        public double targetpremiumamount { get; set; }
        public double totalinsuredamount { get; set; }
        public double ropamount { get; set; }
        public double fractionsurcharge { get; set; }

        public List<WSExam> primaryexamsrequiredlist { get; set; }
        public List<WSExam> partnerexamsrequiredlist { get; set; }

        public List<WSValidationError> errorslist { get; set; }

        

        protected static List<WSExam> getPrimaryExamsRequiredList(WSResult result, WSCustomer customer, WSCustomerPlan custplan, List<WSRider> riderslist)
        {
            try
            {
                double terminsuranceamount = 0;
                if (riderslist != null)
                {
                    foreach (WSRider rider in riderslist)
                    {
                        if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                        {
                            terminsuranceamount += (rider.amount == null ? 0 : rider.amount);
                        }
                    }
                }

                List<WSExam> wsexamslist = new List<WSExam>();
                IEnumerable<examconditionsdet> examslist = Examconditions.getExams(Numericdata.getIntegervalue(customer.Age.ToString()), customer.gendercode.ToCharArray()[0], customer.MaritalStatuscode.ToCharArray()[0], decimal.Parse((custplan.totalotherinsuranceamount + result.insuredamount + terminsuranceamount).ToString()), custplan.productcode, custplan.classcode.ToCharArray()[0]);
                foreach (examconditionsdet exam in examslist)
                {
                    wsexamslist.Add(new WSExam() { examcode = exam.Examcode, sno = exam.sno.Value, examname = Exams.getexam(exam.Examcode) });
                }
                return wsexamslist;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ////newdb.Dispose();
            }


        }

        protected static List<WSExam> getPartnerExamsRequiredList(WSResult result, WSCustomerPlan custplan, WSCustomerPlanPartner partins)
        {
            try
            {
                List<WSExam> wsexamslist = new List<WSExam>();
                if (partins != null)
                {
                    IEnumerable<examconditionsdet> examslist = Examconditions.getExams(Numericdata.getIntegervalue(partins.age.ToString()), partins.gendercode.ToCharArray()[0], partins.maritalstatuscode.ToCharArray()[0], decimal.Parse((partins.totalotherinsuranceamount + partins.amount).ToString()), custplan.productcode, custplan.classcode.ToCharArray()[0]);
                    foreach (examconditionsdet exam in examslist)
                    {
                        wsexamslist.Add(new WSExam() { examcode = exam.Examcode, sno = exam.sno.Value, examname = Exams.getexam(exam.Examcode) });
                    }
                }
                return wsexamslist;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ////newdb.Dispose();
            }


        }


        public static List<WSValidationError> validateDataaftercalculate(WSResult result, WSCustomer cust, WSCustomerPlan custplan, List<WSRider> riderslist, WSCustomerPlanPartner partins)
        {
            WSRider rideradb = null;
            WSRider riderterm = null;

            if (riderslist != null)
            {
                foreach (WSRider rider in riderslist)
                {
                    if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                    {
                        rideradb = rider;
                    }
                    else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                    {
                        riderterm = rider;
                    }
                }

            }


            List<WSValidationError> errorslist = new List<WSValidationError>();
            char ruleclasscode = ' ';
            if (!custplan.classcode.Equals(""))
            {
                ruleclasscode = custplan.classcode.ToCharArray()[0];
            }


            string adbamount1 = "";
            string termamount1 = "";
            string spouseinsuredamount1 = "";

            if (custplan != null)
            {
                if (rideradb != null)
                {
                    adbamount1 = rideradb.amount.ToString();
                }
                if (riderterm != null)
                {
                    termamount1 = riderterm.amount.ToString();
                }
            }

            if (partins != null)
            {
                spouseinsuredamount1 = Convert.ToString(partins.amount);
            }
            double adbamount = Numericdata.getDoublevalue(adbamount1);
            double termamount = Numericdata.getDoublevalue(termamount1);
            double oiramount = Numericdata.getDoublevalue(spouseinsuredamount1);
            double insuranceamount = custplan.insuredamount == 0 ? result.insuredamount : custplan.insuredamount;// custplan.insuredamount;

            char plangroupcode = Productdata.getPlangroupcode(custplan.productcode);
            String productcode = custplan.productcode;

            double premiumamount = custplan.premiumamount == 0 ? result.periodicpremiumamount : custplan.premiumamount;
            int numberofyears = 0;
            int age = cust.Age;


            //double minimumpremiumamount = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, productcode);            
            double minimumpremium = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, productcode, ruleclasscode);
            double minimumtotalpremium = Rules.getRulevaluedouble(Rules.MINIMUM_TOTAL_PREMIUM, productcode, ruleclasscode);
            double minimuminsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, productcode, ruleclasscode);
            double maximuminsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, productcode, ruleclasscode);

            double minimumanytimepremiumamount = Rules.getRulevaluedouble(Rules.MINIMUM_ANYTIME_PREMIUM, productcode, ruleclasscode);


            if (minimumanytimepremiumamount > 0 && minimumanytimepremiumamount > premiumamount)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premium", errormessage = "Minimum anytime Premium should be greater than " + (minimumanytimepremiumamount - 1).ToString(), errormessageespanol = "prima mínima en cualquier momento debe ser mayor " + (minimumanytimepremiumamount - 1).ToString(), errortype = WSErrorType.IS_LESS_THAN, value = (minimumanytimepremiumamount - 1).ToString() });

            }

            int insuranceunderage = Rules.getRulevalueint(Rules.INSURANCE_UNDERAGE, productcode, ruleclasscode);
            double underagemaxinsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT_UNDERAGE, productcode, ruleclasscode);

            Boolean isFixed = false;
            int minimumcontributionperiod = Rules.getRulevalueint(Rules.MINIMUM_CONTRIBUTION_PERIOD, productcode, ruleclasscode);
            int maximumcontributionperiod = Rules.getRulevalueint(Rules.MAXIMUM_CONTRIBUTION_PERIOD, productcode, ruleclasscode);

            //List<WSValidationError> errlist = WSCustomerPlan.validateGSdata(productcode, plangroupcode, custplan);
            
            if (productcode != null && !productcode.Equals(""))
            {
                isFixed = Productdata.isFixed(productcode);
            }
            int insuranceminage = Rules.getRulevalueint(Rules.INSURANCE_MIN_AGE, productcode, ruleclasscode);
            int insurancemaxage = Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, productcode, ruleclasscode);
            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, productcode, ruleclasscode);



            double mininsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, productcode, ruleclasscode);
            double maxinsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, productcode, ruleclasscode);


            char contributiontypecode = custplan.contributiontypecode.ToCharArray()[0];

            char calculatetypecode = custplan.calculatetypecode.ToCharArray()[0];
            char plantypecode = custplan.plantypecode.ToCharArray()[0];

            double annualpremium = WSCustomerPlan.getAnnualizedpremium(custplan);

            double insuredamount = result.insuredamount!=0?result.insuredamount:custplan.insuredamount;// custplan.insuredamount;
            double minumumpremium = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, productcode, ruleclasscode);
            double minumumtotalpremium = Rules.getRulevaluedouble(Rules.MINIMUM_TOTAL_PREMIUM, productcode, ruleclasscode);

            double initialcontributionamount = custplan.initialcontributionamount;

            if (contributiontypecode == Contributiontypes.NUMBEROFYEARS)
            {
                numberofyears = custplan.contributionperiod;
            }
            else if (contributiontypecode == Contributiontypes.UNTILAGE)
            {
                numberofyears = custplan.contributionuntilage - cust.Age + 1;
            }
            else if (contributiontypecode == Contributiontypes.CONTINUOUS)
            {
                numberofyears = maxage - cust.Age;
            }

            int frequencytypevalue = Frequencytypes.getfrequencytypevalue(Frequencytypes.getfrequencytype(custplan.frequencytypecode.ToCharArray()[0]));
            double actualannualpremium = premiumamount * frequencytypevalue;

            if (plangroupcode == Plangroups.LIFE)
            {
                if (minimumpremium > 0)
                    {
                        if ((actualannualpremium < minumumpremium))
                        {
                             errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Premium should be greater than " + minumumpremium.ToString(), errormessageespanol = "Premium debe ser mayor que " + minumumpremium.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minumumpremium.ToString() });
                        }

                    }

                    if (minumumtotalpremium > 0)
                    {
                        if (((actualannualpremium * numberofyears + initialcontributionamount) < minumumtotalpremium))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Total Premium should be greater than " + minumumtotalpremium.ToString(), errormessageespanol = "Total Premium debe ser mayor que " + minumumtotalpremium.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minumumtotalpremium.ToString() });

                        }
                    }

                    if (maximuminsuredamount > 0)
                    {
                        if ((insuranceamount) > maximuminsuredamount)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance cannot be greater than" + maximuminsuredamount.ToString(), errormessageespanol = "El seguro regular no puede ser mayor que " + maximuminsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximuminsuredamount.ToString() });

                        }

                    }

                    if (minimuminsuredamount > 0)
                    {
                        if ((insuranceamount) < minimuminsuredamount)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance cannot be less than" + minimuminsuredamount.ToString(), errormessageespanol = "El seguro regular no puede ser inferior a " + minimuminsuredamount.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimuminsuredamount.ToString() });

                        }
                    }

                    if (maximuminsuredamount > 0)
                    {
                        if ((termamount + insuranceamount) > maximuminsuredamount)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance + Additional Insurance cannot be greater than" + maximuminsuredamount.ToString(), errormessageespanol = "El seguro regular + seguro adicional no puede ser mayor que " + maximuminsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximuminsuredamount.ToString() });

                        }
                    }

                    if ((termamount) > insuranceamount)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Additional Insurance cannot be greater than regular insurance.", errormessageespanol = "La cantidad del Seguro Temporal Adicional no puede ser mayor a la suma asegurada principal", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                    }

                    if (numberofyears <= 0)
                    {
                         errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be more than 1", errormessageespanol = "Años Premium de pago tienen que ser más de 1", errortype = WSErrorType.IS_LESS_THAN, value = "" });

                    }

                    if (maxage > 0)
                    {
                        if ((numberofyears + age) > maxage)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Contribution Period + Age cannot be greater than " + maxage.ToString(), errormessageespanol = "El período de cotización de edad máxima no puede ser mayor que " + maxage.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxage.ToString() });

                        }
                    }

                    if (minimumcontributionperiod > 0)
                    {
                        if (numberofyears <= minimumcontributionperiod)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be at least " + minimumcontributionperiod.ToString(), errormessageespanol = "Años Premium de pago deben ser por lo menos " + minimumcontributionperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimumcontributionperiod.ToString() });

                        }
                    }

                    if (maximumcontributionperiod > 0)
                    {
                        if (numberofyears <= maximumcontributionperiod)
                        {
                             errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years should be less than " + maximumcontributionperiod.ToString(), errormessageespanol = "Años Premium de pago debe ser inferior a " + maximumcontributionperiod.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximumcontributionperiod.ToString() });

                        }
                    }

                    if (insurancemaxage > 0)
                    {
                        if (cust.Age > insurancemaxage)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Age is not between minimum and maximum insurance age", errormessageespanol = "La edad no es entre la edad mínima y máxima de seguros", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });

                        }
                    }

                    if (insuranceminage > 0)
                    {
                        if (cust.Age < insuranceminage)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Age is not between minimum and maximum insurance age", errormessageespanol = "La edad no es entre la edad mínima del seguro y máxima", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });

                        }
                    }

                    if (maxage > 0)
                    {
                        if ((numberofyears + age) > maxage)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Contribution Period + Age should not be greater than maximum age.", errormessageespanol = "Contribución Periodo + La edad no debe ser mayor de edad máxima.", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                        }
                    }


                    if (underagemaxinsuredamount > 0)
                    {
                        if ((age <= insuranceunderage) && (insuredamount > underagemaxinsuredamount))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Underage Insured Amount should not be greater than " + underagemaxinsuredamount.ToString(), errormessageespanol = "Suma Asegurada por menores de edad no debe ser mayor que " + underagemaxinsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = underagemaxinsuredamount.ToString() });

                        }
                    }

                    if (mininsuredamount > 0)
                    {
                        if ((insuredamount < mininsuredamount))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount be greater than " + mininsuredamount.ToString(), errormessageespanol = "Suma Asegurada ser mayor que " + mininsuredamount.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = mininsuredamount.ToString() });

                        }
                    }


                    if (maxinsuredamount > 0)
                    {
                        if ((insuredamount > maxinsuredamount))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount should be less than " + maxinsuredamount.ToString(), errormessageespanol = "Suma Asegurada debe ser inferior a " + maxinsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxinsuredamount.ToString() });

                        }
                    }
                    
            }
            else if (plangroupcode == Plangroups.RETIREMENT || plangroupcode == Plangroups.EDUCATION)
            {


            }
            else if (plangroupcode == Plangroups.TERMINSURANCE || plangroupcode == Plangroups.FUNERAL)
            {
                if (minimumpremium > 0)
                {
                    if ((actualannualpremium < minumumpremium))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Premium should be greater than " + minumumpremium.ToString(), errormessageespanol = "La prima debe ser mayor que " + minumumpremium.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minumumpremium.ToString() });

                    }

                }

                if (minumumtotalpremium > 0)
                {
                    if (((actualannualpremium * numberofyears + initialcontributionamount) < minumumtotalpremium))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Total Premium should be greater than " + minumumtotalpremium.ToString(), errormessageespanol = "La prima total debe ser mayor que " + minumumtotalpremium.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minumumtotalpremium.ToString() });

                    }
                }


                if (maximuminsuredamount > 0)
                {
                    if ((insuranceamount) > maximuminsuredamount)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance cannot be greater than " + maximuminsuredamount.ToString(), errormessageespanol = "El seguro regular no puede ser mayor que " + maximuminsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximuminsuredamount.ToString() });

                    }
                }

                if (minimuminsuredamount > 0)
                {
                    if ((insuranceamount) < minimuminsuredamount)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance cannot be less than " + minimuminsuredamount.ToString(), errormessageespanol = "El seguro regular no puede ser inferior a " + minimuminsuredamount.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimuminsuredamount.ToString() });

                    }
                }


                if (minimumpremium > 0)
                {
                    if ((premiumamount * frequencytypevalue) < minimumpremium)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Premium Amount cannot be less than " + minimuminsuredamount.ToString(), errormessageespanol = "El monto de la prima no puede ser inferior a " + minimuminsuredamount.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimuminsuredamount.ToString() });

                    }

                }


                if (maxinsuredamount > 0)
                {
                    if ((termamount + insuranceamount) > maximuminsuredamount)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Regular Insurance + Additional Insurance cannot be greater than " + maximuminsuredamount.ToString(), errormessageespanol = "El seguro regular + seguro adicional no puede ser mayor que " + maximuminsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximuminsuredamount.ToString() });

                    }

                }

                if ((termamount) > insuranceamount)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.ridertermamount", errormessage = "Additional Insurance cannot be greater than regular insurance.", errormessageespanol = "La cantidad del Seguro Temporal Adicional no puede ser mayor a la suma asegurada principal", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                }

                if ((adbamount) > insuranceamount)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.rideradbamount", errormessage = "Adb Amount cannot be greater than regular insurance.", errormessageespanol = "La cantidad del suplemento ADB no puede ser mayor a la suma asegurada principal", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                }

                if ((oiramount) > insuranceamount)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.rideroiramount", errormessage = "Spouse/Other Insured Rider Amount cannot be greater than regular insurance.", errormessageespanol = "Cónyuge/otro asegurado: El monto del suplemento no puede ser mayor que el seguro regular", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                }


                if (numberofyears <= 0)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be more than 1", errormessageespanol = "Los años para el pago de la prima deben ser mayor que 1", errortype = WSErrorType.IS_LESS_THAN, value = "1" });

                }

                if (maxage > 0)
                {
                    if ((numberofyears + age) > maxage)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Contribution Period + Age cannot be greater than " + maxage.ToString(), errormessageespanol = "La Edad + Periodo de Contribución  no puede ser mayor a " + maxage.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxage.ToString() });

                    }
                }

                if (insurancemaxage > 0)
                {
                    if (cust.Age < insuranceminage || cust.Age > insurancemaxage)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.Age", errormessage = "Age is not between minimum and maximum insurance age.", errormessageespanol = "La edad no esta entre nuestra edad mínima (1) y máxima (65) para emitir una poliza", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" ,rangefromvalue=insuranceminage,rangetovalue=insurancemaxage});

                    }
                }

                if (maxage > 0)
                {
                    if ((numberofyears + age) > maxage)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Contribution Period + Age should not be greater than maximum age.", errormessageespanol = "La Edad + Periodo de Contribución  no puede ser mayor a la edad maxima", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                    }
                }

                if (underagemaxinsuredamount > 0)
                {
                    if ((age <= insuranceunderage) && (insuredamount > underagemaxinsuredamount))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Underage Insured Amount should not be greater than " + underagemaxinsuredamount.ToString(), errormessageespanol = "El monto asegurado para menores de edad no puede ser mayor que " + underagemaxinsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = underagemaxinsuredamount.ToString() });

                    }
                }

                if (minimuminsuredamount > 0)
                {
                    if ((calculatetypecode != Calculatetypes.INSUREDAMOUNT) && (insuredamount < mininsuredamount))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount should be between " + mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(), errormessageespanol = "La suma asegurada debe ser un número entre " + mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString() ,rangefromvalue=mininsuredamount,rangetovalue=maxinsuredamount});

                    }
                }

                if (maxinsuredamount > 0)
                {
                    if ((calculatetypecode != Calculatetypes.INSUREDAMOUNT) && (insuredamount < mininsuredamount))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount should be between " + mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(), errormessageespanol = "La suma asegurada debe ser un número entre " + mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(),rangefromvalue=mininsuredamount,rangetovalue=maxinsuredamount });

                    }
                }

                if (minimumcontributionperiod > 0)
                {
                    if (numberofyears <= minimumcontributionperiod)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be at least " + minimumcontributionperiod.ToString(), errormessageespanol = "Los años para el pago de la prima deben ser por lo menos " + minimumcontributionperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimumcontributionperiod.ToString() });

                    }
                }

                if (maximumcontributionperiod > 0)
                {
                    if (numberofyears <= maximumcontributionperiod)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years should be less than " + maximumcontributionperiod.ToString(), errormessageespanol = "Los años para el pago de la prima deben ser inferior a " + maximumcontributionperiod.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maximumcontributionperiod.ToString() });

                    }
                }

            }



            return errorslist;

        }





    }
}