using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSCustomer
    {        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string MiddleName { get; set; }        
        public int Age { get; set; }
        public string gendercode { get; set; }
        public string MaritalStatuscode { get; set; }
        public string Smoker { get; set; }

      //  public string rescountryno { get; set; }

        public static List<WSValidationError> getCustomerValidationErrorsList(WSCustomer cust,WSCustomerPlan custplan)
        {
            List<WSValidationError> errorslist = new List<WSValidationError>();
            if (custplan.productcode==null || custplan.productcode.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.productcode", errormessage = "Productcode Cannot be blank", errormessageespanol = "El campo para el código del producto no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (custplan.productcode == null || ((!custplan.productcode.Equals("")) && (Productdata.getProduct(custplan.productcode, custplan.company_id).Equals(""))))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.productcode", errormessage = "Productcode not in List", errormessageespanol = "El código del producto no existe", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = Productdata.getProducts(custplan.company_id) });
            }
            if (custplan.classcode == null || custplan.classcode.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.classcode", errormessage = "classcode Cannot be blank", errormessageespanol = "El código de clase no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (custplan.classcode == null || (!custplan.classcode.Equals("")) && !(custplan.classcode.ToCharArray()[0] == Currencytypes.USD || custplan.classcode.ToCharArray()[0] == Currencytypes.RD || custplan.classcode.ToCharArray()[0] == Currencytypes.Euro))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlan.classcode", errormessage = "classcode not in list", errormessageespanol = "El código de clase no existe", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
            }
            if (errorslist.Count > 0)
            {
                return errorslist;
            }
            int minageinsurance=Rules.getRulevalueint(Rules.INSURANCE_MIN_AGE,custplan.productcode,custplan.classcode.ToCharArray()[0]);
            int maxageinsurance=Rules.getRulevalueint(Rules.INSURANCE_MAX_AGE,custplan.productcode,custplan.classcode.ToCharArray()[0]);

            int maxage = Rules.getRulevalueint(Rules.MAX_AGE, custplan.productcode, custplan.classcode.ToCharArray()[0]);

            //Maritalstatus.

            int maxageExitinsurance = Rules.getRulevalueint(Rules.MAX_AGE_EXIT_INSURANCE, custplan.productcode, custplan.classcode.ToCharArray()[0]);


            if (cust.Age == null || cust.Age == 0)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Age Cannot be zero", errormessageespanol = "La edad no puede ser menor o igual a cero", errortype = WSErrorType.IS_A_VALUE, value = "0" });
            }
            if (cust.Age == null || cust.Age < minageinsurance || cust.Age > maxageinsurance)
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Age not in Range", errormessageespanol = "La edad no esta entre nuestra edad mínima (1) y máxima (65) para emitir una poliza.", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = minageinsurance.ToString() + "|" + maxageinsurance.ToString(),rangefromvalue=minageinsurance,rangetovalue=maxageinsurance });
            }
            if (cust.Smoker == null || cust.Smoker.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Smoker", errormessage = "Smoker Cannot be blank", errormessageespanol = "El campo para fumador no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (cust.Smoker == null || !(cust.Smoker.Equals("Y") || cust.Smoker.Equals("N")))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Smoker", errormessage = "Smoker value should be Y or N", errormessageespanol = "Fumador valor debe ser Sí o No", errortype = WSErrorType.VALUE_NOT_IN, value = "Y|N" });
            }
            if (cust.MaritalStatuscode == null || cust.MaritalStatuscode.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.MaritalStatuscode", errormessage = "Marital Status Cannot be blank", errormessageespanol = "El campo para el estado civil no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (cust.MaritalStatuscode == null || Maritalstatus.getmaritalstatus(cust.MaritalStatuscode).Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.MaritalStatuscode", errormessage = "Marital Status values not in List", errormessageespanol = "no los valores de estado civil en la lista", errortype = WSErrorType.IS_BLANK, value = Maritalstatus.getMaritalstatusValues() });
            }

            if (cust.gendercode == null || cust.gendercode.Equals(""))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.gendercode", errormessage = "Gender Cannot be blank", errormessageespanol = "El campo para el código de género no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            }
            if (cust.gendercode == null || !(cust.gendercode.Equals("M") || cust.gendercode.Equals("F")))
            {
                errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.gendercode", errormessage = "Gender value should be M or F", errormessageespanol = "Valor de Género debe ser M o F", errortype = WSErrorType.VALUE_NOT_IN, value = "Y|N" });
            }

            return errorslist;

        }

        public static List<WSValidationError> getCustomerAgeValidationList(WSCustomer cust, List<WSRider> riderslist, WSCustomerPlan custplan)
        {
            List<WSValidationError> errorslist = new List<WSValidationError>();
            int maxageExitRiderAdb = Rules.getRulevalueint(Rules.MAX_AGE_EXIT_RIDER_ADB, custplan.productcode, custplan.classcode.ToCharArray()[0]);
            int maxageExitRiderCI = Rules.getRulevalueint(Rules.MAX_AGE_EXIT_RIDER_CI, custplan.productcode, custplan.classcode.ToCharArray()[0]);
            int maxageExitRiderTerm = Rules.getRulevalueint(Rules.MAX_AGE_EXIT_RIDER_TERM, custplan.productcode, custplan.classcode.ToCharArray()[0]);

            foreach (WSRider rider in riderslist)
            {
                if (rider.ridertypecode.Equals(WSRider.RIDERADB))
                {
                    if (cust.Age + custplan.contributionperiod > maxageExitRiderAdb) //Muerte Accidental
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Customer Age greater for ADB Rider", errormessageespanol = "La persona, en base a su edad, no puede tomar el suplemento de Muerte Accidental al plazo elegido.", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                    }
                }
                else if (rider.ridertypecode.Equals(WSRider.RIDERCI))
                {
                    if (cust.Age + custplan.contributionperiod > maxageExitRiderCI) //Muerte Accidental
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Customer Age greater for CI Rider", errormessageespanol = "La persona, en base a su edad, no puede tomar el suplemento de Invalidez total y permanente al plazo elegido.", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                    }
                }
                else if (rider.ridertypecode.Equals(WSRider.RIDERTERM))
                {
                    if (cust.Age + custplan.contributionperiod > maxageExitRiderTerm) //Gastos Funerarios
                    {
                        errorslist.Add(new WSValidationError() { errorfield = "WSCustomer.Age", errormessage = "Customer Age greater for TERM Rider", errormessageespanol = "La persona, en base a su edad, no puede tomar el suplemento de Gastos Funerarios al plazo elegido.", errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                    }
                }
            }

            return errorslist;
        }

        //Bmarroquin 15-03-2017 Validar sumas aseguradas minimas y maximas de Funeral Expenses
        public static List<WSValidationError> getRider_FE_ValidationList(WSCustomer cust, List<WSRider> riderslist, WSCustomerPlan custplan)
        {
            List<WSValidationError> errorslist = new List<WSValidationError>();
            int lInt_Max_InsuredAmount_GF = Rules.getRulevalueint(Rules.MAX_AMOUNT_INSURED_FE, custplan.productcode, custplan.classcode.ToCharArray()[0]);
            int lInt_Min_InsuredAmount_GF = Rules.getRulevalueint(Rules.MIM_AMOUNT_INSURED_FE, custplan.productcode, custplan.classcode.ToCharArray()[0]);

            double dMinPercentageFE = Rules.getRulevaluedouble(Rules.MIN_PERCENTAGE_INSURED_FE, custplan.productcode, custplan.classcode.ToCharArray()[0]);
            double dInsuredAmount = custplan.insuredamount;

            foreach (WSRider rider in riderslist)
            {
                if (rider.ridertypecode.Equals(WSRider.RIDERTERM)) //Gastos Funerarios
                {
                    /*      Lgonzalez 30-03-2017 --- SUSTITUIDO POR LA VALIDACION DEL 10% MINIMO DE LA SUMA ASEGURADA EN VIDA BASICO, ESTO REVENTARÁ LUEGO  
                    if (rider.amount < lInt_Min_InsuredAmount_GF) 
                    {
                        //Bmarroquin 22-03-2017 cambio xq la cobertura de GF, el minimo cambio de 1,800 a 1,000 
                        errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses can't be smaller than " + lInt_Min_InsuredAmount_GF.ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios no puede ser menor que " + lInt_Min_InsuredAmount_GF.ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                    }
                    */

                    //Lgonzalez 23-03-2017
                    if ((dInsuredAmount * dMinPercentageFE) < lInt_Max_InsuredAmount_GF) //Si el 10% de la suma asegurada es menor que el monto maximo, se evalua el valor del rider, en minimos y maximos
                    {
                        if (rider.amount < (dInsuredAmount * dMinPercentageFE))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses can't be smaller than " + (dInsuredAmount * dMinPercentageFE).ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios no puede ser menor que " + (dInsuredAmount * dMinPercentageFE).ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                        }

                        if (rider.amount > lInt_Max_InsuredAmount_GF) //
                        {
                            //Bmarroquin 22-03-2017 cambio xq la cobertura de GF, el minimo cambio de 1,800 a 1,000 
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses can't be greater than " + lInt_Max_InsuredAmount_GF.ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios no puede ser mayor que " + lInt_Max_InsuredAmount_GF.ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                        }
                    }
                    else //Si el 10% de la suma aseguarada es mayor que el monto maximo, se obliga a que sea el rider tenga valor maximo
                    {
                        if (rider.amount != lInt_Max_InsuredAmount_GF)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses must be " + lInt_Max_InsuredAmount_GF.ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios debe ser " + lInt_Max_InsuredAmount_GF.ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                        }
                    }

                    /*
                    if ((dInsuredAmount * dMinPercentageFE) < lInt_Max_InsuredAmount_GF) //Lgonzalez 30-03-2017 - Si el 10% de lo asegurado es menor q el maximo, vale la pena hacer la validacion contra el monto maximo de GF
                    {
                        if (rider.amount > lInt_Max_InsuredAmount_GF)
                        {
                            //Bmarroquin 22-03-2017 cambio xq la cobertura de GF, el minimo cambio de 1,800 a 1,000 
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses can't be greater than " + lInt_Max_InsuredAmount_GF.ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios no puede ser mayor que " + lInt_Max_InsuredAmount_GF.ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                        }
                    }
                    else //Lgonzalez 30-03-2017 - Si 10% de lo asegurado es mayor q el monto maximo, solo permitiremos q los GF sean del 10%
                    {
                        if (rider.amount != (dInsuredAmount * dMinPercentageFE))
                        {
                            //Lgonzalez 30-03-2017 
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Insured Amount for Funeral Expenses can't be greater than " + (dInsuredAmount * dMinPercentageFE).ToString("C2"), errormessageespanol = "La suma asegurada de Gastos Funerarios no puede ser mayor que " + (dInsuredAmount * dMinPercentageFE).ToString("C2"), errortype = WSErrorType.VALUE_NOT_IN_RANGE, value = "" });
                        }
                    }
                    */
                    break; //Que no siga iterando si se proceso GF
                }
            }

            return errorslist;
        }
        //Bmarroquin 15-03-2017

        public static List<WSValidationError> getCustomerPlanValidationErrorsList(WSCustomer cust,WSCustomerPlan custplan)
        {
            List<WSValidationError> errorslist = new List<WSValidationError>();
            return errorslist;

        }

        


    }
}