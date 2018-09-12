<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAmmendments.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Popups.UCAmmendments" %>
<%@ Register TagPrefix="PdfViewer" Namespace="PdfViewer4AspNet" Assembly="PdfViewerAspNet, Version=3.1.0.29040, Culture=neutral, PublicKeyToken=5b5f377bc08a4d32" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:UpdatePanel runat="server" ID="upPopAmmendment">
    <ContentTemplate>
        <div class="enmienda_pp modal pop1" id="dvPopAmmendment">
            <header>
                <h1>ENMIENDA</h1>
                <a data-modal-close="true" href="#" onclick="CloseAjaxPop(this, 'hdnShowAmmendments');" popname="mpAmmendments">&times;</a>
            </header>
            <!--GRID-->
            <div class="col-5 fl pdR">
                <!--GRID PRINCIPAL-->
                <div class="row_A hei185">
                    <div class="tbl data_G">
                        <asp:GridView ID="gvPopAmmendments" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ClientIDMode="Static"
                            DataKeyNames="Corp_Id,Region_Id,Country_Id,Domesticreg_Id,State_Prov_Id,City_Id,Office_Id,Case_Seq_No,Hist_Seq_No,Ammendment_Id,Is_Completed, Doc_Type_Id, Doc_Category_Id, Document_Id,Comments"
                            OnPageIndexChanging="gvPopAmmendments_PageIndexChanging" AllowPaging="true" PageSize="3">
                            <Columns>
                                <asp:TemplateField HeaderText="Persona" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentName" runat="server" Text='<%# Eval("Insured_Scope_Desc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tipo" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c2">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Ammend_Type_Desc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha de Subida" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentDate" runat="server" Text='<%# Eval("Uploaded_On_F") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PDF" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                                    <ItemTemplate>
                                        <asp:UpdatePanel runat="server" ID="upPopAmmendment">
                                            <ContentTemplate>
                                                <asp:LinkButton runat="server" ID="btnPdf" CssClass="ico_G pdf" Visible='<%# (bool) (Eval("Is_Completed") ?? false) %>' OnClick="btnPDF_OnClick" />

                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnPdf" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:LinkButton runat="server" ID="btnUploadPdf" CssClass="ico_G upload" Visible='<%# !((bool) (Eval("Is_Completed") ?? false))  %>' OnClientClick='<%# "return btnUploadAmmendmentClick("+ Container.DataItemIndex + ",\"#hdnAmmendmentIndex\");"  %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c5">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Status_Desc") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                            <PagerTemplate>
                                <div class="pagination m0">
                                    <p>
                                        Página
                            <asp:Literal ID="indexPage" runat="server" />
                                        de
                            <asp:Literal ID="totalPage" runat="server" />
                                        (<asp:Literal ID="totalItems" runat="server" />
                                        elementos)
                                    </p>
                                    <asp:UpdatePanel runat="server" ID="upPopAmmendment">
                                        <ContentTemplate>
                                            <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                                            <asp:LinkButton runat="server" CssClass="prev_dis" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                                            <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                                            <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="firstButton" />
                                            <asp:AsyncPostBackTrigger ControlID="prevButton" />
                                            <asp:AsyncPostBackTrigger ControlID="nextButton" />
                                            <asp:AsyncPostBackTrigger ControlID="lastButton" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </PagerTemplate>
                            <EmptyDataTemplate>
                                No hay data para mostrar
                            </EmptyDataTemplate>
                            <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" CssClass="EmptyGrid" />
                            <HeaderStyle CssClass="gradient_azul" />
                        </asp:GridView>
                    </div>
                </div>
                <!--GRID PRINCIPAL /> -->
                <div class="row_A mT20">
                    <asp:TextBox runat="server" ID="txtAmmendmentComment" CssClass="hei266 textarea_pink" placeholder="Escriba aqui" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <!--PDF-->
            <div class="col-7 fl">
                <div class=" row_box hei462">
                    <PdfViewer:PdfViewer ID="pdfAmmendments" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="764px" Height="440px">
                    </PdfViewer:PdfViewer>
                </div>
            </div>
            <!--PDF /> -->
            <div class="col-12 fl">
                <asp:LinkButton runat="server" ID="lnkReemplazarAmmendment" CssClass="btn bfusia fr" Text="Reemplazar" OnClick="lnkReemplazarAmmendment_OnClick"></asp:LinkButton>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hdnAmmendmentPath" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnAmmendmentIndex" ClientIDMode="Static" />
        <div style="display: none;">
            <dx:ASPxUploadControl ID="fuPopAmmendments" ClientInstanceName="fuPopAmmendments" runat="server" OnFileUploadComplete="fuPopAmmendments_OnFileUploadComplete" ValidationSettings-AllowedFileExtensions=".pdf">
                <ClientSideEvents TextChanged="uploadFileChange" FileUploadComplete="fuAmmendmentFileComplete" />
            </dx:ASPxUploadControl>
            <asp:Button runat="server" ID="btnUploadAmmendment" ClientIDMode="Static" OnClick="btnUploadAmmendment_OnClick" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
