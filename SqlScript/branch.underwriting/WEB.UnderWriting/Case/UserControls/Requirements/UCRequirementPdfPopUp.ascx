<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirementPdfPopUp.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Requirements.UCRequirementPdfPopUp" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<asp:UpdatePanel ID="RequirementPdfPreview" runat="server">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="overflow-x: hidden; overflow-y: hidden">
            <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                  <ul>
                    <li style="position: absolute; left: 41%; top: 31%;">
                        <asp:Literal ID="ltTypeDoc" Text="Upload PDF" ClientIDMode="Static" runat="server"></asp:Literal>
                    </li>
                    <li style="top: 13%;">
<%--                        <asp:Button ID="btnClosePdfPop" runat="server" CssClass="btnClosePopBtn" ClientIDMode="Static" OnClientClick="return " />--%>
                        <input type="button" id="close_pop_up" class="cls_pup" onclick="CloseRequirementPDFPop();" /> 
                    </li>
                </ul>

            </div>
            <div class="cont type_result_pp">
                <div class=" row mB">
                    <div class="fl wd13 cont_popup">
                        <label class="label mT3">Upload Document:</label>
                    </div>
                    <div class="browse_up browserVD fr wd87">
                        <dx:ASPxUploadControl ID="fuRequirementFile" ClientInstanceName="fuRequirementFile" runat="server" ClientIDMode="Static"
                            ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto"
                            ShowProgressPanel="false"  ValidationSettings-AllowedFileExtensions=".pdf"  BrowseButton-Text="Browse" BrowseButtonStyle-CssClass="Browser" OnFileUploadComplete="fuRequirementFile_FileUploadComplete">
                            <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileRequirementComplete" />
                        </dx:ASPxUploadControl>
                        <asp:Button ID="btnRequirementPreviewPDF" runat="server" ClientIDMode="Static" OnClick="btnRequirementPreviewPDF_Click" Style="display: none;" />
                    </div>
                </div>
                <div class=" row mB">
                    <div class="fl wd13 cont_popup">
                        <label class="label">Comment:</label>
                    </div>
                <asp:TextBox ID="txtDocumentRequirementComment" ClientIDMode="Static" CssClass="wd87 fl hg62" runat="server" TextMode="MultiLine" />
                    </div>
                <!--PDF -->
                <div class=" pdf_view_600">
                    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="940px" Height="580px">
                    </PdfViewer:PdfViewer>
                </div>
                <!--// PDF -->

                <!-- Botones -->
                <div class="wd100 fl hg35 mT10">
                    <div class="boton_wrapper gradient_RJ bdrRJ fr">
                        <span class="equis"></span>
                        <asp:Button ID="CancelBtn" runat="server" Text="Cancel" CssClass="boton" OnClientClick="return CloseRequirementPDFPop();" />
                    </div>

                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR-2-p">
                        <span class="save"></span>
                        <asp:Button ID="SaveBtn" runat="server" Text="Save" CssClass="boton" ClientIDMode="Static" OnClientClick="return validateRequirementPopUp();" OnClick="savePdf"/>
                    </div>

                </div>
                <!--// Botones -->
            </div>
            <!--// cont -->
            
        </div>
    </ContentTemplate>

    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnRequirementPreviewPDF" />
        <asp:AsyncPostBackTrigger ControlID="SaveBtn" />
    </Triggers>
</asp:UpdatePanel>

