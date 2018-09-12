<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCBackgroundInformation.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.WUCBackgroundInformation" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<asp:UpdatePanel runat="server" ID="udpBackgroundInformation" ClientIDMode="Static"  UpdateMode="Conditional">
    <ContentTemplate>
        <div class="col-1-3">
            <asp:Panel runat="server" ID="frmBackGroundInformation" class="fondo_blanco fix_height" ClientIDMode="Static">
                <div class="titulos_azules">
                    <span class="icon_occupation"></span><strong>
                        <asp:Literal runat="server" ID="ltBackInfo">BACKGROUND INFORMATION</asp:Literal></strong>
                </div>
                <div class="content_fondo_blanco">
                    <div class="grupos de_1" runat="server">
                        <div>
                            <fieldset class="margin_t_10" id="frmGrupo1" runat="server" clientidmode="Static">
                                <legend>
                                    <asp:Literal runat="server" ID="ltClientIsa">CLIENT IS A:</asp:Literal></legend>
                                <div class="grupos de_1 checkbox_left" id="dvrepeaterClientIsA">
                                    <asp:Repeater runat="server" ID="repeaterClientIsA" OnItemDataBound="repeaterClientIsA_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <asp:CheckBox runat="server" ID="checkboxQuestion" CssClass="checkInToSpan"/>
                                                <label class="label" runat="server" id="lblQuestion" nameKey='<%# Eval("NameKey") %>'></label>
                                                <div class="campos">
                                                    <label class="label" runat="server" id="Position">Position</label>
                                                    <asp:TextBox runat="server" ID="txtPosition" data-question='<%# Eval("SocialFunctionTypeId")%>'></asp:TextBox>
                                                </div>
                                                <!--campos-->
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--grupos-->
                            </fieldset>
                        </div>

                        <div>
                            <fieldset class="margin_t_10" id="frmGrupo2" runat="server" clientidmode="Static">
                                <legend>
                                    <asp:Literal runat="server" ID="ltHasAcloseRelationship">HAS A CLOSE RELATIONSHIP WITH A:</asp:Literal></legend>
                                <div class="grupos de_1 checkbox_left" id="dvrepeaterHasACloseRelationShipWithA">
                                    <asp:Repeater runat="server" ID="repeaterHasACloseRelationShipWithA" OnItemDataBound="repeaterHasACloseRelationShipWithA_ItemDataBound">
                                        <ItemTemplate>
                                            <div>
                                                <asp:CheckBox runat="server" ID="checkboxQuestion" CssClass="checkInToSpan" onchange="ClearTextBox(this)" />
                                                <label class="label" runat="server" id="lblQuestion" namekey='<%# Eval("NameKey")%>'></label>
                                                <div class="campos">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <label class="label" runat="server" id="Name">Name</label>
                                                                <asp:TextBox runat="server" ID="txtName" data-question='<%#Eval("SocialFunctionTypeId") %>'></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <label class="label" runat="server" id="Position">Position</label>
                                                                <asp:TextBox runat="server" ID="txtPosition"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <!--campos-->
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!--grupos-->
                            </fieldset>
                        </div>
                    </div>
                    <!--grupos--> 
                    <asp:panel runat="server" ID="pnRepeterQuestion">
                        <div class="grupos radios_list margin_t_20" id="divContainerRepeterQuestion">
                            <asp:Repeater runat="server" ID="repeaterQuestion" OnItemDataBound="repeaterQuestion_ItemDataBound">
                                <ItemTemplate> 
                                    <div>
                                        <label runat="server" id="lblQuestion" class="label" data-question='<%#Eval("CitizenQuestId")%>' namekey='<%#Eval("NameKey")%>' style="text-align: justify;"></label>
                                    </div>
                                    <div>
                                        <table class="radio" id='<%#Eval("NameKey")+ "_id"%>'>
                                            <tr>
                                                <td>
                                                    <asp:RadioButton runat="server" ID="rbYes" GroupName="Citizen"  />
                                                    <label id="lblYes" runat="server" namekey='<%#Eval("NameKey")%>' sectionid='<%#Eval("NameKey") + "_section"%>' onclick="MostrarListaPEP(this);"><%# RESOURCE.UnderWriting.NewBussiness.Resources.YesLabel %></label>
                                                </td>
                                                <td>
                                                    <asp:RadioButton runat="server" ID="rbNo" GroupName="Citizen"   />
                                                    <label id="lblNo" runat="server" namekey='<%#Eval("NameKey")%>' sectionid='<%#Eval("NameKey") + "_section"%>' onclick="MostrarListaPEP(this);" ><%# RESOURCE.UnderWriting.NewBussiness.Resources.NoLabel %></label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div> 
                                </ItemTemplate>
                            </asp:Repeater>
                            <br />    
                            <span id="ISPARENTPOLITICAL_section" class="content_fondo_blanco campos">
                                <div class="grupos">
                                    <div class="float_right">
                                        <div class="boton_wrapper amarillo float_right" id="dvAddBtn" runat="server">
                                            <span class="add"></span>
                                            <asp:UpdatePanel ID="udpAdd" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button runat="server" ID="btnAdd" Text="Add" CssClass="boton" AllowEnter="true" OnClientClick="return validateFormCitizenContact(this,'frmBackGroundInformation')" OnClick="btnAdd_Click" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="grupos de_4 small">
                                    <div>
                                        <label class="label red" runat="server" id="lbFullName">Full Name</label>
                                        <asp:TextBox ID="txtFullName" runat="server" AllowEnter="true" ClientIDMode="Static" validation='Required' />
                                    </div>
                                    <div style="width=0;">
                                        <label class="label red" runat="server" id="lbRelationship">Relationship</label>
                                        <div class="wrap_select">
                                            <asp:DropDownList ID="ddlRelationship" runat="server" ClientIDMode="Static" validation='Required'></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="lbPosition">Position</label>
                                        <asp:TextBox ID="txtPosition" runat="server" ClientIDMode="Static" validation='Required' AllowEnter="true" />

                                    </div>
                                    <div>
                                        <label class="label red" runat="server" id="lbFrom">From</label>
                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="datepicker" alt="validateFutureDate" validation="Required" ClientIDMode="Static" AllowEnter="true" />
                                    </div>
                                    <div>
                                        <label class="label" runat="server" id="lbTo">To</label>
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="datepicker" alt="validateFutureDate" ClientIDMode="Static" AllowEnter="true" />
                                    </div>
                                </div>
                                <div class="grid_wrap margin_t_10 gris">
                                    <dx:ASPxGridView ID="gvCitizenContact" runat="server"
                                        KeyFieldName="Exposure_Related_Id"
                                        EnableCallBacks="False"
                                        AutoGenerateColumns="False"
                                        SettingsPager-PageSize="15" OnRowCommand="gvCitizenContact_RowCommand" OnPageIndexChanged="gvCitizenContact_PageIndexChanged" ClientIDMode="Static">
                                        <SettingsPager PageSize="3">
                                        </SettingsPager>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Full Name" FieldName="FullName" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Relationship" FieldName="RelationshipDesc" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Position" FieldName="Position" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="From" FieldName="From" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="To" FieldName="To" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="EDIT" VisibleIndex="6">
                                                <DataItemTemplate>
                                                    <asp:Button runat="server" ID="btnEditar" CommandName="Modify" CssClass="edit_file" />
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="6">
                                                <DataItemTemplate>
                                                    <asp:UpdatePanel ID="udpDelete" runat="server" OnUnload="udpDelete_Unload">
                                                        <ContentTemplate>
                                                            <asp:Button runat="server" ID="btnDelete" CssClass="delete_file" CommandName="Delete" OnClientClick='return DlgConfirm(this)' />
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="btnDelete" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>

                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsBehavior AllowSelectSingleRowOnly="true" AllowSort="False" />
                                    </dx:ASPxGridView>
                                </div>
                            </span>  
                        </div>
                    </asp:panel>
                    <div class="grupos de_1" id="OnlyOwnerInfo" style="display: none">
                        <div>
                            <label runat="server" id="RelationshipWithInsured" class="label">Relationship with insured</label>
                            <div class="wrap_select">
                                <asp:DropDownList runat="server" ID="cbxRelationshipwithinsured">
                                </asp:DropDownList>
                            </div>
                            <!--wrap_select-->
                        </div>
                    </div>
                    <!--grupos-->
                </div>
                <!--content_fondo_blanco-->
            </asp:Panel>
            <!--fondo_blanco-->
        </div>
        <asp:HiddenField ID="hdnCurrentSession" runat="server" Value="" />
        <asp:HiddenField ID="hdnSelectectionrepeaterQuestion" runat="server" Value="" ClientIDMode="Static" />
        <!--col-1-3-->
    </ContentTemplate>
</asp:UpdatePanel>
