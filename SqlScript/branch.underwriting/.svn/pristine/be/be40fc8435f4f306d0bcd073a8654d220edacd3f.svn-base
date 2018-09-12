
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCSecurityQuestions.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.History.UCSecurityQuestions" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<div class="grid_wrap margin_t_15">
    <div class="pagination">


        <dx:ASPxGridView ID="GrdPreguntas" runat="server" AutoGenerateColumns="False"
            OnRowUpdating="GrdPreguntas_RowUpdating" KeyFieldName="QuestionId" DataSourceID="dsQuestion">
            <Columns>
                <dx:GridViewDataTextColumn Caption="#" ReadOnly="true" FieldName="QuestionId" VisibleIndex="0">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="PREGUNTAS" ReadOnly="true" FieldName="QuestionDesc" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="RESPUESTAS" FieldName="Answer" VisibleIndex="2">
                </dx:GridViewDataTextColumn>
            </Columns>
            <SettingsDataSecurity AllowDelete="False" AllowInsert="False" AllowEdit="False" />
        </dx:ASPxGridView>
        <br />


        <asp:ObjectDataSource ID="dsQuestion" runat="server" SelectMethod="GetQuestion" UpdateMethod="SetQuestion"
            TypeName="WEB.ConfirmationCall.UserControls.History.UCSecurityQuestions" OnSelecting="dsQuestion_Selecting" OnUpdating="dsQuestion_Updating" >
            <SelectParameters>
                <asp:Parameter Name="data" Type="Object" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="data" Type="Object" />
            </UpdateParameters>
        </asp:ObjectDataSource>


    </div>
    <!--pagination-->

</div>
<!--grid_wrap-->

<!--grupos-->
