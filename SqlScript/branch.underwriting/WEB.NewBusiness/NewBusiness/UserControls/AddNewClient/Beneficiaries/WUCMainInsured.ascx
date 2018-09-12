<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCMainInsured.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Beneficiaries.WUCMainInsured" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Beneficiaries/WUCBeneficiaries.ascx" TagPrefix="uc1" TagName="WUCMainBeneficiaries" %>
<asp:panel runat="server" ID="pnBeneficiaries" class="fondo_gris">
    <div class="col-1-2">
        <uc1:WUCMainBeneficiaries runat="server" ID="WUCMainBeneficiaries" />
    </div>
    <div class="col-1-2">
        <uc1:WUCMainBeneficiaries runat="server" ID="WUCContingentBeneficiaries" />
    </div>
</asp:panel>
