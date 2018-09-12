<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCheckBoxWithDropdawn.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCCheckBoxWithDropdawn" %>
<div class="de_dos fix_height">
    <table>
        <tr>
            <td>
                <div>
                    <asp:CheckBox ID="cbCheckBoxItem" runat="server" CssClass="refresh_height" AutoPostBack="false" dropdawncheck="dropdawncheck"/>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div  style="display: none">
                    <label class="label">
                        <asp:Label ID="lblRelationship" runat="server" Text="Relationship"></asp:Label></label>
                    <div class="wrap_select">
                        <asp:DropDownList ID="ddlDropdawnOptionsSelect" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </td>
        </tr>
    </table>

</div>

