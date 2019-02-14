function initializePageOnDocReady() {
    setGridStyles();
    setGridStylesPolicies();
    setGridStylesPayments();
    setGridStylesHistory();
    // $("#txtDateFrom").datepicker({ dateFormat: 'dd/mm/yy', minDate: new Date(1999, 10 - 1, 25), maxDate: '0' });
    // $("#txtDateTo").datepicker({ dateFormat: 'dd/mm/yy', maxDate: '0',});
    // $("#ContentSection_rpFilter_txtDateFrom_I").change(function(){validateDates();});
    // $("#ContentSection_rpFilter_txtDateTo_I").change(function(){validateDates();});
    $('#ContentSection_rpFilter_txtDateFrom_I, #ContentSection_rpFilter_txtDateTo_I').keydown(function () {
        return false;
    });
    $("#ContentSection_rpFilter").removeClass();
    $("#ContentSection_rpFilter").css("width", "100%");

    $("#ContentSection_ucSetPoliciesPayments_gvDOPPolicies_DXMainTable").find('[type=checkbox]').change(function () {
        loadingDOP($(this).is(":checked"));
        loadingUSD($(this).is(":checked"));
    });
    $('.helpToolTip').tooltipster({
        iconDesktop: true,
        iconTouch: true,
        position: 'right'
    });
    paymentConfirmation(false);
    paymentCancelModeConfirmation(false);
    ErrorGeneratingReport(false);
    SetDateReport(null);
    var ReportDC = $("#ddlReportsDailyCash");
    ReportDC.change(function () {
        SetDateReport(ReportDC);
    });
    /*
    //For CheckbookInfo
    var ddlBankInfo = $("#ContentSection_ucPaymentMethod_ddlBanksInformation");
    ddlBankInfo.change(function () {
        CallBankInfo(ddlBankInfo.children('option').filter(':selected').text());
    });
    */
}
CallBankInfo = function (bankInfo) {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../Services/Interface.svc/BanksInfo',
        data: { bankName: bankInfo},
        success: function (data) {
            $($.parseJSON(data.d)).each(function (index, value) {
                console.log(value);
            });
        },
        error: function (result) {
            alert(result);
        }
    });
};
function SetDateReport(report) {
    var date = new Date();
    var formattedDate = ('0' + date.getDate()).slice(-2);
    var formattedMonth = ('0' + (date.getMonth() + 1)).slice(-2);
    var formattedYear = date.getFullYear().toString();
    var dateString = new Date(formattedYear, formattedMonth - 1, formattedDate);
    var dateStringBegin = new Date(formattedYear, formattedMonth - 1, 1);
    if (report !== null) {
        switch (report.val()) {
            case "IndividualToday":
            case "BatchToday":
                txtDateTo.SetDate(dateString);
                txtDateFrom.SetDate(dateString);
                $("#ContentSection_rpFilter_txtDateTo_I").attr('disabled', 'disabled');
                break;
            case "IndividualRange":
            case "BatchRange":
                txtDateTo.SetDate(dateString);
                txtDateFrom.SetDate(dateStringBegin);
                $("#ContentSection_rpFilter_txtDateTo_I").removeAttr('disabled');
                break;
            default:
                break;
        }
    }
    else {
        if (typeof txtDateTo !== "undefined" && typeof txtDateFrom !== "undefined") {
            var reportX = $("#ddlReportsDailyCash").val()
            if (reportX === "IndividualToday" || reportX === "IndividualRange") {
                $("#ContentSection_rpFilter_txtDateTo_I").attr('disabled', 'disabled');
            }
            else {
                $("#ContentSection_rpFilter_txtDateTo_I").removeAttr('disabled');
            }
            txtDateTo.SetDate(dateString);
            txtDateFrom.SetDate(dateString);
        }
    }
}

function paymentConfirmation(show) {
    var dlg = $('#confirmation').dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        maxWidth: 600,
        maxHeight: 220,
        width: 600,
        height: 220
    });
    dlg.parent().appendTo(jQuery("form:first"));
    if (show) {
        jQuery('#confirmation').dialog('open');
    }
}

function ErrorGeneratingReport(show) {
    var dlg = $('#errorgenerating').dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        maxWidth: 600,
        maxHeight: 220,
        width: 600,
        height: 220
    });
    dlg.parent().appendTo(jQuery("form:first"));
    if (show) {
        jQuery('#errorgenerating').dialog('open');
    }
}

function paymentCancelModeConfirmation(show) {
    var dlg = $('#cancelConfirmation').dialog({
        autoOpen: false,
        modal: true,
        draggable: false,
        maxWidth: 600,
        maxHeight: 220,
        width: 600,
        height: 220
    });
    dlg.parent().appendTo(jQuery("form:first"));
    if (show) {
        jQuery('#cancelConfirmation').dialog('open');
    }
    else {
        jQuery('#cancelConfirmation').dialog('close');
    }
}

function adecuateIEUI() {
    $('.dxgvCommandColumn.dxgv').closest('td').find('input').each(function () {
        $("<input type='check' />").attr({ id: this.id, style: "opacity:0;width:1px;height:1px;position:relative;background-color:transparent;display:block;margin:0;padding:0;border-width:0;font-size:0pt;", readonly: "readonly" }).insertBefore(this);
    }).remove();
}

function validateDates() {
    var ReportSelected = $("#ddlReportsDailyCash");
    if ($("#ContentSection_rpFilter_txtDateTo_I").val() !== '' && $("#ContentSection_rpFilter_txtDateFrom_I").val() !== '') {
        var date = new Date();
        var formattedDate = ('0' + date.getDate()).slice(-2);
        var formattedMonth = ('0' + (date.getMonth() + 1)).slice(-2);
        var formattedYear = date.getFullYear().toString();
        var dateString = new Date(formattedYear, formattedMonth - 1, formattedDate);

        //DATE SELECTED
        var objSelectedFrom = $("#ContentSection_rpFilter_txtDateFrom_I").val().split("/");
        var SelectedFrom = new Date(objSelectedFrom[2], objSelectedFrom[1] - 1, objSelectedFrom[0]);
        var objSelectedTo = $("#ContentSection_rpFilter_txtDateTo_I").val().split("/");
        var SelectedTo = new Date(objSelectedTo[2], objSelectedTo[1] - 1, objSelectedTo[0]);

        if (ReportSelected.val() === "IndividualToday" || ReportSelected.val() === "BatchToday") {
            txtDateTo.SetDate(SelectedFrom);
        }
        var to = $("#ContentSection_rpFilter_txtDateTo_I").val().split("/");
        toDate = new Date(to[2], to[1] - 1, to[0]);
        var from = $("#ContentSection_rpFilter_txtDateFrom_I").val().split("/");
        fromDate = new Date(from[2], from[1] - 1, from[0]);
        if (toDate < fromDate) {
            SendAlert('La fecha "Hasta" no puede ser menor que la fecha desde.');
            txtDateTo.SetDate(SelectedFrom);
            return;
        }
        if (toDate > new Date()) {
            SendAlert('La fecha "Hasta" no puede ser mayor a la fecha de hoy.');
            txtDateTo.SetDate(dateString);
            return;
        }
        if (fromDate > new Date()) {
            SendAlert('La fecha "Desde" no puede ser mayor a la fecha de hoy.');
            txtDateFrom.SetDate(dateString);
            return;
        }
    }
}
function trimValuesFilter() {
    $("#ContentSection_ucClientSearch_gvClients_DXFREditorcol3_I").change(function () {
        var inpt = $(this);
        inpt.val($.trim(inpt.val()));
        console.log(inpt.val());
    });
}
$(document).ready(function () {
    initializePageOnDocReady();
    trimValuesFilter();
});
var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {
    initializePageOnDocReady();
    trimValuesFilter();
});

//Clients
function grid_SelectionChanged(s, e) {
}
function GetSelectedFieldValuesCallback(value) {

}
function setGridStyles() {
    $('.dx-vam').closest('td').remove();
    $('.dxgvPagerBottomPanel').addClass('paginacion');
    $('.dxeEditArea.dxeEditAreaSys').removeClass('dxeEditAreaSys');
    $('.dxeButton.dxeButtonEditButton img').remove();
    $('.dxeButton.dxeButtonEditButton').addClass('datepicker').addClass('pd12');
    adecuateIEUI();
}
function UserClearConfirmation() {
    return confirm("¿Esta seguro que desea limpiar el formulario?");
}
function loading(isLoading) {
    if (isLoading) {
        $('#parentContainerCollectors').addClass("loading");
    }
    else {
        $('#parentContainerCollectors').removeClass("loading");
    }
}


//Policies
function gridPolicies_SelectionChanged(s, e) {
    s.GetSelectedFieldValues("Policy_No", GetSelectedFieldValuesCallback);
}
function GetSelectedFieldValuesCallback(value) {

}
function EnterEvent(e, ctrl) {
    var keycode = (e.keyCode ? e.keyCode : e.which);
    if (keycode === 13 && ctrl.value.length > 2) {
        return false;
    }
    else {
        return (blockSpecialChar(e));
    }
}
function blockSpecialChar(e) {
    var k = e.keyCode;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || (k >= 48 && k <= 57));
}
function bINT(evt) {
    var value = parseInt((evt.which) ? evt.which : event.keyCode);
    if (value !== 8) {
        if ((value >= 48 && value <= 57) || value === 45 || value === 46) {
            return true;
        }
        else {
            alert('Monto Invalido. Solo acepta valores numéricos.');
            return false;
        }
    }
}
function UserBackConfirmation() {
    return confirm("¿Esta seguro que desea volver atras el formulario (se perderan todos los cambios)?");
}
function setGridStylesPolicies() {
    $('.dx-vam').closest('td').remove();
    $('.dxgvPagerBottomPanel').addClass('paginacion');
    $('.dxeEditArea.dxeEditAreaSys').removeClass('dxeEditAreaSys');
    $('.dxeButton.dxeButtonEditButton img').remove();
    $('.dxeButton.dxeButtonEditButton').addClass('datepicker').addClass('pd12');
}
function SendAlert(msg) {
    setGridStylesPolicies();
    alert(msg);
}
function loadingDOP(isLoading) {
    if (isLoading)
        $('#ContentSection_ucSetPoliciesPayments_DOPPolicies').addClass("loading");
    else
        $('#ContentSection_ucSetPoliciesPayments_DOPPolicies').removeClass("loading");
}
function loadingUSD(isLoading) {
    if (isLoading)
        $('#ContentSection_ucSetPoliciesPayments_USDPolicies').addClass("loading");
    else
        $('#ContentSection_ucSetPoliciesPayments_USDPolicies').removeClass("loading");
}

//Payments 
function setGridStylesPayments() {
    $('.dx-vam').closest('td').remove();
    $('.dxgvPagerBottomPanel').addClass('paginacion');
    $('.dxeEditArea.dxeEditAreaSys').removeClass('dxeEditAreaSys');
    $('.dxeButton.dxeButtonEditButton img').remove();
    $('.dxeButton.dxeButtonEditButton').addClass('datepicker').addClass('pd12');
    loadingHistory(false);
}
function UserCloseConfirmation() {
    return confirm("¿Esta seguro que desea terminar el proceso de la transacción?");
}

//Printing invoice
function PrintElem(elem, content, cssURI) {
    setGridStyles();
    $(elem).html(content);
    Printing($(elem).html(), cssURI);
}
function Printing(data, cssURI) {
    var newWindow = window.open('', 'Factura', 'height=800,width=1200');
    newWindow.document.write(data);
    newWindow.document.close();
    newWindow.focus();
    newWindow.print();
    newWindow.close();
    return true;
}

//Payments methods
function PaymentConfirmation() {
    var ddl = document.getElementById("ddlPaymentForm");
    var paymentMethod = ddl.options[ddl.selectedIndex].value;
    var retorno = false;
    if (paymentMethod.length === 0 && getValueLen("txtAmountToBePaid") === 0) {
        console.log("Error leyendo la forma de pago y/o el monto a pagar.");
        return false;
    }
    switch (paymentMethod) {
        case 'CreditCard':
            if (getValueLen("txtAuthorizationCode") > 0 && getValueLen("txtCreditCardNumber") > 0) {
                retorno = true;
            }
            else {
                alert("Debe completar todos los campos de tarjeta de crédito.");
                return false;
            }
            break;
        case 'Cash':
            if (getValueLen("txtAmountToBePaid") > 0) {
                retorno = true;
            }
            else {
                alert("El campo del monto a pagar, esta vacio, intente nuevamente la transacción.");
                return false;
            }
            break;
        case 'Check':
            if (getValueLen("txtBankCheck") > 0 && getValueLen("txtCheckNumber") > 0 && getValueLen("txtAccountNumberDepTransf") > 0 && getDDLValueLen("ContentSection_ucPaymentMethod_ddlBanksInformation") > 0 && getDDLValueLen("ContentSection_ucPaymentMethod_ddlDepositAccount") > 0) {
                retorno = true;
            }
            else {
                alert("Debe completar todos los campos del pago con cheque.");
                return false;
            }
            break;
        case 'ACH':
            if (getValueLen("txtBankACH") > 0 && getValueLen("txtAccountNumber") > 0 && getValueLen("txtAbaNumber") > 0 && getValueLen("txtAccountOwnerID") > 0 && getValueLen("txtAccountHolder") > 0) {
                retorno = true;
            }
            else {
                alert("Debe completar todos los campos del pago vía ACH.");
                return false;
            }
            break;
        case 'Transfer':
        case 'Deposit':
            if (getValueLen("txtAccountNumberDepTransf") > 0 && getDDLValueLen("ContentSection_ucPaymentMethod_ddlBanksInformation") > 0 && getDDLValueLen("ContentSection_ucPaymentMethod_ddlDepositAccount") > 0) {
                retorno = true;
            }
            else {
                alert("Debe completar todos los campos del pago vía Depósito.");
                return false;
            }
            break;
        default:
            console.log('Error in DDL Payment Method selected.');
            return false;
    }
    loadingHistory(retorno);
    return retorno;
}
function getValueLen(control) {
    return document.getElementById(control).value.length;
}
function getDDLValueLen(controlName) {
    var ddl = document.getElementById(controlName);
    var ddlInfo = ddl.options[ddl.selectedIndex];
    return ddlInfo.value.length;
}

//Payment History
function setGridStylesHistory() {
    $('.dx-vam').closest('td').remove();
    $('.dxgvPagerBottomPanel').addClass('paginacion');
    $('.dxeEditArea.dxeEditAreaSys').removeClass('dxeEditAreaSys');
    $('.dxeButton.dxeButtonEditButton img').remove();
    $('.dxeButton.dxeButtonEditButton').addClass('datepicker').addClass('pd12');
}
function loadingHistory(isLoading) {
    if (isLoading)
        $('#parentContainerCollectors').addClass("loading");
    else
        $('#parentContainerCollectors').removeClass("loading");
}
function loadingHistoryPanel(isLoading, controlName) {
    if (isLoading)
        $(controlName).addClass("loading");
    else
        $(controlName).removeClass("loading");
}
function validateReportValues() {
    if (getDDLValueLen("ContentSection_rpFilter_ddlUsersSecurity") > 0 && getValueLen("ContentSection_rpFilter_txtDateFrom_I") > 0 && getValueLen("ContentSection_rpFilter_txtDateTo_I") > 0)
    {
        loadingHistoryPanel(true, '#ReportContainer');
        return true;
    }
    else {
        alert("Debe completar todos los campos de filtro del reporte.");
        return false;
    }
}
