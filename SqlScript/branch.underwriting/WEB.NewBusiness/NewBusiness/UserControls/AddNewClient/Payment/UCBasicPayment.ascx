<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBasicPayment.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCBasicPayment" %>
<div class="content_fondo_blanco" id="frmPay">
    <div class="grupos de_2">
        <div>
            <label class="label" runat="server" id="OriginationDate">Origination Date</label>
            <asp:TextBox ID="txtOriginationDate" runat="server" class="datepicker" ReadOnly="true" disabled></asp:TextBox>
        </div>
    </div>
    <!--grupos-->

    <asp:panel runat="server" class="grupos de_2" id="pnForm">
        <div>
            <label class="label red" runat="server" id="FormofPayment">Form of Payment</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlFormofPayment" AutoPostBack="true" runat="server" validation="Required" OnSelectedIndexChanged="ddlFormofPayment_SelectedIndexChanged"></asp:DropDownList>
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
    </asp:panel>
    <!--grupos-->

   <%-- <div class="grupos de_1" id="divSave">
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
            <div class="boton_wrapper verde float_right" style="display: none">
                <span class="save"></span>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="boton" Style="height: 26px" OnClick="btnCancel_Click" />
            </div>
            <!--boton_wrapper-->
        </div>
    </div>--%>
    <!--grupos-->
    <!--grid_wrap-->
</div>
