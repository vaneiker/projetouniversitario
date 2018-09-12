<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNotes.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCNotes" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="grupos de_2">
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Subject %>:</label>
        <asp:TextBox ID="TxtSubJect" runat="server"></asp:TextBox>
    </div>
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.CommentType %>:</label>
        <div class="wrap_select">
            <asp:DropDownList ID="DrpCommType" runat="server">
            </asp:DropDownList>
        </div>
        <!--wrap_select-->
    </div>

</div>
<!--grupos-->

<div class="grupos de_1">
    <div>
        <label class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Description %>:</label>
        <div class="textarea_border">
            <asp:TextBox ID="TxtDescripcion" TextMode="MultiLine" Columns="500" Rows="5" runat="server" class="textarea_clear_style" />
            <p class="text_gris">
                <asp:Label ID="TxtDescripcionAnterior" TextMode="MultiLine" Columns="500" Rows="5" runat="server" class="textarea_clear_style" />
            </p>
        </div>
    </div>
</div>
<!--grupos-->

<div class="grupos">
    <div>
        <div style="text-align: right">
            <div class="float_right">
                <div class="boton_wrapper gris float_right">
                    <span class="borrar"></span>
                    <asp:Button ID="BtnCancelNotes" class="boton" runat="server" Text="Cancel" OnClick="BtnCancelNotes_Click" />
                </div>
            </div>
        </div>
    </div>
    <div>
        <div style="text-align: right">
            <div class="float_right">
                <div id="BtnAddNotesDiv" class="boton_wrapper amarillo float_right" runat="server">
                    <span id="BtnAddNotesSpan" class="add" runat="server"></span>
                    <asp:Button class="boton" ID="BtnAddNotes" runat="server" Text="Add" OnClick="BtnAddNotes_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
<!--grupos-->

<div class="grid_wrap margin_t_15">

    <table>
        <thead class="headgrid">
        </thead>
        <tbody class="datagrid">
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <div class="pagination">
                        <dx:ASPxGridView EnablePagingGestures="False" ID="GrdNotes" runat="server" ClientIDMode="Static"
                            DataSourceID="dsNotes"
                            optionsloadingpanel-enabled="false"
                            SettingsLoadingPanel-Mode="Disabled"
                            AutoGenerateColumns="False" OnRowCommand="GrdNotes_RowCommand1" KeyFieldName="CorpId;NoteId;NoteName;NoteDesc;NoteTypeId;NoteTypeDesc"
                            OnPreRender="GrdNotes_PreRender"
                            OnPageIndexChanged="GrdNotes_PageIndexChanged"
                            OnBeforeColumnSortingGrouping="GrdNotes_BeforeColumnSortingGrouping">
                            <Settings ShowHeaderFilterButton="false" />
                            <ClientSideEvents BeginCallback="BeginRequestHandler" EndCallback="EndRequestHandler"></ClientSideEvents>
                            <Columns>
                                <dx:GridViewDataColumn Caption="Subject" FieldName="NoteName" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Comment Type" FieldName="NoteTypeDesc" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Created User" FieldName="OriginatedByName" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Created Date" FieldName="DateAdded" PropertiesEditType="TextBox">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    <DataItemTemplate>
                                     <div><%#string.Format("{0:d}", Eval("DateAdded"))%></div>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>

                                <dx:GridViewDataColumn Caption="Source System" FieldName="SourceSystem" PropertiesEditType="TextBox">
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
                                <dx:GridViewDataColumn Caption="Delete" PropertiesEditType="TextBox" Visible="False">
                                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                                    <DataItemTemplate>
                                        <label class="label">
                                            <asp:Button ID="BtnDelete0" runat="server" class="delete_file" OnClientClick="return confirm('Are you sure?');" CommandName="Delete" HeaderStyle-Width="10%" />
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

                        <asp:ObjectDataSource ID="dsNotes" runat="server" SelectMethod="GetNotes"
                            TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCNotes" OnSelecting="dsNotes_Selecting"></asp:ObjectDataSource>

                    </div>
                    <!--pagination-->
                </td>
            </tr>
        </tfoot>
    </table>



</div>
<!--grid_wrap-->
