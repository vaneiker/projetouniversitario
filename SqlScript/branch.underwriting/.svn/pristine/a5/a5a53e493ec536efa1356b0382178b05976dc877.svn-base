<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSecurityQuestions.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCSecurityQuestions" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<div class="grid_wrap margin_t_15">
    <div class="pagination">
        <dx:ASPxGridView ID="GrdPreguntas" runat="server" AutoGenerateColumns="False" OnRowCommand="GrdEmailAddresses_RowCommand"
            OnRowUpdating="GrdPreguntas_RowUpdating" KeyFieldName="QuestionId,NameId" DataSourceID="dsQuestion">
            <ClientSideEvents BeginCallback="function(){ $('#loading').show(); }"
                EndCallback="function(){ $('#loading').hide();}" RowClick="selectRowS"></ClientSideEvents>
            <Columns>
                <dx:GridViewDataTextColumn Caption="#" ReadOnly="True" FieldName="QuestionId" VisibleIndex="0">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="QUESTION" ReadOnly="True" FieldName="QuestionDesc" VisibleIndex="1">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="ANSWER" FieldName="Answer" VisibleIndex="2">
                    <DataItemTemplate>                        
                        <asp:TextBox ID="txtBox" runat="server" width="100%" Text='<%# Eval("Answer")%>' CssClass="inputValida" ></asp:TextBox>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="NAMEID" ReadOnly="True" FieldName="NameId" VisibleIndex="3" Visible="false">
                    <EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataColumn Caption="Edit" VisibleIndex="4" Visible="false">
                    <HeaderStyle CssClass="auto-style5"></HeaderStyle>
                    <DataItemTemplate>
                        <label class="label">
                            <asp:Button ID="BtnEdit" class="edit_file" runat="server" HeaderStyle-Width="10%" CommandName="Edit" />
                        </label>
                    </DataItemTemplate>
                </dx:GridViewDataColumn>

            </Columns>
            <SettingsPager AlwaysShowPager="true" PageSize="8" NumericButtonCount="3" />
            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
            <SettingsEditing Mode="Inline"></SettingsEditing>
        </dx:ASPxGridView>
        <br />
        <div style="display:block;color:red;font-size:12px">- No se admiten caracteres especiales, solo la pregunta 4 y 6 pueden contener un ( / ) slash para separar las respuestas.<asp:ImageButton ID="imgButtonAlert" runat="server" ImageUrl="~/images/red_icon.png" ToolTip="Estado de las pregunta" Visible="False"/></div>
        <br />
        <asp:ObjectDataSource ID="dsQuestion" runat="server" SelectMethod="GetQuestion" UpdateMethod="SetQuestion"
            TypeName="WEB.ConfirmationCall.UserControls.ConfirmationCall.UCSecurityQuestions" OnSelecting="dsQuestion_Selecting" OnUpdating="dsQuestion_Updating">
            <SelectParameters>
                <asp:Parameter Name="data" Type="Object" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="data" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </div>
    <asp:Button runat="server" ID="btnSelectRows" ClientIDMode="Static" Style="display: none;" OnClick="btnSelectRows_Click" />
    <!--pagination-->
</div>
<!--grid_wrap-->
<div class="grupos">
    <div class="float_right">
        <div class="boton_wrapper verde">
            <span class="save"></span>
            <asp:Button class="boton" ID="BtnGrabar" runat="server" Text="Save" OnClick="BtnGrabar_Click" />
        </div>
    </div>
</div>
<!--grupos-->
