var changeLanguage = function (languageId) {

    var returnUrl = '';

    if (typeof (getReturnUrlAfterLanguageChange) == 'function')
        returnUrl = getReturnUrlAfterLanguageChange();
    else
        returnUrl = window.location;

    $.ajax({
        url: "/Home/Change_Language",
        data: {
            languageId: languageId
        },
        success: function (data) {
            window.location = returnUrl;
        }
    });
}

var stl_Business_Line = {
    1: {
        id: 'Auto',
        Telephone: '+1 (809) 565-5591',
        Email: 'servicios@atlantica.do'
    },
    2: {
        id: 'Salud',
        Telephone: '+1 (844) 822-7262',
        Email: 'servicios@atlanticmed.com'
    },
    3: {
        id: 'Vida',
        Telephone: '+1 (809) 200-5591',
        Email: 'servicios@atlantica.do'
    },
    4: {
        id: 'Lineas Comerciales',
        Telephone: '+1 (809) 565-5591',
        Email: 'servicios@atlantica.do'
    },
    5: {
        id: 'Vivienda',
        Telephone: '+1 (809) 565-5591',
        Email: 'servicios@atlantica.do'
    }
}

//function ChangeContactInformation(e) {
//    var OptionSelected = $(e).val();
//    $('#Telephone').text(stl_Business_Line[OptionSelected].Telephone);
//    $('#Email').text(stl_Business_Line[OptionSelected].Email);
//}

function ChangeContactInformation(id) {
    var OptionSelected = id;
    $('#Telephone').text(stl_Business_Line[OptionSelected].Telephone);
    $('#Email').text(stl_Business_Line[OptionSelected].Email);
}

function roundToTwoDecimals(num) {
    return +(Math.round(num + "e+2") + "e-2");
}

/*BOTONES*/
var getJsonFailAlert = function (jqxhr, textStatus, error) {
    var err = textStatus + ", " + error;
    alert("Request Failed: " + err);
};

var getServerCurrentDate = function (callback) {
    $.getJSON("/Home/GetServerDate", function (data) {
        if (callback)
            callback(data);
    }).fail(getJsonFailAlert);
}

function showError(errorList, title, message, outCallback) {
    if (errorList.length > 0) {
        var errorContainer = $('#errorContainer');
        var errorListContainer = $('#errorList');
        var errorMessagePar = $('#errorMessage');
        var closeButton = $('#popupError > div > button');
        errorListContainer.empty();
        _.each(errorList, function (item) {
            errorListContainer.append('<li>' + item + '</li>');
        });

        if (title)
            $('#errorTitle').html(title);

        if (message) {
            errorMessagePar.html(message);
            errorMessagePar.show();
        }
        else
            errorMessagePar.hide();
        closeButton.focus();
        errorContainer.show();
        if (outCallback)
            closeButton.unbind('click');
        closeButton.click(function () {

        })
    }
}

function showErrorAuto(title, message, errorList, successCallback) {
    var successContainer = $('#errorAutoContainer');
    var successTitle = $('#errorAutoTitle');
    var successMessage = $('#errorAutoMessage');
    var successListContainer = $('#errorAutoList');
    var successBtn = $('#successContainerOkButton');

    successTitle.text(title);
    successMessage.text(message);

    successListContainer.empty();
    if (errorList) {
        _.each(errorList, function (item, i) {
            successListContainer.append('<tr><td align="center" class="c1">' + item + '</td></tr>');
        });
    }

    if (successCallback)
        successBtn.click = function () {
            successCallback();
            $('#successContainer').hide();
        };

    successContainer.show();
}

function showSuccess(title, message, list, showGratitud, okCallback, OcultarBoton) {
    var successContainer = $('#successContainer');
    var successTitle = $('#successTitle');
    var successMessage = $('#successMessage');
    var successListContainer = $('#successList');
    var successGratitud = $('#successGratitud');
    var okButton = $('#successContainer > div > div.mT20 > button');

    successTitle.text(title);
    successMessage.text(message);

    successListContainer.empty();
    if (list) {
        _.each(list, function (item, i) {
            successListContainer.append('<tr><td align="center" class="c1">' + item + '</td></tr>');
        });
    }

    if (OcultarBoton != true) {
        $("#RedirectToOtherApp").css("display", "none");
    }

    okButton.focus();

    if (okCallback) {
        okButton.click(function () {
            $('#successContainer').hide();
            okCallback();
        });
    }

    successContainer.show();
    if (showGratitud)
        successGratitud.show();
    else
        successGratitud.hide();
}

function showSuccessCallback(title, message, okCallback) {
    var successContainer = $('#successContainer');
    var successTitle = $('#successTitle');
    var successMessage = $('#successMessage');
    var successListContainer = $('#successList');
    var successGratitud = $('#successGratitud');
    var okButton = $('#successContainer > div > div.mT20 > button');
    successTitle.text(title);
    successMessage.text(message);
    successListContainer.empty();

    okButton.focus();
    okButton.unbind('click');
    okButton.click(okCallback);
    successContainer.show();

}

function showQuestion(title, question, acceptAction, CancelAction) {
    var questionContainer = $('#questionContainer');
    var questionTitle = $('#questionTitle');
    var questionMessage = $('#questionMessage');
    var questionAccept = $('#questionAccept');
    questionCancel = $('#questionCancel');

    questionTitle.text(title);
    questionMessage.text(question);

    questionAccept.off("click");
    questionAccept.click(function () { questionContainer.hide(); acceptAction(); });

    if (typeof CancelAction === "function") {
        questionCancel.click(function () { questionContainer.hide(); CancelAction(); });
    } else {
        questionCancel.click(function () { questionContainer.hide(); });
    }
    questionContainer.show();
}

function showWarning(warningList, title, message, outCallback) {
    if (warningList.length > 0) {
        var warningContainer = $('#warningContainer');
        var warningListContainer = $('#warningList');
        var warningMessagePar = $('#warningMessage');
        var closeButton = $('#popupWarning > div > button');
        warningListContainer.empty();
        _.each(warningList, function (item) {
            warningListContainer.append('<li>' + item + '</li>');
        });

        if (title)
            $('#warningTitle').html(title);

        if (message) {
            warningMessagePar.html(message);
            warningMessagePar.show();
        }
        else
            warningMessagePar.hide();
        closeButton.focus();
        warningContainer.show();
        if (outCallback)
            closeButton.unbind('click');
        closeButton.click(function () {

        })
    }
}


//This method creates a numerical list from start to end, and appends appendEnd at the end if exists
function getSequentialList(start, end, appendEnd) {
    var arr = new Array();
    for (var i = start; i <= end; i++)
        arr.push({ id: i, name: i.toString() });
    if (appendEnd)
        arr.push({ id: end + 1, name: appendEnd.toString() });
    return arr;
}

function closeReport() {
    $('.modal.autoPDF.report').hide();
}

function showReport(reportPath, saveButtonCallback) {

    $('#exPDF').attr("data", reportPath);

    $('.modal.autoPDF.report iframe.reportSource').attr('src', reportPath);
    $('#reportEmbed').attr('src', reportPath);

    $('#reportSaveButton').unbind('click');
    $('#reportPrintButton>button').unbind('click');

    if (saveButtonCallback) {
        $('#reportSaveButton').show();
        $('#reportSaveButton').click(saveButtonCallback);
    }
    else
        $('#reportSaveButton').hide();

    $('#reportPrintButton>button').click(function () {
        try {
            iframe = document.getElementById('reportFrame');
            iframe.contentWindow.document.execCommand('print', false, null);
        }
        catch (e) {
            window.print();
        }
    });

    $('#reportDownloadButton>div>a').attr('href', reportPath);
    $('.modal.autoPDF.report').show();
}

function getCurrentDateFormat() {
    //return 'dd/mm/yy';
    return 'dd-M-yy';
    //return 'dd-MM-yy';
}

function getCurrentDateTimeMomentFormat() {
    return "DD-MMM-YYYY hh:mm:ss a";
}

function getCurrentDateTimeMomentFormat2() {
    return "DD-MMM-YYYY";
}

ko.utils.clone = function (obj) {
    var target = new obj.constructor();
    for (var prop in obj) {
        var propVal = obj[prop];
        if (ko.isObservable(propVal)) {
            var val = propVal();
            if ($.type(val) == 'object') {
                target[prop] = ko.utils.clone(val);
                continue;
            }
            target[prop] = ko.observable(val);
        }
    }
    return target;
};

ko.extenders.numericRange = function (target, range) {
    //create a writable computed observable to intercept writes to our observable
    var result = ko.pureComputed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target();

            if ($.isNumeric(newValue)) {
                var newValueAsNum = parseInt(newValue);
                if (newValueAsNum >= range[0] && newValueAsNum <= range[1]) {
                    target(newValueAsNum);
                    target.notifySubscribers(newValueAsNum);
                }
                else {
                    target(null);
                    target.notifySubscribers(null);
                }
            }
            else {
                target(null);
                target.notifySubscribers(null);
            }

        }
    }).extend({ notify: 'always' });

    //initialize with current value to make sure it is rounded appropriately
    //result(target());

    //return the new computed observable
    return result;
};

ko.extenders.numeric = function (target, precision) {
    //create a writable computed observable to intercept writes to our observable
    var result = ko.pureComputed({
        read: target,  //always return the original observables value
        write: function (newValue) {
            var current = target(),
                roundingMultiplier = Math.pow(10, precision),
                newValueAsNum = isNaN(newValue) ? 0 : +newValue,
                valueToWrite = Math.round(newValueAsNum * roundingMultiplier) / roundingMultiplier;

            //only write if it changed
            if (valueToWrite !== current) {
                target(valueToWrite);
            } else {
                //if the rounded value is the same, but a different value was written, force a notification for the current field
                if (newValue !== current) {
                    target.notifySubscribers(valueToWrite);
                }
            }
        }
    }).extend({ notify: 'always' });

    //initialize with current value to make sure it is rounded appropriately
    result(target());

    //return the new computed observable
    return result;
};

ko.bindingHandlers.maskedInput = {
    init: function (element, valueAccessor) {
        var mask = valueAccessor();
        $(element).mask(mask);
    }
}

ko.bindingHandlers.inputmask = {
    init: function (element, valueAccessor, allBindingsAccessor) {

        var mask = valueAccessor();

        var observable = mask.value;

        if (ko.isObservable(observable)) {

            $(element).on('focusout change', function () {

                if ($(element).inputmask('isComplete')) {
                    observable($(element).val());
                } else {
                    observable(null);
                }

            });
        }

        $(element).inputmask(mask);

    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var mask = valueAccessor();

        var observable = mask.value;

        if (ko.isObservable(observable)) {

            var valuetoWrite = observable();

            $(element).val(valuetoWrite);
        }
    }

};

function pdfPrint(iframeId) {
    var PDF = document.getElementById(iframeId);
    PDF.focus();
    PDF.contentWindow.print();
}

$(document).ready(function () {

    //ajaxloader
    $(document).ajaxStart(function () {
        $("#ajaxLoader").show();
    });
    $(document).ajaxStop(function () {
        $("#ajaxLoader").hide();
    });

    //Prevent Jquery ajax to cache results
    $.ajaxSetup({ cache: false });

    $.validator.setDefaults({
        showErrors: function (errorMap, errorList) {

            if (errorList.length > 0) {
                var messages = _.map(errorList, function (item) { return item.message; });
                showError(messages, "Se han producido los siguientes errores:");
            }
        },
        onfocusout: false,
        onkeyup: false,
        onclick: false,
        onsubmit: false,
        focusInvalid: false
    });

    $.validator.addMethod("moneyRequired", function (value, element) {
        var stripped = value.replace(/[^0-9.-]/g, '');
        var test = (!isNaN(stripped) || stripped.length == 0);
        return test;
    });

    $.validator.addMethod("moneyRange", function (value, element, params) {
        var stripped = value.replace(/[^0-9.-]/g, '');
        if (!isNaN(stripped)) {
            var number = Number(stripped);
            return (params[0] <= number && number <= params[1]);
        }
        else {
            return false;
        }
    });

    $.validator.addMethod("moneyMinByElement", function (value, element, params) {
        var stripped = value.replace(/[^0-9.-]/g, '');

        if (!isNaN(stripped)) {
            var number = Number(stripped);

            var minValue = Number($('#' + params).val());
            return (number >= minValue);
        }
        else {
            return false;
        }
    }, function (params, element) {
        return 'El pago mÌnimo debe ser de $' + $("#" + params).val() + '.'
    });

    $.validator.addMethod("moneyMaxByElement", function (value, element, params) {
        var stripped = value.replace(/[^0-9.-]/g, '');
        if (!isNaN(stripped)) {
            var number = Number(stripped);
            var maxValue = Number($('#' + params).val());
            return (number <= maxValue);
        }
        else {
            return false;
        }
    });

    $.validator.addMethod("emailWithDomain", function (value, element, params) {
        return this.optional(element) || /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)$/.test(value);
    });

    $.validator.addMethod('dateFormat', function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var ok = true;
        try {
            $.datepicker.parseDate(getCurrentDateFormat(), value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });

    $.validator.addMethod('maxdate', function (value, element, arg) {
        // Same as above
        var valueDay = value.split("/");
        var day = parseInt(valueDay[0]);
        var month = parseInt(valueDay[1]) - 1;
        var year = parseInt(valueDay[2]);

        var referenceMaxDate = arg,
            enteredDate = new Date(year, month, day);

        return enteredDate <= referenceMaxDate;
    });

    $.validator.addMethod("licenseNumber", function (value, element) {
        return this.optional(element) || /^[0-9," ", "-"]+$/i.test(value);
    });

    $.validator.addMethod('nameSurname', function (value) {
        return !value || /^[A-Z\u00C0-\u00DC\00D1\00F1 a-z\u00E0-\u00FC ']+$/.test(value);
    }, 'Ingrese una cadena alfanumÈrica v·lida.');

    $.validator.addMethod('validCedulaLicencia', function (value) {

        var cedu = value.replace("-", "").replace("-", "");
        var typeIdentification = $("#identificationTypeO").val();
        var cedula = typeIdentification.replace("È", "e");

        /*Cedula/Licencia*/
        if (typeIdentification != "RNC" && typeIdentification != "Pasaporte" && (typeIdentification == cedula || typeIdentification == "Licencia")) {
            var qty = cedu.length;
            var isnumeric = /^[0-9," ", "-"]+$/i.test(cedu);

            if (!isnumeric || qty < 11 || qty > 11) {
                return false;
            }
        }
        /**/

        return true;
    }, 'La C&eacute;dula/Licencia debe ser num&eacute;rica y debe tener 11 digitos.');

    $.validator.addMethod('validRNC', function (value) {

        var rnc = value.replace("-", "").replace("-", "");
        var typeIdentification = $("#identificationTypeO").val();

        /*RNC*/
        if (typeIdentification == "RNC") {

            var qty = rnc.length;
            var isnumeric = /^[0-9," ", "-"]+$/i.test(rnc);

            if (!isnumeric || qty < 9 || qty > 9) {
                return false;
            }
        }
        /**/

        return true;
    }, 'El RNC debe ser num&eacute;rico y debe tener 9 digitos.');

    $.validator.addMethod('biggerThan', function (value, element, param) {

        if (this.optional(element)) return true;
        var i = parseInt(value);
        var j = parseInt($(param).val());
        return (i > j) ? false : true;
    }, 'El A&ntilde;o Desde no puede ser mayor que el A&ntilde;o Hasta.');

    $.validator.addMethod('lessThan', function (value, element, param) {

        if (this.optional(element)) return true;
        var i = parseInt(value);
        var j = parseInt($(param).val());
        return (i < j) ? false : true;
    }, 'El A&ntilde;o Hasta no puede ser menor que el A&ntilde;o Desde.');

    $(".autoSelectable")
        .focus(function () { $(this).select(); })
        .mouseup(function (e) { e.preventDefault(); });

    $.datepicker.setDefaults($.datepicker.regional["es"]);

    var monthNames = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];

    $.ajax({
        url: "/Home/GetMonths",
        dataType: 'json',
        async: false,
        success: function (data) {
            monthNames = [];
            _.each(data, function (item) {
                monthNames.push(item.Name);
            });
        }
    });

    $.datepicker.setDefaults({
        dateFormat: getCurrentDateFormat(),
        monthNamesShort: monthNames
    });

    $(document).ajaxError(function (event, jqXHR, settings, thrownError) {

        if (jqXHR.status == 403) //Means authorization error
        {
            var data = $.parseJSON(jqXHR.responseText);
            window.location = data.LogOnUrl;
        }
        else {
            var response = $.parseJSON(jqXHR.responseText);
            var msg = "Se ha producido un error en el sistema.";

            if (response.error) {
                var err = response.error;
                if (response.error.length > 100)
                    err = response.error.substring(0, 100) + "...";
                showError([err]);
            }
            else {
                showError([msg]);
            }
        }
    });

    /*======| ACORDEON |======*/

    var parentDivs = $('#cbp-ntaccordion li'),
        childDivs = $('#cbp-ntaccordion h3').siblings('div'),
        parentDivs2 = $('#cbp-ntaccordion2 li'),
        childDivs2 = $('#cbp-ntaccordion2 h3').siblings('div'),
        h3Event,
        h3Temp,
        sensitivity = 400;

    $('#cbp-ntaccordion h3').click(function () {
        childDivs.slideUp();
        if ($(this).next().is(':hidden')) {
            $(this).next().slideDown();
        } else {
            $(this).next().slideUp();
        }
    });

    $('#cbp-ntaccordion2 h3').click(function () {
        childDivs2.slideUp();
        if ($(this).next().is(':hidden')) {
            $(this).next().slideDown();
        } else {
            $(this).next().slideUp();
        }
    });

    /*======| FIN ACORDEON |======*/

    //Added by Jheiron Dotel to correct VO menu
    $("#menu-2").show();

    $(".noWeirdChar").attr('data-inputmask-regex', "[A-Za-z.-\\sÒ—·ÈÌÛ˙¡…Õ”⁄]*");
    $(".noWeirdChar").inputmask("Regex");

    $(".noWeirdChar2").attr('data-inputmask-regex', "[A-Za-z0-9\\sÒ—·ÈÌÛ˙¡…Õ”⁄]*");
    $(".noWeirdChar2").inputmask("Regex");



    $(".RedirectToOtherApp").on("click", function () {
        $("#ajaxLoader").show();

        var $this = $(this);
        var path = $this.data("path");
        var appname = $this.data("appname");
        var tab = "";

        $.ajax({
            url: "/Account/RedirectToOtherApp",
            data: { path: path, appname: appname, tab: tab },
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data.Status) {
                    //Le notifico al cliente que perdera la informacion
                    showQuestion("Cambiar de Aplicacion", "En caso de que no haya guardado los datos que se han editado o capturado van a perderse.    Esta seguro que desea abandonar la pagina?",
                              function () {
                                  location.href = data.UrlPath;
                                  return false;
                              },
                               function () {
                                   return false;
                               }
                              );

                    $("#ajaxLoader").hide();

                } else {
                    if (data.errormessage !== "") {
                        showError([data.errormessage]);
                    }
                    $("#ajaxLoader").hide();
                }
            }
        });
    });


    $(".RedirectToOtherAppH").on("click", function () {
        $("#ajaxLoader").show();

        var $this = $(this);
        var path = $this.data("path");
        var appname = $this.data("appname");
        var tab = "";

        $.ajax({
            url: "/Account/RedirectToOtherApp",
            data: { path: path, appname: appname, tab: tab },
            dataType: 'json',
            async: false,
            success: function (data) {
                if (data.Status) {

                    location.href = data.UrlPath;
                    $("#ajaxLoader").hide();

                } else {

                    showError([data.errormessage]);
                    $("#ajaxLoader").hide();

                    return false;
                }
            }
        });
    });


    $(".autoChange").on("click", function () {

        //Le notifico al cliente que perdera la informacion
        showQuestion("Cambiar de Aplicacion", "En caso de que no haya guardado los datos que se han editado o capturado van a perderse.    Esta seguro que desea abandonar la pagina?",
                  function () {
                      location.href = "/auto/PoSAuto";
                  },
                   function () {
                       return false;
                   });

        return false;
    });


    $.ajax({
        url: "/PosAuto/GetPathsSecurity",
        dataType: 'json',
        async: false,
        success: function (data) {
            $("#menuOptionLineasComerciales").attr("data-path", data.LC);
            $("#menuOptionLineasEspeciales").attr("data-path", data.LC);
            $("#menuOptionVivienda").attr("data-path", data.VI);
            $("#menuOptionVida").attr("data-path", data.VID);
            $("#menuOptionFunerario").attr("data-path", data.VID);
            $("#menuOptionSalud").attr("data-path", data.SA);


            $("#menuOptionLineasComerciales2").attr("data-path", data.LC);
            $("#menuOptionLineasEspeciales2").attr("data-path", data.LC);
            $("#menuOptionVivienda2").attr("data-path", data.VI);
            $("#menuOptionVida2").attr("data-path", data.VID);
            $("#menuOptionFunerario2").attr("data-path", data.VID);
            $("#menuOptionSalud2").attr("data-path", data.SA);



            //Historico
            $("#menuOptionLineasComercialesH").attr("data-path", data.LCH);
            $("#menuOptionLineasEspecialesH").attr("data-path", data.ESH);
            $("#menuOptionViviendaH").attr("data-path", data.VIH);
            $("#menuOptionVidaH").attr("data-path", data.VIDH);
            $("#menuOptionFunerarioH").attr("data-path", data.VIDH);
            $("#menuOptionSaludH").attr("data-path", data.SAH);


            $("#menuOptionLineasComercialesH2").attr("data-path", data.LCH);
            $("#menuOptionLineasEspecialesH2").attr("data-path", data.ESH);
            $("#menuOptionViviendaH2").attr("data-path", data.VIH);
            $("#menuOptionVidaH2").attr("data-path", data.VIDH);
            $("#menuOptionFunerarioH2").attr("data-path", data.VIDH);
            $("#menuOptionSaludH2").attr("data-path", data.SAH);
        }
    });


    function getCountryUser() {
        $.getJSON("http://freegeoip.net/json/", function (data) {
            var country = data.country_name;
            var ip = data.ip;
            return country;
        });
    }
});


