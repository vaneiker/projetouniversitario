﻿function paymentViewModel() {
    var self = this;


    //This method helps serialization to get the exact info
    self.toJSON = function () {
        var copy = ko.toJS(self);
        delete copy.validationRules;

        return copy;
    };

    self.clear = function () {
        self.amountToPayEntered(0);
        self.applicant.frequency(undefined);
        self.applicant.wayToPay(2);

        self.ach.name(undefined);
        self.ach.bank(undefined);
        self.ach.type(0);
        self.ach.number(undefined);
        self.ach.dummyNumber(undefined);
        self.ach.dummyNumberVisible(false);
        self.ach.achAccountHolderGovernmentId(undefined);
        self.ach.achBankRoutingNumber(undefined);
    };



    //$.ajax({
    //    url: '/PoSAuto/GetPaymentFrecuency',
    //    dataType: 'json',
    //    async: false,
    //    success: function (data) {
    //        self.frequencyList(data);
    //    }
    //});


    self.frequencyList = ko.observableArray
        (
          [
           { id: 0, name: "Pago Único (5% de Descuento)", discountPercentage: 5 },
           { id: 1, name: "Inicial + 1 Cuota", discountPercentage: 0 },
           { id: 2, name: "Inicial + 2 Cuota", discountPercentage: 0 },
           { id: 3, name: "Inicial + 3 Cuota ", discountPercentage: 0 },
           { id: 4, name: "Inicial + 4 Cuota", discountPercentage: 0 },
           { id: 5, name: "Financiado a 5 Cuotas", discountPercentage: 0 },
           { id: 6, name: "Financiado a 6 Cuotas", discountPercentage: 0 },
           { id: 7, name: "Financiado a 7 Cuotas", discountPercentage: 0 },
           { id: 8, name: "Financiado a 8 Cuotas", discountPercentage: 0 },
           { id: 9, name: "Financiado a 9 Cuotas", discountPercentage: 0 },
           { id: 10, name: "Financiado a 10 Cuotas", discountPercentage: 0 },
           { id: 11, name: "Financiado a 11 Cuotas", discountPercentage: 0 },
           { id: 12, name: "Financiado a 12 Cuotas", discountPercentage: 0 }
          ]
        )


    self.frequencyListMotor = ko.observableArray
      (
        [
           { id: 0, name: "Pago Único", discountPercentage: 0 },
        ]
       )

    self.applicant = {
        frequency: ko.observable(),
        wayToPay: ko.observable()
    };

    self.iscPercentage = ko.observable();
    self.amountToPayEntered = ko.observable().money();

    self.currentDiscountPercentage = ko.computed(function () {

        if (self.applicant && self.applicant.frequency() != undefined) {

            var z = $("#hdnIsAMotor").val();
            var f = self.applicant.frequency();
            

            if (z === "true" && f == 0) {
                var freq = _.find(self.frequencyListMotor(), function (item) { return item.id == self.applicant.frequency(); });
                return freq.discountPercentage;
            } else {
                var freq = _.find(self.frequencyList(), function (item) { return item.id == self.applicant.frequency(); });
                return freq.discountPercentage;
            }
        }
        else
            return 0;
    });

    self.isValidForSaving = function () {
        var completed = true;
        var messages = [];

        return completed;

    }






    self.ach = {
        name: ko.observable(),
        bank: ko.observable(),
        type: ko.observable(),
        number: ko.observable(),
        dummyNumber: ko.observable(),
        dummyNumberVisible: ko.observable(false),
        achAccountHolderGovernmentId: ko.observable(),
        achBankRoutingNumber: ko.observable(),
        editNumber: function () { self.ach.dummyNumberVisible(false); $('#achNumber').focus(); }
    };

    self.yearList = ko.observableArray([]);
    var year = today.getFullYear();
    for (var i = 0 ; i < 10; i++, year++)
        self.yearList.push({ id: year, name: year });

    self.validationRules = {
        rules: {
            applicantFrequency: {
                required: true,
                number: true,
                max: 18
            },
            applicantWayToPay: {
                required: true
            },

            //CREDIT CARD
            amountToPayEntered: {
                moneyRequired: true,
                moneyRange: [0.01, 9999999999.99],
                moneyMinByElement: 'minAllowedAmountToPay',
                moneyMaxByElement: 'maxAllowedAmountToPay'
            },

            //ACH
            achName: {
                required: true,
                maxlength: 50,
                nameSurname: true
            },
            achBank: {
                required: true,
                maxlength: 50
            },
            achType: {
                required: true,
            },
            achNumber: {
                required: true,
                number: true,
                maxlength: 50
            },
            achAccountHolderGovernmentId: {
                required: true,
                maxlength: 50
            },
            achBankRoutingNumber: {
                required: true,
                digits: true,
                range: [10000000, 999999999]
            }
        },
        messages: {
            applicantFrequency: {
                required: 'La Frecuencia de Pago es requerida.',
                number: 'Debe ingresar una Frecuencia de Pago válida.',
                max: 'La Frecuencia de Pago no puede ser mayor a 18.'
            },
            applicantWayToPay: {
                required: 'La Forma de Pago es requerida.'
            },

            //CASH
            cashMinimumAmount: {
                moneyRequired: 'El Monto Mínimo de Pago es requerido.',
                moneyRange: 'Debe ingresar un Monto Mínimo de Pago válido.'
            },
            cashPending: {
                moneyRequired: 'El Total Balance Pendiente es requerido.',
                moneyRange: 'Debe ingresar un Total Balance Pendiente válido.'
            },
            cashSpecificAmount: {
                moneyRequired: 'El Monto Específico es requerido.',
                moneyRange: 'Debe ingresar un Monto Específico válido.'
            },
            cashPrimeNet: {
                moneyRequired: 'La Prima Neta es requerida.',
                moneyRange: 'Debe ingresar una Prima Neta válida.'
            },
            cashIsc: {
                moneyRequired: 'El ISC 16% es requerido.',
                moneyRange: 'Debe ingresar un ISC 16% válido.'
            },

            //CREDIT CARD
            amountToPayEntered: {
                moneyRequired: 'Debe ingresar un monto a pagar.',
                moneyRange: 'Debe ingresar un monto a pagar.',
                moneyMinByElement: function (params, element) {

                    var percentallowed = $("#minAllowedAmountToPay").data("percentallowed");
                    percentallowed = (percentallowed * 100);


                    return 'El monto a pagar debe ser al menos el ' + percentallowed + '% del total. Es decir, el pago mínimo debe ser de $' + $("#" + params).val() + '.'

                    //return 'El monto a pagar debe ser al menos el 30% del total. Es decir, el pago mínimo debe ser de $' + $("#" + params).val() + '.'
                },
                moneyMaxByElement: 'El monto a pagar no puede superar el total.'

            },

            //ACH
            achName: {
                required: 'El Nombre del Cuenta Habiente es requerido.',
                maxlength: 'El Nombre del Cuenta Habiente no puede tener más de 50 caracteres de longitud.',
                nameSurname: 'El Nombre de Cuenta Habiente sólo permite caracteres alfabéticos.'
            },
            achBank: {
                required: 'El Banco es requerido.',
                maxlength: 'El Banco no puede tener más de 50 caracteres de longitud.'
            },
            achType: {
                required: 'El Tipo de Cuenta es requerido.',
            },
            achNumber: {
                required: 'El Número de Cuenta es requerido.',
                number: 'Debe ingresar un  Número de Cuenta válido.'
            },
            achAccountHolderGovernmentId: {
                required: "El Número de Identificación Cuenta Habiente es requerido.",
                maxlength: "El Número de Identificación Cuenta Habiente no puede tener más de 50 caracteres de longitud."
            },
            achBankRoutingNumber: {
                required: "El Número de Ruta es requerido.",
                digits: "El Número de Ruta debe ser numérico.",
                range: "El Número de Ruta debe tener 8 o 9 dígitos."
            }

        }
    };

}