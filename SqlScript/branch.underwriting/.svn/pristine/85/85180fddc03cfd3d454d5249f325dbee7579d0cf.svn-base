<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCEmailAndPhones.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.History.UCEmailAndPhones" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!--Comienza el Grid de Email Email-->
<div class="fondo_blanco fix_height">
    <div class="content_fondo_blanco fix_height">

        <div class="texto medical_icon">
            <ul>
                <li>
                    
                    <strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.DeseamosVerificarSuInformacionDeContacto %></strong><br />
                    <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.EnEstosMomentos %>
                    
                </li>
            </ul>
        </div>
        <!--texto-->


        <div class="titulos_no_color"><span class="email"></span><strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.EmailAddress.ToUpper() %></strong></div>
        <div class="content_fondo_blanco">
            <div class="grupos">
                <div style="width:20%">
                    
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.EmailType%></label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="DrpEmailType" runat="server"  Enabled="False"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div style="width:30%">
                    
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.EmailAddress%></label>
                    <asp:TextBox ID="TxtEmailAaddress" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div>
                    <label class="label" style="margin: 0 auto; text-align: center"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary%></label>
                    <asp:CheckBox ID="CkPrimaryEmail" runat="server" Enabled="False" />
                </div>
            </div>
            <!--grupos-->


            <div class="grid_wrap margin_t_10">

                <dx:ASPxGridView EnablePagingGestures="False" ID="GrdEmailAddresses" runat="server" ClientIDMode="Static"
                    DataSourceID="dsEmailAddresses"
                    optionsloadingpanel-enabled="false"
                    SettingsLoadingPanel-Mode="Disabled"
                    AutoGenerateColumns="False" OnRowCommand="GrdEmailAddresses_RowCommand1" KeyFieldName="CorpId;DirectoryId;DirectoryDetailId;EmailAdress;IsPrimary;DirectoryTypeDesc;CreateUser"
                    OnPreRender="GrdEmailAddresses_PreRender"
                    OnPageIndexChanged="GrdEmailAddresses_PageIndexChanged"
                    OnBeforeColumnSortingGrouping="GrdEmailAddresses_BeforeColumnSortingGrouping">
                    <Settings ShowHeaderFilterButton="false" />
                    <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                    <Columns>
                        <dx:GridViewDataColumn Caption="Email Type" FieldName="DirectoryTypeDesc">
                            <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Email Address" FieldName="EmailAdress">
                            <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Primary" FieldName="IsPrimary">
                            <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="View">
                            <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                            <DataItemTemplate>
                                <label class="label">
                                    <asp:Button ID="BtnEditEmail" class="view_verde" runat="server" HeaderStyle-Width="10%" CommandName="Edit" />
                                </label>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager AlwaysShowPager="true" PageSize="4" NumericButtonCount="3" />
                    <SettingsLoadingPanel Mode="Disabled" />
                    <SettingsPopup>
                        <HeaderFilter Height="200" />
                    </SettingsPopup>
                </dx:ASPxGridView>

                <asp:ObjectDataSource ID="dsEmailAddresses" runat="server" SelectMethod="GetEmailAddresses"
                    TypeName="WEB.ConfirmationCall.UserControls.History.UCEmailAndPhones" OnSelecting="dsEmailAddresses_Selecting"></asp:ObjectDataSource>
            </div>
            <!--grid_wrap-->
        </div>
        <!--content_fondo_blanco-->

        <!--Hasta aqui llega Email-->

        <div class="texto">
            <ul>
                <li>
                    
                    <strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ComoNumerosTelefonicos %></strong>
                </li>
            </ul>
        </div>
        <!--texto-->

        <div class="titulos_no_color"><span class="phone"></span><strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PhoneNumbers.ToUpper() %></strong></div>
        <div class="content_fondo_blanco">

            <div class="grupos">
                <div style="width: 50%">
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PhoneType %></label><div class="wrap_select">
                        <asp:DropDownList ID="DrpPhoneType" runat="server" Enabled="False"></asp:DropDownList>
                    </div>
                    <!--wrap_select-->
                </div>
                <div>
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %></label>
                    <asp:CheckBox ID="CkPrimaryPhone" runat="server" Enabled="False"/>
                </div>
            </div>
            <!--grupos-->

            <div class="grupos de_4 small">
                <div>
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.CountryCode %></label>
                    <asp:TextBox ID="TxtCountry" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div>
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.CityCode %></label>
                    <asp:TextBox ID="TxtCity" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div>
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PhoneNumber %></label>
                    <asp:TextBox ID="TxtPhoneNumber" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
                <div>
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Extension %></label>
                    <asp:TextBox ID="TxtExtension" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <!--grupos-->

            <div class="grid_wrap margin_t_10">
                <table>
                    <thead class="headgrid">
                    </thead>
                    <tbody class="datagrid">
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                                <div class="pagination">
                                    <dx:ASPxGridView EnablePagingGestures="False" ID="GrdPhones" runat="server" ClientIDMode="Static"
                                        DataSourceID="dsPhones"
                                        optionsloadingpanel-enabled="false"
                                        SettingsLoadingPanel-Mode="Disabled"
                                        AutoGenerateColumns="False" OnRowCommand="GrdPhones_RowCommand1" KeyFieldName="CorpId;DirectoryId;DirectoryDetailId;CountryCode;AreaCode;PhoneNumber;PhoneExt;IsPrimary;CreateUser;DirectoryTypeDesc"
                                        OnPreRender="GrdPhones_PreRender"
                                        OnPageIndexChanged="GrdPhones_PageIndexChanged"
                                        OnBeforeColumnSortingGrouping="GrdPhones_BeforeColumnSortingGrouping">
                                        <Settings ShowHeaderFilterButton="false" />
                                        <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                                        <Columns>
                                            <dx:GridViewDataColumn Caption="Phone Type" FieldName="DirectoryTypeDesc">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Country Code" FieldName="CountryCode">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="AreaCode" FieldName="AreaCode">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="PhoneNumber" FieldName="PhoneNumber">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="PhoneExt" FieldName="PhoneExt">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Primary" FieldName="IsPrimary">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                            </dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="View">
                                                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                                <DataItemTemplate>
                                                    <label class="label">
                                                        <asp:Button ID="BtnEdit0" class="view_verde" runat="server" CommandName="Edit" HeaderStyle-Width="10%" />
                                                    </label>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsPager AlwaysShowPager="true" PageSize="4" NumericButtonCount="3" />
                                        <SettingsLoadingPanel Mode="Disabled" />
                                        <SettingsPopup>
                                            <HeaderFilter Height="200" />
                                        </SettingsPopup>
                                    </dx:ASPxGridView>
                                    <asp:ObjectDataSource ID="dsPhones" runat="server" SelectMethod="GetPhones"
                                        TypeName="WEB.ConfirmationCall.UserControls.History.UCEmailAndPhones" OnSelecting="dsPhones_Selecting"></asp:ObjectDataSource>

                                </div>
                                <!--pagination-->
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </div>
            <!--grid_wrap-->
        </div>
        <!--content_fondo_blanco-->
    </div>
</div>
