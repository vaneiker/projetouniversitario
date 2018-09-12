<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCScholarFooter.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCScholarFooter" %>
<div class="grupos de_6 alingtoend">
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TotalStudyAmount %></label>
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
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAgeatStartofEducation %></label>
       <asp:Textbox runat="server" ID="txtInsuredProspectAge" ReadOnly="true"></asp:Textbox>
    </div>
</div>
<!--grupos-->
