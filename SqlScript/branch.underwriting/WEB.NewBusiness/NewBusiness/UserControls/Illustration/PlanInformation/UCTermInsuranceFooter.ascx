<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTermInsuranceFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCTermInsuranceFooter" %>
<div id="divTermInsuranceFooter" class="grupos de_8 alingtoend">
    <div>
        <label class="label">Total <%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmountLabel %></label>
       <asp:Textbox runat="server" ID="txtTotalInsuredBenefitRetirementAmount" ReadOnly="true"></asp:Textbox>
    </div>
    <div style="display:none;">
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.lblPrimaAnualNeta %></label>
       <asp:Textbox runat="server" ID="txtPrimaAnualNeta" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.lblMontoRecargoFraccio %></label>
       <asp:Textbox runat="server" ID="txtFraccionamiento" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AnnualPremium %></label>
       <asp:Textbox runat="server" ID="txtAnnualPremium" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PeriodicPremium %></label>
       <asp:Textbox runat="server" ID="txtPeriodicPremium" ReadOnly="true"></asp:Textbox>
    </div>
    <div id="divTax">
        <asp:Label runat="server" ID="lblTax" CssClass="label"></asp:Label>
       <asp:Textbox runat="server" ID="txtTax" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PeriodicPremium %> Total</label>
       <asp:Textbox runat="server" ID="txtPeriodicPremiumTotal" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TargetAnnualPremium %></label>
       <asp:Textbox runat="server" ID="txtTargetAnnualPremium" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredPeriod %> (<%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %>)</label>
       <asp:Textbox runat="server" ID="txtInsuredPeriod" ReadOnly="true"></asp:Textbox>
    </div>
    <div id="divReturnPremium">
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ReturnofPremium %></label>
       <asp:Textbox runat="server" ID="txtReturnPremium" ReadOnly="true"></asp:Textbox>
    </div>
</div>
<!--grupos-->
