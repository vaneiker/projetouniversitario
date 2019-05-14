
function saludViewModel(posVm) {
    var self = this;
    self.parent = posVm;

    //#region [Properties]
    self.test = ko.observable("SALUDVIEWMODEL");
    self.persons = ko.observableArray([]);

    self.amountToPayEntered = ko.observable(0).money();
    self.minAllowedAmountToPay = ko.observable();

    self.totalPrime = ko.computed(function () {
        var total = 0;
        _.each(self.persons(), function (person) { total += person.totalPrime(); });
        return total;
    }).money();

    self.totalDiscount = ko.computed(function () {
        var total = 0;
        _.each(self.persons(), function (person) { total += person.totalDiscount(); });
        var rounded = roundToTwoDecimals(total);
        return rounded;
    }).money();

    self.totalIsc = ko.computed(function () {
        var total = 0;
        _.each(self.persons(), function (person) { total += person.totalIsc(); });
        return total;
    }).money();

    self.totalToPay = ko.computed(function () {
        var value = self.totalPrime() - self.totalDiscount() + self.totalIsc();
        var minPercent = roundToTwoDecimals(value * 0.25);
        self.minAllowedAmountToPay(minPercent);
        return value;
    }).money();

    self.newPerson = ko.observable();
    self.editingPerson = null;
    self.currentPersonToPreconditionApply = ko.observable();
    self.infoAdPerson = ko.observable();

    self.currentPreconditionSmoker = ko.observable();
    self.currentPreconditionHighPressure = ko.observable();
    self.currentPreconditionWeight = ko.observable();
    self.currentPreconditionHeight = ko.observable();
    self.currentPreconditionSelectedSex = ko.observable();
    self.currentPreconditionPreexistingCondition = ko.observable();
    self.currentPreconditionExtremeSport = ko.observable();
    self.currentPreconditionCondition1 = ko.observable();
    self.currentPreconditionCondition1Description = ko.observable();
    self.currentPreconditionCondition2 = ko.observable();
    self.currentPreconditionCondition2Description = ko.observable();
    self.currentPreconditionCondition3 = ko.observable();
    self.currentPreconditionCondition3Description = ko.observable();

    //Valores para paso 3 "Beneficios"
    self.planTypeSelected = ko.observable();
    self.planSelected = ko.observable();
    self.deducibleSelected = ko.observable();

    self.currentRate = ko.computed(function () {
        var total = 0;
        _.forEach(self.persons(), function (person) { total += person.totalPrime() ? person.totalPrime() : 0 });
        return total;
    }).money(); // ko.observable(0).money();

    self.getRates = function () {
        var currPlan = self.planSelected();
        var currDeducible = self.deducibleSelected();
        if (currPlan && currDeducible) {
            $.ajax({
                url: "/PosSalud/GetRates",
                method: 'POST',
                dataType: 'json',
                async: false,
                data: {
                    plan: currPlan,
                    deducible: currDeducible,
                    persons: ko.toJSON(self.persons())
                },
                success: function (data) {
                    var principal = _.find(self.persons(), function (item) { return item.id() == data.principal.id });
                    principal.totalPrime(data.principal.amount);
                    if (data.spouse) {
                        var spouse = _.find(self.persons(), function (item) { return item.id() == data.spouse.id });
                        spouse.totalPrime(data.spouse.amount);
                    }
                    if (data.amountPerChild > 0) {
                        var children = _.filter(self.persons(), function (item) { return item.relationship() == 'Hijo' || item.relationship() == 'Hija' });
                        _.forEach(children, function (item) { item.totalPrime(data.amountPerChild) });
                    }

                    //self.currentRate(data.total);
                },
                error: function () {
                    //self.currentRate(0);
                }
            });
        }
        else {
            return 0;
        }
    };

    self.currentStartDateSelected = ko.observable();
    self.currentEndDateSelected = ko.observable();

    self.payment = new paymentViewModel();
    self.showPayment = ko.observable(false);

    self.currentQuotationNumberSubscription = null;

    self.saludPlanTypeList = ko.observableArray([{
        id: 0,
        name: 'Salud Internacional',
        plans: ko.observableArray(),
    },
                   {
                       id: 1,
                       name: 'Enfermedades Críticas',
                       plans: ko.observableArray(),
                   }]),

    self.saludPlanList = ko.computed(function () {

        if (self.planTypeSelected() != null) {
            if (self.planTypeSelected() == 0) {
                return [{ id: 1, name: 'Elite' }, { id: 2, name: 'Select' }];
            }
            if (self.planTypeSelected() == 1) {
                return [{ id: 3, name: 'Serenity' }];
            }
        }
        else {
            return [];
        }
    });

    self.deducibleList = ko.computed(function () {
        if (self.planTypeSelected() != null) {
            if (self.planTypeSelected() == 0) {
                return [{ id: 1000, name: '$1,000' },
                    { id: 2500, name: '$2,500' },
                    { id: 5000, name: '$5,000' },
                    { id: 10000, name: '$10,000' },
                    { id: 20000, name: '$20,000' }];
            }
            if (self.planTypeSelected() == 1) {
                return [{ id: 25000, name: '$25,000' },
                                   { id: 50000, name: '$50,000' }];
            }
        }
        else
            return [];
    });





    //#endregion

    //#region [Person edition methods]

    self.addPerson = function (formElement) {

        $('#dateOfBirth').removeAttr('readonly');
        if ($('#addPersonForm').valid()) {

            var person = null;

            var isEditing = self.editingPerson != null;

            if (isEditing)
                person = self.editingPerson;
            else
                person = new personViewModel();

            person.student(undefined);
            if (self.newPerson.titular()) {
                _.each(self.persons(), function (item) {
                    if (item.titular() && item.id() != person.id()) {
                        item.relationship(undefined);
                        item.titular(false);
                        showError(['Verifique la <b>Relación con el Solicitante</b> de los asegurados.'], 'Asegurados', 'Se cambió la titularidad del seguro');
                    }
                });

                person.income(self.newPerson.income());
            }
            else {
                person.income(undefined);
                if (self.newPerson.relationship() == 'Hijo' || self.newPerson.relationship() == 'Hija')
                    person.student(self.newPerson.student());
            }

            person.titular(self.newPerson.titular());
            person.firstName(self.newPerson.firstName());
            person.secondName(self.newPerson.secondName());
            person.firstSurname(self.newPerson.firstSurname());
            person.secondSurname(self.newPerson.secondSurname());
            person.relationship(self.newPerson.relationship());
            person.dateOfBirth(self.newPerson.dateOfBirth());
            person.email1(self.newPerson.email1());
            person.phoneNumber(self.newPerson.phoneNumber());
            person.countryId(self.newPerson.countryId());
            person.provinceId(self.newPerson.provinceId());
            person.cityId(self.newPerson.cityId());


            if (isEditing)
                self.editingPerson = null;
            else
                self.persons.push(person);

            var ppal = _.find(self.persons(), function (item) { return item.titular(); });
            if (ppal == null) {
                self.persons()[0].titular(true);
            }

            self.newPerson.clear();

        }
        $('#dateOfBirth').attr('readonly', 'readonly');
    };

    self.editPerson = function (pos) {
        self.editingPerson = self.persons()[self.persons().indexOf(pos)];

        self.newPerson.firstName(self.editingPerson.firstName());
        self.newPerson.secondName(self.editingPerson.secondName());
        self.newPerson.firstSurname(self.editingPerson.firstSurname());
        self.newPerson.secondSurname(self.editingPerson.secondSurname());
        self.newPerson.titular(self.editingPerson.titular());
        self.newPerson.relationship(self.editingPerson.relationship());
        self.newPerson.student(self.editingPerson.student());
        self.newPerson.dateOfBirth(self.editingPerson.dateOfBirth());
        self.newPerson.email1(self.editingPerson.email1());
        self.newPerson.phoneNumber(self.editingPerson.phoneNumber());
        self.newPerson.countryId(self.editingPerson.countryId());
        self.newPerson.provinceId(self.editingPerson.provinceId());
        self.newPerson.cityId(self.editingPerson.cityId());
        self.newPerson.income(self.editingPerson.income());
        return false;

    };

    self.removePerson = function (pos) {
        var personToRemove = self.persons()[self.persons().indexOf(pos)];
        self.persons.remove(personToRemove);
        if (self.editingPerson != null) {
            self.editingPerson = null;
            self.newPerson.clear();
        }
        var principal = _.find(self.persons(), function (item) { return item.titular() });
        if (principal == null && self.persons().length > 0) {
            self.persons()[0].titular(true);
            self.persons()[0].relationship('Mismo');
        }
    };

    self.saveCurrentPerson = function (formElement) {
        var currPerson = self.currentPersonToPreconditionApply();
        if ($('#savePreconditionForm').valid()) {
            if (currPerson != null && currPerson != undefined) {
                currPerson.smoker(self.currentPreconditionSmoker());
                currPerson.highPressure(self.currentPreconditionHighPressure());
                currPerson.weight(self.currentPreconditionWeight());
                currPerson.height(self.currentPreconditionHeight());
                currPerson.selectedSex(self.currentPreconditionSelectedSex());
                currPerson.preexistingCondition(self.currentPreconditionPreexistingCondition());
                currPerson.extremeSport(self.currentPreconditionExtremeSport());
                currPerson.condition1(self.currentPreconditionCondition1());
                currPerson.condition1Description(self.currentPreconditionCondition1Description());
                currPerson.condition2(self.currentPreconditionCondition2());
                currPerson.condition2Description(self.currentPreconditionCondition2Description());
                currPerson.condition3(self.currentPreconditionCondition3());
                currPerson.condition3Description(self.currentPreconditionCondition3Description());

                var currSize = _.size(self.persons());
                var currIndex = self.persons().indexOf(currPerson);
                if (currSize > 0) {
                    if (currSize == 1 || currIndex + 1 == currSize)
                        self.currentPersonToPreconditionApply(self.persons()[0]);
                    else
                        self.currentPersonToPreconditionApply(self.persons()[currIndex + 1]);
                }

                var pending = $.map(self.persons(), function (a, index) { if (!a.preconditionDataComplete()) return a.toString(); });

                //If this person is complete, show success message with pendings 
                if (currPerson.preconditionDataComplete()) {
                    if (pending.length)
                        showSuccess("Las condiciones médicas de " + currPerson.toString() + " han sido cargadas exitosamente.",
                            "Está pendiente por cargar las condiciones médicas de los siguientes asegurados:",
                            pending
                        );
                    else
                        showSuccess("Las condiciones médicas de todos los asegurados han sido cargadas exitosamente."
                            , "Continúe con el paso 3"
                        );
                }
                else { //else, show error message with pendings
                    if (pending.length)
                        showErrorAuto("Las condiciones médicas de " + currPerson.toString() + " no está completa.",
                            "Está pendiente por completar las condiciones médicas de los siguientes asegurados:",
                            pending
                        );
                }
            }
        }
    };

    self.saveCurrentBenefit = function () {
        //TODO
    };

    self.stepPreconditionsCompleted = function () {
        var incompletes = $.map(self.persons(), function (a, index) { if (!a.preconditionDataComplete()) return a.toString(); });
        if (incompletes.length > 0) {
            showError(['Debe completar las condiciones médicas del asegurado indicadas en rojo.'], 'Condiciones Médicas');
        }
        else
            self.parent.nextStep();
    };

    self.currentPersonToPreconditionApply.subscribe(function (item) {
        if (item) {
            self.currentPreconditionSmoker(item.smoker());
            self.currentPreconditionHighPressure(item.highPressure());
            self.currentPreconditionWeight(item.weight());
            self.currentPreconditionHeight(item.height());
            self.currentPreconditionSelectedSex(item.selectedSex());
            self.currentPreconditionPreexistingCondition(item.preexistingCondition());
            self.currentPreconditionExtremeSport(item.extremeSport());
            self.currentPreconditionCondition1(item.condition1());
            self.currentPreconditionCondition1Description(item.condition1Description());
            self.currentPreconditionCondition2(item.condition2());
            self.currentPreconditionCondition2Description(item.condition2Description());
            self.currentPreconditionCondition3(item.condition3());
            self.currentPreconditionCondition3Description(item.condition3Description());

            //$('#vehiclePrice').focus();
        }
    });

    self.persons.subscribe(function (changes) {

        _.each(changes, function (change) {
            if (change.status == 'added') {
                if (self.persons().length > 0) {
                    self.loadPersonsInfoAd(self.persons()[0]);
                }
            }
        });
    }, null, "arrayChange");

    self.cleanSubscription = null;

    self.enableSubscriptions = function (enable) {

        if (self.cleanSubscription)
            self.cleanSubscription.dispose();
        self.cleanSubscription = null;

        if (enable)
        {
            self.cleanSubscription = self.planTypeSelected.subscribe(function (newPlanType) {
                _.each(self.persons(), function (per) {
                    per.adicComplications(0);
                    per.adicTransplant(0);
                    per.totalPrime(null);
                });
            });
        }
    }

    self.loadPersonsInfoAd = function (person) {
        if (person != undefined) {
            self.infoAdPerson().id(person.id());
            self.infoAdPerson().firstName(person.firstName());
            self.infoAdPerson().secondName(person.secondName());
            self.infoAdPerson().firstSurname(person.firstSurname());
            self.infoAdPerson().secondSurname(person.secondSurname());
            self.infoAdPerson().countryId(person.countryId());
            self.infoAdPerson().provinceId(person.provinceId());
            self.infoAdPerson().cityId(person.cityId());
            self.infoAdPerson().dateOfBirth(person.dateOfBirth());
            self.infoAdPerson().email1(person.email1());
            self.infoAdPerson().email2(person.email2());
            self.infoAdPerson().email3(person.email3());
            self.infoAdPerson().phoneNumber(person.phoneNumber());
            self.infoAdPerson().relationship(person.relationship());
            self.getLimitsAgeForBirthDate(person.relationship() == 'Hijo' || person.relationship() == 'Hija', person.student(), function (minAgeDate, maxAgeDate) {
                $('#dateOfBirthAdd').datepicker("option", "maxDate", new Date(minAgeDate));
                $('#dateOfBirthAdd').datepicker("option", "minDate", new Date(maxAgeDate));
            });

            self.infoAdPerson().selectedSex(person.selectedSex());
            self.infoAdPerson().address(person.address());
            self.infoAdPerson().workAddress(person.workAddress());
            self.infoAdPerson().workCountryId(person.workCountryId());
            self.infoAdPerson().workProvinceId(person.workProvinceId());
            self.infoAdPerson().workCityId(person.workCityId());
            self.infoAdPerson().mobile(person.mobile());
            self.infoAdPerson().workPhone(person.workPhone());
            self.infoAdPerson().maritalStatus(person.maritalStatus());
            self.infoAdPerson().partnerName(person.partnerName());
            self.infoAdPerson().job(person.job());
            self.infoAdPerson().company(person.company());
            self.infoAdPerson().yearsInCompany(person.yearsInCompany());
        }
        else {
            self.infoAdPerson(new personViewModel());
        }
    };

    self.saveAdditionalPersonInfo = function (formElement) {
        if ($('#setAditionalPersonInfoForm').valid()) {
            var person = _.find(self.persons(), function (d) { return d.id() == self.infoAdPerson().id(); });

            if (person) {
                person.workCountryId(self.infoAdPerson().workCountryId());
                person.workProvinceId(self.infoAdPerson().workProvinceId());
                person.workCityId(self.infoAdPerson().workCityId());
                person.countryId(self.infoAdPerson().countryId());
                person.provinceId(self.infoAdPerson().provinceId());
                person.cityId(self.infoAdPerson().cityId());
                person.dateOfBirth(self.infoAdPerson().dateOfBirth());
                person.email1(self.infoAdPerson().email1());
                person.email2(self.infoAdPerson().email2());
                person.email3(self.infoAdPerson().email3());
                person.phoneNumber(self.infoAdPerson().phoneNumber());

                person.selectedSex(self.infoAdPerson().selectedSex())
                person.address(self.infoAdPerson().address());
                person.mobile(self.infoAdPerson().mobile());
                person.workPhone(self.infoAdPerson().workPhone());
                person.maritalStatus(self.infoAdPerson().maritalStatus());
                person.partnerName(self.infoAdPerson().partnerName());
                person.job(self.infoAdPerson().job());
                person.company(self.infoAdPerson().company());
                person.yearsInCompany(self.infoAdPerson().yearsInCompany());
                person.workAddress(self.infoAdPerson().workAddress());

                var currIndex = self.persons().indexOf(person);

                if (self.persons().length > currIndex + 1)
                    self.loadPersonsInfoAd(self.persons()[currIndex + 1])
                else
                    self.loadPersonsInfoAd(self.persons()[0]);

                //Success message
                var pending = $.map(self.persons(), function (a, index) { if (!a.personAditionalDataComplete()) return a.toString(); });
                if (pending.length)
                    showSuccess("Los datos del asegurado " + person.toString() + " han sido completados exitosamente.",
                        "Está pendiente por completar los datos de los siguientes asegurados:",
                        pending
                    );
            }
            return true;
        }
        else
            return false;
    }

    self.setAditionalPersonInfo = function (formElement) {
        self.saveAdditionalPersonInfo(formElement);
        return false;
    };

    //#endregion

    //#region [Step-related methods]

    self.reset = function () {
        self.newPerson.clear();
        self.newPerson.titular(true);
        self.persons([]);
        self.currentStartDateSelected($.datepicker.formatDate(getCurrentDateFormat(), new Date()));
        self.currentEndDateSelected($.datepicker.formatDate(getCurrentDateFormat(), new Date()));
        self.payment.applicant.frequency(null);
        self.payment.applicant.wayToPay(null);
        self.planTypeSelected(undefined);
        self.planSelected(undefined);
        self.deducibleSelected(undefined);
    }

    self.buyAfterQuickSteps = function () {
        if (self.planTypeSelected() == undefined) {
            showError(['Debe seleccionar un tipo de plan para poder comprar.'], 'Cotización');
            return;
        }
        if (self.planSelected() == undefined) {
            showError(['Debe seleccionar un plan para poder comprar.'], 'Cotización');
            return;
        }
        if (self.deducibleSelected() == undefined) {
            showError(['Debe seleccionar un deducible para poder comprar.'], 'Cotización');
            return;
        }

        //TODO: verificar si cargó todo lo correspondiente a beneficios

        self.initSteps();
    }

    self.firstStepAdvance = function () {
        var notCompleted = $.map(self.persons(), function (a, index) { if (!a.personDataComplete()) return a.toString(); });
        if (notCompleted.length > 0) {
            if (notCompleted.length)
                showError(notCompleted, "Asegurados",
                    "Verifique los datos de los siguientes asegurados:"
                );
            return;
        }
        self.parent.nextStep();
    }

    self.fourthStepAdvance = function () {
        if (self.saveAdditionalPersonInfo(null))
            self.parent.nextStep();
    }

    self.getStepStatus = function (stepId) {

        if (stepId == 1) {
            if (self.persons().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.persons(), function (item) { return !item.personDataComplete(); });
                if (notCompleted.length == 0)
                    return stepStatuses.COMPLETED;
                else
                    return notCompleted.length == self.persons().length ? stepStatuses.PENDING : stepStatuses.INPROGRESS;
            }
        }
        else if (stepId == 2) {
            if (self.persons().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.persons(), function (item) { return !item.preconditionDataComplete(); });
                if (notCompleted.length == 0)
                    return stepStatuses.COMPLETED;
                else
                    return notCompleted.length == self.persons().length ? stepStatuses.PENDING : stepStatuses.INPROGRESS;
            }
        }
        else if (stepId == 3) {
            //TODO: definir cuándo se tiene una cotización
            if (self.planTypeSelected() == undefined && self.planSelected() == undefined && !self.deducibleSelected() == undefined)
                return stepStatuses.PENDING;
            else {
                if (self.planTypeSelected() != undefined && self.planSelected() != undefined && self.deducibleSelected() != undefined)
                    return stepStatuses.COMPLETED;
                else
                    return stepStatuses.INPROGRESS;
            }
        }
        else if (stepId == 4) {
            if (self.persons().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.persons(), function (item) { return !item.personAditionalDataComplete(); });
                if (notCompleted.length == 0)
                    return stepStatuses.COMPLETED;
                else
                    return notCompleted.length == self.persons().length ? stepStatuses.PENDING : stepStatuses.INPROGRESS;
            }
        }
        else if (stepId == 5) {
            return self.getStepStatus(4) == stepStatuses.COMPLETED ? stepStatuses.COMPLETED : stepStatuses.INPROGRESS;
        }
        else
            return stepStatuses.PENDING;
    }

    self.updateStepData = function (stepId) {
        if (stepId == 2) {
            if (self.persons().length > 0)
                self.currentPersonToPreconditionApply(self.persons()[0]);
        }
        if (stepId == 4) {
            if (self.persons().length > 0)
                self.loadPersonsInfoAd(self.persons()[0]);
        }

    };

    self.quickStepsComplete = ko.computed(function () {
        var result = self.getStepStatus(1) == stepStatuses.COMPLETED
            && self.getStepStatus(2) == stepStatuses.COMPLETED
            && self.getStepStatus(3) == stepStatuses.COMPLETED;
        return result;
    }, this);

    //#endregion

    //#region [Quotation methods]

    self.setEndDateSubscriptionStatus = function (enabled) {

        //if (self.endDateSubscription) {
        //    _.each(self.endDateSubscription, function (subs) {
        //        subs.dispose();
        //    });
        //    self.endDateSubscription = null;
        //}

        //if (enabled) {
        //    var startDateSub = self.currentStartDateSelected.subscribe(function () {
        //        self.updateEndDate();
        //    });
        //    var termTypeSub = self.termTypeSelected.subscribe(function () {
        //        self.updateEndDate();
        //    });
        //    self.endDateSubscription = [startDateSub, termTypeSub];
        //}
    }

    self.setQuotationNumberNotifications = function (statusEnable) {
        if (statusEnable) {
            if (self.currentQuotationNumberSubscription != null)
                self.currentQuotationNumberSubscription.dispose();

            self.currentQuotationNumberSubscription = self.parent.quotation.subscribe(function (quotationNumber) {
                if (quotationNumber)
                    self.loadFromServer(quotationNumber.id);
            });
        }
        else {
            if (self.currentQuotationNumberSubscription != null)
                self.currentQuotationNumberSubscription.dispose();
        }
    }

    self.loadFromServer = function (quotationId) {
        $.getJSON("/PosSalud/GetFullQuotation", { quotationId: quotationId }, function (data) 
        {
            self.enableSubscriptions(false);

            self.reset();

            self.setEndDateSubscriptionStatus(false);
            //self.termTypeSelected(data.TermType ? data.TermType.Id : null);
            self.currentStartDateSelected($.datepicker.formatDate(getCurrentDateFormat(), data.StartDate ? new Date(data.StartDate) : new Date()));
            self.currentEndDateSelected($.datepicker.formatDate(getCurrentDateFormat(), data.EndDate ? new Date(data.EndDate) : new Date()));

            _.each(data.Persons, function (person) {
                var newPerson = new personViewModel();
                newPerson.loadModel(person);
                self.persons.push(newPerson);
            });

            self.planTypeSelected(data.PlanType);
            self.planSelected(data.Plan);
            self.deducibleSelected(data.Deductible);
            self.payment.applicant.frequency(data.PaymentFrequencyId);
            self.payment.applicant.wayToPay(data.PaymentWay);

            self.newPerson.titular(data.Persons.length == 0);


            self.setEndDateSubscriptionStatus(true);
            self.parent.updateStepsStatus();

            self.initSteps();

            self.enableSubscriptions(true);
        });
    }

    self.getQuotations = function (quotationListModel, selectQuotationId) {
        $.getJSON("/PosSalud/GetAvailableQuotations", function (data) {
            quotationListModel(data);
            if (selectQuotationId) {
                var quot = _.find(quotationListModel(), function (item) {
                    return item.id == selectQuotationId;
                });
                self.parent.quotation(quot);
            }
        });
    }

    self.saveQuotation = function (avoidSuccessMessage, onSuccessCallback) {
        var statusToSave = self.isQuotationValidForSaving();

        if (statusToSave.isValid) {
            var quotationId = null;
            if (self.parent.quotation() && self.parent.quotation().id)
                quotationId = self.parent.quotation().id;
            var discountPercentage = 0;

            if (self.payment.applicant.frequency() == 0)
                discountPercentage = self.payment.currentDiscountPercentage();
            $.post("PoSSalud/SaveQuotation", {
                quotationId: quotationId,
                persons: ko.toJSON(self.persons),
                payment: ko.toJSON(self.payment),
                planType: self.planTypeSelected(),
                plan: self.planSelected(),
                deductible: self.deducibleSelected(),
                startDate: self.currentStartDateSelected(),
                endDate: self.currentEndDateSelected(),
                totalPrime: self.totalPrime,
                totalIsc: self.totalIsc,
                totalDiscount: self.totalDiscount,
                discountPercentage: discountPercentage
            },
                function (data) {
                    _.each(data.updatePersons, function (item) {
                        var person = _.find(self.persons(), function (d) { return d.tempId == item.tempId });
                        if (person)
                            person.id(item.id);
                    });


                    if (!self.parent.quotation()) {
                        $.getJSON("PosSalud/GetAvailableQuotations", { userId: 1 }, function (quotationsData) {
                            self.setQuotationNumberNotifications(false);
                            self.parent.quotations(quotationsData);
                            var selQ = _.find(quotationsData, function (q) { return q.id == data.quotationId });
                            self.parent.quotation(selQ);
                            self.setQuotationNumberNotifications(true);
                        });
                    }

                    if (onSuccessCallback) {
                        onSuccessCallback();
                    }

                    if (!avoidSuccessMessage)
                        showSuccess("Cotización", "La cotización se ha guardado correctamente.")
                })
            return true;
        }
        else {
            showError(statusToSave.errorMessages, 'Guardar Cotización');
            return false;
        }
    }

    self.isQuotationValidForSaving = function () {
        var errorMessages = [];

        //Step 1: check step complete is enough
        var step1Complete = self.getStepStatus(1) == stepStatuses.COMPLETED;
        if (!step1Complete)
            errorMessages.push('La sección "Agregar Información del Asegurado" contiene errores.');

        //Step2: if at least one vehicle loaded, all the vehicles MUST be completed
        //if (self.persons().length > 0) {
        //    var incomplete = _.filter(self.persons(), function (item) { return !item.preconditionDataComplete() });
        //    if (incomplete.length != 0)
        //        errorMessages.push('La sección "Condiciones Médicas del Asegurado" contiene errores.');
        //}

        if (!self.payment.isValidForSaving()) {
            errorMessages.push('La sección "Pagos" contiene errores. Asegúrese que los campos Nombre del Solicitante y Número de Identificación Solicitante son alfabéticos y no sobrepasan los 50 caracteres de longitud.');
        }

        var isValid = errorMessages.length == 0;
        return { isValid: isValid, errorMessages: errorMessages };
    }

    //#endregion

    //#region [Side quotation resume methods]

    self.resumePricing = ko.computed(function () {
        var resume = new resumePricingViewModel();

        var columnsNames = eval($('#columnNames').val());
        var insuredType = eval($('#insuredType').val());

        resume.columns.push(new resumePricingItemViewModel().item(columnsNames[0]).align("left").className("c1"));
        resume.columns.push(new resumePricingItemViewModel().item(columnsNames[1]).align("center").className("c2"));
        resume.columns.push(new resumePricingItemViewModel().item(columnsNames[2]).align("center").className("c3"));
        resume.columns.push(new resumePricingItemViewModel().item("").align("center").className("c4").style("width: 32px;"));

        //var personsToEvaluate = _.filter(self.persons(), function (v) { return v.selectedProduct() != undefined });
        var personsToEvaluate = self.persons();
        if (personsToEvaluate.length > 0) {
            _.each(personsToEvaluate, function (person, index) {
                var personName = new resumePricingItemViewModel().item(person.toString()).align("left").className("c1");
                var tipo = new resumePricingItemViewModel().item(person.titular() ? insuredType[0] : insuredType[1]).align("center").className("c2");
                var prime = new resumePricingItemViewModel().item(person.totalPrime()).align("right").className("c3");
                var edit = new resumePricingItemViewModel().align("left").className("c4");
                edit.action.className("grid_icons cazul edit");
                edit.action.funct = function () { self.parent.mainData().initSteps(true); self.parent.setSelectedStep(3); self.parent.setHistory(3); $("#planTabs").children()[0].click(); };
                var resumeItem = [personName, tipo, prime, edit];

                resume.items.push(resumeItem);
                resume.total(resume.total() + person.totalPrime());
            });
        }

        if (self.getStepStatus(3) == stepStatuses.COMPLETED)
            resume.items.push(
                [new resumePricingItemViewModel().item("Plan").align("left").className("c1"),
                    new resumePricingItemViewModel().item("").align("left").className("c2"),
                    new resumePricingItemViewModel().item(self.planSelected()).align("right").className("c3"),
                    new resumePricingItemViewModel().item("").align("left").className("c4")]
            );

        return resume;

    });

    self.resumeSuplements = ko.computed(function () {
        var resume = new resumePricingViewModel();

        resume.items.push([new resumePricingItemViewModel().item("Complicaciones Embarazo").align("left").cSpan(3)]);

        var personsComplications = _.filter(self.persons(), function (p) { return p.adicComplications() == 1 });
        if (personsComplications.length > 0) {
            _.each(personsComplications, function (person, index) {
                var personName = new resumePricingItemViewModel().item(person.toString()).align("left").className("c1");
                var complication = new resumePricingItemViewModel().item("Si").align("right").className("c2");
                var edit = new resumePricingItemViewModel().align("left").className("c3");
                edit.action.className("grid_icons cazul edit");
                edit.action.funct = function () { self.parent.mainData().initSteps(true); self.parent.setSelectedStep(3); self.parent.setHistory(3); $("#planTabs").children()[1].click(); };
                var resumeItem = [personName, complication, edit];

                resume.items.push(resumeItem);
            });
        }

        resume.items.push([new resumePricingItemViewModel().item("Transplante").align("left").cSpan(3)]);
        var personsTransplant = _.filter(self.persons(), function (p) { return p.adicTransplant() == 1 });
        if (personsTransplant.length > 0) {
            _.each(personsTransplant, function (person, index) {
                var personName = new resumePricingItemViewModel().item(person.toString()).align("left").className("c1");
                var complication = new resumePricingItemViewModel().item("Si").align("right").className("c2");
                var edit = new resumePricingItemViewModel().align("left").className("c3");
                edit.action.className("grid_icons cazul edit");
                edit.action.funct = function () { self.parent.mainData().initSteps(true); self.parent.setSelectedStep(3); self.parent.setHistory(3); $("#planTabs").children()[1].click(); };
                var resumeItem = [personName, complication, edit];

                resume.items.push(resumeItem);
            });
        }

        return resume;
    });

    //#endregion

    //#region [Reports]

    self.showReportQuotation = function () {
        self.getReporteCotizacionSalud(function (reportUrl) {
            showReport(reportUrl, null);
        });
    };

    self.downloadReportQuotation = function () {
        self.getReporteCotizacionSalud(function (reportUrl) {
            //window.open(reportUrl);
            $("#a_load").remove();

            var a = document.createElement('a');
            a.id = "a_load";
            a.target = "_blank";
            a.download = "Cotizacion";
            a.href = reportUrl;

            a.click();
        });
    }

    self.getReporteCotizacionSalud = function (callback) {
        var quotationNumber = self.parent.quotation();

        var status = self.saveQuotation(true, function () {
            if (status) {
                if (quotationNumber) {
                    $.getJSON("/PosSalud/ReporteCotizacionSalud", { nroCotizacion: quotationNumber.id }, function (data) {
                        if (!data.error) {
                            callback(data.reportName);
                        }
                    });
                }
                else
                    showError(["Debe tener seleccionada una cotización, o guardar la cotización en curso."], "Ver Cotización en Progreso");
            }
        });
    };

    self.printReporteCotizacion = function () {
        self.getReporteCotizacionSalud(function (reportUrl) {

            $.getJSON("/PosSalud/PrintReport", { sourceFile: reportUrl }, function (data) {
                try {
                    $("#iframeTmp").remove();

                    var iframeTmp = document.createElement('iframe');
                    iframeTmp.id = "iframeTmp";
                    iframeTmp.src = data.reportName;
                    iframeTmp.style.display = 'none';

                    document.body.appendChild(iframeTmp);
                }
                catch (e) {
                    window.open(reportUrl, 'Print_Preview', 'resizable=1');
                }
            });
        });
    };

    self.sendReportEmail = function (emailDestList) {
        var fileName = undefined;
        if ($(".modal.autoPDF.report").is(":visible")) {
            fileName = $('.modal.autoPDF.report iframe.reportSource').attr('src');
        }
        $.getJSON("/PosSalud/EnviarReporteEmail", { destinatarios: JSON.stringify(ko.toJS(emailDestList)), idCotizacion: self.parent.quotation().id, reportName: fileName }, function (data) {
            if (data.error) {
                showErrorAuto("Envío de reporte", data.error);
            }
            else {
                $('.modal.popup03.popupEmail').hide();
                showSuccess("Envío de reporte", "El reporte se envió correctamente a los destinatarios.");
            }
        });
    };

    self.sendForm = function () {
        $.getJSON("/PosSalud/EnviarReporteEmail", { destinatarios: JSON.stringify(ko.toJS(self.parent.emailDestList())), idCotizacion: self.parent.quotation().id, reportName: "/Reports/Salud.pdf" }, function (data) {
            if (data.error) {
                showErrorAuto("Envío de reporte", data.error);
            }
            else {
                $('.modal.popup03.popupEmail').hide();
                showSuccess("Envío de reporte", "El reporte se envió correctamente a los destinatarios.");
            }
        });
    };

    //#endregion

    //#region [Helpers]

    self.setEndDateDatepickerStatus = function (endDateEnabled, minDateSet) {
        if ($('#endDate').datepicker)
            $('#endDate').datepicker('destroy');
        if (endDateEnabled) {
            if (minDateSet) {
                $('#endDate').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    minDate: minDateSet
                });
            }
            else {
                $('#endDate').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    minDate: new Date()
                });
            }
        }
    }

    self.pay = function (formElement) {

        if ($('#payForm').valid()) {

            self.saveQuotation(true, function () {
                var quotationId = self.parent.quotation().id;

                $('#paymentFormContainer').load('/CardNet/CardnetPayment/GeneratePostFormForAuthorization', { quotationId: quotationId }, function () {
                    $('#paymentFormContainer>form').submit();
                });

            });

        }
    };

    //#endregion

    self.getLimitsAgeForBirthDate = function (isSon, isStudent, callback) {
        $.ajax({
            url: "/PosSalud/GetLimitsAge",
            dataType: 'json',
            data: { isSon: isSon, isStudent: isStudent },
            async: false,
            success: function (data) {
                var minDate = moment(new Date()).add(data.min * -1, 'years');
                var maxDate = moment(new Date()).add(data.max * -1, 'years');
                callback(minDate, maxDate);
            }
        });

    }

    self.initSteps = function (quickSteps) {
        if (!self.quickStepsComplete() || quickSteps) {//initQuickSteps
            self.showPayment(false);
            self.parent.setSelectedStep(1);
        }
        else {//initPaymentSteps
            self.showPayment(true);
            self.parent.setSelectedStep(4);
        }
    }


    $(document).ready(function () {

        self.currentStartDateSelected($.datepicker.formatDate(getCurrentDateFormat(), new Date()));
        self.currentEndDateSelected($.datepicker.formatDate(getCurrentDateFormat(), new Date()));

        self.initSteps();

        $("#addPersonForm").validate(new personViewModel().validationRules);
        $("#savePreconditionForm").validate(new personViewModel().validationRules);

        $('.datepicker.dateOfBirth').datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "-100:+0",
            maxDate: new Date()
        });

        self.setEndDateDatepickerStatus(false);
        self.setEndDateSubscriptionStatus(true);

        self.newPerson.countryId(idCountryDefault);

        //For payment spteps
        $("#setAditionalPersonInfoForm").validate(new personViewModel().validationRules);
        //$("#setAditionalPreconditionForm").validate(new vehicleViewModel().validationRules);
        //$("#payForm").validate(self.payment.validationRules);
        //$('#creditCardNumber').mask('0000-0000-0000-0000');

        //self.getMinAgeForBirthDate(function (value) {
        $('#dateOfBirthAdd').datepicker({
            changeMonth: true,
            changeYear: true,
            //yearRange: "-100:+0",
            //maxDate: new Date()
        });
        //});

        ko.computed(function () {
            var isStudent = self.newPerson.student();
            var isSon = self.newPerson.relationship() == 'Hijo' || self.newPerson.relationship() == 'Hija';
            self.getLimitsAgeForBirthDate(isSon, isStudent, function (minAgeDate, maxAgeDate) {
                $('.dateOfBirth').datepicker("option", "maxDate", new Date(minAgeDate));
                $('.dateOfBirth').datepicker("option", "minDate", new Date(maxAgeDate));
            });
        }, this);
    });
}