<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="WEB.ConfirmationCall.UserControls.Common.MyProfile.Calendar" %>

<a href="#"><span></span>
    <h4><%="CALENDARIO" %></h4>
</a>

<ul style="display: block; overflow: hidden;">
    <li class="no_border">
        <ul>
            <li class="no_border">
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
                                    <input type="hidden" name="TpostId" value="0">
                                    <label class="label white">Time:</label>
                                    <table>
                                        <tr>
                                            <td width="3 3%">
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

                  
                </div>
                <!--fondo verde-->
            </li>
            <!--new_task-->
        </ul>
        
    </li>
</ul>
<asp:HiddenField ID="CalendarCurrentDay" runat="server" Value="" ClientIDMode="Static" />