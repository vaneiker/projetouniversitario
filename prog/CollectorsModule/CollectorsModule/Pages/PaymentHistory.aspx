<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CM.Master" AutoEventWireup="true" CodeBehind="PaymentHistory.aspx.cs" UICulture="es" Culture="es-MX" Inherits="CollectorsModule.Pages.PaymentHistory" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <br clear="all"/>
    <!-- <a href="#" class="btn_Recaudo">Historial de pago procesados</a> -->
        
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>     
    <script>
        $('#ContentSection_rpFilter_RPC').removeClass();
    </script>
    <style>


    </style>
              
    <div id="history" class="contenido mdl_recaudo_cont">
            
        <div class="row_A blue">
            <div class=" row_B">
                <div class="cont_gnl box_2-2 mR rsu">
                    <div class="ttlStep  azul_c">Resumen</div>
                    <div class="label_plus_input par row_A mT20"> 
                        <span>Cobros por Tarjeta de Crédito</span>
                        <asp:TextBox ID="txtCreditCardCount" readonly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A"> 
                        <span>Cobros por ACH</span>
                        <asp:TextBox ID="txtACHCount" readonly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A"> 
                        <span>Cobros por Cheque</span>
                        <asp:TextBox ID="txtCheckCount" readonly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A"> 
                        <span>Cobros por Efectivo</span>
                        <asp:TextBox ID="txtCashCount" readonly="true" runat="server"></asp:TextBox>
                    </div>
                    <div class="label_plus_input par row_A total1"> 
                        <span>Total del Período</span>
                        <asp:TextBox ID="txtTotalCount" readonly="true" runat="server"></asp:TextBox>
                    </div>
                    
                </div>
            <div class="cont_gnl box_2-2 fbus">
                <dx:ASPxRoundPanel ID="rpFilter" runat="server" HeaderText="Filter">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        
                        <div class="ttlStep  azul_c">Filtros de Búsqueda</div>
                        <div class="row_A mT20">
                                    <div class="box_2">
                                        <div class="span_plus_table par row_A"> 
                                            <span>Fecha inicio</span>
                                            <div class="tbInSel">
                                                <dx:ASPxDateEdit ID="txtDateFrom" ClientInstanceName="txtDateFrom" OnInit="txtDateFrom_Init" OnDateChanged="txtDate_DateChanged" runat="server">
                                                    <validationsettings CausesValidation="True">
                                                    </validationsettings>
                                                    <clientsideevents DateChanged="function(s,e){validateDates();}" />
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>

                                        <div class="label_plus_input par row_A"> 
                                            <span>Usuario procesador</span>
                                            <asp:DropDownList runat="server" ID="ddlUsersSecurity">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="span_plus_table par row_A"> 
                                            <span>Póliza</span>
                                            <div class="tbInSel">
                                                <dx:ASPxTextBox ID="txtPolicyNo" runat="server" Width="170px">
                                                </dx:ASPxTextBox>
                                            </div>
                                        </div>
                                        <div style="display:none;" class="label_plus_input par row_A"> 
                                            <span>Módulo</span>
                                            <asp:DropDownList runat="server" ID="ddlModuleProcessor">
                                                <%--<asp:ListItem Text="" Value="0" />
                                                <asp:ListItem Text="Collectors" Value="CollectorsModule" />--%>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="label_plus_input par row_A"> 
                                            <span>Moneda</span>
                                            <asp:DropDownList runat="server" ID="ddlCurrency">
                                                <asp:ListItem Text="" Value="0" />
                                                <asp:ListItem Text="USD" Value="1" />
                                                <asp:ListItem Text="DOP" Value="3" />
                                            </asp:DropDownList>
                                        </div>

                                        <asp:LinkButton ID="lnkSearch" runat="server" OnClick="lnkSearch_Click" CssClass="box_2 button button-green alignC embossed">Buscar</asp:LinkButton>
                                    </div>


                                    <div class="box_2">
                                        <div class="span_plus_table par row_A"> 
                                            <span>Fecha Fin</span>
                                            <div class="tbInSel">
                                                <dx:ASPxDateEdit ID="txtDateTo" OnInit="txtDateTo_Init" ClientInstanceName="txtDateTo" OnDateChanged="txtDate_DateChanged" runat="server">
                                                    <validationsettings CausesValidation="True">
                                                    </validationsettings>
                                                    <clientsideevents DateChanged="function(s,e){validateDates();}" />
                                                </dx:ASPxDateEdit>
                                            </div>
                                        </div>

                                        <div class="label_plus_input par row_A"> 
                                            <span>Oficina</span>
                                            <asp:DropDownList runat="server" ID="ddlOfficeFilters">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="label_plus_input par row_A"> 
                                            <span>Línea de Negocio</span>
                                            <asp:DropDownList runat="server" ID="ddlBusinessLine">
                                                <%--<asp:ListItem Text="" Value="0" />
                                                <asp:ListItem Text="Collectors" Value="CollectorsModule" />--%>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="label_plus_input par row_A" style="visibility:hidden;"> 
                                            <%--<span>Moneda</span>
                                            <asp:DropDownList runat="server" ID="ddlCurrency">
                                                <asp:ListItem Text="" Value="0" />
                                                <asp:ListItem Text="USD" Value="1" />
                                                <asp:ListItem Text="DOP" Value="3" />
                                            </asp:DropDownList>--%>
                                        </div>
                                        <asp:Button ID="btnClean" runat="server" OnClick="btnClean_Click" CssClass="box_2 button button-blue alignC embossed" Text="Limpiar"></asp:Button>
                                    </div>
                                </div>
                        
                    </dx:PanelContent>
                </PanelCollection>
                </dx:ASPxRoundPanel>
            </div>
        </div>
          
        
                           
        <div id="historyContent" class=" tbl data_Gpl cont_gnl">
            <dx:ASPxGridView ID="gvPaymentHistory" OnDataBinding="gvPaymentHistory_DataBinding" ClientInstanceName="gvPaymentHistory" runat="server" KeyFieldName="GP_PAYMENT_NUMBER" EnableCallBacks="true" OnHtmlDataCellPrepared="gvPaymentHistory_HtmlDataCellPrepared"
                Width="100%" EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" OnCustomColumnDisplayText="gvPaymentHistory_CustomColumnDisplayText" onCustomCallback="gvPaymentHistory_CustomCallback">
                <Settings ShowTitlePanel="false" ShowFilterRow="false" />
                <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
                <Columns>
                    <dx:GridViewDataColumn Caption="No. de Póliza" HeaderStyle-VerticalAlign="Middle" FieldName="POLICY_NUMBER" VisibleIndex="0" />
                    <dx:GridViewDataColumn Caption="Línea de negocio" FieldName="LINE_OF_BUSINESS" VisibleIndex="1" />
                    <dx:GridViewDataColumn Caption="Nombre del Cliente" FieldName="CUSTNAME" VisibleIndex="2" />
                    <dx:GridViewDataColumn Caption="Moneda" FieldName="CURRENCY_ID" VisibleIndex="3" />
                    <dx:GridViewDataColumn Caption="Monto de pago" FieldName="PAYMENT_AMOUNT" VisibleIndex="4" />
                    <dx:GridViewDataColumn Caption="Fecha de pago" FieldName="PAYMENT_DATE" VisibleIndex="5" SortOrder="Ascending" Settings-SortMode="Custom"/>
                    <dx:GridViewDataColumn Caption="Hora de pago" FieldName="PAYMENT_HOUR" VisibleIndex="6" />
                    <dx:GridViewDataColumn Caption="Forma de pago" CellStyle-HorizontalAlign="Left" FieldName="PAYMENT_TYPE" VisibleIndex="7" />
                    <dx:GridViewDataColumn Caption="No. Cuenta" FieldName="ACCOUNT_NUMBER" VisibleIndex="8" />
                    <dx:GridViewDataColumn Caption="No. de Recibo" FieldName="GP_PAYMENT_NUMBER" VisibleIndex="9" />
                    <dx:GridViewDataColumn Caption="Estatus Trans." FieldName="GP_STATUS" VisibleIndex="10" />
                    <dx:GridViewDataColumn Caption="Oficina" FieldName="OFFICE_NUMBER" VisibleIndex="11" />
                    <dx:GridViewDataColumn Caption="Usuario" FieldName="RECEIVED_BY" VisibleIndex="12" />
                    <dx:GridViewDataColumn Caption="Módulo" FieldName="SOURCE_SYSTEM" VisibleIndex="13" Visible="false" />
                    <dx:GridViewDataColumn Caption="KwkikTag" FieldName="KT_BARCODE" CellStyle-HorizontalAlign="Center" VisibleIndex="14" Visible="true" SortOrder="Ascending" Settings-SortMode="Custom">
                        <DataItemTemplate>
                            <asp:HyperLink runat="server" CssClass="fa fa-eye ver_btn" ID="lnkKwiktagDocument" NavigateUrl='<%# String.Format("~/Controls/vwDocument.ashx?Barcode={0}", DataBinder.Eval(Container.DataItem, "KT_BARCODE")) %>' Target="_blank">
                            </asp:HyperLink>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tag" FieldName="KT_BARCODE" VisibleIndex="14" Visible="true" />
                    <dx:GridViewDataColumn Caption="Recibo" FieldName="KT_BARCODE" CellStyle-HorizontalAlign="Center" VisibleIndex="13" Visible="true">
                        <DataItemTemplate>
                            <%--<asp:LinkButton runat="server" CssClass="fa fa-eye ver_btn" ID="lnkInvoiceDocument" OnClick="lnkInvoiceDocument_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "KT_BARCODE") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "KT_BARCODE") %>' />--%>
                            <asp:HyperLink runat="server" CssClass="fa fa-print ver_btn" ID="lnkInvoiceDocument" NavigateUrl='<%# String.Format("~/Controls/oInvoice.ashx?Barcode={0}&rePrint=Yes", DataBinder.Eval(Container.DataItem, "KT_BARCODE")) %>' Target="_new" />
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>
                <Templates>
                    <FooterCell>
                        <dx:ASPxLabel ID="txtTotalPendingAmount" runat="server" Text=""></dx:ASPxLabel>
                    </FooterCell>
                </Templates>
                <Settings ShowFooter="True" />
                <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                <ClientSideEvents SelectionChanged="grid_SelectionChanged" EndCallback="function(s, e) {loadingHistory(false);setGridStylesHistory();}" BeginCallback="function(s, e) {loadingHistory(true);}" />
            </dx:ASPxGridView>
               <%--<dx:ASPxGridView ID="gvPaymentHistory" OnDataBinding="gvPaymentHistory_DataBinding" ClientInstanceName="gvPaymentHistory" runat="server"
                Width="100%" EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" OnCustomColumnDisplayText="gvPaymentHistory_CustomColumnDisplayText" >
                <Settings ShowTitlePanel="false" ShowFilterRow="false" ShowFilterBar="Hidden" />
                <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
                <Columns>
                    <dx:GridViewDataColumn Caption="No. de Póliza" FieldName="Policy_No" VisibleIndex="0" />
                    <dx:GridViewDataColumn Caption="Línea de negocio" FieldName="Bl_Desc" VisibleIndex="1" />
                    <dx:GridViewDataColumn Caption="Nombre del Cliente" FieldName="Full_Name" VisibleIndex="2" />
                    <dx:GridViewDataColumn Caption="Moneda" FieldName="Currency_Desc" VisibleIndex="3" />
                    <dx:GridViewDataColumn Caption="Monto de pago" FieldName="Paid_Amount" VisibleIndex="4" />
                    <dx:GridViewDataColumn Caption="Fecha de pago" FieldName="Paid_Date" VisibleIndex="5" />
                    <dx:GridViewDataColumn Caption="Hora de pago" FieldName="Transaction_Date" VisibleIndex="6" />
                    <dx:GridViewDataColumn Caption="Forma de pago" FieldName="Payment_Source_Type_Desc" VisibleIndex="7" />
                    <dx:GridViewDataColumn Caption="No. Cuenta" FieldName="Currency_Desc" VisibleIndex="8" />
                    <dx:GridViewDataColumn Caption="No. de Recibo" FieldName="Other_Description" VisibleIndex="9" />
                    <dx:GridViewDataColumn Caption="Oficina" FieldName="Office_Desc" VisibleIndex="10" />
                    <dx:GridViewDataColumn Caption="Usuario" FieldName="UserName" VisibleIndex="11" />
                    <dx:GridViewDataColumn Caption="Módulo" FieldName="UserName" VisibleIndex="12" />
                </Columns>
                <Templates>
                    <FooterCell>
                        <dx:ASPxLabel ID="txtTotalPendingAmount" runat="server" Text=""></dx:ASPxLabel>
                    </FooterCell>
                </Templates>
                <Settings ShowFooter="True" />
                <SettingsBehavior ProcessFocusedRowChangedOnServer="true" />
                <ClientSideEvents SelectionChanged="grid_SelectionChanged" />
            </dx:ASPxGridView>--%>
        </div>
        <div class="row_A mT10">
            <ul class="export_doc Doc_Actions">
                <li>Exportar a</li>
                <li><asp:LinkButton ID="lnkExportPDF" runat="server" OnClick="lnkExportPDF_Click" CssClass="pdf_icon2"></asp:LinkButton></li>
                <li><asp:LinkButton ID="lnkExportExcel" runat="server" OnClick="lnkExportExcel_Click" CssClass="excel"></asp:LinkButton></li>
                <dx:ASPxGridViewExporter ID="gvExporter" GridViewID="gvPaymentHistory" OnRenderBrick="gvExporter_RenderBrick" runat="server"></dx:ASPxGridViewExporter>
            </ul>                      
        </div>
            
    </div>
    </div><!--contenido-->
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="lnkExportPDF" />
        <asp:PostBackTrigger ControlID="lnkExportExcel" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>
