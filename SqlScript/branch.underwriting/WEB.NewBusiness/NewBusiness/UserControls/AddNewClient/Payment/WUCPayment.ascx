<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPayment.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Payment.WUCPayment" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" ID="udpPayment" RenderMode="Inline">
    <ContentTemplate>
        <div class="fix_height">
            <!--nivela los altos importante-->
            <div class="fondo_blanco fix_height" id="dvFPayment">
                <div class="titulos_azules"><span class="payment"></span><strong runat="server" id="Payment">PAYMENT</strong></div>
                <div class="content_fondo_blanco">
                    <div class="grupos de_2">
                        <div>
                            <label class="label" runat="server" id="PeriodicPremium">Periodic Premium</label>
                            <asp:TextBox runat="server" ID="txtPeriodicPremium" Enabled="false" decimal="decimal" />
                        </div>
                        <div>
                            <label class="label" runat="server" id="InitialContribution">Initial Contribution</label>
                            <asp:TextBox runat="server" ID="txtInitialContribution" Enabled="false" decimal="decimal" />
                        </div>
                        <div>
                            <label class="label" runat="server" id="FuturePayment">Future Payment</label>
                            <asp:TextBox runat="server" ID="txtFuturePayment" decimal="decimal" />
                        </div>
                        <div>
                            <label class="label" runat="server" id="Total">Total</label>
                            <asp:TextBox runat="server" ID="txtTotal" Enabled="false" decimal="decimal" />
                        </div>
                        <div>
                        </div>
                        <div>
                            <label class="label" runat="server" id="lblPendingForPay">Pending For Pay</label>
                            <asp:TextBox runat="server" ID="txtPendingForPay" ReadOnly="true" decimalWithsign="decimalWithsign" disabled />
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grupos de_1">
                        <div> 
                            <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vCalculateActive" runat="server">
                                    <div class="boton_wrapper azul float_right">
                                        <span class="calculate"></span>
                                        <asp:Button CssClass="boton" Text="Calculate" runat="server" ID="btnCalculate" OnClick="btnCalculate_Click" />
                                    </div>
                                </asp:View>
                                <asp:View ID="vCalculateInactive" runat="server">
                                    <div class="boton_wrapper inactive float_right">
                                        <span class="process_inactive"></span>
                                        <asp:Button CssClass="aspNetDisabled boton" Text="Calculate" runat="server" ID="btnCalculate2" Enabled="false" disabled="disabled" />
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                            <!--boton_wrapper-->
                        </div>
                    </div>
                    <!--grupos-->

                    <div class="grid_wrap margin_t_10 gris">
                        <dx:ASPxGridView ID="gvPayment" runat="server"
                            EnableCallBacks="False"
                            AutoGenerateColumns="False"
                            SettingsPager-PageSize="15"
                            KeyFieldName="UsdCreditAmount;DocumentId;PaymentDocumentation;PaymentDetId;PaymentId;CurrencyId;PaymentStatusId"
                            Width="100%" OnPageIndexChanged="gvPayment_PageIndexChanged" OnPreRender="gvPayment_PreRender" OnRowCommand="gvPayment_RowCommand">
                            <SettingsPager PageSize="15">
                            </SettingsPager>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="Payment Type" FieldName="PaymentDocumentation" VisibleIndex="0" Name="PaymentType">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Payment Description" FieldName="PaymentSourceDesc" VisibleIndex="1" Name="PaymentDescription">
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Amount" FieldName="UsdCreditAmount" VisibleIndex="2" Name="AmountLabel">
                                    <PropertiesTextEdit DisplayFormatString="N2">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>

                                <dx:GridViewDataTextColumn Caption="Result / Code" FieldName="PaymentStatusDesc" VisibleIndex="4" Name="ResultCode">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataColumn Caption="Action" VisibleIndex="5" Name="ActionLabel">
                                    <DataItemTemplate>
                                        <asp:Button Style="border: 1px solid black; width: 100%; background-color: burlywood;" Enabled='<%# (int)Eval("PaymentStatusId")!=1 %>' runat="server" ID="btnPay" Text='<%#RESOURCE.UnderWriting.NewBussiness.Resources.Process %>' Visible='<%# (int)Eval("PaymentSourceTypeId")==2 %>' CommandArgument="Pay" />
                                    </DataItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                            <Settings ShowFooter="True" />
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="UsdCreditAmount" SummaryType="Sum" />
                            </TotalSummary>
                        </dx:ASPxGridView>

                    </div>
                    <!--grid_wrap-->

                    <div class="grupos de_1">
                        <div>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="vInactive" runat="server">
                                    <div class="boton_wrapper inactive float_right">
                                        <span class="process_inactive"></span>
                                        <asp:Button CssClass="aspNetDisabled boton" Text="Process" runat="server" ID="btnProcessPayment2" OnClick="btnProcessPayment_Click" Enabled="false" disabled="disabled" />
                                    </div>
                                </asp:View>
                                <asp:View ID="vActive" runat="server">
                                    <div class="boton_wrapper verde float_right">
                                        <span class="process_02"></span>
                                        <asp:Button CssClass="boton" Text="Process" runat="server" ID="btnProcessPayment" OnClick="btnProcessPayment_Click" />
                                    </div>
                                </asp:View>
                            </asp:MultiView>
                            <!--boton_wrapper-->
                        </div>
                    </div>

                    <!--grupos-->
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </div>
        <!--end fix height para nivelar los altos importante-->
        <asp:HiddenField runat="server" ID="hdntotalPay" ClientIDMode="Static" />
    </ContentTemplate>
</asp:UpdatePanel>
