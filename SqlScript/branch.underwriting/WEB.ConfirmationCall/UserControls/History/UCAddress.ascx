<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAddress.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.History.UCAddress" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="texto medical_icon">
    <div class="grupos de_2">
        <div>
            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AddressType %>:</label>
            <div class="wrap_select">
                <asp:DropDownList ID="DrpAddressType" runat="server" Enabled="False"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div style="display:none;">
            <%--<label class="label">Business Name:</label>--%>
            <asp:Label ID="LblBussineName" runat="server" CssClass="label" Visible="false">
         <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.BusinessName %>

            </asp:Label>
            <asp:TextBox ID="TxtBussineName" class="no_padding_r" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
        </div>
    </div>
    <!--grupos-->
</div>
<!--texto-->

<div class="grupos de_1">
    <div>
        <table>
            <tr>
                <td width="80%">


                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.StreetAddress %>:</label></td>
                <td>
                    <label class="label" style="margin: 0 auto; text-align: right"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %>:</label></td>
                <td style="padding-bottom: 5px;">
                    <asp:CheckBox ID="CkPrimary" runat="server" Enabled="False" /></td>
            </tr>
        </table>
        <asp:TextBox ID="txtStreetAddress" TextMode="multiline" Columns="50" Rows="5" runat="server" ReadOnly="True" />

    </div>
</div>
<!--grupos-->

<div class="grupos de_6 ">
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Country %>:</label>
        <div class="wrap_select">

            <asp:DropDownList ID="DrpCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpCountry_SelectedIndexChanged" Enabled="False">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>

    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.State %>:</label>
        <div class="wrap_select">
            <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpState_SelectedIndexChanged" Enabled="False">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>

    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.City %>:</label>
        <div class="wrap_select">
            <asp:DropDownList ID="DrpCity" runat="server" Enabled="False">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ZipCode %>:</label>
        <asp:TextBox ID="TxtCodePostal" runat="server" ReadOnly="True"></asp:TextBox>
        <!--wrap_select-->
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
                        <dx:ASPxGridView EnablePagingGestures="False" ID="GrdAddresses" runat="server" ClientIDMode="Static"
                            DataSourceID="dsAddresses"
                            optionsloadingpanel-enabled="false"
                            SettingsLoadingPanel-Mode="Disabled"
                            AutoGenerateColumns="False" OnRowCommand="GrdAddresses_RowCommand1" KeyFieldName="CorpId;DirectoryId;DirectoryDetailId;DirectoryTypeId;StreetAddress;CountryId;CityId;StateProvId;ZipCode;IsPrimary;CreateUser"
                            OnPreRender="GrdAddresses_PreRender"
                            OnPageIndexChanged="GrdAddresses_PageIndexChanged"
                            OnBeforeColumnSortingGrouping="GrdAddresses_BeforeColumnSortingGrouping">
                            <Settings ShowHeaderFilterButton="false" />
                            <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataColumn Caption="Address Type" FieldName="DirectoryTypeDesc" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Street Address" FieldName="StreetAddress" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Country" FieldName="CountryDesc" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="City" FieldName="CityDesc" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="State" FieldName="StateProvDesc" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Postal Code" FieldName="ZipCode" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Primary" FieldName="IsPrimary" PropertiesEditType="CheckBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="View" PropertiesEditType="TextBox">
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

                        <asp:ObjectDataSource ID="dsAddresses" runat="server" SelectMethod="GetAddresses"
                            TypeName="WEB.ConfirmationCall.UserControls.History.UCAddress" OnSelecting="dsAddresses_Selecting"></asp:ObjectDataSource>
                    </div>
                    <!--pagination-->
                </td>
            </tr>
        </tfoot>
    </table>

</div>

