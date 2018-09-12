<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerBasicPayment.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerBasicPayment" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCBasicPayment.ascx" TagPrefix="uc1" TagName="UCBasicPayment" %>
<asp:MultiView ID="MVCash" runat="server" ActiveViewIndex="0">
    <asp:View runat="server" ID="VBasicPayment">
        <uc1:UCBasicPayment runat="server" id="UCBasicPayment" />
    </asp:View>
</asp:MultiView>
<asp:HiddenField ID="hfSelectControls" runat="server" Value="VBasicPayment" />
