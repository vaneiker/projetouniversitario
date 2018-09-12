using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB.NewBusiness.Common;

namespace WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment
{
    //Bmarroquin 20-02-2017 Container del pago con Tarjetas Debito/Credito 
    public partial class UCContainerTarjetasPagos : UC, IUC
    {
        public void edit() { }
        public void FillData() { }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Translator(string.Empty);
        }

        public void Translator(string Lang){}

        public void Initialize() { }

        public delegate void SelectPaymemtForm(int PaymentSourceId, int PaymentSourceTypeId, int PaymentControlId);
        public event SelectPaymemtForm SelectPaymemtFormEvent;
       
        /*
        public delegate void RefreshPaymentDocuments();
        public event RefreshPaymentDocuments RefreshPaymentDocumentsEvent;
        public delegate void SaveDocumentDetail(int PaymentDetId);
        public event SaveDocumentDetail SaveDocumentDetailEvent;
        */

        #region CONTROLES
        TextBox txtOriginationDate;
        DropDownList ddlFormofPayment;
        DropDownList ddlCardType;
        TextBox txtAccountHolderName;
        TextBox txtBankName;
        TextBox txtAccountNumber;
        TextBox txtRepeatAccountNumber;
        TextBox txtABANumber;
        DropDownList ddlAccountHolderRelationshipOwnerInsured;
        TextBox txtAmount;
        UserControl Controles;
        //Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, se agregan nuevos controles
        DropDownList ddlNombresBancos;
        TextBox txtFecVenTarjeta;
        //Bmarroquin 10-03-2017
        CheckBox chkTarAlternativa; 
        System.Web.UI.HtmlControls.HtmlGenericControl lblTarjetaAlternativa;

        public void setControls()
        {
            switch (hfSelectControls.Value)
            {
                case "VTarjetaPagos":
                    Controles = UCPagoConTarjetas;
                    break;
                default:
                    Controles = UCPagoConTarjetas;
                    break;
            }

            /*BUSCO LOS CONTRLES QUE QUIERO GUARDAR*/
            txtOriginationDate = ((TextBox)Controles.FindControl("txtOriginationDate"));
            ddlFormofPayment = ((DropDownList)Controles.FindControl("ddlFormofPayment"));
            ddlCardType = ((DropDownList)Controles.FindControl("ddlCardType"));
            txtAccountHolderName = ((TextBox)Controles.FindControl("txtAccountHolderName"));
            txtBankName = ((TextBox)Controles.FindControl("txtBankName"));
            txtAccountNumber = ((TextBox)Controles.FindControl("txtAccountNumber"));
            txtRepeatAccountNumber = ((TextBox)Controles.FindControl("txtRepeatAccountNumber"));
            txtABANumber = ((TextBox)Controles.FindControl("txtABANumber"));
            ddlAccountHolderRelationshipOwnerInsured = ((DropDownList)Controles.FindControl("ddlAccountHolderRelationshipOwnerInsured"));
            txtAmount = ((TextBox)Controles.FindControl("txtAmount"));
            //Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, se aregan nuevos controles
            ddlNombresBancos = ((DropDownList)Controles.FindControl("ddlNombresBancos"));
            txtFecVenTarjeta = ((TextBox)Controles.FindControl("txtFecVenTarjeta"));
            //Bmarroquin 10-03-2017
            chkTarAlternativa = ((CheckBox)Controles.FindControl("chkTarAlternativa"));
            lblTarjetaAlternativa = ((System.Web.UI.HtmlControls.HtmlGenericControl)Controles.FindControl("lblTarjetaAlternativa"));
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
                        
            UCPagoConTarjetas._ddlAccountHolderRelationshipOwnerInsured.SelectedIndexChanged += ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged;
            UCPagoConTarjetas._ddlCardType.SelectedIndexChanged += ddlCardType_SelectedIndexChanged;
            UCPagoConTarjetas._ddlFormofPayment.SelectedIndexChanged += ddlFormofPayment_SelectedIndexChanged;
            UCPagoConTarjetas._btnSave.Click += btnSave_Click;
            UCPagoConTarjetas._btnCancel.Click += btnCancel_Click;          
        }

        #region EVENTOS CONTROLES
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();

            //Inicializar el formulario 
            var WUCFormOfPayment = (WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCFormOfPayment)this.Page.Master.FindControl("bodyContent")
                             .FindControl("PaymentContainer")
                             .FindControl("WUCFormOfPayment");

            if (!WUCFormOfPayment.isNullReferenceControl())
                WUCFormOfPayment.MethodSelectPaymemtForm(-1, -1, -1);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
            //RefreshPaymentDocumentsEvent();
        }

        protected void ddlFormofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var drop = (DropDownList)sender;

            if ((drop).SelectedValue != "-1")
            {
                var InsItem = Utility.deserializeJSON<Utility.PaymentSource>((drop).SelectedValue);
                ObjServices.PaymentDetId = new Nullable<int>();
                SelectPaymemtFormEvent(InsItem.PaymentSourceId, InsItem.PaymentSourceTypeId, InsItem.PaymentControlId);
            }
            else
                SelectPaymemtFormEvent(-1, -1, -1);
        }

        protected void ddlCardType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region COMMON METHODS
        public void save()
        {
            setControls();
            //Bmarroquin 17-03-2017 Validar el tamanio en el numero de las tarjetas en payments 
            if (ddlCardType.SelectedValue == "1")
            {
                if (txtAccountNumber.Text.Length != 15)
                {
                    this.MessageBox("Por favor ingrese un numero de tarjeta con 15 digitos", Title: "Advertencia");
                    return;
                }
            }

            if (ddlCardType.SelectedValue == "4" || ddlCardType.SelectedValue == "5")
            {
                if (txtAccountNumber.Text.Length != 16)
                {
                    this.MessageBox("Por favor ingrese un numero de tarjeta con 16 digitos", Title: "Advertencia");
                    return;
                }
            }
            //Fin cambio Bmarroquin 17-03-2017

            //Bmarroquin 27-02-2017 Cambio dado que el DatePicker ahora muestra mes-Anio, Hay que validar la entrada..
            string lStr_FecVenTar, lStr_FecVenTarAlter;
            lStr_FecVenTarAlter = lStr_FecVenTar = "01/";

            if (string.IsNullOrEmpty(txtFecVenTarjeta.Text) == false)
            {
                var lArr_Valores = txtFecVenTarjeta.Text.Split('-');
                if (lArr_Valores.Count() == 2)
                {
                    int lInt_Aux = 0;

                    if (int.TryParse(lArr_Valores[0], out lInt_Aux))
                    {
                        if (lInt_Aux <= 9)
                        {
                            lStr_FecVenTar += "0" + lInt_Aux + "/";
                        }
                        else
                        {
                            lStr_FecVenTar += lInt_Aux.ToString() + "/";
                        }

                        //Verificar el anio
                        if (int.TryParse(lArr_Valores[1], out lInt_Aux))
                        {
                            lStr_FecVenTar += lInt_Aux.ToString();
                        }
                        else
                        {
                            this.MessageBox("Se detecto que el año que ha ingresado es invalido, Favor ingrese una fecha en formato mes-año por ejemplo 06-2030", Title: "Advertencia");
                            return;
                        }

                    }
                    else
                    {
                        this.MessageBox("Se detecto que el mes que ha ingresado es invalido, Favor ingrese una fecha en formato mes-año por ejemplo 05-2017", Title: "Advertencia");
                        return;
                    }
                }
                else
                {
                    this.MessageBox("Favor ingrese una fecha en formato mes-año", Title: "Advertencia");
                    return;
                }
            }
            else
            {
                this.MessageBox("La fecha de vencimiento de la tarjeta, no puede ser nula o vacia por favor ingresese un valor", Title: "Advertencia");
                return;
            }
            //Validar si ingreso una tarjeta Alternativa 
            if (UCPagoConTarjetas._chkTarAlternativa != null)
            {
                if (UCPagoConTarjetas._chkTarAlternativa.Checked)
                {
                    if (Session["objTarjeAlter"] != null)
                    {
                        var ObjTarAlter = (Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail)Session["objTarjeAlter"];
                        if (ObjTarAlter.OrderId == "-99") //Esto me indica que se seteo con exito el objeto
                        {
                            if (string.IsNullOrEmpty(ObjTarAlter.TransactionDescription) == false)
                            {
                                var lArr_Valores = ObjTarAlter.TransactionDescription.Split('-');
                                if (lArr_Valores.Count() == 2)
                                {
                                    int lInt_Aux = 0;

                                    if (int.TryParse(lArr_Valores[0], out lInt_Aux))
                                    {
                                        if (lInt_Aux <= 9)
                                        {
                                            lStr_FecVenTarAlter += "0" + lInt_Aux + "/";
                                        }
                                        else
                                        {
                                            lStr_FecVenTarAlter += lInt_Aux.ToString() + "/";
                                        }

                                        //Verificar el anio
                                        if (int.TryParse(lArr_Valores[1], out lInt_Aux))
                                        {
                                            lStr_FecVenTarAlter += lInt_Aux.ToString();
                                        }
                                        else
                                        {
                                            this.MessageBox("Se detecto que el año que ha ingresado es invalido, Favor ingrese una fecha vencimiento de tarjeta alternativa en formato mes-año por ejemplo 06-2030", Title: "Advertencia");
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        this.MessageBox("Se detecto que el mes que ha ingresado es invalido, Favor ingrese una fecha vencimiento de tarjeta alternativa en formato mes-año por ejemplo 05-2017", Title: "Advertencia");
                                        return;
                                    }
                                }
                                else
                                {
                                    this.MessageBox("Favor ingrese una fecha de vencimiento de la tarjeta alternativa en formato mes-año", Title: "Advertencia");
                                    return;
                                }
                            }
                            else
                            {
                                this.MessageBox("La fecha de vencimiento de la tarjeta alternativa, no puede ser nula o vacia por favor ingresese un valor", Title: "Advertencia");
                                return;
                            }

                        }
                    }
                }
            }
            //Fin cambio Bmarroquin 27-02-2017  


            var InsItem = Utility.deserializeJSON<Utility.PaymentSource>(ddlFormofPayment.SelectedValue);
            bool lbnl_InsertMode = false;

            //Bmarroquin 10-03-2017 Verificar si es modo Edicion, se crea el IF  
            if (ObjServices.PaymentId <= 0)
            {
                Entity.UnderWriting.Entities.Payment.ApplyPayment item = new Entity.UnderWriting.Entities.Payment.ApplyPayment();

                item.CorpId = ObjServices.Corp_Id;
                item.CityId = ObjServices.City_Id;
                item.CountryId = ObjServices.Country_Id;
                item.RegionId = ObjServices.Region_Id;
                item.StateProvId = ObjServices.State_Prov_Id;
                item.DomesticregId = ObjServices.Domesticreg_Id;
                item.OfficeId = ObjServices.Office_Id;
                item.CaseSeqNo = ObjServices.Case_Seq_No;
                item.HistSeqNo = ObjServices.Hist_Seq_No;

                item.DueAmount = 0;
                item.DueDate = DateTime.Now;
                item.PaidAmount = 0;
                item.PaymentStatusId = 2;
                item.UserId = ObjServices.UserID.Value;
                //Bmarroquin 20-03-2017 - Verificar si existe un medio de pago 
                Entity.UnderWriting.Entities.Payment.ApplyPayment lObj_PaymentHd = null;
                lObj_PaymentHd = ObjServices.oPaymentManager.GetPayment(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id, ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No, ObjServices.Hist_Seq_No, -99);
                if (lObj_PaymentHd != null)
                {
                    if (lObj_PaymentHd.PaymentId > 0)
                    {
                        this.MessageBox("Ya existe un medio de pago ingresado para la cotizacion, no se puede continuar.", Title: "Advertencia");
                        return;
                    }
                }
                //Fin Bmarroquin 20-03-2017

                var payReturn = ObjServices.oPaymentManager.InsertPayment(item);
                lbnl_InsertMode = true;

                if (payReturn != null)
                    ObjServices.PaymentId = payReturn.PaymentId;
            }

            if (ObjServices.PaymentId.HasValue && ObjServices.PaymentId > 0)
              {
                //Bmarroquin 20-03-2017 - Verificar si existe un medio de pago 
                var lBnlValidarHeader = false;
                if (ObjServices.PaymentDetId.HasValue == false)
                {
                    lBnlValidarHeader = true;
                }

                if (ObjServices.PaymentDetId <= 0)
                {
                    lBnlValidarHeader = true;
                }

                if (lBnlValidarHeader == true && lbnl_InsertMode == false)
                {
                    Entity.UnderWriting.Entities.Payment.ApplyPayment lObj_PaymentHd = null;
                    lObj_PaymentHd = ObjServices.oPaymentManager.GetPayment(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id, ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No, ObjServices.Hist_Seq_No, -99);
                    if (lObj_PaymentHd != null)
                    {
                        if (lObj_PaymentHd.PaymentId > 0)
                        {
                            this.MessageBox("Ya existe un medio de pago ingresado para la cotizacion, no se puede continuar.", Title: "Advertencia");
                            return;
                        }
                    }
                }
                //Fin Bmarroquin 20-03-2017

                Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail itemDetail = new Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail();

                    itemDetail.CorpId = ObjServices.Corp_Id;
                    itemDetail.CityId = ObjServices.City_Id;
                    itemDetail.CountryId = ObjServices.Country_Id;
                    itemDetail.RegionId = ObjServices.Region_Id;
                    itemDetail.StateProvId = ObjServices.State_Prov_Id;
                    itemDetail.DomesticregId = ObjServices.Domesticreg_Id;
                    itemDetail.OfficeId = ObjServices.Office_Id;
                    itemDetail.CaseSeqNo = ObjServices.Case_Seq_No;
                    itemDetail.HistSeqNo = ObjServices.Hist_Seq_No;
                    itemDetail.PaymentId = ObjServices.PaymentId.Value;
                    
                    itemDetail.Rate = 1; //los pagos son siempre en dolares

                    itemDetail.OriginCreditAmount = 0;
                    itemDetail.OriginDebitAmount = 0;
                    itemDetail.UsdCreditAmount = 0;
                    itemDetail.UsdDebitAmount = 0;
                    itemDetail.PaymentSourceId = InsItem.PaymentSourceId;
                    itemDetail.PaymentSourceTypeId = InsItem.PaymentSourceTypeId;
                    itemDetail.PaymentControlId = InsItem.PaymentControlId;
                    itemDetail.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                    itemDetail.CurrencyId = -1; //Oyeme esto ta fijo aqui pero en realidad tu sabe que se va a poner automaticamente en el procedure donde guarda
                itemDetail.AccountTypeId = int.Parse(ddlCardType.SelectedValue);// 4;// int.Parse(ddlCardType.SelectedValue); // en la tabla [Payments].[PM_PMNTS_DETAILS]  hay una FK a otra tabla sin embargo los tipos de tarjetas de credito se guardan en otra tabla...
                itemDetail.UserId = ObjServices.UserID.Value;
                    itemDetail.DueDate = Utility.IsDateReturnNull(txtOriginationDate.Text);
                    itemDetail.RelationshipToOwnerOrInsured = int.Parse(ddlAccountHolderRelationshipOwnerInsured.SelectedValue);
                    itemDetail.PaymentStatusId = 1;//Approved - Simulo que el pago ya fue hecho, en ESA no se efectuan pagos hasta que se ha emitido la poliza 

                    itemDetail.EFTAccountHolder = txtAccountHolderName.Text.Trim();
                itemDetail.EFTAccountHolderSource = ddlNombresBancos.SelectedValue; 
                    itemDetail.EFTAccountNumber = txtAccountNumber.Text;

                //Estos datos se guardan en la tabla [Policy].[PL_PCY_CARDS]
                itemDetail.ExpireDate = Utility.IsDateReturnNull(lStr_FecVenTar);
                itemDetail.Status = true;
                itemDetail.Name = txtAccountHolderName.Text.Trim();
                itemDetail.Number = txtAccountNumber.Text;

                //Bmarroquin 10-03-2017 Correccion para que se actualize la tarjeta alternativa en la tabla [Policy].[PL_PCY_CARDS] cuando sea modo Edit...
                if (string.IsNullOrWhiteSpace(txtBankName.Text) == false)
                {
                   itemDetail.SeqNo = int.Parse(txtBankName.Text);
                }

                /*
                if (!txtABANumber.isNullReferenceObject())
                    itemDetail.EFTABANumber = txtABANumber.Text;
                */
                int DetailID = 0;
                    if (ObjServices.PaymentDetId.HasValue)
                    {
                        DetailID = ObjServices.PaymentDetId.Value;
                        itemDetail.PaymentDetId = ObjServices.PaymentDetId.Value;
                        ObjServices.oPaymentManager.UpdatePaymentDetail(itemDetail);
                    }
                    else
                    {
                        itemDetail.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                        DetailID = ObjServices.oPaymentManager.InsertPaymentDetail(itemDetail).PaymentDetId;

                    if (DetailID == 0)
                    {
                        this.MessageBox("Ocurrio un error al guardar la informacion del detalle de pago", Title: "Advertencia");
                        return;
                    }

                    //Validar si ingreso una tarjeta Alternativa 
                    if (UCPagoConTarjetas._chkTarAlternativa != null)
                    {
                        if (UCPagoConTarjetas._chkTarAlternativa.Checked)
                        {
                            if (Session["objTarjeAlter"] != null)
                            {
                                var ObjTarAlter = (Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail)Session["objTarjeAlter"];
                                if (ObjTarAlter.OrderId == "-99") //Esto me indica que se seteo con exito el objeto
                                {
                                    ObjTarAlter.CorpId = ObjServices.Corp_Id;
                                    ObjTarAlter.CityId = ObjServices.City_Id;
                                    ObjTarAlter.CountryId = ObjServices.Country_Id;
                                    ObjTarAlter.RegionId = ObjServices.Region_Id;
                                    ObjTarAlter.StateProvId = ObjServices.State_Prov_Id;
                                    ObjTarAlter.DomesticregId = ObjServices.Domesticreg_Id;
                                    ObjTarAlter.OfficeId = ObjServices.Office_Id;
                                    ObjTarAlter.CaseSeqNo = ObjServices.Case_Seq_No;
                                    ObjTarAlter.HistSeqNo = ObjServices.Hist_Seq_No;
                                    ObjTarAlter.PaymentId = ObjServices.PaymentId.Value;

                                    ObjTarAlter.Rate = 1; //los pagos son siempre en dolares

                                    ObjTarAlter.OriginCreditAmount = 0;
                                    ObjTarAlter.OriginDebitAmount = 0;
                                    ObjTarAlter.UsdCreditAmount = 0;
                                    ObjTarAlter.UsdDebitAmount = 0;
                                    ObjTarAlter.PaymentSourceId = InsItem.PaymentSourceId;
                                    ObjTarAlter.PaymentSourceTypeId = InsItem.PaymentSourceTypeId;
                                    ObjTarAlter.PaymentControlId = InsItem.PaymentControlId;
                                    ObjTarAlter.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                                    ObjTarAlter.CurrencyId = -1; //Oyeme esto ta fijo aqui pero en realidad tu sabe que se va a poner automaticamente en el procedure donde guarda
                                    //ObjTarAlter.AccountTypeId = int.Parse(ddlCardType.SelectedValue);// 4;// int.Parse(ddlCardType.SelectedValue); 
                                    ObjTarAlter.UserId = ObjServices.UserID.Value;
                                    ObjTarAlter.DueDate = Utility.IsDateReturnNull(txtOriginationDate.Text);
                                    ObjTarAlter.PaymentStatusId = 1;//Approved - Simulo que el pago ya fue hecho, en ESA no se efectuan pagos hasta que se ha emitido la poliza 
                                    ObjTarAlter.PaymentDetailSourceId = System.Guid.NewGuid().ToString();
                                    ObjTarAlter.OrderId = null; //PAra que no truene
                                    ObjTarAlter.ExpireDate = Utility.IsDateReturnNull(lStr_FecVenTarAlter);
                                    ObjServices.oPaymentManager.InsertPaymentDetail(ObjTarAlter);
                                }
                            }
                        }
                    }

                }

                //Bmarroquin 21-03-2017 cambio de lugar el udpate del cliente para que lo haga hasta el final 
                //Colocamos de forma fija en el parametro contactRoleType un 1 el cual es para el contacto propietario OWNER ponerle la relacion  si es un hijo etc.
                var contact = ObjServices.oContactManager.GetContact(ObjServices.Corp_Id, ObjServices.Region_Id, ObjServices.Country_Id, ObjServices.Domesticreg_Id, ObjServices.State_Prov_Id, ObjServices.City_Id, ObjServices.Office_Id, ObjServices.Case_Seq_No, ObjServices.Hist_Seq_No, null, 1, ObjServices.Language.ToInt());
                if (contact != null)
                {
                    this.SetContactInfo(contact);
                }

                //El tab de payment esta completado, No es necesario realizar Pago alguno 
                ObjServices.saveSetValidTab(Utility.Tab.Payment);

                //Bmarroquin 26-02-2017 Usuarios desean ver un msj cuando se guardaron los datos 
                this.MessageBox("Los Datos se Guardaron Correctamente", Title: "Informacion");

                //Inicializar el formulario 
                var WUCFormOfPayment = (WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCFormOfPayment)this.Page.Master.FindControl("bodyContent")
                                     .FindControl("PaymentContainer")
                                     .FindControl("WUCFormOfPayment");

                    if (!WUCFormOfPayment.isNullReferenceControl())
                        WUCFormOfPayment.MethodSelectPaymemtForm(-2, -2, -2); //Bmarroquin 13-03-2017 Con esto indico que no se habilite el dropDownList Medio de pago...

                    ClearData();
                }
                else
                {
                    this.MessageBox("Ocurrio un error al guardar la informacion inicial del pago", Title: "Advertencia");
                    return;
                }
               
        }
        /// <summary>
        /// aqui es donde veo que control debo de llenar  por defecto estare UCACHDOMICILE
        /// </summary>
        public void FillDataSelectControl(String SelectControles, int PaymentSourceId, int PaymentSourceTypeId
            , int PaymentControlId, Entity.UnderWriting.Entities.Payment.ApplyPaymentDetail Payment = null)
        {
            /*AQUI BUSCO QUE CONTROL DEBO PRESENTAR PRIMERO*/
            ClearData();
            switch (SelectControles)
            {
                 case "VTarjetaPagos":
                    MVTarjetaPagos.SetActiveView(VTarjetaPagos);
                    hfSelectControls.Value = "VCargoAutomatico";
                    break;
                default:
                    MVTarjetaPagos.SetActiveView(VTarjetaPagos);
                    hfSelectControls.Value = "VTarjetaPagos";
                    break;
            }

            /*BUSCO LOS OBJECTOS QUE NECESITO LLENAR DEL CONTROL SELECCIONADO*/
            setControls();

            ObjServices.GettingAllDropsJSON(ref ddlFormofPayment, WEB.NewBusiness.Common.Utility.DropDownType.PaymentSource, "PaymentSourceDesc"

                    , corpId: ObjServices.Corp_Id
                    , regionId: ObjServices.Region_Id
                    , countryId: ObjServices.Country_Id
                    , domesticregId: ObjServices.Domesticreg_Id
                    , stateProvId: ObjServices.State_Prov_Id
                    , cityId: ObjServices.City_Id
                    , officeId: ObjServices.Office_Id
                    , caseSeqNo: ObjServices.Case_Seq_No
                    , histSeqNo: ObjServices.Hist_Seq_No
                    , appliedByFreqOrCountry: true
                );

            string x2 = "{\"PaymentSourceId\":{1},\"PaymentSourceTypeId\":{2},\"PaymentControlId\":{3}}"
                     .Replace("{1}", PaymentSourceId.ToString())
                     .Replace("{2}", PaymentSourceTypeId.ToString())
                     .Replace("{3}", PaymentControlId.ToString())
                     ;

            ddlFormofPayment.SelectIndexByValueJSON(x2);


            if (ddlAccountHolderRelationshipOwnerInsured != null)
            {
                ObjServices.GettingAllDrops(ref ddlAccountHolderRelationshipOwnerInsured,
                                    Utility.DropDownType.RelationshipPayment,
                                   "RelationshipDesc",
                                   "RelationshipId",
                                    GenerateItemSelect: true
                                   );
            }

            if (ddlCardType != null)
            {
                ObjServices.GettingAllDrops(ref ddlCardType,
                                        Utility.DropDownType.PaymentType,
                                        "CardTypeDesc",
                                        "CardTypeId",
                                        GenerateItemSelect: true,
                                        PaymentSourceId: PaymentSourceId,
                                        PaymentSourceTypeId: PaymentSourceTypeId,
                                        corpId: ObjServices.Corp_Id
                                   );
            }

            //Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, se agregan nuevas lineas
            if (ddlNombresBancos != null)
            {
                ObjServices.GettingAllDrops(ref ddlNombresBancos,
                        Utility.DropDownType.BankList,
                        "BankDesc",
                        "BankId",
                        GenerateItemSelect: true,
                        countryId: ObjServices.Country_Id
                   );
            }
              
            if (!ObjServices.IsDataReviewMode)
            {
                if (txtOriginationDate != null)
                    txtOriginationDate.Text = DateTime.Now.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
            }

            /*esto quiere decir el pago esta en modo de editar*/
            if (Payment != null)
            {
                ObjServices.PaymentDetId = Payment.PaymentDetId;
                ObjServices.PaymentId = Payment.PaymentId;

                ddlCardType.SelectIndexByValue(Payment.AccountTypeId.ToString());

                if (Payment.OriginCreditAmount.HasValue)
                    txtAmount.Text = Payment.OriginCreditAmount.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo);

                txtOriginationDate.Text = Payment.PaidDate.HasValue ? Payment.PaidDate.Value.ToString() : txtOriginationDate.Text;

                ddlAccountHolderRelationshipOwnerInsured.SelectIndexByValue(Payment.RelationshipToOwnerOrInsured.ToString());


                if (string.IsNullOrEmpty(Payment.EFTAccountHolder) == false)
                    txtAccountHolderName.Text = Payment.EFTAccountHolder;


                if (string.IsNullOrEmpty(Payment.EFTAccountHolderSource) == false)
                    ddlNombresBancos.SelectedValue = Payment.EFTAccountHolderSource; //Bmarroquin 10-03-2017 Agregado para que se muestre el name del banco
                    //txtBankName.Text = Payment.EFTAccountHolderSource;


                if (string.IsNullOrEmpty(Payment.EFTAccountNumber) == false)
                {
                    txtAccountNumber.Text = Payment.EFTAccountNumber;
                    txtRepeatAccountNumber.Text = Payment.EFTAccountNumber;
                }

                if (string.IsNullOrEmpty(Payment.EFTABANumber) == false)
                    if (txtABANumber != null)
                        txtABANumber.Text = Payment.EFTABANumber;

                if (txtFecVenTarjeta != null)
                    //Bmarroquin 10-03-2017 Formatear la fecha a Mes-Anio !!
                    if (Payment.ExpireDate.HasValue)
                    {

                        var mes = Payment.ExpireDate.Value.Month;
                        var anio = Payment.ExpireDate.Value.Year;
                        var lAux = "";
                        if (mes <= 9)
                        {
                            lAux = "0" + mes + "-";
                        }
                        else
                        {
                            lAux = mes + "-";
                        }
                        txtFecVenTarjeta.Text = lAux + anio.ToString();
                    }

                //Bmarroquin 10-03-2017 Comento codigo 
                //readOnly(!(Payment.PaymentStatusId == 1));

                //Bmarroquin 10-03-2017 Mejora para que se guarde el Card Secuence Number de la tarjeta Alternativa si existe, aplica solo pagos con tarjetas y Cargo Automatico...
                if (Payment.SeqNo.HasValue)
                  txtBankName.Text = Payment.SeqNo.ToString();

                //No mostrar el cotrol de Tarjeta Alternativa
                lblTarjetaAlternativa.Visible = false;
                chkTarAlternativa.Visible = false;
            }
            else
            {
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
                       , ObjServices.PaymentId.HasValue ? ObjServices.PaymentId.Value : -1
                   );

                if (paymentHeader != null)
                {
                    if (paymentHeader.PaymentStatusId == 1)
                        readOnly(false);
                    else
                        readOnly(true);
                }
                else
                    readOnly(true);
            }
        }

        public void readOnly(bool Enabled = true)
        {
            setControls();
            UCPagoConTarjetas.activeSaveButton(Enabled);

            txtOriginationDate.Enabled = Enabled;
            txtAccountHolderName.Enabled = Enabled;

            txtAccountNumber.Enabled = Enabled;
            txtRepeatAccountNumber.Enabled = Enabled;

            if (txtABANumber != null)
                txtABANumber.Enabled = Enabled;

            if (txtAmount != null)
                txtAmount.Enabled = Enabled;

            if (ddlFormofPayment != null)
                ddlFormofPayment.Enabled = Enabled;


            if (ddlCardType != null)
                ddlCardType.Enabled = Enabled;


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.Enabled = Enabled;

            //Bmarroquin 11 - 02 - 2017 a raiz de tropicalizacion de ESA, se aregan nuevas lineas
            if (ddlNombresBancos != null)
                ddlNombresBancos.Enabled = Enabled;

            if (txtFecVenTarjeta != null)
                txtFecVenTarjeta.Enabled = Enabled;

        }

        public void ClearData()
        {
            setControls();
            txtOriginationDate.Text = string.Empty;
            txtAccountHolderName.Text = string.Empty;
            txtBankName.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;
            txtRepeatAccountNumber.Text = string.Empty;

            if (txtABANumber != null)
                txtABANumber.Text = string.Empty;

            if (txtAmount != null)
                txtAmount.Text = string.Empty;

            if (ddlFormofPayment != null)
                ddlFormofPayment.SelectIndexByValue("-1");


            if (ddlCardType != null)
                ddlCardType.SelectIndexByValue("-1");


            if (ddlAccountHolderRelationshipOwnerInsured != null)
                ddlAccountHolderRelationshipOwnerInsured.SelectIndexByValue("-1");

            //Bmarroquin 11 - 02 - 2017 a raiz de tropicalizacion de ESA, se aregan nuevas lineas
            if (ddlNombresBancos != null)
                ddlNombresBancos.SelectIndexByValue("-1");
        }

        #endregion

        public void ReadOnlyControls(bool isReadOnly)
        {
            Utility.ReadOnlyControls(this.Controls, isReadOnly);
        }
        private bool SetContactInfo(Entity.UnderWriting.Entities.Contact contact)
        {
            var result = false;
            var relationShipToOwner = !string.IsNullOrEmpty(ddlAccountHolderRelationshipOwnerInsured.SelectedValue) ? ddlAccountHolderRelationshipOwnerInsured.SelectedValue.ToInt() : 0;
            contact.RelationshiptoOwner = relationShipToOwner;
            ObjServices.oContactManager.UpdateContact(contact);
            return result;
        }
    }
}