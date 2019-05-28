var divLoading = '<div class="loading"></div>';


BeginRequestHandler = function (sender, args) {
    $(".loading").remove();
    $("body").append(divLoading);
};

EndRequestHandler = function (sender, args) {
    $(".loading").remove();
};

function InitializeSelect2() {

    $('.dropdown').select2({
        theme: "bootstrap",
        allowClear: true,
        minimumResultsForSearch: 10,
        width: "95%",
        language: {
            noResults: function (params) {
                return "No se han encontrado resultados.";
            }
        }
    });
}



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



function cleanFields() {

    $(".toclean").each(function (id, obj) {
        $(obj).val("");
    });

    $(".tocleanDrop").each(function (id, obj) {
        $(obj).val("");
        $(obj).trigger("change");
    });
}


function createCookie(name, value, days) {
    var expires;

    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    } else {
        expires = "";
    }
    document.cookie = encodeURIComponent(name) + "=" + encodeURIComponent(value) + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = encodeURIComponent(name) + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === ' ')
            c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0)
            return decodeURIComponent(c.substring(nameEQ.length, c.length));
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
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