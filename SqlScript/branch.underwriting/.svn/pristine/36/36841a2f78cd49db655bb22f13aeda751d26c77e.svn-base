using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    public partial class UCUploadDocumentOfPayments : UC, IUC
    {
        public delegate void EditCreditCard(Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail datos);
        public event EditCreditCard EditCreditCardEvent;

        public delegate void RefreshDocuments();
        public event RefreshDocuments RefreshDocumentsEvent;

        public delegate void RefreshDocumentPath2(string Path);
        public event RefreshDocumentPath2 RefreshDocumentPath2Event;

        public class item
        {
            public string PaymentDocumentation { get; set; }
            public string PaymentDescription { get; set; }
            public string Amount { get; set; }
            public string ResultCode { get; set; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator();
        }

        public void Translator()
        {
            if (isChangingLang)
                FillData();
        }

        public void save() { }
        public void edit() { }
        public void Initialize()
        {
            FillData();
        }
        public void ClearData() { }
        protected void gvFormOfPayment_DataBound(object sender, EventArgs e) { }
        public void ReadOnlyControls(bool isReadOnly) { }

        protected void Page_Load(object sender, EventArgs e)
        {
            UCUploadPaymentDocumentPopUp.RefreshDocumentPathEvent += new UCUploadPaymentDocumentPopUp.RefreshDocumentPath(RefreshDocumentPath);
            gvFormOfPayment.Columns[3].Visible = !(ObjServices.IsDataReviewMode);
        }

        public void hideColumn()
        {
            if (ObjServices.IsDataReviewMode && getisView)
            {
                gvFormOfPayment.Enabled = true;
                gvFormOfPayment.Columns[2].Visible = false;
            }

            udpForOfPayment.Update();
        }

        public void RefreshDocumentPath(string Path)
        {
            RefreshDocumentPath2Event(Path);
        }
        public void FillData()
        {
            if (ObjServices.PaymentId.HasValue)
            {
                gvFormOfPayment.DataSource = ObjServices.oPaymentManager.GetAllApplyPaymentDetail
                   (
                         ObjServices.Corp_Id
                       , ObjServices.Region_Id
                       , ObjServices.Country_Id
                       , ObjServices.Domesticreg_Id
                       , ObjServices.State_Prov_Id
                       , ObjServices.City_Id
                       , ObjServices.Office_Id
                       , ObjServices.Case_Seq_No
                       , ObjServices.Hist_Seq_No
                       , ObjServices.PaymentId.Value
                       , ObjServices.Language.ToInt()
                   );
                gvFormOfPayment.DataBind();
            }

            udpForOfPayment.Update();
        }

        protected void gvFormOfPayment_RowCommand(object sender, DevExpress.Web.ASPxGridViewRowCommandEventArgs e)
        {
            var Commando = e.CommandArgs.CommandName;

            var RowIndex = e.VisibleIndex;

            var PaymentDetId = int.Parse(gvFormOfPayment.GetKeyFromAspxGridView("PaymentDetId", RowIndex).ToString());
            var PaymentId = int.Parse(gvFormOfPayment.GetKeyFromAspxGridView("PaymentId", RowIndex).ToString());
            var DocumentId = gvFormOfPayment.GetKeyFromAspxGridView("DocumentId", RowIndex).ToInt() == -1 ? (int?)null :
                              int.Parse(gvFormOfPayment.GetKeyFromAspxGridView("DocumentId", RowIndex).ToString());

            var DocumentTypeId = gvFormOfPayment.GetKeyFromAspxGridView("DocumentTypeId", RowIndex).isNullReferenceObject() ? (int?)null :
                               int.Parse(gvFormOfPayment.GetKeyFromAspxGridView("DocumentTypeId", RowIndex).ToString());

            var DocumentCategoryId = gvFormOfPayment.GetKeyFromAspxGridView("DocumentCategoryId").isNullReferenceObject() ? (int?)null :
                   int.Parse(gvFormOfPayment.GetKeyFromAspxGridView("DocumentCategoryId").ToString());


            switch (Commando)
            {
                case "Modify":
                    var datos = ObjServices.oPaymentManager.GetApplyPaymentDetail
                          (
                                  ObjServices.Corp_Id
                                , ObjServices.Region_Id
                                , ObjServices.Country_Id
                                , ObjServices.Domesticreg_Id
                                , ObjServices.State_Prov_Id
                                , ObjServices.City_Id
                                , ObjServices.Office_Id
                                , ObjServices.Case_Seq_No
                                , ObjServices.Hist_Seq_No
                                , ObjServices.PaymentId.Value
                                , PaymentDetId
                                , ObjServices.Language.ToInt()
                          );

                    if (datos != null)
                    {
                        if (datos.Count() > 0)
                        {
                            EditCreditCardEvent(datos.FirstOrDefault());
                            this.ExcecuteJScript("$('#bodyContent_PaymentContainer_WUCFormOfPayment_txtPath').removeAttr('validation')");
                        }
                    }
                    break;
                case "Delete":
                    var data = ObjServices.oPaymentManager.GetApplyPaymentDetail
                          (
                                  ObjServices.Corp_Id
                                , ObjServices.Region_Id
                                , ObjServices.Country_Id
                                , ObjServices.Domesticreg_Id
                                , ObjServices.State_Prov_Id
                                , ObjServices.City_Id
                                , ObjServices.Office_Id
                                , ObjServices.Case_Seq_No
                                , ObjServices.Hist_Seq_No
                                , ObjServices.PaymentId.Value
                                , PaymentDetId
                                , ObjServices.Language.ToInt()
                          );

                    if (data != null && data.Any())
                    {
                        var PaymentDetail = data.FirstOrDefault();
                        PaymentDetail.UserId = ObjServices.UserID.Value;

                        var lIntResult = ObjServices.oPaymentManager.DeletePaymentDetail(PaymentDetail);

                        if (lIntResult == -1) //Indica Exito
                        {
                            this.MessageBox("Informacion de Pago Eliminada con Exito", Title: "Informacion");
                            FillData();
                            RefreshDocumentsEvent();

                            //Inicializar el formulario 
                            var WUCFormOfPayment = (WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCFormOfPayment)this.Page.Master.FindControl("bodyContent")
                                                 .FindControl("PaymentContainer")
                                                 .FindControl("WUCFormOfPayment");
                            //Bmarroquin 17-03-2017 Fix para corregir Bug luego de guardar con exito un registro y posteriormente eleminar el mismo registro, cuando se intentaba guardar un nuevo registro tronaba un FK.. el PaymentID estaba guardando el del registro recien eliminado, ya no existe en la BD!!
                            ObjServices.PaymentId = -1;
                            ObjServices.PaymentDetId = -1;
                            //Fin cambio Bmarroquin 17-03-2017

                            //Bmarroquin 23-03-2017 dado que solo puedo tener un medio de pago, al borrar el actual medio de pago se debe indicar que el tab pago no es valido, Sp [Policy].[SP_SET_PL_PCY_TAB_VALID]
                            ObjServices.saveSetValidTab(Utility.Tab.Payment, false);

                            if (!WUCFormOfPayment.isNullReferenceControl())
                                WUCFormOfPayment.MethodSelectPaymemtForm(-1, -1, -1);

                        }
                        else//Indica Error controlado o desconocido
                        {
                            this.MessageBox("Ocurrio un errro al tratar de eliminar el medio de pago, contactar con personal de TI", Title: "Advertencia");
                        }
                        //Fin Incorporacion Bmarroquin 10-03-2017
                        //Bmarroquin 09-03-2017  Cambio dado que ahora el delete paymentDetail Elimina el encabezado y los detalles asociados al encabezado....
                        /*
                        var payHeader = ObjServices.oPaymentManager.GetPayment
                                          (
                                              ObjServices.Corp_Id
                                            , ObjServices.Region_Id
                                            , ObjServices.Country_Id
                                            , ObjServices.Domesticreg_Id
                                            , ObjServices.State_Prov_Id
                                            , ObjServices.City_Id
                                            , ObjServices.Office_Id
                                            , ObjServices.Case_Seq_No
                                            , ObjServices.Hist_Seq_No
                                            , ObjServices.PaymentId.Value
                                          );

                        payHeader.UserId = ObjServices.UserID.Value;

                        if (payHeader != null)
                        {
                            payHeader.PaymentStatusId = 2;
                            ObjServices.oPaymentManager.UpdatePayment(payHeader);
                        }
                        */
                        //FillData();
                        //RefreshDocumentsEvent();
                    }
                    break;
                case "Upload":

                    hdfPaymentDetailId.Value = PaymentDetId.ToString();

                    if (DocumentId.HasValue)
                    {
                        string documentType = "D";
                        Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation add = new Entity.UnderWriting.Entities.Requirement.OnBaseAditionalInformation()
                        {
                            Contact_ID = ObjServices.Contact_Id
                        };
                        byte[] pdfOnBase = ObjServices.ViewFileFromOnBase(add,documentType, int.Parse(DocumentCategoryId.ToString()), int.Parse(DocumentTypeId.ToString()));

                        if (pdfOnBase == null)
                        {
                            var DocumentBinary = ObjServices.oPaymentManager.GetDocument(
                                                  ObjServices.Corp_Id
                                                , ObjServices.Region_Id
                                                , ObjServices.Country_Id
                                                , ObjServices.Domesticreg_Id
                                                , ObjServices.State_Prov_Id
                                                , ObjServices.City_Id
                                                , ObjServices.Office_Id
                                                , ObjServices.Case_Seq_No
                                                , ObjServices.Hist_Seq_No
                                                , int.Parse(DocumentCategoryId.ToString())
                                                , int.Parse(DocumentTypeId.ToString())
                                                , int.Parse(DocumentId.ToString()));

                            ViewPDF(DocumentBinary.DocumentBinary);
                        }
                        else
                        {
                            ViewPDF(pdfOnBase);
                        }
                    }
                    else
                        UCUploadPaymentDocumentPopUp.UploadFileView();
                    break;
            }
        }

        public void ViewPDF(byte[] PdfFile)
        {
            var UCShowPDFPopup1 = (NewBusiness.UserControls.Common.WUCShowPDFPopup)this.Page.Master.FindControl("WUCShowPDFPopup1");
            var ModalPopUp = (AjaxControlToolkit.ModalPopupExtender)this.Page.Master.FindControl("ModalPopupPDFViewer");
            //var PdfTitle = (Literal)UCShowPDFPopup1.FindControl("ltTypeDoc");
            UCShowPDFPopup1.LoadPDFPreview(PdfFile);
            //PdfTitle.Text = "View Document";
            ModalPopUp.Show();
            this.ExcecuteJScript("$('#pnModalPopupPDFViewer').find('div:first').prepend(CreateNewPopFrame());");
        }

        public void showPopup()
        {
            UCUploadPaymentDocumentPopUp.UploadFileView();
            ModalPopupExtender1.Show();
        }

        public void saveDocument(int PaymentDetId)
        {
            UCUploadPaymentDocumentPopUp.saveDocument(PaymentDetId);
        }

        protected void gvFormOfPayment_PageIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        protected void gvFormOfPayment_PreRender(object sender, EventArgs e)
        {
            ((ASPxGridView)sender).TranslateColumnsAspxGrid();
        }

        public void Translator(string Lang)
        {
            throw new NotImplementedException();
        }
    }
}
