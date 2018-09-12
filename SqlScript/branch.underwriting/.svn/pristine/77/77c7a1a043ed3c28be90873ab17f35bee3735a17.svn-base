<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCGroupedView.ascx.cs" Inherits="WEB.UnderWriting.Dashboard.UserControls.AlertRerport.WUCGroupedView" %>
<div id="contenedor_groupedview">

    <div id="top_groupedview">
        <table style="width: 894px">
            <tr>
                <td class="titulo_alert">
                    <p>
                        <asp:literal id="lblAlertReason" text="Alert Reason" runat="server" />
                    </p>
                </td>
                <td class="titulo_alert">
                    <p>

                        <asp:literal runat="server" id="lblQuantity" text="Quantity" />

                    </p>
                </td>
                <td class="titulo_alert">
                    <p>
                        <asp:literal runat="server" id="lblPremium" text="Premium" />
                    </p>
                </td>
                <td class="titulo_alert">
                    <p>
                        <asp:literal runat="server" id="lblInsured" text="Insured" />
                    </p>
                </td>
            </tr>
        </table>
    </div>

    <div id="content_groupedview" class="leu">

        <asp:GridView runat="server" ID="gvGroupedView" ShowHeader="False" AutoGenerateColumns="False" ClientIDMode="Static" CellPadding="0"
            CellSpacing="0" BorderStyle="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table style="width: 877px">
                            <tr>
                                <td>
                                    <p><a href="standardtimes_overdue.html">Standard Times Over Due</a></p>
                                </td>
                                <td>
                                    <p>15</p>
                                </td>
                                <td>
                                    <p>$350.00</p>
                                </td>
                                <td>
                                    <p>$120,000.00</p>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </div>

</div>
