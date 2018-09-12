using DI.UnderWriting;
using Entity.UnderWriting.Entities;
using Ionic.Zip;
using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.VehicleInspectionForm
{
    public partial class InspectionForm : UC, IUC
    {
        public string IllustrationStatusCode
        {
            get
            {
                return Convert.ToString(Session["IllustrationStatusCode"]);
            }
        }

        private bool IllustrationIsSubcription()
        {
            return new[] { 
					Utility.IllustrationStatus.Subscription.Code(),
					Utility.IllustrationStatus.Submitted.Code()}.Contains(IllustrationStatusCode);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ObjServices.isChangingLang || !IsPostBack)
            {
                Translator(ObjServices.Language.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            Initialize();
        }

        public void Translator(string Lang)
        {
            btnBackToIllustrations.Text = Resources.IllustrationDetail;
            btnClean.Text = Resources.Clean;
            btnSave.Text = Resources.Save;
            btnDownLoad.Text = Resources.DownloadPhotos;

            if (ObjServices.hdnQuotationTabs != "lnkMissingInspections")
                btnSendToSubscription.Text = Resources.CompleteInspection;
            else
                btnSendToSubscription.Text = Resources.SendToSubscribe;
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            CancelarAutoSave();

            this.ExcecuteJScript("saveAll('');");

            //Fotos1.save();

            int vehiclesCount = Session["vehiclesCount"] != null ? Convert.ToInt32(Session["vehiclesCount"]) : 0;
            bool saved = hdnSaved.Value == "true";

            string script = "cleanAll(); $('#ddlMarca').val(0); DisabledSections('true');";
            this.ExcecuteJScript(script);

            if (vehiclesCount == 1 && saved)
                BackToIllustrations();
        }

        public void edit()
        {
            throw new NotImplementedException();
        }

        public void FillData()
        {
            tipoCombustible1.Initialize();
            verificacionFuncionamiento1.Initialize();
            verificacionPartesFisicas1.Initialize();
            accesoriosTapiceria1.Initialize();
            sistemasSeguridadComplementos1.Initialize();
        }

        public void Initialize()
        {
            informacionesGenerales1.Initialize();
            informacionesGenerales1.FillData();
            FillData();
        }

        public void ClearData()
        {
            informacionesGenerales1.Clean();
            this.ExcecuteJScript("__doPostBack('updFormularioInspeccion', '');");
        }

        private void BackToIllustrations()
        {
            Session["fromInspection"] = true;
            Response.Redirect("IllustrationsVehicle.aspx");
        }

        protected void btnBackToIllustrations_Click(object sender, EventArgs e)
        {
            CancelarAutoSave();
            BackToIllustrations();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void btnClean_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void updBotones_Unload(object sender, EventArgs e)
        {
            MethodInfo methodInfo = typeof(ScriptManager).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                                                         .Where(i => i.Name.Equals("System.Web.UI.IScriptManagerInternal.RegisterUpdatePanel")).First();

            methodInfo.Invoke(ScriptManager.GetCurrent(Page), new object[] 
            { 
                sender as UpdatePanel 
            });
        }

        private void CancelarAutoSave()
        {
            if (Session["AutoSave"] != null && Convert.ToBoolean(Session["AutoSave"]))
            {
                Session["AutoSave"] = false;
                this.ExcecuteJScript("clearInterval(auto_save_interval_id);");
            }
        }

        protected void btnDownLoad_Click(object sender, EventArgs e)
        {
            if (Session["MarcaChasis"] == null) return;

            var document_category = ObjServices.oVehicleManager.GetDocumentCategory("VIFPhotos");

            List<Vehicle.Review.Pic> photos = ObjServices.oVehicleManager.GetVehicleReviewPic(new Vehicle.Review
            {
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticRegId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                InsuredVehicleId = ObjServices.InsuredVehicleId,
                ReviewId = ObjServices.ReviewId
            }).Where(f => f.PictureStatus.GetValueOrDefault() && f.DocTypeId == document_category.DocTypeId && f.DocCategoryId == document_category.DocCategoryId).ToList();

            if (photos.Count > 0)
            {
                ZipFile zip = new ZipFile();
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;

                string[] MarcaChasis = Convert.ToString(Session["MarcaChasis"]).Split('|');
                string Marca = MarcaChasis[0],
                       Chasis = MarcaChasis[1];

                foreach (var photo in photos)
                    zip.AddEntry(string.Format("{0}_{1}_{2}.jpg", Marca, Chasis, photo.DocumentName), photo.DocumentBinary);

                var zipMS = new MemoryStream();
                zip.Save(zipMS);

                Response.Clear();
                Response.AddHeader("content-disposition", string.Format("attachment;filename=fotos_{0}_{1}_{2}.zip", ObjServices.Policy_Id, Marca, Chasis));
                Response.ContentType = "application/zip";
                Response.BinaryWrite(zipMS.ToArray());
                Response.End();
            }
        }

        protected void btnSendToSubscription_Click(object sender, EventArgs e)
        {

            if (ObjServices.hdnQuotationTabs != "lnkMissingInspections")
            {
                //Redireccionar al grid
                Session["firstOption"] = false;
                Response.Redirect("Illustrations.aspx");
            }
            else
            {
                var Ilustration = ObjServices.getillustrationData();

                //Verificar si tiene inspector
                if (Ilustration.InspectorAgentId == null || Ilustration.InspectorAgentId <= 0)
                {
                    this.MessageBox(Resources.YouMustIndicateInspectorName, Title: "Error", Width: 500, Height: 150);
                    return;
                }

                var resValidation = ObjServices.HasCustomerSignInInspection();

                if (resValidation.Item1 == false)
                {
                    this.MessageBox(resValidation.Item2);
                    return;
                }
                           
                //cambiar estatus a suscripcion
                #region Verificar que la inspeccion este completa antes de enviarla a suscripcion

                //Policy.Parameter it = new Policy.Parameter()
                //{
                //    CorpId = ObjServices.Corp_Id,
                //    RegionId = ObjServices.Region_Id,
                //    CountryId = ObjServices.Country_Id,
                //    DomesticregId = ObjServices.Domesticreg_Id,
                //    StateProvId = ObjServices.State_Prov_Id,
                //    CityId = ObjServices.City_Id,
                //    OfficeId = ObjServices.Office_Id,
                //    CaseSeqNo = ObjServices.Case_Seq_No,
                //    HistSeqNo = ObjServices.Hist_Seq_No
                //};

                //var EmptyInspectionAddress = ObjServices.oPolicyManager.GetVehicleInsured(it).Where(x => !x.Inspection.GetValueOrDefault()).Any(v => v.InspectionAddress.Trim() == string.Empty);

                //if (EmptyInspectionAddress)
                //{
                //    string qnumber = informacionesGenerales1.getQuotationNumber();

                //    this.ExcecuteJScript("$('#divReason').hide();");
                //    this.MessageBox(string.Format("Error en la cotizacion {0} - {1}", qnumber, Resources.YouMustIndicateInspectionAddressNew), Width: 500, Title: Resources.Warning);
                //    return;
                //}




                var UsedCar = ObjServices.oPolicyManager.GetVehicleInsured(new Policy.Parameter
                {
                    CorpId = ObjServices.Corp_Id,
                    RegionId = ObjServices.Region_Id,
                    CountryId = ObjServices.Country_Id,
                    DomesticregId = ObjServices.Domesticreg_Id,
                    StateProvId = ObjServices.State_Prov_Id,
                    CityId = ObjServices.City_Id,
                    OfficeId = ObjServices.Office_Id,
                    CaseSeqNo = ObjServices.Case_Seq_No,
                    HistSeqNo = ObjServices.Hist_Seq_No
                }).Where(x => !x.New.GetValueOrDefault() &&
                              (!x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ley") &&
                               !x.ProductTypeDesc.Trim().RemoveCR().ToLower().Contains("ultra"))).ToList();

                if (UsedCar.Count > 0)
                {
                    var emptyaddress = UsedCar.Any(x => string.IsNullOrWhiteSpace(x.InspectionAddress));
                    if (emptyaddress)
                    {
                        string qnumber = informacionesGenerales1.getQuotationNumber();

                        this.ExcecuteJScript("$('#divReason').hide();");
                        this.MessageBox(string.Format("Error en la cotizacion {0} - {1}", qnumber, Resources.YouMustIndicateInspectionAddressNew), Width: 500, Title: Resources.Warning);
                        return;
                    }
                }


                if ((ObjServices.IsInspectorQuotRole || ObjServices.IsAngetInspectorQuotRole || ObjServices.isUserCot))
                {
                    Utility.itemPolicy policy = new Utility.itemPolicy()
                    {
                        CorpId = ObjServices.Corp_Id,
                        RegionId = ObjServices.Region_Id,
                        CountryId = ObjServices.Country_Id,
                        DomesticregId = ObjServices.Domesticreg_Id,
                        StateProvId = ObjServices.State_Prov_Id,
                        CityId = ObjServices.City_Id,
                        OfficeId = ObjServices.Office_Id,
                        CaseSeqNo = ObjServices.Case_Seq_No,
                        HistSeqNo = ObjServices.Hist_Seq_No
                    };

                    string result = ObjServices.InspectionCompleted(policy, ObjServices.ProductLine);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        this.ExcecuteJScript("$('#divReason').hide();");
                        this.MessageBox(result, Width: 500, Title: Resources.Warning);
                        return;
                    }
                }
                #endregion


                Session["areInspected"] = null;

                //aqui debo consultar si el status de inspection esta o no
                bool r = ObjServices.hasInspectionAllVehicles(ObjServices.Case_Seq_No,
                                                              ObjServices.City_Id,
                                                              ObjServices.Corp_Id,
                                                              ObjServices.Country_Id,
                                                              ObjServices.Domesticreg_Id,
                                                              ObjServices.Hist_Seq_No,
                                                              ObjServices.Office_Id,
                                                              ObjServices.Region_Id,
                                                              ObjServices.State_Prov_Id);
                if (!r)
                {
                    this.MessageBox(Resources.QuotationInspectionNoChange, Title: "Error", Width: 500, Height: 150);
                    Session["areInspected"] = "False";
                    return;
                }

                bool comple = ObjServices.isInspectedCompleted(ObjServices.Case_Seq_No,
                                                               ObjServices.City_Id,
                                                               ObjServices.Corp_Id,
                                                               ObjServices.Country_Id,
                                                               ObjServices.Domesticreg_Id,
                                                               ObjServices.Hist_Seq_No,
                                                               ObjServices.Office_Id,
                                                               ObjServices.Region_Id,
                                                               ObjServices.State_Prov_Id);
                if (!comple)
                {
                    this.MessageBox(Resources.QuotationInspectionNoCompleted, Title: "Error", Width: 500, Height: 150);
                    return;
                }

                #region inserto el inspector seleccionado en la inspeccion
                if (Ilustration.InspectorAgentId > 0)
                {
                    ObjServices.AssignIllustrationToSubscriber(ObjServices.Corp_Id,
                     ObjServices.Region_Id,
                     ObjServices.Country_Id,
                     ObjServices.Domesticreg_Id,
                     ObjServices.State_Prov_Id,
                     ObjServices.City_Id,
                     ObjServices.Office_Id,
                     ObjServices.Case_Seq_No,
                     ObjServices.Hist_Seq_No,
                     ObjServices.InspectorAgentId.GetValueOrDefault(),
                     "Inspector"
                     );

                    //Actualizo la flag table para que luego que tenga asignado el inspector, que el proceso reconozca ese dato en la tabla que llena el GridView de la bandeja. si no se hace esto, es como si no se efectuara la asignacion del inspector
                    var result = ObjServices.UpdateTempTable(ObjServices.Policy_Id, ObjServices.UserID.GetValueOrDefault());
                }
                #endregion

                ObjServices.ChangeIllustrationStatus(-1,
                                                     ObjServices.Corp_Id,
                                                     ObjServices.Region_Id,
                                                     ObjServices.Country_Id,
                                                     ObjServices.Domesticreg_Id,
                                                     ObjServices.State_Prov_Id,
                                                     ObjServices.City_Id,
                                                     ObjServices.Office_Id,
                                                     ObjServices.Case_Seq_No,
                                                     ObjServices.Hist_Seq_No,
                                                     ObjServices.UserID.GetValueOrDefault(),
                                                     Utility.IllustrationStatus.Subscription,
                                                     string.Empty,
                                                     ObjServices.Agent_Id,
                                                     string.Empty);

                Session["firstOption"] = false;
                Utility.ExcecuteJScript(this, string.Format("BackToIllustrationList2('{0}', '{1}');", Resources.StatusChangedSuccessfully, Resources.Success));
            }
        }
    }
}