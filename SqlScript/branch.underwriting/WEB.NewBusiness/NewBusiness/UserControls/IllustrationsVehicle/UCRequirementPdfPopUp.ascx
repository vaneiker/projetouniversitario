<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirementPdfPopUp.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCRequirementPdfPopUp" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>

<asp:UpdatePanel ID="RequirementPdfPreview" runat="server">
    <ContentTemplate>
        <div class="pop_up_wrapper">
            <!--escriben por style el ancho que desean-->
            <div class="titulos_azules">

                <strong runat="server" id="uploadDocument">UPLOAD DOCUMENT</strong>
            </div>
            <!--titulos_azules-->
            <div class="content_fondo_blanco">

                <div class="grupos de_1">
                    <div>
                        <table>
                            <tr>
                                <td style="width: 80%;">
                                    <div>
                                        <label class="label"></label>
                                        <asp:TextBox ID="txtPath" runat="server" ClientIDMode="Static" />
                                    </div>
                                </td>

                                <td>
                                    <div class="boton_wrapper azul float_right">
                                        <dx:ASPxUploadControl ID="fuRequirementFile" ClientInstanceName="fuRequirementFile" runat="server" ClientIDMode="Static"
                                            ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Browse"
                                            ValidationSettings-AllowedFileExtensions=".pdf,.png,.jpg,.gif,.bmp,.msg" OnFileUploadComplete="fuRequirementFile_FileUploadComplete">
                                            <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileRequirementComplete" />
                                        </dx:ASPxUploadControl>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--grupos-->
                <div style="background-color: #EEE;">
                    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="810px" Height="580px">
                    </PdfViewer:PdfViewer>
                </div>
                <asp:Button ID="btnRequirementPreviewPDF" runat="server" ClientIDMode="Static" OnClick="btnRequirementPreviewPDF_Click" Style="display: none;" />
                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save" onclick="btnSave.click();"></span>
                            <asp:Button ID="btnSave" ClientIDMode="Static" runat="server" Text="Save" CssClass="boton" OnClick="btnSave_Click" OnClientClick="ClosePopRequirement();" />
                        </div>

                        <div class="boton_wrapper rojo">
                            <span class="equis" style="cursor: pointer" onclick="CancelBtn.click();"></span>
                            <asp:Button runat="server" ID="CancelBtn" Text="Cancel" CssClass="boton" OnClientClick="ClosePopRequirement();" />                            
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--pop_up_wrapper-->
    </ContentTemplate>
</asp:UpdatePanel>

