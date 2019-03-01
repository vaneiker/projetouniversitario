﻿function getReturnUrlAfterLanguageChange() {
    model.saveQuotation();
    var returnUrl = '/Auto/PosAuto';

    if (model.quotation())
        returnUrl = '/Auto/PosAuto/Index/' + model.quotation().id;

    return returnUrl;
}

var model = null;

$(document).ready(function () {

    model = new posViewModel();
    var autoVM = new autoViewModel(model);
    autoVM.newDriver = new driverViewModel();
    autoVM.newDriver.principal(true);
    autoVM.infoAdDriver(new driverViewModel());
    autoVM.infoAdVehicle = ko.observable(new vehicleViewModel(autoVM));

    autoVM.infoAdBeneficiaryFinal(new finalBeneficiaryViewModel());
    autoVM.infoAdPep(new pepViewModel());

    $('#languageSelector').attr('disabled', 'disabled');

    autoVM.Messaging(true);

    model.mainData(autoVM);

    var stepNames = eval($('#stepNames').val());

    model.steps = ko.observableArray([
        {
            order: ko.observable(1),
            name: ko.observable("driver"),
            title: ko.observable(stepNames[0]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.INPROGRESS),
            //mainVisible: function () { return !autoVM.showPayment(); },
            mainVisible: function () { return model.currentStepId() <= 3 },
            stepTemplate: ko.observable('stepDrivers'),
            nextStepButtonTitle: ko.observable('Continuar Paso 2'),
            stepData: autoVM,
            setFocus: autoVM.setFocus
        },
        {
            order: ko.observable(2),
            name: ko.observable("vehicle"),
            title: ko.observable(stepNames[1]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            //mainVisible: function () { return !autoVM.showPayment(); },
            mainVisible: function () { return model.currentStepId() <= 3 },
            stepTemplate: ko.observable('stepVehicleCoverage'),
            nextStepButtonTitle: ko.observable('Continuar'),
            stepData: autoVM,
            setFocus: autoVM.setFocus,
            updateStepData: function () { autoVM.updateStepData(2); }
        },
        {
            order: ko.observable(3),
            name: ko.observable("resume"),
            title: ko.observable(stepNames[2]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            bigger: true,
            //mainVisible: function () { return !autoVM.showPayment(); },
            mainVisible: function () { return model.currentStepId() <= 3 },
            stepTemplate: ko.observable('stepResume'),
            nextStepButtonTitle: ko.observable('Ver Cotización'),
            stepData: autoVM,
            updateStepData: function () { autoVM.updateStepData(3); }
        },
        {
            order: ko.observable(4),
            name: ko.observable("buy1"),
            title: ko.observable(stepNames[3]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: autoVM.showPayment,
            mainVisible: function () { return model.currentStepId() > 3 },
            stepTemplate: ko.observable('stepBuy1'),
            nextStepButtonTitle: ko.observable('Info. Adicional Vehículo'),
            stepData: autoVM,
            updateStepData: function () { autoVM.updateStepData(4); }
        },
        {
            order: ko.observable(5),
            name: ko.observable("buy2"),
            title: ko.observable(stepNames[4]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            //mainVisible: autoVM.showPayment,
            mainVisible: function () { return model.currentStepId() > 3 },
            stepTemplate: ko.observable('stepBuy2'),
            nextStepButtonTitle: ko.observable("Continuar"),
            stepData: autoVM,
            updateStepData: function () { autoVM.updateStepData(5); }
        },
        {
            order: ko.observable(6),
            name: ko.observable("buy3"),
            stepData: autoVM,
            title: ko.observable(stepNames[7]),
            //title: ko.computed(function () {
            //    if (autoVM.allLawProducts())
            //        return stepNames[5];
            //    else
            //        return stepNames[6];
            //}),
            isBuyStep: true,
            status: ko.observable(stepStatuses.PENDING),
            //mainVisible: autoVM.showPayment,
            mainVisible: function () { return model.currentStepId() > 3 },
            stepTemplate: ko.observable('stepBuy3'),
            nextStepButtonTitle: ko.observable('Pagar'),
            updateStepData: function () { autoVM.updateStepData(6); }
        }
    ]);

    model.setSelectedStep(1, null);
    //ko.applyBindings(model);
    //<!-- Agregado por StateTrust -->
    var bindDiv = document.getElementById("divBody");
    ko.applyBindings(model, bindDiv);
    //<!-- Agregado por StateTrust -->

    model.setCurrentStateHistory(1);

    if (typeof paymentStatus != 'undefined') {

        if (paymentStatus == "AuthorizationAnswered") {

            if (paymentSuccess) {

                if (failInsentingQuotationOnSysFlexOrVO == "W") {
                    $("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja, pero, se realizo el pago correctamente y se genero el número de póliza en SysFlex.. No. Póliza: " + PolicyNumberPayment);
                    $("#noAuthorizationCode").html("No. Autorización Pago: " + AuthorizationCode);
                    $('.suCompra').show();
                    window.history.replaceState({}, '', '/Auto/PosAuto');

                    $(".overlaypp").show();
                }
                else if (failInsentingQuotationOnSysFlexOrVO === "GP") {
                    //$("#noPolicyMarbete").html("Ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder, de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + PolicyNumberPayment);
                    $("#noPolicyMarbete").html(errorGPToSysflexMessage.replace("{0}", PolicyNumberPayment));
                    $("#noAuthorizationCode").html("No. Autorización Pago: " + AuthorizationCode);
                    $('.suCompra').show();
                    window.history.replaceState({}, '', '/Auto/PosAuto');

                    $(".overlaypp").show();
                }
                else if (failInsentingQuotationOnSysFlexOrVO === "GP2") {
                    //$("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja y ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder,  de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + PolicyNumberPayment);
                    $("#noPolicyMarbete").html(errorGPToSysflexMessage2.replace("{0}", PolicyNumberPayment));
                    $("#noAuthorizationCode").html("No. Autorización Pago: " + AuthorizationCode);
                    $('.suCompra').show();
                    window.history.replaceState({}, '', '/Auto/PosAuto');

                    $(".overlaypp").show();
                }
                else {
                    $("#noPolicyMarbete").html("No. Poliza: " + PolicyNumberPayment);
                    $("#noAuthorizationCode").html("No. Autorización Pago: " + AuthorizationCode);
                    $('.suCompra').show();
                    window.history.replaceState({}, '', '/Auto/PosAuto');

                    $(".overlaypp").show();
                }
            }
            else {
                $(".overlaypp").hide();

                if (failInsentingQuotationOnSysFlexOrVO == "S") {
                    showError(['El pago fue procesado con éxito, pero, ocurrió un error enviando la cotización al sistema core.'], 'Enviando a Sysflex');
                }
                else if (failInsentingQuotationOnSysFlexOrVO == "E") {
                    showError(['Esta cotización ya ha sido enviada a nuestros sistemas.'], 'Pagos');
                }
                else if (failInsentingQuotationOnSysFlexOrVO == "W") {
                    showError(['Ocurrió un error enviando la cotización a la bandeja, pero, se genero el número de póliza........ No. Póliza: ' + PolicyNumberPayment], 'Enviando a Sysflex');
                }
                else if (failInsentingQuotationOnSysFlexOrVO === "GP") {
                    //showError(['Ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder, de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: ' + PolicyNumberPayment], 'Pagos');
                    showError([errorGPToSysflexMessage.replace("{0}", PolicyNumberPayment)], 'Pagos');

                }
                else if (failInsentingQuotationOnSysFlexOrVO === "GP2") {
                    //showError(['Ha ocurrido un error al tratar envíar la cotización a la Bandeja y ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder,  de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: ' + PolicyNumberPayment], 'Pagos');                    
                    showError([errorGPToSysflexMessage2.replace("{0}", PolicyNumberPayment)], 'Pagos');
                }
                else {
                    showError(['No se ha podido realizar el pago de la cotización Nro ' + quotationNumber + '. El proveedor de pagos ha respondido con el siguiente mensaje: ' + paymentMessage], 'Pagos');
                }
            }
        }
        else if (paymentStatus == "AuthorizationCancelled") {
            $(".overlaypp").hide();

            showError(['No se ha podido realizar el pago de la cotización Nro ' + quotationNumber + '. La operación ha sido cancelada por el usuario.'], 'Pagos');
        }
    }

    var quotId = $('#loadQuotationId').val();    
    if (quotId) {
        $('#marbeteReciboQuotId').val(quotId);
        model.loadQuotation(quotId);
    }


    $(".noWeirdChar").attr('data-inputmask-regex', "[A-Za-z\\sñÑáéíóúÁÉÍÓÚ]*");
    $(".noWeirdChar").inputmask("Regex");

    $(".noWeirdChar2").attr('data-inputmask-regex', "[A-Za-z0-9\\sñÑáéíóúÁÉÍÓÚ]*");
    $(".noWeirdChar2").inputmask("Regex");

    var ShowPepExplication = "";
    var ShowBeneficiaryFinalExplication = "";
    var ShowBeneficiaryFinalExplicationCompany = "";
    var ShowSiVinculadoExplication = "";
    var ShowSiDesignadoExplication = "";


    $.ajax({
        url: '/PoSAuto/ShowPepExplication',
        dataType: 'json',
        async: false,
        success: function (data) {
            ShowPepExplication = data;
        }
    });

    $.ajax({
        url: '/PoSAuto/ShowBeneficiaryFinalExplication',
        dataType: 'json',
        async: false,
        success: function (data) {
            ShowBeneficiaryFinalExplication = "<p>" + data; +"</p>";
        }
    });

    $.ajax({
        url: '/PoSAuto/ShowBeneficiaryFinalExplicationCompany',
        dataType: 'json',
        async: false,
        success: function (data) {
            ShowBeneficiaryFinalExplicationCompany = "<p>" + data; +"</p>";
        }
    });

    autoVM.ShowPepExplication(ShowPepExplication);
    autoVM.ShowBeneficiaryFinalExplication(ShowBeneficiaryFinalExplication);
    autoVM.ShowBeneficiaryFinalExplicationCompany(ShowBeneficiaryFinalExplicationCompany);

    $('#spanPep').qtip({
        content: {
            text: ShowPepExplication,
            title: '¿Que es esto?'
        }
    });

    $('#spanBF').qtip({
        content: {
            text: ShowBeneficiaryFinalExplication,
            title: '¿Que es esto?'
        }
    });

    /*Mask*/
    $("[phonenumber = 'PhoneNumber10']").inputmask("(999)-999-9999");
    /**/
});