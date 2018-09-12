using RESOURCE.UnderWriting.NewBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.Payment
{
    public partial class WUCFormOfPayment : UC, IUC
    {
        public void ClearData() { }
        public void Initialize() { }
        public void save(){}
        public void readOnly(bool x){}
        public void edit(){}

        object ControlSelect;

        public class item
        {
            public string PaymentDocumentation { get; set; }
        }

        public delegate void SelectPaymemtFormOfPayment(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId);
        public event SelectPaymemtFormOfPayment SelectPaymemtFormOfPaymentEvent;
        public delegate void RefreshPaymentInformations();
        public event RefreshPaymentInformations RefreshPaymentInformationsEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            UCContainerTransfer.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerTransfer.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerACH.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerACH.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerCC.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerCC.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerCash.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerCash.SelectPaymemtForm(MethodSelectPaymemtForm); 
            UCContainerBasicPayment.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerBasicPayment.SelectPaymemtForm(MethodSelectPaymemtForm);        
            UCContainerTransfer.SaveDocumentDetailEvent += new AddNewClient.Payment.UCContainerTransfer.SaveDocumentDetail(SaveDocumentDetail);
            UCContainerACH.SaveDocumentDetailEvent += new AddNewClient.Payment.UCContainerACH.SaveDocumentDetail(SaveDocumentDetail);
            UCContainerCC.SaveDocumentDetailEvent += new AddNewClient.Payment.UCContainerCC.SaveDocumentDetail(SaveDocumentDetail);
            UCContainerCash.SaveDocumentDetailEvent += new AddNewClient.Payment.UCContainerCash.SaveDocumentDetail(SaveDocumentDetail);         
            UCContainerCC.RefreshPaymentDocumentsEvent += new AddNewClient.Payment.UCContainerCC.RefreshPaymentDocuments(RefreshPaymentDocuments);
            UCContainerACH.RefreshPaymentDocumentsEvent += new AddNewClient.Payment.UCContainerACH.RefreshPaymentDocuments(RefreshPaymentDocuments);
            UCContainerTransfer.RefreshPaymentDocumentsEvent += new AddNewClient.Payment.UCContainerTransfer.RefreshPaymentDocuments(RefreshPaymentDocuments);
            UCContainerCash.RefreshPaymentDocumentsEvent += new AddNewClient.Payment.UCContainerCash.RefreshPaymentDocuments(RefreshPaymentDocuments); 
            UCUploadDocumentOfPayments.RefreshDocumentsEvent += new AddNewClient.Payment.UCUploadDocumentOfPayments.RefreshDocuments(RefreshPaymentDocuments);           
            UCUploadDocumentOfPayments.EditCreditCardEvent += new AddNewClient.Payment.UCUploadDocumentOfPayments.EditCreditCard(EditCreditCard);                                                                                                                                                    
            UCUploadDocumentOfPayments.RefreshDocumentPath2Event += new AddNewClient.Payment.UCUploadDocumentOfPayments.RefreshDocumentPath2(RefreshDocumentPath);           

            //Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, se incorpora las lineas abajo expuestas para procesar los pagos de ESA
            UCContainerCargoAutomatico.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerCargoAutomatico.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerTarjetasPagos.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerTarjetasPagos.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerPagoNPE.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerPagoNPE.SelectPaymemtForm(MethodSelectPaymemtForm);
            UCContainerPagoCheque.SelectPaymemtFormEvent += new AddNewClient.Payment.UCContainerPagoCheque.SelectPaymemtForm(MethodSelectPaymemtForm);

        }

        #region Eventos Controles hijos
        public void RefreshPaymentDocuments()
        {
            UCUploadDocumentOfPayments.FillData();
            RefreshPaymentInformationsEvent();
        }

        private void SelectView(string Key, int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId, Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail Payment = null)
        {
            switch (Key)
            {
                case "611":
                    MVPaymentForm.SetActiveView(VContainerCash);
                    UCContainerCash.FillDataSelectControl("VCash", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerCash;
                    break;
                case "112":
                    MVPaymentForm.SetActiveView(VContainerACH);
                    UCContainerACH.FillDataSelectControl("VACHDomicile", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerACH;
                    break;
                case "111":
                    MVPaymentForm.SetActiveView(VContainerACH);
                    UCContainerACH.FillDataSelectControl("VCACHOneTime", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerACH;
                    break;
                case "122":
                    MVPaymentForm.SetActiveView(VContainerACH);
                    UCContainerACH.FillDataSelectControl("VACHStbDomicile", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerACH;
                    break;
                case "121":
                    MVPaymentForm.SetActiveView(VContainerACH);
                    UCContainerACH.FillDataSelectControl("VACHStbOnetime", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerACH;
                    break;
                case "212":
                    MVPaymentForm.SetActiveView(VContainerCC);
                    UCContainerCC.FillDataSelectControl("VAContainerCCDomicile", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerCC;
                    break;
                case "211":
                    MVPaymentForm.SetActiveView(VContainerCC);
                    UCContainerCC.FillDataSelectControl("VAContainerCCOneTime", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerCC; ;
                    break;
                case "411":
                    MVPaymentForm.SetActiveView(VContainerTransfer);
                    UCContainerTransfer.FillDataSelectControl("VAContainerTransferCheck", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerTransfer;
                    break;
                case "521":
                    MVPaymentForm.SetActiveView(VContainerTransfer);
                    UCContainerTransfer.FillDataSelectControl("VAContainerTransferWire", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerTransfer;
                    break;
                case "531":
                    MVPaymentForm.SetActiveView(VContainerTransfer);
                    UCContainerTransfer.FillDataSelectControl("VAContainerTransferWirePromise", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerTransfer;
                    break;
                //Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, se incorpora las lineas abajo expuestas para procesar los pagos de ESA
                //Nota: el Key es la PK y FK de la tabla [Payments].[PM_PAYMENTS_SOURCE] los campos: PaymentSourceId, PaymentSourceTypeId y PaymentControlId
                case "323": //Cargo Automatico
                    MVPaymentForm.SetActiveView(VCargoAutomatico);
                    UCContainerCargoAutomatico.FillDataSelectControl("VCargoAutomatico", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerCargoAutomatico;
                    break;
                case "333": //Pago con Tarjetas
                    MVPaymentForm.SetActiveView(VTarjetaPagos);
                    UCContainerTarjetasPagos .FillDataSelectControl("VTarjetaPagos", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerTarjetasPagos;
                    break;
                case "723": //Pago con NPE
                    MVPaymentForm.SetActiveView(VPagoNPE);
                    UCContainerPagoNPE.FillDataSelectControl("VPagoNPE", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerPagoNPE;
                    break;
                case "413"://Pago con Cheque
                    MVPaymentForm.SetActiveView(VPagoCheque);
                    UCContainerPagoCheque.FillDataSelectControl("VPagoCheque", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerPagoCheque;
                    break;
                default:
                    MVPaymentForm.SetActiveView(VContainerBasicPayment);
                    UCContainerBasicPayment.FillDataSelectControl("VContainerBasicPayment", PaymentSourceId, PaymentSourceTypeId, PaymentControlId, Payment);
                    ControlSelect = UCContainerTransfer;
                    break;
            }
        }

        /// <summary>
        /// AQUI CAMBIA LA PARTE DECHA DEPENDIENDO EL LA FORMA DE PAGO 
        ///Payment_Source_Type_Id	Payment_Source_Id	Payment_Control_Id	Payment_Source_Desc	Code_Name
        ///1	1	1	ACH One Time	ACHOneTime
        ///1	1	2	ACH Domicile	ACHDomicile
        ///1	2	1	ACH Statetrust Bank One Time	ACHStatetrustBankOneTime
        ///1	2	2	ACH Statetrust Bank Domicile	ACHStatetrustBankDomicile
        ///2	1	1	Credit Card One Time	CreditCardOneTime
        ///2	1	2	Credit Card Domicile	CreditCardDomicile
        ///4	1	1	Check One Time	CheckOneTime
        ///5	2	1	Wire	Wire
        ///5	3	1	Wire Promise	WirePromise
        /// </summary>
        /// <param name="PaymentSourceId"></param>
        public void MethodSelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId)
        {
            string Key = PaymentSourceTypeId.ToString() + PaymentSourceId.ToString() + PaymentControlId.ToString();
            SelectView(Key, PaymentSourceId, PaymentSourceTypeId, PaymentControlId);
            SelectPaymemtFormOfPaymentEvent(PaymentSourceId, PaymentSourceTypeId, PaymentControlId);
        }

        /// <summary>
        /// AQUI CAMBIA LA PARTE DECHA DEPENDIENDO EL LA FORMA DE PAGO 
        ///Payment_Source_Type_Id	Payment_Source_Id	Payment_Control_Id	Payment_Source_Desc	Code_Name
        ///1	1	1	ACH One Time	ACHOneTime
        ///1	1	2	ACH Domicile	ACHDomicile
        ///1	2	1	ACH Statetrust Bank One Time	ACHStatetrustBankOneTime
        ///1	2	2	ACH Statetrust Bank Domicile	ACHStatetrustBankDomicile
        ///2	1	1	Credit Card One Time	CreditCardOneTime
        ///2	1	2	Credit Card Domicile	CreditCardDomicile
        ///4	1	1	Check One Time	CheckOneTime
        ///5	2	1	Wire	Wire
        ///5	3	1	Wire Promise	WirePromise
        /// </summary>
        /// <param name="PaymentSourceId"></param>
        public void EditCreditCard(Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail datos)
        {
            string Key = datos.PaymentSourceTypeId.ToString() + datos.PaymentSourceId.ToString() + datos.PaymentControlId.ToString();
            SelectView(Key, datos.PaymentSourceId.Value, datos.PaymentSourceTypeId, datos.PaymentControlId, datos);
            /* Bmarroquin 10-03-2017 comento codigo
            if (datos.PaymentStatusId == 1)
            {
                btnAttach.Enabled = false;
                MultiView1.SetActiveView(vInactive);
            }
            else
            {
                btnAttach.Enabled = true;
                MultiView1.SetActiveView(vActive);
            }
            */
        }
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
           
        }

        #region Eventos Comunes
        public void Translator(string Lang)
        {
            FormOfPayment.InnerHtml = Resources.FormOfPayment.ToUpper();
            Upload.InnerHtml = Resources.UPLOAD.Capitalize();
            btnAttach.Text = Resources.Attach;
            btnProcessPayment2.Text = Resources.Attach;
            if (isChangingLang)
                UCUploadDocumentOfPayments.Initialize();
        }

        public void FillData()
        {
            MethodSelectPaymemtForm(-1, -1,-1);

            UCUploadDocumentOfPayments.Initialize();

            var paymentHeader = ObjServices.oPaymentManager.GetPayment
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

            if (paymentHeader != null)
            {
                if (paymentHeader.PaymentStatusId == 1)
                {
                    btnAttach.Enabled = false;
                    MultiView1.SetActiveView(vInactive);
                }
                else
                {
                    btnAttach.Enabled = true;
                    MultiView1.SetActiveView(vActive);
                }

            }
            else
            {
                btnAttach.Enabled = true;
                MultiView1.SetActiveView(vActive);
            }
        }
        #endregion

        #region SaveDocuments
        public void RefreshDocumentPath(string Path)
        {
            txtPath.Text = Path;
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            txtPath.Text = string.Empty;
            UCUploadDocumentOfPayments.showPopup();
        }

        public void SaveDocumentDetail(int PaymentDetId)
        {
            UCUploadDocumentOfPayments.saveDocument(PaymentDetId);
            txtPath.Text = string.Empty;
        }

        #endregion

        public void ReadOnlyControls(bool isReadOnly)
        {
            var typeClass = ControlSelect.GetType();
            var method = typeClass.GetMethod("ReadOnlyControls");
            method.Invoke(ControlSelect, new object[1] { isReadOnly });
            UCUploadDocumentOfPayments.hideColumn();
        }
    }
}