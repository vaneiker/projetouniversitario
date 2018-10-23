﻿using STL.POS.Frontend.Web.NewVersion.CustomCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.Entities;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace STL.POS.Frontend.Web.NewVersion.Controllers
{
    public partial class HomeController : BaseController
    {
        public ActionResult DocumentRequired()
        {
            ViewBag.TitlePage = "DOCUMENTOS REQUERIDOS";
            ViewBag.RequestType = base.RequestType;

            #region Validando nivel de Riesgo del cliente
            if (string.IsNullOrEmpty(base.RiskLevel))
            {
                string result = "";
                var quotaData = GetDataQuotation(base.QuotationId);
                var QuotationDataVehicles = oQuotationManager.GetQuotationVehicles(base.QuotationId);

                var vechicleCount = QuotationDataVehicles.Count();
                var vehicleValues = QuotationDataVehicles.Sum(x => x.VehiclePrice);
                var insuredAmount = QuotationDataVehicles.Sum(x => x.InsuredAmount);
                var pTotalPremium = QuotationDataVehicles.Sum(x => x.TotalPrime + x.TotalIsc);
                var CustomerQuotation = quotaData._drivers.FirstOrDefault();

                if (CustomerQuotation.TypeOfPerson == 5 || CustomerQuotation.TypeOfPerson == 6)//Valido si el tipo de cliente que sea Organismos Públicos Nacional e Internacional para marcarlo como Riesgo bajo por defecto
                    result = "RB";
                else if (CustomerQuotation.PepFormularyOptionsId != null && CustomerQuotation.PepFormularyOptionsId.GetValueOrDefault() > 0 && CustomerQuotation.PepFormularyOptionsId.GetValueOrDefault() != 3)
                    result = "RA";
                else
                {
                    result = this.getRiskGetRiskLevelAuto(vechicleCount, vechicleCount > 1 ? "" : QuotationDataVehicles.FirstOrDefault().UsageName, pTotalPremium, vechicleCount <= 1 ? 0 : vehicleValues, vechicleCount <= 1 ? 0 : insuredAmount, CustomerQuotation.Nationality_Global_Country_Id);
                    result = JsonConvert.DeserializeObject(result).ToString();
                }

                base.RiskLevel = result;
            }
            #endregion

            var docsRequireds = getRequeriments(base.QuotationId);
            ViewBag.QuoId = base.QuotationId;
            ViewBag.isNotLawProduct = isNotLawProduct;
            
            switch (base.RiskLevel)
            {
                case "RA":
                    ViewBag.RiskLevel = "Alto";
                    break;
                case "RM":
                    ViewBag.RiskLevel = "Moderado";
                    break;
                default:
                    ViewBag.RiskLevel = "Bajo";
                    break;
            }

            return PartialView("_DocumentRequired", docsRequireds);
        }

        private List<Requeriments> getRequeriments(int quotationID)
        {
            var docReq = oDocumentRequiredManager.GeQuotationRequeriments(new Requeriments.GetRequerimentsParameters()
            {
                quotationId = quotationID,
                RiskLevel = base.RiskLevel
            });

            return docReq.OrderByDescending(x => x.Required).ToList();
        }

        public ActionResult viewRequiredDoc(int doc, string filename)
        {
            bool _success = false;
            string shortPath = "/Tmp/" + filename;
            try
            {
                var path = Path.Combine(Server.MapPath("~/Tmp"), filename);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                var allDataDoc = oDocumentRequiredManager.GeQuotationRequerimentsByDocument(new Requeriments.GetRequerimentsParameters()
                {
                    documentId = doc,
                    quotationId = base.QuotationId
                }).ToList();

                if (allDataDoc.Any())
                {
                    byte[] binaryData = allDataDoc.FirstOrDefault().DocumentBinary;
                    System.IO.File.WriteAllBytes(path, binaryData);

                    _success = true;
                }
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();
                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), base.QuotationId, "Error al mostrar el documento requerido", "Mensaje: " + ex.Message, ex);
            }
            return Json(new { success = _success, path = shortPath });
        }

        [HttpPost]
        public ActionResult uploadFileLocal(string s = "")
        {
            string path = "";
            bool _success = false;
            string _message = "";
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var RequiredFileSize = oDropDownManager.GetParameter("PARAMETER_KEY_REQUIRED_FILE_SIZE_DOC_REQUIRED").Value.ToInt();
                        if (fileContent.ContentLength > RequiredFileSize)
                        {
                            _message = "El archivo es demasiado grande. El tamaño maximo es 10MB.";
                            return Json(new { success = _success, path = path, message = _message });
                        }

                        var guid = Guid.NewGuid().ToString().Replace("-", "").Substring(1, 12).ToUpper();
                        // get a stream
                        var stream = fileContent.InputStream;
                        // and optionally write the file to disk
                        var fileName = guid + "~~" + fileContent.FileName;
                        path = Path.Combine(Server.MapPath("~/Tmp"), fileName);

                        if (fileContent.ContentType.IndexOf("image") != -1)
                        {
                            byte[] ImgBytes = new byte[fileContent.ContentLength];

                            //verificar el tipo de imagen que se esta capturando para si no es un png entonces convertirla a png
                            //if (fileContent.ContentType.IndexOf("png") == -1)
                            //{
                            //No es un png entonces convertirlo a png
                            ImgBytes = Utility.ConvertImageAsPng(stream);
                            //}

                            //Convertir imagen a pdf                        
                            var pdf = Utility.ConvertImageToPdf(ImgBytes);

                            string pathOnly = Server.MapPath("~/Tmp/");
                            string newPathFileName = string.Concat(pathOnly, Path.GetFileNameWithoutExtension(fileName), ".pdf");

                            Utility.ByteArrayToFile(newPathFileName, pdf);
                            string newFileName = string.Concat(Path.GetFileNameWithoutExtension(fileName), ".pdf");

                            path = "/Tmp/" + newFileName;
                            _success = true;
                        }
                        else if (fileContent.ContentType.IndexOf("pdf") != -1)
                        {
                            using (var fileStream = System.IO.File.Create(path))
                            {
                                stream.CopyTo(fileStream);
                                _success = true;
                            }
                            path = "/Tmp/" + fileName;
                        }
                        else
                        {
                            return Json(new { success = false, path = path, message = "Este tipo de archivo no es soportado." });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();
                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), base.QuotationId, "Error al cargar el documento requerido", "Mensaje: " + ex.Message, ex);
            }
            return Json(new { success = _success, path = path, message = _message });
        }

        [HttpPost]
        public ActionResult saveRequiredDocument(string jsondata)
        {
            bool _success = false;
            string _message = "";
            try
            {
                var jdata = JsonConvert.DeserializeObject<Utility.jsonDocRequired>(jsondata);
                var RequiredFileSize = oDropDownManager.GetParameter("PARAMETER_KEY_REQUIRED_FILE_SIZE_DOC_REQUIRED").Value.ToInt();

                string shortPath = jdata.DRActualPath.Replace("/Tmp/", "");
                var completePath = Path.Combine(Server.MapPath("~/Tmp"), shortPath);
                string docname = Path.GetFileName(completePath);

                byte[] docBinary = System.IO.File.ReadAllBytes(completePath);

                if (docBinary.Length > RequiredFileSize)
                {
                    _message = "El archivo es demasiado grande. El tamaño maximo es 10MB."; ;
                    return Json(new { success = _success, message = _message });
                }

                var realDocBinary = Utility.CompressPDF(docBinary);

                oDocumentRequiredManager.SetQuotationRequeriment(new Requeriments.SetRequerimentsParameters()
                {
                    quotationId = jdata.quotationID.ToInt(),
                    documentId = jdata.DocumentId.ToIntNullable(),
                    personId = jdata.PersonId.ToIntNullable(),
                    requirementTypeId = jdata.RequirementTypeId.ToInt(),
                    userId = GetCurrentUserID().HasValue ? GetCurrentUserID().Value : 7298,
                    vehicleId = jdata.VehicleId.ToIntNullable(),
                    documentName = docname,
                    documentBinary = realDocBinary
                });

                _success = true;

                deleteFileFromPath(completePath);
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();
                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), base.QuotationId, "Error al guardar el documento requerido", "Mensaje: " + ex.Message, ex);
            }

            return Json(new { success = _success, message = _message });
        }

        [HttpPost]
        public ActionResult deleteRequiredDoc(string jsondata)
        {
            bool _success = false;
            string _message = "";
            try
            {
                var jdata = JsonConvert.DeserializeObject<Utility.jsonDocRequired>(jsondata);

                string shortPath = jdata.DRActualPath.Replace("/Tmp/", "");
                var completePath = Path.Combine(Server.MapPath("~/Tmp"), shortPath);

                oDocumentRequiredManager.DeleteQuotationRequeriment(new Requeriments.SetRequerimentsParameters()
                {
                    quotationId = jdata.quotationID.ToInt(),
                    documentId = jdata.DocumentId.ToIntNullable(),
                    userId = GetCurrentUserID().HasValue ? GetCurrentUserID().Value : 7298
                });

                _success = true;

                deleteFileFromPath(completePath);
            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();
                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), base.QuotationId, "Error al eliminar el documento requerido", "Mensaje: " + ex.Message, ex);
            }

            return Json(new { success = _success, message = _message });
        }

        [HttpPost]
        public ActionResult validateRequiredDoc(string jsondata, bool validated)
        {
            bool _success = false;
            string _message = "";
            try
            {
                var jdata = JsonConvert.DeserializeObject<Utility.jsonDocRequired>(jsondata);

                oDocumentRequiredManager.ValidateQuotationRequeriment(new Requeriments.SetRequerimentsParameters()
                {
                    quotationId = jdata.quotationID.ToInt(),
                    documentId = jdata.DocumentId.ToIntNullable(),
                    validated = validated,
                    userId = GetCurrentUserID().HasValue ? GetCurrentUserID().Value : 7298
                });

                _success = true;

            }
            catch (Exception ex)
            {
                var userLogged = GetCurrentUsuario();
                //Insertamos en el log
                LoggerHelper.Log(CommonEnums.Categories.Error, (userLogged != null ? userLogged.UserLogin : ""), base.QuotationId, "Error al validar el documento requerido", "Mensaje: " + ex.Message, ex);
            }

            return Json(new { success = _success, message = _message });
        }

        public JsonResult allRequiredValidated()
        {
            List<string> _messages = new List<string>();

            bool _success = true;
            string templateDocUpload = "El Documento Requerido: <strong>{0}</strong> debe ser subido y validado.";
            string templateDocValidate = "El Documento Requerido: <strong>{0}</strong> debe ser validado.";

            var docReq = oDocumentRequiredManager.GeQuotationRequeriments(new Requeriments.GetRequerimentsParameters()
            {
                quotationId = base.QuotationId,
                RiskLevel = base.RiskLevel
            }).ToList();

            if (docReq.Any())
            {
                foreach (var d in docReq)
                {
                    if (d.Required)
                    {
                        if (!d.DocumentId.HasValue)
                        {
                            _messages.Add(string.Format(templateDocUpload, d.RequirementTypeDesc));
                            _success = false;
                        }
                        else if (d.DocumentId.HasValue && !d.Validated)
                        {
                            _messages.Add(string.Format(templateDocValidate, d.RequirementTypeDesc));
                            _success = false;
                        }
                    }
                }
            }

            if (_success)
            {
                var quotation = oQuotationManager.GetQuotation(base.QuotationId);
                var parameter = new Quotation.parameter
                {
                    id = base.QuotationId,
                    lastStepVisited = 5,
                    monthlyPayment = quotation != null ? quotation.MonthlyPayment : null,
                    financed = quotation != null ? quotation.Financed.GetValueOrDefault() : false,
                    period = quotation != null ? quotation.Period : null,
                    modi_UserId = (GetCurrentUserID() != null ? GetCurrentUserID() : quotation.Modi_UserId),
                    RiskLevel = !string.IsNullOrEmpty(base.RiskLevel)? base.RiskLevel: null
                };

                oQuotationManager.SetQuotation(parameter);
            }

            return Json(new { success = _success, message = _messages });
        }

        private void deleteFileFromPath(string path)
        {
            try
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            catch (Exception ex)
            { }
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}