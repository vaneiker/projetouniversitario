<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCheckBoxListWithQuestion.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.AddNewClient.HealthDeclaration.UCCheckBoxListWithQuestion" %>
<div class="de_uno">
    <div>
        <table>
            <tr>
                <td>

                    <label class="label"><asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label></label>
                </td>
                <td>
                    <div>
                        <table class="radio">
                            <tr>
                                <td>
                                   <asp:RadioButtonList ID="rblRadioButtonList" runat="server" RepeatColumns="2" validation="Required"></asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
