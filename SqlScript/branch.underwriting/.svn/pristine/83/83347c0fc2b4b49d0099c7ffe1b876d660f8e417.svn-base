<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerTransfer.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerTransfer" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCContainerTransferCheck.ascx" TagPrefix="uc1" TagName="UCContainerTransferCheck" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCContainerTransferWire.ascx" TagPrefix="uc1" TagName="UCContainerTransferWire" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCContainerTransferWirePromise.ascx" TagPrefix="uc1" TagName="UCContainerTransferWirePromise" %>

<asp:MultiView ID="MVTransfer" runat="server">
    <asp:View ID="VAContainerTransferCheck" runat="server">
        <uc1:UCContainerTransferCheck runat="server" ID="UCContainerTransferCheck" />
    </asp:View>
    <asp:View ID="VAContainerTransferWire" runat="server">
        <uc1:UCContainerTransferWire runat="server" ID="UCContainerTransferWire" />
    </asp:View>
    <asp:View ID="VAContainerTransferWirePromise" runat="server">
        <uc1:UCContainerTransferWirePromise runat="server" ID="UCContainerTransferWirePromise" />
    </asp:View>
</asp:MultiView>

<asp:HiddenField ID="hfSelectControls" runat="server" Value="VAContainerTransferCheck" />
