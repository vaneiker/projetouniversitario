<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAmendments.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCAmendments" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Src="~/Case/UserControls/PolicyPlanData/UCRequestAmendments.ascx" TagPrefix="uc1" TagName="UCRequestAmendments" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<ul class="secundario">
    <li class="pp_amend">
        <div class=" head">
            <div class="boton_wrapper gradient_vd2 bdrVd2 mT7">
                <span class="amen_info"></span>
                <asp:Button runat="server" ID="btnRequestAmendments" Text="Request Amendments" CssClass="boton" OnClick="btnRequestAmendments_Click" />
            </div>
        </div>
        <PdfViewer:PdfViewer ID="pdfViewerID" CssClass="PdfViewer" runat="server" Height="347" Width="910"
            ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Visible="false">
        </PdfViewer:PdfViewer>
        <%--        <iframe src="<%=ResolveClientUrl("~/pdf/enmienda.pdf")%>" width="100%" id="iframe"></iframe>--%>
        <asp:UpdatePanel ID="upAmendments" ClientIDMode="Static" runat="server">
            <ContentTemplate>
                 <div class="tbl data_G">
                <asp:GridView ID="gvAmendments"  runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="CorpId,RegionId,CountryId,DomesticregId,StateProvId,CityId,OfficeId,CaseSeqNo,HistSeqNo,DocCategoryId,DocTypeId,DocumentId"
                    OnPageIndexChanging="gvAmendments_PageIndexChanging" AllowPaging="true" PageSize="3">


                    <Columns>
                        <asp:TemplateField HeaderText="Insured" HeaderStyle-CssClass="c1" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("InsuredScopeDesc") %>' ID="lblInsured" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Template" HeaderStyle-CssClass="c2" ItemStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("AmmendTypeDesc") %>' ID="lblTemplate" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date" HeaderStyle-CssClass="c3" ItemStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("AmmendmentDate") %>' ID="lblDate" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="PDF Files" HeaderStyle-CssClass="c4" ItemStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="lnkPdfButton" CssClass="pdf_file" OnClick="lnkPdfButton_Click" runat="server" Visible='<%# Eval("Status").ToString().ToLower().Trim() == "completed"%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c5" ItemStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("Status") %>' ID="lblStatus" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>


                    <PagerTemplate>

                        <div class="pagination">
                            <p>
                                Page
                            <asp:Literal ID="indexPage" runat="server" />
                                of
                            <asp:Literal ID="totalPage" runat="server" />
                                (<asp:Literal ID="totalItems" runat="server" />
                                items)
                            </p>
                            <asp:LinkButton runat="server" CssClass="rewd" CommandName="Page" CommandArgument="First" ID="firstButton" />
                            <asp:LinkButton runat="server" CssClass="prev" CommandName="Page" CommandArgument="Prev" ID="prevButton" />

                            <asp:LinkButton runat="server" CssClass="next" CommandName="Page" CommandArgument="Next" ID="nextButton" />
                            <asp:LinkButton runat="server" CssClass="fwrd" CommandName="Page" CommandArgument="Last" ID="lastButton" />
                        </div>

                    </PagerTemplate>
                    <PagerStyle CssClass="RCFooterPad" />
                    <HeaderStyle CssClass="gradient_azul" />
                    <EmptyDataTemplate>
                        No data to display
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                </asp:GridView>
                     </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvAmendments" />
            </Triggers>

        </asp:UpdatePanel>
    </li>
</ul>

<div id="dvRequestAmendments" style="display: none; padding: 0">
    <uc1:UCRequestAmendments runat="server" ID="UCRequestAmendments" />
</div>
<asp:HiddenField runat="server" ID="hfRequestAmendments" ClientIDMode="Static" Value="false" />
