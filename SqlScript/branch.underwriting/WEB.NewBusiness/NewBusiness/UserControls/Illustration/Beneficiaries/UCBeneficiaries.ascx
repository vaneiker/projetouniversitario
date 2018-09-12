<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBeneficiaries.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Beneficiaries.UCBeneficiaries" ClientIDMode="AutoID" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>

<asp:Panel runat="server" ID="pnlBeneficiaries">
    <div class="grupos de_4">
        <div>
            <label class="label red"><%=RESOURCE.UnderWriting.NewBussiness.Resources.FirstNameLabel %></label>
            <asp:TextBox runat="server" ID="txtFirstName" validation="Required" alphabetical='alphabetical' />
        </div>
        <div>
            <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.MiddleNameLabel %></label>
            <asp:TextBox runat="server" ID="txtMiddleName" alphabetical='alphabetical' />
        </div>
        <div>
            <label class="label red"><%=RESOURCE.UnderWriting.NewBussiness.Resources.LastNameLabel %></label>
            <asp:TextBox runat="server" ID="txtLastName" validation="Required" alphabetical='alphabetical' />
        </div>
        <div>
            
           <label class="label"><%=RESOURCE.UnderWriting.NewBussiness.Resources.SecondLastNameLabel %></label>            
           <%--Bmarroquin 27-01-2017 no es Obligatorio el 2 Apellido--%>
            <asp:TextBox runat="server" ID="txtSecondLastName" alphabetical='alphabetical' />
        </div>
        <div>
            <label class="label red">
                <%=RESOURCE.UnderWriting.NewBussiness.Resources.RelationshipLabel %>
            </label>
            <div class="wrap_select">
                <asp:DropDownList runat="server" ID="ddlRelationship" validation="Required">
                    <asp:ListItem Text="Option 1" />
                    <asp:ListItem Text="Option 2" />
                </asp:DropDownList>
            </div>
            <!--wrap_select-->
        </div>
        <div>
            <label class="label red"><%=RESOURCE.UnderWriting.NewBussiness.Resources.DateofBirthLabel %></label>
            <asp:TextBox runat="server" ID="txtDateOfBirth" date="birth" CssClass="datepicker" validation="Required" />
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <label id="lblPercentage" runat="server" class="label red"><%=RESOURCE.UnderWriting.NewBussiness.Resources.PercentageLabel %></label>
                        <asp:TextBox runat="server" ID="txtPercentage" validation="Required" data-inputmask="'alias': 'decimal', 'groupSeparator': ',', 'autoGroup': true, 'allowMinus': false, 'allowPlus': false, 'digits': 2" />
                    </td>
                    <td style="width: 130px; text-align: right">
                        <div class="boton_wrapper amarillo">
                            <span class="add"></span>
                            <asp:Button runat="server" ID="btnAdd" CssClass="boton" Text="Add" OnClientClick='return ValidateBeneficiary(this);' OnClick="btnAdd_Click" />
                            <input type="hidden" value="<%=this.pnlBeneficiaries.ClientID %>" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--grupos-->
    <div class="grid_wrap margin_t_10">
        <dx:ASPxGridView ID="gvBeneficiaries" runat="server" KeyFieldName="Id" ClientIDMode="Static" OnRowCommand="gvBeneficiaries_RowCommand" DataSourceID="dsBeneficiaries" AutoGenerateColumns="False">
            <Columns>
                <dx:GridViewDataColumn Caption="First Name" Name="FirstNameLabel" FieldName="FirstName" HeaderStyle-CssClass="c1" CellStyle-CssClass="c1" />
                <dx:GridViewDataColumn Caption="Middle Name" Name="MiddleNameLabel" FieldName="MiddleName" HeaderStyle-CssClass="c2" CellStyle-CssClass="c2" />
                <dx:GridViewDataColumn Caption="Last Name" Name="LastNameLabel" FieldName="LastName" HeaderStyle-CssClass="c3" CellStyle-CssClass="c3" />
                <dx:GridViewDataColumn Caption="Second Last Name" Name="SecondLastNameLabel" FieldName="SecondLastName" HeaderStyle-CssClass="c3" CellStyle-CssClass="c3" />
                <dx:GridViewDataColumn Caption="Date Of Birth" Name="DateofBirthLabel" FieldName="DateOfBirth" HeaderStyle-CssClass="c4" CellStyle-CssClass="c4" />
                <dx:GridViewDataColumn Caption="Relationship" Name="RelationshipLabel" FieldName="Relationship" HeaderStyle-CssClass="c4" CellStyle-CssClass="c4" />
                <dx:GridViewDataColumn Caption="Percentage" Name="PercentageLabel" HeaderStyle-CssClass="c5" CellStyle-CssClass="c5">
                    <DataItemTemplate>
                       <asp:Label runat="server"><%# (Convert.ToDecimal(Eval("Percentage"))/100).ToString("p") %></asp:Label> 
                    </DataItemTemplate>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Edit" Name="Edit" HeaderStyle-CssClass="c6" CellStyle-CssClass="c6">
                    <DataItemTemplate>
                        <asp:Button runat="server" CssClass="edit_file" ID="btnEdit" CommandArgument='<%#Eval("Id") %>' CommandName="Edit"></asp:Button>
                    </DataItemTemplate>
                    <Settings AllowHeaderFilter="False" AllowSort="False" />
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Delete" Name="DELETE" HeaderStyle-CssClass="c7" CellStyle-CssClass="c7">
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
        <asp:ObjectDataSource ID="dsBeneficiaries" runat="server" SelectMethod="GetBeneficiaries"
            TypeName="WEB.NewBusiness.NewBusiness.UserControls.Illustration.Beneficiaries.UCBeneficiaries" OnSelecting="dsBeneficiaries_Selecting"></asp:ObjectDataSource>
    </div>
</asp:Panel>
