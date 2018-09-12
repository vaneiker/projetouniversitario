<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopPerzonalizedProfile.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.PolicyPlanData.UCPopPerzonalizedProfile" %>
<asp:UpdatePanel ID="upPerProfile" runat="server">
    <ContentTemplate>
        <div class="pp_distribution ">
            <div class="cont">
                <div class=" wd49 fl mR-2-p mB">
                    <label class="label">Policy #:</label>
                    <asp:TextBox ID="txtIPPolicy" runat="server" ReadOnly="true"></asp:TextBox>
                    <label class="label">Plan Name:</label>
                    <asp:TextBox ID="txtIPPlanName" runat="server" ReadOnly="true"></asp:TextBox>
                    <label class="label">Investment Profile:</label>
                    <asp:TextBox ID="txtIPInvestmentProfile" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <div class=" wd49 fl mB15">
                    <label class="label">Currency:</label>
                    <asp:TextBox ID="txtIPCurrency" runat="server" ReadOnly="true"></asp:TextBox>
                    <label class="label">Plan Type:</label>
                    <asp:TextBox ID="txtIPPlanType" runat="server" ReadOnly="true"></asp:TextBox>
                    <label class="label">Profile Type:</label>
                    <asp:TextBox ID="txtIPProfileType" runat="server" ReadOnly="true"></asp:TextBox>
                </div>
                <label class="label wd100 txtBold fl">Profile Distribution</label>
                <div class="data_G tbl wd100 fl" style="max-height: 430px; overflow-y: scroll;">
                    <asp:GridView ID="gvPopProfileDistribution" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
                        DataKeyNames="SymbolId, InvstProductDate, InvestmentProfileDate, StockExchangeId, ProjectionRate, InvestmentCurrency,
                         MinPercentAllowed, MaxPercentAllowed,  InitialValidDate, EndValidDate, Symbol, SymbolDesc, InvestProductDateId">
                        <Columns>
                            <asp:TemplateField HeaderText="Symbol" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <%# Eval("Symbol") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c2">
                                <ItemTemplate>
                                    <%# Eval("SymbolDesc") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Percentage" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c3">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPDPercentage" CssClass="PPDecimalFormat PDPercentage" runat="server" onBlur="SetPPTotalPercent(this);"
                                        Text='<%# Eval("InvstProfilePercent") == null? "0.00"  : Decimal.Parse(Eval("InvstProfilePercent").ToString()).ToString("N2") %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                            <div style="border-bottom-width: 0px; color: #F00 !important; text-align: center;" class="dxgv dxgvEmptyDataRow">
                                No data to display
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
                <div class="tbl wd100 mB fl">
                    <table>
                        <tr class="gradient_gris">
                            <td align="left" class="c1"></td>
                            <td align="right" class="c2">
                                <div>TOTAL DISTRIBUTION</div>
                            </td>
                            <td align="center" class="c3" style="width: 13.6%;">
                                <asp:TextBox ID="txtPPTotalPercent" ClientIDMode="Static" runat="server" Text="0.00%" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="wd100 fl hg35">
                    <div class="boton_wrapper gradient_vd2 bdrVd2 fr mR">
                        <span class="save"></span>
                        <asp:Button ID="btPerPronSave" runat="server" ClientIDMode="Static" CssClass="boton" Text="Save" OnClick="btPerPronSave_Click" OnClientClick="return ValidatePerProfileTotal();" />
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnPIPProfTypeId" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btPerPronSave" />
    </Triggers>
</asp:UpdatePanel>
