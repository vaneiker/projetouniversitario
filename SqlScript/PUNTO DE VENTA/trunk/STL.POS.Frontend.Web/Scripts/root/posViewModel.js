﻿var stepStatuses = {
    PENDING: 0,
    INPROGRESS: 1,
    COMPLETED: 2
}

function posViewModel() {
        var self = this;

    self.test = ko.observable("POSVIEWMODEL");
    self.quotation = ko.observable();
    self.module = ko.observable("auto");
    self.currentStepId = ko.observable(0);
    self.steps = ko.observableArray([]);
    self.stepClosed = ko.observable(false);
    self.mainData = ko.observable();
    self.quotations = ko.observableArray();
    self.cities = ko.observableArray();
    self.provinces = ko.observableArray();
    self.typeInvoiceList = ko.observableArray();
    self.MessageInvoiceSpecial = ko.observableArray();
    //julisy amador
    self.Municipalities = ko.observableArray();
    self.IsFinanced = ko.observable(false);
    self.period = ko.observable();
    self.monthlyPayment = ko.observable();
    self.FinancingMonths = ko.observableArray();
    //self.amortizationTable = ko.observableArray([{ periodNumber: "", balance: "", date: "", interest: "", payment: "", principal: "", previousBalance: "" }]);
    self.yearMonths = ko.observableArray([
                                            { expirationDateMonth: 1, name: '1' },
                                            { expirationDateMonth: 2, name: '2' },
                                            { expirationDateMonth: 3, name: '3' },
                                            { expirationDateMonth: 4, name: '4' },
                                            { expirationDateMonth: 5, name: '5' },
                                            { expirationDateMonth: 4, name: '6' },
                                            { expirationDateMonth: 7, name: '7' },
                                            { expirationDateMonth: 8, name: '8' },
                                            { expirationDateMonth: 9, name: '9' },
                                            { expirationDateMonth: 10, name: '10' },
                                            { expirationDateMonth: 11, name: '11' },
                                            { expirationDateMonth: 12, name: '12' }]);

    

    
    self.CreditCardTypes = ko.observableArray([]);
    self.yearListCreditCard = ko.observableArray([]);
    self.yearList = ko.observableArray([{ expirationDateYear: '', Name: '' }]);

    self.EconomicActivities = ko.observableArray([{ Segment: '', name: '' }]);
    self.creditCardTypeId = ko.observable();
    //self.creditCardNumber = ko.observable();
    self.expirationDateYear = ko.observable();
    self.expirationDateMonth = ko.observable();
    self.cardHolder = ko.observable();
    //self.cardMask = ko.observable('****************');
    //julisy amador

    self.sideViewCustom = ko.observable();

    self.agentList = ko.observableArray([]);
    self.agent = ko.observable();

    self.disableEditVehicle = ko.observable(false);  

    self.emailDestList = ko.observableArray();
    self.addEmailDest = function () {
        self.emailDestList.push(ko.observable());
        $('.modal.popup03.popupEmail table input[type="text"]:last').focus();
    };
    self.showEmailSender = function (sendFunction) {
        if (self.quotation()) {
            self.emailDestList([ko.observable()]);
            $('.modal.popup03.popupEmail').show();
            $('.modal.popup03.popupEmail table input[type="text"]:first').focus();
            $('#reportFrame').hide();

            $(".modal.popup03.popupEmail #send").unbind("click");
            $(".modal.popup03.popupEmail #send").bind("click", sendFunction ? function () { sendFunction(); $('#reportFrame').show(); } : self.sendReportEmail);
        }
    };
    self.sendReportEmail = function () {
        if (self.emailDestList().length) {
            if (self.mainData && self.mainData().sendReportEmail) {
                self.mainData().sendReportEmail(self.emailDestList());
            }
        }
    };

    self.printReporteCotizacion = function () {
        if (self.mainData && self.mainData().printReporteCotizacion) {
            self.mainData().printReporteCotizacion();
        }
    };

    self.saveQuotation = function (onSuccessCallback) {
        /**/
        if (self.mainData && self.mainData().saveQuotation) {
            self.mainData().saveQuotation(true, onSuccessCallback);
        }
    }

    self.newQuotationNoQuestion = function () {

        if (self.mainData()) {
            if (self.mainData().reset) {
                self.mainData().reset();
                self.quotation(null);
                self.mainData().reset();
            }
            if (self.mainData().initSteps)
                self.mainData().initSteps();
        }
        _.each(self.steps(), function (s) { s.status(stepStatuses.PENDING); });
        self.currentStepId(1);

        $('.overlaypp').hide();
    }

    self.newQuotation = function () {
        if (self.quotation()) {
            showQuestion("Cotización", "¿Desea descartar los cambios de la cotización en curso e iniciar una nueva cotización?", function () {
                self.newQuotationNoQuestion();
            });
        }
    }

    self.allVehicles = function () {

        if (self.mainData && self.mainData().vehicles()) {

            return self.mainData().vehicles();
        }
    }

    self.colorList = ko.observableArray();
    self.jobList = ko.observableArray();

    self.nationalitiesList = ko.observableArray();
    self.maritalStatusList = ko.observableArray([
        { id: 1, name: 'Casado' },
        { id: 2, name: 'Divorciado' },
        { id: 3, name: 'Soltero' },
        { id: 4, name: 'Unión Libre' }
    ]);

    self.accidentsList = ko.observableArray([{ id: 0, name: '0' },
                    { id: '1', name: '1' },
                    { id: '2', name: '2' },
                    { id: '3', name: '3' },
                    { id: '4', name: '4' },
                    { id: '5', name: '5' },
                    { id: '6', name: '6' },
                    { id: '7', name: '7' },
                    { id: '8', name: '8' },
                    { id: '9', name: '9' },
                    { id: '10', name: '10' },
                    { id: '+10', name: '+10' }
    ]);

    self.getYearsInCompany = function (n) {
        var arr = new Array();
        for (var i = 0; i <= n; i++)
            arr.push({ id: i, name: i.toString() });
        return arr;
    }

    self.showReportQuotation = function () {
        if (self.mainData().showReportQuotation)
            self.mainData().showReportQuotation();
    }

    self.downloadReportQuotation = function () {
        if (self.mainData().downloadReportQuotation)
            self.mainData().downloadReportQuotation();
    }

    self.emailReportQuotation = function () {
        if (self.mainData().emailReportQuotation)
            self.mainData().emailReportQuotation();
    }


    self.identificationTypeList = ko.observableArray();
    self.RelationshipList = ko.observableArray();


    self.yearsInCompanyList = ko.observableArray(self.getYearsInCompany(60));

    self.yearsDrivingList = ko.observableArray(self.getYearsInCompany(60));

    //1         = EFECTIVO
    //2         =  TARJETAS
    //3         = CHEQUES
    //4         =  OTROS PAGOS

    self.wayToPayList = ko.observableArray();


    self.creditCardTypeList = ko.observableArray([{ id: 1, name: 'American Express' },
                    { id: 2, name: 'Master Card' },
                    { id: 3, name: 'Visa' }]),

    self.months = ko.observableArray([{ id: 1, name: '1' },
                    { id: 2, name: '2' },
                    { id: 3, name: '3' },
                    { id: 4, name: '4' },
                    { id: 5, name: '5' },
                    { id: 6, name: '6' },
                    { id: 7, name: '7' },
                    { id: 8, name: '8' },
                    { id: 9, name: '9' },
                    { id: 10, name: '10' },
                    { id: 11, name: '11' },
                    { id: 12, name: '12' }]),

    self.typeAccounts = ko.observableArray([{ id: 1, name: 'Ahorro' },
                    { id: 0, name: 'Corriente' }]),

    //self.relationshipList = ko.observableArray([
    //                { id: 'Mismo', name: 'Mismo' },
    //                { id: 'Compañero de Vida', name: 'Compañero de Vida' },
    //                { id: 'Cónyuge', name: 'Cónyuge' },
    //                { id: 'Hija', name: 'Hija' },
    //                { id: 'Hijo', name: 'Hijo' }]),

    self.incomeList = ko.observableArray([{ id: 1, name: 'USD $5,000 a $10,000' },
                    { id: 2, name: 'USD $10,000 a $15,000' },
                    { id: 3, name: 'USD $15,000 a $20,000' },
                    { id: 4, name: 'USD $20,000 a $25,000' },
                    { id: 5, name: 'USD $25,000 a $30,000' }]),

    self.boolList = ko.observableArray([{ id: 0, name: 'No' }, { id: 1, name: 'Si' }]),

    self.countConditionList = ko.observableArray([{ id: 0, name: 'No' },
                    { id: 1, name: 'Si, 1 Enfermedad' },
                    { id: 2, name: 'Si, 2 Enfermedades' },
                    { id: 3, name: 'Si, 3 Enfermedades' }]),

    self.conditionList = ko.observableArray([
                    { id: 'Cáncer', name: 'Cáncer' },
                    { id: 'Derrame o Infarto Cerebral', name: 'Derrame o Infarto Cerebral' },
                    { id: 'Fallo Renal', name: 'Fallo Renal' },
                    { id: 'Infarto Miocardial', name: 'Infarto Miocardial' },
                    { id: 'Revascularización Coronaria', name: 'Revascularización Coronaria' }]),


     self.ForeingLicenceList = ko.observableArray([{ id: 1, name: 'Sí' },
                        { id: 2, name: 'No' }]),


    self.setHistory = function (id) {
        window.history.pushState({ order: id }, '');
    }

    self.setCurrentStateHistory = function (id) {
        window.history.replaceState({ order: id }, '');
    }

    self.setSelectedStep = function (id, isBackStep) {
        var backstep = isBackStep || false;

        if (self.mainData()) {
            if (self.mainData().getStepStatus) {
                if (self.mainData().getStepStatus(id) == stepStatuses.COMPLETED
                    || id == 1
                    || (self.mainData().getStepStatus(self.currentStepId()) == stepStatuses.COMPLETED && self.currentStepId() + 1 == id)
                    || (self.mainData().getStepStatus(id - 1) == stepStatuses.COMPLETED && (self.mainData().getStepStatus(id) == stepStatuses.PENDING || (self.mainData().getStepStatus(id) == stepStatuses.INPROGRESS)))) {
                    var prevStep = self.currentStep();
                    self.currentStepId(id);
                    var nextStep = self.currentStep();

                    if (self.currentStep().updateStepData)
                        self.currentStep().updateStepData();

                    self.updateStepsStatus();
                }
            }
            else
                alert('Please define getStepStatus method in viewmodel');
        }
        else {
            var prevStep = self.currentStep();
            self.currentStepId(id);
            var nextStep = self.currentStep();

            self.updateStepsStatus();

            if (!backstep)
                window.history.pushState({ order: id }, '');
        }
        if (self.currentStep().setFocus)
            self.currentStep().setFocus(id);
    };

    self.currentStep = function () {
        var first = _.find(self.steps(), function (item) { return item.order() == self.currentStepId(); });
        return first;
    }

    self.nextStep = function (onSuccessCallback) {
        /**/
        var ammount = self.steps().length;
        if (ammount > self.currentStepId()) {
            self.saveQuotation(onSuccessCallback);
            var prevStep = self.currentStep();
            self.setSelectedStep(self.currentStepId() + 1);
            var currStep = self.currentStep();
            self.setHistory(self.currentStepId());
        }
    }

    self.prevStep = function () {
        var ammount = self.steps().length;

        self.saveQuotation();
        if (self.currentStepId() > 1) {
            var posStep = self.currentStep();
            self.setSelectedStep(self.currentStepId() - 1);
            var currStep = self.currentStep();
            self.setHistory(self.currentStepId());
        }
    }

    self.updateStepsStatus = function () {
        _.each(self.steps(), function (step) {
            step.status(self.mainData().getStepStatus(step.order()));
        });
    }

    self.showOurProducts = function () {
        if (self.mainData() && self.mainData().showOurProducts)
            self.mainData().showOurProducts();
    }

    self.loadQuotation = function (quotId) {

        if (self.mainData() && self.mainData().loadQuotation)
            self.mainData().loadQuotation(quotId);
    };

    window.onpopstate = function (event) {
        if (event.state && event.state.order) {
            self.setSelectedStep(event.state.order, true);
        }
    };

    $(document).ready(function () {

        //$.getJSON("/PoSAuto/GetCities", function (data) {
        //    self.cities(data);
        //});

        $.ajax({
            url: "/PosAuto/GetCountries",
            dataType: 'json',
            async: false,
            success: function (data) {
                self.nationalitiesList(data);
            }
        });

        $.getJSON("/PoSAuto/GetProvinces", function (data) {
            self.provinces(data);
        });

        //$.ajax({
        //    url: '/PoSAuto/GetMunicipalities',
        //    dataType: 'json',
        //    async: false,
        //    success: function (data) {
        //        self.Municipalities(data);
        //    }
        //});

        $.ajax({
            url: '/PoSAuto/GetTypesInvoice',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.typeInvoiceList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetIdentificationTypes',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.identificationTypeList(data);
            }
        });


        $.ajax({
            url: '/PoSAuto/GetWayToPay',
            dataType: 'json',
            async: false,
            success: function (data) {
                //1         =  EFECTIVO
                //2         =  TARJETAS
                //3         =  CHEQUES
                //4         =  OTROS PAGOS
                self.wayToPayList(data);
            }
        });


        $.ajax({
            url: '/PoSAuto/GetColors',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.colorList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetJobs',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.jobList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetRelationShips',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.RelationshipList(data);
            }
        });
        
    });
}