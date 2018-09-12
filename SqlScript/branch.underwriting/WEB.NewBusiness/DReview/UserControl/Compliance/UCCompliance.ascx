<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCompliance.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Requirements.UCCompliance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/NewBusiness/UserControls/Common/WUCGridPaginator.ascx" TagPrefix="uc1" TagName="WUCGridPaginator" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<div class="grid_wrap margin_t_10">
    <dx:ASPxGridView ID="GridComplianceData" KeyFieldName="Contact_Id"
        runat="server" ClientIDMode="Static"
        EnableCallBacks="False" Width="100%" AutoGenerateColumns="False"  OnRowCommand="GridComplianceData_RowCommand" >
        <Columns>
            <dx:GridViewDataTextColumn Caption="ROL" FieldName="Nombre_Rol" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="NOMBRE COMPLETO" FieldName="ClientName" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="FECHA DE NACIMIENTO" FieldName="Dob" VisibleIndex="2">
                 <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="IDENTIFICACION" FieldName="Identificacion" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="TIPO IDENTIFICACION" FieldName="TipoIdentificacion" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ESTADO DE CUMPLIMIENTO" FieldName="statusCompliance" VisibleIndex="5">
               <DataItemTemplate>
                  <asp:Literal runat="server" ID="litstatus" Text='<%# DataBinder.Eval(Container.DataItem,"statusCompliance") %>'></asp:Literal>
               </DataItemTemplate>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="REENVIAR CONSULTA" VisibleIndex="7">
                <DataItemTemplate>
                    <asp:LinkButton runat="server" CssClass='<%# DataBinder.Eval(Container.DataItem,"statusCompliance").ToString() == "Possible Match" ? "imgUpload_file_Ds" : "upload_file"  %>' Enabled='<%# DataBinder.Eval(Container.DataItem,"statusCompliance").ToString() == "Possible Match" ? false : true  %>' ID="lnkReenviar" CommandName="reenviar" 
                        ToolTip='<%# DataBinder.Eval(Container.DataItem,"statusCompliance").ToString() == "Possible Match" ? "Boton Deshabilitado debido al estado actual (Possible Match)" : ""  %>'></asp:LinkButton>
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="CONTACID" FieldName="ContactId" VisibleIndex="8" Width="0px" Visible="false">
            </dx:GridViewDataTextColumn>

            <dx:GridViewDataTextColumn Caption="Address" FieldName="Address" VisibleIndex="9"  Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="CountryOfBirth" FieldName="CountryOfBirth" VisibleIndex="10"  Visible="false">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="ID" VisibleIndex="10"  Visible="false">
            </dx:GridViewDataTextColumn>
        </Columns>
        <SettingsPager PageSize="50">
        </SettingsPager>
        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
    </dx:ASPxGridView>
</div>




