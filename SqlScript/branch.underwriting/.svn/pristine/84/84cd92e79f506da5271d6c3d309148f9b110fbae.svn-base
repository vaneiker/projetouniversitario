
var url;
var now;
var parts;
var ctrlname;
var urlparts;
var urlname;
var time;
var twoDigitMonth;
var currentDate;
var cudate;
var gelolamento;
var stringctrl;
var stringurl;
var $geSecurityMatters;
var $geSecurityMattersApp;
var goTracking;
$(document).ready(function () {

    $("#SecLogOut").click(function () {
        goLogOut = {
            SecurityMatters: $geSecurityMatters.val(),
            SecurityMattersApp: $geSecurityMattersApp.val()
        };


        //console.log(goTracking);
        calllogout();
    });

    $geSecurityMatters = $('#hiddSecurityMatters');
    $geSecurityMattersApp = $('#hiddSecurityMattersapp');

    $('input,a').click(function () {

        url = window.location.protocol + "//" + (window.location.host + "/" + window.location.pathname).replace("//", "/");
        gelolamento = $(this).is("a") ? $(this).attr("id") : this.name;

        parts = gelolamento.split("$");
        urlparts = url.split("/");

        now = new Date();
        time = now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
        twoDigitMonth = ((now.getMonth().length + 1) === 1) ? (now.getMonth() + 1) : '0' + (now.getMonth() + 1);
        currentDate = now.getFullYear() + "-" + twoDigitMonth + "-" + now.getDate() + ' ' + time;
        //validacion url pagina
        if (urlparts.length <= 0) {
            urlname = 'Wrong';
        } else {
            urlname = urlparts[urlparts.length - 1];
        }
        //validacion url pagina
        if (parts.length <= 0) {
            ctrlname = 'Wrong';
        } else {
            ctrlname = parts[parts.length - 1];
        }

        goTracking = {
            StringCtrl: ctrlname,
            StringUrl: urlname,
            Cudate: currentDate,
            SecurityMatters: $geSecurityMatters.val(),
            SecurityMattersApp: $geSecurityMattersApp.val()
        };
        //console.log(goTracking);
        callTrack();
    });



    $(".dropdown img.flag").addClass("flagvisibility");

    $(".dropdown dt a").click(function () {
        $(".dropdown dd ul").toggle();
    });
    function getSelectedValue(id) {
        return $("#" + id).find("dt a span.value").html();
    }

    $(document).bind('click', function (e) {
        var $clicked = $(e.target);
        if (!$clicked.parents().hasClass("dropdown"))
            $(".dropdown dd ul").hide();
    });


    $("#flagSwitcher").click(function () {
        $(".dropdown img.flag").toggleClass("flagvisibility");
    });

    //log out desde modulo seguridad




});

window.onbeforeunload = function () {
    //      if (window.location.pathname == url) {
    if (url == window.location.protocol + "//" + (window.location.host + "/" + window.location.pathname).replace("//", "/")) {
        callTrack();

    }
    else if (urlparts != null) {
        if (window.location.toString().indexOf(urlparts[1]) != -1) {
            callTrack();
        }
    } else {
        goLogOut = {
            SecurityMatters: $geSecurityMatters.val(),
            SecurityMattersApp: $geSecurityMattersApp.val()
        };
        calllogout();
    }
};



function callTrack() {

    var data = '{tracking:"' + JSON.stringify(goTracking).replace(/"/g, '\'') + '"}';
    var CurrentURL = window.location.protocol + "//" + (window.location.host + "/" + window.location.pathname).replace("//", "/");
    // console.log('O.K.');
    $.ajax({
        url: CurrentURL + '/SaveTracking',
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: data,
        success: function (response) {
            var a = '';
        },
        error: function (jqXHR, textStatus, errorThrown) { }
    });
}

function calllogout() {
    var CurrentURL = window.location.protocol + "//" + (window.location.host + "/" + window.location.pathname).replace("//", "/");
    var dato = '{logout:"' + JSON.stringify(goLogOut).replace(/"/g, '\'') + '"}';

    //console.log('K.O.');
    $.ajax({
        url: CurrentURL + '/SaveLogOut',
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        cache: false,
        data: dato,
        success: function (response) {
            			window.location.assign(response.d); 

        },
        error: function (jqXHR, textStatus, errorThrown) { }
    });
}

















/*****************************/

//$(document).ready(function () {
//    var url;
//    var now;
//    var parts;
//    var ctrlname;
//    var urlparts;
//    var urlname;
//    var time;
//    var twoDigitMonth;
//    var currentDate;
//    var cudate;
//    var gelolamento;
//    var stringctrl;
//    var stringurl;

//    $(':input').click(function () {

//        var goTracking;
//        gelolamento = this.name;
//        url = window.location.pathname;
//        now = new Date();
//        time = now.getHours() + ':' + now.getMinutes() + ':' + now.getSeconds();
//        twoDigitMonth = ((now.getMonth().length + 1) === 1) ? (now.getMonth() + 1) : '0' + (now.getMonth() + 1);
//        currentDate = now.getDate() + "/" + twoDigitMonth + "/" + now.getFullYear() + ' ' + time;
//        parts = gelolamento.split("$");
//        urlparts= url.split("/");

//        if (urlparts.length <= 0) {
//            urlname = 'Wrong';
//        } else {
//            urlname = urlparts[urlparts.length - 1];
//        }


//        if (parts.length <= 0) {
//            ctrlname = 'Wrong';
//        } else {
//            ctrlname = parts[parts.length - 1];
//        }


//        goTracking = {

//            stringctrl: ctrlname.toString(),
//            stringurl: urlname.toString(),
//            cudate: currentDate.toString()

//        }





//        console.log(goTracking);

//    });


