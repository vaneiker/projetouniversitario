<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCGridPaginator.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Common.WUCGridPaginator" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <div class="pagination">
                        <p>
                            <asp:Literal runat="server" ID="ltPageInformation"> Page 1 of 2 (4 items) </asp:Literal>
                        </p>
                        <asp:Button CssClass="rewd" runat="server" ID="btnFirstPage" OnClick="btnFirstPage_Click" OnClientClick="BeginRequestHandler(this)" />
                        <asp:Button CssClass="prev_dis" runat="server" ID="btnPrior" OnClick="btnPrior_Click" OnClientClick="BeginRequestHandler(this)" />
                        <asp:LinkButton runat="server" ID="hlkCurrent" CssClass="current" OnClick="hlkNumber_Click"> 1 </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="hlkNumber" CssClass="numbers" OnClick="hlkNumber_Click"> 2 </asp:LinkButton>
                        <asp:Button CssClass="next" runat="server" ID="btnNext" OnClick="btnNext_Click" OnClientClick="BeginRequestHandler(this)" />
                        <asp:Button CssClass="fwrd" runat="server" ID="btnLastPage" OnClick="btnLastPage_Click" OnClientClick="BeginRequestHandler(this)" />
                    </div>
                    <!--pagination-->
                </td>
            </tr>
        </table>
        <asp:HiddenField runat="server" ID="hdnTotalPage" Value="0" />
        <asp:HiddenField runat="server" ID="hfCurrentPage" Value="1" />
        <asp:HiddenField runat="server" ID="hdnTotalRecord" Value="0" />
        <asp:HiddenField runat="server" ID="hdnRecordPerPage" Value="0" />
        <asp:HiddenField runat="server" ID="hdnSessionGridName" Value="" />
    </ContentTemplate>
</asp:UpdatePanel>

