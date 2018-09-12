<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCLeftMenu.ascx.cs" Inherits="WEB.UnderWriting.Common.WUCLeftMenu" %>

<%--<asp:UpdatePanel ID="upLeftSearch" runat="server">
    <ContentTemplate>--%>

<!-- CASE SUMMARY -->
<li class="case-summ clear"><a href="#Case-Summary" id="aUnderwritingQueque" lnk="lnk" onclick="setCurrentAccordeon(this,'#hfLeftMenuAccordeon');"><span></span>
    <h4>Underwriting Queue</h4>
</a>
    <ul class="hg190">
        <li class="pd10 bgBL fl">

            <div class="under_queue">
                <asp:GridView ID="gvQueue" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                    <Columns>
                        <asp:TemplateField HeaderStyle-CssClass="c1" ItemStyle-CssClass="c1 borde_dorado">
                            <ItemTemplate>
                                <asp:Label ID="lblTabName" runat="server" Text='<%# Eval("TabName")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="On Time" HeaderStyle-CssClass="c2 dorada" ItemStyle-CssClass="c2 borde_dorado">
                            <ItemTemplate>
                                <asp:Label ID="lblOnTime" runat="server" Text='<%# Eval("OnTime")  %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Past Estimated Date" HeaderStyle-CssClass="c3 dorada" ItemStyle-CssClass="c3 borde_dorado">
                            <ItemTemplate>
                                <asp:Label ID="lblDelayed" runat="server" Text='<%# Eval("Delayed") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle CssClass="bgBL" />


                    <EmptyDataTemplate>
                        No data to display
                    </EmptyDataTemplate>
                    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />

                </asp:GridView>
            </div>


        </li>
    </ul>
</li>
<!-- advanced search -->
<li class="adv_search">
    <a href="#advanced-search" class="new" onclick="setCurrentAccordeon(this,'#hfLeftMenuAccordeon');" lnk="lnk" id="aAdvancedSearach"><span></span>
        <h4>ADVANCED SEARCH</h4>
    </a>
    <ul>
        <li class="pd0-10 fl">

            <div class="cont_blo" style="float: left; width: 100%; border: none; padding: 0px;">
                <!--advanced search-->
                <div class=" div_menu row">From</div>
                <asp:TextBox ID="dateFromTxt" runat="server" CssClass="datepicker" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="cont_blo">
                <div class=" div_menu row">To</div>
                <asp:TextBox ID="dateToTxt" runat="server" CssClass="datepicker" ClientIDMode="Static"></asp:TextBox>
            </div>

            <div class="cont_blo">
                <!--advanced search-->
                <div class=" div_menu">
                    search by policy #:
                </div>
                <asp:TextBox ID="txtSearchByPolicy" runat="server" CssClass="policy_no" ClientIDMode="Static"></asp:TextBox>
                <div class=" div_menu">
                    client:
                </div>
                <asp:TextBox ID="txtClient" runat="server" CssClass="policy_no" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="cont_blo">
                <!--advanced search-->
                <div class=" div_menu">
                    office
                </div>
                <asp:DropDownList runat="server" ID="OfficeDDL" DataValueField="Value" DataTextField="Text" ClientIDMode="Static" />

                <div class=" div_menu">
                    manager:
                </div>
                <asp:DropDownList runat="server" ID="ManagerDDL" DataValueField="Value" DataTextField="Text" ClientIDMode="Static" />

                <div class=" div_menu">
                    sub-manager:
                </div>
                <asp:DropDownList runat="server" ID="SubManagerDDL" DataValueField="Value" DataTextField="Text" ClientIDMode="Static" />

                <div class=" div_menu">
                    agent:
                </div>
                <asp:DropDownList runat="server" ID="AgentDDL" ClientIDMode="Static"></asp:DropDownList>

                <div class=" div_menu">
                    plan name
                </div>
                <asp:DropDownList runat="server" ID="PlanNameDDL" ClientIDMode="Static"></asp:DropDownList>

                <div class=" div_menu">
                    underwriter:
                </div>
                <asp:DropDownList runat="server" ID="UnderWriterDDL" ClientIDMode="Static" DataValueField="Value" DataTextField="Text"></asp:DropDownList>
            </div>
            <div class="cont_blo">
                <!--advanced search-->
                <div class=" alignC mT10">
                    <div class="boton_wrapper mR25 fl gris">
                        <span class="erase"></span>
                        <asp:Button ID="btnAdSearchClear" runat="server" Text="Clear All" CssClass="boton" OnClick="btnAdSearchClear_Click" />
                    </div>

                    <div class="boton_wrapper gradient_vd2 bdrVd2">
                        <span class="save"></span>
                        <asp:Button ID="btnAdSearchSubmit" runat="server" Text="Submit" CssClass="boton" OnClick="btnAdSearchSubmit_Click" OnClientClick="return ValidateSearchField();" />
                    </div>
                </div>
            </div>
        </li>
    </ul>
</li>
<!--end menu-->
<%-- </ul>--%>
<!--end ul acordeon-->
<%--</div>--%>
<!--accordion-->
<div class="copy_version">
    <asp:Label ID="lblVersionNo" runat="server"></asp:Label>
</div>
<%--</div>--%>
<asp:HiddenField ID="hfLeftMenuAccordeon" runat="server" ClientIDMode="Static" Value="" />
<asp:HiddenField ID="hfSelectedManager" runat="server" ClientIDMode="Static" Value="-1" />
<asp:HiddenField ID="hfSelectedSubManager" runat="server" ClientIDMode="Static" Value="-1" />
<asp:HiddenField ID="hfSelectedAgent" runat="server" ClientIDMode="Static" Value="-1" />

<%--    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ManagerDDL" />
        <asp:AsyncPostBackTrigger ControlID="OfficeDDL" />
        <asp:AsyncPostBackTrigger ControlID="SubManagerDDL" />
    </Triggers>
</asp:UpdatePanel>--%>
