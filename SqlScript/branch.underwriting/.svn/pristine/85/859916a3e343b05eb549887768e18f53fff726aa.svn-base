<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopupApplySurcharge.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCPopupApplySurcharge" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:UpdatePanel runat="server" ID="UpdatePanel4" OnUnload="UpdatePanel4_Unload">
    <ContentTemplate>

        <style type="text/css">
            .de_1 > div, .porcentaje-recargo > div {
                width: 70% !important;
            }

            #btnApplySurcharge {
                width: 33% !important;
            }

            #txtCalculoRecargo {
                color: #888; /*#669933;*/
                font-size: 13px;
                font-weight: bold;
                margin-top: 2px !important;
                text-align: right;
                width: 30% !important;
            }
        </style>

        <dx:ASPxPopupControl ID="ppcApplySurcharge" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcApplySurcharge" AllowDragging="True"
            PopupAnimationType="None" ClientSideEvents-Closing="ClosePopup" Width="1024" CssClass="recargoApply">
            <ClientSideEvents Closing="ClosePopup"></ClientSideEvents>
            <ContentCollection>
                <dx:PopupControlContentControl runat="server">
                    <div id="frmApplySurcharge" class="barra_sub_menu">
                        <div>
                            <div class="grupos de_2">
                                <div>
                                    <span class="label"></span>
                                    <asp:TextBox runat="server" ID="txtPopupSurchargeIllustrationNo" ClientIDMode="Static" Enabled="false" Style="font-size: 10pt;"></asp:TextBox>
                                </div>
                                <div>
                                    <span class="label"></span>
                                    <asp:TextBox runat="server" ID="txtPopupSurchargeInsuredName" ClientIDMode="Static" Enabled="false" Style="font-size: 10pt;"></asp:TextBox>
                                </div>
                            </div>

                            <div class="tbl data_Gpl gvVehiculos">
                                <asp:MultiView runat="server" ActiveViewIndex="0" ID="mtvRecargos">
                                    <asp:View runat="server" ID="vRecargosVehiculos">
                                        <asp:UpdatePanel runat="server" OnUnload="UpdatePanel4_Unload">
                                            <ContentTemplate>
                                                <dx:ASPxGridView ID="gvVehiculos" runat="server"
                                                    KeyFieldName="VehicleUniqueId;InsuredVehicleId;OwnDamage"
                                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                                    OnBeforeHeaderFilterFillItems="gvVehiculos_BeforeHeaderFilterFillItems"
                                                    OnAfterPerformCallback="gvVehiculos_AfterPerformCallback" OnPageIndexChanged="gvVehiculos_PageIndexChanged">
                                                    <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                                    <Columns>
                                                        <dx:GridViewDataTextColumn FieldName="VehicleDesc" Name="VehicleDesc" Settings-AllowSort="False" />
                                                        <dx:GridViewDataTextColumn FieldName="Chassis" Name="Chassis" Settings-AllowSort="False" />
                                                        <dx:GridViewDataTextColumn FieldName="Registry" Name="Registry" Settings-AllowSort="False" />
                                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" Settings-AllowSort="False" CellStyle-HorizontalAlign="Right" Settings-AllowAutoFilter="False">
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Settings-AllowAutoFilter="False">
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataTextColumn FieldName="OwnDamageF" Name="OwnDamage" Caption="Daños Propios" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Settings-AllowAutoFilter="False">
                                                            <CellStyle HorizontalAlign="Right">
                                                            </CellStyle>
                                                        </dx:GridViewDataTextColumn>
                                                        <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" Settings-AllowSort="False">
                                                            <DataItemTemplate>
                                                                <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                            </DataItemTemplate>
                                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellStyle HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </dx:GridViewDataColumn>
                                                    </Columns>
                                                    <Settings
                                                        HorizontalScrollBarMode="Hidden"
                                                        VerticalScrollBarMode="Hidden"
                                                        ShowGroupPanel="false"
                                                        ShowFooter="true"
                                                        ShowFilterRow="true"
                                                        ShowHeaderFilterButton="false"
                                                        ShowFilterRowMenu="false"
                                                        ShowFilterRowMenuLikeItem="false"
                                                        ShowFilterBar="Hidden" />
                                                    <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                                    <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                                    </SettingsPager>
                                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                                </dx:ASPxGridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="gvVehiculos" />
                                            </Triggers>
                                        </asp:UpdatePanel>

                                    </asp:View>
                                    <asp:View ID="vRecargosProperty" runat="server">
                                        <dx:ASPxGridView ID="gvProperty" runat="server"
                                            KeyFieldName="UniquePropertyId;PremiumAmount"
                                            EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                            OnBeforeHeaderFilterFillItems="gvProperty_BeforeHeaderFilterFillItems"
                                            OnAfterPerformCallback="gvProperty_AfterPerformCallback">
                                            <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="BusinessTypeDesc" Name="" Caption="Tipo de Negocio" />
                                                <dx:GridViewDataTextColumn FieldName="ActivfityTypeDesc" Name="" Caption="Actividad" />
                                                <dx:GridViewDataTextColumn FieldName="AddressStreet" Name="" Caption="Calle" />
                                                <dx:GridViewDataTextColumn FieldName="BusinessTypeDesc" Name="" Caption="Número" />

                                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                                <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <DataItemTemplate>
                                                        <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                    </DataItemTemplate>
                                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Settings
                                                HorizontalScrollBarMode="Hidden"
                                                VerticalScrollBarMode="Hidden"
                                                ShowGroupPanel="false"
                                                ShowFooter="true"
                                                ShowFilterRow="false"
                                                ShowHeaderFilterButton="false"
                                                ShowFilterRowMenu="false"
                                                ShowFilterRowMenuLikeItem="false"
                                                ShowFilterBar="Hidden" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                        </dx:ASPxGridView>
                                    </asp:View>
                                    <asp:View ID="vRecargosAirPlane" runat="server">
                                        <dx:ASPxGridView ID="gvAirplane" runat="server"
                                            KeyFieldName="UniqueAirplaneId;BlTypeId;BlId;ProductId;PremiumAmount;"
                                            EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                            OnBeforeHeaderFilterFillItems="gvAirplane_BeforeHeaderFilterFillItems"
                                            OnAfterPerformCallback="gvAirplane_AfterPerformCallback">
                                            <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                                <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <DataItemTemplate>
                                                        <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                    </DataItemTemplate>
                                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Settings
                                                HorizontalScrollBarMode="Hidden"
                                                VerticalScrollBarMode="Hidden"
                                                ShowGroupPanel="false"
                                                ShowFooter="true"
                                                ShowFilterRow="false"
                                                ShowHeaderFilterButton="false"
                                                ShowFilterRowMenu="false"
                                                ShowFilterRowMenuLikeItem="false"
                                                ShowFilterBar="Hidden" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                        </dx:ASPxGridView>
                                    </asp:View>
                                    <asp:View runat="server" ID="vRecargosNavy">
                                        <dx:ASPxGridView ID="gvNavy" runat="server"
                                            KeyFieldName="UniqueNavyId;PremiumAmount"
                                            EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                            OnBeforeHeaderFilterFillItems="gvNavy_BeforeHeaderFilterFillItems"
                                            OnAfterPerformCallback="gvNavy_AfterPerformCallback">
                                            <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                                <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <DataItemTemplate>
                                                        <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                    </DataItemTemplate>
                                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Settings
                                                HorizontalScrollBarMode="Hidden"
                                                VerticalScrollBarMode="Hidden"
                                                ShowGroupPanel="false"
                                                ShowFooter="true"
                                                ShowFilterRow="false"
                                                ShowHeaderFilterButton="false"
                                                ShowFilterRowMenu="false"
                                                ShowFilterRowMenuLikeItem="false"
                                                ShowFilterBar="Hidden" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                        </dx:ASPxGridView>
                                    </asp:View>
                                    <asp:View runat="server" ID="vRecargosBail">
                                        <dx:ASPxGridView ID="gvBail" runat="server"
                                            KeyFieldName="UniqueBailId;PremiumAmount"
                                            EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                            OnBeforeHeaderFilterFillItems="gvBail_BeforeHeaderFilterFillItems"
                                            OnAfterPerformCallback="gvBail_AfterPerformCallback">
                                            <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                                <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <DataItemTemplate>
                                                        <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                    </DataItemTemplate>
                                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Settings
                                                HorizontalScrollBarMode="Hidden"
                                                VerticalScrollBarMode="Hidden"
                                                ShowGroupPanel="false"
                                                ShowFooter="true"
                                                ShowFilterRow="false"
                                                ShowHeaderFilterButton="false"
                                                ShowFilterRowMenu="false"
                                                ShowFilterRowMenuLikeItem="false"
                                                ShowFilterBar="Hidden" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                        </dx:ASPxGridView>
                                    </asp:View>
                                    <asp:View runat="server" ID="vTransport">
                                        <dx:ASPxGridView ID="gvTransport" runat="server"
                                            KeyFieldName="UniqueTransportId;PremiumAmount"
                                            EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                            OnBeforeHeaderFilterFillItems="gvTransport_BeforeHeaderFilterFillItems"
                                            OnAfterPerformCallback="gvTransport_AfterPerformCallback">
                                            <ClientSideEvents RowDblClick="gvRecargosRowDblClick" />
                                            <Columns>
                                                <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                                <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                    <CellStyle HorizontalAlign="Right">
                                                    </CellStyle>
                                                </dx:GridViewDataTextColumn>
                                                <dx:GridViewDataColumn Width="7%" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                                    <DataItemTemplate>
                                                        <asp:Label CssClass="primary_chk" Height="20px" ID="lblRecargo" runat="server" Visible='<%# Eval("SurchargeApplied") %>' Width="20px"></asp:Label>
                                                    </DataItemTemplate>
                                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <CellStyle HorizontalAlign="Center">
                                                    </CellStyle>
                                                </dx:GridViewDataColumn>
                                            </Columns>
                                            <Settings
                                                HorizontalScrollBarMode="Hidden"
                                                VerticalScrollBarMode="Hidden"
                                                ShowGroupPanel="false"
                                                ShowFooter="true"
                                                ShowFilterRow="false"
                                                ShowHeaderFilterButton="false"
                                                ShowFilterRowMenu="false"
                                                ShowFilterRowMenuLikeItem="false"
                                                ShowFilterBar="Hidden" />
                                            <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                            <SettingsPager PageSize="10" AlwaysShowPager="true">
                                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                            </SettingsPager>
                                            <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                        </dx:ASPxGridView>
                                    </asp:View>
                                </asp:MultiView>
                                <asp:HiddenField runat="server" ID="hdnSelectedRowVisibleIndex" ClientIDMode="Static" />
                                <asp:Button runat="server" ID="btnSelectedRow" OnClick="btnSelectedRow_Click" ClientIDMode="Static" Style="display: none;" />
                            </div>

                            <div>
                                <div style="float: left; width: 60%;">
                                    <div class="grupos de_1">
                                        <div class="label_plus_input par">
                                            <span style="font-size: 13px; padding-top: 3px;">Tipo de Recargo:</span>
                                            <asp:DropDownList CssClass="combo_box" ID="ddlTipoRecargo" Style="border: 1px solid #4472C4; padding-left: 4px; width: 50% !important;" runat="server" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="grupos de_2 porcentaje-recargo">
                                        <div class="label_plus_input par">
                                            <span style="font-size: 13px; padding-top: 3px;">Porcentaje de Recargo:</span>
                                            <asp:UpdatePanel runat="server" ID="UpdatePanel5" OnUnload="UpdatePanel4_Unload">
                                                <ContentTemplate>
                                                    <asp:DropDownList
                                                        AutoPostBack="true"
                                                        ClientIDMode="Static"
                                                        CssClass="combo_box"
                                                        ID="ddlPorcentajeRecargo"
                                                        Style="border: 1px solid #4472C4; padding-left: 4px; width: 50% !important;"
                                                        runat="server"
                                                        Enabled="false"
                                                        OnSelectedIndexChanged="ddlPorcentajeRecargo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlPorcentajeRecargo" EventName="SelectedIndexChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <asp:TextBox
                                            ClientIDMode="Static"
                                            ID="txtCalculoRecargo"
                                            ReadOnly="true"
                                            runat="server"
                                            Text="$0.00"></asp:TextBox>
                                    </div>

                                    <asp:Button
                                        Enabled="false"
                                        runat="server"
                                        ID="btnApplySurcharge"
                                        ClientIDMode="Static"
                                        CssClass="button button-green alignC embossed mB row_A mL10"
                                        Text="Save"
                                        OnClick="btnApplySurcharge_Click"
                                        OnClientClick="return validateForm('frmApplySurcharge');" />
                                </div>
                            </div>
                            <div style="text-align: right;">
                                <asp:Button
                                    runat="server"
                                    ID="btnVerRecargos"
                                    ClientIDMode="Static"
                                    CssClass="col-4 fr button button-blue alignC embossed mT20"
                                    Style="background-color: #47A5DF; border-color: #47A5DF; color: #fff;"
                                    Text="Ver todos los recargos"
                                    OnClick="btnVerRecargos_Click" />
                            </div>

                            <div class="tbl data_Gpl gvRecargos">
                                <dx:ASPxGridView ID="gvRecargos" runat="server" KeyFieldName="SurchargeId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                    OnRowCommand="gvRecargos_RowCommand">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                        <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                        <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            <CellStyle HorizontalAlign="Right">
                                            </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Width="5%" Name="Edit" Caption="Edit" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel2">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Edit"></asp:Button>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnEdit" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </DataItemTemplate>
                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Width="5%" Name="Delete" Caption="Delete" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                            <DataItemTemplate>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" CssClass="delete_file" ID="btnDelete" CommandName="Delete" OnClientClick="return DlgConfirm(this)"></asp:Button>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </DataItemTemplate>
                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle HorizontalAlign="Center">
                                            </CellStyle>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <Settings
                                        HorizontalScrollBarMode="Hidden"
                                        VerticalScrollBarMode="Hidden"
                                        ShowGroupPanel="false"
                                        ShowFooter="true"
                                        ShowFilterRow="false"
                                        ShowHeaderFilterButton="false"
                                        ShowFilterRowMenu="false"
                                        ShowFilterRowMenuLikeItem="false"
                                        ShowFilterBar="Hidden" />
                                    <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                    <SettingsPager PageSize="10" AlwaysShowPager="true">
                                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                </dx:ASPxGridView>
                            </div>
                            <div class="fr">
                                <table>
                                    <tbody>
                                        <tr style="background-color: white; text-align: right;">
                                            <td>
                                                <span class="label">TOTAL RECARGOS:</span>
                                            </td>
                                            <td>
                                                <asp:Label ClientIDMode="Static" CssClass="label" ID="lblTotalSurcharges" Text="$0.00" runat="server" />
                                            </td>
                                        </tr>
                                        <tr style="background-color: white; text-align: right;" runat="server" id="trTotalDanosPropios">
                                            <td>
                                                <span class="label">TOTAL DAÑOS PROPIOS CON RECARGOS:</span>
                                            </td>
                                            <td>
                                                <asp:Label ClientIDMode="Static" CssClass="label" ID="lblTotalOwnDamagesWithSurcharges" Text="$0.00" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </ContentTemplate>
</asp:UpdatePanel>

<dx:ASPxPopupControl ID="ppcAllSurcharges" runat="server" CloseAction="CloseButton" CloseOnEscape="true" Modal="True"
    PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="ppcAllSurcharges" AllowDragging="True"
    PopupAnimationType="None" ClientSideEvents-Closing="ClosePopup" Width="1024" CssClass="recarAll">
    <ClientSideEvents Closing="ClosePopup"></ClientSideEvents>
    <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel1" OnUnload="UpdatePanel4_Unload">
                <ContentTemplate>
                    <div id="frmAllSurcharges" class="barra_sub_menu">
                        <div class="tbl data_Gpl gvAllSurcharges">
                            <asp:MultiView runat="server" ID="mtMasterAllSurcharges">
                                <asp:View runat="server" ID="vAllSurchargesAuto">
                                    <dx:ASPxGridView ID="gvAllSurcharges" runat="server" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="VehicleDesc" Name="VehicleDesc" Caption="Vehiculo" />
                                            <dx:GridViewDataTextColumn FieldName="Registry" Name="Registry" Caption="Placa" />
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vAllSurchargesProperty">
                                    <dx:ASPxGridView ID="gvAllSurchargesProperty" runat="server" KeyFieldName="Recargo" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vAllSurchargesNavy">
                                    <dx:ASPxGridView ID="gvAllSurchargesNavy" runat="server" KeyFieldName="Recargo" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vAllSurchargesTransport">
                                    <dx:ASPxGridView ID="gvAllSurchargesTransport" runat="server" KeyFieldName="Recargo" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vAllSurchargesBail">
                                    <dx:ASPxGridView ID="gvAllSurchargesBail" runat="server" KeyFieldName="Recargo" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vAllSurchargesAirplane">
                                    <dx:ASPxGridView ID="gvAllSurchargesAirPlane" runat="server" KeyFieldName="Recargo" EnableCallBacks="False" AutoGenerateColumns="False" Width="100%" Enabled="false">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TipoRecargo" Name="TipoRecargo" Caption="Tipo de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="PorcentajeRecargo" Name="PorcentajeRecargo" Caption="Porcentaje de Recargo" />
                                            <dx:GridViewDataTextColumn FieldName="RecargoF" Name="Recargo" Caption="Recargo" CellStyle-HorizontalAlign="Right">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <Settings
                                            HorizontalScrollBarMode="Hidden"
                                            VerticalScrollBarMode="Hidden"
                                            ShowGroupPanel="false"
                                            ShowFooter="true"
                                            ShowFilterRow="false"
                                            ShowHeaderFilterButton="false"
                                            ShowFilterRowMenu="false"
                                            ShowFilterRowMenuLikeItem="false"
                                            ShowFilterBar="Hidden" />
                                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="true" AllowSelectSingleRowOnly="false" />
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                            </asp:MultiView>
                        </div>
                        <div class="fr">
                            <table>
                                <tbody>
                                    <tr style="background-color: white; text-align: right;">
                                        <td>
                                            <span class="label">TOTAL RECARGOS:</span>
                                        </td>
                                        <td>
                                            <asp:Label ClientIDMode="Static" CssClass="label" ID="lblTotalAllSurcharges" Text="$0.00" runat="server" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvAllSurcharges" />
                </Triggers>
            </asp:UpdatePanel>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>
