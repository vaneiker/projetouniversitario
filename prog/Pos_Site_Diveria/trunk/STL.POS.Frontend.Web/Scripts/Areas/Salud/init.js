$(document).ready(function () {
    var model = new posViewModel();

    var saludVM = new saludViewModel(model);
    saludVM.getQuotations(model.quotations);
    saludVM.newPerson = new personViewModel();
    saludVM.newPerson.titular(true);
    saludVM.infoAdPerson(new personViewModel());
    saludVM.setQuotationNumberNotifications(true);
    
    model.mainData(saludVM);

    var stepNames = eval($('#stepNames').val());

    model.steps = ko.observableArray([
        {
            order: ko.observable(1),
            name: ko.observable("person"),
            title: ko.observable(stepNames[0]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.INPROGRESS),
            mainVisible: function () { return !saludVM.showPayment(); },
            stepTemplate: ko.observable('stepPersons'),
            nextStepButtonTitle: ko.observable('Continuar Paso 2'),
            stepData: saludVM
        },
        {
            order: ko.observable(2),
            name: ko.observable("precondition"),
            title: ko.observable(stepNames[1]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: function () { return !saludVM.showPayment(); },
            stepTemplate: ko.observable('stepPreconditions'),
            nextStepButtonTitle: ko.observable('Continuar Paso 3'),
            stepData: saludVM,
            updateStepData: function () { saludVM.updateStepData(2); }
        },
        {
            order: ko.observable(3),
            name: ko.observable("benefit"),
            title: ko.observable(stepNames[2]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: function () { return !saludVM.showPayment(); },
            stepTemplate: ko.observable('stepBenefit'),
            nextStepButtonTitle: ko.observable('Ver Cotización'),
            stepData: saludVM,
            //updateStepData: function () { saludVM.updateStepData(3); }
        },
        {
            order: ko.observable(4),
            name: ko.observable("buy1"),
            title: ko.observable(stepNames[3]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: saludVM.showPayment,
            stepTemplate: ko.observable('stepBuy1'),
            nextStepButtonTitle: ko.observable('Info. Adicional Precondiciones Médicas'),
            stepData: saludVM,
            updateStepData: function () { saludVM.updateStepData(4); }
        },
        {
            order: ko.observable(5),
            name: ko.observable("buy2"),
            title: ko.observable(stepNames[4]),
            isBuyStep: false,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: saludVM.showPayment,
            stepTemplate: ko.observable('stepBuy2'),
            nextStepButtonTitle: ko.observable('Continuar'),
            stepData: saludVM
        },
        {
            order: ko.observable(6),
            name: ko.observable("buy3"),
            title: ko.observable(stepNames[5]),
            isBuyStep: true,
            status: ko.observable(stepStatuses.PENDING),
            mainVisible: saludVM.showPayment,
            stepTemplate: ko.observable('stepBuy3'),
            nextStepButtonTitle: ko.observable('Pagar'),
            stepData: saludVM
        }
    ]);

    model.setSelectedStep(1);
    //ko.applyBindings(model);
    //<!-- Agregado por StateTrust -->    var bindDiv = document.getElementById("divBody");    ko.applyBindings(model, bindDiv);    //<!-- Agregado por StateTrust -->

    if (typeof paymentStatus != 'undefined') {        
        if (paymentStatus == "AuthorizationAnswered") {
            if (paymentSuccess) {
                showSuccess('Pagos', 'Ha completado satisfactoriamente el pago de la cotización Nro ' + quotationNumber);
            }
            else {
                showError(['No se ha podido realizar el pago de la cotización Nro ' + quotationNumber + '. El proveedor de pagos ha respondido con el siguiente mensaje: ' + paymentMessage], 'Pagos');
            }
        }
        else if (paymentStatus == "AuthorizationCancelled") {
            showError(['No se ha podido realizar el pago de la cotización Nro ' + quotationNumber + '. La operación ha sido cancelada por el usuario.'], 'Pagos');
        }
    }

});