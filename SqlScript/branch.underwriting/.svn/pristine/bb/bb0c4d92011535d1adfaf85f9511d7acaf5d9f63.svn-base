<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Printing.ascx.cs" Inherits="Web.SubmittedPolicies.Life.UserControls.Issue.Printing" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Data.Linq" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<!--PASOS /> -->
<!--CAMPOS-->
<asp:UpdatePanel ID="upPrintingPolicies" runat="server" ClientIDMode="Static">
    <ContentTemplate>
        <div class="col-12 mT10 mB fl">
            <div class="col-2 fr alignC">
                <asp:Button runat="server" ID="btnFiltrar" CssClass="btn bgreen fr" Text="Filtrar" OnClick="btnFiltrar_OnClick" />
            </div>
            <div class="col-3 fr">
                <div class="trans_label">
                    <label>Tipo de Producto</label>
                    <asp:DropDownList runat="server" ID="ddlProductType" CssClass="pdL15" />
                </div>
            </div>
            <div class="col-3 fr">
                <div class="trans_label">
                    <label># de Póliza</label>
                    <asp:TextBox runat="server" ID="txtPolicyNo" CssClass="pdL15"></asp:TextBox>
                </div>
            </div>
            <div class="col-4 fr">
                <div class="trans_label">
                    <label>Estado de Impresión</label>
                    <asp:DropDownList runat="server" ID="ddlPrintingStatus" CssClass="pdL15" />
                </div>
            </div>
        </div>
        <!--CAMPOS />-->

        <div class="Grid_dv No_Click">
            <dx:ASPxGridView ID="gvPrinting"
                runat="server"
                DataSourceID="dsPrintingPolicies"
                KeyFieldName="Corp_Id;Region_Id;Country_Id;Domesticreg_Id;State_Prov_Id;City_Id;Office_Id;Case_Seq_No;Hist_Seq_No;Policy_No"
                EnableCallBacks="false"
                AutoGenerateColumns="false"
                ShowHeaderWhenEmpty="true">
                <Settings ShowFilterRow="false" ShowFilterBar="Hidden" ShowHeaderFilterButton="false" ShowFilterRowMenu="false" ShowFilterRowMenuLikeItem="false" />
                <Columns>
                    <dx:GridViewDataColumn FieldName="Policy_No" Caption="Número de Póliza" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c1" HeaderStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn FieldName="OwnerFullName" Caption="Nombre del Propietario" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c2" HeaderStyle-CssClass="c2" HeaderStyle-HorizontalAlign="Center"  />
                    <dx:GridViewDataDateColumn FieldName="Policy_Effective_Date" Caption="Fecha de Emisión" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c3" HeaderStyle-CssClass="c3"
                        CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                        <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataColumn FieldName="Product_Desc" Caption="Tipo de Producto" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c4" HeaderStyle-CssClass="c4"  HeaderStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataTextColumn FieldName="Initial_Premium" Caption="Monto de Prima Inicial" HeaderStyle-HorizontalAlign="Center"  Settings-AutoFilterCondition="Equals" CellStyle-CssClass="c5" HeaderStyle-CssClass="c5">
                        <PropertiesTextEdit DisplayFormatString="C2"></PropertiesTextEdit>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataColumn FieldName="Payment_Freq_Type_Desc" Caption="Frecuencia de Pago" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c6" HeaderStyle-CssClass="c6" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataColumn FieldName="MethodOfPayment" Caption="Tipo de Pago" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c7" HeaderStyle-CssClass="c7" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                    <dx:GridViewDataDateColumn FieldName="LastPaymentDate" Caption="Fecha Pago Final" HeaderStyle-HorizontalAlign="Center" CellStyle-CssClass="c8" HeaderStyle-CssClass="c8"
                        CellStyle-HorizontalAlign="Center" Settings-AutoFilterCondition="Equals">
                        <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataColumn FieldName="AgentFullName" Caption="Nombre Agente" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c9" HeaderStyle-CssClass="c9" HeaderStyle-HorizontalAlign="Center"  />
                    <dx:GridViewDataColumn FieldName="Office_Desc" Caption="Oficina" Settings-AutoFilterCondition="Contains" CellStyle-CssClass="c10" HeaderStyle-CssClass="c10" HeaderStyle-HorizontalAlign="Center"  />
                    <dx:GridViewCommandColumn ButtonType="Image" Caption="Revisar" HeaderStyle-CssClass="c11" HeaderStyle-HorizontalAlign="Center">
                        <CustomButtons>
                            <dx:GridViewCommandColumnCustomButton ID="btnRevisar" Styles-CssPostfix="c15 btn1 ico_G review" />
                        </CustomButtons>
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn FieldName="Is_Print" Caption="¿Impresa?" CellStyle-CssClass="c12" HeaderStyle-CssClass="c12" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage ID="imgStatus" ImageUrl='<%# Eval("Is_Print_Image")%>' runat="server" Width="22px" Height="26px" ImageAlign="Middle"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" Caption="Seleccionar" CellStyle-CssClass="c13" HeaderStyle-CssClass="c13" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" />
                </Columns>
                <SettingsBehavior AllowFocusedRow="False" ProcessFocusedRowChangedOnServer="true" AllowSelectSingleRowOnly="False" AllowSort="True" />
                <SettingsPager PageSize="10" NumericButtonCount="3" />
            </dx:ASPxGridView>
            <dx:LinqServerModeDataSource ID="dsPrintingPolicies" runat="server" OnSelecting="dsPrintingPolicies_OnSelecting" />
        </div>
        <div class="row_A fl mT10">
            <asp:LinkButton runat="server" ID="lnkImprimir" OnClick="lnkImprimir_OnClick" CssClass="btn bgreen fr" Text="Imprimir"></asp:LinkButton>
        </div>
        <asp:HiddenField runat="server" ID="hdnPolicyNo" />
        <asp:HiddenField runat="server" ID="hdnProductType" />
        <asp:HiddenField runat="server" ID="hdnPrintStatus" />
    </ContentTemplate>
</asp:UpdatePanel>
