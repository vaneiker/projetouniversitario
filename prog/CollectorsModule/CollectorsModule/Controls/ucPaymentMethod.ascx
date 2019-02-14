<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPaymentMethod.ascx.cs" Inherits="CollectorsModule.Controls.ucPaymentMethod" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="contenido">
    <div class="procesar_pg">
        <div class="bdrRadius20">
            <div class="cont_gnl ach">
                <div class="label_plus_input par mB20 mT10">
                    <span class="azul_pl">Forma de Pago</span>
                    <asp:DropDownList runat="server" ID="ddlPaymentForm" ClientIDMode="Static" OnSelectedIndexChanged="ddlPaymentForm_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text="Tarjeta debito/crédito" Value="CreditCard"></asp:ListItem>
                        <%--<asp:ListItem Text="Efectivo" Value="Cash"></asp:ListItem>--%>
                        <asp:ListItem Text="Cheque" Value="Check"></asp:ListItem>
                        <asp:ListItem Text="ACH" Value="ACH"></asp:ListItem>
                        <asp:ListItem Text="Depósito" Value="Deposit"></asp:ListItem>
                        <asp:ListItem Text="Transferencia" Value="Transfer"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                </br>
                 <%--FOR TRANSFER/DEPOSIT PAYMENT--%>               
                 <div id="pnlTransfAndDeposit" runat="server">
                    <fieldset>
                        <legend>Información Cuenta Depósitos:</legend>
                        <div class="label_plus_input par row_A ">
                            <asp:Label runat="server" ID="lblBankepTransf" Text="Banco" CssClass="azul_pl"></asp:Label>
                             <asp:DropDownList runat="server" ID="ddlBanksInformation" AutoPostBack="true" OnSelectedIndexChanged="ddlBanksInformation_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="label_plus_input par row_A ">
                            <asp:Label runat="server" ID="lblDepositAccount"  Text="Cuenta de Depósito" CssClass="azul_pl"></asp:Label>
                             <asp:DropDownList runat="server" ID="ddlDepositAccount" AutoPostBack="true" OnSelectedIndexChanged="ddlDepositAccount_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="label_plus_input par row_A ">
                            <asp:Label runat="server" ID="lblBankAccountNumber"  Text="Número de Cuenta" CssClass="azul_pl"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAccountNumberDepTransf" ClientIDMode="Static" MaxLength="100"></asp:TextBox>
                        </div>
                    </fieldset>
                    </br>
                </div>
                <%-------------------%>

                <%--FOR ACH PAYMENT--%>
                <div id="pnlACH" runat="server">
                    <div class="label_plus_input par row_A ">
                        <asp:Label runat="server" ID="lblAccountHolder"  Text="Titular de la cuenta" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtAccountHolder" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A ">
                        <asp:Label runat="server" ID="lblBankACH"  Text="Banco" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtBankACH" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A mB">
                        <span class="azul_pl">Tipo de Cuenta</span>
                        <asp:DropDownList runat="server" ID="ddlAccountType">
                        </asp:DropDownList>
                    </div>
                    <div class="label_plus_input par row_A ">
                        <asp:Label runat="server" ID="lblAccountNumber" Text="Número de Cuenta" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtAccountNumber" ClientIDMode="Static" MaxLength="25"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A ">
                        <asp:Label runat="server" ID="lblAbaNumber" Text="Código ABA" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtAbaNumber" ClientIDMode="Static" MaxLength="9"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A ">
                        <asp:Label runat="server" ID="lblAccountOwnerID" Text="Identificación cuenta habiente" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtAccountOwnerID" ClientIDMode="Static" MaxLength="15"></asp:TextBox>
                    </div>
                </div>
                <%-------------------%>

                <%--Tarjeta de credito--%>
                <div id="pnlCreditCard" runat="server">
                    <div class="label_plus_input par row_A mB20">
                        <asp:Label runat="server" ID="lblAuthorizationCode" Text="Codigo de autorización" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtAuthorizationCode" ClientIDMode="Static" MaxLength="8"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A mB">
                        <span class="azul_pl">Tipo de tarjeta</span>
                        <asp:DropDownList runat="server" ID="ddlCreditCardType">
                        </asp:DropDownList>
                    </div>
                    <div class="label_plus_input par row_A mB20">
                        <asp:Label runat="server" ID="lblCreditCardNumber" Text="Terminal Tarjeta de crédito" CssClass="azul_pl"></asp:Label>
                        <asp:TextBox runat="server" ID="txtCreditCardNumber" ClientIDMode="Static" MaxLength="4"></asp:TextBox>
                    </div>
                </div>
                <%----------------------%>

                <%--Cheque--%>
                <div id="pnlCheck" runat="server">
                    <fieldset>
                        <legend>Información Pago con Cheque:</legend>
                        <div class="label_plus_input par row_A ">
                            <asp:Label runat="server" ID="lblBankCheck" Text="Banco Emisor" CssClass="azul_pl"></asp:Label>
                            <asp:TextBox runat="server" ID="txtBankCheck" ClientIDMode="Static" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="label_plus_input par row_A ">
                            <asp:Label runat="server" ID="lblCheckNumber" Text="Número de Cheque" CssClass="azul_pl"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCheckNumber" ClientIDMode="Static" MaxLength="10"></asp:TextBox>
                        </div>
                    </fieldset>
                    </br>
                </div>
                <%----------%>
                <div class="label_plus_input par row_A mT10">
                    <asp:Label runat="server" ID="lblTag" Text="Etiqueta actual" CssClass="gris_pl helpToolTip" title="El tag presentado es el correspondiente a la próxima etiqueta a ser generada (currente), si la etiqueta que usted tiene es distinta a esta (menor/mayor), puede colocarla manualmente en esta caja de texto para que sea generada al procesar el pago. Es preciso que la secuencia introducida sea la correcta para evitar errores en la generación de tags."></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="false" ClientIDMode="Static" onkeydown="return EnterEvent(event,this);" AutoPostBack="true" ID="txtCurrentTag"></asp:TextBox>
                </div>
                <div class="label_plus_input par row_A mT10">
                    <asp:Label runat="server" ID="lblComments" Text="Comentarios" CssClass="gris_pl"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="false" ClientIDMode="Static" onkeydown="return EnterEvent(event,this);" AutoPostBack="true" ID="txtComments" MaxLength="250"></asp:TextBox>
                </div>
                <div class="cPink label_plus_input par row_A mT10">
                    <asp:Label runat="server" ID="lblAmountToBePaid" Text="Monto a Pagar"></asp:Label>
                    <asp:TextBox runat="server" ReadOnly="true" ClientIDMode="Static" ID="txtAmountToBePaid"></asp:TextBox>
                </div>
            </div>
            <div class="botones_pmt">
                <asp:Button runat="server" ID="btnProcessPayment" CssClass="fr button button-green alignC embossed mB" OnClientClick="return PaymentConfirmation();" OnClick="btnProcessPayment_Click" Text="Procesar" />
                <asp:Button runat="server" ID="btnClearAll" CssClass="fr button button button-red alignC embossed" OnClientClick="if (!UserClearConfirmation()) return false;" OnClick="btnClearAll_Click" Text="Limpiar" />
            </div>
        </div>
    </div>
    <div class="row_A mT20 mB100">
        <asp:LinkButton runat="server" ID="btnBack" CssClass="back_btn" OnClientClick="if (!UserBackConfirmation()) return false;" OnClick="btnBack_Click">
            <i class="flecha_iz"></i>Volver página anterior
        </asp:LinkButton>
    </div>
</div>
<div id="confirmation" title="Procesar pago?">
    <br />
    <span class="ui-icon ui-icon-alert" style="margin: 0 7px 50px 0; float: left;"></span>
    <span>Esta póliza recibió pagos en las últimas 24 horas, ¿está seguro que desea procesar esta transacción (para procesar el pago presione el botón "Procesar", de lo contrario, presione el botón "Cancelar")?</span>
    <hr />
    <br />
    <div class="ui-dialog-buttonset">
        <asp:Button runat="server" ID="btnCancelPaymentConfirmation" CssClass="fr button button button-red alignC embossed" OnClientClick="$('#confirmation').dialog('close');" Text="Cancelar" />
        <asp:Button runat="server" ID="btnPaymentConfirmation" CssClass="fr button button-green alignC embossed mB mR-1-p" OnClientClick="loading(true);" OnClick="ProcessPayment" Text="Procesar" />
    </div>
</div>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ddlBanksInformation" />
        <asp:PostBackTrigger ControlID="ddlDepositAccount" />
    </Triggers>
</asp:UpdatePanel>
<!--contenido-->
