<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirementTable.ascx.cs" Inherits="WEB.UnderWriting.Case.UserControls.Requirements.UCRequirementTable" %>
<%@ Register Src="~/Case/UserControls/Requirements/UCRequirementPdfPopUp.ascx" TagPrefix="uc1" TagName="UCRequirementPdfPopUp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AJAX" %>

<asp:GridView ID="gvRequeriment" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true"
    DataKeyNames="RequirementCatId,RequirementTypeId,RequirementDocId,ContactId,RequirementId">
    <Columns>
        <asp:TemplateField HeaderText="Requirement" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <div>
                    <%# Eval("RequirementTypeDesc") %>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c1" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <div>
                    <%# Eval("RoleDesc") %>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Requested By" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c2">
            <ItemTemplate>
                <%# Eval("RequestedByUserName") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date Requested" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c3">
            <ItemTemplate>
                <%# Eval("RequestedDate","{0:MM/dd/yyyy}") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Date Uploaded" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c4">
            <ItemTemplate>
                <%# Eval("ReceivedDate","{0:MM/dd/yyyy}") %>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="View / Upload Final Document" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c5">
            <ItemTemplate>
                <asp:LinkButton runat="server" CssClass='<%# ((bool)Eval("IsComplete") ? "pulse pdf_ico": "pulse up_icon") %>' OnClick="LoadPdfPopUp" OnClientClick="$('#SaveBtn').prop('disabled', true);"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Communications / Preview Document" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c6">
            <ItemTemplate>
                <asp:LinkButton runat="server" CssClass="email" OnClick="RequirementComunicationBTN_Click"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Send To Reinsurance" HeaderStyle-CssClass="gradient_azul" ItemStyle-CssClass="c7" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:CheckBox runat="server" ID="ReinsuranceChk" Checked='<%# (bool)Eval("SendToReinsurance") ? true : false %>'
                    data-key='<%# Eval("ContactId") + "|" + Eval("RequirementCatId") + "|" + Eval("RequirementTypeId")+ "|" + Eval("RequirementId")%>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <RowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
        No data to display
    </EmptyDataTemplate>
    <EmptyDataRowStyle ForeColor="Red" HorizontalAlign="Center" />
</asp:GridView>


<asp:HiddenField runat="server" ID="hfRequirementPdfPopUp" ClientIDMode="Static" Value="false" />
<asp:HiddenField runat="server" ID="hdnRequirementCatId" ClientIDMode="Static" />




