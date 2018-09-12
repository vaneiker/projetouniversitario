<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Riders.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.PolicyDetail.Riders" %>
<div class="tbl data_G">
    <asp:GridView ID="gvRiders" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ClientIDMode="Static">
        <Columns>
            <asp:TemplateField HeaderText="Tipo de Rider" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="c1">
                <ItemTemplate>
                    <asp:Label ID="lblDocumentName" runat="server" Text='<%# Eval("Ryder_Type_Desc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Monto de Beneficio" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c2" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="c2">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Beneficiary_Amount_F") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de Inicio" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c3" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c3">
                <ItemTemplate>
                    <asp:Label ID="lblDocumentDate" runat="server" Text='<%# Eval("Effective_Date_F") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha de Expiración" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c4" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c4">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Expire_Date_F") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="# de Años" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c5" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c5">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Number_Of_Year") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sobre Prima" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c6" ItemStyle-HorizontalAlign="Right" ItemStyle-CssClass="c6">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Extra_Premium_F") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razón Declinada o Excluida" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c7" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c7">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Extra_Premium_Comments") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Estatus" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="c8" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="c8">
                <ItemTemplate>
                    <asp:Label ID="lblUploadDate" runat="server" Text='<%# Eval("Rider_Status_Desc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No hay data para mostrar
        </EmptyDataTemplate>
        <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" CssClass="EmptyGrid" />
        <HeaderStyle CssClass="gradient_azul" />
    </asp:GridView>
</div>
