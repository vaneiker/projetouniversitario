<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCIdentification.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.WUCIdentification" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpIdentification" OnUnload="UpdatePanel_Unload">
    <ContentTemplate>
        <asp:Panel runat="server" class="col-1-3 " ID="frmIdentifications" ClientIDMode="Static">
            <div class="fondo_blanco ">
                <div class="titulos_azules">
                    <span class="identification"></span><strong>
                        <asp:Literal runat="server" ID="ltIdentifications">IDENTIFICATIONS</asp:Literal>
                    </strong>
                </div>
                <div class="content_fondo_blanco fix_height">
                    <asp:Panel runat="server" ID="pnForm" DefaultButton="btnAddIdentification">
                        <div class="grupos">
                            <div style="width: 50%">
                                <label class="label red" runat="server" id="IDType">ID Type</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="cbxIDType" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="cbxIDType_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                            <div class="float_right">
                                <div class="boton_wrapper amarillo float_right">
                                    <span class="add"></span>
                                    <asp:Button runat="server" Text="Add" CssClass="boton" OnClientClick="return validateFormIdentification('frmIdentifications')" ID="btnAddIdentification" OnClick="btnAddIdentification_Click" />
                                </div>
                                <!--boton_wrapper-->
                            </div>
                        </div>
                        <!--grupos-->
                        <div class="grupos de_3 small alingtoend">
                            <div>
                                <label class="label red" runat="server" id="IDNumber">ID Number</label>
                                <asp:TextBox runat="server" ID="txtIDNumber" validation="Required" AllowEnter="true" />
                            </div>

                            <div>
                                <label class="label red" runat="server" id="ExpDate">EXPIRATION DATE</label>
                                <asp:TextBox runat="server" ID="txtExpDate" CssClass="datepicker" validation="Required" ClientIDMode="Static" AllowEnter="true" />
                            </div>

                            <div>
                                <label class="label red" runat="server" id="IssuedBy">Issued by</label>
                                <div class="wrap_select">
                                    <asp:DropDownList runat="server" ID="cbxIssuedBy" validation="Required">
                                    </asp:DropDownList>
                                </div>
                                <!--wrap_select-->
                            </div>
                        </div>
                    </asp:Panel>
                    <!--grupos-->
                    <div class="grid_wrap margin_t_10 gris">
                        <dx:ASPxGridView ID="gvCommonIdentification" runat="server"
                            KeyFieldName="SeqNo"
                            EnableCallBacks="False"
                            AutoGenerateColumns="False"
                            SettingsPager-PageSize="15"
                            Width="100%" OnRowCommand="gvCommonIdentification_RowCommand" OnPageIndexChanged="gvCommonIdentification_PageIndexChanged" OnPreRender="gvCommonIdentification_PreRender">
                            <SettingsPager PageSize="3">
                            </SettingsPager>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="TYPE" FieldName="ContactIdTypeDescription" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ID NUMBER" FieldName="Id" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="EXPIRATION DATE" FieldName="ExpireDate" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ISSUED BY" FieldName="CountryIssuedByDesc" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EDIT" VisibleIndex="6">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Modify"></asp:Button>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="6">
                                    <DataItemTemplate>
                                        <asp:Button ID="btnDelete" runat="server" CssClass="delete_file" CommandName="Delete" OnClientClick="return DlgConfirm(this)"></asp:Button>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                        </dx:ASPxGridView>
                    </div>
                    <!--grid_wrap-->
                </div>
                <!--content_fondo_blanco-->
            </div>
            <!--fondo_blanco-->
        </asp:Panel>
        <!--col-1-3-->
        <asp:HiddenField runat="server" ID="hdnTotalIdentification" Value="" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hdnCurrentSession" Value="" />
        <asp:HiddenField runat="server" ClientIDMode="Static" ID="isBirthCertificate" Value="false" />

    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="gvCommonIdentification" />
        <asp:AsyncPostBackTrigger ControlID="cbxIDType" /> 
    </Triggers>
</asp:UpdatePanel>  
