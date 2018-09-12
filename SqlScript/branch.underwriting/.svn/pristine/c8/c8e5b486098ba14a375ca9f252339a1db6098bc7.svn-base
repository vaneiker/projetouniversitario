var dialogWarning;
var dialogFailComunication;
var comboxAction;
var textboxReason;
var lblFailComunication;
var dialogFile;
var option = 1;
var selectGridRow = false;

$(document).ready(function () {

    if (document.getElementById("frmMain") != undefined) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    }

    var $dateFrom = $('#bodyContent_UCHeader_txtDateFrom');
    var $dateTo = $('#bodyContent_UCHeader_txtDateTo');


    $dateFrom.change(function () {
        if ($dateTo.val() != "" && ($dateFrom.val() > $dateTo.val())) {
            alertify.alert(MessageFromValidator);
            $dateFrom.val("");
            $dateFrom.text("");
            return false;
        }
        var now = new Date();
        var strNow = (("0" + (now.getMonth() + 1)).slice(-2)) + "/" + (("0" + (now.getDate())).slice(-2)) + "/" + now.getFullYear();

        if ($dateFrom.val() > strNow) {
            alertify.alert(MessageDateValidator);
            $dateFrom.val("");
            $dateFrom.text("");
            return false;
        }

    });


    $dateTo.change(function () {
        if ($dateFrom.val() != "" && ($dateTo.val() < $dateFrom.val())) {
            alertify.alert(MessageToValidator);
            $dateTo.val("");
            $dateTo.text("");
            return false;
        }
        var now = new Date();
        var strNow = (("0" + (now.getMonth() + 1)).slice(-2)) + "/" + (("0" + (now.getDate())).slice(-2)) + "/" + now.getFullYear();

        if ($dateTo.val() > strNow) {
            alertify.alert(MessageDateValidator);
            $dateTo.val("");
            $dateTo.text("");
            return false;

        }

    });


});


function BeginRequestHandler(sender, args) {
    $("#bodyContent_UCHeader_txtDateFrom").datepicker({ minDate: new Date(2012, 1 - 1, 1) });
    $('#loading').show();
}

function EndRequestHandler(sender, args) {
    $('#loading').hide();

    if ($("#bodyContent_UCAddress_DrpCountry :selected").text().trim().toUpperCase() == "GUATEMALA") {
        $("#ConfirmAddGuatemala").css("display", "block");
    } else {
        $("#ConfirmAddGuatemala").css("display", "none");
    }

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

    if ($("#hdnShowPopAttachCall").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopUCAttachCall",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "ADJUNTAR LLAMADA",
            pmodal: true,
            presizable: false,
            OnCLose: function () {


                $("#hdnShowPopAttachCall").val("false");
            }

        });
    } else {
        initializatePopupsAndClose("#dvPopUCAttachCall");
    }

    //if ($("#bodyContent_UCAddress_DrpCountry :selected").text().trim().toUpperCase() == "GUATEMALA") {

    //    $("#bodyContent_UCAddress_ConfirmAddGuatemala").css("display", "block");
    //} else {
    //    $("#bodyContent_UCAddress_ConfirmAddGuatemala").css("display", "none");
    //}

    //$("#bodyContent_UCAddress_DrpCountry").change(function () {
    //    if ($("#bodyContent_UCAddress_DrpCountry :selected").text().trim().toUpperCase() == "GUATEMALA") {

    //        $("#bodyContent_UCAddress_ConfirmAddGuatemala").css("display", "block");
    //    } else {
    //        $("#bodyContent_UCAddress_ConfirmAddGuatemala").css("display", "none");
    //    }

    //});


    //--------------------------------dialog-------------------------------------//
    $(function () {

        dialogWarning = $("#dialog-form");
        comboxAction = $("#drpAction");
        textboxReason = $("#TxtReason");
        dialogFailComunication = $('#dialog-form-faild');
        dialogFile = $('#dialog-file');

        lblFailComunication = $('#lblFailComunication');

        dialogWarning.dialog({
            resizable: false,
            autoOpen: false,
            height: 235,
            width: 450,
            modal: true,
            open: function (type, data) {
                dialogWarning.parent().appendTo("form");
            }
        });
        //
        dialogFailComunication.dialog({
            resizable: false,
            autoOpen: false,
            height: 120,
            width: 450,
            modal: true,
            open: function (type, data) {
                dialogFailComunication.parent().appendTo("form");
            }
        });
        //

        dialogFile.dialog({
            resizable: false,
            autoOpen: false,
            height: 500,
            width: 800,
            modal: true,
            cache: false,
            open: function (type, data) {
                dialogFailComunication.parent().appendTo("form");
            }
        });


        //
        comboxAction.change(function () {
            var optionSelected = comboxAction.find("option:selected");
            var textSelected = optionSelected.text();
            dialogWarning.dialog('option', 'title', textSelected);
            dialogFailComunication.dialog('option', 'title', textSelected);
        });
    });
    //--------------------------------dialog-------------------------------------//

    $(function () {

        ///inputValida #bodyContent_UCSecurityQuestions_GrdPreguntas input.dxeEditArea_DevEx.dxeEditAreaSys
        $("input[class='inputValida']").keydown(function (event) {
            var key = event.keyCode || event.which;
            
            if (key == 16) {
                return;
            }

            if (key == 13) {
                event.preventDefault();
            }
            if (key >= 65 && key <= 105 || key == 8 || key == 32 || key == 111 || 16) {
                return true;
            } else {
                return false;
            }
           
        });

    });

   // $(".dxp-lead.dxp-summary").text($("#hdnNoDataToPaginate").val());

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
    selectGridRow = true;
    document.getElementById("hdnGridIndexRow").value = e.visibleIndex;
    document.getElementById("btnSelectRow").click();

}


function selectRowS(s, e) {
    document.getElementById("hdnGridIndexRows").value = e.visibleIndex;
    document.getElementById("btnSelectRows").click();

}

ChangeTab = function (Tab, Menu) {

    //Limpiar
    $("#" + Menu + " li").removeClass("active");

    vTab = $('#' + Tab);

    $(vTab).parent().addClass("active");
};

function CloseUCAttachCall() {
    $("#hdnShowPopAttachCall").val("false");
}


function isEmail(Email) {
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!filter.test(Email))
        return false;
    else
        return true;
}
//
function validateEmail() {
    var txtEmail = document.getElementById('TxtEmailAaddress');
    var isValid = isEmail(txtEmail.value);
    if (!isValid) {
        if (!txtEmail.value || 0 === txtEmail.value.length) {
            alertify.alert('Field email is required.');
        } else {
            alertify.alert('Field email is invalid.');
        }
    }
    return isValid;
}

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

//
function popup_ShownS(s, e) {
    popup2.Show();
}
//

function btnCancel_Click() {
    dialogWarning.dialog("close");
    return false;
}

function btnNo_Click() {
    dialogFailComunication.dialog("close");
    $('#hfYesOrNo').val('No');
    return true;
}


function onSubmit_Click() {
    //
    //if (selectGridRow == false) { return false; }
    var comboText = comboxAction.find("option:selected").text();
    var comboValue = comboxAction.find("option:selected")[0].value;

    dialogWarning.removeAttr('title');
    dialogWarning.attr('title', comboText);
    var verify = false;

    //
    if (comboValue == "8") {
        dialogWarning.dialog("open");
        return false;
    } else if (comboValue == "1" | comboValue == "2" | comboValue == "3" |
        comboValue == "4" | comboValue == "5") {
        var msg = document.getElementById("bodyContent_hfApplyStatus").value;
        lblFailComunication.html('');
        lblFailComunication.html(msg);
        dialogFailComunication.dialog('open');
        return false;
    } 
    return true;
}
//
function onBtnOK_Click() {
    if (!textboxReason.val() || textboxReason.val().length == 0) {
        alertify.alert('Field Reason is required.');
        return false;
    } else {k
        dialogWarning.dialog("close");
    }
    return true;
}
//=======
function btnPopupCancel_Click() {
    popup2.Hide();
}

function onBtnYes_Click() {
    var msg = document.getElementById("bodyContent_hfSendEmailClient").value;
    lblFailComunication.html('');
    lblFailComunication.html(msg);
    if ($('#hfYesOrNo').val() == "Yes") {
        if (option == 2) {
            dialogFailComunication.dialog("close");
            option = 1;
            return true;
        }
        option++;
    } else {
        option = 1;
        dialogFailComunication.dialog("close");
        $('#hfYesOrNo').val('No');
        return true;
    }
    return false;
}


function CallOtherWindow() {
    var name = document.getElementById("bodyContent_UCAttachment_hfPathFile").value;
    //var obj = $('#bodyContent_UCAttachment_IfDocuments')[0];
    //document.getElementById("iframeShowDocument").src = "";
    //document.getElementById("iframeShowDocument").src = ruta;
    dialogFile.dialog("open");
    return true;
}
//

function fnConfirmacion() {
    var msg = document.getElementById("hfMensaje").value;
    return confirm(msg);
}
//
function CalculateItbis(val) {
    var result = 0;

    var valor = val.replace(/,/g, "");
    var Tax = document.getElementById("HDFItbis");
    var itbis = parseFloat(Tax.value);

    var valorcal = parseFloat(valor);

    result = valorcal * itbis;

    return result;
}


function ValItbis(valor) {
    var SelectiveTax = document.getElementById("txtSelectiveTax");

    if (SelectiveTax != null)
        SelectiveTax.value = CalculateItbis(valor.toString());
}

function CalculateAnnualPrimium(PeriodicPremiumvalue, ddlFrequencyvalue) {
    var periodicpremium = parseFloat(PeriodicPremiumvalue.replace(/,/g, ""));
    var HDFMultiploAnual = document.getElementById("HDFMultiploAnual");
    var MultiploAnual = parseFloat(HDFMultiploAnual.value);

    var annualPremium = 0;

    switch (ddlFrequencyvalue) {
        case "1"://Trimestral
            annualPremium = (periodicpremium * 4) - ((periodicpremium * 4) * MultiploAnual);
            break;
        case "2"://Mensual
            annualPremium = (periodicpremium * 12) - ((periodicpremium * 12) * MultiploAnual);
            break;
        case "3"://Anual
            annualPremium = (periodicpremium * 1) - ((periodicpremium * 1) * MultiploAnual);
            break;
        case "4"://Semestral
            annualPremium = (periodicpremium * 2) - ((periodicpremium * 2) * MultiploAnual);
            break;
    }

    return annualPremium;
}

function GetAnnualPremium(PeriodicPremiumvalueID, ddlFrequencyID) {
    var txtAnnualPremium = document.getElementById('txtAnnualPremium');
    var txtAnnualPremiumWithTax = document.getElementById('txtAnnualPremiumWithTax');

    var frequency = document.getElementById(ddlFrequencyID);
    var periodicpremium = document.getElementById(PeriodicPremiumvalueID)


    var TatalAnualpremium = 0.00;
    if (frequency != null && periodicpremium != null) {
        var PeriodicPremiumvalue = periodicpremium.value;
        var ddlFrequencyvalue = frequency.value;
        TatalAnualpremium = CalculateAnnualPrimium(PeriodicPremiumvalue.toString(), ddlFrequencyvalue);
    }

    ValItbis(TatalAnualpremium);

    if (txtAnnualPremium != null && txtAnnualPremiumWithTax != null) {
        txtAnnualPremium.value = TatalAnualpremium.toString();
        txtAnnualPremiumWithTax.value = TatalAnualpremium + CalculateItbis(TatalAnualpremium.toString());
    }
}


