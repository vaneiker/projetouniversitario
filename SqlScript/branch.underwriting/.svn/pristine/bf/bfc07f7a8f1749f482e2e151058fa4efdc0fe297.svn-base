<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerACH.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerACH" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCACHDomicile.ascx" TagPrefix="uc1" TagName="UCACHDomicile" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCACHOneTime.ascx" TagPrefix="uc1" TagName="UCACHOneTime" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCACHStbDomicile.ascx" TagPrefix="uc1" TagName="UCACHStbDomicile" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCACHStbOnetime.ascx" TagPrefix="uc1" TagName="UCACHStbOnetime" %>
<asp:MultiView ID="MVACH" runat="server">
    <asp:View ID="VACHDomicile" runat="server">
        <uc1:UCACHDomicile runat="server" ID="UCACHDomicile" />
    </asp:View>
    <asp:View ID="VCACHOneTime" runat="server">
        <uc1:UCACHOneTime runat="server" ID="UCACHOneTime" />
    </asp:View>
    <asp:View ID="VACHStbDomicile" runat="server">
        <uc1:UCACHStbDomicile runat="server" ID="UCACHStbDomicile" />
    </asp:View>
    <asp:View ID="VACHStbOnetime" runat="server">
        <uc1:UCACHStbOnetime runat="server" ID="UCACHStbOnetime" />
    </asp:View>
</asp:MultiView>   
<asp:HiddenField ID="hfSelectControls" runat="server" Value="VACHDomicile" />