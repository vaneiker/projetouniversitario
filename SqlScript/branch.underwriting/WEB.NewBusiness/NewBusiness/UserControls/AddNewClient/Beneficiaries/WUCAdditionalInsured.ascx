<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCAdditionalInsured.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Beneficiaries.WUCAdditionalInsured" %>
<%@ Register Src="~/NewBusiness/UserControls/AddNewClient/Beneficiaries/WUCBeneficiaries.ascx" TagPrefix="uc1" TagName="WUCAdditionalBeneficiaries" %>
<div ID="pnBeneficiaries" class="fondo_gris">
    <div class="col-1-2">
        <uc1:WUCAdditionalBeneficiaries runat="server" ID="WUCMainBeneficiaries" />
    </div>
    <div class="col-1-2">
        <uc1:WUCAdditionalBeneficiaries runat="server" ID="WUCContingentBeneficiaries" />
    </div>
</div>
