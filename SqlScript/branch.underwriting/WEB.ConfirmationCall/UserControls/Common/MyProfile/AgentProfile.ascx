<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgentProfile.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.MyProfile.AgentProfile" %>
<%--<script src="../../../Services/UtilsService.svc/js"></script>--%>
<a href="#" id="current"><span></span>
    <h4>
        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Profile.ToUpper() %></h4>
</a>
<ul style="display: block; overflow: hidden;">
    <li class="last-child">

        <asp:UpdatePanel ID="divPerfil" ClientIDMode="Static" class="perfil" runat="server">
            <ContentTemplate>
                <%--    <div id="divPerfil" class="perfil">--%>
                <div class="foto_perfil">
                    <asp:FileUpload runat="server" ID="fldUploadAgentImage" ClientIDMode="Static" CssClass="input_file" accept="image/*" data-bind="enable: AgentProfileViewModel.editMode, visible: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangePhoto }" />
                    <span data-bind="visible: AgentProfileViewModel.editMode" class="edit_photo"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.UploadPhoto %></span>
                    <img data-bind="attr: { src: 'data:image/png;base64,' + AgentProfileViewModel.agentModel.Photo() }"
                        width="78" height="103">
                </div>
                <div class="info">
                    <h2 data-bind="text: AgentProfileViewModel.agentModel.AgentModel.AgentName"></h2>
                    <h3 data-bind="text: AgentProfileViewModel.agentModel.AgentModel.Position"></h3>
                    <p data-bind="text: AgentProfileViewModel.agentModel.AgentModel.Country">
                    </p>
                    <a data-bind="text: AgentProfileViewModel.agentModel.AgentModel.Email, attr: { href: 'mailto:' + AgentProfileViewModel.agentModel.AgentModel.Email }"></a>
                </div>
                <!--info-->
                <div id="divTabsAProfile" class="tabs">
                    <input id="tab-1" type="radio" name="radio-set" class="tab-selector-1" value="1" data-bind="checked: AgentProfileViewModel.TabSelected" />
                    <label for="tab-1" class="tab-label-1">
                    </label>
                    <input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" value="2" data-bind="checked: AgentProfileViewModel.TabSelected" />
                    <label for="tab-2" class="tab-label-2">
                    </label>
                    <input id="tab-3" type="radio" name="radio-set" class="tab-selector-3" value="3" data-bind="checked: AgentProfileViewModel.TabSelected" />
                    <label for="tab-3" class="tab-label-3">
                    </label>
                    <input id="tab-4" type="radio" name="radio-set" class="tab-selector-4" value="4" data-bind="checked: AgentProfileViewModel.TabSelected" />
                    <label for="tab-4" class="tab-label-4">
                    </label>
                    <input id="tab-5" type="radio" name="radio-set" class="tab-selector-5" value="5" data-bind="checked: AgentProfileViewModel.TabSelected" />
                    <label for="tab-5" class="tab-label-5">
                    </label>
                    <input id="tab-6" type="radio" name="editprofile" class="tab-selector-6" data-bind="checked: AgentProfileViewModel.editMode, event: { click: AgentProfileViewModel.RebindEvent }" />
                    <label for="tab-6" class="tab-label-6">
                    </label>
                    <div class="clearfix">
                    </div>
                    <!--no quitar-->
                    <!--tabs-->
                    <div class="content_tabs">
                        <!--mensaje que aparece solo cuando se activa el boton de editar-->
                        <span class="edit_mode"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.EditMode %></span>
                        <!--<span class="changes_saved">Changes saved</span>   -->
                        <!--contenido de los tabs-->
                        <div class="quick_mail">
                            <h2>
                                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.QuickMail %></h2>
                            <asp:TextBox runat="server" ID="txtSubject" ClientIDMode="Static" />
                            <asp:DropDownList runat="server" ID="drpEmailTo" DataTextField="Key" DataValueField="Value"></asp:DropDownList>
                            <asp:TextBox runat="server" ID="txtMessage1" ClientIDMode="Static" TextMode="MultiLine" />
                            <asp:Button runat="server" ID="btnSend" ClientIDMode="Static" CssClass="btn_green" />
                            <asp:Button runat="server" ID="btnClear" ClientIDMode="Static" CssClass="btn_grey" />
                            <a href="#" class="new_emails"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.HaveNewMessage %><span class="notify">3</span></a>

                        </div>
                        <!--quick_mail-->
                        <!--OJO todos los inputs, select siguientes deben estar readonly y editables cuando se pulse el btn de editar o el tab-6-->
                        <div class="profile">
                            <h2></h2>
                            <table>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Office %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.AgentModel.Office" type="text" readonly="readonly" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Position %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.AgentModel.Position" type="text" readonly="readonly" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Gender %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.AgentModel.Gender" type="text" readonly="readonly" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Type %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.AgentModel.Type" type="text" readonly="readonly" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Since %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.AgentModel.AgentSince" type="text" readonly="readonly" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                        <!--profile-->
                        <div class="list_mails">
                            <h2>E-mails</h2>
                            <table>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Type %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.agentModel.AgentModel.ListObservableEmail,
    optionsText: 'TypeDisplay',
    value: AgentProfileViewModel.agentModel.currentEmail"
                                            class="tipo">
                                        </select>
                                        <input data-bind="click: AgentProfileViewModel.AddEmail" type="button" class="add_option" />
                                        <input data-bind="click: AgentProfileViewModel.RemoveEmail" type="button" class="delete_option" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Address %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.currentEmail().Email, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeEmail }"
                                            type="text" maxlength="70" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %>:
                                    </th>
                                    <td>
                                        <input data-bind="checked: AgentProfileViewModel.agentModel.currentEmail().Primary, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeEmail }"
                                            type="checkbox" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!--list_mails-->
                        <div class="list_phones">
                            <h2>
                                <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Phones %></h2>
                            <table>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Type %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.agentModel.AgentModel.ListObservablePhone,
    optionsText: 'TypeDisplay',
    value: AgentProfileViewModel.agentModel.currentPhone"
                                            class="tipo">
                                        </select>
                                        <input data-bind="click: AgentProfileViewModel.AddPhone" type="button" class="add_option" />
                                        <input data-bind="click: AgentProfileViewModel.RemovePhone" type="button" class="delete_option" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.AreaCode %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.currentPhone().AreaCode, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangePhone }"
                                            type="text" maxlength="5" onkeypress="return useNumber(event);" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.PhoneNumber %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.currentPhone().PhoneNumber, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangePhone }"
                                            type="text" maxlength="10" onkeypress="return useNumber(event);" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Extension %> :
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.currentPhone().Ext, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangePhone }"
                                            type="text" maxlength="10" onkeypress="return useNumber(event);" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %>:
                                    </th>
                                    <td>
                                        <input data-bind="checked: AgentProfileViewModel.agentModel.currentPhone().Primary, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangePhone }"
                                            type="checkbox" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                        <!--list_phones-->
                        <div class="list_address">
                            <h2><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Location %></h2>
                            <table>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Type %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.agentModel.AgentModel.ListObservableAddress,
    optionsText: 'TypeDisplay',
    value: AgentProfileViewModel.agentModel.currentAddress, event: { change: AgentProfileViewModel.ChangeListAddress }"
                                            class="tipo">
                                        </select>
                                        <input data-bind="click: AgentProfileViewModel.AddAddress" type="button" class="add_option" />
                                        <input data-bind="click: AgentProfileViewModel.RemoveAddress" type="button" class="delete_option" />
                                    </td>
                                </tr>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Country %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.ListCountry,
    value: AgentProfileViewModel.agentModel.currentAddress().Country, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeCountry }">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Region:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.ListRegion,
    value: AgentProfileViewModel.agentModel.currentAddress().Region, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeRegion }">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.StateProv %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.ListState,
    value: AgentProfileViewModel.agentModel.currentAddress().State, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeState }">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.City %>:
                                    </th>
                                    <td>
                                        <select data-bind="
    options: AgentProfileViewModel.ListCity,
    value: AgentProfileViewModel.agentModel.currentAddress().City, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeCountry }">
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Street %>:
                                    </th>
                                    <td>
                                        <textarea data-bind="value: AgentProfileViewModel.agentModel.currentAddress().Street, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeAddress }"
                                            maxlength="70"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <th><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.ZipCode %>:
                                    </th>
                                    <td>
                                        <input data-bind="value: AgentProfileViewModel.agentModel.currentAddress().ZipCode, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeAddress }"
                                            type="text" maxlength="10" />
                                    </td>
                                </tr>
                                <th>
                                    <%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Primary %>:
                                </th>
                                <td>
                                    <input data-bind="checked: AgentProfileViewModel.agentModel.currentAddress().Primary, enable: AgentProfileViewModel.editMode, event: { change: AgentProfileViewModel.ChangeAddress }"
                                        type="checkbox" />
                                </td>
                                </tr>
                            </table>

                        </div>
                        <!--list_address-->
                        <span id="spnEditAgentInfo" class="edit_botones">
                            <%--      <div class="loading">
                                    <div class="loadingcontent">
                                        <p style="display: table-cell; vertical-align: top;">
                                            <img src="<%=Page.ResolveUrl("~/Content/Images/" + RESOURCE.UnderWriting.ConfirmationCall.Resources.Loadinggif)  %>" alt="Loading..." />
                                        </p>
                                    </div>
                                </div>--%>
                            <div class="loading" data-bind="attr: { height: AgentProfileViewModel.HeightLoading }"></div>
                            <input data-bind="click: AgentProfileViewModel.SaveChangesAgentProfile" id="btnSaveAgentProfileData" class="btn_green" type="button" value="<%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Save %>" />
                            <asp:Button runat="server" ID="btnCancelAProfile" ClientIDMode="Static" CssClass="btn_red" Text="Cancel" OnClientClick="CancelChangesAgentProfile();" OnClick="btnCancelAProfile_Click" />

                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnListCountry" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnListRegion" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnListState" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnListCity" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnAgentProfileData" />
                            <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnMessage" />
                            <asp:Button runat="server" ClientIDMode="Static" ID="btnHdnSaveAgentProfileData" Style="display: none;" OnClick="btnHdnSaveAgentProfileData_Click" />
                        </span>
                    </div>
                    <!--content_tabs-->
                    <div class="clearfix">
                    </div>
                    <!--no quitar-->
                </div>
                <!--tabs-->
                <div>
                    <asp:Label  runat="server"  ID="lblCompanyProfile" class="label"><%= RESOURCE.UnderWriting.ConfirmationCall.Resources.Company %>:</asp:Label>
                    <asp:DropDownList runat="server" ID="drpCompanyProfile" DataTextField="Value" DataValueField="Key" OnSelectedIndexChanged="drpCompanyProfile_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <label class="idiomas_label">Language:</label>
                <div id="divLanguage" class="idiomas">
                    <label class="en">English</label>
                    <ul>
                        <li class="es" onclick="changeLanguage('es');">Español</li>
                        <li class="en" onclick="changeLanguage('en');">English</li>
                    </ul>
                </div>
                <!--idiomas-->
                <asp:Button ID="btnLogout" runat="server" CssClass="btn_logout" Text="LogOut" OnClientClick='document.getElementById("hdnLogout").value = "False";' OnClick="btnLogOut_Click" />
                <asp:HiddenField  runat="server" ClientIDMode="Static" ID="hdnLogout" Value="True"/>
                <%-- </div>--%>
                <!--perfil-->
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClear" />
                <asp:AsyncPostBackTrigger ControlID="btnHdnSaveAgentProfileData" />
                <asp:AsyncPostBackTrigger ControlID="btnCancelAProfile" />
            </Triggers>
        </asp:UpdatePanel>
    </li>
</ul>
