<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUCCallAndVisits.ascx.cs" Inherits="WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits.WUCCallAndVisits" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v14.2, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraScheduler" Assembly="DevExpress.XtraScheduler.v14.2.Core, Version=14.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<div class="grid grid-pad">
    <div class="col-1-1">
        <div class="barra1">
            <div class="grupos de_4">
                <div>
                    <label class="label">First Name</label>
                    <input type="text">
                </div>
                <div>
                    <label class="label">Middle Name</label>
                    <input type="text">
                </div>
                <div>
                    <label class="label">Last Name</label>
                    <input type="text">
                </div>
                <div>
                    <label class="label">2nd LastName</label>
                    <input type="text">
                </div>
            </div>
            <!--grupos de_4-->
        </div>
        <!--barra1-->
    </div>
    <!--col-1-1-->

    <div class="col-1-3">
        <div class="titulos_azules"><span class="insured"></span><strong>CONTACT AND FOLLOW UP</strong></div>
        <div class="fondo_blanco fix_height">
            <div class="content_fondo_blanco">
                <div class="grupos de_2">
                    <div>
                        <label class="label">Task type</label>
                        <div class="wrap_select">
                            <select>
                                <option>Option 1</option>
                                <option>Option 2</option>
                            </select>
                        </div>
                    </div>

                    <div>
                        <table>
                            <tr>
                                <!--este td desaparece al principio y aparecera segun task type-->
                                <td>
                                    <label class="label">Visit type</label>
                                    <div class="wrap_select">
                                        <select>
                                            <option>Option 1</option>
                                            <option>Option 2</option>
                                        </select>
                                    </div>
                                </td>
                                <td style="width: 30%">
                                    <label class="label" style="margin: 0 auto; text-align: center">All day event</label>
                                    <input name="primary" type="checkbox">
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos de_2">
                    <div>
                        <label class="label">From</label>
                        <input type="text" class="datepicker" id="from">
                    </div>
                    <div>
                        <label class="label">To:</label>
                        <input type="text" class="datepicker" id="to">
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos de_1">
                    <div>
                        <label class="label">Subject:</label>
                        <input type="text">
                    </div>
                    <div>
                        <label class="label">Note:</label>
                        <textarea style="height: 202px;"></textarea>
                    </div>
                </div>
                <!--grupos-->

                <div class="grupos">
                    <div>
                        <div class="boton_wrapper rojo">
                            <span class="reminders_icon"></span>
                            <input class="boton" type="submit" value="Add Reminder">
                        </div>
                    </div>
                    <div>
                        <div class="boton_wrapper azul">
                            <span class="follow_up_icon"></span>
                            <input class="boton" type="submit" value="Follow Up">
                        </div>
                    </div>
                    <div class="float_right">
                        <div class="boton_wrapper verde">
                            <span class="save"></span>
                            <input class="boton" type="submit" value="Save">
                        </div>
                    </div>
                </div>
                <!--grupos-->

            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--fondo_blanco-->
    </div>
    <!--col-1-3-->

    <div class="col-2-3">
        <div class="titulos_azules"><span class="calendar_ttle"></span><strong>CALENDAR</strong></div>

        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" OnAppointmentRowInserted="ASPxScheduler1_AppointmentRowInserted" AppointmentDataSourceID="appointmentDataSource">

              <Storage>
                <Appointments>
                    <Mappings AppointmentId="Id" Start="StartTime" End="EndTime" Subject="Subject" AllDay="AllDay"
                        Description="Description" Label="Label" Location="Location" RecurrenceInfo="RecurrenceInfo"
                        ReminderInfo="ReminderInfo" Status="Status" Type="EventType" />
                </Appointments>
            </Storage>

            <Views>
                <WeekView Enabled="false"/>
                <FullWeekView Enabled="true"></FullWeekView>
            </Views>

        </dxwschs:ASPxScheduler>

        <asp:ObjectDataSource ID="appointmentDataSource" runat="server"
            OnObjectCreated="appointmentsDataSource_ObjectCreated"
            TypeName="WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits.CustomEventDataSource"
            DataObjectTypeName="WEB.NewBusiness.NewBusiness.UserControls.Contact.CallAndVisits.CustomEvent"
            InsertMethod="InsertMethodHandler"
            UpdateMethod="UpdateMethodHandler"
            SelectMethod="SelectMethodHandler"
            DeleteMethod="DeleteMethodHandler"></asp:ObjectDataSource>
    </div>
    <!--col-2-3-->

    <div class="col-1-3">
        <div class="titulos_azules"><span class="icon_note_ttle"></span><strong>NEW NOTE</strong></div>
        <div class="fondo_blanco">
            <div class="content_fondo_blanco">
                <div class="grupos de_1">
                    <div>
                        <label class="label">Action date:</label>
                        <asp:TextBox runat="server" ID="txtActionDate" CssClass="datepicker"  />
                    </div>
                    <div>
                        <label class="label">Note:</label>
                        <asp:TextBox runat="server" ID="txtNote" Height="311px" TextMode="MultiLine" />
                    </div>
                    <div>
                        <div class="boton_wrapper verde float_right">
                            <span class="save"></span>
                            <asp:Button runat="server" ID="btnSave" CssClass="boton" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <!--grupos-->
            </div>
            <!--content_fondo_blanco-->
        </div>
        <!--fondo_blanco-->
    </div>
    <!--col-1-3-->

    <div class="col-2-3">
        <div class="titulos_azules"><span class="task_follow"></span><strong>TASK</strong></div>

        <iframe style="height: 208px" src="http://dev.statetrustbank.eu/DevExpress/GridViewDataBindingtoLargeDatabase.aspx"></iframe>

    </div>
    <!--col-2-3-->

    <div class="col-2-3">
        <div class="titulos_azules"><span class="task_follow"></span><strong>FOLLOW UP</strong></div>

        <iframe style="height: 208px" src="http://dev.statetrustbank.eu/DevExpress/GridViewDataBindingtoLargeDatabase.aspx"></iframe>

    </div>
    <!--col-2-3-->

</div>
