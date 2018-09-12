<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFacultyPosition.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Common.UCFacultyPosition" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" class="cont_gnl rcomp mT25" RenderMode="Block" ID="udpMaster">
    <ContentTemplate>
        <div class="round_blue ">Facultativo</div>
        <div class="col-6 fl">
            <fieldset>
                <legend>Inf. Facultativo </legend>
                <asp:Panel runat="server" ID="pnItems">
                    <asp:UpdatePanel runat="server" ID="udpItems">
                        <ContentTemplate>
                            <asp:MultiView runat="server" ID="mtvMaster" ActiveViewIndex="0">
                                <asp:View runat="server" ID="vAuto">
                                    <dx:ASPxGridView ID="gvVehiculos" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentage;ReinsurancePremiumAmount"
                                        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnRowCommand="Item_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="VehicleDesc" Name="VehicleDesc" Caption="DESCRIPCION" Settings-AllowSort="False" />
                                            <dx:GridViewDataTextColumn FieldName="Chassis" Name="Chassis" Caption="CHASIS" Settings-AllowSort="False" />
                                            <dx:GridViewDataTextColumn FieldName="Registry" Name="Registry" Settings-AllowSort="False" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" Settings-AllowSort="False" CellStyle-HorizontalAlign="Right" Settings-AllowAutoFilter="False">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="Premium" Caption="Prima" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Settings-AllowAutoFilter="False">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DPPremiumAmountF" Name="PrimaOwnDamages" Caption="Prima Daños Propios" CellStyle-HorizontalAlign="Right" Settings-AllowSort="False" Settings-AllowAutoFilter="False">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View ID="vProperty" runat="server">
                                    <dx:ASPxGridView ID="gvProperty" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentage;ReinsurancePremiumAmount"
                                        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnRowCommand="Item_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View ID="vAirPlane" runat="server">
                                    <dx:ASPxGridView ID="gvAirplane" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentage;ReinsurancePremiumAmount"
                                        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnRowCommand="Item_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vNavy">
                                    <dx:ASPxGridView ID="gvNavy" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentage;ReinsurancePremiumAmount"
                                        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnRowCommand="Item_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vBail">
                                    <dx:ASPxGridView ID="gvBail" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentage;ReinsurancePremiumAmount"
                                        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnPreRender="gvVehiculos_PreRender" OnRowCommand="Item_RowCommand">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                                <asp:View runat="server" ID="vTransport">
                                    <dx:ASPxGridView ID="gvTransport" ClientIDMode="Static" runat="server"
                                        KeyFieldName="ReinsuranceAmount;InsuredAmount;UniqueId;CorpId;RegionId;CountryId;DomesticregId;StateProvId;CityId;OfficeId;CaseSeqNo;HistSeqNo;ReinsurancePercentag;ReinsurancePremiumAmounte">
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="Select" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnSelect" data='<%#Eval("UniqueId") %>' Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Select %>' CommandName="Select" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataTextColumn FieldName="ProductDesc" Name="ProductDesc" Caption="Plan" />
                                            <dx:GridViewDataTextColumn FieldName="InsuredAmountF" Name="InsuredAmount" Caption="Monto Asegurado" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PremiumAmountF" Name="PremiumAmount" Caption="Monto Prima" CellStyle-HorizontalAlign="Right">
                                                <CellStyle HorizontalAlign="Right">
                                                </CellStyle>
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
                                        <SettingsPager PageSize="10" AlwaysShowPager="true">
                                            <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                                        </SettingsPager>
                                        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
                                    </dx:ASPxGridView>
                                </asp:View>
                            </asp:MultiView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                <div style="height: 13px;"></div>
                <div>
                    <asp:UpdatePanel runat="server" class="grupos de_2 mT30" RenderMode="Block" ID="udpTotales" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="label_plus_input par">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.MontoFacultativo %></span>
                                <asp:TextBox runat="server" ID="txtFactultyAmount" Style="text-align: left;" decimal="decimal" ReadOnly="true" Text="0.00"></asp:TextBox>
                            </div>
                            <div class="label_plus_input par">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.PercentageLabel%></span>
                                <asp:TextBox runat="server" ID="txtReinsurancePercentage" Style="text-align: right;" ReadOnly="true" Text="0.00"></asp:TextBox>
                            </div>
                            <div class="label_plus_input par">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.PrimaCedida%></span>
                                <asp:TextBox runat="server" ID="txtPrimaCedida" Style="text-align: right;" ReadOnly="true" Text="0.00"></asp:TextBox>
                            </div>
                            <div class="label_plus_input par">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.TotalDistribuido %></span>
                                <asp:TextBox runat="server" ID="txtTotalDistribuido" Style="text-align: left;" decimal="decimal" ReadOnly="true" Text="0.00"></asp:TextBox>
                            </div>
                            <div class="label_plus_input par">
                                <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.RestoTotal%></span>
                                <asp:TextBox runat="server" ID="txtRestoTotal" Style="text-align: left;" decimal="decimal" ReadOnly="true" Text="0.00"></asp:TextBox>
                            </div>
                            <div>
                                <asp:LinkButton runat="server" CssClass="button button-red alignC disabled embossed fr row_A" ID="lnkCancelContract" OnClick="lnkCancelContract_Click">
                            <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %></span>
                                </asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel runat="server" style="width: 100%" RenderMode="Block" ID="udpCancelContract">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnContratos" Enabled="false">
                                <div class="" id="dvContratos" style="display: block">
                                    <asp:UpdatePanel runat="server" ID="udpGridView" ClientIDMode="Static" RenderMode="Block" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" OnClick="btnAdd_Click" CssClass="fl" />
                                            <asp:Label Style="font-family: initial;" runat="server" ID="lblAgregarContrato" Text="Agregar Contrato"></asp:Label>
                                            <dx:ASPxGridView
                                                ID="gvContrato"
                                                runat="server"
                                                EnableCallBacks="False"
                                                ClientIDMode="Static"
                                                AutoGenerateColumns="false"
                                                KeyFieldName="corpId;contractUniqueId;IdContrato;RecordIndex;Status"
                                                Width="100%" OnRowCommand="gvContrato_RowCommand"
                                                OnPageIndexChanged="gvContrato_PageIndexChanged" OnPreRender="gvContrato_PreRender">
                                                <Columns>
                                                    <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <div class="grupos de_2" style="text-align: center">
                                                                        <asp:Panel runat="server" ID="pnDelete">
                                                                            <asp:LinkButton runat="server" ID="btnDelete" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this);" />
                                                                        </asp:Panel>
                                                                        <div>
                                                                            <asp:LinkButton runat="server" ID="btnCancel" CssClass="mycancel_file" CommandName="Cancel" Visible="false" />
                                                                        </div>
                                                                        <div>
                                                                            <asp:LinkButton runat="server" ID="btnEditOrSave" CssClass="myedit_file" CommandName="Edit" OnClientClick="return validateForm('udpGridView');" />
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="btnEditOrSave" />
                                                                    <asp:AsyncPostBackTrigger ControlID="btnCancel" />
                                                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="Nombre Compañia" Settings-AllowSort="true" Width="220" Name="CompanyNameLabel" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <div>
                                                                <asp:DropDownList ID="ddlNombreCompania" runat="server" label='<%#RESOURCE.UnderWriting.NewBussiness.Resources.CompanyNameLabel %>' validation="Required" Visible="false">
                                                                </asp:DropDownList>
                                                            </div>
                                                            <asp:Label runat="server" ID="ltNombreCompania" Text='<%#Eval("NombreCompania")%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="NombreContrato" Settings-AllowSort="true" Name="ContractName" Width="220" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:TextBox ID="txtNombreContrato" runat="server" label='<%#RESOURCE.UnderWriting.NewBussiness.Resources.ContractName %>' Text='<%#Eval("NombreContrato")%>' validation="Required" Visible="false" />
                                                            <asp:Label runat="server" ID="ltNombreContrato" Text='<%#Eval("NombreContrato")%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="MontoContrato" Settings-AllowSort="true" Name="ContractAmount" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtMontoContrato" Text='<%#Eval("MontoContratoF")%>' validation="Required" label='<%#RESOURCE.UnderWriting.NewBussiness.Resources.ContractAmount %>' decimal="decimal" Visible="false" />
                                                            <asp:Label runat="server" ID="ltMontoContrato" Text='<%#Eval("MontoContratoF")%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="PorcCommision" Settings-AllowSort="true" Name="CommisionPercent" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtPorcCommision" Text='<%#Eval("PorcCommisionF")%>' validation="Required" allowZero="true" label='<%#RESOURCE.UnderWriting.NewBussiness.Resources.CommisionPercent %>' decimal="decimal3" Visible="false" />
                                                            <asp:Label runat="server" ID="ltPorcCommision" Text='<%#Eval("PorcCommisionF")%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="%" Settings-AllowSort="true" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:Label runat="server" ID="ltPorcContrato" Text='<%#string.Format(System.Globalization.CultureInfo.InvariantCulture,"{0:#,0.000000}",Eval("PorcContrato"))%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                    <dx:GridViewDataColumn Caption="PayDateLimit" Settings-AllowSort="true" Name="PayDateLimit" CellStyle-HorizontalAlign="Center">
                                                        <DataItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtPayDateLimit" Text='<%#Eval("FechaLimitePagoF")%>' validation="Required" label='<%#RESOURCE.UnderWriting.NewBussiness.Resources.PayDateLimit %>' CssClass="PayDateLimit datepickerWithoutIcon" Visible="false" />
                                                            <asp:Label runat="server" ID="ltPayDateLimit" Text='<%#Eval("FechaLimitePagoF")%>' />
                                                        </DataItemTemplate>
                                                    </dx:GridViewDataColumn>
                                                </Columns>
                                                <Settings ShowFooter="True" />
                                                <Settings VerticalScrollableHeight="409" VerticalScrollBarMode="Visible" />
                                            </dx:ASPxGridView>
                                            <div style="height: 10px;"></div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvContrato" />
                                            <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </fieldset>
        </div>
        <div class="col-6 fl cbrage">
            <fieldset>
                <legend>Coberturas</legend>
                <asp:Panel runat="server" ID="pnCoverages" ClientIDMode="Static">
                    <asp:UpdatePanel runat="server" RenderMode="Block" UpdateMode="Conditional" ID="udpCoverages">
                        <ContentTemplate>
                            <dx:ASPxGridView
                                ID="gvCoveragesFake"
                                runat="server"
                                EnableCallBacks="False"
                                AutoGenerateColumns="False"
                                Width="100%" OnPreRender="gvVehiculos_PreRender">
                                <Columns>
                                    <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="CoverageName" Name="CoverageName">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="CoverageTypeDesc" Name="CoverageTypeDesc">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="ContractualPercentage" Caption="Porcentage contractual">
                                    </dx:GridViewDataTextColumn>
                                </Columns>
                                <SettingsBehavior AllowSort="False" />
                                <Settings ShowFooter="True" />
                                <Settings VerticalScrollableHeight="719" VerticalScrollBarMode="Visible" />
                            </dx:ASPxGridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </fieldset>
        </div>
        <div class="row_A">
            <div class="col-4 fr">
                <asp:LinkButton runat="server" CssClass="button button-green alignC embossed fl col-6 disabled" Style="float: right !important;" ID="btnGuardar" OnClick="btnGuardar_Click">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
                </asp:LinkButton>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</asp:UpdatePanel>
