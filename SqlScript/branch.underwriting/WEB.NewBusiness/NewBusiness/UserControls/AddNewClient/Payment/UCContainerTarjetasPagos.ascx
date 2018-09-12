<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContainerTarjetasPagos.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.Payment.UCContainerTarjetasPagos" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Payment/UCPagoConTarjetas.ascx" TagPrefix="uc1" TagName="UCPagoConTarjetas" %>

<asp:MultiView ID="MVTarjetaPagos" runat="server">
   <asp:View ID="VTarjetaPagos" runat="server">
     <uc1:UCPagoConTarjetas runat="server" ID="UCPagoConTarjetas" />         
   </asp:View>
</asp:MultiView>   
<asp:HiddenField ID="hfSelectControls" runat="server" Value="VTarjetaPagos" />