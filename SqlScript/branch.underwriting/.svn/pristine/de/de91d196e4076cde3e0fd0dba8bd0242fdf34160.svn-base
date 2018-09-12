<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCACHOneTime.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCACHOneTime" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="content_fondo_blanco" id="frmPay">
    <div class="grupos de_2">
        <div>
            <label class="label" runat="server" id="OriginationDate">Origination Date</label>
            <asp:TextBox ID="txtOriginationDate" runat="server" class="datepicker" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <!--grupos-->

    <div class="grupos de_2">
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
                <asp:DropDownList ID="ddlCardType" runat="server" validation="Required" OnSelectedIndexChanged="ddlCardType_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="AccountHolderName">Account Holder Name</label>
            <asp:TextBox ID="txtAccountHolderName" runat="server" validation="Required"></asp:TextBox>
        </div>
        <div>
            <label class="label red" runat="server" id="BankName">Bank Name</label>
            <asp:TextBox ID="txtBankName" runat="server" validation="Required" ClientIDMode="Static" Enabled="false"></asp:TextBox>
        </div>
        <div>
            <label class="label red" runat="server" id="AccountNumber">Account Number</label>
            <asp:TextBox ID="txtAccountNumber" runat="server" validation="Required"></asp:TextBox>
        </div>
        <div style="display:none">
            <label class="label" runat="server" id="RepeatAccountNumber">Repeat Account Number</label>
            <asp:TextBox ID="txtRepeatAccountNumber" runat="server" ClientIDMode="Static"></asp:TextBox>
        </div>
        <div>
            <label class="label red" runat="server" id="ABANumber">ABA Number</label>
            <asp:TextBox ID="txtABANumber" runat="server" ClientIDMode="Static" validation="Required"></asp:TextBox>
        </div>     
        <div>
            <label class="label red" runat="server" id="AccountHolderRelationshipOwnerInsured">AccountHolder Relationship/Owner/Insured</label>
            <div class="wrap_select">
                <asp:DropDownList ID="ddlAccountHolderRelationshipOwnerInsured" runat="server" validation="Required" OnSelectedIndexChanged="ddlAccountHolderRelationshipOwnerInsured_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red" runat="server" id="Amount">Amount</label>
            <asp:TextBox ID="txtAmount" runat="server" validation="Required" decimal="decimal"></asp:TextBox>
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


    <!--grid_wrap-->
</div>
