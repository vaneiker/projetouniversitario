<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAllFinancialInformationReceived.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.FinancialInfo.UCAllFinancialInformationReceived" %>
<ul class="secundario" style="display: none;">
    <li class="allfinfo">
        <asp:UpdatePanel ID="upFinancialDocs" runat="server">
            <ContentTemplate>
               <div class="tbl data_G">
                    <asp:GridView ID="gvFinancialDocuments" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                        DataKeyNames="RequirementCatId,RequirementTypeId,RequirementDocId,ContactId,RequirementId"
                        PageSize="5" AllowPaging="true" OnPageIndexChanging="gvFinancialDocuments_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Document Name" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <div>
                                        <%# Eval("RequirementTypeDesc") %>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Requested" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c2">
                                <ItemTemplate>
                                    <%# Eval("RequestedDate","{0:MM/dd/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Date Received" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c3">
                                <ItemTemplate>
                                    <%# Eval("ReceivedDate","{0:MM/dd/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="View PDF" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c4">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkViewPdf" runat="server" CssClass='<%# ((bool)Eval("IsComplete") ? "pulse pdf_ico": "pulse up_icon") %>' OnClientClick="$('#SaveBtn').prop('disabled', true);" OnClick="lnkViewPdf_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
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
                        <EmptyDataTemplate>
                            <div style="border-bottom-width: 0px; color: #F00 !important; text-align: center;" class="dxgv dxgvEmptyDataRow">
                                No data to display
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <asp:HiddenField runat="server" ID="hdnFinancialPDF" ClientIDMode="Static" Value="false" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </li>
</ul>
