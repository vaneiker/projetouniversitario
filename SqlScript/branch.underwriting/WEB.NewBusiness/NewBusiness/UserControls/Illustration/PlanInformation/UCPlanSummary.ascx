<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPlanSummary.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.PlanInformation.UCAxysSummary" %>
<div class="titulos_azules">
    <strong>
        <asp:Literal ID="ltrPlanTitle" runat="server" /></strong>
</div>
<div class="content_fondo_blanco overflow_hidden">
    <div class="details_grid overflow_auto">
        <table>
            <asp:Repeater runat="server" ID="rpPlanSummary">
                <ItemTemplate>
                    <tr>
                        <td class="titulo"><%#Eval("Key")%></td>
                        <td>
                            <div>
                                <%#Eval("Value")%>
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <!--details_grid-->
</div>
