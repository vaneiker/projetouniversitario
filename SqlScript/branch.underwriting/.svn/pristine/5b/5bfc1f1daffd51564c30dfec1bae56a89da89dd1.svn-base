<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPopupApplyDiscount.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.UCPopupApplyDiscount" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:UpdatePanel ID="UpdatePanel3" runat="server" OnUnload="UpdatePanel3_Unload">
    <ContentTemplate>
        <div class="pop_up_wrapper wd940" style="width: 1400px; overflow-x: hidden; overflow-y: hidden;">
            <!--Header-->
            <div id="PopupHeader" class="titulos_azules head_contengridproxi" style="width: 100%;">
                <ul>
                    <li style="position: absolute; left: 41%; top: 31%;">
                        <asp:Literal ID="ltTypeDoc" ClientIDMode="Static" runat="server"></asp:Literal>
                    </li>
                    <li style="top: 13%;">
                        <asp:Button
                            runat="server"
                            ID="btnClosePopupDiscount"
                            CssClass="cls_pup"
                            Text=""
                            Style="background-color: transparent; border: 0;"
                            OnClick="btnClosePopupDiscount_Click" OnClientClick="ClosePopDiscount()" />
                    </li>
                </ul>
            </div>
            <!--Header-->
            <!--Body-->
            <div id="frmApplyDiscount" class="barra_sub_menu" style="width: 100%;">
                <div>
                    <div class="grupos de_2">
                        <div>
                            <span class="label"><%=WEB.NewBusiness.Common.Utility.Capitalize(RESOURCE.UnderWriting.NewBussiness.Resources.ILLUSTRATIONLABEL)%></span>
                            <asp:TextBox runat="server" ID="txtPopupDiscountIllustrationNo" ClientIDMode="Static" Enabled="false" Style="font-size: 10pt;"></asp:TextBox>
                        </div>
                        <div>
                            <span class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredName%></span>
                            <asp:TextBox runat="server" ID="txtPopupDiscountInsuredName" ClientIDMode="Static" Enabled="false" Style="font-size: 10pt;"></asp:TextBox>
                        </div>
                        <asp:HiddenField runat="server" ID="hdnCalculoPorcentaje" ClientIDMode="Static" />
                    </div>

                    <div class="tbl data_Gpl gvVehiculos">
                        <asp:MultiView ID="mvDiscount" runat="server">
                            <asp:View ID="vAuto" runat="server">
                                <dx:ASPxGridView ID="gvVehiculos" runat="server"
                                    KeyFieldName="InsuredVehicleId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnPageIndexChanged="gvVehiculos_PageIndexChanged">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="VehicleDesc" Name="Vehicle" Caption="Vehiculo" Width="40%" />
                                        <dx:GridViewDataTextColumn FieldName="Registry" Name="Registry" Caption="Placa" Width="20%" />
                                        <dx:GridViewDataTextColumn FieldName="InsuredAmount" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right" Width="20%">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmount" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right" Width="20%">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
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
                                    <SettingsPager PageSize="5" Visible="true" AlwaysShowPager="true">
                                        <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                    </SettingsPager>
                                    <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                </dx:ASPxGridView>
                            </asp:View>

                            <asp:View ID="vProperty" runat="server">
                                <dx:ASPxGridView ID="gvProperty" runat="server" ClientIDMode="Static"
                                    KeyFieldName="UniquePropertyId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Enabled="false" OnPreRender="gvProperty_PreRender">
                                    <Columns>

                                        <dx:GridViewDataTextColumn FieldName="ActivfityTypeDesc" Name="ActivfityTypeDescLabel" Caption="ActivfityTypeDesc" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn FieldName="EdificationValueF" Name="EdificationValueLabel" Caption="EdificationValueLabel" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>

                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit NullDisplayText="$0.00"></PropertiesTextEdit>
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

                            <asp:View ID="vAirPlane" runat="server">
                                <dx:ASPxGridView ID="gvAirPlane" runat="server"
                                    KeyFieldName="UniqueAirplaneId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Enabled="false" OnPreRender="gvAirPlanePreRender">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Name" Name="NameLabel" Caption="NameLabel" />
                                        <dx:GridViewDataTextColumn FieldName="AirplaneBase" Name="AirplaneBaseLabel" Caption="AirplaneBaseLabel" />

                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
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

                            <asp:View ID="vBail" runat="server">
                                <dx:ASPxGridView ID="gvBail" runat="server"
                                    KeyFieldName="UniqueBailId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Enabled="false" OnPreRender="gvBail_PreRender">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="EquipmentQty" Name="EquipmentQtyLabel" Caption="EquipmentQtyLabel" />

                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
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

                            <asp:View ID="vTransport" runat="server">
                                <dx:ASPxGridView ID="gvTransport" runat="server"
                                    KeyFieldName="UniqueTransportId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Enabled="false" OnPreRender="gvTransport_PreRender">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Name" Name="NameLabel" Caption="NameLabel" />
                                        <dx:GridViewDataTextColumn FieldName="Type" Name="Type" Caption="Type" />

                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
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

                            <asp:View ID="vNavy" runat="server">
                                <dx:ASPxGridView ID="gvNavy" runat="server" 
                                    KeyFieldName="UniqueNavyId"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" Enabled="false" OnPreRender="gvNavy_PreRender">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="Name" Name="NameLabel" Caption="NameLabel" />
                                        <dx:GridViewDataTextColumn FieldName="BasePort" Name="BasePortLabel" Caption="BasePortLabel" />

                                        <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
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

                    <div class="row_A mB apdesc">
                        <div class="row_A">

                            <div class="grupos de_3">
                                <div>
                                    <span class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TypeOfDiscount%></span>
                                    <asp:DropDownList ClientIDMode="Static" ID="ddlTipoDescuento" runat="server" Style="border: 1px solid #4472C4;"></asp:DropDownList>
                                </div>

                                <div>
                                    <span class="label waiting_percentage"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PercentageDiscount%></span>
                                    <asp:TextBox
                                        ClientIDMode="Static"
                                        CssClass="numbers onlyNumbers"
                                        decimal="decimal"
                                        ID="txtPorcentajeDescuento"
                                        runat="server"
                                        Style="text-align: right;"></asp:TextBox>

                                    <asp:DropDownList ClientIDMode="Static" ID="ddlPorcentajeDescuento" runat="server" Style="border: 1px solid #4472C4; display: none;"></asp:DropDownList>
                                </div>

                                <div>
                                    <span class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.CalculatedAmount%></span>
                                    <asp:TextBox
                                        ClientIDMode="Static"
                                        CssClass="numbers onlyNumbers"
                                        decimal="decimal"
                                        ID="txtCalculatedAmount"
                                        Enabled="false"
                                        runat="server"
                                        Style="text-align: right;"></asp:TextBox>

                                    <asp:TextBox ClientIDMode="Static" CssClass="numbers onlyNumbers" decimal="decimal" ID="txtMontoDescuento" Enabled="false" runat="server" Style="text-align: right; display: none;"></asp:TextBox>
                                </div>
                            </div>

                            <div class="grupos de_2">
                                <div style="width: 66.5% !important;">
                                    <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DiscountComment%></label>
                                    <asp:TextBox ClientIDMode="Static" ID="txtNota" Rows="5" runat="server" Style="border: 1px solid #4472C4;" TextMode="MultiLine"></asp:TextBox>
                                </div>

                                <div style="width: 33.3% !important;">
                                    <div style="height: 59px;"></div>
                                    <div class="grupos de_2">
                                        <div>
                                            <asp:Button
                                                ClientIDMode="Static"
                                                CssClass="button button-green alignC embossed mB row_A"
                                                ID="btnApplyDiscount"
                                                OnClick="btnApplyDiscount_Click"
                                                OnClientClick="return validateForm('frmApplyDiscount');"
                                                runat="server"
                                                Style="line-height: 0px !important;"
                                                Text="Save" />
                                        </div>

                                        <div>
                                            <asp:Button
                                                ClientIDMode="Static"
                                                CssClass="button button-gris alignC embossed row_A bdr_dec"
                                                ID="btnClean"
                                                OnClick="btnClean_Click"
                                                runat="server"
                                                Style="line-height: 0px !important;"
                                                Text="Clean" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>

                    <asp:UpdatePanel ID="UpdatePanel7" runat="server" OnUnload="UpdatePanel3_Unload">
                        <ContentTemplate>
                            <div class="tbl data_Gpl gvRecargos">
                                <dx:ASPxGridView ID="gvRecargos" runat="server" 
                                    KeyFieldName="DiscountId;DiscountRuleId;DiscountRuleDetailId;NotePredefiniedId;Comment;MontoDescuentoF"
                                    EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"
                                    OnCustomColumnDisplayText="gvRecargos_CustomColumnDisplayText"
                                    OnHtmlDataCellPrepared="gvRecargos_HtmlDataCellPrepared"
                                    OnRowCommand="gvRecargos_RowCommand" OnPreRender="gvRecargos_PreRender">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="FullName" Name="AGENT" Caption="Suscriptor" Settings-AllowSort="False" Width="30%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="TipoDescuento" Name="TypeOfDiscount" Caption="Tipo Descuento" Settings-AllowSort="False" Width="20%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="PorcentajeDescuento" Name="PercentageDiscount" Caption="Porcentaje" Settings-AllowSort="False" Width="8%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="MontoDescuentoF" Name="AmountOfDiscount" Caption="Descuento" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Width="12%">
                                            <PropertiesTextEdit DisplayFormatString="$#,##0.00" NullDisplayText="$0.00"></PropertiesTextEdit>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="Comment" Name="DiscountComment" Caption="Nota" Settings-AllowSort="False" Width="12%"></dx:GridViewDataTextColumn>
                                        <dx:GridViewDataColumn Width="5%" Name="Edit" Caption="Edit" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False">
                                            <DataItemTemplate>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel5">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Edit" Visible='<%#Eval("VisibleButton") %>'></asp:Button>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnEdit" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </DataItemTemplate>
                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                        </dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Width="5%" Name="DeleteLabel" Caption="DeleteLabel" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False">
                                            <DataItemTemplate>
                                                <asp:UpdatePanel runat="server" ID="UpdatePanel6">
                                                    <ContentTemplate>
                                                        <asp:Button runat="server" CssClass="delete_file" ID="btnDelete" CommandName="Delete" OnClientClick="return DlgConfirm(this)" Visible='<%#Eval("VisibleButton") %>'></asp:Button>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </DataItemTemplate>
                                            <Settings AllowHeaderFilter="False" AllowSort="False" />
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                    <TotalSummary>
                                        <dx:ASPxSummaryItem FieldName="MontoDescuento" SummaryType="Sum" DisplayFormat="$#,##0.00" />
                                    </TotalSummary>
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
                                                <span class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.TotalPremiumDiscounts.ToUpper()%>:</span>
                                            </td>
                                            <td>
                                                <asp:Label ClientIDMode="Static" CssClass="label" ID="lblTotalPremiumDiscounts" Text="$0.00" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="gvRecargos" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <!--Body-->
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ddlPorcentajeDescuento" EventName="SelectedIndexChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnClosePopupDiscount" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="gvVehiculos" EventName="PageIndexChanged" />
    </Triggers>
</asp:UpdatePanel>
<asp:HiddenField runat="server" ID="hdnWarningMessageTitle" ClientIDMode="Static" />

<script>
    DropText();
</script>
