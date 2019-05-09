﻿var divLoading = '<div class="loading"></div>';

//var divLoading = '<div class="loading"><div class="imgloading"><img src="/Content/images/loading.gif" alt="Loading" class="img-fluid" /></div></div>';
BeginRequestHandler = function (sender, args) {   
    $(".loading").remove();    
    $("body").append(divLoading);    
};

EndRequestHandler = function (sender, args) {
    $(".loading").remove();
};

function showError(errorList, title) {

    var errorContainer = $("#ppError");
    var errorTitle = $("#errorTitle");
    var errorListContainer = $("#errorListContainer");

    if (title) {
        errorTitle.html(title);
    }

    errorListContainer.empty();
    if (errorList) {
        $.each(errorList, function (item, i) {
            errorListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }
    errorContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function showSucess(sucessList, title, okCallback, OcultarBoton) {

    var sucessContainer = $("#ppSucess");
    var sucessTitle = $("#sucessTitle");
    var sucessListContainer = $("#sucessListContainer");
    var okButton = $('#btnSucessOk');

    if (title) {
        sucessTitle.html(title);
    }

    sucessListContainer.empty();
    if (sucessList) {
        $.each(sucessList, function (item, i) {
            sucessListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }

    if (OcultarBoton == false) {
        $("#RedirectToOtherApp").css("display", "block");
    } else {
        $("#RedirectToOtherApp").css("display", "none");
    }

    //cuando no haya usuario logueado no mostrar el boton de ir a la bandeja
    if ($("#hdnOnlyLoggedUsers").val() === "False" || $("#hdnOnlyLoggedUsers").val() === "false") {
        $("#RedirectToOtherApp").css("display", "none");
    }
    
    okButton.focus();

    if (okCallback) {
        okButton.unbind('click');
        okButton.click(function () {
            sucessContainer.modal('hide');
            okCallback();
        });
    }

    //sucessContainer.modal('show');
    sucessContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function showQuestion(question, title, acceptAction, CancelAction) {

    var questionModalContainer = $("#ppQuestion");
    var questionTitle = $("#questionTitle");
    var questionContainer = $("#questionContainer");
    var okButton = $('#btnQuestionOk');
    var cancelButton = $('#btnQuestionCancel');

    if (title) {
        questionTitle.html(title);
    }

    questionContainer.empty();
    if (question) {
        questionContainer.html(question);
    }

    okButton.off("click");
    okButton.click(function () { questionModalContainer.modal('hide'); acceptAction(); });

    if (typeof CancelAction === "function") {
        cancelButton.off("click");
        cancelButton.click(function () { questionModalContainer.modal('hide'); CancelAction(); });
    } else {
        cancelButton.click(function () { questionModalContainer.modal('hide'); });
    }

    //questionModalContainer.modal('show');
    questionModalContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function number_format(amount, decimals) {

    amount += ''; // por si pasan un numero en vez de un string
    amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

    decimals = decimals || 0; // por si la variable no fue fue pasada

    // si no es un numero o es igual a cero retorno el mismo cero
    if (isNaN(amount) || amount === 0)
        return parseFloat(0).toFixed(decimals);

    // si es mayor o menor que cero retorno el valor formateado como numero
    amount = '' + amount.toFixed(decimals);

    var amount_parts = amount.split('.'),
        regexp = /(\d+)(\d{3})/;

    while (regexp.test(amount_parts[0]))
        amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

    return amount_parts.join('.');
}