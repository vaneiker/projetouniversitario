<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSetPoliciesPayments.ascx.cs" Inherits="CollectorsModule.Controls.ucSetPoliciesPayments" %>
<asp:UpdatePanel ID="upSetPolicies" runat="server">
    <ContentTemplate>

<div class="contenido">
    <div runat="server" id="DOPPolicies" class="bdrRadius20 row_A">
    <div class="ttlStep  azul_c azul_pl">Pólizas en Pesos Dominicanos</div>
    <div class=" tbl data_Gpl sl_polizas">
        <dx:ASPxGridView ID="gvDOPPolicies" OnDataBinding="gvDOPPolicies_DataBinding" ClientInstanceName="gvDOPPolicies" runat="server" OnSelectionChanged="gvDOPPolicies_SelectionChanged"
            KeyFieldName="POLICY_NUMBER" Width="100%" OnFocusedRowChanged="gvDOPPolicies_SelectionChanged" OnCustomColumnDisplayText="gvDOPPolicies_CustomColumnDisplayText" 
            EnableRowsCache="False" SettingsBehavior-AllowFocusedRow="False">
            <Settings ShowTitlePanel="False" ShowFilterRow="False" ShowFilterBar="Hidden" />
            <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
               
            <Columns>
                <dx:GridViewDataColumn Caption="Seleccionar">
                    <DataItemTemplate>
                        <asp:CheckBox runat="server" ID="ckbSelectPolicies" OnCheckedChanged="gvDOPPolicies_SelectionChanged" AutoPostBack="true" ValidationGroup="ckPolicies" />
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Línea de negocio" FieldName="LINE_OF_BUSINESS" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Plan" FieldName="PLAN_TYPE" VisibleIndex="2" />
                <dx:GridViewDataColumn Caption="Póliza" FieldName="POLICY_NUMBER" VisibleIndex="3" />
                <dx:GridViewDataColumn Caption="Estatus" FieldName="POLICY_STATUS" VisibleIndex="4" />
                <dx:GridViewDataColumn Caption="Fecha de vencimiento" FieldName="EXPIRATION_DATE" VisibleIndex="5" />
                <dx:GridViewDataColumn Caption="CURRENCY_ID" FieldName="CURRENCY_ID" Visible="false" VisibleIndex="6" />
                <dx:GridViewDataColumn Caption="Balance pendiente" FieldName="CUSTOMER_BALANCE"  VisibleIndex="7">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="Valor a pagar" VisibleIndex="8" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:TextBox runat="server" ID="txtAmountDue" Style="text-align:right !important;" Enabled="false" OnTextChanged="txtAmountDue_TextChanged" OnKeyPress="return bINT(event);" AutoPostBack="true"></asp:TextBox>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Histórico de Pagos" VisibleIndex="9" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:HyperLink runat="server" CssClass="fa fa-eye ver_btn" ID="btnPaymentHistoryPolicy" NavigateUrl='<%# String.Format("~/Pages/PaymentHistory.aspx?Policy_No={0}", DataBinder.Eval(Container.DataItem, "POLICY_NUMBER")) %>' Target="_blank">
                        </asp:HyperLink>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="LINE_OF_BUSINESS" FieldName="LINE_OF_BUSINESS" Visible="false" VisibleIndex="10" />
                <dx:GridViewDataColumn Caption="CUSTNAME" FieldName="CUSTNAME" Visible="false" VisibleIndex="11" />
                <dx:GridViewDataColumn Caption="LINE_OF_BUSINESS" FieldName="LINE_OF_BUSINESS" Visible="false" VisibleIndex="12" />
            </Columns>
            <Templates>
                <FooterCell>
                    <dx:ASPxLabel ID="txtTotalPendingAmount" runat="server" Text="" OnInit="txtTotalPendingAmount_Init"></dx:ASPxLabel>
                </FooterCell>
            </Templates>
            <Settings ShowFooter="True" />
            <SettingsPager PageSize="250" />
            <Settings VerticalScrollableHeight="350" VerticalScrollBarMode="Visible" />
            <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
            <ClientSideEvents SelectionChanged="gridPolicies_SelectionChanged" EndCallback="function(s, e){loadingDOP(false); setGridStylesPolicies();}" BeginCallback="function(s, e){loadingDOP(true);}" />
        </dx:ASPxGridView>
        <%--<dx:ASPxGridView ID="gvDOPPolicies" OnDataBinding="gvDOPPolicies_DataBinding" ClientInstanceName="gvDOPPolicies" runat="server" OnSelectionChanged="gvDOPPolicies_SelectionChanged"
            KeyFieldName="Policy_No" Width="100%" OnFocusedRowChanged="gvDOPPolicies_SelectionChanged" OnCustomColumnDisplayText="gvDOPPolicies_CustomColumnDisplayText" 
            EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" >
            <Settings ShowTitlePanel="false" ShowFilterRow="false" ShowFilterBar="Hidden" />
            <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
               
            <Columns>
                <dx:GridViewDataColumn Caption="Seleccionar">
                    <DataItemTemplate>
                        <asp:CheckBox runat="server" ID="ckbSelectPolicies" OnCheckedChanged="gvDOPPolicies_SelectionChanged" AutoPostBack="true" ValidationGroup="ckPolicies" />
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Linea de negocio" FieldName="Bl_Desc" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Plan" FieldName="Product_Desc" VisibleIndex="2" />
                <dx:GridViewDataColumn Caption="Poliza" FieldName="Policy_No" VisibleIndex="3" />
                <dx:GridViewDataColumn Caption="Estatus" FieldName="Policy_Status_Desc" VisibleIndex="4" />
                <dx:GridViewDataColumn Caption="Prima annual" FieldName="Annual_Premium" VisibleIndex="5" />
                <dx:GridViewDataColumn Caption="Fecha de vencimiento" FieldName="DueDate" VisibleIndex="6" />
                <dx:GridViewDataColumn Caption="Balance pendiente" FieldName="PendingAmount"  VisibleIndex="7">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="Valor a pagar" VisibleIndex="8" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:TextBox runat="server" ID="txtAmountDue" Style="text-align:right !important;" Enabled="false" OnTextChanged="txtAmountDue_TextChanged" OnKeyPress="return bINT(event);" AutoPostBack="true"></asp:TextBox>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Historico de Pagos" VisibleIndex="9" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:HyperLink runat="server" CssClass="fa fa-eye ver_btn" ID="btnPaymentHistoryPolicy" NavigateUrl='<%# String.Format("~/Pages/PaymentHistory.aspx?Policy_No={0}", DataBinder.Eval(Container.DataItem, "Policy_No")) %>' Target="_blank">
                        </asp:HyperLink>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Bussiness_Line_Id" FieldName="Bussiness_Line_Id" Visible="false" VisibleIndex="10" />
                <dx:GridViewDataColumn Caption="Currency_Id" FieldName="Currency_Id" Visible="false" VisibleIndex="11" />
                <dx:GridViewDataColumn Caption="TotalDueAmount" FieldName="TotalDueAmount" Visible="false" VisibleIndex="12" />
                <dx:GridViewDataColumn Caption="Full_Name" FieldName="Full_Name" Visible="false" VisibleIndex="13" />
            </Columns>
            <Templates>
                <FooterCell>
                    <dx:ASPxLabel ID="txtTotalPendingAmount" runat="server" Text="" OnInit="txtTotalPendingAmount_Init"></dx:ASPxLabel>
                </FooterCell>
            </Templates>
            <Settings ShowFooter="True" />
            <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
            <ClientSideEvents SelectionChanged="gridPolicies_SelectionChanged" EndCallback="setGridStylesPolicies" />
        </dx:ASPxGridView>--%>
    </div>
</div>
    <div runat="server" id="USDPolicies" class="bdrRadius20 row_A mT40">
    <div class="ttlStep  azul_c azul_pl">Pólizas en Dólares</div>
    <div class=" tbl data_Gpl sl_polizas">
        <dx:ASPxGridView ID="gvUSDPolicies" OnDataBinding="gvUSDPolicies_DataBinding" ClientInstanceName="gvUSDPolicies" runat="server" OnSelectionChanged="gvUSDPolicies_SelectionChanged"
            KeyFieldName="POLICY_NUMBER" Width="100%" OnFocusedRowChanged="gvUSDPolicies_SelectionChanged" OnCustomColumnDisplayText="gvDOPPolicies_CustomColumnDisplayText"
            EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" >
            <Settings ShowTitlePanel="false" ShowFilterRow="false" ShowFilterBar="Hidden" />
            <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
               
            <Columns>
                <dx:GridViewDataColumn Caption="Seleccionar">
                    <DataItemTemplate>
                        <asp:CheckBox runat="server" ID="ckbSelectPoliciesUSD" OnCheckedChanged="gvUSDPolicies_SelectionChanged" AutoPostBack="true" ValidationGroup="ckPolicies" />
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Línea de negocio" FieldName="LINE_OF_BUSINESS" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Plan" FieldName="PLAN_TYPE" VisibleIndex="2" />
                <dx:GridViewDataColumn Caption="Póliza" FieldName="POLICY_NUMBER" VisibleIndex="3" />
                <dx:GridViewDataColumn Caption="Estatus" FieldName="POLICY_STATUS" VisibleIndex="4" />
                <dx:GridViewDataColumn Caption="Fecha de vencimiento" FieldName="EXPIRATION_DATE" VisibleIndex="5" />
                <dx:GridViewDataColumn Caption="CURRENCY_ID" FieldName="CURRENCY_ID" Visible="false" VisibleIndex="6" />
                <dx:GridViewDataColumn Caption="Balance pendiente" FieldName="CUSTOMER_BALANCE"  VisibleIndex="7">
                </dx:GridViewDataColumn>
                <dx:GridViewDataTextColumn Caption="Valor a pagar" VisibleIndex="8" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:TextBox runat="server" ID="txtAmountDueUSD" Style="text-align:right !important;" Enabled="false" OnTextChanged="txtAmountDueUSD_TextChanged" OnKeyPress="return bINT(event);" AutoPostBack="true"></asp:TextBox>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Histórico de Pagos" VisibleIndex="9" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:HyperLink runat="server" CssClass="fa fa-eye ver_btn" ID="btnPaymentHistoryPolicyUSD" NavigateUrl='<%# String.Format("~/Pages/PaymentHistory.aspx?Policy_No={0}", DataBinder.Eval(Container.DataItem, "POLICY_NUMBER")) %>' Target="_blank">
                        </asp:HyperLink>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="LINE_OF_BUSINESS" FieldName="LINE_OF_BUSINESS" Visible="false" VisibleIndex="10" />
                <dx:GridViewDataColumn Caption="CUSTNAME" FieldName="CUSTNAME" Visible="false" VisibleIndex="11" />
                <dx:GridViewDataColumn Caption="LINE_OF_BUSINESS" FieldName="LINE_OF_BUSINESS" Visible="false" VisibleIndex="12" />
            </Columns>
            <Templates>
                <FooterCell>
                    <dx:ASPxLabel ID="txtTotalPendingAmountUSD" runat="server" Text="" OnInit="txtTotalPendingAmountUSD_Init"></dx:ASPxLabel>
                </FooterCell>
            </Templates>
            <Settings ShowFooter="True" />
            <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
            <ClientSideEvents SelectionChanged="gridPolicies_SelectionChanged" EndCallback="function(s, e){loadingUSD(false); setGridStylesPolicies();}" BeginCallback="function(s, e){loadingUSD(true);}" />
        </dx:ASPxGridView>
            <%--<dx:ASPxGridView ID="gvUSDPolicies" OnDataBinding="gvUSDPolicies_DataBinding" ClientInstanceName="gvUSDPolicies" runat="server" OnSelectionChanged="gvUSDPolicies_SelectionChanged"
            KeyFieldName="Policy_No" Width="100%" OnFocusedRowChanged="gvUSDPolicies_SelectionChanged" OnCustomColumnDisplayText="gvDOPPolicies_CustomColumnDisplayText"
            EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" >
            <Settings ShowTitlePanel="false" ShowFilterRow="false" ShowFilterBar="Hidden" />
            <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
               
            <Columns>
                <dx:GridViewDataColumn Caption="Seleccionar">
                    <DataItemTemplate>
                        <asp:CheckBox runat="server" ID="ckbSelectPoliciesUSD" OnCheckedChanged="gvUSDPolicies_SelectionChanged" AutoPostBack="true" ValidationGroup="ckPoliciesUSD" />
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Linea de negocio" FieldName="Bl_Desc" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Plan" FieldName="Product_Desc" VisibleIndex="2" />
                <dx:GridViewDataColumn Caption="Poliza" FieldName="Policy_No" VisibleIndex="3" />
                <dx:GridViewDataColumn Caption="Estatus" FieldName="Policy_Status_Desc" VisibleIndex="4" />
                <dx:GridViewDataColumn Caption="Prima annual" FieldName="Annual_Premium" VisibleIndex="5" />
                <dx:GridViewDataColumn Caption="Fecha de vecimiento" FieldName="Expiration_Date" VisibleIndex="6" />
                <dx:GridViewDataColumn Caption="Balance pendiente" FieldName="PendingAmount" VisibleIndex="7"/>
                <dx:GridViewDataTextColumn Caption="Valor a pagar" VisibleIndex="8" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:TextBox runat="server" Style="text-align:right !important;" ID="txtAmountDueUSD" Enabled="false" OnTextChanged="txtAmountDueUSD_TextChanged" OnKeyPress="return bINT(event);" AutoPostBack="true"></asp:TextBox>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn Caption="Historico de Pagos" VisibleIndex="9" 
                    CellStyle-HorizontalAlign="Center">
                    <Settings AllowAutoFilter="False" AllowSort="False"></Settings>
                    <DataItemTemplate>
                        <asp:HyperLink runat="server" CssClass="fa fa-eye ver_btn" ID="btnPaymentHistoryPolicyUSD" NavigateUrl='<%# String.Format("~/Pages/PaymentHistory.aspx?Policy_No={0}", DataBinder.Eval(Container.DataItem, "Policy_No")) %>' Target="_blank">
                        </asp:HyperLink>
                    </DataItemTemplate>
                    <Settings AllowAutoFilter="False" AllowSort="False" />
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Bussiness_Line_Id" FieldName="Bussiness_Line_Id" Visible="false" VisibleIndex="10" />
                <dx:GridViewDataColumn Caption="Currency_Id" FieldName="Currency_Id" Visible="false" VisibleIndex="11" />
                <dx:GridViewDataColumn Caption="TotalDueAmount" FieldName="TotalDueAmount" Visible="false" VisibleIndex="12" />
                <dx:GridViewDataColumn Caption="Full_Name" FieldName="Full_Name" Visible="false" VisibleIndex="13" />
            </Columns>
            <Templates>
                <FooterCell>
                    <dx:ASPxLabel ID="txtTotalPendingAmountUSD" runat="server" Text="" OnInit="txtTotalPendingAmountUSD_Init"></dx:ASPxLabel>
                </FooterCell>
            </Templates>
            <Settings ShowFooter="True" />
            <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
            <ClientSideEvents SelectionChanged="gridPolicies_SelectionChanged" EndCallback="setGridStylesPolicies" />
        </dx:ASPxGridView>--%>
    </div>
</div>
    <div class="row_A mT20 mB100">
    <div class="col-4 fl">
        <asp:LinkButton runat="server" ID="btnBack" CssClass="back_btn" OnClick="btnBack_Click" OnClientClick="if (!UserBackConfirmation()) return false;">
            <i class="flecha_iz"></i>Volver página anterior
        </asp:LinkButton>
    </div>
    <div class="col-4 fr botones_func">
        <asp:Button runat="server" ID="btnContinue" CssClass="col-4 fr button button-green alignC embossed" OnClick="btnContinue_Click" Text="Continuar" />
        <asp:Button runat="server" ID="btnClearAll" CssClass="col-4 fr button button-red alignC embossed" OnClientClick="if (!UserClearConfirmation()) return false;" OnClick="btnClearAll_Click" Text="Limpiar" />
    </div>
</div>
</div>
<div id="cancelConfirmation" title="Procesar pagos pólizas canceladas">
    <br />
    <span class="ui-icon ui-icon-alert" style="margin: 0 7px 50px 0; float: left;"></span>
    <span>Usted ha seleccionado una póliza en estatus "Cancelada" (CA), para poder procesar algún pago, debe contactarse con el personal de servicios.</span>
    <hr />
    <br />
    <div class="ui-dialog-buttonset">
        <asp:Button runat="server" id="btnPaymentConfirmationCancelled" class="fr button button-green alignC embossed mB mR-1-p" OnClientClick="loading(true); paymentCancelModeConfirmation(false);" Text="Aceptar"></asp:Button>
    </div>
</div>

    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnPaymentConfirmationCancelled" />
    </Triggers>
</asp:UpdatePanel>