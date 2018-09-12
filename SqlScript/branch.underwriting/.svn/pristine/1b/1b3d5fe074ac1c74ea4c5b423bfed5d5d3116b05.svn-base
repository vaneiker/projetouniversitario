<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBailDetail.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.IllustrationAlliedLines.UCBailDetail" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style>
    .AtributoAdicional {
        margin-top: -60px !important;
    }
</style>

<div id="dvBailDetailForm" style="padding: 10px">
    <div class="">
        <fieldset>
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.BailDetail %></legend>
            <div class="bloqTransportDetail addDobleDynamic">
                <div class="row_B">
                    <asp:Panel ID="Panel_txt_producto" runat="server" class="label_plus_input par col-4">
                        <span>Producto</span>
                        <asp:TextBox runat="server" ID="txt_producto" ReadOnly="true"></asp:TextBox>
                    </asp:Panel>
                    <asp:Repeater runat="server" ID="rpCondiciones" OnItemDataBound="rpCondiciones_ItemDataBound">
                        <ItemTemplate>
                            <div class="label_plus_input par col-4">
                                <span><%# Eval("descripcion") %></span>
                                <asp:TextBox runat="server" ID="txtCondicion" Text='<%# Eval("valor") %>' ReadOnly="true"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>

            <asp:HiddenField ID="hdnProductName" runat="server" />
            <asp:HiddenField ID="hdnDomecticRegId" runat="server" />
        </fieldset>
        <fieldset style="height: 300px;" runat="server" id="fieldSetFeatures" visible="false">
            <legend><%=RESOURCE.UnderWriting.NewBussiness.Resources.BailFeatures %></legend>
            <asp:Panel runat="server" ID="dvPropertyFeature" ClientIDMode="Static">
                <asp:ImageButton runat="server" ID="btnAdd" ImageUrl="~/Content/images/add_icon.png" OnClick="btnAdd_Click" />
                <asp:UpdatePanel runat="server" ID="udpGridView">
                    <ContentTemplate>
                        <dx:ASPxGridView
                            ID="gvBailExtraInfo"
                            runat="server"
                            EnableCallBacks="False"
                            KeyFieldName="UniqueBailId;SeqId;BaileeStatusId;CountryIdDomesticregId;StateProvId;CityId;NationalityCountryId;IdentificationTypeDesc;Identification;TipoRiesgoNameKey;FinancialClearance;MunicipioId"
                            ClientIDMode="Static"
                            AutoGenerateColumns="false"
                            Width="100%"
                            OnRowCommand="gvBailExtraInfo_RowCommand"
                            OnPreRender="gvBailExtraInfo_PreRender"
                            OnPageIndexChanged="gvBailExtraInfo_PageIndexChanged">
                            <Columns>
                                <dx:GridViewDataColumn Caption="" CellStyle-HorizontalAlign="Center" Name="Operation">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="grupos de_2" style="text-align: center">
                                                    <asp:Panel runat="server" ID="pnDelete">
                                                        <asp:LinkButton runat="server" ID="btnDelete" CssClass="delete_file" CommandName="DeleteFeature" OnClientClick="return DlgConfirm(this);" />
                                                    </asp:Panel>
                                                    <div>
                                                        <asp:LinkButton runat="server" ID="btnEditOrSave" CssClass="myedit_file" CommandName="EditFeature" OnClientClick="return validateForm('dvPropertyFeature');" />
                                                    </div>
                                                    <div>
                                                        <asp:LinkButton runat="server" ID="btnCancel" Visible="false" CssClass="mycancel_file" CommandName="Cancel" />
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnEditOrSave" />
                                                <asp:AsyncPostBackTrigger ControlID="btnCancel" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="GridCompliColumTypeIdentifi" Settings-AllowSort="true" Name="GridCompliColumTypeIdentifi" HeaderStyle-CssClass="lh16" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>                                         
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlIdentificationTypeId" runat="server" Visible="false" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlIdentificationTypeId_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Literal runat="server" ID="ltIdentificationTypeId" Text='<%#Eval("IdentificationTypeDesc")%>' />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlIdentificationTypeId" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Identification" Settings-AllowSort="true" Name="Identification" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtIdentification" Text='<%#Eval("Identification")%>' label="Identification" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltIdentification" Text='<%#Eval("Identification")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Name" Settings-AllowSort="true" Name="Name" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtName" Text='<%#Eval("Name")%>' label="Name" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltName" Text='<%#Eval("Name")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="LastName" Settings-AllowSort="true" Name="LastName" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtLastName" Text='<%#Eval("LastName")%>' label="LastName" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltLastName" Text='<%#Eval("LastName")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Email" Settings-AllowSort="true" Name="Email" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtEmail" Text='<%#Eval("Email")%>' label="Email" inputtype="Email" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltEmail" Text='<%#Eval("Email")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="PhoneNumberLabel" Settings-AllowSort="true" Name="PhoneNumberLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtPhone" Text='<%#Eval("Phone")%>' label="PhoneNumberLabel" data-inputmask="'mask': '(999)999-9999'" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltPhone" Text='<%#Eval("Phone")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                 <dx:GridViewDataColumn Caption="StreetAddress" Settings-AllowSort="true" Name="StreetAddress" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtAddress" Text='<%#Eval("Address")%>' label="StreetAddress" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltAddress" Text='<%#Eval("Address")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>


                                <dx:GridViewDataColumn Caption="Country" Settings-AllowSort="true" Name="Country" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlCountryId" runat="server" Visible="false" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryIdSelectedIndexChanged"></asp:DropDownList>
                                                <asp:Literal runat="server" ID="ltCountryId" Text='<%#Eval("CountryDesc")%>' />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlCountryId" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="StateProvinceLabel" Settings-AllowSort="true" Name="StateProvinceLabel" CellStyle-HorizontalAlign="Center" Width="150px">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlStateProvId" runat="server" Visible="false" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlStateProvId_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Literal runat="server" ID="ltStateProvId" Text='<%#Eval("CityDesc")%>' />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlStateProvId" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="municipality" Settings-AllowSort="true" Name="municipality" CellStyle-HorizontalAlign="Center" Width="150px">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlMunicipality" Visible="false" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlMunicipality_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Literal runat="server" ID="ltMunicipaly" Text='<%#Eval("MunicipioDesc")%>' />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlMunicipality" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="City" Settings-AllowSort="true" Name="City" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:DropDownList ID="ddlCityId" runat="server" Visible="false" validation="Required"></asp:DropDownList>
                                        <asp:Literal runat="server" ID="ltCityId" Text='<%#Eval("Sector")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                               

                                <dx:GridViewDataColumn Caption="NationalityCountryLabel" Settings-AllowSort="true" Name="NationalityCountryLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:DropDownList ID="ddlNationalityCountryId" runat="server" Visible="false" validation="Required"></asp:DropDownList>
                                        <asp:Literal runat="server" ID="ltNationalityCountryId" Text='<%#Eval("NationalityCountryDesc")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="RepresentativeNameLabel" Settings-AllowSort="true" Name="RepresentativeNameLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtRepresentativeName" Text='<%#Eval("RepresentativeName")%>' label="RepresentativeNameLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltRepresentativeName" Text='<%#Eval("RepresentativeName")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="RepresentativeIdentificationTypeLabel" Settings-AllowSort="true" Name="RepresentativeIdentificationTypeLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlRepresentativeIdentificationTypeId" runat="server" Visible="false" validation="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlRepresentativeIdentificationTypeId_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Literal runat="server" ID="ltRepresentativeIdentificationTypeId" Text='<%#Eval("RepresentativeIdentificationTypeDesc")%>' />
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddlRepresentativeIdentificationTypeId" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="RepresentativeIdentificationLabel" Settings-AllowSort="true" Name="RepresentativeIdentificationLabel" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:TextBox runat="server" ID="txtRepresentativeIdentification" Text='<%#Eval("RepresentativeIdentification")%>' label="RepresentativeIdentificationLabel" validation="Required" Visible="false" />
                                        <asp:Literal runat="server" ID="ltRepresentativeIdentification" Text='<%#Eval("RepresentativeIdentification")%>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Name="FinancialClearance" Caption="" CellStyle-HorizontalAlign="Center" Width="50px" PropertiesEditType="TextBox">
                                    <DataItemTemplate>
                                        <asp:Image runat="server" ID="imgRiesgo" Style="width: 22px; height: 22px;" />
                                    </DataItemTemplate>
                                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="" Name="InfCredit" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>
                                        <asp:Button runat="server" Enabled='<%#Eval("isEnableTU")%>' CssClass='<%#Eval("ClassNameTU")%>' ID="btnInfCredit" CommandName="InfCredit" title="Ver información crediticia"></asp:Button>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsPager PageSize="8" AlwaysShowPager="true">
                                <PageSizeItemSettings Visible="false" ShowAllItem="true" />
                            </SettingsPager>
                            <SettingsBehavior AllowSelectSingleRowOnly="false" AllowSort="False" AllowFocusedRow="false" />
                            <Settings ShowFooter="True" />
                        </dx:ASPxGridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvBailExtraInfo" />
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                    </Triggers>
                </asp:UpdatePanel>
            </asp:Panel>
        </fieldset>
    </div>
    <div style="height: 42px;"></div>    
    <div style="float: right;">
        <asp:Panel runat="server" ID="pnGuardar" Visible="false" class="fl" Style="margin-left: 10px;">
            <asp:LinkButton runat="server" CssClass="button button-green alignC embossed" ID="btnGuardar" OnClick="btnGuardar_Click" OnClientClick="return validateForm('dvBailDetailForm');">
                        <span><%= RESOURCE.UnderWriting.NewBussiness.Resources.Save %></span>
            </asp:LinkButton>
        </asp:Panel>
        <div class="fl" style="position: absolute; right: 10px; bottom: 10px;">
            <input type="button" id="CloseBailModal" class="button button-red alignC embossed AtributoAdicional" value="<%= RESOURCE.UnderWriting.NewBussiness.Resources.Cancel %>" onclick="ClosePopBailDetail()" />
        </div>
    </div>

    <asp:HiddenField ID="hdnUniqueBailID" runat="server" />

    <asp:ModalPopupExtender ID="mpeTransunion" PopupControlID="pnTransunion" DropShadow="false" BackgroundCssClass="ModalBackgroud3" TargetControlID="hdnPopTransunion" BehaviorID="popupBhvrTransunion" runat="server"></asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnTransunion" CssClass="modalPopup" ClientIDMode="Static" Style="display: none">
        <div class="pop_up_wrapper" style="width: 1034px; height: 960px; overflow-x: hidden; overflow-y: hidden">
            <!--escriben por style el ancho que desean-->
            <div class="titulos_azules head_contengridproxi PreviewPDF" style="width: 100%;">
                <ul>
                    <li style="position: absolute; left: 41%; top: 31%;">
                        <asp:Label ID="lblTitle" ClientIDMode="Static" runat="server"></asp:Label>
                    </li>
                    <li style="top: 13%;">
                        <input type="button" id="close_pop_up" class="cls_pup" onclick="ClosePopTransunion();" style="background-color: transparent; border: none;" />
                    </li>
                </ul>
            </div>
            <!--titulos_azules-->
            <iframe runat="server" id="ifrmTransunion" clientidmode="Static" style="height: 920px; padding: 0;"></iframe>
            <!--content_fondo_blanco-->
        </div>
    </asp:Panel>
    <asp:HiddenField runat="server" Value="false" ID="hdnPopTransunion" ClientIDMode="Static" />
</div>
