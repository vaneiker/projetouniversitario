<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCUploadReceiptPopup.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.SubmittedPolicies.WUCUploadReceiptPopup" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpUploadReceipt">
    <ContentTemplate>
        <div class="pop_up_wrapper" style="width: 720px;">
            <div class="titulos_azules">
                <strong>UPLOAD DOCUMENT</strong>
            </div>

            <div class="content_fondo_blanco">
                <div class="grupos de_4">
                    <div>
                        <label class="label">First Name</label>
                        <asp:TextBox runat="server" ID="txtFirtName" ReadOnly="true" />
                    </div>
                    <div>
                        <label class="label">Middle Name</label>
                        <asp:TextBox runat="server" ID="txtMiddleName" ReadOnly="true" />
                    </div>
                    <div>
                        <label class="label">Last Name</label>
                        <asp:TextBox runat="server" ID="txtLastName" ReadOnly="true" />
                    </div>

                    <div>
                        <label class="label">Second Last Name</label>
                        <asp:TextBox runat="server" ID="txtSecondLastName" ReadOnly="true" />
                    </div>
                </div>
                <!--grupos-->

                <fieldset class="margin_t_10">
                    <legend>UPLOAD ARCHIVE</legend>
                    <div class="grupos de_3">
                        <div class="label_check margin_t_15">
                            <asp:CheckBox runat="server" ID="chkUploadReceipt" Checked="true" />
                            <label class="label">Upload Receipt</label>
                        </div>
                        <div>
                            <label class="label"></label>
                            <dx:ASPxUploadControl ID="fuPendingReceiptFile" ClientInstanceName="fuPendingReceiptFile" runat="server" ClientIDMode="Static"
                                ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Browse"
                                ValidationSettings-AllowedFileExtensions=".pdf" ValidationSettings-NotAllowedFileExtensionErrorText="Just can upload pdf files" OnFileUploadComplete="fuPendingReceiptFile_FileUploadComplete">
                                <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFilePendingReceiptComplete" />
                            </dx:ASPxUploadControl>
                        </div> 
                        <div>
                            <label class="label">Client Signature Date Receipt</label>
                            <asp:TextBox runat="server" ID="txtClienSignatureDateReceipt" ClientIDMode="Static" CssClass="datepicker_03"/>
                        </div>
                    </div>
                    <!--grupos-->
                    <div class="grupos de_3">
                        <div class="label_check margin_t_15">
                            <asp:CheckBox runat="server" ID="chkUploadAmmedment" Checked="true" /><label class="label">Upload Amendment</label>
                        </div>
                        <div>
                            <label class="label"></label>
                            <dx:ASPxUploadControl ID="fuPendingAmedmentFile" ClientInstanceName="fuPendingAmedmentFile" runat="server" ClientIDMode="Static"
                                ShowAddRemoveButtons="false" ShowUploadButton="false" ShowClearFileSelectionButton="false" UploadMode="Auto" ShowProgressPanel="false" BrowseButton-Text="Browse"
                                ValidationSettings-AllowedFileExtensions=".pdf" ValidationSettings-NotAllowedFileExtensionErrorText="Just can upload pdf files" OnFileUploadComplete="fuPendingAmedmentFile_FileUploadComplete">
                                <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="uploadFilePendingAmedmentComplete" />
                            </dx:ASPxUploadControl>
                        </div>
                        <div>
                            <label class="label">Client Signature Date Ammedment</label>
                            <asp:TextBox runat="server" ID="txtClienSignatureDateAmmedment"  ClientIDMode="Static"  CssClass="datepicker_03" />
                        </div>
                    </div>
                    <!--grupos-->
                </fieldset>


                <!--grupos-->
                <div class="contenedor_tabs blanco margin_t_15">
                    <ul class="tabs_ttle dvddo_in_2" id="MenuTabsPopUp">
                        <li>
                            <asp:LinkButton ID="lnkReceipt" runat="server" ClientIDMode="Static" OnClick="ManageView" OnClientClick="ActiveCurrentLink(this)" Text="RECEIPT" />
                        </li>
                        <li>
                            <asp:LinkButton ID="lnkAmendment" runat="server" ClientIDMode="Static" OnClick="ManageView" OnClientClick="ActiveCurrentLink(this)" Text="AMENDMENT" />
                        </li>
                    </ul>
                </div>
                <!--contenedor_tabs-->
                <asp:MultiView runat="server" ID="mtViewPdf">
                    <asp:View runat="server" ID="vReceipt">
                        <div style="height: 424px;border:1px solid silver;">
                            <PdfViewer:PdfViewer ID="pdfReceipt" runat="server" ShowScrollbars="true" ClientIDMode="Static" ShowToolbarMode="Show" Width="700px" Height="424px">
                            </PdfViewer:PdfViewer>
                        </div>
                    </asp:View>
                    <asp:View runat="server" ID="vAmendment">
                        <div style="height: 424px;border:1px solid silver;">
                            <PdfViewer:PdfViewer ID="pdfAmendment" runat="server" ShowScrollbars="true" ClientIDMode="Static" ShowToolbarMode="Show" Width="700px" Height="424px">
                            </PdfViewer:PdfViewer>
                        </div>
                    </asp:View>
                </asp:MultiView>

                <div class="grupos">
                    <div class="float_right">
                        <div class="boton_wrapper azul">
                            <span class="submit_cases"></span>
                            <asp:Button runat="server" Text="Submit" CssClass="boton" ID="submitCase" OnClick="submitCase_Click" OnClientClick="return validateEmptyField();" />
                        </div>
                        <div class="boton_wrapper rojo">
                            <span class="equis"></span>
                            <asp:Button runat="server" Text="Cancel" CssClass="boton" OnClientClick="return ClosePendingReceiptPop();" />
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>

        <asp:Button ID="btnPendingReceiptPreviewPDF" runat="server" ClientIDMode="Static" OnClick="btnPendingReceiptPreviewPDF_Click" Style="display: none;" />
        <asp:Button ID="btnPendingAmedmentFilePDF" runat="server" ClientIDMode="Static" OnClick="btnPendingAmedmentFilePDF_Click" Style="display: none;" />
        <asp:Button ID="btnClearPdf" runat="server" ClientIDMode="Static" OnClick="btnClearPdf_Click" Style="display: none;" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnPendingReceiptPreviewPDF" />
        <asp:AsyncPostBackTrigger ControlID="lnkReceipt" />
        <asp:AsyncPostBackTrigger ControlID="lnkAmendment" />
        <asp:AsyncPostBackTrigger ControlID="btnClearPdf" />
    </Triggers>
</asp:UpdatePanel>

<asp:HiddenField ID="hdnCurrentTabUploadReceiptPopUp" ClientIDMode="Static" runat="server" Value="lnkReceipt" />
