<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerCC.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerCC" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCContainerCCDomicile.ascx" TagPrefix="uc1" TagName="UCContainerCCDomicile" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCContainerCCOneTime.ascx" TagPrefix="uc1" TagName="UCContainerCCOneTime" %>


<asp:MultiView ID="MVCC" runat="server">
    <asp:View ID="VAContainerCCOneTime" runat="server">
        <uc1:UCContainerCCOneTime runat="server" ID="UCContainerCCOneTime" />
    </asp:View>

    <asp:View ID="VAContainerCCDomicile" runat="server">
        <uc1:UCContainerCCDomicile runat="server" ID="UCContainerCCDomicile" />
    </asp:View>
</asp:MultiView>

<asp:HiddenField ID="hfSelectControls" runat="server" Value="VAContainerCCOneTime" />