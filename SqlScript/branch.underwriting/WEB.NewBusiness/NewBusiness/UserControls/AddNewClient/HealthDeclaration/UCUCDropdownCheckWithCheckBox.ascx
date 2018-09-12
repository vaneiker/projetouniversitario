<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCUCDropdownCheckWithCheckBox.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCUCDropdownCheckWithCheckBox" %>
<%@ Register TagPrefix="asp" Namespace="Saplin.Controls" Assembly="DropDownCheckBoxes" %>
<div class="de_dos fix_height">
    <table>
        <tr>
            <td>
                <div>
                    <asp:CheckBox ID="cbCheckBoxItem" runat="server" CssClass="refresh_height checkbox_left" AutoPostBack="false" onclick="hideCheckTexbox(this)" dropdawncheck="dropdawncheck" />

                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none" >
                    <label class="label">
                        <asp:Label ID="lblRelationship" runat="server" Text="Relationship"></asp:Label></label>
                    <div class="">
                        <asp:DropDownCheckBoxes runat="server" Width="100%" Height="100%" UseSelectAllNode="false" AddJQueryReference="false" CssClass="wrap_select">
                            <Style SelectBoxWidth="195" DropDownBoxBoxWidth="160" DropDownBoxBoxHeight="150" />
                            <Items>
                                <asp:ListItem Text="Mango" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Apple" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Banana" Value="3"></asp:ListItem>
                            </Items>
                        </asp:DropDownCheckBoxes>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</div>
