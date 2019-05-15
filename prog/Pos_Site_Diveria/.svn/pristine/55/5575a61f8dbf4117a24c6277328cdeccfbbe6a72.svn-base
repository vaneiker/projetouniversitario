using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entities
{
    public class Cardnet
    {
        public class RequestModel
        {
            private string CreateMD5(string input)
            {

                // Use input string to calculate MD5 hash
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }

            public string TransactionType { get; set; }
            public string CurrencyCode { get; set; }
            public string AcquiringInstitutionCode { get; set; }
            public string MerchantType { get; set; }
            public string MerchantNumber { get; set; }
            public string MerchantNumber_amex { get; set; }
            public string MerchantTerminal { get; set; }
            public string MerchantTerminal_amex { get; set; }
            public string ReturnUrl { get; set; }
            public string CancelUrl { get; set; }
            public string PageLanguaje { get; set; }
            public string OrdenId { get; set; }
            public string TransactionId { get; set; }
            public string Amount { get; set; }
            public string Tax { get; set; }
            public string MerchantName { get; set; }

            public string Ipclient { get; set; }

            public string KeyEncriptionKey
            {
                get
                {
                    //MerchantType
                    //MerchantNumber
                    //MerchantTerminal
                    //TransactionId
                    //Amount
                    //Tax
                    if (!string.IsNullOrEmpty(this.MerchantType)
                        && !string.IsNullOrEmpty(this.MerchantNumber)
                        && !string.IsNullOrEmpty(this.MerchantTerminal)
                        && !string.IsNullOrEmpty(this.TransactionId)
                        && !string.IsNullOrEmpty(this.Amount)
                        && !string.IsNullOrEmpty(this.Tax))
                    {
                        var str = this.MerchantType
                            + this.MerchantNumber
                            + this.MerchantTerminal
                            + this.TransactionId
                            + this.Amount
                            + this.Tax;

                        var output = CreateMD5(str.ToLower());
                        return output.ToLower();
                    }
                    else
                        throw new InvalidOperationException("El modelo no tiene todos los parámetros necesarios cargados para generar el KeyTransactionKey.");

                }
            }

            public string CardnetUrl { get; set; }

        }

        public class ResponseModel
        {
            public string Id { get; set; }
            public string CreditCardNumber { get; set; }
            public string ResponseCode { get; set; }
            public string AuthorizationCode { get; set; }
            public string RetrivalReferenceNumber { get; set; }
            public string OrdenId { get; set; }
            public string TransactionId { get; set; }

            public string ResponseMsg
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
}
