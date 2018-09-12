<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerCCDomicile.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerCCDomicile" %>

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
            <label class="label red" runat="server" id="FormofPayment">Form of Payment</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlFormofPayment" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlFormofPayment_SelectedIndexChanged" validation="Required"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="PaymentType">Payment Type</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlCardType" runat="server" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged" validation="Required"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="CardholderName">Cardholder Name</label>
            <asp:TextBox ID="txtCardholderName" runat="server" validation="Required"></asp:TextBox>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <label class="label red" runat="server" id="ExpirationDate">Expiration Date </label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlExpirationDateMonth" runat="server" validation="Required"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </td>
                    <td style="width: 40%">
                        <label class="label red"></label>
                        <div class="wrap_select">
                            <asp:DropDownList ID="ddlExpirationDateYear" runat="server" validation="Required"></asp:DropDownList>
                        </div>
                        <!--wrap_select-->
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <label class="label red" runat="server" id="CardNumber">Card Number</label>
            <asp:TextBox ID="txtCardNumber" runat="server" validation="Required" data-inputmask="'mask': '9999-9999-9999-9999'" creditcard="creditcard"></asp:TextBox>
        </div>
        <div style="display:none">
            <label class="label" runat="server" id="RepeatCardNumber">Repeat Card Number</label>
            <asp:TextBox ID="txtRepeatCardNumber" runat="server" ClientIDMode="Static" data-inputmask="'mask': '9999-9999-9999-9999'" creditcard="creditcard"></asp:TextBox>
        </div>
        <div style="display:none">
            <label class="label" runat="server" id="CIDorCVVN2">CID or CVV #2</label>
            <asp:TextBox ID="txtCIDCVV" runat="server"  validateEqualControlId="txtRepeatCIDCVV"></asp:TextBox>
        </div>
        <div style="display:none">                    
            <label class="label" runat="server" id="RepeatCIDorCVVN2">Repeat CID or CVV #2</label>
            <asp:TextBox ID="txtRepeatCIDCVV" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label class="label red" runat="server" id="CardholderRelationshipOwnerInsured">Cardholder Relationship/Owner/Insured</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlAccountHolderRelationshipOwnerInsured" runat="server" OnSelectedIndexChanged="ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged" validation="Required"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="Amount">Amount</label>
            <asp:TextBox ID="txtAmount" runat="server" decimal="decimal" validation="Required"></asp:TextBox>
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
                </asp:View>
                <asp:View ID="vInactive" runat="server">
                    <div class="boton_wrapper inactive float_right">
                        <span class="process_inactive"></span>
                        <asp:Button CssClass="aspNetDisabled boton" Text="Save" runat="server" ID="btnProcessPayment2" Enabled="false" disabled="disabled" />
                    </div>
                </asp:View>

            </asp:MultiView>

            <div class="boton_wrapper gris float_right" style="display: block;margin-right: 10px;">
                <span class="borrar"></span>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="boton" Style="height: 26px" OnClick="btnCancel_Click" />
            </div>
            <!--boton_wrapper-->
        </div>
    </div>
    <!--grupos-->


    <!--grid_wrap-->
</div>
