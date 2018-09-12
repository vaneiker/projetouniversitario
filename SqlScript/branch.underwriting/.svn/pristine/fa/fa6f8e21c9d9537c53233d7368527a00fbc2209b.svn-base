<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAirPlaneDetail.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCAirPlaneDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div id="dvAirPlaneDetailForm" style="padding: 10px">
    <div class="">
        <fieldset>
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Product %></legend>
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
            </div>

            <asp:HiddenField ID="hdnProductName" runat="server" />
        </fieldset>

        <fieldset style="height: 300px;" runat="server" id="fieldSetFeatures" visible="false">
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.Pilot %></legend>
            <asp:Panel runat="server" ID="dvPilot" ClientIDMode="Static">
                <div>
                    <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" OnClick="btnAdd_Click" />
                </div>
                <asp:UpdatePanel runat="server" ID="udpGridView">
                    <ContentTemplate>
                        <dx:ASPxGridView
                            ID="gvAirplaneDetailPilot"
                            runat="server"
                            EnableCallBacks="False"
                            ClientIDMode="Static"
                            AutoGenerateColumns="false"
                            KeyFieldName="UniqueAirplaneId;SeqId"
                            Width="100%"
                            OnRowCommand="gvAirplaneDetailPilot_RowCommand"
                            OnPreRender="gvAirplaneDetailPilot_PreRender"
                            OnPageIndexChanged="gvAirplaneDetailPilot_PageIndexChanged">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="grupos de_2" style="text-align: center">
                                                    <asp:Panel runat="server" ID="pnDelete">
                                                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="delete_file" CommandName="DeletePilot" OnClientClick="return DlgConfirm(this);" />
                                                    </asp:Panel>
                                                    <div>
                                                        <asp:LinkButton runat="server" ID="btnEditOrSave" CssClass="myedit_file" CommandName="EditPilot" OnClientClick="return validateForm('dvPilot');" />
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
                                        <asp:TextBox runat="server" ID="txtNamePilot" Text='<%#Eval("Name")%>' validation="Required" label="Name" Visible="false" />
                                        <asp:Literal runat="server" ID="ltNamePilot" Text='<%#Eval("Name")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="TotalFlighthours" Settings-AllowSort="true" Name="TotalFlighthours" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtFlighthours" Text='<%#Eval("Flighthours")%>' validation="Required" label="TotalFlighthours" number="number" Visible="false" />
                                        <asp:Literal runat="server" ID="ltFlighthours" Text='<%#Eval("FlighthoursF")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsPager PageSize="8" AlwaysShowPager="true">
                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
                            <Settings ShowFooter="True" />
                        </dx:ASPxGridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvAirplaneDetailPilot" />
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </fieldset>
    </div>
    <div style="height: 6px;"></div>
    <div style="float: right;">
        <asp:Panel runat="server" Visible="false" ID="pnGuardar" class="fl" Style="margin-left: 10px;">
            <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvAirPlaneDetailForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
            </asp:LinkButton>
        </asp:Panel>
        <div class="fl" style="position: absolute; right: 10px; bottom: 10px;">
            <input type="button" class="button button-red alignC embossed" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopAirPlaneDetail()" />
        </div>
    </div>
    <asp:HiddenField ID="hdnAirPlaneUniqueID" runat="server" />
</div>
