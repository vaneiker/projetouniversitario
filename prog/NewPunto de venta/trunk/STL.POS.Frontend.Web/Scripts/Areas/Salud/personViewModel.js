function personViewModel() {
    var self = this;

    //This method helps serialization to get the exact info
    self.toJSON = function () {
        var copy = ko.toJS(self);
        copy.adicComplications = self.adicComplications() == 1;
        copy.adicTransplant = self.adicTransplant() == 1;
        delete copy.parent;
        delete copy.modelList;
        delete copy.validationRules;
        delete copy.provincesList;
        delete copy.citiesList;
        delete copy.workProvincesList;
        delete copy.workCitiesList;
        return copy;
    };

    self.id = ko.observable(Math.floor((Math.random() * 10000) + 1) * -1);

    self.titular = ko.observable();
    self.firstName = ko.observable();
    self.secondName = ko.observable();
    self.firstSurname = ko.observable();
    self.secondSurname = ko.observable();
    self.relationship = ko.observable();
    self.student = ko.observable();
    self.dateOfBirth = ko.observable();
    self.email1 = ko.observable();
    self.email2 = ko.observable();
    self.email3 = ko.observable();
    self.phoneNumber = ko.observable();
    self.countryId = ko.observable();
    self.provinceId = ko.observable();
    self.municipalityId = ko.observable();
    
    self.cityId = ko.observable();
    self.income = ko.observable();

    //Aditional information
    self.maritalStatus = ko.observable();
    self.company = ko.observable();
    self.job = ko.observable();
    self.yearsInCompany = ko.observable();
    self.mobile = ko.observable();
    self.workPhone = ko.observable();
    self.address = ko.observable();
    self.workCountryId = ko.observable();
    self.workProvinceId = ko.observable();
    self.workCityId = ko.observable();
    self.workAddress = ko.observable();
    self.partnerName = ko.observable();


    //PRECONDITIONS
    self.smoker = ko.observable();
    self.highPressure = ko.observable();
    self.weight = ko.observable();
    self.height = ko.observable();
    self.sexes = ko.observableArray(['Femenino', 'Masculino']);
    self.selectedSex = ko.observable();
    self.preexistingCondition = ko.observable();
    self.extremeSport = ko.observable();

    self.condition1 = ko.observable();
    self.condition1Description = ko.observable();
    self.condition2 = ko.observable();
    self.condition2Description = ko.observable();
    self.condition3 = ko.observable();
    self.condition3Description = ko.observable();

    //ADITIONALS
    self.adicComplications = ko.observable(0);
    self.adicTransplant = ko.observable(0);


    self.toString = ko.computed(function () {
        return self.firstName() + ' ' + self.firstSurname();
    });

    self.provincesList = ko.observableArray([]);
    self.citiesList = ko.observableArray([]);
    self.workProvincesList = ko.observableArray([]);
    self.workCitiesList = ko.observableArray([]);

    self.validationRules = {
        rules: {
            firstName: {
                nameSurname: true,
                required: true,
                maxlength: 50
            },
            secondName: {
                nameSurname: true,
                maxlength: 50
            },
            firstSurname: {
                nameSurname: true,
                required: true,
                maxlength: 50
            },
            secondSurname: {
                nameSurname: true,
                maxlength: 50
            },
            relationship: {
                required: true
            },
            dateOfBirth: {
                required: true,
                dateFormat: true
            },
            email: {
                required: true,
                maxlength: 255,
                emailWithDomain: true
            },
            email2: {
                maxlength: 255,
                emailWithDomain: true
            },
            email3: {
                maxlength: 255,
                emailWithDomain: true
            },
            phoneNumber: {
                required: true,
                maxlength: 50
            },
            cityId: {
                required: true
            },
            income: {
                required: true
            },

            weight: {
                required: true,
                number: true
            },
            height: {
                required: true,
                number: true
            },
            dateOfBirth: {
                required: true,
                dateFormat: true
            },
            sexo: {
                required: true
            },
            maritalStatus: {
                required: true
            },
            partnerName: {
                nameSurname: true,
                maxlength: 50
            },
            job: {
                required: true,
                maxlength: 50
            },
            company: {
                required: true,
                maxlength: 50
            },
            yearsInCompany: {
                required: true
            },
            address: {
                required: true,
                maxlength: 50
            },
        },
        messages: {
            firstName: {
                nameSurname: 'El Primer nombre sólo permite caracteres alfabéticos.',
                required: 'El Primer Nombre es requerido.',
                maxlength: 'El Primer Nombre no puede tener más de 50 caracteres de longitud.'
            },
            secondName: {
                nameSurname: 'El Segundo nombre sólo permite caracteres alfabéticos.',
                maxlength: 'El Segundo Nombre no puede tener más de 50 caracteres de longitud.'
            },
            firstSurname: {
                nameSurname: 'El Primer Apellido sólo permite caracteres alfabéticos.',
                required: 'El Primer Apellido es requerido.',
                maxlength: 'El Primer Apellido no puede tener más de 50 caracteres de longitud.'
            },
            secondSurname: {
                nameSurname: 'El Segundo Apellido sólo permite caracteres alfabéticos.',
                maxlength: 'El Segundo Apellido no puede tener más de 50 caracteres de longitud.'
            },
            relationship: {
                required: 'Debe seleccionar una Relación con el Solicitante.'
            },
            dateOfBirth: {
                required: 'La Fecha de Nacimiento es requerida.',
                dateFormat: 'Debe ingresar una Fecha de Nacimiento válida.'
            },
            email: {
                required: 'El Email es requerido.',
                maxlength: 'El Email no puede tener más de 255 caracteres de longitud.',
                emailWithDomain: 'El Email debe ser una dirección de correo electrónico válida.'
            },
            email2: {
                maxlength: 'El Email no puede tener más de 255 caracteres de longitud.',
                emailWithDomain: 'El Email debe ser una dirección de correo electrónico válida.'
            },
            email3: {
                maxlength: 'El Email no puede tener más de 255 caracteres de longitud.',
                emailWithDomain: 'El Email debe ser una dirección de correo electrónico válida.'
            },
            phoneNumber: {
                required: 'El Teléfono es requerido.',
                maxlength: 'El Teléfono no puede tener más de 50 caracteres de longitud.'
            },
            cityId: {
                required: 'Debe seleccionar una Ciudad de la lista.'
            },
            income: {
                required: 'Debe seleccionar un Promedio Ingreso Familiar Anual de la lista.'
            },

            weight: {
                required: 'El Peso es requerido.',
                number: 'Debe igresar un Peso en kilos válido.'
            },
            height: {
                required: 'La Estatura es requerida.',
                number: 'Debe igresar una Estatura en metros válida.'
            },
            dateOfBirth: {
                required: 'La Fecha de Nacimiento es requerida',
                dateFormat: 'Debe ingresar una Fecha de Nacimiento válida',
            },
            sexo: {
                required: 'Debe seleccionar Sexo'
            },
            maritalStatus: {
                required: 'El Estado Civil es requerido'
            },
            partnerName: {
                nameSurname: 'El Nombre del Cónyuge sólo permite caracteres alfabéticos.',
                maxlength: 'El Nombre del Cónyuge no puede tener más de 50 caracteres de longitud.'
            },
            job: {
                required: 'La Posición es requerida',
                maxlength: 'La Posición no puede tener más de 50 caracteres de longitud'
            },
            company: {
                required: 'El Nombre de la Empresa es requerido',
                maxlength: 'El Nombre de la Empresa no puede tener más de 50 caracteres de longitud'
            },
            yearsInCompany: {
                required: 'Los Años en la Empresa son requeridos'
            },
            address: {
                required: 'El Domicilio es requerido',
                maxlength: 'El Domicilio no puede tener más de 50 caracteres de longitud'
            },
        }
    };

    self.totalPrime = ko.observable(0).money();
    //self.totalPrime = ko.computed(function () {
    //    var total = 0;
    //    if (self.primesRetrieved()) {
    //        total = self.productLimitSet().SdPrime() + self.productLimitSet().TpPrime() + self.productLimitSet().ServicesPrime();
    //    }
    //    return roundToTwoDecimals(total);
    //}).money();

    self.totalDiscount = ko.observable(0).money();
    //self.totalDiscount = ko.computed(function () {
    //    if (self.parent && self.parent.payment) {
    //        var total = self.totalPrime() * (self.parent.payment.currentDiscountPercentage() / 100);
    //        return roundToTwoDecimals(total);
    //    }
    //    else
    //        return 0;
    //});

    self.totalIsc = ko.observable(0).money();
    //self.totalIsc = ko.computed(function () {
    //    if (self.parent && self.parent.payment) {
    //        var total = (self.totalPrime() - self.totalDiscount()) * (self.parent.payment.iscPercentage() / 100);
    //        return roundToTwoDecimals(total);
    //    }
    //    else
    //        return 0;
    //});

    self.countryId.subscribe(function (id) {
        $.ajax({
            url: "/PosAuto/GetProvinces",
            dataType: 'json',
            async: false,
            data: { countryId: id },
            success: function (data) {
                self.provincesList(data);
                $.ajax({
                    url: "/PosAuto/GetCities",
                    dataType: 'json',
                    async: false,
                    data: { countryId: id },
                    success: function (data) {
                        self.citiesList(data);
                    }
                });
            }
        });
    });

    self.workCountryId.subscribe(function (id) {
        $.ajax({
            url: "/PosAuto/GetProvinces",
            dataType: 'json',
            async: false,
            data: { countryId: id },
            success: function (data) {
                self.workProvincesList(data);
                $.ajax({
                    url: "/PosAuto/GetCities",
                    dataType: 'json',
                    async: false,
                    data: { countryId: id },
                    success: function (data) {
                        self.workCitiesList(data);
                    }
                });
            }
        });
    });

    self.clear = function () {
        self.titular(false);
        self.firstName('');
        self.secondName('');
        self.firstSurname('');
        self.secondSurname('');
        self.relationship(undefined);
        self.student(false);
        self.dateOfBirth('');
        self.email1('');
        self.email2('');
        self.email3('');
        self.phoneNumber('');
        self.municipalityId(undefined);
        self.cityId(undefined);
        self.income(undefined);
        self.address("");

        //Aditional information
        self.maritalStatus(undefined);
        self.company("");
        self.job(undefined);
        self.yearsInCompany("");
        self.phoneNumber("");
        self.mobile("");
        self.workPhone("");
        self.countryId(idCountryDefault);
        self.provinceId(undefined);
        self.cityId(undefined);
        self.workAddress("");
        self.partnerName("");
    };

    self.personDataComplete = function () {
        var completed = self.firstName() &&
        self.firstSurname() &&
        (self.titular() || !self.titular() && self.relationship())
        self.dateOfBirth() &&
        self.email1() &&
        self.phoneNumber() &&
        self.cityId() &&
        (!self.titular() || self.titular() && self.income());

        return completed;
    };

    self.personAditionalDataComplete = function () {

        var complete = self.maritalStatus() != undefined &&
            self.company() &&
            self.job() != undefined &&
            self.yearsInCompany() != undefined &&
            self.maritalStatus() != undefined &&
            self.address() &&
            self.phoneNumber();

        return complete;
    };

    self.preconditionDataComplete = function () {

        var complete = self.smoker() != undefined &&
            self.highPressure() != undefined &&
            self.weight() != undefined &&
            self.height() != undefined &&
            self.selectedSex() != undefined &&
            self.preexistingCondition() != undefined &&
            self.extremeSport() != undefined;

        switch (self.preexistingCondition()) {
            case 1:
                if (!self.condition1())
                    complete = false;
                break;
            case 2:
                if (!self.condition1() || !self.condition2())
                    complete = false;
                break;
            case 3:
                if (!self.condition1() || !self.condition2() || !self.condition3())
                    complete = false;
                break;
        }

        return complete;
    };

    self.loadModel = function (model) {
        self.id(model.Id);
        self.firstName(model.FirstName);
        self.secondName(model.SecondName);
        self.firstSurname(model.FirstSurname);
        self.secondSurname(model.SecondSurname);
        self.titular(model.IsPrincipal);

        self.relationship(model.Relationship);
        self.student(model.IsStudent);
        self.dateOfBirth($.datepicker.formatDate(getCurrentDateFormat(), moment(model.DateOfBirth).toDate()));
        self.email1(model.Email1);
        self.email2(model.Email2);
        self.email3(model.Email3);
        self.phoneNumber(model.PhoneNumber);
        self.countryId(model.City.Country_Id);
        self.provinceId(model.City.State_Prov_Id);
        self.municipalityId(model.City.Domesticreg_Id + '-' + model.City.State_Prov_Id + '-' + model.City.Municipio_Id);
        self.cityId(model.City.Domesticreg_Id + '-' + model.City.State_Prov_Id + '-' + model.City.Municipio_Id + '-' + model.City.City_Id);
        self.income(model.Income);
        self.address(model.Address);
        self.totalPrime(model.Prime);

        self.smoker(model.IsSmoker);
        self.highPressure(model.IsHighPressure);
        self.weight(model.Weight);
        self.height(model.Height);
        self.selectedSex(model.Sex);
        self.preexistingCondition((model.Condition1 ? 1 : 0) + (model.Condition2 ? 1 : 0) + (model.Condition3 ? 1 : 0));
        self.extremeSport(model.IsExtremeAthlete);

        self.condition1(model.Condition1);
        self.condition1Description(model.Condition1Description);
        self.condition2(model.Condition2);
        self.condition2Description(model.Condition2Description);
        self.condition3(model.Condition3);
        self.condition3Description(model.Condition3Description);

        //Aditional information
        self.maritalStatus(model.MaritalStatus);
        self.partnerName(model.PartnerName);
        self.company(model.Company);
        self.job(model.Job);
        self.yearsInCompany(model.YearsInCompany);
        self.mobile(model.Mobile);
        self.workPhone(model.WorkPhone);
        self.workCountryId(model.WorkCity == null ? model.City.Country_Id : model.WorkCity.Country_Id);
        self.workProvinceId(model.WorkCity == null ? undefined : model.WorkCity.State_Prov_Id);
        self.workCityId(model.WorkCity == null ? undefined : model.WorkCity.Domesticreg_Id + '-' + model.WorkCity.State_Prov_Id + '-' + model.WorkCity.City_Id);
        self.workAddress(model.WorkAddress);

        self.adicComplications(model.Complication ? 1 : 0);
        self.adicTransplant(model.Transplant ? 1 : 0);
    }

}