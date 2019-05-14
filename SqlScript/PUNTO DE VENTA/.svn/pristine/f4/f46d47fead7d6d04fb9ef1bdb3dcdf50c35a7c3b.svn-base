function finalBeneficiaryViewModel() {
    var self = this;

    //This method helps serialization to get the exact info
    self.toJSON = function () {
        var copy = ko.toJS(self);
        //delete copy.toString;
        delete copy.validationRules;
        return copy;
    };

    self.id = ko.observable(Math.floor((Math.random() * 10000) + 1) * -1);
    self.fullNameBeneficiary = ko.observable();
    self.percentageBeneficiary = ko.observable(0);
    self.driverID = ko.observable();

    self.formattedPercent = ko.pureComputed({
        read: function () {
            return self.percentageBeneficiary().toFixed(0);
        },
        write: function (value) {
            // Strip out unwanted characters, parse as float, then write the 
            // raw data back to the underlying "price" observable
            value = parseFloat(value.replace(/[^\.\d]/g, ""));
            self.percentageBeneficiary(isNaN(value) ? 0 : value); // Write to underlying storage
        },
        owner: self
    });


    self.clear = function () {
        self.fullNameBeneficiary('');
        self.percentageBeneficiary(0);
        self.driverID();
    }


    /*Si deciden que estos campos seran requeridos, solo descomentar*/
    self.validationRules = {
        rules: {
            fullNameBeneficiary: {
                nameSurname: true,
                required: true,
                maxlength: 300
            },

            percentageBeneficiary: {
                moneyRequired: true,
                moneyRange: [20, 100]
            }
        },
        messages: {
            fullNameBeneficiary: {
                nameSurname: 'El Nombre Completo sólo permite caracteres alfabéticos.',
                required: 'El Nombre Completo es requerido.',
                maxlength: 'El Nombre Completo no puede tener más de 300 caracteres de longitud.'
            },
            percentageBeneficiary: {
                moneyRequired: 'El Porcentaje es requerido',
                moneyRange: 'El Porcentaje debe estar en el rango de 20 a 100.'
            }
        }
    };
    //

    self.loadModel = function (model) {        
        self.id(model.Id);
        self.fullNameBeneficiary(model.Name)
        self.percentageBeneficiary(model.PercentageParticipation);
        self.driverID(model.PersonBenefiId);
    }

    self.finalBeneficiaryDataComplete = function () {
        var completed = self.fullNameBeneficiary()
            && self.percentageBeneficiary() != undefined        
        //&& self.driverID() != undefined

        return completed;
    };
}