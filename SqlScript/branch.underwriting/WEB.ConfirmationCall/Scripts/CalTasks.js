window.calTasks = {};

function renderCalendar(today) {
    var calendarHTML = "";
    var thisDay = today.getDate();
    var firstDay = new Date(today.getFullYear(), today.getMonth(), 1);
    var startDay = firstDay.getDay();
    var eDay = new Date(today.getFullYear(), today.getMonth() + 1, 0);
    var PMeDay = new Date(today.getFullYear(), today.getMonth(), 0);
    var year = eDay.getYear() + 1900;
    if (((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0)) {
        nDays = 29;
    } else {
        nDays = eDay.getDate();
    }
    year = PMeDay.getYear() + 1900;
    if (((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0)) {
        PMnDays = 29;
    } else {
        PMnDays = PMeDay.getDate();
    }
    column = 0;
    endDay = (startDay - 1);
    if (startDay > 1) {
        count = PMnDays - (endDay - 1);
    } else {
        if (startDay === 0) {
            count = PMnDays - 6;
            endDay = 6;
        } else {
            count = PMnDays - 7;
            endDay = 7;
        }
    }
    for (i = 1 ; i <= endDay; i++) {
        if (column === 0) {
            calendarHTML = calendarHTML + '<tr>';
        }
        calendarHTML = calendarHTML + '<td class="off"><a href="#" class="cal_BCP">' + count + '</a></td>';
        count++;
        column++;
        if (column === 7) {
            calendarHTML = calendarHTML + '</tr>';
            column = 0;
        }
    }
    for (i = 1; i <= nDays; i++) {
        if (column === 0) {
            calendarHTML = calendarHTML + '<tr>';
        }
        if (i == thisDay) {
            calendarHTML = calendarHTML + '<td class="active"><a href="#" class="cal_BC">' + i + '</a></td>';
        } else {
            calendarHTML = calendarHTML + '<td><a href="#"class="cal_BC">' + i + '</a></td>';
        }
        column++;
        if (column === 7) {
            calendarHTML = calendarHTML + '</tr>';
            column = 0;
        }
    }
    endDay = 7 - column;
    for (i = 1 ; i <= endDay; i++) {
        if (column === 0) {
            calendarHTML = calendarHTML + '<tr>';
        }
        calendarHTML = calendarHTML + '<td class="off"><a href="#" class="cal_BCN">' + i + '</a></td>';
        column++;
        if (column === 7) {
            calendarHTML = calendarHTML + '</tr>';
            column = 0;
        }
    }

    $('#calHeader').html(today.format("MMMM yyyy"));
    $('#calendar1').html(calendarHTML);
    $('#CalendarCurrentDay').val(today);

    jQuery.support.cors = true;
    $.ajax({
        url: '../api/Task/' + today.format("yyyy-MM-dd"),
        type: 'GET',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            //console.log(data);
            window.calTasks = data;
            renderTasks();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    controlerCalendar();

    $('#TaskPostId').val('0');
    $('#TaskTimeHour').val('');
    $('#TaskTimeMinutes').val('');
    $('#TaskTimePeriod').val('');
    $('#TaskRelatedTo').val('');
    $('#TaskNote').val('');
}

function renderTasks() {
    var taskListHTML = "";

    for (var i in window.calTasks) {
        rDate = new Date(window.calTasks[i].Date);
        taskListHTML = taskListHTML + '<div class="grupos de_1"><div><table>';
        taskListHTML = taskListHTML + '<tr><td width="" class="textbold">Reminder Date:</td><td>' + rDate.format("dd-MM-yyyy") + '</td></tr>';
        taskListHTML = taskListHTML + '<tr><td class="textbold">Time:</td><td>' + window.calTasks[i].TimeHour + ':' + window.calTasks[i].TimeMinutes + ' ' + window.calTasks[i].TimePeriod + '</td></tr>';
        taskListHTML = taskListHTML + '<tr><td class="textbold">Related to:</td><td>' + window.calTasks[i].RelatedTo + '</td></tr>';
        taskListHTML = taskListHTML + '<tr><td class="textbold">Note:</td><td>' + window.calTasks[i].Note + '</td></tr>';
        taskListHTML = taskListHTML + '</table></div><div><div class="float_right"><input id="calTasksEdit' + i + '" class="btn_edit" type="button" /></div></div></div>';
        //console.log(JSON.stringify(Tasks[i]));
    }
    $('#TasksList').html(taskListHTML);
    for (var i in window.calTasks) {
        $('#calTasksEdit' + i).click(calTasksEditClick);
    }

    var TasksCount = (isNaN($("#TasksList .grupos.de_1").length || $("#TasksList .grupos.de_1").length == null) ? 0 : $("#TasksList .grupos.de_1").length);
    $("#btnCantidadTask").val(TasksCount);
    $("#btnCantidadTask").text(TasksCount);

}

function controlerCalendar() {
    $('.cal_BCP').one("click", function () {
        var today = new Date($('#CalendarCurrentDay').val());
        renderCalendar(new Date(today.getFullYear(), today.getMonth() - 1, $(this).html()));
    });

    $('.cal_BC').one("click", function () {
        var today = new Date($('#CalendarCurrentDay').val());
        renderCalendar(new Date(today.getFullYear(), today.getMonth(), $(this).html()));
    });

    $('.cal_BCN').one("click", function () {
        var today = new Date($('#CalendarCurrentDay').val());
        renderCalendar(new Date(today.getFullYear(), today.getMonth() + 1, $(this).html()));
    });
}

function calTasksEditClick(e) {
    console.log(window.calTasks[e.currentTarget.id.replace("calTasksEdit", "")]);
    Task = window.calTasks[e.currentTarget.id.replace("calTasksEdit", "")];
    $('#TaskPostId').val(Task.CallMeetingId);
    $('#TaskTimeHour').val(Task.TimeHour);
    $('#TaskTimeMinutes').val(Task.TimeMinutes);
    $('#TaskTimePeriod').val(Task.TimePeriod);
    $('#TaskRelatedTo').val(Task.RelatedTo);
    $('#TaskNote').val(Task.Note);

    $('#AddNewTask').click();
}

$(document).ready(function () {



    $('#calPrev').click(function () {
        var today = new Date($('#CalendarCurrentDay').val());
        renderCalendar(new Date(today.getFullYear(), today.getMonth(), 0));
    });

    var today = new Date();
    $('#calToday').html(today.format("MMMM") + "<span>" + today.format("dd") + "</span>");
    $('#calTodayBtn').click(function () {
        renderCalendar(new Date());
    });

    $('#calNext').click(function () {
        var today = new Date($('#CalendarCurrentDay').val());
        renderCalendar(new Date(today.getFullYear(), today.getMonth() + 2, 0));
    });

    renderCalendar(new Date());

    $('#calTasksSubmit').click(function () {
        var today = new Date($('#CalendarCurrentDay').val());
        $.post('../api/Task', {
            CorpId: 1,
            ContactId: 1,
            CallMeetingId: $('#TaskPostId').val() === undefined ? 0 : $('#TaskPostId').val(),
            Date: today.format("yyyy-MM-dd"), //(today.getFullYear() + '-' + today.getMonth() + '-' + today.getDate()),
            TimeHour: $('#TaskTimeHour').val(),
            TimeMinutes: $('#TaskTimeMinutes').val(),
            TimePeriod: $('#TaskTimePeriod').val(),
            RelatedTo: $('#TaskRelatedTo').val(),
            Note: $('#TaskNote').val()
        }).done(function () {
            //alert("Success");
            console.log({
                CorpId: 1,
                ContactId: 1,
                CallMeetingId: $('#TaskPostId').val() === undefined ? 0 : $('#TaskPostId').val(),
                Date: today.format("yyyy-MM-dd"), //(today.getFullYear() + '-' + today.getMonth() + '-' + today.getDate()),
                TimeHour: $('#TaskTimeHour').val(),
                TimeMinutes: $('#TaskTimeMinutes').val(),
                TimePeriod: $('#TaskTimePeriod').val(),
                RelatedTo: $('#TaskRelatedTo').val(),
                Note: $('#TaskNote').val()
            });
            renderCalendar(new Date($('#CalendarCurrentDay').val()));
        }).fail(function (result) {
            console.log(result);
        });

        return false;
    });
    $('#calTasksCancel').click(function () {
        $('#TaskPostId').val("");
        $('#TaskTimeHour').val("");
        $('#TaskTimeMinutes').val("");
        $('#TaskTimePeriod').val("");
        $('#TaskRelatedTo').val("");
        $('#TaskNote').val("");

        $('#AddNewTask').click();
        return false;
    });

    $("#btnCantidadTask").mouseover(function () {
        OnMoreCountTasksOver(this, $("#hdnMensajeToolTipCountTasks").val());
    });
     
    $("#btnCantidadTask").mouseout(function () {
        popup_HideMaster();
    });
    
});

var keyValue;
function OnMoreCountTasksOver(element, key) {
    callbackPanel.SetContentHtml("");
    popup.ShowAtElement(element);
    keyValue = key;
    popup.SetHeaderText("Info");

    var top = $("#btnCantidadTask").offset().top;
    popup.ShowAtPos(33, top);
   
    
  
}
function popup_Shown(s, e) {
    callbackPanel.PerformCallback(keyValue);
}
//
function popup_HideMaster(s, e) {
 popup.Hide();
}

