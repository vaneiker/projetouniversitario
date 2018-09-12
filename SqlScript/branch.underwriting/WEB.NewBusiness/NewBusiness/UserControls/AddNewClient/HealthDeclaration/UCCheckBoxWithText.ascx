<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCheckBoxWithText.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCCheckBoxWithText" %>
<div class="de_dos fix_height">
    <table>
        <tr>
            <td>
                <div>
                    <asp:CheckBox ID="cbCheckBoxItem" runat="server" CssClass="refresh_height" onclick="hideCheckTexbox(this)" AutoPostBack="false"  textcheck='textcheck' />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: none">
                    <label class="label">
                        <asp:Label ID="lblDrownDawnTitles" runat="server" Text=""></asp:Label></label>
                    <asp:TextBox runat="server" CssClass="datepicker"></asp:TextBox>

                </div>
            </td>
        </tr>
    </table>

</div>
