using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WEB.ConfirmationCall.Common
{
    public class UsersAsigne
    {
        
        public static void addUsersAsigned(int Corp_Id, int Region_Id, int Country_Id, int Domesticreg_Id, int State_Prov_Id, int City_Id,
            int Office_Id, int Case_Seq_No, int Hist_Seq_No, int Create_UsrId, byte Select_Case, string HostName, string Action)
        {

            using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AsignedUser"].ConnectionString))
            {
                if (oConnection.State != ConnectionState.Open)
                {
                    oConnection.Open();
                }
                using (SqlCommand oCommand = new SqlCommand())
                {

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Connection = oConnection;
                    oCommand.CommandText = "[Underwriting].[SP_SET_UW_USERS_ASIGNED]";

                    oCommand.Parameters.Add(new SqlParameter("@Corp_Id", Corp_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Region_Id", Region_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Country_Id", Country_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Domesticreg_Id", Domesticreg_Id));
                    oCommand.Parameters.Add(new SqlParameter("@State_Prov_Id", State_Prov_Id));
                    oCommand.Parameters.Add(new SqlParameter("@City_Id", City_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Office_Id", Office_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Case_Seq_No", Case_Seq_No));
                    oCommand.Parameters.Add(new SqlParameter("@Hist_Seq_No", Hist_Seq_No));
                    oCommand.Parameters.Add(new SqlParameter("@Create_UsrId", Create_UsrId));
                    oCommand.Parameters.Add(new SqlParameter("@Select_Case", Select_Case));
                    oCommand.Parameters.Add(new SqlParameter("@HostName", HostName));
                    oCommand.Parameters.Add(new SqlParameter("@Action", Action));

                    oCommand.ExecuteNonQuery();

                }

            }

        }
        //
        public static int isUsersAsigned(int Corp_Id, int Region_Id, int Country_Id, int Domesticreg_Id, int State_Prov_Id, int City_Id,
          int Office_Id, int Case_Seq_No, int Hist_Seq_No,int Create_UsrId)
        {
           int rs = 0;
            using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AsignedUser"].ConnectionString))
            {
                if (oConnection.State != ConnectionState.Open)
                {
                    oConnection.Open();
                }
                using (SqlCommand oCommand = new SqlCommand())
                {

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Connection = oConnection;
                    oCommand.CommandText = "[Underwriting].[SP_GET_UW_USERS_ASIGNED]";

                    oCommand.Parameters.Add(new SqlParameter("@Corp_Id", Corp_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Region_Id", Region_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Country_Id", Country_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Domesticreg_Id", Domesticreg_Id));
                    oCommand.Parameters.Add(new SqlParameter("@State_Prov_Id", State_Prov_Id));
                    oCommand.Parameters.Add(new SqlParameter("@City_Id", City_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Office_Id", Office_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Case_Seq_No", Case_Seq_No));                   
                     oCommand.Parameters.Add(new SqlParameter("@Hist_Seq_No", Hist_Seq_No));
                     oCommand.Parameters.Add(new SqlParameter("@Create_UsrId", Create_UsrId));
                    
                  
                    object oObject =  oCommand.ExecuteScalar();

                   rs = Convert.ToInt32(oObject);

                }

            }
            return rs;

        }
        //
        public static int GetUsersAsignedHours(int Corp_Id, int Region_Id, int Country_Id, int Domesticreg_Id, int State_Prov_Id, int City_Id,
        int Office_Id, int Case_Seq_No, int Hist_Seq_No, int Create_UsrId)
        {
            int rs = 0;
            using (SqlConnection oConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AsignedUser"].ConnectionString))
            {
                if (oConnection.State != ConnectionState.Open)
                {
                    oConnection.Open();
                }
                using (SqlCommand oCommand = new SqlCommand())
                {

                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.Connection = oConnection;
                    oCommand.CommandText = "[Underwriting].[SP_GET_UW_USERS_ASIGNED_HOURS]";

                    oCommand.Parameters.Add(new SqlParameter("@Corp_Id", Corp_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Region_Id", Region_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Country_Id", Country_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Domesticreg_Id", Domesticreg_Id));
                    oCommand.Parameters.Add(new SqlParameter("@State_Prov_Id", State_Prov_Id));
                    oCommand.Parameters.Add(new SqlParameter("@City_Id", City_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Office_Id", Office_Id));
                    oCommand.Parameters.Add(new SqlParameter("@Case_Seq_No", Case_Seq_No));
                    oCommand.Parameters.Add(new SqlParameter("@Hist_Seq_No", Hist_Seq_No));
                    oCommand.Parameters.Add(new SqlParameter("@Create_UsrId", Create_UsrId));


                    object oObject = oCommand.ExecuteScalar();

                    rs = Convert.ToInt32(oObject);

                }

            }
            return rs;

        }
        //

    }
}