<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CM.Master" AutoEventWireup="true" CodeBehind="DailyCash.aspx.cs" UICulture="es" Culture="es-MX"  Inherits="CollectorsModule.Pages.DailyCash" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <br clear="all" />
    <br clear="all" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script>
                $('#ContentSection_rpFilter_RPC').removeClass();
            </script>
            <div class="containerDC">
                <div class="leftPaneDC">
                    <div id="history" class="contenido mdl_recaudo_cont">
                        <div class="row_A blue">
                            <div class="cont_gnl fbus">
                                <dx:ASPxRoundPanel ID="rpFilter" runat="server" HeaderText="Filter">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <div class="ttlStep  azul_c">Filtros de Búsqueda</div>
                                            <div class="row_A mT20">
                                                <div class="box">
                                                    <div class="label_plus_input par row_A">
                                                        <span>Reporte</span>
                                                        <asp:DropDownList runat="server" ID="ddlReportsDailyCash" ClientIDMode="Static">
                                                            <asp:ListItem Text="Individual - Diario" Value="IndividualToday" />
                                                            <asp:ListItem Text="Individual - Rango" Value="IndividualRange" />
                                                            <%--
                                                                <asp:ListItem Text="Todos - Diario" Value="BatchToday" />
                                                                <asp:ListItem Text="Todos - Rango" Value="BatchRange" />
                                                            --%>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div id="adminUser" runat="server">
                                                        <div class="label_plus_input par row_A"> 
                                                            <span>Usuario</span>
                                                            <asp:DropDownList runat="server" ID="ddlUsersSecurity">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div id="regularUser" runat="server">
                                                        <div class="span_plus_table par row_A">
                                                            <span>Usuario</span>
                                                            <div class="tbInSel">
                                                                <dx:ASPxTextBox ID="txtCollectorName" ReadOnly="true" runat="server" CssClass="pdL12px">
                                                                </dx:ASPxTextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="span_plus_table par row_A">
                                                        <span>Oficina</span>
                                                        <div class="tbInSel">
                                                            <dx:ASPxTextBox ID="txtOfficeName" ReadOnly="true" runat="server" CssClass="pdL12px">
                                                            </dx:ASPxTextBox>
                                                        </div>
                                                    </div>
                                                    <div class="label_plus_input par row_A">
                                                        <span>Forma de Pago</span>
                                                        <asp:DropDownList runat="server" ID="ddlPaymentType">
                                                            <asp:ListItem Text="Todos" Value="" />
                                                            <asp:ListItem Text="Efectivo" Value="0" />
                                                            <asp:ListItem Text="Cheque" Value="1" />
                                                            <asp:ListItem Text="Tarjeta de Crédito" Value="2" />
                                                            <asp:ListItem Text="Transferencia ACH" Value="3" />
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="span_plus_table par row_A">
                                                        <span>Fecha inicio</span>
                                                        <div class="tbInSel">
                                                            <dx:ASPxDateEdit ID="txtDateFrom" ClientInstanceName="txtDateFrom" OnInit="txtDateFrom_Init" OnDateChanged="txtDate_DateChanged" CssClass="pdL12px" runat="server">
                                                                <ValidationSettings CausesValidation="True">
                                                                </ValidationSettings>
                                                                <ClientSideEvents DateChanged="function(s,e){validateDates();}" />
                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>

                                                    <div class="span_plus_table par row_A">
                                                        <span>Fecha Fin</span>
                                                        <div class="tbInSel">
                                                            <dx:ASPxDateEdit ID="txtDateTo" OnInit="txtDateTo_Init" ClientInstanceName="txtDateTo" OnDateChanged="txtDate_DateChanged" CssClass="pdL12px" runat="server">
                                                                <ValidationSettings CausesValidation="True">
                                                                </ValidationSettings>
                                                                <ClientSideEvents DateChanged="function(s,e){validateDates();}" />
                                                            </dx:ASPxDateEdit>
                                                        </div>
                                                    </div>

                                                    <asp:LinkButton ID="lnkPreview" runat="server" CssClass="box_2 button button-rose alignC" OnClick="btPreview_Click" OnClientClick="return validateReportValues();">Ver</asp:LinkButton>
                                                    <div style="visibility:hidden"><asp:LinkButton ID="LinkButton2" runat="server" CssClass="box_2 button button-green alignC">Limpiar</asp:LinkButton></div>
                                                </div>
                                            </div>

                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ReportContainer" class="rightPaneDC">
                    <iframe style="height: 680px" runat="server" id="iReport" frameborder="0" src="~/Reports/Default.pdf"></iframe>
                </div>
            </div>

            <div id="errorgenerating" title="Reporte Transacciones Procesadas" style="height: 200px !important">
                <br />
                <span class="ui-icon ui-icon-alert" style="margin: 0 7px 50px 0; float: left;"></span>
                <span>Ocurrió un error generando el reporte, las causas probables son: </span>
                <br />
                <br /><span style="margin-left:5px;">- No existen registros posteados para los filtros especificados.</span>
                <br /><span style="margin-left:5px;">- La combinación de parametros, no arrojo datos y necesita ser evaluado por el administrador del sistema.</span>
                <hr />
                <div class="ui-dialog-buttonset">
                    <asp:Button runat="server" ID="btnConfirmClose" CssClass="fr button button button-red alignC embossed" OnClientClick="$('#errorgenerating').dialog('close');" Text="Cerrar" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
