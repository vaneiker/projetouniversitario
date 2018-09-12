<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerCash.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerCash" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCCash.ascx" TagPrefix="uc1" TagName="UCCash" %> 
<asp:MultiView ID="MVCash" runat="server" ActiveViewIndex="0" >
    <asp:View runat="server" ID="VCash">
        <uc1:UCCash runat="server" ID="UCCash" />
    </asp:View>
    </asp:MultiView>

<asp:HiddenField ID="hfSelectControls" runat="server" Value="VCash" />