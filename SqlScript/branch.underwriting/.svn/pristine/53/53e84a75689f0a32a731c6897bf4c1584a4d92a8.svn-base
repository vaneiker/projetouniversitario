<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPEPForm.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationsVehicle.WUCPEPForm" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:UpdatePanel runat="server" style="width: 100%" RenderMode="Block" ID="udpPep" ClientIDMode="Static">
    <ContentTemplate>
        <div class="select_buy1">
            <div class="box_SP row_B">
                <div class="ttl">
                    <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" Style="top: -6px; position: relative;" OnClick="btnAdd_Click" CssClass="fl" /><asp:Label Style="font-family: initial;" runat="server" ID="lblAgregarContrato" Text="Agregar"></asp:Label>
                </div>
                <div class="boxCont">
                    <dx:ASPxGridView
                        ID="gvPEP"
                        runat="server"
                        EnableCallBacks="False"
                        AutoGenerateColumns="false"
                        Width="100%"
                        KeyFieldName="RecordIndex;Status"
                        OnRowCommand="gvPEP_RowCommand">
                        <Columns>
                            <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center" Width="100">
                                <DataItemTemplate>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="grupos de_2" style="text-align: center">
                                                <asp:Panel runat="server" ID="pnDelete">
                                                    <asp:LinkButton runat="server" ID="btnDeletePEP" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this);" />
                                                </asp:Panel>
                                                <div>
                                                    <asp:LinkButton runat="server" ID="btnCancelPEP" CssClass="mycancel_file" CommandName="Cancel" Visible="false" />
                                                </div>
                                                <div>
                                                    <asp:LinkButton runat="server" ID="btnEditOrSavePEP" CssClass="myedit_file" CommandName="Edit" OnClientClick="return validateForm('udpPep');" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnEditOrSavePEP" />
                                            <asp:AsyncPostBackTrigger ControlID="btnCancelPEP" />
                                            <asp:AsyncPostBackTrigger ControlID="btnDeletePEP" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Nombre Completo" Settings-AllowSort="true" Name="NameLabel" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtName" validation="Required" label="Nombre Completo" Visible="false" Text='<%#Eval("NombreCompleto")%>'></asp:TextBox>
                                    <asp:Literal runat="server" ID="ltName" Text='<%#Eval("NombreCompleto")%>' />
                                    <asp:Label ID="BeneficiaryId" runat="server" Text='<%# Eval("BeneficiaryId") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="PepFormularyOptionsId" runat="server" Text='<%# Eval("PepFormularyOptionsId") %>' Visible="false"></asp:Label>
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Parentesco" Settings-AllowSort="true" Name="" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <div>
                                        <asp:DropDownList runat="server" ID="ddlParentesco" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlParentesco_SelectedIndexChanged" label="Parentesco" Visible="false"></asp:DropDownList>
                                    </div>
                                    <asp:Literal runat="server" ID="ltParentesco" Text='<%#Eval("ParentescoDesc")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Posición y/o Cargo Público" Settings-AllowSort="true" Name="" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtCargoPublico" Text='<%#Eval("CargoPublico")%>' validation="Required"  label="Posición y/o Cargo Público" Visible="false"></asp:TextBox>
                                    <asp:Literal runat="server" ID="ltCargoPublico" Text='<%#Eval("CargoPublico")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Año Desde" Settings-AllowSort="true" Name="" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtanioDesde" Text='<%#Eval("anioDesde")%>' number="number4" style="text-align:center" Visible="false"></asp:TextBox>
                                    <asp:Literal runat="server" ID="ltanioDesde" Text='<%#Eval("anioDesde")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                            <dx:GridViewDataColumn Caption="Año Hasta" Settings-AllowSort="true" Name="" CellStyle-HorizontalAlign="Center">
                                <DataItemTemplate>
                                    <asp:TextBox runat="server" ID="txtAnioHasta" Text='<%#Eval("anioHasta")%>' style="text-align:center" number="number4" Visible="false"></asp:TextBox>
                                    <asp:Literal runat="server" ID="ltAnioHasta" Text='<%#Eval("anioHasta")%>' />
                                </DataItemTemplate>
                            </dx:GridViewDataColumn>
                        </Columns>
                        <Settings ShowFooter="True" />
                        <Settings VerticalScrollableHeight="300" VerticalScrollBarMode="Visible" />
                    </dx:ASPxGridView>
                </div>
            </div>
        </div>        
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" />
    </Triggers>
</asp:UpdatePanel>
