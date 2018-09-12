using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;
using RESOURCE.UnderWriting.NewBussiness;
using Entity.UnderWriting.Entities;

namespace WEB.NewBusiness.NewBusiness.UserControls.Beneficiaries
{
    public partial class BeneficiariesContainer : UC, IUC
    {
        public Utility.OperationType Operation
        {
            get { return ((Utility.OperationType)Session["OperationBenficiaries"]); }
            set
            {
                Session["OperationBenficiaries"] = value;
                gvBeneficiaries.Enabled = (value == Utility.OperationType.Insert);
                pnGvBeneficiaries.CssClass = (value == Utility.OperationType.Insert) ? "grid_wrap margin_t_10 gris"
                                                                                     : "DisabledGrid grid_wrap margin_t_10 gris";
            }
        }

        public int? RowIndex
        {
            get { return int.Parse(Session["RowIndexBenficiaries"].ToString()); }
            set { Session["RowIndexBenficiaries"] = value; }
        }

        private string TempFilePath
        {
            get { return Server.MapPath("~/TempFiles"); }
        }

        protected void Page_Load(object sender, EventArgs e) { }

        public void edit() { }

        public void EnabledControls(bool x)
        {
            if (!ObjServices.esFunerario())
            {
                WUCMainInsured.EnabledControls(x);
                WUCAdditionalInsured.EnabledControls(x);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator("");
        }

        public void Translator(string Lang)
        {
            MainInsured.Text = Resources.MainInsuredLabel;

            AdditionalInsured.Text = Resources.AdditionalInsured;

            MainBeneficiaries.Text = Resources.CLAIMANTSBENEFICIARIES;

            BeneficiariesInformation.Text = Resources.BeneficiariesInformationLabel;

            //Traduccion para los planes funerarios
            if (ObjServices.esFunerario())
            {
                FirtName.InnerHtml = Resources.FirstNameLabel;
                SecondLastName.InnerHtml = Resources.SecondLastNameLabel;
                LastName.InnerHtml = Resources.LastNameLabel;
                MiddleName.InnerHtml = Resources.MiddleNameLabel;
                DateOfBirth.InnerHtml = Resources.DateofBirthLabel;
                Relationship.InnerHtml = Resources.RelationshipLabel;
                Gender.InnerHtml = Resources.GenderLabel;
                ID.InnerHtml = "ID#";
                btnAdd.Text = Resources.Add;
                btnClear.Text = Resources.Clear;
                fuMainBenediciarieFile.BrowseButton.Text = Resources.UPLOADID.Capitalize(' ');
                gvBeneficiaries.Columns[0].Caption = Resources.FirstNameLabel;
                gvBeneficiaries.Columns[1].Caption = Resources.MiddleNameLabel;
                gvBeneficiaries.Columns[2].Caption = Resources.LastNameLabel;
                gvBeneficiaries.Columns[3].Caption = Resources.SecondLastNameLabel;
                gvBeneficiaries.Columns[4].Caption = Resources.DateofBirthLabel;
                gvBeneficiaries.Columns[5].Caption = Resources.RelationshipLabel;
                gvBeneficiaries.Columns[6].Caption = "ID";
                gvBeneficiaries.Columns[7].Caption = Resources.DocumentLabel;
                gvBeneficiaries.Columns[8].Caption = Resources.Edit;
                gvBeneficiaries.Columns[9].Caption = Resources.DeleteLabel;
                btnSearch.Text = Resources.SearchContact;
            }

            if (isChangingLang)
            {
                FillDrop();
                FillData();
            }
        }

        public void save()
        {
            if (!ObjServices.esFunerario())
            {
                WUCMainInsured.save();
                WUCAdditionalInsured.save();
            }
        }

        public void FillData()
        {
            if (!ObjServices.esFunerario())
            {
                WUCMainInsured.FillData();
                WUCAdditionalInsured.FillData();
            }
            else
            {

                var data = ObjServices.oBeneficiaryManager.GetAllBeneficiary(ObjServices.Corp_Id,
                                                                             ObjServices.Region_Id,
                                                                             ObjServices.Country_Id,
                                                                             ObjServices.Domesticreg_Id,
                                                                             ObjServices.State_Prov_Id,
                                                                             ObjServices.City_Id,
                                                                             ObjServices.Office_Id,
                                                                             ObjServices.Case_Seq_No,
                                                                             ObjServices.Hist_Seq_No,
                                                                             true,
                                                                             1,
                                                                             null
                                                                             , languageId: ObjServices.Language.ToInt()
                                                                             ).ToList();

                hdnCountBeneficiaries.Value = data.Count.ToString();

                ObjServices.saveSetValidTab(Utility.Tab.Beneficiaries, hdnCountBeneficiaries.ToInt() > 0);

                gvBeneficiaries.DataSource = data;
                gvBeneficiaries.DataBind();
            }
        }

        public void FillDrop()
        {
            //Llenar el dropDpown de Generos
            ObjServices.GettingAllDrops(ref ddlGender,
                                    Utility.DropDownType.Gender,
                                    "GenderDesc",
                                    "GenderId",
                                    GenerateItemSelect: true
                                   );

            //Llenar el dropDown de Relationship
            ObjServices.GettingAllDrops(ref ddlRelationship,
                                     Utility.DropDownType.Relationship,
                                     "RelationshipDesc",
                                     "RelationshipId",
                                     GenerateItemSelect: true
                                     );
        }

        public void Initialize()
        {
            if (ObjServices.esFunerario())
            {
                Operation = Utility.OperationType.Insert;
                mtBeneficiariesMain.ActiveViewIndex = 1;
                FillDrop();
                FillData();
            }
            else
            {
                mtBeneficiariesMain.ActiveViewIndex = 0;
                WUCMainInsured.Initialize();
                WUCAdditionalInsured.Initialize();
            }
        }

        public void ClearData()
        {
            if (!ObjServices.esFunerario())
            {
                WUCMainInsured.ClearData();
                WUCAdditionalInsured.ClearData();
            }
        }

        public bool saveBeneficiaries()
        {
            bool result = false;

            //No es un plan funerario
            if (!ObjServices.esFunerario())
            {
                if (ObjServices.HasInsured)
                    result = WUCMainInsured.saveBeneficiaries() && WUCAdditionalInsured.saveBeneficiaries();
                else
                    result = WUCMainInsured.saveBeneficiaries();
            }
            else
                result = hdnCountBeneficiaries.ToInt() > 0;

            ObjServices.saveSetValidTab(Utility.Tab.Beneficiaries, result);

            return result;
        }

        public void ReadOnlyControls(bool isReadOnly)
        {
            if (!ObjServices.esFunerario())
            {
                WUCMainInsured.ReadOnlyControls(isReadOnly);
                WUCAdditionalInsured.ReadOnlyControls(isReadOnly);
            }
        }

        protected void gvBeneficiaries_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var GridView = (sender as DevExpress.Web.ASPxGridView);
            var ContactId = int.Parse(GridView.GetKeyFromAspxGridView("ContactId", e.VisibleIndex).ToString());
            var Commando = e.CommandArgs.CommandName;
            RowIndex = e.VisibleIndex;

            switch (Commando)
            {
                case "Modify":
                    var dataBenef = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ContactId, languageId: ObjServices.Language.ToInt());
                    txtFirstName.Text = dataBenef.FirstName;
                    txtMiddleName.Text = dataBenef.MiddleName;
                    txtLastName.Text = dataBenef.FirstLastName;
                    txtSecondLastName.Text = dataBenef.SecondLastName;
                    txtDateOfBirth.Text = dataBenef.Dob.ToString();
                    ddlGender.SelectIndexByValue(dataBenef.Gender);
                    ddlRelationship.SelectIndexByValue(dataBenef.RelationshiptoOwner.ToString());
                    txtID.Text = GridView.GetKeyFromAspxGridView("ContactMainId", e.VisibleIndex).ToString();
                    Operation = Utility.OperationType.Edit;
                    btnAdd.Text = "Save";
                    break;
                case "Delete":
                    ObjServices.oBeneficiaryManager.DeleteBeneficiary(ObjServices.Corp_Id,
                                                                      ObjServices.Region_Id,
                                                                      ObjServices.Country_Id,
                                                                      ObjServices.Domesticreg_Id,
                                                                      ObjServices.State_Prov_Id,
                                                                      ObjServices.City_Id,
                                                                      ObjServices.Office_Id,
                                                                      ObjServices.Case_Seq_No,
                                                                      ObjServices.Hist_Seq_No,
                                                                      ContactId,
                                                                      Utility.ContactRoleIDType.Beneficiarie.ToInt()
                                                                      );

                    FillData();
                    break;

                case "PdfView":
                    btnFile_Click();
                    break;

            }
        }

        public void createBeneficiarie(int contactId)
        {
            //Adjuntar el beneficiario a la poliza
            ObjServices.oPolicyManager.AddContactToPolicy(ObjServices.Corp_Id,
                                                          ObjServices.Region_Id,
                                                          ObjServices.Country_Id,
                                                          ObjServices.Domesticreg_Id,
                                                          ObjServices.State_Prov_Id,
                                                          ObjServices.City_Id,
                                                          ObjServices.Office_Id,
                                                          ObjServices.Case_Seq_No,
                                                          ObjServices.Hist_Seq_No,
                                                          contactId,
                                                          Utility.ContactTypeId.Contact.ToInt(),
                                                          Utility.ContactRoleIDType.Beneficiarie.ToInt(),
                                                          ObjServices.Agent_Id.Value,
                                                          ObjServices.UserID.Value
                                                         );


            var DataContactBeneficiary = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, contactId, ObjServices.Language.ToInt());

            var objId = ObjServices.oContactManager.GetAllIdDocumentBenefitary(contactId, ObjServices.Language.ToInt()).LastOrDefault();

            //Actualizar el beneficiario
            var BItem = new Beneficiary
            {
                //Seteo el Key del Item                
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                ContactId = contactId,
                ContactRoleTypeId = 4,
                ContactTypeId = 4, //Aqui el tipo de cliente 5 Compañia y 4 beneficiario.                  
                PrimaryBeneficiary = true,
                BeneficiaryTypeId = 1,

                RelationshipToOwnerId = DataContactBeneficiary.RelationshiptoOwner,
                RelationshipDesc = DataContactBeneficiary.RelationshiptoOwnerDesc,

                SeqNo = objId != null ? objId.SeqNo : (int?)null,
                ContactMainId = objId != null ? objId.Id : null,

                CreateUser = ObjServices.UserID.Value
            };

            ObjServices.oBeneficiaryManager.UpdatetBeneficiary(BItem);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var ContactID = -1;
            var ContactId = -1;
            var SeqNo = -1;
            var DocumentId = -1;

            if (Operation == Utility.OperationType.Edit)
            {
                ContactID = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("ContactId", RowIndex.Value).ToString());
                ContactId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("ContactId", RowIndex.Value).ToString());
                SeqNo = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("SeqNo", RowIndex.Value).ToString());
                DocumentId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("DocumentId", RowIndex.Value).ToString());
            }

            var FileName = TempFilePath + "\\" + hdnUploadedPDFPath.Text;
            //Agregar un nuevo beneficiario
            var BItem = new Entity.UnderWriting.Entities.Beneficiary()
            {
                //Seteo el Key del Item
                ContactId = Operation == Utility.OperationType.Insert ? -1 : ContactID,
                CorpId = ObjServices.Corp_Id,
                RegionId = ObjServices.Region_Id,
                CountryId = ObjServices.Country_Id,
                DomesticregId = ObjServices.Domesticreg_Id,
                StateProvId = ObjServices.State_Prov_Id,
                CityId = ObjServices.City_Id,
                OfficeId = ObjServices.Office_Id,
                CaseSeqNo = ObjServices.Case_Seq_No,
                HistSeqNo = ObjServices.Hist_Seq_No,
                ContactRoleTypeId = 4,
                BeneficiaryTypeId = 1,
                ContactTypeId = 4, //Aqui el tipo de cliente 5 Compañia y 4 beneficiario.
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                FirstLastName = txtLastName.Text,
                PrimaryBeneficiary = true,
                SecondLastName = txtSecondLastName.Text,
                Dob = txtDateOfBirth.Text.ParseFormat(),
                RelationshipToOwnerId = ddlRelationship.ToInt(),
                Gender = ddlGender.SelectedValue,
                CreateUser = ObjServices.UserID.Value,
                ContactMainId = txtID.Text.Trim(),
                SeqNo = Operation == Utility.OperationType.Insert ? -1 : SeqNo,
                DocumentBinary = String.IsNullOrEmpty(hdnUploadedPDFPath.Text) ? null : Utility.ReadBinaryFile(FileName)
            };

            if (Operation == Utility.OperationType.Insert)
                ObjServices.oBeneficiaryManager.InsertBeneficiary(BItem);
            else
            {
                if (!String.IsNullOrEmpty(hdnUploadedPDFPath.Text))
                {
                    if (gvBeneficiaries.GetKeyFromAspxGridView("DocumentId", RowIndex.Value) != null)
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, DocumentId, Utility.ReadBinaryFile(FileName), 1);
                    else
                        //Insertar Documento
                        ObjServices.oBeneficiaryManager.SetDocument(ContactId, SeqNo, null, Utility.ReadBinaryFile(FileName), 1);
                }

                ObjServices.oBeneficiaryManager.UpdatetBeneficiary(BItem);
                Operation = Utility.OperationType.Insert;
                btnAdd.Text = Resources.Add;
            }

            Utility.ClearAll(pnFormBeneficiaries.Controls);
            hdnUploadedPDFPath.Text = "";
            FillData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Operation = Utility.OperationType.Insert;
            Utility.ClearAll(pnFormBeneficiaries.Controls);
        }

        protected void Translate_PreRender(object sender, EventArgs e)
        {
            if (sender is GridView)
                ((GridView)sender).TranslateColumnsGridView();
            else
                if (sender is DevExpress.Web.ASPxGridView)
                    ((DevExpress.Web.ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        protected void fuMainBenediciarieFile_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            var message = "";
            try
            {
                var file = e.UploadedFile;
                if (file.IsValid)
                {
                    var fileName = Utility.GetSerialId() + "~~" + file.FileName;
                    var savePath = TempFilePath + "\\" + fileName;
                    file.SaveAs(savePath);

                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", fileName, "");
                }
                else
                    message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", "Error");
            }
            catch (Exception ex)
            {
                message = String.Format("{{ \"file\": \"{0}\", \"error\": \"{1}\"}}", "", ex.Message);
            }
            e.CallbackData = message;
        }

        protected void btnFile_Click()
        {
            if (Operation != Utility.OperationType.Edit)
            {
                var ContactId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("ContactId", RowIndex.Value).ToString());
                var DocumentCategoryId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("DocumentCategoryId", RowIndex.Value).ToString());
                var DocumentTypeId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("DocumentTypeId", RowIndex.Value).ToString());
                var DocumentId = int.Parse(gvBeneficiaries.GetKeyFromAspxGridView("DocumentId", RowIndex.Value).ToString());

                //Buscar Data del documento.
                var beneficiaryDoc = ObjServices.oBeneficiaryManager.GetIdDocument(ContactId, DocumentCategoryId, DocumentTypeId, DocumentId);

                if (beneficiaryDoc.DocumentBinary != null)
                {

                    var UCShowPDFPopup1 = (NewBusiness.UserControls.Common.WUCShowPDFPopup)this.Page.Master.FindControl("WUCShowPDFPopup1");
                    var HiddenShowPdF = (HiddenField)this.Page.Master.FindControl("hdnShowBeneficiariePDF");
                    var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("ModalPopupPDFViewer");
                    //var PdfTitle = (Literal)UCShowPDFPopup1.FindControl("ltTypeDoc");

                    if (UCShowPDFPopup1 != null && HiddenShowPdF != null && ModalPopUp != null)
                    {
                        UCShowPDFPopup1.LoadPDFPreview(beneficiaryDoc.DocumentBinary);
                        //PdfTitle.Text = Resources.DocumentView;
                        ModalPopUp.Show();
                    }

                }
            }
            else
                this.MessageBox("Documents cannot be previewed while in edition mode, please save info and try again.", Title: "Edition Mode");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var bodyContent = this.Page.Master.FindControl("bodyContent");
            (bodyContent.FindControl("hdnShowPopClientInfoSearch") as HiddenField).Value = "true";
            var WUCSearchClientOrOwner = bodyContent.FindControl("popSearchClientOrOwner").FindControl("WUCSearchClientOrOwner");

            if (WUCSearchClientOrOwner != null)
            {
                var ohdnKeyNameProduct = WUCSearchClientOrOwner.FindControl("hdnKeyNameProduct");

                if (!ohdnKeyNameProduct.isNullReferenceControl())
                    (ohdnKeyNameProduct as HiddenField).Value = ObjServices.KeyNameProduct;

                var oWUCSearchClientOrOwner = (NewBusiness.UserControls.AddNewClient.Common.WUCSearchClientOrOwner)WUCSearchClientOrOwner;
                oWUCSearchClientOrOwner.ContactTypeID = Utility.ContactTypeId.Contact.ToInt();
                oWUCSearchClientOrOwner.Initialize();
                var udpAddNewClient = bodyContent.FindControl("udpAddNewClient");
                if (udpAddNewClient != null)
                    (udpAddNewClient as UpdatePanel).Update();
            }
        }
    }
}