<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNewExclusion.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCNewExclusion" %>

<asp:UpdatePanel ID="upNewExclusions" runat="server">
    <ContentTemplate>
        <div class="cont_risk_popup ">
            <div class="wd100 fl mB22 clear">
                <div class=" wd31-5 fl mR-2-p">
                    <label class="fl mB  " for="rt">EXCLUSION TYPE:</label>
                    <asp:DropDownList runat="server" ID="ddlNEExclusionType" ClientIDMode="Static" CssClass="fl m0" AutoPostBack="true" OnSelectedIndexChanged="ddlExclusionType_SelectedIndexChanged" />
                </div>
                <div class=" wd44 fl mR-2-p">
                    <label class="fl mB  ">EXCLUSION:</label>
                    <asp:DropDownList runat="server" ID="ddlNEExclusion" ClientIDMode="Static" CssClass="fl m0" />
                </div>
                <div class="wd20 fl">
                    <label class="fl mB ">REQUESTED BY:</label>
                    <asp:DropDownList runat="server" ID="ddlNERequestedBy" ClientIDMode="Static" CssClass="fl m0" />
                </div>
            </div>

            <div class="wd100 fl mB15">
                <label class="wd100 fl alignL mB">COMMENTS:</label>
                <asp:TextBox runat="server" ID="txtNEExclusionComment" ClientIDMode="Static" CssClass="wd100 hg300" TextMode="MultiLine" />
            </div>

            <div class="wd100 fl hg35 clear">
                <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr mR">
                    <span class="add"></span>
                    <asp:Button runat="server" ID="btnNEAdd" CssClass="boton" OnClick="btnAdd_Click" Text="Add" OnClientClick="return ValidateNewExclusion();" />
                </div>
                <asp:HiddenField ID="hdnNEIsAditional" Value="false" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdnNEContactId" runat="server" ClientIDMode="Static" Value="false" />
                <asp:HiddenField ID="hdnNEContactRoleTypeId" runat="server" ClientIDMode="Static" Value="false" />
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlNEExclusionType" />
    </Triggers>
</asp:UpdatePanel>

