<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUploadDocument.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.UCUploadDocument" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<asp:UpdatePanel ID="udpUploadPDF" runat="server">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 800px;">
            <div class="titulos_azules">
                <strong runat="server" id="UploadDocument">UPLOAD DOCUMENT</strong>
            </div>
            <!--titulos_azules-->
            <div class="content_fondo_blanco"> 
                <div class="grupos de_1">
                    <asp:Panel runat="server" ID="pnUpdateDocument">
                        <div>
                            <table>
                                <tr>
                                    <td width="80%">
                                        <div>
                                            <label class="label"></label>
                                            <input type="text">
                                        </div>
                                    </td>

                                    <td>
                                        <div class="boton_wrapper azul float_right">
                                            <dx:ASPxUploadControl ID="fuFile" ClientInstanceName="fuFile" runat="server" ClientIDMode="Static"
                                                ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Browse"
                                                ValidationSettings-AllowedFileExtensions=".pdf" OnFileUploadComplete="fuFile_FileUploadComplete">
                                                <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFileComplete" />
                                            </dx:ASPxUploadControl>

                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </asp:Panel>
                </div>

                <!--PDF -->

                <div style="background-color: #EEE;">
                    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="800px" Height="600px">
                    </PdfViewer:PdfViewer>
                </div>
                <!--// PDF -->
                <asp:Panel runat="server" ID="pnUploadDocumentButtons">
                    <asp:Button ID="btnPreviewPDF" runat="server" ClientIDMode="Static" Style="display: none;" />
                    <!-- Botones -->
                    <div class="grupos">
                        <div class="float_right">
                            <div class="boton_wrapper rojo">
                                <span class="equis"></span>
                                <asp:Button ID="CancelBtn" runat="server" Text="Cancel" class="boton" />
                            </div>
                            <div class="boton_wrapper verde">
                                <span class="save"></span>
                                <asp:Button ID="SaveBtn" runat="server" Text="Save" class="boton" />
                            </div>
                        </div>
                    </div>
                    <!--// Botones -->
                </asp:Panel>

                <asp:Panel runat="server" ID="pnCloseButton" Visible="false">  
                    <div class="grupos">
                        <div class="float_right">
                            <div class="boton_wrapper rojo">
                                <span class="equis"></span>
                                <asp:Button ID="CloseBtn" runat="server" Text="Close" class="boton" />
                            </div>
                        </div>
                    </div>
                    <!--// Botones -->
                </asp:Panel>
            </div>
            <!--// cont -->
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnPreviewPDF" />
    </Triggers>
</asp:UpdatePanel>
