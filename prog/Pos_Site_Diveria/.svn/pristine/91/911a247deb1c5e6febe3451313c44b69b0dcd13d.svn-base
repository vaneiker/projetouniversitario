function paymentViewModel() {
    var self = this;

    self.toJSON = function () {
        var copy = ko.toJS(self);

        delete copy.frequencyList;
        delete copy.yearList;
        delete copy.validationRules;

        return copy;
    }

    self.frequencyList = ko.observableArray([{ id: 1, name: "1 pago", discountPercentage: 5 },
        { id: 2, name: "2 pago", discountPercentage: 0 },
        { id: 3, name: "3 pago", discountPercentage: 0 },
        { id: 4, name: "4 pago", discountPercentage: 0 }])

    self.applicant = {
        name: ko.observable(),
        identification: ko.observable(),
        contributor: ko.observable(),
        frequency: ko.observable(),
        wayToPay: ko.observable(),
        dateToPay: ko.observable($.datepicker.formatDate('dd/mm/yy', new Date()))
    };

    self.iscPercentage = ko.observable();

    self.currentDiscountPercentage = ko.computed(function () {
        if (self.applicant && self.applicant.frequency()) {
            var freq = _.find(self.frequencyList(), function (item) { return item.id == self.applicant.frequency(); });
            return freq.discountPercentage;
        }
        else
            return 0;
    });

    self.isValidForSaving = function () {
        var completed = true;
        var messages = [];

        if (self.applicant.name()) {
            var valid = self.applicant.name().length < 50 && /^[A-Z\u00C0-\u00DC\00D1\00F1 a-z\u00E0-\u00FC ']+$/.test(self.applicant.name());
            completed &= valid;
        }

        if (self.applicant.identification()) {
            var valid = self.applicant.identification().length < 50 && /^[A-Z\u00C0-\u00DC\00D1\00F1 a-z\u00E0-\u00FC0-9 ']+$/.test(self.applicant.identification());
            completed &= valid;
        }

        return completed;

    }

    self.ach = {
        name: ko.observable(),
        achBankRoutingNumber: ko.observable(),
        achAccountHolderGovernmentId: ko.observable(),
        type: ko.observable(),
        number: ko.observable()
    };

    self.yearList = ko.observableArray([]);
    var year = today.getFullYear();
    for (var i = 0 ; i < 10; i++, year++)
        self.yearList.push({ id: year, name: year });

    self.validationRules = {
        rules: {
            applicantName: {
                required: true,
                maxlength: 50,
                nameSurname: true
            },
            applicantIdentification: {
                required: true,
                number: true
            },
            applicantContributor: {
                required: true
            },
            applicantFrequency: {
                required: true,
                number: true,
                max: 18
            },
            applicantWayToPay: {
                required: true
            },
            applicantDateToPay: {
                required: true,
                dateFormat: true
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
            achBankRoutingNumber: {
                required: true,
                maxlength: 9,
                number: true
            },
            achAccountHolderGovernmentId: { //Cedula
                required: true,
                maxlength: 20
            },
            achType: {
                required: true,
            },
            achNumber: {
                required: true,
                number: true
            }
        },
        messages: {
            applicantName: {
                required: 'El Nombre del Solicitante es requerido.',
                maxlength: 'El Nombre del Solicitante no puede tener más de 50 caracteres de longitud.',
                nameSurname: 'El Nombre del Solicitante sólo permite caracteres alfabéticos.'
            },
            applicantIdentification: {
                required: 'El No.Identificación Solicitante es requerido.',
                number: 'Debe ingresar un No.Identificación Solicitante numérico válido.'
            },
            applicantContributor: {
                required: 'El Tipo de Contribuyente es requerido.'
            },
            applicantFrequency: {
                required: 'La Frecuencia de Pago es requerida.',
                number: 'Debe ingresar una Frecuencia de Pago válida.',
                max: 'La Frecuencia de Pago no puede ser mayor a 18.'
            },
            applicantWayToPay: {
                required: 'La Forma de Pago es requerida.'
            },
            applicantDateToPay: {
                required: 'La Fecha de Pago es requerida.',
                dateFormat: 'Debe ingresar una Fecha de Pago válida.'
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
                moneyRange: 'El monto a pagar debe ser un valor numérico.',
                moneyMinByElement: 'El monto a pagar debe ser al menos el 25% del total.',
                moneyMaxByElement: 'El monto a pagar no puede superar el total.'

            },

            //ACH
            achName: {
                required: 'El Nombre del Cuenta Habiente es requerido.',
                maxlength: 'El Nombre del Cuenta Habiente no puede tener más de 50 caracteres de longitud.',
                nameSurname: 'El Nombre de Cuenta Habiente sólo permite caracteres alfabéticos.'
            },
            achBankRoutingNumber: {
                required: 'El Routing Number del banco es requerido.',
                maxlength: 'El Routing Number del banco no puede tener más de 9 caracteres numéricos.',
                number: 'El Routing Number del banco debe ser numérico.'
            },
            achAccountHolderGovernmentId: { //Cedula
                required: 'La cédula es requerida.',
                maxlength: 'La cédula no puede tener más de 20 caracteres de longitud.'
            },
            achType: {
                required: 'El Tipo de Cuenta es requerido.',
            },
            achNumber: {
                required: 'El Número de Cuenta es requerido.',
                number: 'Debe ingresar un  Número de Cuenta válido.'
            }

        }
    };

}