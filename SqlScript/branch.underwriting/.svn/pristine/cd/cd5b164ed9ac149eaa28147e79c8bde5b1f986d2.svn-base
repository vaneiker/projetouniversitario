<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerPagoCheque.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerPagoCheque" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCPagoNPE.ascx" TagPrefix="uc1" TagName="UCPagoNPE" %>

<asp:MultiView ID="MVPagoCheque" runat="server">
    <asp:View ID="VPagoCheque" runat="server">
        <%-- Bmarroquin nota: Utilizo el mismo User Control que NPE dado que son los mismos campos--%> 
        <uc1:UCPagoNPE runat="server" ID="UCPagoNPE" />         
    </asp:View>
</asp:MultiView>   
<asp:HiddenField ID="hfSelectControls" runat="server" Value="VPagoCheque" />