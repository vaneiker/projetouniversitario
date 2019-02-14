<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPaymentConfirmation.ascx.cs" Inherits="CollectorsModule.Controls.ucPaymentConfirmation" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<style>
    #ContentSection_ucPaymentConfirmation_gvPaymentsProcessed_tcfooter5 
    {
        background: #58AA00;
        color: white;
    }
</style>
<div class="contenido">
    <div class="ttlStep  azul_c ">Confirmación</div>
    <div class="bdrRadius20 row_A mT40 mB">
        <div class="ttlStep  azul_c azul_pl">Monto por Póliza</div>
        <div class=" tbl data_Gpl mdl_cj_confirmacionPP">
             <dx:ASPxGridView ID="gvPaymentsProcessed" ClientInstanceName="gvPaymentsProcessed" OnDataBinding="gvPaymentsProcessed_DataBinding" runat="server" KeyFieldName="Policy_No" Width="100%" 
                EnableRowsCache="false" SettingsBehavior-AllowFocusedRow="false" OnCustomColumnDisplayText="gvPaymentsProcessed_CustomColumnDisplayText" >
                <Settings ShowTitlePanel="false" ShowFilterRow="false" ShowFilterBar="Hidden" />
                <SettingsBehavior AllowGroup="false" AllowDragDrop="false" />
               
                <Columns>
                    <dx:GridViewDataColumn Caption="Linea de negocio" FieldName="Bl_Desc" VisibleIndex="1" />
                    <dx:GridViewDataColumn Caption="Plan" FieldName="Product_Desc" VisibleIndex="2" />
                    <dx:GridViewDataColumn Caption="Póliza" FieldName="Policy_No" VisibleIndex="3" />
                    <dx:GridViewDataColumn Caption="Estado transacción" FieldName="ResponseCode" VisibleIndex="4" Visible="true" />
                    <dx:GridViewDataColumn Caption="Tag" FieldName="KwikTag" VisibleIndex="5" Visible="true" />
                    <dx:GridViewDataColumn Caption="Valor pagado" FieldName="PaidAmount" VisibleIndex="6" />
                    <dx:GridViewDataColumn Caption="Recibo" FieldName="KwikTag" CellStyle-HorizontalAlign="Center" VisibleIndex="7" Visible="true">
                        <DataItemTemplate>
                            <%--<asp:LinkButton runat="server" CssClass="fa fa-eye ver_btn" ID="lnkInvoiceDocument" OnClick="lnkInvoiceDocument_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "KT_BARCODE") %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "KT_BARCODE") %>' />--%>
                            <asp:HyperLink runat="server" CssClass="fa fa-print ver_btn" ID="lnkInvoiceDocument" NavigateUrl='<%# String.Format("~/Controls/oInvoice.ashx?Barcode={0}&rePrint=No", DataBinder.Eval(Container.DataItem, "KwikTag")) %>' Target="_new" />
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                </Columns>
                <Templates>
                    <FooterCell>
                        <dx:ASPxLabel ID="txtTotalAmount" runat="server" Text="" OnInit="txtTotalAmount_Init"></dx:ASPxLabel>
                    </FooterCell>
                </Templates>
                <Settings ShowFooter="True" />
                 <ClientSideEvents EndCallback="function(s, e){setGridStylesPayments(); loadingHistory(false);}" BeginCallback="function(s, e){setGridStylesPayments(); loadingHistory(false);}"  />
            </dx:ASPxGridView>                    
        </div>
    </div>
    <div class="row_A mB40">
        <span class="lb_azul wd50 fl alignC">Forma de pago: <asp:Label runat="server" ID="lblPaymentForm"></asp:Label></span>
        <div class="fr ">
            <asp:LinkButton runat="server" ID="lnkCloseTransaction" CssClass="fr button print button-green alignC embossed" OnClientClick="if (!UserCloseConfirmation()) return false;" OnClick="lnkCloseTransaction_Click">
                Volver al Inicio
            </asp:LinkButton>
            <%--<asp:LinkButton runat="server" ID="lnkPrintInvoice" CssClass="fr button print button-blue alignC embossed azul_pl" OnClick="lnkPrintInvoice_Click">
            <i class="fa fa-print"></i> Imprimir Recibo
            </asp:LinkButton>--%>
        </div>
    </div>
</div><!--contenido-->
<div id="contentInvoice" style="display:none;">

</div>
<script>
    loadingHistory(false);
</script>