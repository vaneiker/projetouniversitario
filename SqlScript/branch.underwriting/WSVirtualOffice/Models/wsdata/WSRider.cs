using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSVirtualOffice.Models.businesslogic;

namespace WSVirtualOffice.Models.wsdata
{
    public class WSRider
    {
        public readonly static string RIDERADB = "ADB";
        public readonly static string RIDERTERM = "TERM";
        //public readonly static string RIDEROIR = "OIR";
        public readonly static string RIDERFAMILIAR = "FAMILIAR";
        public readonly static string RIDERREPATRIACION = "REPATRIACION";
        public readonly static string RIDERSEPELTURALOTE = "SEPELTURALOTE";
        public readonly static string RIDERCI = "CI";

        public string ridertypecode { get; set; }
        public double amount { get; set; }
        public int term { get; set; }
        public string type { get; set; }
        public static List<WSValidationError> getRidersValidationErrorsList(List<WSRider> riderslist, WSCustomerPlanPartner partins, WSCustomerPlan custplan,WSCustomer cust)
        {
            List<WSValidationError> errorslist = new List<WSValidationError>();
            try
            {
            foreach (var item in riderslist)
            {
                
                    double adbamount = 0;
                    double termamount = 0;
                    double oiramount = 0;

                    if (item.ridertypecode.Equals("ADB"))
                    {
                        if (item.amount==0.0)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "ADB Amount cannot be empty.", errormessageespanol = "El campo de cantidad del suplemento ADB no se puede dejar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
           
                        }
                        else if (Program.isdecimal(item.amount.ToString()) == false)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "ADB Amount is invalid.", errormessageespanol = "La cantidad del suplemento ADB no es válida, necesita ser un número", errortype = WSErrorType.IS_A_VALUE, value = "" });
           
                        }
                        if (Program.isdecimal(item.amount.ToString()) == true)
                        {
                            if (Numericdata.getDoublevalue(item.amount.ToString()) < 0.0)
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "ADB Amount cannot be negative.", errormessageespanol = "La cantidad del suplemento ADB no puede ser negativa", errortype = WSErrorType.IS_A_VALUE, value = "" });
           
                            }

                        }
                        if (item.amount!=null)
                        adbamount = Numericdata.getDoublevalue(item.amount.ToString());

                    }

                    if (item.ridertypecode.Equals("TERM"))
                    {
                        //char termcontrcode = Contributiontypes.getcontributiontypecode(Lookuplangdata.getEnglishvalue(Lookuptables.contributiontypedet, ddluntilageterm.Text, Sessionclass.getSessiondata(Session).language));
                        if (item.amount == 0.0)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Term Amount cannot be empty.", errormessageespanol = "El campo para la cantidad a término no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                                     
                        }
                        if (Program.isdecimal(item.amount.ToString()) == false)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Term Amount is invalid.", errormessageespanol = "La cantidad a término no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });
           
                        }


                        if (item.type == null || (item.type.Equals("") || item.type.Equals("Select")))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSRider.amount", errormessage = "Term Age cannot be empty.", errormessageespanol = "El campo para la edad a término no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
           
                        }
                        if (item.term == 0)
                        {
                            if (item.type == Contributiontypes.UNTILAGE.ToString() || item.type == Contributiontypes.NUMBEROFYEARS.ToString())
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age cannot be empty.", errormessageespanol = "El campo para la edad a término no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            
                            }
                        }
                        if (Program.isPositiveInteger(item.term.ToString()) == false)
                        {
                            if (item.type == Contributiontypes.UNTILAGE.ToString() || item.type == Contributiontypes.NUMBEROFYEARS.ToString())
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age is invalid.", errormessageespanol = "La edad a término no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });

                            }

                        }

                        if (Program.isinteger(item.term.ToString()) == true)
                        {
                            if (Program.isPositiveInteger(item.term.ToString()))
                            {
                                if (Convert.ToInt16(item.term.ToString()) <= 0)
                                {
                                    if (item.type == Contributiontypes.UNTILAGE.ToString() || item.type == Contributiontypes.NUMBEROFYEARS.ToString())
                                    {
                                        errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age should be greater than 0.", errormessageespanol = "La edad a término debe ser mayor que 0", errortype = WSErrorType.IS_LESS_THAN, value = "0" });
                                    }
                                }
                            }
                            else
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age is invalid.", errormessageespanol = "La edad a término no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                            }

                        }

                        if (item.type == Contributiontypes.UNTILAGE.ToString())
                        {

                            int agee = cust.Age;
                            if (Program.isPositiveInteger(item.term.ToString()))
                            {
                                if (Numericdata.getIntegervalue(item.term.ToString()) < agee)
                                {
                                    errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Until Age cannot be less than age.", errormessageespanol = "Plazo Hasta La edad no puede ser inferior a la edad.", errortype = WSErrorType.IS_LESS_THAN, value = "" });
            
                                }
                            }
                            else
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age is invalid.", errormessageespanol = "La edad a término no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                            }
                        }
                        else if (item.type == Contributiontypes.NUMBEROFYEARS.ToString())
                        {
                            if (Program.isPositiveInteger(item.term.ToString()))
                            {
                                if (Numericdata.getIntegervalue(item.term.ToString()) <= 0)
                                {
                                    errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term number of years should be greater than 0.", errormessageespanol = "Número de Plazo de año debe ser mayor que 0.", errortype = WSErrorType.IS_LESS_THAN, value = "" });
            
                                }
                            }
                            else
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Age is invalid.", errormessageespanol = "La edad a término no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                            }
                        }
                        if (Program.isPositiveDecimal(item.amount.ToString()) == true)
                        {
                            if (Numericdata.getDoublevalue(item.amount.ToString()) < 0.0)
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSRider.term", errormessage = "Term Amount cannot be negative.", errormessageespanol = "La cantidad a término no puede ser negativa", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                            }

                        }
                        if (item.amount!=null)
                            termamount = Numericdata.getDoublevalue(item.amount.ToString());
                    }
                }
                if(errorslist.Count!=0)
                {
                    return errorslist;
                }

                if (custplan.rideroir == "Y")
                    {

                        //char spousecontrtypecode = partins.contributiontypecode;

                        if (partins.amount==0.0)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.amount", errormessage = "Other insured amount cannot be empty.", errormessageespanol = "El campo para el monto de otro asegurado no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            
                        }

                        else if (Program.isdecimal(partins.amount.ToString()) == false)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.amount", errormessage = "Other insured amount is invalid.", errormessageespanol = "El monto de otro asegurado no es válido", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                        }
                        else if (partins.term==0)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Spouse/Other Insured Age cannot be empty.", errormessageespanol = "Cónyuge/otro asegurado: El campo para la edad no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
            
                        }
                        else if (Program.isinteger(partins.term.ToString()) == false)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Spouse/Other Insured Age is invalid.", errormessageespanol = "Cónyuge/otro asegurado: La edad no es válida", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                        }
                        else if (partins.term==0)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Contribution Number of years Spouse cannot be empty.", errormessageespanol = "El número de años de seguro para el Otro asegurado no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                                
                        }
                        else if (Program.isinteger(partins.term.ToString()) == false)
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Contribution Number of years Spouse cannot be empty.", errormessageespanol = "El número de años de seguro para el Otro asegurado no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                           
                        }

                        else if (partins.gendercode==null || partins.gendercode.Equals(""))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.gendercode", errormessage = "Spouse/Other Insured Sex of cannot be empty.", errormessageespanol = "Cónyuge/otro asegurado: El campo para el género no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                          
                        }
                        else if (partins.maritalstatuscode == null || partins.maritalstatuscode.Equals(""))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.maritalstatuscode", errormessage = "Spouse/Other Insured Marital Status cannot be empty.", errormessageespanol = "Cónyuge/otro: El campo para el estado civil no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                          
                        }

                        else if (partins.smoker == null || partins.smoker.Equals(""))
                        {
                            errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.smoker", errormessage = "Spouse/Other Insured Smoker cannot be empty.", errormessageespanol = "Cónyuge/otro: El campo para fumadores no puede estar vacío", errortype = WSErrorType.IS_BLANK, value = "" });
                          
                        }
                       
                        if (Program.isdecimal(partins.amount.ToString()) == true)
                        {
                            if (Numericdata.getDoublevalue(partins.amount.ToString()) < 0.0)
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.amount", errormessage = "Other insured amount cannot be negative.", errormessageespanol = "El monto de otro asegurado no puede ser negativo", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                            }

                        }

                        if (Program.isinteger(partins.term.ToString()) == true && Program.isinteger(partins.age.ToString()) == true && Program.isinteger(partins.term.ToString()) == true)
                        {

                            if (Numericdata.getIntegervalue(partins.term.ToString()) <= 0)
                                {
                                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Number of years should be greater than 0", errormessageespanol = "El número de años debe ser mayor que 0", errortype = WSErrorType.IS_LESS_THAN, value = "" });
            
                                }
                            
                        }

                        if (Program.isinteger(partins.age.ToString()) == true)
                        {
                            if (Convert.ToInt16(partins.age.ToString()) <= 0)
                            {
                                errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.age", errormessage = "Age of other insured should be greater than 0", errormessageespanol = "La edad del asegurado adicional debe ser mayor a 0", errortype = WSErrorType.IS_LESS_THAN, value = "" });
            
                            }

                        }
                        if (Program.isinteger(partins.term.ToString()) == true)
                        {

                            if (Convert.ToInt16(partins.term.ToString()) < 0)
                                {
                                    errorslist.Add(new WSValidationError() { errorfield = "WSCustomerPlanPartner.term", errormessage = "Number of years cannot be negative.", errormessageespanol = "El número de años no puede ser negativo", errortype = WSErrorType.IS_A_VALUE, value = "" });
            
                                }
                            
                        }

                    }
      

                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            
            return errorslist;
        }
        
    }
}