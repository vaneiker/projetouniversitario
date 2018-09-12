<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLegacyFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCLegacyFooter" %>
<div class="grupos de_5">
    <div>
        <label class="label">Total <%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmountLabel %></label>
       <asp:Textbox runat="server" ID="txtTotalInsuredBenefitRetirementAmount" ReadOnly="true"></asp:Textbox>
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
</div>
<!--grupos-->
