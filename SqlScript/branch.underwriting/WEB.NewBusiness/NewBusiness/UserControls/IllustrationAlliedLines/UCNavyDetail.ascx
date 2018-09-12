<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavyDetail.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCNavyDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div id="dvNavyDetailForm" style="padding: 10px">
    <div class="">
        <fieldset>
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.NavyDetail %></legend>     
            <div class="bloqTransportDetail addDobleDynamic">
                <div class="row_B">
                    <asp:Panel ID="Panel_txt_producto" runat="server" class="label_plus_input par col-4">
                        <span>Producto</span>
                        <asp:TextBox runat="server" ID="txt_producto" ReadOnly="true"></asp:TextBox>
                    </asp:Panel>
                    <asp:Repeater runat="server" ID="rpCondiciones" OnItemDataBound="rpCondiciones_ItemDataBound">
                        <ItemTemplate>
                            <div class="label_plus_input par col-4">
                                <span><%# Eval("descripcion") %></span>
                                <asp:TextBox runat="server" ID="txtCondicion" Text='<%# Eval("valor") %>' ReadOnly="true"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:HiddenField ID="hdnProductName" runat="server" />
            </div>
        </fieldset>
    </div>
    <div style="height: 76px;"></div>
    <div style="float: right;">
        <asp:Panel runat="server" ID="pnGuardar" Visible="false" class="fl" Style="margin-left: 10px;">
            <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvNavyDetailForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
            </asp:LinkButton>
        </asp:Panel>

        <div class="fl" style="bottom: 9px; position: absolute; right: 10px;">
            <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopNavyDetail()" />
        </div>
    </div>

    <asp:HiddenField ID="hdnUniqueNavyID" runat="server" />
</div>

