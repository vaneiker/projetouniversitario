<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLighthouseFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCLighthouseFooter" %>
<div class="grupos de_5 alingtoend">
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TotalInsuredAmount %></label>
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
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredPeriod %> (<%=RESOURCE.UnderWriting.NewBussiness.Resources.Years %>)</label>
       <asp:Textbox runat="server" ID="txtInsuredPeriod" ReadOnly="true"></asp:Textbox>
    </div>
</div>
<!--grupos-->
