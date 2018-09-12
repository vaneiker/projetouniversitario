<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAxysFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCAxysFooter" %>
<div class="grupos de_7 alingtoend">
    <div>
        <label class="label">Total Retirement Amount</label>
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
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TargetAnnualPremium %></label>
       <asp:Textbox runat="server" ID="txtTargetAnnualPremium" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MinimumAnnualPremium %></label>
       <asp:Textbox runat="server" ID="txtMinimumAnnualPremium" ReadOnly="true"></asp:Textbox>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ProspectAgeatStartofRetirement %></label>
       <asp:Textbox runat="server" ID="txtInsuredProspectAge" ReadOnly="true"></asp:Textbox>
    </div>
</div>
<!--grupos-->
