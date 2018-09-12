<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTerminateExclusion.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCTerminateExclusion" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>


<div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
    <ul>
        <li style="position: absolute; left: 41%; top: 31%;">
            <asp:Literal ID="ltTypeDoc" Text="Terminate Exclusion" ClientIDMode="Static" runat="server"></asp:Literal>
        </li>
        <li style="top: 13%;">
            <input type="button" id="close_pop_up" class="cls_pup" onclick="CloseTerminateExclusionPop();" />
        </li>
    </ul>
</div>
<div class="cont_risk_popup ">
    <div class="wd100 fl mB22 clear">
        <div class=" wd20 fl mR-2-p">
            <label class="fl mB  ">NOTIFICATION DATE:</label>
            <asp:TextBox ID="txtNotificationDateTerminateExclusion" runat="server" CssClass="datepickerPop" ClientIDMode="Static" alt="LimitMinDate" txtName="txtEndDateTerminateExclusion" />
        </div>
        <div class=" wd20 fl mR-2-p">
            <label class="fl mB  ">END DATE:</label>
            <asp:TextBox ID="txtEndDateTerminateExclusion" runat="server" CssClass="datepickerPop" ClientIDMode="Static" />
        </div>
        <div class=" wd56 fl">
            <label class="fl mB wd100 ">UPLOAD FILE:</label>

            <div class="browse_up browserVD fl wd62">
                <dx:ASPxUploadControl ID="fuTerminateExclusionFile" ClientInstanceName="fuTerminateExclusionFile" runat="server" ClientIDMode="Static"
                    ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto"
                    ShowProgressPanel="false" ValidationSettings-AllowedFileExtensions=".pdf" BrowseButton-Text="Browse" BrowseButtonStyle-CssClass="Browser" OnFileUploadComplete="fuTerminateExclusionFile_FileUploadComplete">
                    <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileTerminateExclusionComplete" />
                </dx:ASPxUploadControl>
            </div>
        </div>
    </div>
    <div class="wd100 fl mB15">
        <label class="wd100 fl alignL mB">COMMENTS:</label>
        <asp:TextBox ID="txtTerminateExclusionComment" runat="server" CssClass="wd100 hg300" TextMode="MultiLine" ClientIDMode="Static" />
    </div>
    <div class="wd100 fl hg35 clear">
        <div class="boton_wrapper gradient_RJ bdrRJ fr">
            <span class="equis"></span>

            <asp:Button ID="btnCancel" runat="server" CssClass="boton" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="return CloseTerminateExclusionPop();" />
        </div>
        <div class="boton_wrapper gradient_vd2 bdrVd2 txtNG-f fr mR">
            <span class="save"></span>
            <asp:Button ID="btnAdd" runat="server" CssClass="boton" Text="Save" OnClick="btnAdd_Click" OnClientClick="return ValidateTerminateExclusion();" />
        </div>
    </div>
</div>

<asp:HiddenField ID="hdnSequenceReference" runat="server" />
<asp:HiddenField ID="hdnRiskId" runat="server" />
<asp:HiddenField ID="hdnUnderwriterName" runat="server" />
<asp:HiddenField ID="hdnStoreComment" runat="server" />
<asp:HiddenField ID="hdnIsAditional" Value="false" runat="server" />
<asp:HiddenField ID="hdnTerminateExclusionPdfPath" runat="server" ClientIDMode="Static" />
