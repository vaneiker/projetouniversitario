using STL.POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STL.POS.THProxy
{

    public delegate int GetProjectId();

    public interface ITHProxy
    {
        GetProjectId GetThProjectId { get; set; }
        Tuple<byte[], byte[]> GetMarbeteExecutePreview(Quotation quotation, string userDefault = "", string agentFullName = "", int codRamo = 106);
        int GetMarbete(Quotation quotation, string userDefault = "", int codRamo = 106);
        int SendMarbeteByMail(Quotation quotation, List<string> destinationAddresses, string userDefault = "10562", string agentFullName = "", int codRamo = 106);
        int SendQuotationCompletedAndPaid(Quotation quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal=true);
        int SendQuotationCompletedButPaidCancelled(Quotation quotation, int codRamo = 106,IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal=true);
        int SendQuotationInspectionPending(Quotation quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        int SendNewUserCreated(string username, string fullname, string userEmail, string link);
        int SendForgetPassword(string username, string fullname, string userEmail, string link);
        int SendQuotation15DaysWarning(Quotation quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        int SendQuotation5DaysWarning(Quotation quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        int SendQuotationByMail(Quotation quotation, List<string> destinationAddresses, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        int SendDetailedAutoQuotation(QuotationAuto quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        Tuple<int, byte[]> SendDetailedAutoQuotationOnSave(QuotationAuto quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        byte[] SendDetailedAutoQuotationPreview(QuotationAuto quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true);
        string GetBatchJobStatus(int bjId);
        byte[] GenerateXMLContratoKSI(QuotationAuto quotation, List<Amortization> thisAmortizationTable, bool EsContrato, Person ContactData, double financingAmount, string ContactFullAdress, int periodo);
    }
}
