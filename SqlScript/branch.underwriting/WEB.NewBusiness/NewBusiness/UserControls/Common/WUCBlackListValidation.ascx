<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCBlackListValidation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.WUCBlackListValidation" %>
<asp:UpdatePanel runat="server" ID="udpBlackListValidation">
    <ContentTemplate>
        <div style="text-align: center">
            <h2>
                <asp:Literal runat="server" ID="ltBody"></asp:Literal></h2>
            <div style="text-align: center">
                <span class="txtbold"><%=RESOURCE.UnderWriting.NewBussiness.Resources.Accept%></span>
                <asp:RadioButtonList ID="rbAcepta" runat="server" RepeatDirection="Horizontal" CssClass="radio tblr w200 float-center">
                    <asp:ListItem>Si</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div>
                <div class="fr" style="margin-left: 10px;">
                    <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ClientIDMode="Static" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return DlgConfirm(this);">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
                    </asp:LinkButton>
                </div>

                <div class="fr" style="margin-left: 10px;">
                    <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopBlackList();" />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

