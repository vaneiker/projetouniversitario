<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCOfficeAgent.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.OfficeAgent.UCOfficeAgent" %>
<div class="tbl mB">
    <asp:Repeater ID="rptData" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="">
                    <td align="left" class="c1">
                        <div>Agent Name:</div>
                    </td>
                    <td align="left" class="c2">
                        <div><%# Eval("FullName")%></div>
                    </td>
                    <td align="left" class="c3">
                        <div>Office:</div>
                    </td>
                    <td align="left" class="c4">
                        <div><%# Eval("OfficeDescription")%></div>
                    </td>
                </tr>
                <tr class="">
                    <td align="left" class="c1">
                        <div>Comm Table:</div>
                    </td>
                    <td align="left" class="c2">
                        <div><%# Eval("CommTable")%></div>  
                    </td>
                    <td align="left" class="c3">
                        <div>Product Name:</div>
                    </td>
                    <td align="left" class="c4">
                        <div><%# Eval("ProductDescription")%></div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</div>

<div class="tbl_1">
    <asp:GridView ID="gvAllAgents" runat="server" AutoGenerateColumns="false" DataKeyNames="" CellPadding="0" CellSpacing="0">
        <Columns>
            <asp:TemplateField HeaderText="Levels" HeaderStyle-CssClass="c1 gradient_azul pdL-10 alignL" ItemStyle-CssClass="c1">
                <ItemTemplate>
                    <div><%# Eval("PositionDescription")%></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" HeaderStyle-CssClass="c1 gradient_azul pdL-10 alignL">
                <ItemTemplate>
                    <div><%# Eval("FullName")%></div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
