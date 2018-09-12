<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRequirement.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Requirements.UCRequirement" ClientIDMode="AutoID" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<asp:Panel runat="server" ID="pnlRequerimentsData" CssClass="grupos de_5">
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.ProductName %></label>
        <div class="wrap_select">
            <asp:DropDownList runat="server" ID="ddlProduct">
                <asp:ListItem Text="Option 1" />
                <asp:ListItem Text="Option 2" />
            </asp:DropDownList>
        </div>
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.InsuredAmount %></label>
        <asp:TextBox runat="server" ID="txtInsuredAmount" CssClass="amount insuredamount" decimal='decimal' />
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AnnuityAmount %></label>
        <asp:TextBox runat="server" ID="txtAnnuityAmount" CssClass="amount annuityamount" decimal='decimal' />
    </div>
    <div>
        <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.AnnuityPeriod %></label>
        <asp:TextBox runat="server" ID="txtAnnuityPeriod" CssClass="amount annuityperiod" number='number2' />
    </div>
    <div>
        <div class="boton_wrapper amarillo">
            <span class="add"></span>
            <asp:Button runat="server" ID="btnAdd" CssClass="boton" Text="Add" OnClick="btnAdd_Click" OnClientClick='return ValidateRequirement(this);' />
            <input type="hidden" value="<%=this.pnlRequerimentsData.ClientID %>" />
        </div>
    </div>
</asp:Panel>
<!--grupos-->

<div class="grid_wrap margin_t_10">
    <dx:ASPxGridView ID="gvRequirements" KeyFieldName="Id" runat="server"
        EnableCallBacks="false" OnRowCommand="gvRequirements_RowCommand" DataSourceID="ldsRequirement">
        <Columns>
            <dx:GridViewDataColumn Caption="Product Name" Name="ProductName" HeaderStyle-CssClass="c1" CellStyle-CssClass="c1" FieldName="ProductType" />
            <dx:GridViewDataColumn Caption="Insured Amount" Name="InsuredAmount" FieldName="InsuredAmount" HeaderStyle-CssClass="c2 amount" CellStyle-CssClass="c2 amount" />
            <dx:GridViewDataColumn Caption="Annuity Amount" Name="AnnuityAmount" FieldName="AnnuityAmount" HeaderStyle-CssClass="c3 amount" CellStyle-CssClass="c3 amount" />
            <dx:GridViewDataColumn Caption="Annuity Period" Name="AnnuityPeriod" FieldName="AnnuityPeriod" HeaderStyle-CssClass="c4 amount" CellStyle-CssClass="c4 amount" />
            <dx:GridViewDataColumn Caption="Edit" Name="Edit" HeaderStyle-CssClass="c10" CellStyle-CssClass="c5">
                <DataItemTemplate>
                    <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandArgument='<%#Eval("Id") %>' CommandName="Edit"></asp:Button>
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataColumn>
            <dx:GridViewDataColumn Caption="Delete" Name="DELETE" HeaderStyle-CssClass="c11" CellStyle-CssClass="c6">
                <DataItemTemplate>
                    <asp:Button runat="server" CssClass="delete_file" ID="btnDelete" CommandArgument='<%#Eval("Id") %>' CommandName="Delete"></asp:Button>
                </DataItemTemplate>
                <Settings AllowHeaderFilter="False" AllowSort="False" />
            </dx:GridViewDataColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
        <SettingsPager PageSize="3" NumericButtonCount="3" />
        <SettingsPopup>
            <HeaderFilter Height="200" />
        </SettingsPopup>
        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
        <Settings ShowFilterBar="Hidden" />
    </dx:ASPxGridView>
    
    <dx:LinqServerModeDataSource OnSelecting="ldsRequirement_Selecting" ID="ldsRequirement" runat="server" DefaultSorting="ProductType" /> 
</div>
<!--grid_wrap-->

<div class="grid_wrap margin_t_10">
    <dx:ASPxGridView ID="gvRequirementDetails" KeyFieldName="ExamCode" runat="server"
        EnableCallBacks="false" DataSourceID="ldsRequirementDetail">
        <Columns>
            <dx:GridViewDataColumn Caption="DETAILS REQUIREMENTS INSURED" Name="DetailRequirementsInsured" CellStyle-CssClass="c1" HeaderStyle-HorizontalAlign="Left" HeaderStyle-CssClass="c1 left_align" FieldName="ExamName" />
        </Columns>
        <SettingsPager PageSize="3" NumericButtonCount="3" />
        <SettingsPopup>
            <HeaderFilter Height="200" />
        </SettingsPopup>
        <SettingsDataSecurity AllowInsert="false" AllowEdit="false" AllowDelete="false" />
        <Settings ShowFilterBar="Hidden" />
    </dx:ASPxGridView>
    <dx:LinqServerModeDataSource OnSelecting="ldsRequirementDetail_Selecting" ID="ldsRequirementDetail" runat="server" DefaultSorting="ExamName" /> 

</div>
