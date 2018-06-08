using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using WebServiceInternal;
using CLR_WS_TH.DLL;

/// <summary>
/// CLR Comunication with THunderHead
/// </summary>
public partial class WSTHUNDERHEAD
{    /// <summary>
    /// Generic Method for Send Template for Thunderhead
    /// </summary>
    /// <param name="XmlTransaction">String XML</param>
    /// <param name="XmlMembers">String XML</param>
    /// <param name="XmlDeducibleData">String XML</param>
    /// <param name="XmlRecipients">String XML</param>
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SP_CALL_TH(String XmlTransaction, String XmlPaquete, int TipoTransaction, String XmlContabilidad = null, String XmlSupervisor = null, String XmlReclamo = null
//,int? NumQuery,int? Corp_Id,int? Trans_Type_Id ,int? TH_Transaction_Code	
//,String Policy_No				
//,int? Quotation_No,int? Item_No ,DateTime? Policy_Effective_Date		
//,DateTime? Trans_Date ,int? Trans_Status_Id,
//        int? Create_Userid,int? SecuenciaMov,bool? Status
       
        )
    {
        //try
        //{
        //    THProxy _proxy = new THProxy();

        //    var d = _proxy.Send_Plexis_Template(XmlTransaction, XmlPaquete, TipoTransaction, XmlContabilidad, XmlSupervisor, XmlReclamo);
        //    SqlPipe sp = SqlContext.Pipe;
        //    SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
        //    record.SetInt32(0, d);

        //    //Send Result Set
        //    SqlContext.Pipe.SendResultsStart(record);
        //    SqlContext.Pipe.SendResultsRow(record);
        //    SqlContext.Pipe.SendResultsEnd();

        //    //Int32 _value = 0;
        //    //Int32.TryParse(d.ToString(), out _value);

        //    //using (SqlConnection connection = new SqlConnection("context connection=true"))
        //    //{
        //    //    string Template_Params = "<AUTO_SYSFLEX>" + XmlTransaction + XmlPaquete + "</AUTO_SYSFLEX>";
     
        //    //    SqlCommand cmd = connection.CreateCommand();
        //    //    cmd.CommandText = "[Transaction_Control].[SET_TRANSACTION]";
        //    //    cmd.CommandType = CommandType.StoredProcedure;
        //    //    cmd.Parameters.AddWithValue("@NumQuery", SqlDbType.Int).Value = NumQuery ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Corp_Id", SqlDbType.Int).Value = Corp_Id ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Trans_Type_Id", SqlDbType.Int).Value = Trans_Type_Id ?? 0;
        //    //    cmd.Parameters.AddWithValue("@TH_Transaction_Code", SqlDbType.Int).Value = _value ;
        //    //    cmd.Parameters.AddWithValue("@Policy_No", SqlDbType.VarChar).Value = Policy_No ?? "";
        //    //    cmd.Parameters.AddWithValue("@Quotation_No", SqlDbType.BigInt).Value = Quotation_No ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Item_No", SqlDbType.Int).Value = Item_No ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Policy_Effective_Date", SqlDbType.DateTime).Value = Policy_Effective_Date;
        //    //    cmd.Parameters.AddWithValue("@Template_Params", SqlDbType.NVarChar).Value = Template_Params ?? "";
        //    //    cmd.Parameters.AddWithValue("@Trans_Date", SqlDbType.DateTime).Value = Trans_Date ?? DateTime.Now;
        //    //    cmd.Parameters.AddWithValue("@Trans_Status_Id", SqlDbType.Int).Value = Trans_Status_Id ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Create_Userid", SqlDbType.Int).Value = Create_Userid ?? 0;
        //    //    cmd.Parameters.AddWithValue("@SecuenciaMov", SqlDbType.Int).Value = SecuenciaMov ?? 0;
        //    //    cmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = Status ?? true;
        //    //    connection.Open();
        //    //    cmd.ExecuteNonQuery();
        //    //    connection.Close();


        //    //    //  SqlPipe sp = SqlContext.Pipe;
        //    //    // SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
        //    //    // record.SetInt32(0, d);

        //    //    //Send Result Set
        //    //    //SqlContext.Pipe.SendResultsStart(record);
        //    //    //SqlContext.Pipe.SendResultsRow(record);
        //    //    //SqlContext.Pipe.SendResultsEnd();

        //    //}


   
        //}
    
        //catch (Exception ex)
        //{

        //    //using (SqlConnection connection = new SqlConnection("context connection=true"))
        //    //{
                
        //    //    connection.Open();
        //    //    string sql =  "INSERT INTO Exceptions(Description,Transactiion,CreatedDate) VALUES(@param1,@param2,@param3)";
        //    //    SqlCommand cmd = new SqlCommand(sql, connection);
        //    //    cmd.Parameters.Add("@param1", SqlDbType.VarChar).Value = ex.ToString() ?? string.Empty;
        //    //    cmd.Parameters.Add("@param2", SqlDbType.Int).Value = Trans_Type_Id ?? 0;
        //    //    cmd.Parameters.Add("@param3", SqlDbType.DateTime).Value = DateTime.Now;
        //    //    cmd.CommandType = CommandType.Text;
        //    //    cmd.ExecuteNonQuery();
                
        //    //      SqlPipe sp = SqlContext.Pipe;
        //    //     SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
        //    //     record.SetInt32(0, d);

        //    //    Send Result Set
        //    //    SqlContext.Pipe.SendResultsStart(record);
        //    //    SqlContext.Pipe.SendResultsRow(record);
        //    //    SqlContext.Pipe.SendResultsEnd();

        //    //}


        //    SqlPipe sp = SqlContext.Pipe;
        //    sp.Send(ex.ToString());
        //    sp.Send(ex.InnerException.Message.ToString());
        //    sp.Send(ex.Message.ToString());
        //    sp.Send(ex.Source.ToString());

        //}
    }




    ///// <summary>
    ///// Send Welcome Template for Thunderhead
    ///// </summary>
    ///// <param name="FullName">String</param>
    ///// <param name="Mail">String</param>
    ///// <param name="PolicyNumber">String</param>
    ///// <param name="PolicyType">String</param>
    ///// <param name="Intermediary">String</param>
    ///// <param name="Country">String</param>
    ///// <returns>TransactionID</returns>
    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void SP_SEND_WELCOME(String FullName
    //                                 , String Mail
    //                                 , String PolicyNumber
    //                                 , String PolicyType
    //                                 , String Intermediary
    //                                 , String Country
    //                                 , String Plan
    //                                 , DateTime StartDateOfCoverage
    //                                 , DateTime EndDateOfCoverage
    //                                 , String ContractType
    //                                 , String ProductLine
    //                                 , String Product
    //                                 , String Address
    //                                 , String ProviderNetwork
    //                                 , String PolicyStatus
    //                                 , String Username
    //                                 , DateTime DoB
    //                                 , String Sex
    //                                 , String SelectionDeductible
    //                                 , Int32 RelationshipToApplicantID
    //                                 , String RelationshipToApplicant
    //                                 , String FamiliarityWithOwner
    //                                 , Decimal AmountPrima
    //                                 , Decimal MaximaSumInsured
    //                                 , Decimal Deductible
    //                                 , String CivilStatus
    //                                 , Int32 Smoker
    //                                 , Int32 FullTimeStudent
    //                                 , Int32 PreExistingCondition
    //                                 , String OftenOfPay
    //                                 , Decimal ValueOfSuplement
    //                                 //DeductibleData
    //                                 , Decimal AmountDeductibleSelection
    //                                 , String AnnualDeductibleOption
    //                                )
    //{
    //    try
    //    {
    //        THProxy _proxy = new THProxy();

    //        var d = _proxy.Send_Plexis_Welcome(FullName
    //                                         , Mail
    //                                         , PolicyNumber
    //                                         , PolicyType
    //                                         , Intermediary
    //                                         , Country
    //                                         , Plan
    //                                         , StartDateOfCoverage
    //                                         , EndDateOfCoverage
    //                                         , ContractType
    //                                         , ProductLine
    //                                         , Product
    //                                         , Address
    //                                         , ProviderNetwork
    //                                         , PolicyStatus
    //                                         , Username
    //                                         , DoB
    //                                         , Sex
    //                                         , SelectionDeductible
    //                                         , RelationshipToApplicantID
    //                                         , RelationshipToApplicant
    //                                         , FamiliarityWithOwner
    //                                         , AmountPrima
    //                                         , MaximaSumInsured
    //                                         , Deductible
    //                                         , CivilStatus
    //                                         , Smoker
    //                                         , FullTimeStudent
    //                                         , PreExistingCondition
    //                                         , OftenOfPay
    //                                         , ValueOfSuplement
    //                                         //DeductibleData
    //                                         , AmountDeductibleSelection
    //                                         , AnnualDeductibleOption
    //                                         );

    //        SqlPipe sp = SqlContext.Pipe;
    //        SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
    //        record.SetInt32(0, d);
            
    //        //Send Result Set
    //        SqlContext.Pipe.SendResultsStart(record);
    //        SqlContext.Pipe.SendResultsRow(record);
    //        SqlContext.Pipe.SendResultsEnd();

    //    }
    //    catch (Exception ex)
    //    {
    //        SqlPipe sp = SqlContext.Pipe;
    //        sp.Send(ex.ToString());
    //        sp.Send(ex.InnerException.Message.ToString());
    //        sp.Send(ex.Message.ToString());
    //        sp.Send(ex.Source.ToString());
    //    }
    //}

    ///// <summary>
    ///// Send Card Issuance Template for Thunderhead
    ///// </summary>
    ///// <param name="FullName">String</param>
    ///// <param name="Mail">String</param>
    ///// <param name="PolicyNumber">String</param>
    ///// <param name="PolicyType">String</param>
    ///// <param name="Product">String</param>
    ///// <param name="StartDateOfCoverage">DateTime</param>
    ///// <param name="EndDateOfCoverage">DateTime</param>
    ///// <returns>TransactionID</returns>
    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void SP_CARD_EMISION(String FullName, String Mail, String PolicyNumber, String PolicyType, String Product, DateTime StartDateOfCoverage, DateTime EndDateOfCoverage)
    //{
    //    try
    //    {
    //        THProxy _proxy = new THProxy();
    //        var d = _proxy.Send_Plexis_CardIssuance(FullName
    //                                                , Mail
    //                                                , PolicyNumber
    //                                                , PolicyType
    //                                                , Product
    //                                                , StartDateOfCoverage
    //                                                , EndDateOfCoverage);

    //        SqlPipe sp = SqlContext.Pipe;
    //        SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
    //        record.SetInt32(0, d);
    //        //Send Result Set
    //        SqlContext.Pipe.SendResultsStart(record);
    //        SqlContext.Pipe.SendResultsRow(record);
    //        SqlContext.Pipe.SendResultsEnd();
    //    }
    //    catch (Exception ex)
    //    {
    //        SqlPipe sp = SqlContext.Pipe;
    //        sp.Send(ex.ToString());
    //        sp.Send(ex.InnerException.Message.ToString());
    //        sp.Send(ex.Message.ToString());
    //        sp.Send(ex.Source.ToString());
    //    }
    //}

    ///// <summary>
    ///// Send Information Exception Template for Thunderhead
    ///// </summary>
    ///// <param name="FullName">String</param>
    ///// <param name="Mail">String</param>
    ///// <param name="PolicyNumber">String</param>
    ///// <param name="PolicyType">String</param>
    ///// <param name="Product">String</param>
    ///// <param name="StartDateOfCoverage">DateTime</param>
    ///// <param name="EndDateOfCoverage">DateTime</param>
    ///// <returns>TransationId</returns>
    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void SP_INFO_EXCEPCION(String FullName, String Mail, String PolicyNumber, String PolicyType, String Product, DateTime StartDateOfCoverage, DateTime EndDateOfCoverage)
    //{
    //    try
    //    {
    //        THProxy _proxy = new THProxy();

    //        var d = _proxy.Send_Plexis_InfoExcep(FullName
    //                                            , Mail
    //                                            , PolicyNumber
    //                                            , PolicyType
    //                                            , Product
    //                                            , StartDateOfCoverage
    //                                            , EndDateOfCoverage);

    //        SqlPipe sp = SqlContext.Pipe;
    //        SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
    //        record.SetInt32(0, d);
    //        //Send Result Set
    //        SqlContext.Pipe.SendResultsStart(record);
    //        SqlContext.Pipe.SendResultsRow(record);
    //        SqlContext.Pipe.SendResultsEnd();
    //    }
    //    catch (Exception ex)
    //    {
    //        SqlPipe sp = SqlContext.Pipe;
    //        sp.Send(ex.ToString());
    //        sp.Send(ex.InnerException.Message.ToString());
    //        sp.Send(ex.Message.ToString());
    //        sp.Send(ex.Source.ToString());
    //    }
    //}

    ///// <summary>
    ///// Send Duplicated Card Template for Thunderhead
    ///// </summary>
    ///// <param name="FullName">String</param>
    ///// <param name="Mail">String</param>
    ///// <param name="PolicyNumber">String</param>
    ///// <param name="PolicyType">String</param>
    ///// <param name="StartDateOfCoverage">DateTime</param>
    ///// <param name="EndDateOfCoverage">DateTime</param>
    ///// <returns>TransactionID</returns>
    //[Microsoft.SqlServer.Server.SqlProcedure]
    //public static void SP_CARD_DUPLICATE(String FullName, String Mail, String PolicyNumber, String PolicyType, DateTime StartDateOfCoverage, DateTime EndDateOfCoverage)
    //{
    //    try
    //    {
    //        THProxy _proxy = new THProxy();
    //        var d = _proxy.Send_Plexis_Duplicated_Card(FullName
    //                                            , Mail
    //                                            , PolicyNumber
    //                                            , PolicyType
    //                                            , StartDateOfCoverage
    //                                            , EndDateOfCoverage);

    //        SqlPipe sp = SqlContext.Pipe;
    //        SqlDataRecord record = new SqlDataRecord(new SqlMetaData("TransactionId", SqlDbType.Int));
    //        record.SetInt32(0, d);
    //        //Send Result Set
    //        SqlContext.Pipe.SendResultsStart(record);
    //        SqlContext.Pipe.SendResultsRow(record);
    //        SqlContext.Pipe.SendResultsEnd();
    //    }
    //    catch (Exception ex)
    //    {
    //        SqlPipe sp = SqlContext.Pipe;
    //        sp.Send(ex.ToString());
    //        sp.Send(ex.InnerException.Message.ToString());
    //        sp.Send(ex.Message.ToString());
    //        sp.Send(ex.Source.ToString());
    //    }
    //}

};
