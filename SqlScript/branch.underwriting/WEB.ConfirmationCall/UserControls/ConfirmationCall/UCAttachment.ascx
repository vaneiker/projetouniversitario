<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAttachment.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAttachment" %>
<%@ Register Src="~/UserControls/ConfirmationCall/UCAttachCall.ascx" TagPrefix="uc1" TagName="UCAttachCall" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="PdfViewerAspNet" Namespace="PdfViewer4AspNet" TagPrefix="PdfViewer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<style type="text/css">
    .auto-style1 {
        height: 23px;
    }
</style>

<script type="text/javascript">
    function ShowLoginWindow() {
        pcLogin.Show();
    }
    function ShowCreateAccountWindow() {
        pcCreateAccount.Show();
        tbUsername.Focus();
    }

</script>

<asp:UpdatePanel runat="server" ID="upUCAttachCall" ClientSideEvents-BeginCallback="function(){ $('#divLoading').show(); }" 
    ClientSideEvents-EndCallback="function(){ $('#divLoading').hide(); }">
    <ContentTemplate>
        <div id="dvPopUCAttachCall" style="display: none;">
            <uc1:UCAttachCall runat="server" ID="UCAttachCall" />
        </div>
        <asp:HiddenField ID="hdnShowPopAttachCall" runat="server" ClientIDMode="Static" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUCAttachCallOrig" />
    </Triggers>
</asp:UpdatePanel>

<div class="grid_wrap margin_t_10">
    <div class="titulos_gris_02">
        <asp:Button ID="btnUCAttachCallOrig" class="pluss_icon" runat="server" ClientIDMode="Static" OnClick="btnUCAttachCallOrig_Click" Text="Adjuntar Llamada" />
        <strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AttachCall.ToUpper() %>:</strong>
    </div>
    <!--titulos_azules-->

    <dx:ASPxGridView EnablePagingGestures="False" ID="gvAttachedCalls" runat="server" ClientIDMode="Static"
        DataSourceID="dsCalls"
        optionsloadingpanel-enabled="false"
        SettingsLoadingPanel-Mode="Disabled"
        AutoGenerateColumns="False" KeyFieldName="RecordingFile; StepId; StepCaseNo; CallId; CommunicationTypeId"
        OnPreRender="gvAttachedCalls_PreRender"
        OnPageIndexChanged="gvAttachedCalls_PageIndexChanged"
        OnBeforeColumnSortingGrouping="gvAttachedCalls_BeforeColumnSortingGrouping"
        OnHtmlRowPrepared="gvAttachedCalls_HtmlRowPrepared"
        OnRowCommand="gvAttachedCalls_RowCommand" class="datagrid">
        <Settings ShowHeaderFilterButton="false" />
        <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
        <Columns>
            <dx:GridViewDataColumn Caption="User" FieldName="OriginatedByName" PropertiesEditType="TextBox">
                <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Call Start At" FieldName="StartDate" PropertiesEditType="TextBox">
                <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Call End At" FieldName="EndDate" PropertiesEditType="TextBox">
                <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Duration" FieldName="Duration" PropertiesEditType="TextBox">
                <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Outgoing Number" FieldName="OutboundNumber" PropertiesEditType="TextBox">
                <Settings AutoFilterCondition="Contains" HeaderFilterMode="CheckedList" />
            </dx:GridViewDataColumn>

            <dx:GridViewDataColumn Caption="PlayRecording" FieldName="PlayRecording" PropertiesEditType="TextBox">
                <DataItemTemplate>
                    <%# Eval("RecordingFileClean")%>
                </DataItemTemplate>
            </dx:GridViewDataColumn>

            <dx:GridViewDataColumn Caption="Delete" PropertiesEditType="TextBox">
                <DataItemTemplate>
                    <asp:Button ID="BtnRejectAttachCall" class="delete_file" runat="server" OnClientClick="return confirm('Are you sure?');" CommandName="Delete" HeaderStyle-Width="10%" />
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="true" AllowFocusedRow="True" />
        <SettingsPager AlwaysShowPager="true" PageSize="3" NumericButtonCount="2" />
        <Settings ShowFilterRow="true" ShowFilterBar="Auto" />
        <SettingsLoadingPanel Mode="Disabled" />
        <SettingsPopup>
            <HeaderFilter Height="200" />
        </SettingsPopup>
    </dx:ASPxGridView>

    <asp:ObjectDataSource ID="dsCalls" runat="server" SelectMethod="GetCalls"
        TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAttachment" OnSelecting="dsCalls_Selecting"></asp:ObjectDataSource>
</div>
<!--grid_wrap-->

<div class="grid_wrap margin_t_10">
    <div class="titulos_gris_02">
        <strong><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.UploadedDocuments.ToUpper() %></strong>
    </div>
    <!--titulos_azules-->
    <dx:ASPxGridView ID="gvDocuments" runat="server" ClientIDMode="Static"
        DataSourceID="dsDocuments"
        optionsloadingpanel-enabled="false"
        SettingsLoadingPanel-Mode="Disabled"
        AutoGenerateColumns="False" KeyFieldName="DocCategoryId;DocTypeId;DocumentId"
        OnPreRender="gvDocuments_PreRender"
        OnPageIndexChanged="gvDocuments_PageIndexChanged"
        OnBeforeColumnSortingGrouping="gvAttachedCalls_BeforeColumnSortingGrouping"
        OnRowCommand="gvDocuments_RowCommand" class="datagrid">
        <Columns>
            <dx:GridViewDataTextColumn Caption="DATE" FieldName="DocumentDate" VisibleIndex="1">
                <HeaderStyle CssClass="auto-style1"></HeaderStyle>
                <DataItemTemplate>
                    <div><%#string.Format("{0:d}", Eval("DocumentDate"))%></div>
                </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DOCCATEGORY" FieldName="DocCategoryId" VisibleIndex="2" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DOCTYPEID" FieldName="DocTypeId" VisibleIndex="3" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DOCID" FieldName="DocumentId" VisibleIndex="4" Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DOCUMENT DESCRIPCION" FieldName="DocCategoryDesc" VisibleIndex="5">
                <CellStyle CssClass="ObservationTruncatedCell"></CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="DOCUMENT NAME" FieldName="DocumentName" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataColumn Width="120px" Caption="VER" VisibleIndex="7">
                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                <DataItemTemplate>
                    <label class="label">
                        <asp:Button ID="BtnView" runat="server" class="view_verde" CommandName="View" HeaderStyle-Width="10%" />
                    </label>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="REJECT" VisibleIndex="8" Visible="false">
                <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                <DataItemTemplate>
                    <label class="label">
                        <asp:Button ID="BtnDelete0" runat="server" class="delete_file" CommandName="Delete" HeaderStyle-Width="10%" />
                    </label>
                </DataItemTemplate>
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsBehavior ColumnResizeMode="NextColumn" />
    </dx:ASPxGridView>
    <iframe src="/TempFiles/prueba.pdf" id="IfDocuments" runat="server" style="display: none;"></iframe>
    <asp:HiddenField ID="hfPathFile" runat="server" />

    <asp:ObjectDataSource ID="dsDocuments" runat="server" SelectMethod="GetDocuments"
        TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCAttachment" OnSelecting="dsDocuments_Selecting"></asp:ObjectDataSource>

    <!--grid_wrap-->
</div>

<asp:ModalPopupExtender ID="ModalPopupPadecimiento" BackgroundCssClass="modalPopup" PopupControlID="pnPadecimiento" 
    TargetControlID="hfPadecimiento" BehaviorID="popupPadecimiento" runat="server">
</asp:ModalPopupExtender>
<asp:Panel runat="server" ID="pnPadecimiento" ClientIDMode="Static">
    <div class="titulos_azules" style="width: 100%;">
        <ul>
            <li style="position: absolute; left: 41%; top: 31%;">
                <asp:Literal ID="ltMsgTitulo" runat="server"></asp:Literal>
            </li>
            <li style="top: 13%;">
                <input type="button" id="close_pop_up" class="cls_pup" onclick="$find('popupPadecimiento').hide();" />
            </li>
            <li>
                <button type="button" style="position: absolute; top: 7px; right: 40px; border: 0px; width: 24px; height: 24px; cursor: pointer; background-image: url('../../Images/MAXIM.png'); background-repeat: no-repeat; }"
                    id="btnMaxMin" alt="0" onclick="MaxMinWindowAjaxModalPopup(this);">
                </button>
            </li>
        </ul>
    </div>
    <PdfViewer:PdfViewer ID="pdfViewerPdfPopUp" runat="server" ClientIDMode="Static" ShowScrollbars="true" ShowToolbarMode="Show" Width="900px" Height="800px"></PdfViewer:PdfViewer>
</asp:Panel>
<asp:HiddenField runat="server" ID="hfPadecimiento" ClientIDMode="Static" />




