using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace GlobalLogger
{
    public static class GLogger
    {
        public static void LogError(Exception error)
        {
            GExceptionResult er;
            GlobalLogParameter log;
            string logValue, eLogValue;

            er = GetExceptionResult(error, 1) ?? new GExceptionResult();
            logValue = JsonConvert.SerializeObject(er);
            eLogValue = string.Empty;

            log = new GlobalLogParameter
            {
                LogTypeId = 3,
                CorpId = 1,
                CompanyId = 2,
                ProjectId = 20,
                Identifier = null,
                LogValue = logValue
            };

            GLogger.InsertLog(log);
        }

        private static GExceptionResult GetExceptionResult(Exception ex, int level)
        {
            GExceptionResult result;
            string mgs;

            if (ex != null)
            {
                mgs = level == 1 ? "Exception" : "InnerException";

                mgs = ex is SqlException
                           ? ((SqlException)(ex)).Procedure
                           : mgs;

                result = new GExceptionResult
                {
                    Code = level,
                    Message = mgs,
                    MethodName = GLogger.GetMethod(ex),
                    MessageException = ex.Message,
                    InnerException = GLogger.GetExceptionResult(ex.InnerException, level++),
                    StackTraceException = ex.StackTrace,
                    TypeException = ex.GetType().FullName
                };
            }
            else
                result = null;

            return
                result;
        }

        private static string GetMethod(Exception ex)
        {
            string methodName;
            Assembly thisAsse;
            StackTrace st;
            StackFrame[] sfs;
            MethodBase mb;

            methodName = string.Empty;

            try
            {
                thisAsse = Assembly.GetExecutingAssembly();
                st = new StackTrace(ex);
                sfs = st.GetFrames();

                if (sfs != null)
                {
                    mb = sfs.Select(f => f.GetMethod()).FirstOrDefault(m => m.Module.Assembly == thisAsse);
                    methodName = mb != null ? mb.Name : sfs[0].GetMethod().Name;
                }
            }
            catch (Exception)
            {

            }

            return
                methodName;
        }

        private static DataTable InsertLog(GlobalLogParameter parameter)
        {
            string query;
            SqlDataAdapter dataAdapter;
            DataTable dT;
            SqlCommand command;
            SqlConnection connection;
            string identifier;

            query = "exec [Global].[SP_INSERT_GS_LOG] @Log_Type_Id,@Corp_Id,@Company_Id,@Project_Id,@Identifier,@Log_Value;";
            //connection = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["GlobalLogger"]].ConnectionString);
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["GlobalLogger"].ConnectionString);
            command = new SqlCommand(query, connection);
            dT = new DataTable();
            identifier = string.Empty;
            identifier = Guid.NewGuid().ToString();

            command.Parameters.Add(new SqlParameter("@Log_Type_Id", parameter.LogTypeId));
            command.Parameters.Add(new SqlParameter("@Corp_Id", parameter.CorpId));
            command.Parameters.Add(new SqlParameter("@Company_Id", parameter.CompanyId));
            command.Parameters.Add(new SqlParameter("@Project_Id", parameter.ProjectId));
            command.Parameters.Add(new SqlParameter("@Identifier", identifier));
            command.Parameters.Add(new SqlParameter("@Log_Value", parameter.LogValue));

            try
            {
                dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dT);
            }
            catch (Exception)
            {
            }
            finally
            {
                try
                {
                    if (connection != null)
                    {
                        if (connection.State != ConnectionState.Closed)
                            connection.Close();
                    }
                }
                catch (Exception)
                {
                }
            }

            return
                dT;
        }
    }

    public class GExceptionResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string MethodName { get; set; }
        public string MessageException { get; set; }
        public GExceptionResult InnerException { get; set; }
        public string StackTraceException { get; set; }
        public string TypeException { get; set; }
    }
    public class GlobalLogParameter
    {
        public int LogTypeId { get; set; }
        public int? CorpId { get; set; }
        public int? CompanyId { get; set; }
        public int? ProjectId { get; set; }
        public Guid? Identifier { get; set; }
        public string LogValue { get; set; }
    }
}