<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTransportDetail.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCTransportDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div id="dvTransportDetailForm" style="padding: 10px">
    <div>
        <fieldset>
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

    <fieldset style="height: 339px;" runat="server" id="fieldSetFeatures" visible="false">
        <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.TransportFeatures %></legend>
        <asp:Panel runat="server" ID="dvPropertyFeature" ClientIDMode="Static">
            <div>
                <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" OnClick="btnAdd_Click" />
            </div>
            <asp:UpdatePanel runat="server" ID="udpGridView">
                <ContentTemplate>
                    <dx:ASPxGridView
                        ID="gvTransportExtraInfo"
                        runat="server"
                        EnableCallBacks="False"
                        KeyFieldName="UniqueTransportId;SeqId;TransportExtraInfoStatusId"
                        ClientIDMode="Static"
                        AutoGenerateColumns="false"
                        Width="100%"
                        OnRowCommand="gvTransportExtraInfo_RowCommand"
                        OnPreRender="gvTransportExtraInfo_PreRender"
                        OnPageIndexChanged="gvTransportExtraInfo_PageIndexChanged">
                        <Columns>
                            <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center" Name="Operation">
                                <DataItemTemplate>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="grupos de_2" style="text-align: center">
                                                <asp:Panel runat="server" ID="pnDelete">
                                                    <asp:LinkButton runat="server" ID="btnDelete" CssClass="delete_file" CommandName="DeleteFeature" OnClientClick="return DlgConfirm(this);" />
                                                </asp:Panel>
                                                <div>
                                                    <asp:LinkButton runat="server" ID="btnEditOrSave" CssClass="myedit_file" CommandName="EditFeature" OnClientClick="return validateForm('dvPropertyFeature');" />
                                                </div>
                                                <div>
                                                    <asp:LinkButton runat="server" ID="btnCancel" Visible="false" CssClass="mycancel_file" CommandName="Cancel" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnEditOrSave" />
                                            <asp:AsyncPostBackTrigger ControlID="btnCancel" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Name" Settings-AllowSort="true" Name="Name" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtNameExtra" Text='<%#Eval("Name")%>' label="Name" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltName" Text='<%#Eval("Name")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Brand" Settings-AllowSort="true" Name="Brand" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtBrand" Text='<%#Eval("Brand")%>' label="Brand" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltBrand" Text='<%#Eval("Brand")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Model" Settings-AllowSort="true" Name="Model" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtModel" Text='<%#Eval("Model")%>' label="Model" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltModel" Text='<%#Eval("Model")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Year" Settings-AllowSort="true" Name="Year" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtYearExtra" Text='<%#Eval("Year")%>' label="Year" number="number4" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltYear" Text='<%#Eval("Year")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="PlateAirplane" Settings-AllowSort="true" Name="PlateAirplane" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtPlate" Text='<%#Eval("Plate")%>' label="PlateAirplane" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltPlate" Text='<%#Eval("Plate")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="VehicleChasis" Settings-AllowSort="true" Name="VehicleChasis" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtVin" Text='<%#Eval("Vin")%>' label="VehicleChasis" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltVin" Text='<%#Eval("Vin")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="SerialKey" Settings-AllowSort="true" Name="SerialKey" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtSerialKey" Text='<%#Eval("SerialKey")%>' label="Serial Key" validation="Required" Visible="false" />
                                    <asp:Literal runat="server" ID="ltSerialKey" Text='<%#Eval("SerialKey")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <SettingsPager PageSize="4" AlwaysShowPager="true">
                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                        </SettingsPager>
                        <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
                        <Settings ShowFooter="True" />
                    </dx:ASPxGridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvTransportExtraInfo" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
    </fieldset>
</div>
<div style="height: 19px;"></div>
<div style="float: right;">
    <asp:Panel runat="server" ID="pnGuardar" Visible="false" class="fl" Style="margin-left: 10px;">
        <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvTransportDetailForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
        </asp:LinkButton>
    </asp:Panel>

    <div class="fl" style="position: absolute; right: 10px; bottom: 10px;">
        <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopTransportDetail()" />
    </div>
</div>
<asp:HiddenField ID="hdnUniqueTransportID" runat="server" />


