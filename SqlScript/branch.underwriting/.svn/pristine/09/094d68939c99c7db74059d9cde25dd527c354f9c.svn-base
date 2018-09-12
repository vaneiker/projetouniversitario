<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCPopMergeCases.ascx.cs" Inherits="WEB.NewBusiness.DReview.UserControl.DReview.WUCPopMergeCases" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<div class="pop_up_wrapper" style="width: 1400px; height: 632px;">
    <!--escriben por style el ancho que desean-->
    <div class="titulos_azules">
        <input type="button" class="close_pop_up" onclick="HidePopup()">
        <strong runat="server" id="ExportingSelectedRecords">EXPORTING SELECTED RECORDS FROM SUBMITTED CASES (MERGE CASES)</strong>
    </div>
    <!--titulos_azules-->
    <div class="content_fondo_blanco">
        <div class="titulos_sin_accion02" runat="server" id="NewCaseInformation">
            NEW CASE INFORMATION
        </div>
        <div class="grid_wrap">
            <dx:ASPxGridView ID="gridMaster" ClientIDMode="Static" DataSourceID="MasterDataSource"
                runat="server" Width="100%" AutoGenerateColumns="False" KeyFieldName="ContactId" SettingsLoadingPanel-Mode="Disabled" OnPreRender="gridMaster_PreRender">
                <ClientSideEvents BeginCallback="function(){BeginRequestHandler();}" EndCallback="function(){pageLoad(); EndRequestHandler(); }" />
                <Columns>
                    <dx:GridViewDataColumn FieldName="Roles" Caption="ROLE" Name="Role" />
                    <dx:GridViewDataColumn FieldName="FirstName" Caption="NAME" Name="NameLabel" />
                    <dx:GridViewDataColumn FieldName="MiddleName" Caption="MIDDLE NAME" Name="MiddleNameLabel" />
                    <dx:GridViewDataColumn FieldName="FirstLastName" Caption="LAST NAME" Name="LastNameLabel" />
                    <dx:GridViewDataColumn FieldName="SecondLastName" Caption="SECOND LAST NAME" Name="SecondLastNameLabel" />
                    <dx:GridViewDataColumn Caption="ID NUMBER" Name="IDNumberLabel">
                        <DataItemTemplate>
                            <div>
                                <ul>
                                    <%# Eval("ids") %>
                                </ul>
                            </div>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataDateColumn FieldName="Dob" Caption="DATE OF BIRTH" Name="DateofBirthLabel" />
                    <dx:GridViewDataColumn FieldName="CountryDesc" Caption="COUNTRY" Name="CountryLabel" />
                    <dx:GridViewDataCheckColumn Caption="NEW CLIENT" Width="5%" Name="NEWCLIENT">
                        <DataItemTemplate>
                            <asp:CheckBox runat="server" ID="chkNewClient" CssClass="CheckMasterGrid" data='<%# Eval("ContactId") %>' />
                        </DataItemTemplate>
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn Caption="SAME AS SELECTED" Width="10%" Name="SAMEASSELECTED">
                        <DataItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSameAsSelected" CssClass="CheckMasterGrid" data='<%# Eval("ContactId") %>' />
                        </DataItemTemplate>
                    </dx:GridViewDataCheckColumn>
                </Columns>
                <SettingsPager PageSize="60" NumericButtonCount="3" AlwaysShowPager="true">
                    <PageSizeItemSettings Visible="true" ShowAllItem="true" />
                </SettingsPager>
                <SettingsBehavior ColumnResizeMode="NextColumn" />
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="detailGrid" runat="server" SettingsPager-Visible="false" KeyFieldName="ContactId" DataSourceID="DetailDataSource"
                            Width="100%" OnBeforePerformDataSelect="detailGrid_DataSelect" SettingsLoadingPanel-Mode="Disabled" OnPreRender="detailGrid_PreRender">
                            <ClientSideEvents BeginCallback="function(){BeginRequestHandler();}" EndCallback="function(){EndRequestHandler();pageLoad(); }" />
                            <Settings ShowFilterRow="true" ShowFilterBar="Auto" ShowHeaderFilterButton="true" ShowFilterRowMenu="true" ShowFilterRowMenuLikeItem="false" />
                            <Columns>
                                <dx:GridViewDataColumn FieldName="FirstName" Caption="NAME" Name="NameLabel" />
                                <dx:GridViewDataColumn FieldName="MiddleName" Caption="MIDDLE NAME" Name="MiddleNameLabel" />
                                <dx:GridViewDataColumn FieldName="FirstLastName" Caption="LAST NAME" Name="FirstNameLabel" />
                                <dx:GridViewDataColumn FieldName="SecondLastName" Caption="SECOND LAST NAME" Name="SecondLastNameLabel" />
                                <dx:GridViewDataColumn Caption="ID NUMBER" Name="IDNumberLabel">
                                    <DataItemTemplate>
                                        <div>
                                            <ul>
                                                <%# Eval("ids") %>
                                            </ul>
                                        </div>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataDateColumn FieldName="Dob" Caption="DATE OF BIRTH" Name="DateofBirthLabel" />
                                <dx:GridViewDataColumn FieldName="CountryDesc" Caption="COUNTRY" Name="CountryLabel" />
                                <dx:GridViewDataCheckColumn Caption="SELECT" Name="Select">
                                    <DataItemTemplate>
                                        <asp:CheckBox runat="server" ID="chkSelect" CssClass="detailcheckGrid" data='<%# Eval("ContactId") %>' />
                                    </DataItemTemplate>
                                </dx:GridViewDataCheckColumn>
                            </Columns>
                            <Settings VerticalScrollableHeight="150" VerticalScrollBarMode="Visible" />
                            <SettingsBehavior ColumnResizeMode="NextColumn" AllowSelectSingleRowOnly="true" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <SettingsDetail ShowDetailRow="true" AllowOnlyOneMasterRowExpanded="false" />
                <Settings VerticalScrollableHeight="400" VerticalScrollBarStyle="Virtual" />
            </dx:ASPxGridView>

            <asp:ObjectDataSource ID="MasterDataSource" runat="server" SelectMethod="GetDataMaster"
                TypeName="WEB.NewBusiness.DReview.UserControl.DReview.WUCPopMergeCases" OnSelecting="MasterDataSource_Selecting"></asp:ObjectDataSource>

            <asp:ObjectDataSource ID="DetailDataSource" runat="server" SelectMethod="getDataDetailSession"
                TypeName="WEB.NewBusiness.DReview.UserControl.DReview.WUCPopMergeCases" OnSelecting="DetailDataSource_Selecting"></asp:ObjectDataSource>
        </div>
        <!--grid_wrap-->
        <div class="grupos">
            <div class="float_right">
                <div class="boton_wrapper verde">
                    <span class="save"></span>
                    <asp:Button runat="server" ID="btnSave" CssClass="boton" OnClientClick="return validateSubmitToUnderWriting(this);" Text="Export" OnClick="btnSave_Click" />
                </div>

                <div class="boton_wrapper rojo">
                    <span class="equis"></span>
                    <input class="boton" type="button" runat="server" id="btnClose" value="Close" onclick="HidePopup()">
                </div>
            </div>
        </div>
        <!--grupos-->
    </div>
    <!--content_fondo_blanco-->
</div>

<asp:HiddenField runat="server" Value="" ID="CheckIds" ClientIDMode="Static" />
<asp:HiddenField runat="server" Value="" ID="DetailGridDisabled" ClientIDMode="Static" />
<asp:HiddenField runat="server" Value="" ID="hdnSelectedContact" ClientIDMode="Static" />
<asp:HiddenField runat="server" Value="" ID="hdnPosScrollMasterGrid" ClientIDMode="Static" />
