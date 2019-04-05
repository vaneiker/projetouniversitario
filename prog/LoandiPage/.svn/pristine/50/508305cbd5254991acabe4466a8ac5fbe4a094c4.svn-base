$(document).ready(function () {

    InitializeCustom();

    $(".call_btn").click(function () {
        getPhoneTypes();
        $('#ppCustomerCallback').modal({ backdrop: 'static', keyboard: false });

        $("#hdnBl").val("");

        var $this = $(this);
        var bl = $this.data('bl');

        $("#hdnBl").val(bl);
    });

    $("#SendCallback").click(function () {
        return SendCallback();
    });

    $(document).on('change', '#PhoneType', function () {
        var selected = $(this).val();
        var $CountryCodeCallback = $('#CountryCodeCallback');
        var $CityCodeCallback = $('#CityCodeCallback');
        var $NumToCall = $('#NumToCall');

        $CityCodeCallback.prop('disabled', false);
        $NumToCall.prop('disabled', false);

        switch (selected) {
            case "1"://Telefono mobil
                $CountryCodeCallback.prop('disabled', false);
                break;
            case "2":
                $CountryCodeCallback.prop('disabled', true);
                break;
            default://Telefono mobil
                $CountryCodeCallback.val('');
                $CityCodeCallback.val('');
                $NumToCall.val('');

                $CountryCodeCallback.prop('disabled', true);
                $CityCodeCallback.prop('disabled', true);
                $NumToCall.prop('disabled', true);
                break;
        }
    });

    $("#closeCustomerCallback").click(function () {
        ClearCallBack(true);
    });

    //var IpWasUsed = readCookie('IpWasUsed');
    //if (IpWasUsed == null) {
    getClientIpInfo();
    //}
    
    $(".quoteAssist").click(function () {
        var $this = $(this);

        var hdnMedio = $("#hdnMedio").val();
        var toUrl = "";

        if (hdnMedio !== '')
        {
            toUrl = "?m=" + hdnMedio;
        }

        var url = $this.attr("href") + toUrl;
        
        window.location.href = url;

        return false;
    });
});

function InitializeChosen() {

    $('.chosen-select-deselect').select2({
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

function InitializeCustom() {

    $(document).ajaxStart(function () {
        BeginRequestHandler();
    });

    $(document).ajaxStop(function () {
        EndRequestHandler();
    });

    InitializeChosen();

    //#Region Jquery Validate
    $.validator.setDefaults({
        showErrors: function (errorMap, errorList) {
            if (errorList.length > 0) {
                var messages = $.map(errorList, function (item) { return item.message; });
                showError(messages, "Se han producido los siguientes errores:");
            }
        },
        ignore: ":hidden:not(.chosen-select-deselect)",//Le digo que no ignore los campos ocultos que tenga esa clase
        //ignore: [":not([readonly='readonly'])"], //Le digo que no ignore los campos ocultos que tenga esa clase
        onfocusout: false,
        onkeyup: false,
        onclick: false,
        onsubmit: true,
        focusInvalid: false
    });

}

function getCurrentDateFormat() {
    return 'dd-M-yy';
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

function showWarning(warningList, title) {

    var warningContainer = $("#ppWarning");
    var warningTitle = $("#warningTitle");
    var warningListContainer = $("#warningListContainer");

    if (title) {
        warningTitle.html(title);
    }

    warningListContainer.empty();
    if (warningList) {
        $.each(warningList, function (item, i) {
            warningListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }
    //warningContainer.modal('show');
    warningContainer.modal({ backdrop: 'static', keyboard: false, show: true });
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

function showInfo(infoList, title) {

    var infoContainer = $("#ppInfo");
    var infoTitle = $("#infoTitle");
    var infoListContainer = $("#infoListContainer");

    if (title) {
        infoTitle.html(title);
    }

    infoListContainer.empty();
    if (infoList) {
        $.each(infoList, function (item, i) {
            infoListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }
    //infoContainer.modal('show');
    infoContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function SendCallback() {

    var hasError = false;

    if ($("#FirstNamesCallBack").val() == '') {
        hasError = true;
        showError(["Debe indicar su Nombre y Apellido para que nuestros representantes le llamen"], "Información incompleta");
        return false;
    }
    if ($("#LastNamesCallBack").val() == '') {
        hasError = true;
        showError(["Debe indicar su Nombre y Apellido para que nuestros representantes le llamen"], "Información incompleta");
        return false;
    }
    if ($("#PhoneType").val() == '' || $("#PhoneType").val() == null) {
        hasError = true;
        showError(["Debe indicar el Tipo de teléfono"], "Información incompleta");
        return false;
    }
    if ($("#PhoneType").val() == '1') {
        if ($("#CountryCodeCallback").val() == '') {
            $("#CountryCodeCallback").addClass('requerido');
            hasError = true;
            showError(["Debe indicar el código del País"], "Información incompleta");
            return false;
        } else
            $("#CountryCodeCallback").removeClass('requerido');
    } else
        $("#CountryCodeCallback").removeClass('requerido');

    if ($("#CityCodeCallback").val() == '') {
        hasError = true;
        showError(["Debe indicar el código de área de la ciudad"], "Información incompleta");
        return false;
    }

    if ($("#NumToCall").val() == '') {
        hasError = true;
        showError(["Debe indicar el número al que desea que le llamen"], "Información incompleta");
        return false;
    }

    if (!hasError) {

        var datos = {
            CntCode: $("#CountryCodeCallback").val() != 1 ? "" : $("#CountryCodeCallback").val(),
            CityCode: $("#CityCodeCallback").val(),
            NumToCall: $("#NumToCall").val(),
            Lang: "ES",
            FirstNames: $("#FirstNamesCallBack").val(),
            LastNames: $("#LastNamesCallBack").val(),
            City: "Santo Domingo",
            Country: "Republica Dominicana",
            Client: "Y",
            Email: $("#EmailCallback").val(),
            PolicyNum: "",
            Products: "SERVICIO MOBILE",
            Reason: "Other",
            Company: "STB",
            Message: $("#MessageCallback").val(),
            Svc: "a",
            PhoneType: $("#PhoneType").val(),
            Reference: $("#MessageCallback").val(),
            BL: $("#hdnBl").val()
        };

        $.ajax({
            url: "/Home/SendCallback",
            method: "POST",
            dataType: "json",
            data: datos,
            success: function (result) {
                ClearCallBack(true);
                showInfo(["En breves instantes uno de nuestros representantes le estará contactando"], "Llamada en proceso");
            },
            error: function (response) {
                if (response.responseText == "True") {
                    ClearCallBack(true);
                    showInfo(["En breves instantes uno de nuestros representantes le estará contactando"], "Llamada en proceso");

                } else {
                    ClearCallBack(true);
                    showError(["Ha ocurrido un error mientras se realizaba su llamada. Intente nuevamente por favor"], "Error realizando la llamada");
                }
            }
        });
    }

}

function getPhoneTypes() {
    $.ajax({
        url: "/Home/GetPhoneTypes",
        dataType: "json",
        async: false,
        data: {},
        success: function (result) {
            var $select_elem = $("#PhoneType");
            $select_elem.empty();
            $select_elem.append('<option value="">Tipo de teléfono</option>');

            $.each(result, function (idx, obj) {
                $select_elem.append('<option value="' + obj.Value + '">' + obj.name + '</option>');
            });
            //$select_elem.val('1');
            $select_elem.trigger("chosen:updated");
            $("#CountryCodeCallback").prop('disabled', true);
            $("#CityCodeCallback").prop('disabled', true);
            $("#NumToCall").prop('disabled', true);
        },
        error: function (response) {
            showError([response.responseText], "Error buscando los tipos de telefonos");
        }
    });
}

function ClearCallBack(CloseModal) {
    var $FirstNamesCallBack = $('#FirstNamesCallBack');
    var $LastNamesCallBack = $('#LastNamesCallBack');
    var $PhoneType = $('#PhoneType');
    var $CountryCodeCallback = $('#CountryCodeCallback');
    var $CityCodeCallback = $('#CityCodeCallback');
    var $NumToCall = $('#NumToCall');
    var $PolicyNumCallBack = $('#PolicyNumCallBack');
    $FirstNamesCallBack.val('');
    $LastNamesCallBack.val('');
    $PhoneType.val('');
    $PhoneType.trigger("chosen:updated");

    var $EmailCallback = $('#EmailCallback');
    var $MessageCallback = $('#MessageCallback');

    $CountryCodeCallback.val('');
    $CityCodeCallback.val('');
    $NumToCall.val('');
    $PolicyNumCallBack.val('');
    $EmailCallback.val('');
    $MessageCallback.val('');

    if (CloseModal)
        $('#ppCustomerCallback').modal('hide');
}

function getClientIp() {

    var Ip = "";

    $.ajax({
        url: "https://api.ipify.org/?format=json",
        dataType: "json",
        async: false,
        data: {},
        success: function (data) {
            if (data) {
                Ip = data.ip;
                return Ip;
            }
        },
        error: function (response) {
            console.log("Error Call");
            console.log(response.responseText);
            console.log(response);
        }
    });

    return Ip;
}

function getClientIpInfo() {

    var clientip = getClientIp();
    var m = getParameterByName("m", window.location.href);
    
    $.ajax({
        url: "/Home/getClientIpInfo",
        dataType: "json",
        async: false,
        data: { ip: clientip, m: m },
        success: function (data) {

            if (!data.success) {
                //var IpWasUsed = readCookie('IpWasUsed');
                //if (IpWasUsed != null) {
                //    eraseCookie('IpWasUsed');
                //}
                console.log(data.message);
            }
            else if (data.success) {
                //createCookie('IpWasUsed', true, 1);

                $("#hdnMedio").val(data.medio);
            }
        },
        error: function (response) {
            console.log("Error Call");
            console.log(response.responseText);
            console.log(response);
        }
    });
}