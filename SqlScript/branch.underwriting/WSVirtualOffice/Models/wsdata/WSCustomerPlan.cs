using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.businesslogic;
using WSVirtualOffice.Models.blinsurance;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSCustomerPlan
    {
        //public long customerPlanno { get; set; }
        public string IllustrationNo { get; set; }
        public string productcode { get; set; }
        public string company_id { get; set; }

        public string classcode { get; set; }
        public long customerno { get; set; }
        public string frequencytypecode { get; set; }

        public double insuredamount { get; set; }
        public double premiumamount { get; set; }

        public double initialcontributionamount { get; set; }


        public string insurancelevelcode { get; set; }
        public string calculatetypecode { get; set; }

        public string investmentprofilecode { get; set; }

        public int activityrisktypeno { get; set; }
        public int healthrisktypeno { get; set; }

        public int contributionperiod { get; set; }

        public string financialgoal { get; set; }
        public int financialgoalage { get; set; }
        public double financialgoalamount { get; set; }




        public int countryno { get; set; }

        public int insuranceperiod { get; set; }
        public int annuityperiod { get; set; }
        public int defermentperiod { get; set; }
        public int retirementperiod { get; set; }


        public string contributiontypecode { get; set; }
        public string rideroir { get; set; }
        public double totalotherinsuranceamount { get; set; }

        public string plantypecode { get; set; }

        public int contributionuntilage { get; set; }
        public double annuityamount { get; set; }
        public string initialcontributiontype { get; set; }
        public string studentname { get; set; }
        public int studentage { get; set; }
        public bool? HaveSpecialPayment { get; set; }
        public decimal? SpecialPayment { get; set; }
        public int? ProviderTypeId { get; set; }
        public int? ProviderId { get; set; }
        public decimal? FinancingRate { get; set; }
        public string DestinyFund { get; set; }
        public int? ContributionPeriodMonth { get; set; }
        public static void setDefaultValues(WSCustomerPlan custplan)
        {
            String productcode = custplan.productcode;
            char plangroupcode = Productdata.getPlangroupcode(custplan.productcode);

            if (plangroupcode == Plangroups.TERMINSURANCE || plangroupcode == Plangroups.FUNERAL)
            {
                custplan.contributiontypecode = Contributiontypes.NUMBEROFYEARS.ToString();
                custplan.plantypecode = Plantypes.INSURED.ToString();
                custplan.investmentprofilecode = "U";
            }

            if (productcode.Equals("EDU") || productcode.Equals("HRZ") || productcode.Equals("CPI"))
            {
                custplan.investmentprofilecode = "U";
            }

            if (plangroupcode == Plangroups.FUNERAL)
            {
                custplan.calculatetypecode = Calculatetypes.PREMIUMAMOUNT.ToString();
            }
            /*
            Boolean isFixed = false;
            if (productcode != null && !productcode.Equals(""))
            {
                isFixed = Productdata.isFixed(productcode);
            }*/
        }

        public static List<WSValidationError> getCustomerValidationErrorsList(WSCustomer cust, WSCustomerPlan custplan)
        {
            /*
             * if (custplan.financialgoal == 'Y')
                {
                    if (custplan.financialgoalage < this.age)
                    {
                        this.planerror = true;
                        // need to create a string in languages so that, that particular string instead
                        this.planerrordata = this.planerrordata + " financialgoal age rate cannot be less than age";
                    }
                }
             * 
             * 
             * 
             * 
             */

            List<WSValidationError> errorslist = new List<WSValidationError>();

            String productcode = custplan.productcode;
            char plangroupcode = Productdata.getPlangroupcode(custplan.productcode);

            Boolean isFixed = false;
            if (productcode != null && !productcode.Equals(""))
            {
                isFixed = Productdata.isFixed(productcode);
            }
            //int mincontributionperiod=

            char ruleclasscode = ' ';
            if (!custplan.classcode.Equals(""))
            {
                ruleclasscode = custplan.classcode.ToCharArray()[0];
            }
            if (productcode.Contains("VCR"))
            {
                if ((!custplan.SpecialPayment.HasValue || custplan.SpecialPayment.Value < 0) && custplan.HaveSpecialPayment.HasValue && custplan.HaveSpecialPayment.Value)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.SpecialPayment", errormessage = "SpecialPayment Cannot be blank", errormessageespanol = "El campo pago especial del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }
                if (!custplan.ProviderTypeId.HasValue || custplan.ProviderTypeId.Value < 1)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.ProviderTypeId", errormessage = "Institution financial Cannot be blank", errormessageespanol = "El campo institución financiera del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }
                if (!custplan.ProviderId.HasValue || custplan.ProviderId.Value < 1)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.ProviderId", errormessage = "Institution financial Cannot be blank", errormessageespanol = "El campo institución financiera del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }
                if (custplan.DestinyFund == string.Empty)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.DestinyFund", errormessage = "Destiny Fund Cannot be blank", errormessageespanol = "El campo destino de los fondos del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }
                if (!custplan.FinancingRate.HasValue || custplan.FinancingRate.Value < 0)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.FinancingRate", errormessage = "Financing Rate Cannot be blank", errormessageespanol = "El campo tasa de interes del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }

            }
            if (plangroupcode == ' ')
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.productcode", errormessage = "Plangroup Cannot be blank", errormessageespanol = "El campo para el código de grupo del plan no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (!(plangroupcode == ' ') && !(plangroupcode == Plangroups.EDUCATION || plangroupcode == Plangroups.FUNERAL || plangroupcode == Plangroups.LIFE || plangroupcode == Plangroups.RETIREMENT || plangroupcode == Plangroups.TERMINSURANCE))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.productcode", errormessage = "Plangroup not in range", errormessageespanol = "No grupo plan en el rango", errortype = WSErrorType.IS_BLANK, value = Plangroups.getPlangroups() });
            }

            int mincontributionperiod = Rules.getRulevalueint(Rules.MINIMUM_CONTRIBUTION_PERIOD, custplan.productcode, custplan.classcode.ToCharArray()[0]);
            int mininsuranceperiod = Rules.getRulevalueint(Rules.MINIMUM_INSURANCE_PERIOD, custplan.productcode, custplan.classcode.ToCharArray()[0]);


            if (custplan.contributiontypecode != null && (!custplan.contributiontypecode.Equals("") || !custplan.contributiontypecode.Equals("Select")) && !custplan.contributiontypecode.Equals("C"))
            {
                if (custplan.contributiontypecode == "U")
                {
                    if (custplan.contributionuntilage == 0)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionuntilage", errormessage = "Until Age cannot be empty.", errormessageespanol = "Hasta que edad no puede estar vacío.", errortype = WSErrorType.IS_BLANK, value = "0" });

                    }
                    if (Program.isPositiveInteger(custplan.contributionuntilage.ToString()) == false)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionuntilage", errormessage = "Until Age is invalid.", errormessageespanol = "Hasta la edad no es válida.", errortype = WSErrorType.IS_A_VALUE, value = "0" });

                    }
                }
                else
                {
                    if (custplan.contributionperiod == 0)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "contributionperiod cannot be blank", errormessageespanol = "El Periodo de Contribución no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "0" });
                    }
                    if (custplan.contributionperiod < mincontributionperiod)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "contributionperiod cannot be less than " + mincontributionperiod.ToString(), errormessageespanol = "El Periodo de Contribución no puede ser inferior a " + mincontributionperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = mincontributionperiod.ToString() });
                    }
                    if (custplan.insuranceperiod == 0)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuranceperiod", errormessage = "insuranceperiod cannot be blank", errormessageespanol = "El campo para el período del seguro no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "0" });
                    }
                    if (custplan.insuranceperiod < mininsuranceperiod)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuranceperiod", errormessage = "insuranceperiod cannot be less than " + mininsuranceperiod.ToString(), errormessageespanol = "El período del seguro no puede ser menor a " + mininsuranceperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = mininsuranceperiod.ToString() });
                    }
                }
            }



            if (custplan.countryno == 0)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.countryno", errormessage = "country cannot be blank", errormessageespanol = "El código de País no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "0" });
            }
            if ((custplan.countryno != 0) && Countries.getcountry(custplan.countryno).Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.countryno", errormessage = "country is not in List", errormessageespanol = "El código de País no no es válido", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = "0" });
            }
            if (custplan.calculatetypecode == null || ((custplan.calculatetypecode.Equals("")) && plangroupcode != Plangroups.FUNERAL))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.calculatetypecode", errormessage = "Calculate Type code is blank", errormessageespanol = "El tipo de Contribución no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            /*
            if ((!custplan.calculatetypecode.Equals("")) && plangroupcode != Plangroups.FUNERAL )
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.calculatetypecode", errormessage = "Calculate Type code not in list", errormessageespanol = "", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = "P|I|N" });
            }*/
            if (custplan.frequencytypecode == null || custplan.frequencytypecode.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.frequencytypecode", errormessage = "Frequency Type code is blank", errormessageespanol = "Código de Tipo de Frecuencia no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (custplan.frequencytypecode == null || ((!custplan.frequencytypecode.Equals("")) && Frequencytypes.getfrequencytype(custplan.frequencytypecode.ToCharArray()[0]).Equals("")))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.frequencytypecode", errormessage = "Frequency Type code is not in List", errormessageespanol = "La frecuencia de pago no es válida", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = "" });
            }
            if ((plangroupcode == Plangroups.LIFE || plangroupcode == Plangroups.RETIREMENT || plangroupcode == Plangroups.EDUCATION))
            {
                if (custplan.investmentprofilecode == null || custplan.investmentprofilecode.Equals(""))
                {
                    if (!custplan.productcode.Equals("EDU") && !custplan.productcode.Equals("HRZ"))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.investmentprofilecode", errormessage = "investmentprofilecode is blank", errormessageespanol = "El campo para el perfil de inversión no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                    }
                }
            }

            if ((plangroupcode == Plangroups.LIFE || plangroupcode == Plangroups.RETIREMENT || plangroupcode == Plangroups.EDUCATION))
            {
                if (custplan.investmentprofilecode == null || ((!custplan.investmentprofilecode.Equals("")) && (!(custplan.investmentprofilecode.ToCharArray()[0] == Invprofiledata.BALANCED || custplan.investmentprofilecode.ToCharArray()[0] == Invprofiledata.GROWTH || custplan.investmentprofilecode.ToCharArray()[0] == Invprofiledata.GUARANTEED || custplan.investmentprofilecode.ToCharArray()[0] == Invprofiledata.MODERATE))))
                {
                    if (!custplan.productcode.Equals("EDU") && !custplan.productcode.Equals("HRZ"))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.investmentprofilecode", errormessage = "investmentprofilecode not in list", errormessageespanol = "La tasa del perfil de inversión no está en la lista", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = "" });
                    }
                }
            }

            if (custplan.financialgoalage == null || ((custplan.financialgoalage != 0) && custplan.financialgoalage < 0))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be less than 0", errormessageespanol = "edad meta financiera no puede ser inferior a 0", errortype = WSErrorType.IS_LESS_THAN, value = "0" });
            }
            if (custplan.financialgoalage == null || ((custplan.financialgoalage != 0) && custplan.financialgoalage > 100))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be greater than 100", errormessageespanol = "edad meta financiera no puede ser mayor a 100", errortype = WSErrorType.IS_GREATER_THAN, value = "100" });
            }

            if (plangroupcode == Plangroups.LIFE)
            {
                //errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be greater than 100", errormessageespanol = "", errortype = WSErrorType.IS_GREATER_THAN, value = "100" });
            }
            else if (plangroupcode == Plangroups.EDUCATION || plangroupcode == Plangroups.RETIREMENT)
            {
                //errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be greater than 100", errormessageespanol = "", errortype = WSErrorType.IS_GREATER_THAN, value = "100" });
            }
            else if (plangroupcode == Plangroups.TERMINSURANCE)
            {
                if (custplan.calculatetypecode == null || custplan.calculatetypecode.Equals(""))
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.calculatetypecode", errormessage = "calculatetypecode is blank", errormessageespanol = "El campo de Calcular no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                }
                else if (!(custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.INSUREDAMOUNT || custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.PREMIUMAMOUNT))
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.calculatetypecode", errormessage = "calculatetypecode should be P or I", errormessageespanol = "calcular el código de tipo debe ser P o I", errortype = WSErrorType.VALUE_NOT_IN, value = "P|I" });
                }
                else
                {
                    if ((custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.INSUREDAMOUNT) && custplan.premiumamount <= 0)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "premiumamount should be greater than 0", errormessageespanol = "monto de la prima debe ser mayor que 0 ", errortype = WSErrorType.IS_LESS_THAN, value = "0" });
                    }
                    else if ((custplan.calculatetypecode.ToCharArray()[0] == Calculatetypes.PREMIUMAMOUNT) && custplan.insuredamount <= 0)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "insuredamount should be greater than 0", errormessageespanol = "suma asegurada debe ser mayor que 0 ", errortype = WSErrorType.IS_LESS_THAN, value = "0" });
                    }

                }
                //errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be greater than 100", errormessageespanol = "", errortype = WSErrorType.IS_GREATER_THAN, value = "100" });
            }
            else if (plangroupcode == Plangroups.FUNERAL)
            {
                //errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "financialgoalage cannot be greater than 100", errormessageespanol = "", errortype = WSErrorType.IS_GREATER_THAN, value = "100" });
            }


            if (custplan.activityrisktypeno == 0)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.activityrisktypeno", errormessage = "activityrisktypeno cannot be 0", errormessageespanol = "número de tipo de riesgo de la actividad no puede ser 0", errortype = WSErrorType.IS_BLANK, value = "0" });
            }
            else
            {
                if (Activityrisktypes.getActivityrisktype(custplan.activityrisktypeno, custplan.productcode).Equals(""))
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.activityrisktypeno", errormessage = "activityrisktypeno is not in ", errormessageespanol = "número de tipo de riesgo de la actividad no está en la lista", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = custplan.activityrisktypeno.ToString() });
                }

            }

            if (custplan.financialgoal != null && !custplan.financialgoal.Equals("") /*|| !ddlfingoal.Text.Equals(Lookuplangdata.getLanguagevalue(Lookuptables.booleandet, "Select", Sessionclass.getSessiondata(Session).language))*/)
            {
                char value = Convert.ToChar(custplan.financialgoal);
                if (value == 'Y')
                {
                    if (custplan.financialgoalamount == 0.0 && (custplan.financialgoalamount.Equals("") || custplan.financialgoalamount <= 0))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalamount", errormessage = "Financial Goal Amount cannot be empty.", errormessageespanol = "Meta Financiera Monto no puede estar vacío.", errortype = WSErrorType.IS_BLANK, value = "" });

                    }
                    if (custplan.financialgoalamount != 0.0 && Program.isPositiveDecimal(custplan.financialgoalamount.ToString()) == false)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalamount", errormessage = "Financial Goal Amount is invalid.", errormessageespanol = "Financiera Monto Meta no es válido.", errortype = WSErrorType.IS_A_VALUE, value = "" });

                    }
                    if (custplan.financialgoalage == 0 && custplan.financialgoalage.Equals(""))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalage", errormessage = "Financial Goal Until Age cannot be empty.", errormessageespanol = "Meta Financiera Hasta La edad no puede estar vacío.", errortype = WSErrorType.IS_BLANK, value = "" });

                    }
                    if (custplan.financialgoalage != 0 && Program.isPositiveInteger(custplan.financialgoalage.ToString()) == false)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.financialgoalamount", errormessage = "Financial Goal Until Age is invalid.", errormessageespanol = "Meta Financiera Hasta Edad no es válido.", errortype = WSErrorType.IS_A_VALUE, value = "" });

                    }
                }
            }

            if (custplan.initialcontributiontype != null && !custplan.initialcontributiontype.Equals(""))
            {
                string value = custplan.initialcontributiontype;
                if (value == "Y")
                {
                    if (custplan.initialcontributionamount != 0.0 && (custplan.initialcontributionamount.Equals("") || custplan.initialcontributionamount <= 0))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.initialcontributionamount", errormessage = "Initial Contribution Amount cannot be empty.", errormessageespanol = "Monto inicial Contribución no puede estar vacío.", errortype = WSErrorType.IS_BLANK, value = "" });

                    }
                    if (custplan.initialcontributionamount != 0.0 && Program.isPositiveDecimal(custplan.initialcontributionamount.ToString()) == false)
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.initialcontributionamount", errormessage = "Initial Contribution Amount is invalid.", errormessageespanol = "Monto inicial Contribución no es válido.", errortype = WSErrorType.IS_A_VALUE, value = "" });

                    }
                }
            }


            if (custplan.healthrisktypeno == 0)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.healthrisktypeno", errormessage = "healthrisktypeno cannot be 0", errormessageespanol = "valor del riesgo de salud no puede ser 0", errortype = WSErrorType.IS_BLANK, value = "0" });
            }
            else
            {
                if (Healthrisktypes.getHealthrisktype(custplan.healthrisktypeno, custplan.productcode).Equals(""))
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.healthrisktypeno", errormessage = "healthrisktypeno is not in ", errormessageespanol = "valor del riesgo de salud no está en la lista ", errortype = WSErrorType.VALUE_NOT_IN_LIST, value = custplan.healthrisktypeno.ToString() });
                }

            }

            //custplan.con

            //validateDatabeforecalculate



            int frequencytypevalue = Frequencytypes.getfrequencytypevalue(custplan.frequencytypecode);
            double premiumamount = custplan.premiumamount * frequencytypevalue;
            double insuredamount = custplan.insuredamount;

            if (plangroupcode != Plangroups.FUNERAL)
            {
                double gsmaxinsuredamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_INSURED_AMOUNT, productcode, ruleclasscode);
                double gsmaxpremiumamount = Rules.getRulevaluedouble(Rules.GS_MAXIMUM_PREMIUM_AMOUNT, productcode, ruleclasscode);

                if (premiumamount > gsmaxpremiumamount)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Premium Amount cannot be greater than " + gsmaxpremiumamount.ToString("$#,##0.00"), errormessageespanol = "El monto de la prima no puede ser mayor que " + gsmaxpremiumamount.ToString("$#,##0.00"), errortype = WSErrorType.IS_GREATER_THAN, value = gsmaxpremiumamount.ToString() });

                }
                //if (insuredamount > gsmaxinsuredamount)
                //{
                //    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount cannot be greater than " + gsmaxinsuredamount.ToString(), errormessageespanol = "El período del seguro no puede ser mayor que " + gsmaxinsuredamount.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = gsmaxinsuredamount.ToString() });

                //}

            }

            double minimumcontributionperiod = Rules.getRulevalueint(Rules.MINIMUM_CONTRIBUTION_PERIOD, productcode, ruleclasscode);
            int maxageendannuity = Rules.getRulevalueint(Rules.MAXIMUM_AGE_END_ANNUITY, productcode, ruleclasscode);

            int insuranceminage = Rules.getRulevalueint(Rules.INSURANCE_MIN_AGE, productcode, ruleclasscode);
            int insurancemaxage = Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE, productcode, ruleclasscode);
            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, productcode, ruleclasscode);

            int numberofyears = 0;
            int age = cust.Age;

            double mininsuredamount = Rules.getRulevaluedouble(Rules.MINIMUM_INSURED_AMT, productcode, ruleclasscode);
            double maxinsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT, productcode, ruleclasscode);

            char contributiontypecode = custplan.contributiontypecode.ToCharArray()[0];
            string calculatetypecode = custplan.calculatetypecode;
            char plantypecode = custplan.plantypecode.ToCharArray()[0];
            //Plantypes.

            double annualpremium = getAnnualizedpremium(custplan);
            //double premiumamount = custplan.premiumamount;
            //double insuredamount = custplan.insuredamount;
            double minumumpremium = Rules.getRulevaluedouble(Rules.MINIMUM_YEARLY_PREMIUM, productcode, ruleclasscode);

            int insuranceunderage = Rules.getRulevalueint(Rules.INSURANCE_UNDERAGE, productcode, ruleclasscode);
            double underagemaxinsuredamount = Rules.getRulevaluedouble(Rules.MAXIMUM_INSURED_AMT_UNDERAGE, productcode, ruleclasscode);









            //Plantypes.

            if (plangroupcode == Plangroups.LIFE)
            {
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
            }
            else
            {
                numberofyears = custplan.contributionperiod;
            }





            //  int mininsuranceperiod = Rules.getRulevalueint(Rules.MINIMUM_INSURANCE_PERIOD, productcode, ruleclasscode);
            int maxinsuranceperiod = Rules.getRulevalueint(Rules.MAXIMUM_INSURANCE_PERIOD, productcode, ruleclasscode);

            int maxageinsuranceterm = Rules.getRulevalueint(Rules.MAX_AGE_INSURANCE_TERM, productcode, ruleclasscode);

            if (numberofyears <= 0)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be greater than 1", errormessageespanol = "Los años para el pago de la prima deben ser mayor que 1", errortype = WSErrorType.IS_LESS_THAN, value = "1" });
            }

            if (maxageinsuranceterm > 0)
            {
                if ((numberofyears + age) > maxageinsuranceterm)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Contribution Period + Age cannot be greater than " + maxageinsuranceterm.ToString(), errormessageespanol = "La Edad + Periodo de Contribución  no puede ser mayor a " + maxageinsuranceterm.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxageinsuranceterm.ToString() });

                }
            }


            if (minimumcontributionperiod > 0)
            {
                if (numberofyears < minimumcontributionperiod)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.contributionperiod", errormessage = "Premium Payment Years need to be at least " + minimumcontributionperiod.ToString(), errormessageespanol = "Los años para el pago de la prima deben ser por lo menos " + minimumcontributionperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = minimumcontributionperiod.ToString() });

                }
            }


            if (insuranceminage > 0)
            {
                if (cust.Age < insuranceminage)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.Age", errormessage = "Age is not between minimum and maximum insurance age.", errormessageespanol = "La edad no esta entre nuestra edad mínima (1) y máxima (65) para emitir una poliza", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "", rangefromvalue = insuranceminage, rangetovalue = insurancemaxage });

                }
            }

            if (insurancemaxage > 0)
            {
                if (cust.Age > insurancemaxage)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.Age", errormessage = "Age is not between minimum and maximum insurance age.", errormessageespanol = "La edad no esta entre nuestra edad mínima (1) y máxima (65) para emitir una poliza", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "", rangefromvalue = insuranceminage, rangetovalue = insurancemaxage });

                }
            }

            if (maxageinsuranceterm > 0)
            {
                if ((numberofyears + age) > maxageinsuranceterm)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.age", errormessage = "Contribution Period + Age should not be greater than maximum age.", errormessageespanol = "La Edad + Periodo de Contribución  no puede ser mayor a la edad maxima", errortype = WSErrorType.IS_GREATER_THAN, value = "" });

                }
            }
            if (!(plangroupcode == Plangroups.LIFE))
            {
                if (calculatetypecode != null)
                {
                    if (minumumpremium > 0)
                    {
                        if ((annualpremium < minumumpremium) && (calculatetypecode.ToCharArray()[0] != Calculatetypes.PREMIUMAMOUNT))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.premiumamount", errormessage = "Premium should be greater than " + minumumpremium.ToString("$#,##0.00"), errormessageespanol = "La prima debe ser mayor que " + minumumpremium.ToString("$#,##0.00"), errortype = WSErrorType.IS_LESS_THAN, value = minumumpremium.ToString() });

                        }

                    }
                }

                if (underagemaxinsuredamount > 0)
                {
                    if ((age <= insuranceunderage) && (calculatetypecode.ToCharArray()[0] != Calculatetypes.INSUREDAMOUNT) && (insuredamount > underagemaxinsuredamount))
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Underage insured amount should not be greater than " + underagemaxinsuredamount.ToString("$#,##0.00"), errormessageespanol = "El monto asegurado para menores de edad no puede ser mayor que " + underagemaxinsuredamount.ToString("$#,##0.00"), errortype = WSErrorType.IS_GREATER_THAN, value = underagemaxinsuredamount.ToString() });


                    }
                }

                if (!(plangroupcode == Plangroups.FUNERAL))
                {
                    if (mininsuredamount > 0)
                    {
                        if ((calculatetypecode.ToCharArray()[0] != Calculatetypes.INSUREDAMOUNT) && (insuredamount < mininsuredamount))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount should be between " + mininsuredamount.ToString("$#,##0.00") + " y " + maxinsuredamount.ToString("$#,##0.00"), errormessageespanol = "La suma asegurada debe ser un número entre " + mininsuredamount.ToString("$#,##0.00") + " y " + maxinsuredamount.ToString("$#,##0.00"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = mininsuredamount.ToString() + "and" + " " + maxinsuredamount.ToString(), rangefromvalue = mininsuredamount, rangetovalue = maxinsuredamount });


                        }
                    }

                    if (maxinsuredamount > 0)
                    {
                        if ((calculatetypecode.ToCharArray()[0] != Calculatetypes.INSUREDAMOUNT) && (insuredamount > maxinsuredamount))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.insuredamount", errormessage = "Insured Amount should be between " + mininsuredamount.ToString("$#,##0.00") + " y " + maxinsuredamount.ToString("$#,##0.00"), errormessageespanol = "La suma asegurada debe ser un número entre " + mininsuredamount.ToString("$#,##0.00") + " y " + maxinsuredamount.ToString("$#,##0.00"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = mininsuredamount.ToString() + " " + "and" + " " + maxinsuredamount.ToString(), rangefromvalue = mininsuredamount, rangetovalue = maxinsuredamount });

                        }
                    }
                }
            }

            if (plangroupcode == Plangroups.EDUCATION || plangroupcode == Plangroups.RETIREMENT)
            {
                if (Program.isPositiveInteger(custplan.retirementperiod.ToString()) == false)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.retirementperiod", errormessage = "Insurance Period cannot be empty.", errormessageespanol = "El campo para el período del seguro no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });

                }
            }

            //if (mininsuranceperiod > 0)
            //{
            //    if (custplan.insuranceperiod < mininsuranceperiod)
            //    {
            //        errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.retirementperiod", errormessage = "Insurance Period cannot be less than " + mininsuranceperiod.ToString(), errormessageespanol = "El período del seguro no puede ser inferior a " + mininsuranceperiod.ToString(), errortype = WSErrorType.IS_LESS_THAN, value = mininsuranceperiod.ToString() });

            //    }
            //}


            if (maxinsuranceperiod > 0)
            {
                if (custplan.insuranceperiod > maxinsuranceperiod)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.retirementperiod", errormessage = "Insurance Period cannot be greater than " + maxinsuranceperiod.ToString(), errormessageespanol = "El período del seguro no puede ser mayor que " + maxinsuranceperiod.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxinsuranceperiod.ToString() });

                }
            }

            if (maxageinsuranceterm > 0)
            {
                if ((age + custplan.insuranceperiod) > maxageinsuranceterm)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.retirementperiod", errormessage = "Term Insurance can be provide only until " + maxageinsuranceterm.ToString(), errormessageespanol = "El seguro a término sólo puede ser provisto hasta " + maxageinsuranceterm.ToString(), errortype = WSErrorType.IS_GREATER_THAN, value = maxageinsuranceterm.ToString() });

                }
            }
            if (!(plangroupcode == Plangroups.LIFE))
            {
                if ((numberofyears) != custplan.insuranceperiod)
                {
                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.retirementperiod", errormessage = "Insurance Period and Premium Period should be equal", errormessageespanol = "El período del seguro y de la prima deben ser iguales", errortype = WSErrorType.IS_A_VALUE, value = "" });

                }
            }







            return errorslist;



        }


        public static double calculatepv(double growthrate, int frequency, double amount)
        {
            double netamount = amount;
            for (int i = 1; i < frequency; i++)
            {
                netamount = netamount + amount * (1.0 / Math.Pow((1 + growthrate), i));

            }
            return netamount;

        }


        public static double getAnnualizedpremium(WSCustomerPlan custplan)
        {
            try
            {
                String productcode = custplan.productcode;
                char classcode = custplan.classcode.ToCharArray()[0];
                char investmentprofilecode = custplan.investmentprofilecode.ToCharArray()[0];
                double growthrate = Productinvprofile.getInvprofilerate(investmentprofilecode, productcode, classcode);
                int frequencytypevalue = Frequencytypes.getfrequencytypevalue(Frequencytypes.getfrequencytype(custplan.frequencytypecode.ToCharArray()[0]));
                double periodicgrowthrate = Math.Pow((1 + growthrate), 1.0 / frequencytypevalue * 1.0) - 1;
                double frequencytypepenalty = Frequencytypes.getfrequencytypepenalty(Frequencytypes.getfrequencytype(custplan.frequencytypecode.ToCharArray()[0]));
                double periodicpremiumamount = custplan.premiumamount;
                double netperiodicpayment = periodicpremiumamount / (1 + frequencytypepenalty);
                double annualizedpremiumamount = calculatepv(growthrate, frequencytypevalue, netperiodicpayment);
                return annualizedpremiumamount;

            }
            catch (Exception ex)
            {
                return 0;
            }


        }



    }
}