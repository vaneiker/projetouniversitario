<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirements.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Requirements.UCRequirements" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCGridPaginator.ascx" TagPrefix="uc1" TagName="WUCGridPaginator" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<div class="grid_wrap margin_t_10">
    <dx:ASPxGridView ID="GridViewRequirements" KeyFieldName="ID;CategoryID;TypeId;ContactID;HasDocument;DocId"
        runat="server" ClientIDMode="Static"
        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewRequirements_RowCommand">
        <Columns>
            <dx:GridViewDataTextColumn Caption="REQUIREMENT" FieldName="Requirement" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="LAST UPDATE" FieldName="LastUpdate" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ROLE" FieldName="ContactRoleDesc" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UPLOAD" VisibleIndex="3">
                <DataItemTemplate>
                    <asp:LinkButton runat="server" CssClass='<%#bool.Parse(DataBinder.Eval(Container.DataItem,"HasDocument").ToString()) == true ? "pdf_ico":"upload_file" %> ' ID="btnUploadFile" OnClientClick="return UploadRequirement(this)"></asp:LinkButton>
                    <input type="hidden" name="ReqRowID" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                    <input type="hidden" name="ReqRowCatID" value='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>' />
                    <input type="hidden" name="ReqRowTypeID" value='<%# DataBinder.Eval(Container.DataItem, "TypeId") %>' />
                    <input type="hidden" name="ReqRowContactID" value='<%# DataBinder.Eval(Container.DataItem, "ContactID") %>' />
                    <input type="hidden" name="ReqRowHasDocument" value='<%# DataBinder.Eval(Container.DataItem,"HasDocument") %>' />
                    <input type="hidden" name="ReqRowDocId" value='<%# DataBinder.Eval(Container.DataItem,"DocId") %>' />
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VIEW" VisibleIndex="4">
                <DataItemTemplate>
                    <asp:Button runat="server" CssClass="view_file" CommandName="view" />
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DELETE" VisibleIndex="5">
                <DataItemTemplate>
                    <asp:Button runat="server" CssClass="delete_file" CommandName="delete" OnClientClick="return DlgConfirm(this)" />
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn Caption="OBLIG" FieldName="Is_Mandatory" VisibleIndex="6">
            </dx:GridViewDataCheckColumn>
        </Columns>

        <SettingsPager PageSize="20">
        </SettingsPager>

        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
    </dx:ASPxGridView>
</div>




