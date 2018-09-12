<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAddress.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAddress" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="texto medical_icon">
    <div class="grupos de_2">
        <div>
            <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AddressType %>:</label>
            <div class="wrap_select">
                <asp:DropDownList ID="DrpAddressType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpAddressType_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div style="display:none;">
            <%--<label class="label">Business Name:</label>--%>
            <asp:Label ID="LblBussineName" runat="server" CssClass="label" Visible="False">
                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.BusinessName %>
            </asp:Label>
            <asp:TextBox ID="TxtBussineName" class="no_padding_r" runat="server" Visible="False"></asp:TextBox>
        </div>
    </div>
    <!--grupos-->
</div>
<!--texto-->

<div class="grupos de_1">
    <div>
        <table>
            <tr>
                <td style="width: 80%">
                    <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.StreetAddress %>:</label></td>
                <td>
                    <label class="label" style="margin: 0 auto; text-align: right"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %>:</label></td>
                <td style="padding-bottom: 5px;">
                    <asp:CheckBox ID="CkPrimary" runat="server" /></td>
            </tr>
        </table>
        <asp:TextBox ID="txtStreetAddress" TextMode="multiline" Columns="50" Rows="5" MaxLength="50" runat="server" />

    </div>
</div>
<!--grupos-->

<div class="grupos de_6 ">
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Country %>:</label>
        <div class="wrap_select">

            <asp:DropDownList ID="DrpCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpCountry_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>

    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.State %>:</label>
        <div class="wrap_select">
            <asp:DropDownList ID="DrpState" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrpState_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>

    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.City %>:</label>
        <div class="wrap_select">
            <asp:DropDownList ID="DrpCity" runat="server">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ZipCode %>:</label>
        <asp:TextBox ID="TxtCodePostal" runat="server"></asp:TextBox>
        <!--wrap_select-->
    </div>
    <div>
        <div style="text-align: right">
            <div class="float_right">
                <div class="boton_wrapper gris float_right">
                    <span class="borrar"></span>
                    <asp:Button ID="BtnCancelAddress" class="boton" runat="server" Text="" OnClick="BtnCancelAddress_Click" />
                </div>
            </div>
        </div>
    </div>
    <div>
        <div style="text-align: right">
            <div class="float_right">
                <div id="BtnAddAddressDiv" class="boton_wrapper amarillo float_right" runat="server">
                    <span id="BtnAddAddressSpan" class="add" runat="server"></span>
                    <asp:Button ID="BtnAddAddress" class="boton" runat="server" Text="" OnClick="BtnAdd_Click" />
                </div>
                <!--boton_wrapper-->
            </div>
        </div>
    </div>
</div>

<div id="ConfirmAddGuatemala" style="display: none" class="grupos de_11 ">
    <div>
        <asp:CheckBox ID="chkConfirmAddGuatemala" runat="server" />

    </div>

    <label class="label" style="margin-top: 20px; color: red;"><%=RESOURCE.UnderWriting.ConfirmationCall.Resources.MsgGuatemala %></label>



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
                                <dx:GridViewDataColumn Caption="Street Address" Width="30px" FieldName="StreetAddress">
                                    <DataItemTemplate>
                                        <div>
                                            <%# Container.Text %>
                                        </div>
                                    </DataItemTemplate>
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
                                <dx:GridViewDataColumn Caption="Edit" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    <DataItemTemplate>
                                        <label class="label">
                                            <asp:Button ID="BtnEdit0" class="edit_file" runat="server" CommandName="Edit" HeaderStyle-Width="10%" />
                                        </label>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Delete" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    <DataItemTemplate>
                                        <label class="label">
                                            <asp:Button ID="BtnDelete0" runat="server" class="delete_file" OnClientClick="return fnConfirmacion();" CommandName="Delete" HeaderStyle-Width="10%" />
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
                            TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAddress" OnSelecting="dsAddresses_Selecting"></asp:ObjectDataSource>
                    </div>
                    <!--pagination-->
                </td>
            </tr>
        </tfoot>
    </table>

</div>



<%--   <div id="dvPopUpGuatemalaConfirmation" style="display: none;">
        
           <div class="grupos de_2">

             <div>
              <label class="label">Remember to confirm with your client where do they want the policy to be sent</label>
              <asp:CheckBox ID="ChkConfirmAddresGuatemala" runat="server" />
                 
            </div>
           </div>
            
            <div class="wd100 fl hg35">
                    <div class="boton_wrapper rojo">
                        <span class="equis"></span>
                        <input type="submit"  value="Cancel" id="btnCancelConfirmAddGuatemala" class="boton">
                    </div>
                    <div class="boton_wrapper azul">
                        <span class="next_icon2"></span>
                             <input type="submit"  value="Ok" id="btnOkConfirmAddGuatemala" class="boton">
                    </div>
                </div>





            </div>--%>