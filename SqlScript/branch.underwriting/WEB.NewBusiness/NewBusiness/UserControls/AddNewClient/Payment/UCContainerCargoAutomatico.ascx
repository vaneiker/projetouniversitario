<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerCargoAutomatico.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerCargoAutomatico" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCPagoConTarjetas.ascx" TagPrefix="uc1" TagName="UCPagoConTarjetas" %>

<asp:MultiView ID="MVCargoAutomatico" runat="server">
    <asp:View ID="VCargoAutomatico" runat="server">
        <uc1:UCPagoConTarjetas runat="server" ID="UCPagoConTarjetas" />         
    </asp:View>
</asp:MultiView>   
<asp:HiddenField ID="hfSelectControls" runat="server" Value="VCargoAutomatico" />