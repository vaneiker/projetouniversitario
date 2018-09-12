<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCContactList.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.ContactInformation.WUCContactList" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<div class="barra1 overflow_hidden">
    <div class="boton_wrapper amarillo margin_0 float_right">
        <span class="add"></span>
        <asp:Button runat="server" CssClass="boton" ID="btnAddNewContact" Text="Add New Contact" OnClick="btnAddNewContact_Click" />
    </div>
    <!--boton_wrapper-->
</div>
<div class="grid_wrap">
    <!--barra1-->
    <dx:ASPxGridView ID="gvContactList"
        DataSourceID="LinqDS" runat="server"
        KeyFieldName="ContactId;FirstName;LastName"
        EnableCallBacks="false"
        AutoGenerateColumns="False"        
        OnRowCommand="gvContactList_RowCommand" OnAfterPerformCallback="gvContactList_AfterPerformCallback" OnPreRender="gvContactList_PreRender" Width="100%">
        <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />     
        <Columns>
            <dx:GridViewDataTextColumn Caption="FIRST NAME" FieldName="FirstName" VisibleIndex="0" Name="FirstNameLabel">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="LAST NAME" FieldName="LastName" VisibleIndex="1" Name="LastNameLabel">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ID NUMBER" FieldName="IdNumber" VisibleIndex="2" Name="IDNumberLabel">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DateOfBirth" Caption="DATE OF BIRTH" CellStyle-HorizontalAlign="Center" Name="DateofBirthLabel" >
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn Caption="COUNTRY OF RESIDENCE" FieldName="Country" VisibleIndex="4" Name="CountryOfResidenceLabel">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="LastUpdate" Caption="LAST UPDATE" CellStyle-HorizontalAlign="Center" Name="LastUpdateLabel">
                <PropertiesDateEdit DisplayFormatString="MM/dd/yyyy"></PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataColumn Caption="EDIT" VisibleIndex="13" Name="Edit" Width="4%">
                <DataItemTemplate>
                    <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandName="Modify"></asp:Button>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
        <Settings ShowGroupPanel="True" />
        <SettingsBehavior ColumnResizeMode="NextColumn" />
        <Settings VerticalScrollableHeight="500" VerticalScrollBarMode="Visible" />
        <SettingsPager PageSize="20" AlwaysShowPager="true">
            <PageSizeItemSettings Visible="true" ShowAllItem="true" />
        </SettingsPager>
        <SettingsPopup>
            <HeaderFilter Height="200" />
        </SettingsPopup>
        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
    </dx:ASPxGridView>
    <dx:LinqServerModeDataSource OnSelecting="LinqDS_Selecting" ID="LinqDS" runat="server" DefaultSorting="FirstName" /> 
</div>
