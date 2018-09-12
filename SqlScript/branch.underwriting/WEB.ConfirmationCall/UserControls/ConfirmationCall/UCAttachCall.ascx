<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAttachCall.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAttachCall" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Import Namespace="RESOURCE.UnderWriting.ConfirmationCall" %>

<asp:UpdatePanel ID="upAttachCall" runat="server">
    <ContentTemplate>
        <div class="attach_call">
            <div class="cont wd100">
                <div class="tbl radio data_G">
                    <div class="">
                        <table cellspacing="0" rules="all" border="1" id="tblAttachCalls" style="border-collapse: collapse;">
                        </table>
                    </div>
                    <div style="overflow-y: auto; height: 550px;">
                        <dx:ASPxGridView EnablePagingGestures="False" ID="gvAttachCalls" runat="server" ClientIDMode="Static"
                            DataSourceID="dsCalls"
                            optionsloadingpanel-enabled="false"
                            SettingsLoadingPanel-Mode="Disabled"
                            AutoGenerateColumns="False" KeyFieldName="UserName; StartTime; EndTime; Duration; IncomingNumber; CallerIDName; CallerIdNumber; OutgoingNumber; RecordingFile; CallLogId"
                            OnPreRender="gvAttachCalls_PreRender"
                            OnPageIndexChanged="gvAttachCalls_PageIndexChanged"
                            OnBeforeColumnSortingGrouping="gvAttachCalls_BeforeColumnSortingGrouping"
                            OnHtmlRowPrepared="gvAttachCalls_HtmlRowPrepared" class="datagrid">
                            <Settings ShowHeaderFilterButton="false" />
                            <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataColumn Caption="User" FieldName="UserName" PropertiesEditType="TextBox">
                                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Call Start At" FieldName="StartTime" PropertiesEditType="TextBox">
                                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Call End At" FieldName="EndTime" PropertiesEditType="TextBox">
                                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Duration" FieldName="Duration" PropertiesEditType="TextBox">
                                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Outgoing Number" FieldName="OutgoingNumber" PropertiesEditType="TextBox">
                                    <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="PlayRecording" PropertiesEditType="TextBox">
                                    <DataItemTemplate>
                                        <%# Eval("RecordingFileClean")%>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" />
                            <SettingsPager AlwaysShowPager="true" PageSize="10" NumericButtonCount="4" />
                            <Settings ShowFilterRow="true" ShowFilterBar="Auto" />
                            <SettingsLoadingPanel Mode="Disabled" />
                            <SettingsPopup>
                                <HeaderFilter Height="200" />
                            </SettingsPopup>
                        </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="dsCalls" runat="server" SelectMethod="GetCalls"
                            TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAttachCall" OnSelecting="dsCalls_Selecting"></asp:ObjectDataSource>
                    </div>
                </div>

                <!-- Botones -->
                <div class="wd100 fl hg35 mb20" >
                    <div class="boton_wrapper rojo">
                        <span class="equis"></span>                        
                        <asp:Button ID="btnACCancel" runat="server" CssClass="boton" Text="Cancel" OnClick="btnACCancel_Click" OnClientClick="CloseUCAttachCall()" />                        
                    </div>
                    <div class="boton_wrapper azul">
                        <span class="attach"></span>
                        <asp:Button ID="btnACAttach" runat="server" CssClass="boton" Text="Attach" OnClick="btnACAttach_Click" OnClientClick="CloseUCAttachCall()" />
                    </div>
                </div>
                <!--// Botones -->
            </div>
            <!--// cont -->
        </div>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnACAttach" />
    </Triggers>
</asp:UpdatePanel>
