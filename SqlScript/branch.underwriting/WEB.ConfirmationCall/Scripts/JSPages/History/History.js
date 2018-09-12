$(document).ready(function () {

    if (document.getElementById("frmMain") != undefined) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    }


});

function BeginRequestHandler() {
    $('#loading').show();
}

function EndRequestHandler(sender, args) {
    $('#loading').hide();
    CountryTimeConfig();
}

function pageLoad() {
    ConfigSystem();
    ConfigureLanguage();
    //Cambiar de Tab
    var CurrentTabLeft = $("#hfSelectTABLeft").val();
    var CurrentTabRight = $("#hfSelectTABRight").val();
    var CurrentTabHeader = $("#hfSelectHeaderTAB").val();

    ChangeTab(CurrentTabLeft, "MenuTabsLeft");
    ChangeTab(CurrentTabRight, "MenuTabsRight");
    ChangeTab(CurrentTabHeader, "MenuHeader");

    $(".dxp-lead.dxp-summary").each(function (index) {

        if ($(this).text() == "No data to paginate") {
            $(this).text($("#hdnNoDataToPaginate").val());
        }

        else {
            if ($("#hdnLang").val() == "es") {
                $(this).text($(this).text().replace("Page", "Página").replace("of", "de").replace("items", "filas"));
            }

        }

    });


}

$(document).ready(function () {
    $("table.hiderow tbody tr").click(function () {
        var str = $(this).closest("tr").siblings();
        if (str.hasClass("highlighted2")) {
            str.removeClass("highlighted2")
        } else {

            str.addClass("highlighted2")
            $(this).toggleClass();
        }
    })
    CountryTimeConfig();
});

function CountryTimeConfig() {
    var d = new Date();
    var TimeZone = parseFloat($("#hdnCurrentCountryTime").val());
    var utc = new Date(d.getUTCFullYear(), d.getUTCMonth(), d.getUTCDate(), d.getUTCHours(), d.getUTCMinutes(), d.getUTCSeconds());
    timestamp = new Date(utc.getTime() + (3600000 * TimeZone));
    $("#lblPolicyCountryTime").clock({ "format": "12", "calendar": "false", "timestamp": timestamp });
}

function selectRow(s, e) {
    document.getElementById("hdnGridIndexRow").value = e.visibleIndex;
    document.getElementById("btnSelectRow").click();
}

ChangeTab = function (Tab, Menu) {

    //Limpiar
    $("#" + Menu + " li").removeClass("active");

    vTab = $('#' + Tab);

    $(vTab).parent().addClass("active");
};



var keyValue;
function OnMoreInfoClick(element, key) {
    callbackPanel.SetContentHtml("");
    popup.ShowAtElement(element);
    //popup.ShowAtPos(200, 200);
    //popup.SetSize(100, 150);
    keyValue = key.replace(/(\\)/gm, "</br>");
}
function popup_Shown(s, e) {
    callbackPanel.PerformCallback(keyValue);
}
//
function popup_Hide(s, e) {
    popup.Hide();
}

function drpAction_SelectedIndexChanged(s, e) {
    if (s == 8) {
        popup_ShownS();
    }
}



function popup_ShownS(s, e) {
    popup2.Show();
}


