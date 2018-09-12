<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRiskClass.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCRiskClass" %>

<asp:UpdatePanel runat="server" ID="udpRiskClass">
    <ContentTemplate>
        <!-- RISK  -->

        <div class="add_line fl mT">
            <span class="label  txtBold sub_ttl fl">
                <asp:Label ID="lblContactType" runat="server" Text="INSURED"></asp:Label>
            </span>

            <%--<span class="label sub_ttl txtBold fl">SUGGESTED CLASSIFICATION: STANDARD</span>--%>
            <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr">
                <span class="add"></span>
                <asp:Button runat="server" ID="btnAddNewRisk" CssClass="boton" Text="Add New Risk" ClientIDMode="Static" OnClick="btnAddNewRisk_Click" />
            </div>
        </div>
        <span class="label txtBold sub_ttl fl">Life </span>
        <div class="data_G tbl">
            <asp:GridView ID="gvRiskLife" DataKeyNames="RiskId, SequenceReference, YearToReconsider, Duration,TableRating, PerThousandRating"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvRisks_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="RiskType" runat="server" Text='<%# Eval("RyderTypeDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--Bmarroquin 04-03-2017 que no muestre el Reason Description--%>
<%--                    <asp:TemplateField HeaderText="Rate Reason" HeaderStyle-CssClass="c2" >
                        <ItemTemplate>
                            <asp:Label ID="Category" runat="server" Text='<%# Eval("ReasonDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Table Rating" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="TableRaiting" runat="server" Text='<%# Eval("CreditDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Per Thousand" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="PerThousand" runat="server" Text='<%# Eval("PerThousandRating") == null? "" : Decimal.Parse(Eval("PerThousandRating").ToString()).ToString("N2")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="Duration" runat="server" Text='<%# Eval("Duration ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="StartDate" runat="server" Text='<%#  Eval("StartDate") != null? DateTime.Parse(Eval("StartDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Years to Reconsider" HeaderStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="Recondider" runat="server" Text='<%# Eval("YearToReconsider ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reconsider Date" HeaderStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="RecondiderDate" runat="server" Text='<%#  Eval("ReconsiderDate") != null? DateTime.Parse(Eval("ReconsiderDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="c9">
                        <ItemTemplate>
                            <asp:Label ID="EndDate" runat="server" Text='<%#  Eval("EndDate") != null? DateTime.Parse(Eval("EndDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c10">
                        <ItemTemplate>
                            <asp:Label ID="Status" runat="server" Text='<%# Eval("StatusDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="c11">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnLifeEditRisk" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="btnLifeEditRisk_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c12">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnLifeDeleteRisk" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="btnLifeDeleteRisk_Click" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>
        </div>
        <div class="total" style="display:none;">
            <div class="box mT10  wd15_pdR fl alignR">
                TABLE RATING:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCLifeTableRating" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                PER THOUSAND:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCLifePerThousand" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                ACTIONS:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCLifeActions" ClientIDMode="Static" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>


        <span class="label txtBold sub_ttl fl">Accidental Death and Dismemberment</span>
        <div class="data_G tbl">
            <asp:GridView ID="gvRiskADB" DataKeyNames="RiskId, SequenceReference, YearToReconsider, Duration,TableRating, PerThousandRating"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvRiskADB_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="RiskType" runat="server" Text='<%# Eval("RyderTypeDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%--Bmarroquin 04-03-2017 que no muestre el Reason Description--%>
<%--                    <asp:TemplateField HeaderText="Rate Reason" HeaderStyle-CssClass="c2" >
                        <ItemTemplate>
                            <asp:Label ID="Category" runat="server" Text='<%# Eval("ReasonDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Table Rating" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="TableRaiting" runat="server" Text='<%# Eval("CreditDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Per Thousand" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="PerThousand" runat="server" Text='<%# Eval("PerThousandRating") == null? "" : Decimal.Parse(Eval("PerThousandRating").ToString()).ToString("N2")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="Duration" runat="server" Text='<%# Eval("Duration ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="StartDate" runat="server" Text='<%#  Eval("StartDate") != null? DateTime.Parse(Eval("StartDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Years to Reconsider" HeaderStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="Recondider" runat="server" Text='<%# Eval("YearToReconsider ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reconsider Date" HeaderStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="RecondiderDate" runat="server" Text='<%#  Eval("ReconsiderDate") != null? DateTime.Parse(Eval("ReconsiderDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="c9">
                        <ItemTemplate>
                            <asp:Label ID="EndDate" runat="server" Text='<%#  Eval("EndDate") != null? DateTime.Parse(Eval("EndDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c10">
                        <ItemTemplate>
                            <asp:Label ID="Status" runat="server" Text='<%# Eval("StatusDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="c11">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnADBEditRisk" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="btnADBEditRisk_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c12">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnADBDeleteRisk" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="btnADBDeleteRisk_Click" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>
        </div>
        <div class="total" style="display:none;">
            <div class="box mT10  wd15_pdR fl alignR">
                TABLE RATING:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCADBTableRating" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                PER THOUSAND:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCADBPerThousand" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                ACTIONS:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCADBActions" ClientIDMode="Static" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <%-- Bmarroquin 03-02-2017 a raiz de tropicalizacion ESA, se agregan grids de Risk para las coberturas adicioanles --%>
        <span class="label txtBold sub_ttl fl">Disability Advance Payment Benefit</span>
        <div class="data_G tbl">
            <asp:GridView ID="gvRiskITP" DataKeyNames="RiskId, SequenceReference, YearToReconsider, Duration,TableRating, PerThousandRating"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvRiskITP_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="RiskType" runat="server" Text='<%# Eval("RyderTypeDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%--Bmarroquin 04-03-2017 que no muestre el Reason Description--%>
<%--                    <asp:TemplateField HeaderText="Rate Reason" HeaderStyle-CssClass="c2" >
                        <ItemTemplate>
                            <asp:Label ID="Category" runat="server" Text='<%# Eval("ReasonDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Table Rating" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="TableRaiting" runat="server" Text='<%# Eval("CreditDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Per Thousand" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="PerThousand" runat="server" Text='<%# Eval("PerThousandRating") == null? "" : Decimal.Parse(Eval("PerThousandRating").ToString()).ToString("N2")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="Duration" runat="server" Text='<%# Eval("Duration ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="StartDate" runat="server" Text='<%#  Eval("StartDate") != null? DateTime.Parse(Eval("StartDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Years to Reconsider" HeaderStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="Recondider" runat="server" Text='<%# Eval("YearToReconsider ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reconsider Date" HeaderStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="RecondiderDate" runat="server" Text='<%#  Eval("ReconsiderDate") != null? DateTime.Parse(Eval("ReconsiderDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="c9">
                        <ItemTemplate>
                            <asp:Label ID="EndDate" runat="server" Text='<%#  Eval("EndDate") != null? DateTime.Parse(Eval("EndDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c10">
                        <ItemTemplate>
                            <asp:Label ID="Status" runat="server" Text='<%# Eval("StatusDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="c11">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnITPEditRisk" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="btnITPEditRisk_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c12">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnITPDeleteRisk" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="btnITPDeleteRisk_Click" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>
        </div>
        <div class="total" style="display:none;">
            <div class="box mT10  wd15_pdR fl alignR">
                TABLE RATING:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCITPTableRating" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                PER THOUSAND:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCITPPerThousand" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                ACTIONS:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCITPActions" ClientIDMode="Static" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <span class="label txtBold sub_ttl fl">Funeral Expenses</span>
        <div class="data_G tbl">
            <asp:GridView ID="gvRiskGF" DataKeyNames="RiskId, SequenceReference, YearToReconsider, Duration,TableRating, PerThousandRating"
                runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvRiskGF_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="RiskType" runat="server" Text='<%# Eval("RyderTypeDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%--Bmarroquin 04-03-2017 que no muestre el Reason Description--%>
<%--                    <asp:TemplateField HeaderText="Rate Reason" HeaderStyle-CssClass="c2" >
                        <ItemTemplate>
                            <asp:Label ID="Category" runat="server" Text='<%# Eval("ReasonDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Table Rating" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="TableRaiting" runat="server" Text='<%# Eval("CreditDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Per Thousand" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="PerThousand" runat="server" Text='<%# Eval("PerThousandRating") == null? "" : Decimal.Parse(Eval("PerThousandRating").ToString()).ToString("N2")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Duration" HeaderStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="Duration" runat="server" Text='<%# Eval("Duration ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="StartDate" runat="server" Text='<%#  Eval("StartDate") != null? DateTime.Parse(Eval("StartDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Years to Reconsider" HeaderStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="Recondider" runat="server" Text='<%# Eval("YearToReconsider ") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reconsider Date" HeaderStyle-CssClass="c8">
                        <ItemTemplate>
                            <asp:Label ID="RecondiderDate" runat="server" Text='<%#  Eval("ReconsiderDate") != null? DateTime.Parse(Eval("ReconsiderDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="c9">
                        <ItemTemplate>
                            <asp:Label ID="EndDate" runat="server" Text='<%#  Eval("EndDate") != null? DateTime.Parse(Eval("EndDate").ToString()).ToString("MM/dd/yyy"): ""%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="c10">
                        <ItemTemplate>
                            <asp:Label ID="Status" runat="server" Text='<%# Eval("StatusDesc")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="c11">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnGFEditRisk" ClientIDMode="Static" runat="server" CssClass="edit_file" OnClick="btnGFEditRisk_Click" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="c12">
                        <ItemTemplate>
                            <div>
                                <asp:Button ID="btnGFDeleteRisk" ClientIDMode="Static" runat="server" CssClass="delete_file" OnClick="btnGFDeleteRisk_Click" OnClientClick="return DlgConfirm(this);" />
                            </div>
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

                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>
        </div>
        <div class="total" style="display:none;">
            <div class="box mT10  wd15_pdR fl alignR">
                TABLE RATING:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCGFTableRating" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                PER THOUSAND:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCGFPerThousand" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd15_pdR fl alignR">
                ACTIONS:
            </div>
            <div class="box  wd15_pdR fl">
                <asp:TextBox ID="txtRCGFActions" ClientIDMode="Static" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <%-- ****************  Fin Cambios Bmarroquin 03-02-2017   **************  --%>

        <!-- CREDIT  -->
        <div class="add_line fl mT20">
            <span class="label txtBold sub_ttl fl">CREDITS </span>
            <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr">
                <span class="add"></span>
                <asp:Button runat="server" ID="btnNewCredit" CssClass="boton" Text="Add New Credit" ClientIDMode="Static" OnClick="btnNewCredit_Click" />
            </div>
        </div>
        <div class="data_G tbl">
            <asp:GridView ID="gvCredit" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvCredit_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Credit Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="CreditType" runat="server" Text='<%# Eval("CreditTypeDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="RiskType" runat="server" Text='  <%# (Eval("CreditTypeId") !=null  ? 
                                                                                        (int.Parse(Eval("CreditTypeId").ToString()) == 2? 
                                                                                               Eval("TableRating") == null? "" : Decimal.Parse(Eval("TableRating").ToString()).ToString("N0") +  "%"
                                                                                        : Eval("TableRating") == null? "" : Decimal.Parse(Eval("TableRating").ToString()).ToString("N2")+ "")  
                                                                                 : ""  ) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="Category" runat="server" Text='<%# Eval("CreditReasonDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:Label ID="TableRaiting" runat="server" Text='<%# Eval("Comment")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" />
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
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>
        </div>

        <div class="total" style="display:none;">
            <div class="box sub_ttl mT10 wd20_pdR fl">
                SYSTEM RESULTS:
            </div>
            <div class="box mT10  wd20_pdR fl alignR">
                TOTAL TABLE RATING:
            </div>
            <div class="box  wd20_pdR fl">
                <asp:TextBox ID="txtRCTTableRating" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
            <div class="box mT10  wd20_pdR fl alignR">
                TOTAL PER THOUSAND:
            </div>
            <div class="box  wd20_pdR fl">
                <asp:TextBox ID="txtRCTPerThousand" ClientIDMode="Static" runat="server" ReadOnly="true" CssClass="alignR"></asp:TextBox>
            </div>
        </div>

        <!--EXCLUSION -->
        <div class="add_line fl mT20">
            <span class="label sub_ttl txtBold fl">EXCLUSION</span>
            <div class="boton_wrapper gradient_AM_btn bdrAM txtNG-f fr">
                <span class="add"></span>
                <asp:Button runat="server" ID="btnNewExclusion" CssClass="boton" Text="Add New Exclusion" ClientIDMode="Static" OnClick="btnNewExclusion_Click" />
            </div>
        </div>
        <div class="mB22 data_G tbl">
            <asp:GridView ID="gvExclusion" DataKeyNames="Comment,StartDate,SequenceReference,RiskId,UnderwriterName" runat="server" AutoGenerateColumns="false"
                ShowHeaderWhenEmpty="true" AllowPaging="true" PageSize="3" OnPageIndexChanging="gvExclusion_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="Exclusion Type" HeaderStyle-CssClass="c1">
                        <ItemTemplate>
                            <asp:Label ID="ExclusionTypeDesc" runat="server" Text='<%# Eval("ExclusionTypeDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Exclusion" HeaderStyle-CssClass="c2">
                        <ItemTemplate>
                            <asp:Label ID="ExclusionDesc" runat="server" Text='<%# Eval("ExclusionDesc")  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Requested By" HeaderStyle-CssClass="c3">
                        <ItemTemplate>
                            <asp:Label ID="RequestedBy" runat="server" Text='<%# Eval("RequestedByName")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="comment_icon" runat="server" ID="lnkComment" OnClick="lnkComment_Click" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Start Date" HeaderStyle-CssClass="c5">
                        <ItemTemplate>
                            <asp:Label ID="StartDate" runat="server" Text='<%# Eval("StartDate")  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Notification Date" HeaderStyle-CssClass="c6">
                        <ItemTemplate>
                            <asp:Label ID="NotificationDate" runat="server" Text='<%# Eval("NotificationDate") != null? DateTime.Parse(Eval("NotificationDate").ToString()).ToString("MM/dd/yyy"): ""  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" HeaderStyle-CssClass="c7">
                        <ItemTemplate>
                            <asp:Label ID="EndDate" runat="server" Text='<%# Eval("EndDate") != null? DateTime.Parse(Eval("EndDate").ToString()).ToString("MM/dd/yyy"): ""  %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Terminate Exclusion" HeaderStyle-CssClass="c4">
                        <ItemTemplate>
                            <asp:LinkButton CssClass="cancel-icon" runat="server" ID="lnkTerminateExclusion" OnClick="lnkTerminateExclusion_Click" Visible='<%#int.Parse(Eval("RiskRateStatusId").ToString())!=4%>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
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
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
                <HeaderStyle CssClass="gradient_azul" />
                <PagerStyle CssClass="RCFooterPad" />
            </asp:GridView>

        </div>
        <asp:HiddenField ID="hdnIsAditional" runat="server" ClientIDMode="Static" Value="false" />
        <asp:HiddenField ID="hdnContactId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnContactRoleTypeId" runat="server" ClientIDMode="Static" />
    </ContentTemplate>
</asp:UpdatePanel>



