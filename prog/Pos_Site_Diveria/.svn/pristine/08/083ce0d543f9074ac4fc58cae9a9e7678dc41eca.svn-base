using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STL.POS.Frontend.Web.Areas.CardNet.Models
{

    public class ResponseModel
    {
        public String Id { get; set; }
        public String CreditCardNumber { get; set; }
        public String ResponseCode { get; set; }
        public String AuthorizationCode { get; set; }
        public String RetrivalReferenceNumber { get; set; }
        public String OrdenId { get; set; }
        public String TransactionId { get; set; }

        public String ResponseMsg
        {
            get
            {
                String value = "";
                switch (ResponseCode)
                {
                    case "N7":
                        value = "Invalid Expiration date";
                        break;
                    case "00":
                        value = "Approved or completed successfully";
                        break;
                    case "01":
                        value = "Refer to card issuer";
                        break;
                    case "02":
                        value = "Refer to card issuer special condition";
                        break;
                    case "03":
                        value = "Ivalid merchant";
                        break;
                    case "04":
                        value = "Pick-up Card";
                        break;
                    case "05":
                        value = "Do not honor";
                        break;
                    case "06":
                        value = "Error";
                        break;
                    case "07":
                        value = "Request in Progress";
                        break;
                    case "08":
                        value = "Honor with identification";
                        break;
                    case "09":
                        value = "Request in progress";
                        break;
                    case "10":
                        value = "Approved partial";
                        break;
                    case "11":
                        value = "Approved VIP";
                        break;
                    case "12":
                        value = "Invalid transaction";
                        break;
                    case "13":
                        value = "Invalid amount";
                        break;
                    case "14":
                        value = "Invalid card number";
                        break;
                    case "15":
                        value = "No such issuer";
                        break;
                    case "16":
                        value = "Approved update track 3";
                        break;
                    case "17":
                        value = "Customer cancellation";
                        break;
                    case "18":
                        value = "Customer dispute";
                        break;
                    case "19":
                        value = "Re enter transaction";
                        break;
                    case "20":
                        value = "Invalid response";
                        break;
                    case "21":
                        value = "No action taken";
                        break;
                    case "22":
                        value = "Suspected malfunction";
                        break;
                    case "23":
                        value = "Unacceptable transaction fee";
                        break;
                    case "24":
                        value = "File update not supported";
                        break;
                    case "25":
                        value = "Unable to locate record";
                        break;
                    case "26":
                        value = "Duplicate record";
                        break;
                    case "27":
                        value = "File update edit error";
                        break;
                    case "28":
                        value = "File update file locked";
                        break;
                    //----Not 29
                    case "30":
                        value = "File update failed";
                        break;
                    case "31":
                        value = "Bank not supported";
                        break;
                    case "32":
                        value = "Completed partially";
                        break;
                    case "33":
                        value = "Expired card pick-up";
                        break;
                    case "34":
                        value = "Suspected fraud pick-up";
                        break;
                    case "35":
                        value = "Contact acquirer pick-up";
                        break;
                    case "36":
                        value = "Restricted card pick-up";
                        break;
                    case "37":
                        value = "Call acquirer security pick up";
                        break;
                    case "38":
                        value = "PIN tries exceeded pick-up";
                        break;
                    case "39":
                        value = "No credit account";
                        break;
                    case "40":
                        value = "Function not supported";
                        break;
                    case "41":
                        value = "Lost card";
                        break;
                    case "42":
                        value = "No universal account";
                        break;
                    case "43":
                        value = "Stolen card";
                        break;
                    case "44":
                        value = "No investment account";
                        break;
                    //--- 45 to 50 Not found
                    case "51":
                        value = "Not sufficient funds";
                        break;
                    case "52":
                        value = "No checked account";
                        break;
                    case "53":
                        value = "No savings account";
                        break;
                    case "54":
                        value = "Expired card";
                        break;
                    case "55":
                        value = "Incorrect PIN";
                        break;
                    case "56":
                        value = "No card record";
                        break;
                    case "57":
                        value = "Transaction not permitted to cardholder";
                        break;
                    case "58":
                        value = "Transaction not permitted on terminal";
                        break;
                    case "59":
                        value = "Suspected fraud";
                        break;
                    case "60":
                        value = "Contact acquirer";
                        break;
                    case "61":
                        value = "Exceeds withdrawal limit";
                        break;
                    case "62":
                        value = "Restricted card";
                        break;
                    case "63":
                        value = "Security violation";
                        break;
                    case "64":
                        value = "Original amount incorrect";
                        break;
                    case "65":
                        value = "Exceeds withdrawal frequency";
                        break;
                    case "66":
                        value = "Call acquirer security";
                        break;
                    case "67":
                        value = "Hard capture";
                        break;
                    case "68":
                        value = "Response received too late";
                        break;
                    // 69 to 74 not found
                    case "75":
                        value = "PIN tries exceeded";
                        break;
                    case "76":
                        value = "Intervene bank approval required";
                        break;
                    case "77":
                        value = "Intervene bank approval required";
                        break;
                    case "78":
                        value = "Intervene bank approval required for partial amount";
                        break;
                    // 79 to 89 not found
                    case "90":
                        value = "Cut-off in progress";
                        break;
                    case "91":
                        value = "Issuer or switch inoperative";
                        break;
                    case "92":
                        value = "Routing error";
                        break;
                    case "93":
                        value = "Violation of law";
                        break;
                    case "94":
                        value = "Duplicate transaction";
                        break;
                    case "95":
                        value = "Reconcile error";
                        break;
                    case "96":
                        value = "System malfunction";
                        break;
                    // 97 not found
                    case "98":
                        value = "Exceeds cash limit";
                        break;
                    case "EB":
                        value = "Check Digit Error";
                        break;
                    default:
                        value = "Responsed Code not found!!!☺";
                        break;
                }
                return value;
            }
        }
    }
}