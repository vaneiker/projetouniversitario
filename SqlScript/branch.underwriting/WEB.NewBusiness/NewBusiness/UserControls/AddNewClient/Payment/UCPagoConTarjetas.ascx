<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPagoConTarjetas.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCPagoConTarjetas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%--Bmarroquin 26-02-2017 cambio para que el DatePicker de la fecha de vencimiento Tarjeta solo muestre Mes-Anio--%>
<style>
.ui-datepicker-calendar 
{
  display: none;
}
</style>

<div class="content_fondo_blanco" id="frmPay">
    <div class="grupos de_2">
        <div>
            <label class="label" runat="server" id="OriginationDate">Origination Date</label>
            <asp:TextBox ID="txtOriginationDate" runat="server" class="datepicker" ReadOnly="true" disabled></asp:TextBox>
        </div>
    </div>
    <!--grupos-->

    <div class="grupos de_2">
        <div>
            <label class="label" runat="server" id="FormofPayment">Form of Payment</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlFormofPayment" AutoPostBack="true" runat="server" validation="Required" OnSelectedIndexChanged="ddlFormofPayment_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label" runat="server" id="PaymentType">Payment Type</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlCardType" runat="server" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" validation="Required"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label" runat="server" id="AccountHolderName">Account Holder Name</label>
            <asp:TextBox ID="txtAccountHolderName" runat="server" validation="Required"></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="BankName">Bank Name</label>
            <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA,  los bancos se cargaran desde la BD--%>
            <asp:TextBox ID="txtBankName" runat="server" ClientIDMode="Static" Enabled="false" Visible="false"></asp:TextBox>
            <div class="wrap_select">
              <asp:DropDownList ID="ddlNombresBancos" runat="server" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" validation="Required"></asp:DropDownList>
            </div>
        </div>
        <div>
            <label class="label" runat="server" id="AccountNumber">Numero de Tarjeta</label>
             <%--Bmarroquin 16-03-2017 para que solo se puedan ingresar numeros enteros, se agrega class NumTarjetaFormat--%>
            <asp:TextBox ID="txtAccountNumber" runat="server" validation="Required" MaxLength="16" class="NumTarjetaFormat"></asp:TextBox>
        </div>
        <div style="display:none">
            <label class="label" runat="server" id="RepeatAccountNumber">Repeat Account Number</label>
            <asp:TextBox ID="txtRepeatAccountNumber" runat="server"  ClientIDMode="Static"></asp:TextBox>
        </div>
         <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, el ABA no se utiliza en el pais, se oculta todo el DIV--%>
        <div style="display:none;">
            <label class="label" runat="server" id="ABANumber">ABA Number</label>
            <asp:TextBox ID="txtABANumber" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, no se necesita el monto no se hace pago antes de emitir la poliza en el pais, se oculta todo el DIV--%>
        <div style="display:none;">
            <label class="label" runat="server" id="Amount">Amount</label>
            <asp:TextBox ID="txtAmount" runat="server" decimal="decimal"></asp:TextBox>
        </div>
        <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, Para pagos con tarjeta es necesario validar la fecha de vencimiento--%>
       <div>
            <label class="label" runat="server" id="lblFechaVenTarjeta">Fecha Vencimiento de Tarjeta</label>
             <%--Bmarroquin 26-02-2017 cambio para que el DatePicker de la fecha de vencimiento Tarjeta solo muestre Mes-Anio--%>
            <asp:TextBox ID="txtFecVenTarjeta" runat="server" validation="Required"  class="datePicker_2"></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="AccountHolderRelationshipOwnerInsured">AccountHolder Relationship/Owner/Insured</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlAccountHolderRelationshipOwnerInsured" runat="server" validation="Required" OnSelectedIndexChanged="ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label" runat="server" id="lblTarjetaAlternativa">Tarjeta Alternativa</label>
            <asp:CheckBox ID="chkTarAlternativa" runat="server" Checked="false" AutoPostBack="true" OnCheckedChanged="chkTarAlternativa_CheckedChanged"></asp:CheckBox>
        </div>
    </div>
    <!--grupos-->

    <div class="grupos de_1" id="divSave">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="vActive" runat="server">
                    <div class="boton_wrapper verde float_right">
                        <span class="save"></span>
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="boton" OnClick="btnSave_Click" OnClientClick="return validateForm('frmPay')" />
                    </div>
                    <div class="boton_wrapper gris float_right" style="display: block; margin-right: 10px;">
                        <span class="borrar"></span>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="boton" Style="height: 26px" OnClick="btnCancel_Click" />
                    </div>
                </asp:View>
                <asp:View ID="vInactive" runat="server">
                    <div class="boton_wrapper inactive float_right">
                        <span class="process_inactive"></span>
                        <asp:Button CssClass="aspNetDisabled boton" Text="Save" runat="server" ID="btnProcessPayment2" Enabled="false" disabled="disabled" />
                    </div>

                    <div class="boton_wrapper inactive float_right" style="margin-right: 10px;">
                        <span class="process_inactive"></span>
                        <asp:Button CssClass="aspNetDisabled boton" Text="Cancel" runat="server" ID="btnCancel2" Enabled="false" disabled="disabled" />
                    </div>
                </asp:View>
            </asp:MultiView>

            <!--boton_wrapper-->
        </div>
    </div>
    <!--grupos-->

<asp:Button ID="btnShowPopup" Style="display: none" runat="server" Text="ShowPopup" />
<Ajax:ModalPopupExtender ID="mpePopUpTarjeAlter" PopupControlID="pnlFormTarjetaAlter" DropShadow="false" BackgroundCssClass="ModalBackgroud3"
     TargetControlID="btnShowPopup" BehaviorID="popupBhvr" runat="server" >
</Ajax:ModalPopupExtender>
<asp:Panel runat="server" ID="pnlFormTarjetaAlter" CssClass="modalPopup" ClientIDMode="Static">
  <div class="content_fondo_blanco">
    <div class="grid_wrap margin_t_10 gris">

       <div class="pop_up_wrapper" style="width: 812px; height: 590px;">
          <div class="titulos_azules">
            <strong runat="server" id="DocumentView">TARJETA ALTERNATIVA</strong>
          </div>
          <!--titulos_azules-->
          <div class="content_fondo_blanco">
       <div class="grupos de_1" id="frmTarAlter">

        <div>
            <label class="label" runat="server" id="PaymentType2">Payment Type</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlCardType2" runat="server" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" validation2="Required2"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label" runat="server" id="AccountHolderName2">Account Holder Name</label>
            <asp:TextBox ID="txtAccountHolderName2" runat="server" validation2="Required2"></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="BankName2">Bank Name</label>
            <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA,  los bancos se cargaran desde la BD--%>
            <asp:TextBox ID="txtBankName2" runat="server" ClientIDMode="Static" Enabled="false" Visible="false"></asp:TextBox>
            <div class="wrap_select">
              <asp:DropDownList ID="ddlNombresBancos2" runat="server" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" validation2="Required2"></asp:DropDownList>
            </div>
        </div>
        <div>
            <label class="label" runat="server" id="AccountNumber2">Numero de Tarjeta</label>
            <%--Bmarroquin 16-03-2017 para que solo se puedan ingresar numeros enteros, se agrega class NumTarjetaFormat--%>
            <asp:TextBox ID="txtAccountNumber2" runat="server" validation2="Required2" MaxLength="16" class="NumTarjetaFormat"></asp:TextBox>
        </div>

        <%--Bmarroquin 11-02-2017 a raiz de tropicalizacion de ESA, Para pagos con tarjeta es necesario validar la fecha de vencimiento--%>
       <div>
            <label class="label" runat="server" id="lblFechaVenTarjeta2">Fecha Vencimiento de Tarjeta</label>
            <%--Bmarroquin 26-02-2017 cambio para que el DatePicker de la fecha de vencimiento Tarjeta solo muestre Mes-Anio--%>
            <asp:TextBox ID="txtFecVenTarjeta2" runat="server" validation2="Required2"  class="datePicker_2"></asp:TextBox>
        </div>
        <div>
            <label class="label" runat="server" id="AccountHolderRelationshipOwnerInsured2">AccountHolder Relationship/Owner/Insured</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlAccountHolderRelationshipOwnerInsured2" runat="server" validation2="Required2" OnSelectedIndexChanged="ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>

     <div class="grupos de_1" id="divSave">
        <div>
            <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="boton_wrapper verde float_right">
                        <span class="save"></span>
                        <asp:Button ID="btnSaveTarAlter" runat="server" Text="Save" class="boton" OnClick="btnSaveTarAlter_Click" OnClientClick="return validateForm2('frmTarAlter')" />
                    </div>
                    <div class="boton_wrapper gris float_right" style="display: block; margin-right: 10px;">
                        <span class="borrar"></span>
                        <asp:Button ID="btnCancelTarAlter" runat="server" Text="Cancel" class="boton" Style="height: 26px" OnClick="btnCancelTarAlter_Click" />
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="boton_wrapper inactive float_right">
                        <span class="process_inactive"></span>
                        <asp:Button CssClass="aspNetDisabled boton" Text="Save" runat="server" ID="Button3" Enabled="false" disabled="disabled" />
                    </div>

                    <div class="boton_wrapper inactive float_right" style="margin-right: 10px;">
                        <span class="process_inactive"></span>
                        <asp:Button CssClass="aspNetDisabled boton" Text="Cancel" runat="server" ID="Button4" Enabled="false" disabled="disabled" />
                    </div>
                </asp:View>
            </asp:MultiView>

            <!--boton_wrapper-->
        </div>
     </div>

      </div>  
              <!--PDF -->
             <div style="background-color: #EEE;">
             </div>
             <!--// PDF -->
             <asp:Panel runat="server" ID="pnCloseButton" Visible="false" >
                    <div class="grupos">
                        <div class="float_right">
                            <div class="boton_wrapper rojo">
                                <span class="equis"></span>
                                <asp:Button ID="CloseBtn" runat="server" Text="Close" class="boton" OnClientClick="return ClosePaymentPDFPop();" />
                            </div>
                        </div>
                    </div>
                    <!--// Botones -->
                </asp:Panel>

            </div>
            <!--// cont -->
        </div>        
          
    </div>
  </div>


</asp:Panel>

    <!--grid_wrap-->
</div>
