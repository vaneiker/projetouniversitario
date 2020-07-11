﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STL.POS.Data;
using System.Xml.Serialization;
using System.IO;
using STL.POS.THProxy.THWebService;
using System.Configuration;
using Microsoft.Web.Services3.Design;
using System.Timers;
using System.Threading;
using STL.POS.WsProxy;
using STL.POS.WsProxy.SysflexService;
using System.Globalization;
using STL.POS.Data.CSEntities;


namespace STL.POS.THProxy
{
    public class THProxy : ITHProxy
    {
        private THSecurityAssertion securityToken;
        private JobAPIWebService webClient;

        private NewTHService.WCFServiceClient thServicesClient;
        private NewTHService.THParams tHParams;


        private const int ID_DOCUMENT_CAMBIO_DE_CONTRASENIA = 1335501224;
        private const int ID_DOCUMENT_COTIZACION_ACEPTADA = 1335501036;
        private const int ID_DOCUMENT_COTIZACION_NO_COMPLETADA = 1335501038;
        private const int ID_DOCUMENT_COTIZACION_PENDIENTE_INSPECCION = 1335501039;
        private const int ID_DOCUMENT_COTIZACION_PROXIMA_A_VENCER_15_DIAS = 1335501037;
        private const int ID_DOCUMENT_COTIZACION_PROXIMA_A_VENCER_5_DIAS = 1335501041;
        private const int ID_DOCUMENT_ENVIO_CONTRASENIA = 1335501028;
        private const int ID_DOCUMENT_COTIZACION_ENVIADA_EMAIL = 1335501268;
        private const int ID_DOCUMENT_RESUMEN_COTIZACION = 1335501365;
        private const int ID_DOCUMENT_RESUMEN_COTIZACION_GUARDADA = 1335501365;
        private const int ID_DOCUMENT_MARBETE = 1335501793;
        private const int ID_DOCUMENT_MARBETE_ENVIADA_EMAIL = 1335501987;

        private const int ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4 = 1335504116;

        public const string BATCH_RESULT_QueuedForParsing = "p";
        public const string BATCH_RESULT_Parsing = "P";
        public const string BATCH_RESULT_DocumentProduction = "D";
        public const string BATCH_RESULT_Stored = "H";
        public const string BATCH_RESULT_ProcessingCompleted = "C";
        public const string BATCH_RESULT_Finished = "F";
        public const string BATCH_RESULT_SentForReview = "W";
        public const string BATCH_RESULT_Stopped = "S";
        public const string BATCH_RESULT_Errored = "E";

        private const double GET_REPORT_TIMEOUT_MS = 60000;
        private const int GET_BATCH_STATUS_TIMEOUT_MS = 500;
        private const int CREATE_MARBETE_PDF_MS = 5000;

        public GetProjectId GetThProjectId
        {
            get;
            set;
        }

        public THProxy()
        {
            webClient = new JobAPIWebService();
            var user = ConfigurationManager.AppSettings["ThUsername"];
            var pass = ConfigurationManager.AppSettings["ThPassword"];

            //webClient.Timeout = 300000;//en milisegundos

            securityToken = new THSecurityAssertion(user, pass);

            webClient.SetPolicy(new Policy(securityToken));

            
            thServicesClient = new NewTHService.WCFServiceClient();
            tHParams = new NewTHService.THParams();
            tHParams.user = ConfigurationManager.AppSettings["ThUsername"];
            tHParams.password = ConfigurationManager.AppSettings["ThPassword"];
            
        }

        private byte[] SerializeToXml(POS_AUTO transaction, bool writeToFile = false)
        {
            XmlSerializer serial = new XmlSerializer(typeof(POS_AUTO));
            var stream = new MemoryStream();

            serial.Serialize(stream, transaction);

            var stReader = new StreamReader(stream);
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName()) + ".xml";

            if (writeToFile)
            {
                stream.Position = 0;
                var fileStream = new FileStream(file, FileMode.OpenOrCreate);
                var stWriter = new StreamWriter(fileStream);
                stWriter.Write(stReader.ReadToEnd());
                stWriter.Flush();
                stWriter.Close();
            }

            stream.Position = 0;

            var buffer = stream.ToArray();

            return buffer;
        }

        private byte[] SerializeToXml2(STL.POS.THProxy.Schemas.POS_AUTO transaction, bool writeToFile = false)
        {
            XmlSerializer serial = new XmlSerializer(typeof(STL.POS.THProxy.Schemas.POS_AUTO));
            var stream = new MemoryStream();

            serial.Serialize(stream, transaction);

            var stReader = new StreamReader(stream);
            var file = Path.Combine(Path.GetTempPath(), Path.GetTempFileName()) + ".xml";

            if (writeToFile)
            {
                stream.Position = 0;
                var fileStream = new FileStream(file, FileMode.OpenOrCreate);
                var stWriter = new StreamWriter(fileStream);
                stWriter.Write(stReader.ReadToEnd());
                stWriter.Flush();
                stWriter.Close();
            }

            stream.Position = 0;

            var buffer = stream.ToArray();

            return buffer;
        }
        public int SendNewUserCreated(string username, string fullname, string userEmail, string link)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Transaction.DocumentId = ID_DOCUMENT_ENVIO_CONTRASENIA;
            transaction.Transaction.Fullname = fullname;
            transaction.Transaction.Url = link;
            transaction.Transaction.UserEmail = userEmail;
            transaction.Transaction.Username = username;

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);
        }

        public int SendForgetPassword(string username, string fullname, string userEmail, string link)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Transaction.DocumentId = ID_DOCUMENT_CAMBIO_DE_CONTRASENIA;
            transaction.Transaction.Fullname = fullname;
            transaction.Transaction.Url = link;
            transaction.Transaction.UserEmail = userEmail;
            transaction.Transaction.Username = username;

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);

        }

        public int SendQuotationCompletedAndPaid(Quotation quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_ACEPTADA;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();
            transaction.Transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            LoadQuotationDetail(quotation, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            transaction.Quotation.LineOfBusiness = "AUTO"; // "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);
        }

        public Tuple<byte[], byte[]> GetMarbeteExecutePreview(Quotation quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106)
        {
            byte[] result;

            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_MARBETE;
            //transaction.Transaction.Fullname = quotation.PrincipalFullName; //ORIGINAL 06-10-2016
            //transaction.Transaction.Username = quotation.User != null ? quotation.User.GetFullName() : userDefault;

            transaction.Transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();
            transaction.Transaction.NoPoliza = quotation.PolicyNumber;
            if (quotation.StartDate.HasValue)
                transaction.Transaction.FechaInicio = quotation.StartDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt");

            if (quotation.EndDate.HasValue)
            {
                //transaction.Transaction.FechaVencimiento = quotation.EndDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt"); //ORIGINA 17-10-2016 JHEIRON DOTEL
                transaction.Transaction.FechaVencimiento = quotation.StartDate.Value.AddDays(90).Date.ToString("dd-MMM-yyyy hh:mm:ss tt");
            }

            LoadQuotationDetail(quotation, transaction, codRamo, null, true);

            transaction.Quotation.LineOfBusiness = "AUTO";//  "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            result = SendToTHExecutePreview(transaction, buffer, 0, 0);

            Thread.Sleep(CREATE_MARBETE_PDF_MS);

            return new Tuple<byte[], byte[]>(result, buffer);
        }

        public int GetMarbete(Quotation quotation, string userDefault = "10562", int codRamo = 106)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_MARBETE;
            //transaction.Transaction.Fullname = quotation.PrincipalFullName; //ORIGINAL 06-10-2016
            transaction.Transaction.Username = quotation.User != null ? quotation.User.GetFullName() : userDefault;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();
            transaction.Transaction.NoPoliza = quotation.PolicyNumber;
            if (quotation.StartDate.HasValue)
                transaction.Transaction.FechaInicio = quotation.StartDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt");

            if (quotation.EndDate.HasValue)
                transaction.Transaction.FechaVencimiento = quotation.EndDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt");

            LoadQuotationDetail(quotation, transaction, codRamo, null, false);

            transaction.Quotation.LineOfBusiness = "AUTO";//  "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            int result = SendToTH(transaction, buffer);
            Thread.Sleep(CREATE_MARBETE_PDF_MS);

            return result;
        }

        public int SendMarbeteByMail(Quotation quotation, List<string> destinationAddresses, string userDefault = "10562", string agentFullName = "", int codRamo = 106)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_MARBETE_ENVIADA_EMAIL;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = string.Join(",", destinationAddresses);
            transaction.Transaction.NoPoliza = quotation.PolicyNumber;
            if (quotation.StartDate.HasValue)
                transaction.Transaction.FechaInicio = quotation.StartDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt");

            //if (quotation.EndDate.HasValue)
            //    transaction.Transaction.FechaVencimiento = quotation.EndDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt");

            if (quotation.EndDate.HasValue)
            {
                //transaction.Transaction.FechaVencimiento = quotation.EndDate.Value.ToString("dd-MMM-yyyy hh:mm:ss tt"); //ORIGINA 17-10-2016 JHEIRON DOTEL
                transaction.Transaction.FechaVencimiento = quotation.StartDate.Value.AddDays(90).Date.ToString("dd-MMM-yyyy hh:mm:ss tt");
            }

            transaction.Transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            LoadQuotationDetail(quotation as QuotationAuto, transaction, codRamo, null, false);
            transaction.Quotation.LineOfBusiness = "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.PrincipalName = quotation.PrincipalFullName;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);

        }

        public int SendQuotation15DaysWarning(Quotation quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_PROXIMA_A_VENCER_15_DIAS;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();
            transaction.Transaction.NoPoliza = quotation.PolicyNumber;

            LoadQuotationDetail(quotation, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            transaction.Quotation.LineOfBusiness = "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);
        }

        public int SendQuotation5DaysWarning(Quotation quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_PROXIMA_A_VENCER_5_DIAS;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();

            LoadQuotationDetail(quotation, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            transaction.Quotation.LineOfBusiness = "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);
            return SendToTH(transaction, buffer);
        }

        public int SendQuotationCompletedButPaidCancelled(Quotation quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_NO_COMPLETADA;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();

            LoadQuotationDetail(quotation as QuotationAuto, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            transaction.Quotation.LineOfBusiness = "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.Product = quotation.GetQuotationProduct();


            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);

        }

        public int SendQuotationInspectionPending(Quotation quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_PENDIENTE_INSPECCION;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = quotation.GetPrincipalEmail();

            transaction.Transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            LoadQuotationDetail(quotation as QuotationAuto, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            transaction.Quotation.LineOfBusiness = "AUTO"; // "AUTO";// quotation.BusinessLine.Name; //ORIGINAL 15-08-2017
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction, false);

            return SendToTH(transaction, buffer);

        }

        public int SendQuotationByMail(Quotation quotation, List<string> destinationAddresses, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var transaction = new POS_AUTO();
            transaction.Transaction = new POS_AUTOTransaction();
            transaction.Quotation = new POS_AUTOQuotation();

            transaction.Transaction.DocumentId = ID_DOCUMENT_COTIZACION_ENVIADA_EMAIL;
            transaction.Transaction.Fullname = quotation.PrincipalFullName;
            transaction.Transaction.UserEmail = string.Join(",", destinationAddresses);

            transaction.Transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            LoadQuotationDetail(quotation as QuotationAuto, transaction, codRamo, itemProjectionPayment, IsSaleChannelNormal);
            transaction.Quotation.LineOfBusiness = "AUTO";// quotation.BusinessLine.Name;
            transaction.Quotation.PrincipalName = quotation.PrincipalFullName;
            transaction.Quotation.Product = quotation.GetQuotationProduct();

            var buffer = SerializeToXml(transaction);

            return SendToTH(transaction, buffer);

        }

        public byte[] SendToTHExecutePreview(POS_AUTO transaction, byte[] transactionData, int THProjectID, int THBatchConfigResID)
        {
            byte[] binary = null;

            ExternalJobRequestAPI request = new ExternalJobRequestAPI();

            request.batchName = "IntegracionPuntodeVenta";

            request.projectID = THProjectID;
            request.batchConfigResID = THBatchConfigResID;
            /*
            request.projectID = ConfigurationManager.AppSettings["THProjectID"].toInt();
            request.batchConfigResID = ConfigurationManager.AppSettings["THBatchConfigResID"].toInt();
            */


            //request.projectID = 0;
            //request.batchConfigResID = 1335501240;

            request.batchCollect = 8;
            request.finOption = 0;
            request.jobType = 0;
            request.transactionData = transactionData;
            webClient.Timeout = 1200000;

            var result = webClient.executePreview(request);

            //obtener canal(es) documento(s) generado(s)
            var channelDocuments = result.masterChannels;

            for (int i = 0; i < channelDocuments.Length; i++)
            {
                var doc = channelDocuments[i];
                binary = doc.data;
                String ext = doc.formatString;
                if (ext == "pdf")
                    break;
            }

            return binary;
        }
        private byte[] SendToTHExecutePreview2(STL.POS.THProxy.Schemas.POS_AUTO transaction, byte[] transactionData)
        {
            byte[] binary = null;

            ExternalJobRequestAPI request = new ExternalJobRequestAPI();

            request.batchName = "IntegracionPuntodeVenta";

            if (GetThProjectId != null)
            {
                request.projectID = GetThProjectId();
            }
            else
                request.projectID = 1335500015; //Failsafe

            //#if (DEBUG)
            //            request.projectID = 1335500015;
            //#else
            //                        request.projectID = 0;
            //#endif
            request.batchConfigResID = 1335501240;
            request.batchCollect = 8;
            request.finOption = 0;
            request.jobType = 0;
            request.transactionData = transactionData;

            var result = webClient.executePreview(request);

            //obtener canal(es) documento(s) generado(s)
            var channelDocuments = result.masterChannels;

            for (int i = 0; i < channelDocuments.Length; i++)
            {
                var doc = channelDocuments[i];
                binary = doc.data;
                String ext = doc.formatString;
                if (ext == "pdf")
                    break;
            }

            return binary;
        }

        private int SendToTH(POS_AUTO transaction, byte[] transactionData)
        {
            ExternalJobRequestAPI request = new ExternalJobRequestAPI();

            request.batchName = "IntegracionPuntodeVenta";

            if (GetThProjectId != null)
            {
                request.projectID = GetThProjectId();
            }
            else
            {
                request.projectID = 1335500015; //Failsafe
            }

            request.batchConfigResID = 1335501240;
            request.batchCollect = 8;
            request.finOption = 0;
            request.jobType = 0;
            request.transactionData = transactionData;
            var output = webClient.submitBatch(request);
            return output;
        }

        public int SendToTH_NewPV(byte[] transactionData)
        {
            ExternalJobRequestAPI request = new ExternalJobRequestAPI();

            request.batchName = "IntegracionPuntodeVenta";

            if (GetThProjectId != null)
            {
                request.projectID = GetThProjectId();
            }
            else
            {
                request.projectID = 1335500015; //Failsafe
            }

            request.batchConfigResID = 1335501240;
            request.batchCollect = 8;
            request.finOption = 0;
            request.jobType = 0;
            request.transactionData = transactionData;
            var output = webClient.submitBatch(request);
            return output;
        }

        public string GetBatchJobStatus(int bjId)
        {
            var batchJob = webClient.getBatchJob(bjId);
            return batchJob.batchStatus;
        }

        public Tuple<int, byte[]> SendDetailedAutoQuotationOnSave(QuotationAuto quotation, int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = true)
        {
            var dataObject = new POS_AUTO();
            var transaction = new POS_AUTOTransaction();
            var quotationTH = new POS_AUTOQuotation();
            dataObject.Transaction = transaction;

            /*Forma Anterior de Flotilla 21-07-2017*/
            /*if (quotation.VehicleProducts.Count() > 4)
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;//Para vehiculos mayores a 4
            }
            else
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_GUARDADA;
            }*/

            transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;

            transaction.Fullname = quotation.PrincipalFullName;

            LoadQuotationDetail(quotation, dataObject, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            var buffer = SerializeToXml(dataObject, false);

            var batchJobId = SendToTH(dataObject, buffer);

            return new Tuple<int, byte[]>(batchJobId, buffer);
        }


        /// <summary>
        ///  Este metodo devuelve la cotizacion como un arreglo de bytes
        /// </summary>
        /// <param name="quotation"></param>
        /// <returns></returns>
        public byte[] SendDetailedAutoQuotationPreview(QuotationAuto quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            byte[] result;
            var dataObject = new POS_AUTO();
            var transaction = new POS_AUTOTransaction();
            var quotationTH = new POS_AUTOQuotation();
            dataObject.Transaction = transaction;

            /*Forma Anterior de Flotilla 21-07-2017*/
            var quantityTotalDiferentVehicles = quotation.VehicleProducts.Count();
            var quantityTotalVehicles = quotation.VehicleProducts.Where(x => x.VehicleQuantity > 4);

            var quantityTotalVehiclesDuplicates = quotation.VehicleProducts.Where(x => x.VehicleQuantity > 1);

            if (quantityTotalVehiclesDuplicates != null)
            {
                foreach (var a in quantityTotalVehiclesDuplicates)
                {
                    quantityTotalDiferentVehicles += a.VehicleQuantity.Value;
                };
            }

            if (quantityTotalDiferentVehicles > 4)
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;//Para vehiculos mayores a 4
            }
            else if (quantityTotalVehicles.Count() > 0)
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;//Para vehiculos mayores a 4
            }
            else
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION;
            }

            //transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;


            transaction.Fullname = quotation.PrincipalFullName;
            transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;

            LoadQuotationDetail(quotation, dataObject, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            var buffer = SerializeToXml(dataObject, false);

            result = SendToTHExecutePreview(dataObject, buffer, 0, 0);

            return result;
        }

        public int SendDetailedAutoQuotation(QuotationAuto quotation, string userDefault = "10562", string agentFullName = "", int codRamo = 106, IEnumerable<itemProjectionPayment> itemProjectionPayment = null, bool IsSaleChannelNormal = false)
        {
            var dataObject = new POS_AUTO();
            var transaction = new POS_AUTOTransaction();
            var quotationTH = new POS_AUTOQuotation();
            dataObject.Transaction = transaction;

            /*Forma Anterior de Flotilla 21-07-2017*/
            /*if (quotation.VehicleProducts.Count() > 4)
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;//Para vehiculos mayores a 4
            }
            else
            {
                transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION;
            }*/

            transaction.DocumentId = ID_DOCUMENT_RESUMEN_COTIZACION_MAYOR4;

            transaction.Fullname = quotation.PrincipalFullName;
            transaction.Username = !string.IsNullOrEmpty(agentFullName) ? agentFullName : quotation.User != null ? quotation.User.GetFullName() : userDefault;


            LoadQuotationDetail(quotation, dataObject, codRamo, itemProjectionPayment, IsSaleChannelNormal);

            var buffer = SerializeToXml(dataObject, false);

            var batchJobId = SendToTH(dataObject, buffer);

            var getReportTimer = new System.Timers.Timer(GET_REPORT_TIMEOUT_MS);

            var status = BATCH_RESULT_Parsing;
            getReportTimer.Start();
            while (getReportTimer.Enabled && status != BATCH_RESULT_Finished)
            {
                status = webClient.getBatchJob(batchJobId).batchStatus;
                Thread.Sleep(GET_BATCH_STATUS_TIMEOUT_MS);
            }

            if (status != BATCH_RESULT_Finished)
            {
                if (status != BATCH_RESULT_Errored)
                    throw new TimeoutException("No se ha generado el reporte en tiempo: error de timeout");
                else
                    throw new Exception("Error en la generación del reporte.");
            }

            return batchJobId;
        }

        private static void LoadQuotationDetail(Quotation quotation, POS_AUTO dataObject, int codRamo, IEnumerable<itemProjectionPayment> itemProjectionPayment, bool IsSaleChannelNormal)
        {

            POS_AUTOQuotation quotationTH = new POS_AUTOQuotation();
            dataObject.Quotation = quotationTH;

            //Primera página
            quotationTH.PrincipalName = quotation.PrincipalFullName;
            quotationTH.PrincipalCountry = quotation.GetPrincipal().City.Country.Global_Country_Desc;
            quotationTH.ProposalDate = DateTime.Now;
            quotationTH.ProposalDateSpecified = true;
            quotationTH.Plan = "AUTO";
            quotationTH.IdType = quotation.GetPrincipal().IdentificationType == null ? "" : quotation.GetPrincipal().IdentificationType;
            quotationTH.IdNumber = quotation.GetPrincipal().IdentificationNumber == null ? "" : quotation.GetPrincipal().IdentificationNumber;
            quotationTH.IsSaleChannelNormal = IsSaleChannelNormal ? "true" : "false";
            quotationTH.IsSaleChannelNormalFieldSpecified = true;

            var PaymentOptions = new List<POS_AUTOQuotationPaymentOptions>(0);

            //Pago Unico
            var DataPagoUnico = itemProjectionPayment.FirstOrDefault(x => x.Numero == 1);
            PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            {
                PaymentType = "1",
                PaymentTypeFieldSpecified = true,
                InitialPayment = DataPagoUnico.Inicial.ToString(CultureInfo.InvariantCulture),
                InitialPaymentFieldSpecified = true,
                NextPay = DataPagoUnico.Cuotas,
                NextPayFieldSpecified = true
            });

            //Inicial + 4 Cuotas
            var DataInicialMas4Pagos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 2);
            PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            {
                PaymentType = "2",
                PaymentTypeFieldSpecified = true,
                InitialPayment = DataInicialMas4Pagos.Inicial.ToString(CultureInfo.InvariantCulture),
                InitialPaymentFieldSpecified = true,
                NextPay = DataInicialMas4Pagos.Cuotas,
                NextPayFieldSpecified = true
            });

            //Inicial + 4 Cuotas Automaticas
            var DataInicialMas4PagosAutomaticos = itemProjectionPayment.FirstOrDefault(x => x.Numero == 3);
            PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            {
                PaymentType = "3",
                PaymentTypeFieldSpecified = true,
                InitialPayment = DataInicialMas4PagosAutomaticos.Inicial.ToString(CultureInfo.InvariantCulture),
                InitialPaymentFieldSpecified = true,
                NextPay = DataInicialMas4PagosAutomaticos.Cuotas,
                NextPayFieldSpecified = true

            });

            //Inicial + 11 cuotas financiadas
            var DataFinanced = itemProjectionPayment.FirstOrDefault(x => x.Numero == 4);
            PaymentOptions.Add(new POS_AUTOQuotationPaymentOptions
            {
                PaymentType = "4",
                PaymentTypeFieldSpecified = true,
                InitialPayment = DataFinanced.Inicial.ToString(CultureInfo.InvariantCulture),
                InitialPaymentFieldSpecified = true,
                NextPay = DataFinanced.Cuotas,
                NextPayFieldSpecified = true
            });

            quotationTH.PaymentPaymentOptions = PaymentOptions.ToArray();

            if (!string.IsNullOrEmpty(quotation.GetPrincipal().PhoneNumber))
            {
                quotationTH.TelephoneNumber = quotation.GetPrincipal().PhoneNumber;
            }
            else if (!string.IsNullOrEmpty(quotation.GetPrincipal().Mobile))
            {
                quotationTH.TelephoneNumber = quotation.GetPrincipal().Mobile;
            }
            else if (!string.IsNullOrEmpty(quotation.GetPrincipal().WorkPhone))
            {
                quotationTH.TelephoneNumber = quotation.GetPrincipal().WorkPhone;
            }
            else
            {
                quotationTH.TelephoneNumber = "";
            }

            quotationTH.Email = quotation.GetPrincipal().Email == null ? "" : quotation.GetPrincipal().Email;
            quotationTH.NumberOfPayments = quotation.PaymentFrequencyId;
            quotationTH.NumberOfPaymentsSpecified = true;
            quotationTH.QuotationNumber = quotation.QuotationNumber;
            quotationTH.QuotationDate = quotation.Created;
            quotationTH.QuotationDateSpecified = true;
            quotationTH.NumberOfVehicles = (quotation as QuotationAuto).VehicleProducts.Count;
            quotationTH.StartDate = quotation.StartDate.Value;
            quotationTH.StartDateSpecified = true;
            quotationTH.EndDate = quotation.EndDate.Value;
            quotationTH.EndDateSpecified = true;



            int invoicetypeid = 0;

            //Conductores
            var driversTh = new List<POS_AUTOQuotationDrivers>();
            foreach (var driver in (quotation as QuotationAuto).Drivers)
            {
                var driverTh = new POS_AUTOQuotationDrivers();
                driverTh.BirthDate = driver.DateOfBirth;
                driverTh.BirthDateSpecified = true;
                driverTh.Email = driver.Email;
                driverTh.IdNumber = driver.IdentificationNumber;
                driverTh.IdType = driver.IdentificationType;
                driverTh.Name = driver.GetFullName();
                //driverTh.TelephoneNumber = driver.PhoneNumber;

                if (!string.IsNullOrEmpty(driver.PhoneNumber))
                {
                    driverTh.TelephoneNumber = driver.PhoneNumber;
                }
                else if (!string.IsNullOrEmpty(driver.Mobile))
                {
                    driverTh.TelephoneNumber = driver.Mobile;
                }
                else if (!string.IsNullOrEmpty(driver.WorkPhone))
                {
                    driverTh.TelephoneNumber = driver.WorkPhone;
                }
                else
                {
                    driverTh.TelephoneNumber = "";
                }

                driversTh.Add(driverTh);
                if (invoicetypeid == 0)
                {
                    invoicetypeid = driver.InvoiceTypeId.GetValueOrDefault();
                }
            }
            quotationTH.Drivers = driversTh.ToArray();

            //Vehiculos
            var vehiclesTH = new List<POS_AUTOQuotationVehicles>();
            int count = 0;
            foreach (var vehicle in (quotation as QuotationAuto).VehicleProducts)
            {
                count = 1;

                while (count <= vehicle.VehicleQuantity)
                {
                    var vehicleTH = new POS_AUTOQuotationVehicles();
                    vehicleTH.Brand = vehicle.VehicleMakeName;
                    vehicleTH.EnsuredAmount = vehicle.InsuredAmount.GetValueOrDefault(0);
                    vehicleTH.EnsuredAmountSpecified = true;
                    vehicleTH.Model = vehicle.VehicleModel.Model_Desc;
                    vehicleTH.Plan = vehicle.SelectedProductName;
                    vehicleTH.VehicleType = vehicle.SelectedVehicleTypeName;
                    vehicleTH.Year = vehicle.Year.GetValueOrDefault(0);
                    vehicleTH.YearSpecified = true;
                    vehicleTH.Registro = vehicle.Plate;
                    vehicleTH.Chasis = vehicle.Chassis;

                    vehicleTH.VehicleValue = vehicle.VehiclePrice;
                    vehicleTH.Quantity = 1; //vehicle.VehicleQuantity.HasValue ? vehicle.VehicleQuantity.Value : 1;
                    vehicleTH.VehiclePrime = vehicle.TotalPrime.HasValue ? vehicle.TotalPrime.Value : 0;

                    if (vehicle.ProductLimits.Count > 0)
                    {
                        var prodLimit = vehicle.ProductLimits.First(pl => pl.IsSelected);

                        //Coberturas por vehículos (terceros)
                        var tpCoveragesTH = new List<POS_AUTOQuotationVehiclesThirdDamagesCoverages>();
                        foreach (var tpCov in prodLimit.ThirdPartyCoverages)
                        {
                            var tpCovTH = new POS_AUTOQuotationVehiclesThirdDamagesCoverages();
                            tpCovTH.Description = tpCov.Name.Capitalize(' ');
                            tpCovTH.Limit = tpCov.Limit;
                            tpCovTH.MinimumDeductibleSpecified = true;
                            tpCovTH.MinimumDeductible = tpCov.MinDeductible;
                            tpCovTH.LimitSpecified = true;
                            tpCoveragesTH.Add(tpCovTH);
                        }
                        vehicleTH.ThirdDamagesCoverages = tpCoveragesTH.ToArray();
                        vehicleTH.ThirdDamagesPrime = prodLimit.TpPrime.GetValueOrDefault(0);
                        vehicleTH.ThirdDamagesPrimeSpecified = true;

                        var sdCoveragesTH = new List<POS_AUTOQuotationVehiclesSelfDamagesCoverages>();

                        var SysFlexProxy = new CoreProxy(new SysFlexServiceClient());

                        foreach (var tpCov in prodLimit.SelfDamagesCoverages)
                        {
                            var sdCovTH = new POS_AUTOQuotationVehiclesSelfDamagesCoverages();
                            sdCovTH.Description = tpCov.Name.Capitalize(' ');
                            sdCovTH.Limit = tpCov.Limit;
                            sdCovTH.MinimumDeductibleSpecified = true;
                            sdCovTH.MinimumDeductible = tpCov.MinDeductible;
                            sdCovTH.LimitSpecified = true;

                            sdCovTH.Deducible = Convert.ToDecimal(tpCov.Deductible.GetValueOrDefault()) + "(%)";//Cambio 14-08-2017

                            sdCoveragesTH.Add(sdCovTH);
                        }
                        vehicleTH.SelfDamagesCoverages = sdCoveragesTH.ToArray();
                        vehicleTH.SelfDamagesPrime = prodLimit.SdPrime.GetValueOrDefault(0);
                        vehicleTH.SelfDamagesPrimeSpecified = true;

                        var addCoveragesTH = new List<POS_AUTOQuotationVehiclesAdditionals>();
                        decimal ServicesPrimeTotal = 0;
                        foreach (var addCov in prodLimit.ServicesCoverages)
                        {
                            var selected = addCov.Coverages.FirstOrDefault(c => c.IsSelected);

                            if (selected != null)
                            {
                                var addCovTH = new POS_AUTOQuotationVehiclesAdditionals();
                                addCovTH.Description = selected.Name.Capitalize(' ');
                                addCovTH.Limit = selected.Amount;
                                addCovTH.LimitSpecified = true;
                                addCovTH.MinimumDeductibleSpecified = true;
                                addCovTH.MinimumDeductible = selected.MinDeductible;
                                addCoveragesTH.Add(addCovTH);

                                ServicesPrimeTotal += selected.Amount;
                            }
                        }
                        vehicleTH.Additionals = addCoveragesTH.ToArray();
                        vehicleTH.AdditionalsPrime = ServicesPrimeTotal;
                        vehicleTH.AdditionalsPrimeSpecified = true;

                        vehicleTH.TotalVehiclePrime = (vehicleTH.VehiclePrime * vehicleTH.Quantity);

                        vehicleTH.TotalVehiclePrimeSpecified = true;
                    }

                    vehiclesTH.Add(vehicleTH);
                    count++;
                }
            }
            quotationTH.Vehicles = vehiclesTH.ToArray();
            quotationTH.NumberOfVehicles = vehiclesTH.Count;
            quotationTH.NumberOfVehiclesSpecified = true;

            decimal total = 0;

            var primes = new POS_AUTOQuotationPrimeResume();


            primes.TotalAnualPrime = quotation.TotalPrime.Value;
            primes.TotalAnualPrimeSpecified = true;

            //Descuentos
            var realDiscount = (quotation.TotalFlotillaDiscount.HasValue ? quotation.TotalFlotillaDiscount.Value : 0) + (quotation.TotalDiscount.HasValue ? quotation.TotalDiscount.Value : 0);

            primes.Discount = realDiscount;
            primes.DiscountSpecified = true;

            decimal newTotalAnualPrime = ((quotation.TotalPrime.HasValue ? quotation.TotalPrime.Value : 0) - realDiscount);
            decimal newTotaltaxes = newTotalAnualPrime * ((quotation.ISCPercentage.HasValue ? quotation.ISCPercentage.Value : 0) / 100);

            //Prima Total Con descuento
            primes.PrimeDiscount = newTotalAnualPrime;
            primes.PrimeDiscountSpecified = true;

            if (newTotaltaxes > 0)
            {
                if (invoicetypeid == 5)
                {
                    //limpiar el campo de impuesto del vehiculo.
                    primes.Taxes = 0;
                    newTotaltaxes = 0;
                }
                else
                {
                    primes.Taxes = newTotaltaxes;
                }
                primes.TaxesSpecified = true;
            }
            else
            {
                if (invoicetypeid == 5)
                {
                    //limpiar el campo de impuesto del vehiculo.
                    primes.Taxes = 0;
                    newTotaltaxes = 0;
                }
                else
                {
                    primes.Taxes = quotation.TotalISC.Value;
                }
                primes.TaxesSpecified = true;
            }

            total = newTotalAnualPrime + newTotaltaxes;

            primes.TotalPayment = total;
            primes.TotalPaymentSpecified = true;
            dataObject.Quotation.PrimeResume = primes;
        }

        public byte[] GenerateXMLContratoKSI(QuotationAuto quotation,
                                             List<Amortization> thisAmortizationTable,
                                             bool EsContrato,
                                             Person ContactData,
                                             double financingAmount,
                                             string ContactFullAdress,
                                            int periodo)
        {
            const string FormatoFecha = "{0:dd/MM/yyyy}";
            var result = new byte[] { };
            var Email = string.Empty;

            var DocumentIDContratoKSI = EsContrato ? ConfigurationManager.AppSettings["DocumentIDContratoKSI"] : ConfigurationManager.AppSettings["DocumentIDAmortizacionKSI"];

            var data = new STL.POS.THProxy.Schemas.POS_AUTO();

            var oContract = new STL.POS.THProxy.Schemas.Contract();
            var oTransaction = new STL.POS.THProxy.Schemas.Transaction();
            var oLoan = new STL.POS.THProxy.Schemas.Loan();
            var oFee = new STL.POS.THProxy.Schemas.Fee();
            #region Transacction

            oTransaction.DocumentId = DocumentIDContratoKSI;
            #region Loan
            oLoan.Account = "";
            oLoan.Id = "";
            oLoan.Status = "";
            oLoan.AccountName = ContactData.GetFullName();
            oLoan.Client = ContactData.GetFullName(); ;
            oLoan.FoundsSource = "Fondos Propios";
            oLoan.FundsDestination = "-";
            oLoan.CredtitFacility = "PRESTAMOS PERSONALES PARA GASTOS";
            oLoan.Comite = "";
            oLoan.PaymentMethod = "";
            oLoan.RequestedAmount = "";
            oLoan.ApprovedAmount = "";
            oLoan.ReleasedAmount = "";
            oLoan.CapitalReturn = "";
            oLoan.LastCut = "";
            oLoan.Interest = "";
            oLoan.Comission = "";
            oLoan.DelayFee = "";
            oLoan.FeeAmount = "";
            oLoan.PaymentPeriod = "";
            oLoan.Frequency = "";
            oLoan.RequestDate = "";
            oLoan.ApprovementDate = "";
            oLoan.ReleasedDate = "";
            oLoan.ExpirationDate = "";
            oLoan.NextPaymentDate = "";


            #region Fee
            oLoan.Fee = new List<STL.POS.THProxy.Schemas.Fee>(0);


            //var oAmortizationTable = AmortizationTable.Select(ta => new STL.POS.THProxy.Schemas.Fee
            //Obtener la tabla de amortizacion del prestamo
            //var DataResult = oPolicyGlobalService.ksiCalculator(new GlobalServices.PolicyksiCalculatorparameter
            //{
            //    DesiredAmount = (double)this.annualPremium.GetValueOrDefault(),
            //    LoanType = GlobalServices.LoanType.VehicleInsurance,
            //    Periods = Period.GetValueOrDefault()
            //});

            //var hasError = ErrorCode.Contains(DataResult.Code);

            //if (hasError)
            //    throw new Exception(string.Format("No se pudo generar la tabla de amortización  Error : {0}", DataResult.Message));


            //var DataAT = DataResult.productCalculatorResult.AmotizationTable;

            var AmortizationTable = thisAmortizationTable.Select(ta => new STL.POS.THProxy.Schemas.Fee
            {
                Number = ta.PeriodNumber.ToString().Replace(",", ""),
                Date = string.Format(FormatoFecha, ta.Date),
                Amount = ta.Payment.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Capital = ta.Principal.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Interests = ta.Interest.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", ""),
                Comission = "0",
                Spends = "0",
                Total = ta.Balance.ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "")
            });

            oLoan.TotalCapital = thisAmortizationTable.Sum(p => p.Principal).ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oLoan.TotalInterests = thisAmortizationTable.Sum(p => p.Interest).ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            oLoan.TotalComissions = "0";
            oLoan.TotalSpends = "0";
            oLoan.TotalAmount = "";
            var NumeroCuotas = (periodo).ToString("#,0", CultureInfo.InvariantCulture).Replace(",", "");

            oLoan.FeeNumber = NumeroCuotas;
            oLoan.Fee.AddRange(AmortizationTable);
            oTransaction.Loan = oLoan;
            #endregion

            #endregion

            #endregion

            //var Direccion = (ContactData.Address != null) ? string.Concat(ContactData.Address, ", ", ContactData.City.City_Desc, ", ", ContactData.City. oAddress.MunicipioDesc) : "-"; 



            #region Contract
            var ValueToConvertMonthlyPayment = quotation.MonthlyPayment != null ? quotation.MonthlyPayment : 0; // this.MonthlyPayment.GetValueOrDefault().ToString("#,0.00", CultureInfo.InvariantCulture).Replace(",", "");
            var LoanAmountString = Numalet.ToCardinal(financingAmount.ToString(), CultureInfo.InvariantCulture).ToUpper();
            var PaymentAmountString = Numalet.ToCardinal(ValueToConvertMonthlyPayment.ToString(), CultureInfo.InvariantCulture).ToUpper(); ;

            oContract.LoanNumber = "";
            oContract.CustomerName = quotation.PrincipalFullName;
            oContract.Citizenship = ContactData.Nationality.Global_Country_Desc;
            oContract.CivilStatus = string.IsNullOrEmpty(ContactData.MaritalStatus) ? "N/A" : ContactData.MaritalStatus;
            oContract.Id = ContactData.IdentificationNumber;
            oContract.Address1 = ContactFullAdress;
            oContract.Address2 = ContactFullAdress;
            oContract.CompanyRepresentative = "";
            oContract.CompanyRepCiticenship = "";
            oContract.CompanyRepId = "";
            oContract.QuotationNumber = quotation.QuotationNumber;
            oContract.InsuranceCompany = "ATLANTICA SEGUROS";

            oContract.LoanAmountString = string.Format("{0} {1}", LoanAmountString, financingAmount.ToString("N2", CultureInfo.InvariantCulture)/*TotalPrime*/);
            oContract.NumberOfPaymentString = string.Format("{0} ({1}) Cuotas", Numalet.ToCardinal(NumeroCuotas), NumeroCuotas).Replace("con 00/100.- ", "");
            oContract.PaymentAmountString = string.Format("{0} {1}", PaymentAmountString, quotation.MonthlyPayment.GetValueOrDefault().ToString("N2", CultureInfo.InvariantCulture));
            oContract.LoanRateString = "-";

            oContract.CreditCardType = Numalet.GetCreditCardType(quotation.Credit_Card_Type_Id.GetValueOrDefault());
            oContract.CreditCardNumber = string.IsNullOrEmpty(quotation.Credit_Card_Number) ? "" : Helperes.Decrypt_Query(quotation.Credit_Card_Number);
            oContract.CreditCardExpirationDate = quotation.Expiration_Date_Month != null ? string.Concat(quotation.Expiration_Date_Month, "/", quotation.Expiration_Date_Year) : "";

            string mes = DateTime.Now.ToString("MMMM").Capitalize();

            var ContractDateString = string.Format("{0}({1}) di­as del mes de {2} del año {3} ({4})",
                                                    Numalet.ToCardinal(DateTime.Now.Day).Replace("con 00/100.- ", ""),
                                                    DateTime.Now.Day,
                                                    mes,
                                                    Numalet.ToCardinal(DateTime.Now.Year).Replace("con 00/100.- ", ""),
                                                    DateTime.Now.Year);

            oContract.ContractDateString = ContractDateString;
            #endregion

            data.Transaction = oTransaction;
            data.Contract = oContract;

            var buffer = SerializeToXml2(data, false);

            result = SendToTHExecutePreview(null, buffer, 0, 0);

            return
                 result;
        }


        public void SendToTHExecutePreview_SMS(POS_AUTO transaction, byte[] transactionData, int THProjectID, int THBatchConfigResID)
        {
            ExternalJobRequestAPI request = new ExternalJobRequestAPI();

            request.batchName = "IntegracionPuntodeVenta";

            request.projectID = THProjectID;
            request.batchConfigResID = THBatchConfigResID;

            request.batchCollect = 8;
            request.finOption = 0;
            request.jobType = 0;
            request.transactionData = transactionData;
            webClient.Timeout = 1200000;

            var result = webClient.submitBatch(request);
        }


        public void NewSendToTHExecutePreview_SMS(byte[] transactionData, int THProjectID, int THBatchConfigResID)
        {
            tHParams.batchConfigResID = THBatchConfigResID;
            tHParams.projectID = THProjectID;
            tHParams.batchname = "IntegracionPuntodeVenta";
            tHParams.batchCollect = 8;

            tHParams.finOption = 0;
            tHParams.jobType = 0;

            var result = thServicesClient.submitBatch(tHParams, transactionData);
        }


        public byte[] NewSendToTHExecutePreview(byte[] transactionData, int THProjectID, int THBatchConfigResID)
        {
            byte[] binary = null;
            
            tHParams.batchConfigResID = THBatchConfigResID;
            tHParams.projectID = THProjectID;
            tHParams.batchname = "IntegracionPuntodeVenta";
            tHParams.batchCollect = 8;

            tHParams.finOption = 0;
            tHParams.jobType = 0;

            var result = thServicesClient.executePreview(tHParams, transactionData);
            if (result.Count() > 0)
            {
                binary = result.FirstOrDefault().Xmlbinary;
            }

            return binary;
        }
    }
}