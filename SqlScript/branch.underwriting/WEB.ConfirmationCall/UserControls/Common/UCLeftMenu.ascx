<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLeftMenu.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.UCLeftMenu" %>
<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:HiddenField ID="CalendarCurrentDay" runat="server" Value="" ClientIDMode="Static" />

<%--<div id="profile_menu_logo" class="logo" runat="server" ></div>--%>
<!--logo-->
<div class="accordion">
    <ul id="acordeon_agent_profile">
        <%--        <li class="perfil_agent"><a href="#item1" id="current"><span></span>
            <h4>PROFILE</h4>
        </a>
            <ul>
                <li>
                    <div class="perfil">
                        <!--div q collapasa-->
                        <div class="foto_perfil">
                            <!--cuando este en edit mode aparece el input file y el span / lo puedes manejar por display none o omitiendolo de la estructura
                            <input type="file" class="input_file">
                            <span class="edit_photo">Upload a Photo</span>-->
                            <!--si no hay foto subida, no debe aparecer img, el foto de perfil tiene un background q indica q no tiene foto-->
                            <img src="../images/foto.png" width="78" height="103" />
                        </div>
                        <!--foto_perfil-->
                        <div class="info">
                            <h2>Andrés Pérez Gutiérrez</h2>
                            <h3>Agent StateTrust</h3>
                            <p>Venezuela</p>
                            <a href="mailto:andreapmartinez@gmail.com">andreapmartinez@gmail.com</a>
                        </div>
                        <!--info-->

                        <div class="tabs">
                            <input id="tab-1" type="radio" name="radio-set" class="tab-selector-1" />
                            <label for="tab-1" class="tab-label-1"></label>
                            <input id="tab-2" type="radio" name="radio-set" class="tab-selector-2" />
                            <label for="tab-2" class="tab-label-2"></label>
                            <input id="tab-3" type="radio" name="radio-set" class="tab-selector-3" />
                            <label for="tab-3" class="tab-label-3"></label>
                            <input id="tab-4" type="radio" name="radio-set" class="tab-selector-4" />
                            <label for="tab-4" class="tab-label-4"></label>
                            <input id="tab-5" type="radio" name="radio-set" class="tab-selector-5" checked="checked" />
                            <label for="tab-5" class="tab-label-5"></label>
                            <input id="tab-6" type="radio" name="editprofile" class="tab-selector-6" />
                            <label for="tab-6" class="tab-label-6"></label>
                            <div class="clearfix"></div>
                            <!--no quitar-->

                            <!--tabs-->
                            <div class="content_tabs">
                                <!--mensaje que aparece solo cuando se activa el boton de editar-->
                                <span class="edit_mode">Edit mode</span>
                                <!--<span class="changes_saved">Changes saved</span>   -->

                                <!--contenido de los tabs-->
                                <div class="quick_mail">
                                    <h2>Quick mail</h2>
                                    <input type="text" placeholder="Subject" />
                                    <select>
                                        <option>Select a Department</option>
                                        <option>Data 2</option>
                                    </select>
                                    <textarea placeholder="Write a message"></textarea>
                                    <input type="submit" value="Send" class="btn_green" />
                                    <input type="submit" value="Clear" class="btn_grey" />
                                    <a href="#" class="new_emails">You have new messages<span class="notify">3</span></a>
                                </div>
                                <!--quick_mail-->

                                <!--OJO todos los inputs, select siguientes deben estar readonly y editables cuando se pulse el btn de editar o el tab-6-->

                                <div class="profile">
                                    <h2>Information</h2>
                                    <table>
                                        <tr>
                                            <th>Office:</th>
                                            <td>
                                                <input type="text" value="Caracas 01" /></td>
                                        </tr>
                                        <tr>
                                            <th>Position:</th>
                                            <td>
                                                <input type="text" value="State Trust Agent" /></td>
                                        </tr>
                                        <tr>
                                            <th>Gender:</th>
                                            <td>
                                                <input type="text" value="Male" /></td>
                                        </tr>
                                        <tr>
                                            <th>Type:</th>
                                            <td>
                                                <input type="text" value="--" /></td>
                                        </tr>
                                        <tr>
                                            <th>Employee Since:</th>
                                            <td>
                                                <input type="text" value="March 27, 2010" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <!--profile-->

                                <div class="list_mails">
                                    <h2>E-mails</h2>
                                    <table>
                                        <tr>
                                            <th>Type:</th>
                                            <td>
                                                <select class="tipo">
                                                    <option>Primary</option>
                                                    <option>Other</option>
                                                </select>
                                                <input type="submit" class="add_option" />
                                                <input type="submit" class="delete_option" /></td>
                                        </tr>
                                        <tr>
                                            <th>Address:</th>
                                            <td>
                                                <input type="text" value="andreapmartinez@gmail.com" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <!--list_mails-->

                                <div class="list_phones">
                                    <h2>Phones</h2>
                                    <table>
                                        <tr>
                                            <th>Type:</th>
                                            <td>
                                                <select class="tipo">
                                                    <option>Home</option>
                                                    <option>Office</option>
                                                    <option>Cell Phone 1</option>
                                                    <option>Cell Phone 2</option>
                                                </select>
                                                <input type="submit" class="add_option" />
                                                <input type="submit" class="delete_option" /></td>
                                        </tr>
                                        <tr>
                                            <th>Number:</th>
                                            <td>
                                                <input type="text" value="(809) 544-5623"></td>
                                        </tr>
                                    </table>
                                </div>
                                <!--list_phones-->

                                <div class="list_address">
                                    <h2>Location</h2>
                                    <table>
                                        <tr>
                                            <th>Type:</th>
                                            <td>
                                                <select class="tipo">
                                                    <option>Home</option>
                                                    <option>Work</option>
                                                    <option>Other</option>
                                                </select>
                                                <input type="submit" class="add_option">
                                                <input type="submit" class="delete_option"></td>
                                        </tr>
                                        <tr>
                                            <th>Country:</th>
                                            <td>
                                                <input type="text" value="State Trust Agent"></td>
                                        </tr>
                                        <tr>
                                            <th>State:</th>
                                            <td>
                                                <input type="text" value="Male"></td>
                                        </tr>
                                        <tr>
                                            <th>City:</th>
                                            <td>
                                                <input type="text" value="--"></td>
                                        </tr>
                                        <tr>
                                            <th>Street:</th>
                                            <td>
                                                <input type="text" value="--"></td>
                                        </tr>
                                        <tr>
                                            <th>Zip-code:</th>
                                            <td>
                                                <input type="text" value="--"></td>
                                        </tr>
                                    </table>
                                </div>
                                <!--list_address-->

                                <span class="edit_botones">
                                    <!--Estos botones apareceran solo cuando este activo el boton de editar-->
                                    <input class="btn_green" type="submit" value="Save" />
                                    <input class="btn_red" type="submit" value="Cancel" />
                                </span>
                            </div>
                            <!--content_tabs-->
                            <div class="clearfix"></div>
                            <!--no quitar-->
                        </div>
                        Company:<br />
                        <!--Fijo hasta que se haga el SP que traiga las companias desde GLOBAL-->
                        <asp:DropDownList ID="drpCompanyProfile" runat="server" OnSelectedIndexChanged="drpCompanyProfile_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="1">STATETRUST LIFE</asp:ListItem>
                            <asp:ListItem Value="2">ATLANTICA SEGUROS</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <label class="idiomas_label">Language:</label>
                        <div id="divLanguage" class="idiomas">
                            <label class="en">English</label>
                            <ul>
                                <li class="es" onclick="changeLanguage('es');">Español</li>
                                <li class="en" onclick="changeLanguage('en');">English</li>
                            </ul>
                        </div>
                        <!--idiomas-->
                        <asp:Button ID="btnLogout" runat="server" CssClass="btn_logout" Text="LogOut" OnClientClick='document.getElementById("hdnLogout").value = "False";' OnClick="btnLogout_Click" />
                        <asp:HiddenField runat="server" ClientIDMode="Static" ID="hdnLogout" Value="True" />
                    </div>
                    <!--perfil-->
                </li>
            </ul>
        </li>--%>
        <!--perfil_agente-->
      <%--  <label class="idiomas_label">Company:</label>
        <br />--%>
<%--        <!--Fijo hasta que se haga el SP que traiga las companias desde GLOBAL-->
        <asp:DropDownList ID="drpCompanyProfile" runat="server" OnSelectedIndexChanged="drpCompanyProfile_SelectedIndexChanged" AutoPostBack="false">
            <asp:ListItem Value="1">STATETRUST LIFE</asp:ListItem>
            <asp:ListItem Value="2">ATLANTICA SEGUROS</asp:ListItem>
        </asp:DropDownList>--%>
        <li class="calendar_agent"><a href="#item2"><span></span>
            <h4>CALENDAR</h4>
        </a>
            <ul>
                <li>
                    <div class="content_calendar">
                        <!--div q collapasa-->
                        <div class="today">December<span>23</span></div>
                        <!--today-->
                        <div>
                            <table class="cal">
                                <caption>
                                    <a id="calPrev" class="prev" href="#"></a><a id="calNext" class="next" href="#"></a><a id="calHeader" href="#"></a>
                                </caption>
                                <thead>
                                    <tr>
                                        <th>Mon</th>
                                        <th>Tue</th>
                                        <th>Wed</th>
                                        <th>Thu</th>
                                        <th>Fri</th>
                                        <th>Sat</th>
                                        <th>Sun</th>
                                    </tr>
                                </thead>
                                <tbody id="calendar1">
                                </tbody>
                            </table>
                        </div>
                        <!--<a href="#" class="add_new_task">Add new task</a>-->
                    </div>
                </li>
            </ul>

            <ul>
                <li class="new_task"><a id="AddNewTask" href="#item1">Add new task<span></span></a>
                    <ul>
                        <li>
                            <div class="fondo_verde">
                                <div class="grupos de_1">
                                    <div>
                                        <input type="hidden" id="TaskPostId" value="0">
                                        <label class="label white">Time:</label>
                                        <table>
                                            <tr>
                                                <td width="33%">
                                                    <input type="text" id="TaskTimeHour"></td>
                                                <td width="33%">
                                                    <input type="text" id="TaskTimeMinutes"></td>
                                                <td width="33%">
                                                    <div class="wrap_select">
                                                        <select id="TaskTimePeriod">
                                                            <option>AM</option>
                                                            <option>PM</option>
                                                        </select>
                                                    </div>
                                                    <!--wrap_select-->
                                                </td>
                                            </tr>
                                        </table>
                                    </div>

                                    <div>
                                        <label class="label white">Related to: </label>
                                        <input type="text" id="TaskRelatedTo">
                                    </div>

                                    <div>
                                        <label class="label white">Note: </label>
                                        <input type="text" id="TaskNote">
                                    </div>

                                    <!--<div>
                              <div class="grupos">
                                  <div class="float_right">
                                      <div class="boton_wrapper amarillo">
                                          <span class="add"></span>
                                          <input class="boton" type="submit" value="Add">
                                      </div>
                                      
                                      <div class="boton_wrapper rojo">
                                          <span class="equis"></span>
                                          <input class="boton" type="submit" value="Cancel">
                                      </div>
                                  </div>
                              </div>
                            </div>-->

                                    <div>
                                        <div class="float_right">
                                            <input id="calTasksSubmit" class="btn_blue" type="button" value="Add">
                                            <input id="calTasksCancel" class="btn_grey" type="button" value="Cancel">
                                        </div>
                                    </div>
                                </div>
                                <!--grupos-->
                            </div>
                            <!--fondo verde-->


                        </li>
                    </ul>

                    <div id="TasksList" class="fondo_verde">

                        <!--grupos-->
                    </div>
                    <!--fondo verde-->
                </li>
                <!--new_task-->
            </ul>
        </li>

    </ul>
    <!--end ul acordeon-->

</div>



