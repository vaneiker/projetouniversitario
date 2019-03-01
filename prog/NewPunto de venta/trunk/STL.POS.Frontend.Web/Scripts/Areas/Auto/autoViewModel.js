﻿/// <reference path="D:\Proyectos\STL-PuntoDeVenta\trunk\3-Desarrollo\3.2 Solucion\STL.POS.Frontend.Web\Areas/Auto/Views/PoSAuto/StepCoverage.cshtml" />
var loanTypes = [
    'Vehicles',
    'Personal',
    'Payroll',
    'VehicleInsurance',
    'HouseInsurance',
    'LifeInsurace',
    'EnterpriseInsurance']

function autoViewModel(posVm) {
    var self = this;
    self.parent = posVm;

    //#region [Properties]
    self.test = ko.observable("AUTOVIEWMODEL");
    self.drivers = ko.observableArray([]);
    self.vehicles = ko.observableArray([]);
    self.FinalBeneficiary = ko.observableArray([]);
    self.PEP = ko.observableArray([]);

    self.prices = ko.observableArray([]);
    self.additionalProductList = ko.observableArray();
    self.amountToPayEntered = ko.observable(0).money();
    self.minAllowedAmountToPay = ko.observable();
    self.currentYear = ko.observable();
    self.quotationCoreNumber = ko.observable();

    self.vehicleYearsOldList = ko.observableArray([{ id: '0 Km', name: '0 Km' }, { id: 'Usado', name: 'Usado' }]);
    self.infoAdDriver = ko.observable();
    self.infoAdBeneficiaryFinal = ko.observable();
    self.infoAdPep = ko.observable();

    self.dateOfBirthSubscribe = null;
    self.IsFinanced = ko.observable(false);
    self.DomicileInitialPayment = ko.observable(false);
    self.IsDomiciliation = ko.observable(false);
    self.monthlyPayment = ko.observable();
    self.period = ko.observable();
    //self.amortizationTable = ko.observableArray([{ periodNumber: "", balance: "", date: "", interest: "", payment: "", principal: "", previousBalance: "" }]);
    self.amortizationTable = ko.observableArray([]);

    self.CreditCardTypes = ko.observableArray([]);
    //self.EconomicActivities = ko.observableArray([{ segment: '', name: '' }]);
    self.creditCardTypeId = ko.observable();
    self.creditCardNumber = ko.observable();
    self.creditCardNumberNoEdit = ko.observable();
    self.expirationDateYear = ko.observable();
    self.expirationDateMonth = ko.observableArray([]);
    self.cardHolder = ko.observable();
    //self.cardMask = ko.observable('****************');

    self.setFocus = function (orderId) {
        setTimeout(function () {
            if (orderId == 1)
                $('#focusFirstName').focus();
            if (orderId == 2)
                $('#focusBtnAddVehicle').focus();
        }, 3000);
    }

    self.totalPrime = ko.computed(function () {
        var total = 0;
        //_.each(self.vehicles(), function (vehicle) { total += vehicle.totalPrime(); });//ORIGINAL 13-07-2017
        _.each(self.vehicles(), function (vehicle) {

            var actualVehicleQty = vehicle.VehicleQuantity();
            var actualVehiculePrime = vehicle.totalPrime();

            var ToPrimeAddQtyVehi = (actualVehiculePrime * actualVehicleQty);

            total += ToPrimeAddQtyVehi;
        });
        //$('#QuotationTotalPremium').val(total);

        return total;
    }).money();

    self.totalDiscount = ko.computed(function () {
        var total = 0;

        _.each(self.vehicles(), function (vehicle) {

            var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";

            if (ve.indexOf("Motocicleta") == -1) {

                var actualVehicleQty = vehicle.VehicleQuantity();
                var actualVehiculeDiscount = vehicle.totalDiscount();

                var ToPrimeAddQtyVehi = (actualVehiculeDiscount * actualVehicleQty);

                total += ToPrimeAddQtyVehi;

                //total += vehicle.totalDiscount();//ORIGINAL 13-07-2017
            }
        });

        var rounded = roundToTwoDecimals(total);
        return rounded;
    }).money();

    self.getInfoDriverInvoiceTypeID = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().InvoiceTypeId()) {
            var it = self.infoAdDriver().InvoiceTypeId();

            if (it == 5) {
                return true;
            }
        }
        return false;
    });

    self.totalIsc = ko.computed(function () {
        var total = 0;

        var it = self.getInfoDriverInvoiceTypeID();

        if (it == false) {
            //_.each(self.vehicles(), function (vehicle) { total += vehicle.totalIsc(); });//ORIGINAL 13-07-2017
            _.each(self.vehicles(), function (vehicle) {

                var actualVehicleQty = vehicle.VehicleQuantity();
                var actualVehiculeIsc = vehicle.totalIsc();

                var ToPrimeAddQtyVehi = (actualVehiculeIsc * actualVehicleQty);

                total += ToPrimeAddQtyVehi;
            });
        }
        //var prime = parseFloat($('#QuotationTotalPremium').val());
        //prime += total;

        //$('#QuotationTotalPremium').val(prime);

        return total;
    }).money();

    self.GetMinAllowedAmountToPayPercent = ko.observable();

    self.NotifyMessagingAgent = ko.observable();
    self.QtyYearsBack0KmVip = ko.observable();
    self.allReadyPay = ko.observable(false);

    self.totalToPay = ko.computed(function () {
        var value = self.totalPrime() - self.totalDiscount() + self.totalIsc();
        //var minPercent = roundToTwoDecimals(value * 0.30);

        var percent = self.GetMinAllowedAmountToPayPercent();
        var minPercent = roundToTwoDecimals(value * percent);

        $("#minAllowedAmountToPay").data("percentallowed", percent);

        self.minAllowedAmountToPay(minPercent);
        var rounded = roundToTwoDecimals(value);
        return rounded;
    }).money();

    self.PercentByQtyVehicle = ko.observable();
    self.TotalByQtyVehicle = ko.computed(function () {

        if (self.PercentByQtyVehicle()) {

            var totalPrime = self.totalPrime();
            var PercentByQtyVehicle = self.PercentByQtyVehicle();

            var result = totalPrime * (PercentByQtyVehicle / 100);

            var rounded = roundToTwoDecimals(result);
            return rounded;
        }
    }).money();

    self.GetPercentToInsured = ko.computed(function () {
        var total = 0;
        _.each(self.vehicles(), function (vehicle) { total = vehicle.porcImpuesto(); return total; });
        return total;
    });

    self.effectiveDate = ko.observable();
    self.effectiveDateEnd = ko.observable();
    self.changeDate = ko.observable(false);
    self.changedDateBirth = ko.observable(false);
    self.changedDateBirthFirst = ko.observable(false);
    self.changedClientSexFirst = ko.observable(false);
    self.changedForeingLicenceFirst = ko.observable(false);


    self.effectiveDatesLessThanYear = ko.computed(function () {

        if (self.changeDate()) {
            var efdt = $('#effectivedate').val() !== undefined ? $('#effectivedate').val() : "";
            var efdf = $('#effectivedateend').val() !== undefined ? $('#effectivedateend').val() : "";

            if (efdt !== "" && efdf != "") {

                var makeDateT = getCorrectDateFormat(efdt);
                var makeDateF = getCorrectDateFormat(efdf);

                var dt = moment(makeDateT);
                var df = moment(makeDateF);

                var diff = df.diff(dt, 'years'); // 1

                //if (diff < 1) {                    
                self.currentStartDateSelected(moment(dt).format(getCurrentDateTimeMomentFormat()));
                self.currentEndDateSelected(moment(df).format(getCurrentDateTimeMomentFormat()));

                $("#effectiveDatesLeesThanYear").val('S');
                return;
                //}
            }
        }
        $("#effectiveDatesLeesThanYear").val('N');
    });


    self.listSencuenceVehiclesDeleted = ko.observableArray([]);

    self.newDriver = ko.observable();
    self.editingDriver = null;

    self.infoAdVehicle = ko.observable();
    self.vehicleBrandList = ko.observableArray();
    self.usageList = ko.observableArray();

    self.storeList = ko.observableArray();
    self.driversInfoAd = ko.observable();
    self.vehiclesInfoAd = ko.observable();

    self.payment = new paymentViewModel();


    self.showPayment = ko.observable(false);

    self.currentVehicleToPrimeApply = ko.observable();
    self.currentProductLimitSet = ko.observable();
    self.currentVehiclePrimesRetrieved = ko.observable(false);

    self.currentProductTypeSelected = ko.observable();
    self.currentProductUsageSelected = ko.observable();
    self.currentProductSelected = ko.observable();

    self.currentProductTypeList = ko.observableArray();
    self.currentProductUsageList = ko.observableArray();

    //Products
    self.currentProductUsageList = ko.computed(function () {
        var type = self.currentProductTypeSelected();
        if (type)
            return type.Products;
        else
            return [];
    });

    //Coverages
    self.currentProductList = ko.computed(function () {
        var type = self.currentProductUsageSelected();
        if (type)
            return type.Coverages;
        else
            return [];
    });

    self.currentVehicleName = ko.observable();
    self.currentVehiclePrice = ko.observable().money();
    self.percentageToInsureSelected = ko.observable();
    self.termTypeSelected = ko.observable(2);
    self.currentStartDateSelected = ko.observable();
    self.currentEndDateSelected = ko.observable();
    self.currentAdditionalCoverageSelected = ko.observableArray([]);
    self.selectedDeductible = ko.observable();
    self.currentVehicleAdditionalInfo = ko.observable();
    self.currentQuotationNumberSubscription = null;
    //#endregion


    self.ShowPepExplication = ko.observable();
    self.ShowBeneficiaryFinalExplication = ko.observable();
    self.ShowBeneficiaryFinalExplicationCompany = ko.observable();
    self.maxDatePolicyVigency = ko.observable();
    self.isFlotilla = ko.observable(false);
    self.ShowBeneficiaryFinalExplicationFootPage = ko.observable();

    self.ShowPepExplicationFootPage = ko.computed(function () {

        if (self.ShowPepExplication()) {

            return self.ShowPepExplication();
        }
        return "";
    });

    //SurCharge
    self.surchargePercentList = ko.observableArray();
    //#endregion

    self.getQuotationNumberForRates = ko.computed(function () {

        if (self.parent.quotation() && self.parent.quotation().id) {

            return self.parent.quotation().id;
        }
        else {
            var z = $('#loadQuotationId').val();

            return z;
        }
    });

    self.getQuotationNumber = ko.computed(function () {

        if (self.parent.quotation() && self.parent.quotation().quotationNumber) {

            return self.parent.quotation().quotationNumber;
        } else {
            var z = $('#loadQuotationNumber').val();

            return z;
        }
    });


    self.isAgentEmpty = ko.computed(function () {
        var qq = self.parent.agent();
        //El agente por default
        if (self.parent.agentList().length == 0 && (qq == null || qq == undefined)) {
            return true;
        }

        if (self.parent.agentList().length > 0 && qq != null && qq != undefined) {
            return true;
        }
        return false
    });
    self.FillIdentificationFinalBeneficiaryOptions = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() == "RNC") {
            $('#hdfIdentificationType').val('RNC');
            $('#QtyEmployees_RNC').css('display', 'block');
            $('#QtyPersonsDepend_CED').css('display', 'none');
            $('#URL_RNC').css('display', 'block');
            $('#chkHomeOwner_CED').css('display', 'none');
            $('#Fax_RNC').css('display', 'block');

            $.ajax({
                url: '/PoSAuto/GetIdentificationFinalBeneficiaryOptionsCompany',
                dataType: 'json',
                async: false,
                success: function (data) {
                    self.IdentificationFinalBeneficiaryOptionsList(data);
                }
            });

        } else if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != "RNC") {
            $('#hdfIdentificationType').val(self.infoAdDriver().identificationType());
            $('#QtyEmployees_RNC').css('display', 'none');
            $('#URL_RNC').css('display', 'none');
            $('#QtyPersonsDepend_CED').css('display', 'block');
            $('#chkHomeOwner_CED').css('display', 'block');
            $('#Fax_RNC').css('display', 'none');
            $.ajax({
                url: '/PoSAuto/GetIdentificationFinalBeneficiaryOptions',
                dataType: 'json',
                async: false,
                success: function (data) {
                    self.IdentificationFinalBeneficiaryOptionsList(data);
                }
            });
        }
    });

    self.BlockBeneficiaryFinalIfIsLaw = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.AllAreLawProducts() == true) {

            $("#IdentificationFinalBeneficiaryOptionsId").attr("disabled", "disabled");
            self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(null);
            self.FinalBeneficiary.removeAll();
            return true;
        }
        else if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {

            $("#IdentificationFinalBeneficiaryOptionsId").attr("disabled", "disabled");
            self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(null);
            self.FinalBeneficiary.removeAll();
            return true;
        }
        else {
            $("#IdentificationFinalBeneficiaryOptionsId").removeAttr("disabled");
        }
        return false;
    });

    self.showButtonDuplicate = ko.observable(false);

    self.showButtonDuplicateIfHasVehicle = ko.computed(function () {

        if (self.vehicles().length > 0) {
            self.showButtonDuplicate(true);
        }
        self.showButtonDuplicate(false);
    });

    self.openModalDuplicate = function () {
        if (self.vehicles().length > 0) {
            $(".vehicleDuplicate").show();
        }
    }

    self.saveDuplicates = function () {

        var obj = [];
        var hasError = false;

        var vehicleidList = $(".vehicleDesc").map(function () {

            var veid = $(this).data("veid");
            var qty = "";
            var q = $(this).closest('td').next().find('.qtyVeh');

            if (q != undefined && q != null) {
                qty = q.val();
            }

            var isNumber = parseInt(qty);

            if (!isNaN(isNumber)) {
                obj.push({ veid: veid, qty: qty });
            } else {
                hasError = true;
                return false;
            }
        }).get();


        if (hasError) {
            showError(["La Cantidad debe ser un valor numerico"], 'Duplicando Vehículos');
            return false;
        }

        var result = JSON.stringify(obj);

        var quotnumber = "";

        if (self.parent && self.parent.quotation() && self.parent.quotation().quotationNumber) {
            quotnumber = self.parent.quotation().quotationNumber;
        }

        $.getJSON("/Auto/PosAuto/duplicateVehicles", {
            quotnumber: quotnumber, jsondata: result
        }, function (data) {

            if (data.success) {

                location.reload();

                return true;
            }
            else {
                showError([data.message], 'Duplicando Vehículos');
                return false
            }
        });
    }

    self.newtotalIsc = ko.computed(function () {

        if (self.payment) {
            var it = self.getInfoDriverInvoiceTypeID();


            if (it == true) {
                return 0;
            }

            var t = $("#hdnIsAMotor").val();
            var PrimeNoMotors = 0;
            var PrimeYesMotors = 0;
            if (t === "true2") {
                PrimeNoMotors = self.totalPrimeNoMotors();
                PrimeYesMotors = self.totalPrimeYesMotors();
            }

            var total = 0;
            var substractTotal = 0;
            var PercentByQtyVehicle = self.PercentByQtyVehicle();

            var AlltotalDiscount = 0;

            if (self.totalDiscount() && self.totalDiscount() > 0) {
                AlltotalDiscount = self.totalDiscount();
            }

            if (self.TotalByQtyVehicle() && self.TotalByQtyVehicle() > 0) {
                AlltotalDiscount += self.TotalByQtyVehicle();
            }



            if (self.payment.applicant && self.payment.applicant.frequency() != 0 && PercentByQtyVehicle == 0) {
                var total = 0;

                _.each(self.vehicles(), function (vehicle) {; total += vehicle.totalIsc(); });

                var ro = roundToTwoDecimals(total);
                return ro;
            }
            else if (self.payment.applicant && self.payment.applicant.frequency() != 0 && PercentByQtyVehicle > 0) {

                var total = 0;

                /*Calculando el impuesto aplicando el descuento de flotilla*/
                var newTotal = self.totalPrime() - AlltotalDiscount;
                var percentInsurance = self.GetPercentToInsured();
                total = newTotal * (percentInsurance / 100);


                var ro = roundToTwoDecimals(total);
                return ro;
            }
            else if (self.payment.applicant && self.payment.applicant.frequency() == 0 && t === "true" && PercentByQtyVehicle == 0) {//son motores solamente

                var total = 0;

                _.each(self.vehicles(), function (vehicle) {; total += vehicle.totalIsc(); });

                var ro = roundToTwoDecimals(total);
                return ro;
            } else if (self.payment.applicant && self.payment.applicant.frequency() == 0 && t === "true" && PercentByQtyVehicle > 0) {//son motores solamente con desc. flotilla

                var total = 0;

                //_.each(self.vehicles(), function (vehicle) {; total += vehicle.totalIsc(); });

                //var ro = roundToTwoDecimals(total);

                /*Calculando el impuesto aplicando el descuento de flotilla*/
                var newTotal = self.totalPrime() - AlltotalDiscount;
                var percentInsurance = self.GetPercentToInsured();
                total = newTotal * (percentInsurance / 100);


                var ro = roundToTwoDecimals(total);

                return ro;

            } else if (self.payment.applicant && self.payment.applicant.frequency() == 0 && PercentByQtyVehicle > 0) {

                var total = 0;

                /*Calculando el impuesto aplicando el descuento de flotilla*/
                var newTotal = self.totalPrime() - AlltotalDiscount;
                var percentInsurance = self.GetPercentToInsured();
                total = newTotal * (percentInsurance / 100);


                var ro = roundToTwoDecimals(total);
                return ro;
            }
            else {

                total = (PrimeNoMotors == 0 ? self.totalPrime() : PrimeNoMotors) * (self.payment.currentDiscountPercentage() / 100);
                substractTotal = ((PrimeNoMotors == 0 ? self.totalPrime() : PrimeNoMotors) - total);

                if (PrimeYesMotors > 0) {
                    substractTotal = (substractTotal + PrimeYesMotors);
                }
            }

            var iscPercentage = parseFloat(self.payment.iscPercentage());

            var result = substractTotal * (iscPercentage / 100);

            if (isNaN(result)) {
                return 0;
            }

            var ro = roundToTwoDecimals(result);
            return ro;
        }
        else
            return 0;

    }).money();

    self.allAreMotors = ko.computed(function () {

        if (self.vehicles()) {

            var motors = 0;
            var Nomotors = 0;
            var r = false;
            _.each(self.vehicles(), function (vehicle) {

                var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";

                if (ve.indexOf("Motocicleta") != -1) {
                    motors++;
                } else {
                    Nomotors++;
                }
            });

            if (motors > 0 && Nomotors == 0) {
                r = true;
            } else {
                r = false;
            }
        }
        return r;
    });

    self.isDiscountEnable = ko.computed(function () {

        var dis = self.payment.currentDiscountPercentage();

        if (dis > 0) {
            self.payment.amountToPayEntered(self.newtotalToPay());
            return false;
        }

        if (self.payment.applicant && self.payment.applicant.frequency() != undefined && self.payment.applicant.frequency() == 0 && self.allAreMotors() == true) {

            self.payment.amountToPayEntered(self.newtotalToPay());
            return false;
        }

        self.payment.amountToPayEntered(0);
        return true;
    });

    self.GetSelectedVehicleType = ko.computed(function () {

        var r = false;
        $("#hdnIsAMotor").val("false");
        var qtyMotors = 0;
        var qtyOthers = 0;

        if (self.vehicles() && self.vehicles().length > 1) {

            _.each(self.vehicles(), function (vehicle) {

                var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";

                if (ve.indexOf("Motocicleta") != -1) {
                    r = false;
                    $("#hdnIsAMotor").val("true2");
                    qtyMotors++;
                } else {
                    qtyOthers++;
                }


                if (qtyOthers == 0) {
                    r = true;
                    $("#hdnIsAMotor").val("true");
                } else if (qtyMotors > 0) {
                    r = false;
                    $("#hdnIsAMotor").val("true2");
                }
            });

        }
        else {
            _.each(self.vehicles(), function (vehicle) {

                var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";

                if (ve.indexOf("Motocicleta") != -1) {
                    r = true;
                    $("#hdnIsAMotor").val("true");
                    return;
                }
            });
        }

        return r;
    });

    self.totalPrimeNoMotors = ko.computed(function () {
        var total = 0;
        _.each(self.vehicles(), function (vehicle) {
            var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";

            if (ve.indexOf("Motocicleta") == -1) {

                var actualVehicleQty = vehicle.VehicleQuantity();
                var actualVehiculePrime = vehicle.totalPrime();

                var ToPrimeAddQtyVehi = (actualVehiculePrime * actualVehicleQty);

                total += ToPrimeAddQtyVehi;

                //total += vehicle.totalPrime();//ORIGINAL 14-07-2017
            }
        });
        return total;
    }).money();

    self.totalPrimeYesMotors = ko.computed(function () {
        var total = 0;
        _.each(self.vehicles(), function (vehicle) {
            var ve = vehicle.selectedVehicleType() ? vehicle.selectedVehicleType().Name : "";


            if (ve.indexOf("Motocicleta") != -1) {

                var actualVehicleQty = vehicle.VehicleQuantity();
                var actualVehiculePrime = vehicle.totalPrime();

                var ToPrimeAddQtyVehi = (actualVehiculePrime * actualVehicleQty);

                total += ToPrimeAddQtyVehi;

                //total += vehicle.totalPrime();//ORIGINAL 14-07-2017
            }
        });
        return total;
    }).money();

    self.newtotalToPay = ko.computed(function () {

        //var value = self.totalPrime() - self.totalDiscount() + self.newtotalIsc();

        var t = $("#hdnIsAMotor").val();
        var PrimeNoMotors = 0;
        var PrimeYesMotors = 0;
        if (t === "true2") {
            PrimeNoMotors = self.totalPrimeNoMotors();
            PrimeYesMotors = self.totalPrimeYesMotors();
        }

        var value = 0;
        var PercentByQtyVehicle = self.PercentByQtyVehicle();

        if (PrimeNoMotors > 0 && PrimeYesMotors > 0 && PercentByQtyVehicle == 0) {
            var PrimeNoMotorsMinusDiscount = (PrimeNoMotors - self.totalDiscount());
            value = (PrimeNoMotorsMinusDiscount + PrimeYesMotors) + self.newtotalIsc();
        }

        else if (PercentByQtyVehicle > 0) {

            /*New TotalPrime*/
            var newTotal = self.totalPrime() - self.TotalByQtyVehicle();
            var percentInsurance = self.GetPercentToInsured();
            var Totaltaxes = newTotal * (percentInsurance / 100);


            value = newTotal - self.totalDiscount() + self.newtotalIsc();
        }
        else {
            value = self.totalPrime() - self.totalDiscount() + self.newtotalIsc();
        }

        //var minPercent = roundToTwoDecimals(value * 0.30);

        var percent = self.GetMinAllowedAmountToPayPercent();

        $("#minAllowedAmountToPay").data("percentallowed", percent);

        var minPercent = roundToTwoDecimals(value * percent);
        self.minAllowedAmountToPay(minPercent);
        var rounded = roundToTwoDecimals(value);

        return rounded;
    }).money();

    self.ValidDobCompany = ko.computed(function () {

        if (self.infoAdDriver() && !self.infoAdDriver().dateOfBirth() && self.infoAdDriver().identificationType() != 'RNC') {
            $("#dateOfBirthValidRNC").val("True");
            return true;
        }

        $("#dateOfBirthValidRNC").val("False");
        return false;
    });

    self.ischangeDateBirth = ko.computed(function () {
        /*
        if (self.infoAdDriver() && self.infoAdDriver().dateOfBirth()) {

            var dateOfBirthAdd = $("#dateOfBirthAdd").val();
            if (dateOfBirthAdd != undefined && dateOfBirthAdd != "") {
                self.changedDateBirth(true);
                return true;
            }
        }*/
        self.changedDateBirth(false);
        return false;
    });

    self.ischangeidentificationType = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() == 'RNC') {

            self.infoAdDriver().dateOfBirth('');
            $("#dateOfBirthAdd").attr('disabled', true);
            $("#dateOfBirthAdd").val('N/A');
        }
        else if (self.infoAdDriver() && self.infoAdDriver().identificationType() != 'RNC') {


            if ($("#dateOfBirthAdd").val() == "N/A") {
                self.infoAdDriver().license('');
                $("#license").val('');
                $("#dateOfBirthAdd").val('');
            }

            var empty = self.infoAdDriver().dateOfBirth();
            if (empty == "") {
                showError(["Como cambio el Tipo de Identificacion Debe Seleccionar la Fecha de Nacimiento Nuevamente"], "Fecha Nacimiento");
            }
        }
        /*else {
            $("#dateOfBirthAdd").removeAttr('disabled');
        }*/
    });

    self.totalPrimeWithDiscount = ko.computed(function () {

        var total = 0;
        var totalDiscount = 0;
        if (self.totalDiscount() && self.totalDiscount() > 0) {
            totalDiscount = self.totalDiscount();
        }

        if (self.TotalByQtyVehicle() && self.TotalByQtyVehicle() > 0) {
            totalDiscount += self.TotalByQtyVehicle();
        }

        total = (self.totalPrime() - totalDiscount);

        var rounded = roundToTwoDecimals(total);

        return rounded;
    }).money();


    self.cedMask = ko.observable(false);
    self.rncMask = ko.observable(false);
    self.whatMask = ko.observable('N');

    self.documetInvalid = ko.observable(false);

    self.setMaskRncCedu = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().identificationType()) {

            var value = self.infoAdDriver().identificationType();

            switch (value) {
                case "Cédula":
                case "Licencia":
                    self.cedMask(true);
                    self.rncMask(false);
                    break;
                case "RNC":
                    self.rncMask(true);
                    self.cedMask(false);
                    break;
                default:
                    self.rncMask(false);
                    self.cedMask(false);
                    break;
            }
        }
    });

    self.isValidDocument = ko.computed(function () {
        var currentStepId = self.parent.currentStepId();

        if (currentStepId == 4) {

            if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().license()) {

                var DocumentType = self.infoAdDriver().identificationType();
                var Number = self.infoAdDriver().license();
                var messageError = "";

                if (DocumentType == 'Cédula') {
                    DocumentType = 'Cedula';
                }
                else if (DocumentType == 'RNC') {
                    DocumentType = 'Rnc';
                }

                var noQuot = "";

                if (self.parent.quotation() && self.parent.quotation().quotationNumber) {
                    noQuot = self.parent.quotation().quotationNumber;
                }

                $.ajax({
                    url: '/PoSAuto/DocumentValidator',
                    data: { Number: Number, DocumentType: DocumentType, noQuot: noQuot },
                    dataType: 'json',
                    async: false,
                    success: function (data) {

                        if (data === true) {

                            $("#continueToVehicle").removeAttr("disabled");
                            $("#license").removeClass("errorBorder");
                            self.documetInvalid(false);
                            return true;
                        }
                        else {
                            messageError = "El Número de Identificación '" + Number + "' no es valido, por favor verifique.";
                            //$("#continueToVehicle").attr("disabled", "disabled");
                            $("#license").addClass("errorBorder");
                            self.documetInvalid(true);
                            showError([messageError], 'Validando Número de Identificación');
                        }
                    }
                });
            }
            return false;
        }
    });


    self.isfirstLoad = ko.observable(false);
    self.isfirstLoadBF = ko.observable(false);
    self.urlValidationCedulaRnc = ko.observable();
    self.urlValidationCedulaRncShow = ko.observable();
    self.EmailInvoiceErrorSysflex = ko.observable();

    self.PepOptionsList = ko.observableArray();
    self.SocialReasonList = ko.observableArray();
    self.OwnerShipStructureList = ko.observableArray();
    self.IdentificationFinalBeneficiaryOptionsList = ko.observableArray();

    self.showSelectOptionInvoiceType = ko.observable();

    self.openModalCedulaRnc = ko.computed(function () {

        var InvoiceTypeId = $("#InvoiceTypeId").val();
        var license = $("#license").val();

        //if (identificationType !== 'Pasaporte' && identificationType != undefined && license !== "" && license != undefined) {
        if (self.infoAdDriver() && self.infoAdDriver().InvoiceTypeId() && self.infoAdDriver().license() && self.parent) {

            license = self.infoAdDriver().license();
            InvoiceTypeId = self.infoAdDriver().InvoiceTypeId();
            var currentStepId = self.parent.currentStepId();

            if (InvoiceTypeId == '1' && currentStepId == 4) {

                var show = self.urlValidationCedulaRncShow();

                if (show == "SI") {
                    dialogRncCedula(license);
                }
            }
        }
    });

    self.getLastStep = ko.computed(function () {

        if (self.parent && self.parent.currentStepId()) {
            var sp = self.parent.currentStepId();
            if (sp == 2) {
                return false;
            } else { return true; }
        }

        return false;
    });

    self.Messaging = ko.observable();

    self.ShowOrNotMessaging = ko.computed(function () {

        if (!self.parent.agent() /*&& self.payment && self.payment.applicant.wayToPay() == 1*/) {
            return false;
        }

        return true;
    });

    self.minAllowedAmountToPayShow = ko.computed(function () {

        var value = 0;

        if (self.payment.applicant && self.payment.applicant.frequency() == 0) {
            value = self.newtotalToPay();
        } else {
            value = self.minAllowedAmountToPay();
        }

        var rounded = roundToTwoDecimals(value);

        return rounded;
    }).money();

    self.minAllowedAmountToPayShowPercent = ko.computed(function () {

        var percent = self.GetMinAllowedAmountToPayPercent();
        $("#minAllowedAmountToPay").data("percentallowed", percent);
        var percentToPay = (percent * 100);
        var value = "";

        if (self.payment.applicant && self.payment.applicant.frequency() == 0) {
            value = "100%";
        } else {
            value = percentToPay + "%";
        }

        return value;
    });

    self.allLawProducts = ko.computed(function () {
        var oneNotLaw = _.filter(self.vehicles(), function (v) { return !v.isLawProduct() });
        return oneNotLaw.length == 0;
    });

    self.AllAreLawProducts = ko.computed(function () {

        var p = self.allLawProducts();
        if (p == true) {
            //Todos son de ley
            $("#AllAreLawProducts").val("True");
            return true;
        }
        else {
            //al menos 1 no es de ley
            $("#AllAreLawProducts").val("False");
            return false;
        }
    });

    self.isRequiredEffectiveDate = ko.computed(function () {
        if (!self.effectiveDate()) {
            return true;
        }
        return false;
    });

    self.isRequiredEffectiveDateEnd = ko.computed(function () {
        if (!self.effectiveDateEnd()) {
            return true;
        }
        return false;
    });


    self.showOrNotEffectiveDate = ko.computed(function () {
        //var p = self.AllAreLawProducts();
        var a = self.parent.agentList();

        if (/*p &&*/ a.length > 0) {
            return true;
        }
        return false;
    });

    //#region [Lists]

    self.termTypes = ko.observableArray();

    self.percentageToInsure = ko.observableArray([]);

    self.currentProductDeductibles = ko.observableArray();

    self.vehicleAvailableYears = ko.observableArray();

    self.availablePassengersList = ko.observableArray(getSequentialList(1, 50, '+50'));

    //#endregion

    self.qtyVeiclesOther = ko.observable();

    //#region [Quotation methods]

    self.primeTextByTerm = ko.computed(function () {
        if (self.termTypeSelected()) {
            termType = _.find(self.termTypes(), function (t) { return t.id == self.termTypeSelected() });
            if (termType)
                return "Prima " + termType.timeSpanInLetters;
            else
                return "Prima";
        }
        else
            return "Prima";
    });

    self.endDateSubscription = null;

    self.setEndDateSubscriptionStatus = function (enabled) {

        if (self.endDateSubscription) {
            _.each(self.endDateSubscription, function (subs) {
                subs.dispose();
            });
            self.endDateSubscription = null;
        }

        if (enabled) {
            var startDateSub = self.currentStartDateSelected.subscribe(function () {
                self.updateEndDate();
            });
            //var termTypeSub = self.termTypeSelected.subscribe(function () {
            //    self.updateEndDate();
            //});
            self.endDateSubscription = [startDateSub]; //, termTypeSub];
        }
    };

    self.updateEndDate = function () {

        var startDate = moment(self.currentStartDateSelected(), getCurrentDateTimeMomentFormat());
        var endDate = moment(startDate).add(12, 'months').startOf('day');

        self.currentEndDateSelected(endDate.format(getCurrentDateTimeMomentFormat()));
    };

    self.oldAgentSelected = ko.observable();

    self.setOldAgentSelected = ko.computed(function () {
        if (self.parent && self.parent.agent()) {

            var agentActual = self.parent.agent();
            var oldAgent = self.oldAgentSelected();

            if (oldAgent == undefined) {
                self.oldAgentSelected(agentActual);
            }
        }
    });

    self.setOldAgentNew = function (agent) {
        if (agent != null) {
            self.oldAgentSelected(agent);
        }
    };

    self.getActualAgent = function () {
        if (self.parent && self.parent.agent()) {
            return self.parent.agent();
        }
    };

    self.getOldAgent = function () {

        if (self.oldAgentSelected()) {
            return self.oldAgentSelected();
        }
    };

    self.getNewAgentSelected = ko.computed(function () {

        if (self.parent && self.parent.agent()) {
            var agentActual = self.parent.agent();
            var oldAgent = self.oldAgentSelected();

            if (oldAgent.AgentCode != agentActual.AgentCode) {
                return agentActual;
            }
        }
        return null;
    });

    self.UpdateVehiclesByAgentChange = ko.computed(function () {
        //var wasRequoting = false;

        if (self.oldAgentSelected()) {

            var agentActual = self.getActualAgent();
            var oldAgent = self.getOldAgent();

            if (oldAgent.AgentCode != agentActual.AgentCode) {

                if (self.vehicles().length > 0) {

                    _.each(self.vehicles(), function (vehicle) {

                        vehicle.getPrimes();
                    });

                    //wasRequoting = true;                    
                }

                var NewAgent = agentActual;
                self.setOldAgentNew(NewAgent);
            }
        }

        //if (wasRequoting)
        //{
        //    self.saveQuotation(true);
        //}
    });

    function someDataClientWasChanged() {

        if (self.changedDateBirthFirst()) {
            return true;
        } else if (self.changedForeingLicenceFirst()) {
            return true;
        } else if (self.changedClientSexFirst()) {
            return true;
        } else { return false; }
    }

    function CallRequoting() {
        if (self.vehicles().length > 0) {

            _.each(self.vehicles(), function (vehicle) {
                vehicle.getPrimes();
            });

            self.changedDateBirthFirst(false);
            self.changedDateBirth(false);
            self.changedForeingLicenceFirst(false);
            self.changedClientSexFirst(false);
        }


    }

    function UpdateVehiclesByChangeDateBirthFirst() {

        var dateOfBirth = $("#NewdateOfBirth").val();
        if (dateOfBirth != undefined && dateOfBirth != "") {

            if (self.vehicles().length > 0) {

                _.each(self.vehicles(), function (vehicle) {
                    vehicle.getPrimes();
                });
            }
            self.changedDateBirthFirst(false);
            self.changedDateBirth(false);
        }
    }

    function UpdateVehiclesByChangeForeingLicenceFirst() {
        var ForeingLicence = $("#NewForeingLicence").val();

        if (ForeingLicence != undefined && ForeingLicence != "") {

            if (self.vehicles().length > 0) {
                _.each(self.vehicles(), function (vehicle) {

                    vehicle.getPrimes();
                });
            }
            self.changedForeingLicenceFirst(false);
        }
    };

    function UpdateVehiclesByChangeClientSexFirst() {
        var clientSex = $("#NewclientSex").val();
        if (clientSex != undefined && clientSex != "") {

            if (self.vehicles().length > 0) {
                _.each(self.vehicles(), function (vehicle) {
                    vehicle.getPrimes();
                });
            }
            self.changedClientSexFirst(false);
        }
    };

    //Original 28-10-2017 - Jheiron
    /*self.UpdateVehiclesByChangeDateBirthFirst = ko.computed(function () {

        if (self.changedDateBirthFirst()) {
            
            var dateOfBirth = $("#dateOfBirth").val();

            if (dateOfBirth != undefined && dateOfBirth != "") {

                if (self.vehicles().length > 0) {

                    _.each(self.vehicles(), function (vehicle) {
                        vehicle.getPrimes();
                    });
                }
                self.changedDateBirthFirst(false);
                self.changedDateBirth(false);
            }
        }
    });*/

    //Este metido no se usara porque en la segunda pantalla del cliente no se cambiara nada de esto 28-10-2017 - Jheiron
    /*self.UpdateVehiclesByChangeDateBirth = ko.computed(function () {
        if (self.parent && self.changedDateBirth()) {

            var dateOfBirthAdd = $("#dateOfBirthAdd").val();

            if (dateOfBirthAdd != undefined && dateOfBirthAdd != "") {

                if (self.vehicles().length > 0) {

                    _.each(self.vehicles(), function (vehicle) {
                        vehicle.getPrimes();
                    });
                }
                self.changedDateBirthFirst(false);
                self.changedDateBirth(false);
            }
        }
    });*/
    //Original 28-10-2017 - Jheiron
    /*self.UpdateVehiclesByChangeForeingLicenceFirst = ko.computed(function () {

        if (self.changedForeingLicenceFirst()) {
            var ForeingLicence = $("#ForeingLicence").val();

            if (ForeingLicence != undefined && ForeingLicence != "") {

                if (self.vehicles().length > 0) {
                    _.each(self.vehicles(), function (vehicle) {

                        vehicle.getPrimes();
                    });
                }
                self.changedForeingLicenceFirst(false);
            }
        }
    });

    self.UpdateVehiclesByChangeClientSexFirst = ko.computed(function () {
        if (self.changedClientSexFirst()) {
            var clientSex = $("#clientSex").val();
            if (clientSex != undefined && clientSex != "") {

                if (self.vehicles().length > 0) {
                    _.each(self.vehicles(), function (vehicle) {
                        vehicle.getPrimes();
                    });
                }
                self.changedClientSexFirst(false);
            }
        }
    });*/

    self.UpdateVehiclesByChangeEffectiveDatesLessThanYear = ko.computed(function () {
        if (self.changeDate()) {
            var effectiveDatesLeesThanYearEffectiveDateEnd = $("#effectiveDatesLeesThanYear").val();

            if (effectiveDatesLeesThanYearEffectiveDateEnd == "S") {

                if (self.vehicles().length > 0) {
                    _.each(self.vehicles(), function (vehicle) {

                        vehicle.getPrimes();
                    });
                }
                self.changeDate(false);
                $("#effectiveDatesLeesThanYear").val('N');
            }


            self.saveQuotation(true);
        }
    });
    //applicantWayToPay
    self.loadQuotation = function (quotationId, getAllInfo) {
        $.getJSON("/PosAuto/GetFullQuotation", { quotationId: quotationId }, function (data) {
            self.isfirstLoad(true);
            self.isfirstLoadBF(true);

            self.reset();

            self.quotationCoreNumber(data.QuotationCoreNumber);

            $("#QuotationCoreNumber").val(data.QuotationCoreNumber);

            //valido si es full
            if (!data.SendInspectionOnly) {
                $('#IsFinanced').attr('disabled', 'disabled');
            } else {
                $('#IsFinanced').removeAttr('disabled');
            }

            //Julisy Amador
            self.IsFinanced(data.Financed);
            self.DomicileInitialPayment(data.DomicileInitialPayment);

            if (data.Financed) { // domiciliacion obligatoria en caso de financiamiento
                self.IsDomiciliation(true);
                $('#IsDomiciliation').attr('disabled', 'disabled');
            } else {
                self.IsDomiciliation(true);
                $('#IsDomiciliation').removeAttr('disabled');
            }

            self.creditCardTypeId(data.Credit_Card_Type_Id);
            if (data.Expiration_Date_Year != null) {
                self.expirationDateYear(data.Expiration_Date_Year);
            } else {
                self.expirationDateYear();
            }

            if (data.Credit_Card_Number_Key != null && data.Credit_Card_Number_Key != '') {
                $('#creditCardNumber').inputmask('remove');
                self.creditCardNumber(data.Credit_Card_Number_Key);
                $('#creditCardNumber').attr('disabled', 'disabled');
                $('#editCreditCard').css('display', 'block');
            } else {
                self.creditCardNumber('');
                $('#creditCardNumber').attr('disabled', 'disabled');
                //$('#creditCardNumber').removeAttr('disabled');
                $('#editCreditCard').css('display', 'none');
            }

            if (data.Expiration_Date_Month != null) {
                self.expirationDateMonth(data.Expiration_Date_Month);
            } else {
                self.expirationDateMonth();
            }

            if (data.Card_Holder != null) {
                self.cardHolder(data.Card_Holder);
            } else {
                self.cardHolder();
            }

            if (self.IsFinanced()) {
                self.monthlyPayment(data.MonthlyPayment);
                self.period(data.Period);
            }
            //Julisy Amador

            self.setEndDateSubscriptionStatus(false);
            self.termTypeSelected(data.TermType ? data.TermType.Id : null);

            var actualDate = moment(new Date());
            var selectedDat = moment(data.StartDate);

            var result = getNewDateYear(actualDate);

            var isbefore = moment(actualDate).isBefore(selectedDat);
            var isSameYear = moment(actualDate).isSame(selectedDat, "year");
            var isSameMonth = moment(actualDate).isSame(selectedDat, "month");
            var isSameDay = moment(actualDate).isSame(selectedDat, "day");


            if (isbefore) {
                self.currentStartDateSelected(moment(data.StartDate ? data.StartDate : new Date()).format(getCurrentDateTimeMomentFormat()));
                self.currentEndDateSelected(moment(data.EndDate ? data.EndDate : result).format(getCurrentDateTimeMomentFormat()));
            }
            else if (isSameDay && isSameMonth && isSameYear) {
                self.currentStartDateSelected(moment(data.StartDate ? data.StartDate : new Date()).format(getCurrentDateTimeMomentFormat()));
                self.currentEndDateSelected(moment(data.EndDate ? data.EndDate : result).format(getCurrentDateTimeMomentFormat()));
            } else {
                self.currentStartDateSelected(moment(new Date()).format(getCurrentDateTimeMomentFormat()));
                self.currentEndDateSelected(moment(result).format(getCurrentDateTimeMomentFormat()));
            }

            //self.currentStartDateSelected(moment(data.StartDate ? data.StartDate : new Date()).format(getCurrentDateTimeMomentFormat()));
            //self.currentEndDateSelected(moment(data.EndDate ? data.EndDate : new Date()).format(getCurrentDateTimeMomentFormat()));

            self.payment.applicant.frequency(data.PaymentFrequencyId);
            self.payment.applicant.wayToPay(data.PaymentWay);

            self.payment.ach.achAccountHolderGovernmentId(data.AchAccountHolderGovId);
            self.payment.ach.achBankRoutingNumber(data.AchBankRoutingNumber);
            self.payment.ach.name(data.AchName);

            if (data.AchNumber && data.AchNumber.length > 0) {
                self.payment.ach.dummyNumber(data.AchNumber);
                self.payment.ach.dummyNumberVisible(true);
            }
            else
                self.payment.ach.dummyNumberVisible(false);

            self.payment.ach.type(data.AchType);
            self.payment.amountToPayEntered(data.AmountToPayEnteredByUser);

            self.newDriver.principal(data.Drivers.length == 0);
            _.each(data.Drivers, function (driver) {
                var newDriver = new driverViewModel();
                newDriver.loadModel(driver);
                self.drivers.push(newDriver);
            });

            //Cargando Beneficiarios del Conductor
            _.each(data.IdentificationFinalBeneficiarys, function (beneficiary) {
                var newBeneficiary = new finalBeneficiaryViewModel();
                newBeneficiary.loadModel(beneficiary); //setAsync false for check the complete steps
                self.FinalBeneficiary.push(newBeneficiary);
            });
            //

            //Cargando PEPS del Conductor
            _.each(data.PepFormularys, function (pep) {
                var newPep = new pepViewModel();
                newPep.loadModel(pep);
                self.PEP.push(newPep);
            });
            //

            self.PercentByQtyVehicle(data.FlotillaDiscountPercent);

            self.qtyVeiclesOther(data.VehicleProducts.length);

            var newVehicles = new Array();
            var ind = 0;
            _.each(data.VehicleProducts, function (vehicle) {
                var newVehicle = new vehicleViewModel(self);

                newVehicle.NotFirstLoading(false);

                newVehicle.loadModel(vehicle, false); //setAsync false for check the complete steps
                newVehicles.push(newVehicle);
            });
            self.vehicles(newVehicles);

            if (self.vehicles().length > 0) {
                self.showButtonDuplicate(true);
            }

            var q = self.parent.agent();

            if (self.parent.agentList().length === 1) { //Agente logueado
                self.parent.agent(self.parent.agentList()[0]);
            }
            else {//Suscriptor logueado. Selecciona agente
                //self.parent.agent(ko.utils.arrayFirst(self.parent.agentList(), function (item) { return item.nameid === data.User.Username }));
                self.parent.agent(ko.utils.arrayFirst(self.parent.agentList(), function (item) { return item.NameId === data.User.Username }));
            }

            self.setEndDateSubscriptionStatus(true);
            self.parent.updateStepsStatus();

            self.initSteps();

            self.parent.setSelectedStep(data.LastStepVisited);

            self.parent.quotation({ id: data.Id, quotationNumber: data.QuotationNumber, user: data.User.Username });

            self.Messaging(data.Messaging);


            if (isbefore) {
                if (data.StartDate != null) {
                    self.effectiveDate($.datepicker.formatDate(getCurrentDateFormat(), moment(data.StartDate).toDate()));
                } else {
                    self.effectiveDate('');
                }

                if (data.EndDate != null) {
                    self.effectiveDateEnd($.datepicker.formatDate(getCurrentDateFormat(), moment(data.EndDate).toDate()));
                } else {
                    self.effectiveDateEnd('');
                }
            }
            else if (isSameDay && isSameMonth && isSameYear) {

                if (data.StartDate != null) {
                    self.effectiveDate($.datepicker.formatDate(getCurrentDateFormat(), moment(data.StartDate).toDate()));
                } else {
                    self.effectiveDate('');
                }

                if (data.EndDate != null) {
                    self.effectiveDateEnd($.datepicker.formatDate(getCurrentDateFormat(), moment(data.EndDate).toDate()));
                } else {
                    self.effectiveDateEnd('');
                }

            }
            else {
                self.effectiveDate($.datepicker.formatDate(getCurrentDateFormat(), moment(new Date()).toDate()));

                self.effectiveDateEnd($.datepicker.formatDate(getCurrentDateFormat(), moment(result).toDate()));
            }


            var $this = $('#effectivedate');
            var makeDate = getCorrectDateFormat($this.val());

            var neDat = $.datepicker.formatDate(getCurrentDateFormat(), moment(makeDate).toDate());
            var neDatMax = getNewDateYear(makeDate);

            $('#effectivedateend').datepicker('option', 'minDate', neDat);
            $('#effectivedateend').datepicker('option', 'maxDate', neDatMax);//Un Ano a partir de la Fecha Seleccionada
        });
    }

    self.showBrochure = function () {
        $("#brochurePopup").show();
    }

    self.showOurProducts = function () {
        self.showBrochure();
    }

    self.saveQuotation = function (avoidSuccessMessage, onSuccessCallback, commingfromUnload) {

        if (commingfromUnload == true) {
            return true;
        }

        if (!self.parent.agent() || typeof self.parent.agent() !== 'object' || !self.parent.agent().NameId) {

            self.parent.agent(undefined);
        }

        var statusToSave = self.isQuotationValidForSaving();

        var PercentByQtyVehicle = self.PercentByQtyVehicle() > 0 ? self.PercentByQtyVehicle() : 0;
        var TotalByQtyVehicle = self.TotalByQtyVehicle() > 0 ? self.TotalByQtyVehicle() : 0;

        //ORIGINAL 22-07-2017
        //var l = self.AllAreLawProducts();

        //if (l) {
        //    if (self.effectiveDate()) {
        //        self.currentStartDateSelected(self.effectiveDate());
        //    }
        //}

        if (self.effectiveDate()) {
            self.currentStartDateSelected(self.effectiveDate());
        }

        if (self.effectiveDateEnd()) {
            self.currentEndDateSelected(self.effectiveDateEnd());
        }


        //
        if (statusToSave.isValid) {
            var quotationId = null;
            if (self.parent.quotation() && self.parent.quotation().id)
                quotationId = self.parent.quotation().id;

            var agent = self.parent.agent();

            var discountPercentage = 0;

            if (self.payment.applicant.frequency() == 0)
                discountPercentage = self.payment.currentDiscountPercentage();

            self.creditCardNumberNoEdit('');
            //$.post("/PosAuto/SaveQuotation", {
            $.post("/PosAuto/SaveQuotation_New", {
                quotationId: quotationId,
                drivers: ko.toJSON(self.drivers),
                vehicles: ko.toJSON(self.vehicles),
                payment: ko.toJSON(self.payment),
                startDate: self.currentStartDateSelected(),
                endDate: self.currentEndDateSelected(),
                termTypeId: 2, //Mantis 0013078: term type fixed to 1 year
                totalPrime: self.totalPrime(),
                totalIsc: self.totalIsc(),
                totalDiscount: self.totalDiscount(),
                discountPercentage: discountPercentage,
                allLawProducts: self.allLawProducts(),
                lastStepVisited: self.parent.currentStepId(),
                agent: agent,
                Messaging: self.Messaging(),
                PercentByQtyVehicle: PercentByQtyVehicle,
                TotalByQtyVehicle: TotalByQtyVehicle,
                driversFinalBeneficiary: ko.toJSON(self.FinalBeneficiary),
                driversPeps: ko.toJSON(self.PEP),
                IsFinanced: self.IsFinanced(),
                monthlyPayment: self.monthlyPayment(),
                period: self.period(),
                Credit_Card_Type_Id: self.creditCardTypeId(),
                Credit_Card_Number_Key: self.creditCardNumber(),
                Expiration_Date_Year: self.expirationDateYear(),
                Expiration_Date_Month: self.expirationDateMonth(),
                Card_Holder: self.cardHolder(),
                IsDomiciliation: self.IsDomiciliation(),
                DomicileInitialPayment: self.DomicileInitialPayment()
            },
                function (data) {

                    if (data.Credit_Card_Number != null && data.Credit_Card_Number != '') {
                        $('#creditCardNumber').inputmask('remove');
                        self.creditCardNumber(data.Credit_Card_Number);
                        $('#creditCardNumber').attr('disabled', 'disabled');
                        $('#editCreditCard').css('display', 'block');
                    } else {
                        $('#creditCardNumber').attr('disabled', 'disabled');
                        //$('#creditCardNumber').removeAttr('disabled');
                        $('#editCreditCard').css('display', 'none');
                    }

                    if (data.redirectNoLogin) {
                        window.location = data.redirectNoLogin;
                    }

                    _.each(data.updateDrivers, function (item) {
                        var driver = _.find(self.drivers(), function (d) { return d.tempId == item.tempId });
                        if (driver)
                            driver.id(item.id);
                    });

                    _.each(data.updateVehicles, function (item) {
                        var vehicle = _.find(self.vehicles(), function (d) { return d.tempId == item.tempId });
                        if (vehicle)
                            vehicle.id(item.id);
                    });

                    if (!self.parent.quotation()) {
                        self.parent.quotation({ id: data.quotationId, quotationNumber: data.quotationNumber });
                        //window.history.pushState({ order: 1 }, document.title, '/Auto/PosAuto/Index/' + data.quotationId);
                        window.history.pushState({ order: 1 }, document.title, '/Auto/PosAuto/Index/' + data.quotationIdEncript);
                    }

                    //var startDate = moment(data.newStartDate, getCurrentDateTimeMomentFormat()); //original
                    var startDate = moment(data.newStartDate);
                    var endDate = moment(data.newEndDate);

                    self.effectiveDate($.datepicker.formatDate(getCurrentDateFormat(), moment(startDate).toDate()));
                    self.effectiveDate();

                    self.effectiveDateEnd($.datepicker.formatDate(getCurrentDateFormat(), moment(endDate).toDate()));
                    self.effectiveDateEnd();

                    self.quotationCoreNumber(data.QuotationCoreNumber);

                    $("#QuotationCoreNumber").val(data.QuotationCoreNumber);

                    if (onSuccessCallback) {
                        onSuccessCallback();
                    }

                    if (!avoidSuccessMessage) {
                        showSuccess("Cotización", "La cotización se ha guardado correctamente.")
                    }

                    self.isfirstLoad(true);
                    self.isfirstLoadBF(true);

                });

            return true;
        }
        else {

            if (statusToSave.isAgentEmppty) {
                showError(statusToSave.errorMessages, 'Guardar Cotización');
                return false;
            }

            else if (!avoidSuccessMessage) {
                showError(statusToSave.errorMessages, 'Guardar Cotización');
            }

            else if (statusToSave.pepOrBf) {
                showError(statusToSave.errorMessages, 'Guardar Cotización');
                return false;
            }

            return false;
        }
    }

    self.finalizeQuotation = function (saveQuotation) {
        var quotationId = null;

        if (self.parent.quotation() && self.parent.quotation().id) {
            quotationId = self.parent.quotation().id;
            self.saveQuotation(true);
            $.post("/PosAuto/FinalizeQuotation", {
                quotationId: quotationId
            },
                function () {
                    showSuccess("Cotización", "La cotización se ha dado por finalizada correctamente.");
                });
        }
    };

    self.isQuotationValidForSaving = function () {
        var errorMessages = [];
        isAgentEmppty = false;
        var pepOrBf = false;

        if (self.parent.agentList().length > 0 && !self.parent.agent()) {
            errorMessages.push('Debe seleccionar el Agente para la cotización.');
            isAgentEmppty = true;
        }

        //Step 1: check step complete is enough
        var step1Complete = self.getStepStatus(1) == stepStatuses.COMPLETED;
        if (!step1Complete) {
            errorMessages.push('La sección "Agregar Conductores" contiene errores. Debe seleccionar al menos un conductor principal para poder continuar.');
        }

        //Step2: if at least one vehicle loaded, all the vehicles MUST be completed
        if (self.vehicles().length > 0) {
            var incomplete = _.filter(self.vehicles(), function (item) { return !item.vehicleDataComplete() });
            if (incomplete.length != 0) {
                errorMessages.push('La sección "Agregar Vehículos" contiene errores. Debe corregir dichos errores para poder continuar.');
            }
        }

        if (!self.payment.isValidForSaving()) {
            errorMessages.push('La sección "Pagos" contiene errores. Asegúrese que los campos Nombre del Solicitante y Número de Identificación Solicitante son alfabéticos y no sobrepasan los 50 caracteres de longitud.');
        }

        var currentStepId = self.parent.currentStepId();
        if (currentStepId == 4) {
            var result = ValidPepOrBF();
            var sp = result.split('|');

            if (sp.length > 0) {
                var valid = sp[0];//Valid
                var msj = sp[1];//msj
                if (valid == "false" && msj != "") {
                    pepOrBf = true;
                    errorMessages.push(msj);
                }
            }
        }

        var isValid = errorMessages.length == 0;
        return { isValid: isValid, errorMessages: errorMessages, isAgentEmppty: isAgentEmppty, pepOrBf: pepOrBf };
    }


    //#endregion

    //#region [Step-related methods]

    self.reset = function () {
        self.newDriver.clear();
        self.vehicles.removeAll();
        self.drivers([]);
        self.termTypeSelected(2);
        self.currentStartDateSelected(moment(new Date()).format(getCurrentDateTimeMomentFormat()));
        self.updateEndDate();
        self.payment.clear();
        self.amountToPayEntered(null);
        self.Messaging(true);
        self.FinalBeneficiary.removeAll();
        self.PEP.removeAll();

        self.listSencuenceVehiclesDeleted.removeAll();
    }

    self.firstStepAdvance = function () {

        var a = self.isAgentEmpty();
        var clientDataChanged = someDataClientWasChanged();
        if (a == true) {

            if (clientDataChanged == true) {
                //Recotizame
                //UpdateVehiclesByChangeDateBirthFirst();
                CallRequoting();
            }

            self.parent.nextStep();
            self.parent.disableEditVehicle(false);

        } else {
            showError(['Debe seleccionar el Agente para la cotización.'], 'Guardar Cotización');
            return false;
        }
    }

    self.fourthStepAdvance = function () {
        var pass = true;

        //Valido que si el cliente quiere domiciliar, que indiquen los datos de la tarjeta
        var domiciled = self.IsDomiciliation();
        if (domiciled != null && domiciled == true) {
            if (!self.creditCardTypeId() || self.creditCardTypeId() <= 0) {
                showError(["Si desea domiciliar el pago, debe seleccionar el tipo de tarjeta en la domiciliación"], 'Guardar Cotizacion');
                return false;
            }
            if (!self.creditCardNumber() || self.creditCardNumber() == '') {
                showError(["Si desea domiciliar el pago, debe indicar el número de tarjeta en la domiciliación"], 'Guardar Cotizacion');
                return false;
            }

            if (!self.expirationDateYear() || self.expirationDateYear() <= 0) {
                showError(["Si desea domiciliar el pago, debe indicar el año de vencimiento de la tarjeta en la domiciliación"], 'Guardar Cotizacion');
                return false;
            }

            if (!self.expirationDateMonth() || self.expirationDateMonth() <= 0) {
                showError(["Si desea domiciliar el pago, debe indicar el mes de vencimiento de la tarjeta en la domiciliación"], 'Guardar Cotizacion');
                return false;
            }

            if (!self.cardHolder() || self.cardHolder() == '') {
                showError(["Si desea domiciliar el pago, debe indicar el Tarjetahabiente en la domiciliación"], 'Guardar Cotizacion');
                return false;
            }
        }
        //var $AnnualIncome = $('#AnnualIncome');
        //var anuualIncomes = $AnnualIncome.val().replace("$", "").replace(",", "");
        //var quoTotalPremium = parseFloat($('#QuotationTotalPremium').val()) // prima con impuesto de la cotizacion
        //var totalPremiumValidation = parseFloat($('#ParameterTotalPremium').val()); // monto parametro de validacion
        //if (quoTotalPremium > totalPremiumValidation) { //valido si la prima supera el monto definido en el parametro para validar la informacion laboral
        //    if (anuualIncomes <= 0) {
        //        $AnnualIncome.addClass('errorBorder');
        //        showError(["El Ingreso Anual es requerido."], 'Guardar Cotizacion');
        //        return false;
        //    }
        //} else {
        //    if ($('#OwnershipStructureId').val() == 4 || self.AllAreLawProducts() == false) { // Validando si es persona fisca para obligar al usuario a que coloque el ingreso anual
        //        if (anuualIncomes <= 0) {
        //            $AnnualIncome.addClass('errorBorder');
        //            showError(["El Ingreso Anual es requerido."], 'Guardar Cotizacion');
        //            return false;
        //        }
        //    }
        //}

        var currentStepId = self.parent.currentStepId();
        if (currentStepId == 4) {
            var result = ValidPepOrBF();
            var sp = result.split('|');

            if (sp.length > 0) {
                var valid = sp[0];//Valid
                var msj = sp[1];//msj
                if (valid == "false" && msj != "") {
                    pass = false;
                    showError([msj], 'Guardar Cotizacion');
                }
            }
        }

        if (pass) {
            pass = isValidTheDocument();
        }


        if (pass) {

            if ($("#dateOfBirthAdd").val() == '' && self.infoAdDriver().dateOfBirth() == '') {
                showError(["Como cambio el Tipo de Identificacion Debe Seleccionar la Fecha de Nacimiento Nuevamente"], "Fecha Nacimiento");
                pass = false;
            }
        }

        if (self.setAditionalDriverInfoMethod(null) && pass) {

            self.isfirstLoad(false);
            self.isfirstLoadBF(false);

            $(".PepPOP").hide();
            $(".IdentificationFinalBeneficiaryPOP").hide();

            self.parent.nextStep();
        }
    }

    self.fifthStepAdvance = function () {

        if (self.saveAditionalVehicleInfo(null, true))
            self.goToPay();

    }

    self.buyAfterQuickSteps = function (showReport) {

        var financed = self.IsFinanced();
        if (financed != null && financed == true) {
            var period = self.period();
            if (period == null || period <= 0) {
                showError(["Debe seleccionar la cantidad de meses del financiamiento"], "Financiamiento Cotización");
                return false;
            }
        }
        self.parent.nextStep();
    }

    self.buyAfterQuickStepsFromSidebar = function (showReport) {

        self.parent.saveQuotation();
        self.parent.setSelectedStep(4, false);
    }

    self.goToPay = function () {

        if (!self.allLawProducts()) {
            self.saveQuotation(true, function () {
                var quotationId = null;
                if (self.parent.quotation() && self.parent.quotation().id)
                    quotationId = self.parent.quotation().id;
                var discountPercentage = 0;
                $.getJSON("/Auto/PosAuto/SendQuotationToCoreAndFinalize", {
                    quotationId: quotationId
                }, function (data) {
                    if (data.success) {
                        //showSuccess('Enviar inspección', data.message);   
                        var userConected = $("#userConected").val();


                        if (userConected == "S") {
                            showSuccess('Enviar inspección', data.message, null, null, null, true);
                        } else if (userConected == "N") {
                            showSuccess('Enviar inspección', data.message);
                        } else {
                            showSuccess('Enviar inspección', data.message);
                        }
                        //showSuccess('Enviar inspección', data.message, null, null, null, true);
                        self.parent.nextStep();
                    }
                    else {
                        showError([data.message], 'Enviar inspección');
                    }
                });
            });
        }
        else {
            var fail = true;
            self.saveQuotation(true, function () {
                var quotationId = null;
                if (self.parent.quotation() && self.parent.quotation().id) {
                    quotationId = self.parent.quotation().id;
                }
                $.ajax({
                    url: "/Auto/PosAuto/CheckChassisPlateLawProducts",
                    dataType: 'json',
                    async: true,
                    data: { quotationId: quotationId },
                    success: function (data) {
                        if (data.success) {
                            fail = false;
                            self.parent.nextStep();
                        }
                        else {
                            fail = false;
                            showError([data.message], 'Chasis o Placa Repetido');
                        }
                    }
                });
            });
            /**/
        }
    }

    self.getStepStatus = function (stepId) {

        if (stepId == 1) {
            if (self.drivers().length == 0)
                return stepStatuses.PENDING;
            else
                return stepStatuses.COMPLETED;
        }
        else if ((stepId == 2) || (stepId == 3)) {
            if (self.vehicles().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.vehicles(), function (item) { return !item.vehicleDataComplete(); });
                if (notCompleted.length == 0)
                    return stepStatuses.COMPLETED;
                else
                    return stepStatuses.PENDING;
            }
        }
        else if (stepId == 4) {
            if (self.drivers().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.drivers(), function (item) { return !item.driverAditionalDataComplete(); });
                if (notCompleted.length == 0) {
                    return stepStatuses.COMPLETED;
                }
                else {
                    return notCompleted.length == self.drivers().length ? stepStatuses.PENDING : stepStatuses.INPROGRESS;
                }
            }
        }
        else if (stepId == 5) {
            if (self.vehicles().length == 0)
                return stepStatuses.PENDING;
            else {
                var notCompleted = _.filter(self.vehicles(), function (item) { return !item.vehicleAditionalDataComplete(); });
                if (notCompleted.length == 0)
                    return stepStatuses.COMPLETED;
                else
                    return notCompleted.length == self.vehicles().length ? stepStatuses.PENDING : stepStatuses.INPROGRESS;
            }
        }
        else
            return stepStatuses.PENDING;
    }

    self.updateStepData = function (stepId) {
        if (stepId == 2) {
            if (self.vehicles().length == 0)
                self.addVehicle();
        }
        if (stepId == 3) {
            if (self.vehicles().length > 0)
                self.currentVehicleToPrimeApply(self.vehicles()[0]);
        }
        if (stepId == 4) {
            if (self.drivers().length > 0)
                self.loadDriversInfoAd(self.drivers()[0]);
        }
        if (stepId == 5) {
            if (self.vehicles().length > 0) {
                self.loadInfoAdVehicle(self.vehicles()[0]);
            }
        }
        if (stepId == 6) {
            if (userType === 'Assistant' || userType === 'Agent') {
                //if(!self.IsDomiciliation())
                $("#skipPaymentBtn").show();
            }
        }
    }

    self.quickStepsComplete = ko.computed(function () {
        var result = self.getStepStatus(1) == stepStatuses.COMPLETED
            && self.getStepStatus(2) == stepStatuses.COMPLETED
            && self.getStepStatus(3) == stepStatuses.COMPLETED;
        return result;
    }, this);

    self.qtyVehiclesCreated = ko.computed(function () {

        var totalVehicleQty = 0;

        _.each(self.vehicles(), function (vehicle) {
            var actualVehicleQty = vehicle.VehicleQuantity();

            totalVehicleQty += actualVehicleQty;
        });

        return totalVehicleQty;

        /*Orginal 13-07-2017*/
        /*var v = self.vehicles();
        if (v.length == 0 && self.qtyVeiclesOther()) {
            var a = self.qtyVeiclesOther();
            return a;
        }
        return v.length;*/
    });

    self.isRequoting = ko.observable(false);

    //#endregion


    //#region Ownership Structure
    self.OwnershipStructureSelectedText = ko.observable('');

    self.isAFisicPerson = ko.computed(function () {
        var anuualIncomes = parseFloat($("#AnnualIncome").val());
        var job = $('#job').val();
        var Company = $('#company').val();

        if (self.infoAdDriver() && self.infoAdDriver().OwnershipStructureId()) {
            var text = $("#OwnershipStructureId option:selected").text();
            var value = $("#OwnershipStructureId option:selected").val();
            if (value == 4) { //validando si es persona fisica
                /*
                self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(null);
                $("#IdentificationFinalBeneficiaryOptionsId").attr("disabled", "disabled");
                self.FinalBeneficiary.removeAll();
                */
                self.OwnershipStructureSelectedText(text);
                $("#AnnualIncome").removeAttr("disabled");

                if (anuualIncomes <= 0) {
                    $('#AnnualIncome').addClass('errorBorder');
                } else {
                    $('#AnnualIncome').removeClass('errorBorder');
                }

                if (Company == null || Company == '') {
                    $('#company').addClass('errorBorder');
                } else {
                    $('#company').removeClass('errorBorder');
                }

                if (job == null || job == '') {
                    $('#job').addClass('errorBorder');
                } else {
                    $('#job').removeClass('errorBorder');
                }

            } else if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {
                $("#AnnualIncome").removeAttr("disabled");
                self.infoAdDriver().OwnershipStructureId(null);
                self.OwnershipStructureSelectedText('');
            }
            else {
                //$("#IdentificationFinalBeneficiaryOptionsId").removeAttr("disabled");                
                $("#AnnualIncome").attr("disabled", "disabled");
                $("#AnnualIncome").val("0");
                self.OwnershipStructureSelectedText('');
            }
        }
        else if (self.infoAdDriver()) {
            $("#AnnualIncome").removeAttr("disabled");
            self.infoAdDriver().OwnershipStructureId(null);
            self.OwnershipStructureSelectedText('');
        }
    });
    //#endregion


    //#region PEP
    self.loadPepDriver = function (pep) {

        if (pep != undefined) {
            self.infoAdPep().id(pep.id());
            self.infoAdPep().driverID(pep.driverID());
            self.infoAdPep().fullNamePep(pep.fullNamePep());
            self.infoAdPep().RelationshipIdPep(pep.RelationshipIdPep());
            self.infoAdPep().PositionPep(pep.PositionPep());
            self.infoAdPep().fromYear(pep.fromYear());
            self.infoAdPep().toYear(pep.toYear());
        }
        else {
            self.infoAdPep(new new pepViewModel());
        }
    };

    function prepareNewPep(passName) {

        var newPep = new pepViewModel();
        var driver = _.find(self.drivers(), function (d) { return d.id() == self.infoAdDriver().id(); });
        if (driver != null) {
            newPep.driverID(driver.id());
            if (passName) {
                var clientName = self.infoAdDriver().firstName() + " " + self.infoAdDriver().surname();
                newPep.fullNamePep(clientName);

            }
        }
        self.PEP.push(newPep);


        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {

            $("#PepFormularyOptionsId").removeAttr("disabled");
            var currentStepId = self.parent.currentStepId();

            if (self.PepOptionsList() && self.infoAdDriver().PepFormularyOptionsId()) {
                var idfibeOption = _.find(self.PepOptionsList(), function (item) { return item.id == self.infoAdDriver().PepFormularyOptionsId(); });
                if (idfibeOption.allowed == true) {
                    if (currentStepId == 4) {
                        /*para saber si el campo de parentezco es requerido o no*/
                        if (idfibeOption.name.indexOf("Designado") != -1) {
                            $(".RelationshipIdPep").attr("disabled", "disabled");
                            $('.RelationshipIdPep').removeClass("errorBorder");
                            self.infoAdPep().RelationshipIdPep(null);
                        } else {
                            $(".RelationshipIdPep").removeAttr("disabled");
                        }
                    }
                }
            }
        }

    }

    self.addNewPep = function () {
        prepareNewPep();
        $(".tbl.agregar_vh tbody tr:last td:first select").focus();
    };

    self.SetPep = function (formElement) {

        /*Pep*/
        if ($('#PepForm').valid()) {

            var incompletes = _.filter(self.PEP(), function (item) { return !item.pepDataComplete(); });
            if (incompletes.length > 0) {
                showError(['Debe completar los datos de los PEP indicados en rojo.'], 'Guardar PEP');
            } else if (self.PEP().length <= 0) {
                showError(['Debe agregar un PEP, sino presione el boton Cancelar.'], 'Guardar PEP');
            }
            else {
                $('#PepPopup').hide();
            }
        }
        return false;
        /**/
    };

    self.ShowButtonPep = function () {
        if (self.PEP().length > 0) {
            return true;
        }
        return false;
    };

    self.OpenModalButtonPep = function () {

        if (self.PEP().length > 0) {
            $('#PepPopup').show();
            return true;
        }
        $('#PepPopup').hide();
        return false;
    };

    self.CancelSetPep = function () {

        if (self.PEP().length > 0) {

            var pep = _.find(self.PEP(), function (d) { return d.driverID() == self.infoAdDriver().id() && d.id() == self.infoAdPep().id(); });

            if (pep != undefined) {
                self.PEP.remove(pep);
            }

        } else {
            self.PEP.removeAll();
        }

        $('#PepPopup').hide();
    };

    self.removePep = function (PepToRemove) {

        self.PEP.remove(PepToRemove);
    };

    self.showOrNotIPepForm = ko.computed(function () {
        var currentStepId = self.parent.currentStepId();
        var passName = false;

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {

            $("#PepFormularyOptionsId").removeAttr("disabled");

            if (self.PepOptionsList() && self.infoAdDriver().PepFormularyOptionsId()) {
                var idfibeOption = _.find(self.PepOptionsList(), function (item) { return item.id == self.infoAdDriver().PepFormularyOptionsId(); });
                if (idfibeOption.allowed == true) {

                    if (currentStepId == 4) {

                        /*para saber si el campo de parentezco es requerido o no*/
                        if (idfibeOption.name.indexOf("Designado") != -1) {
                            $(".RelationshipIdPep").attr("disabled", "disabled");
                            $('.RelationshipIdPep').removeClass("errorBorder");
                            self.infoAdPep().RelationshipIdPep(null);

                            passName = true;

                        } else {
                            $(".RelationshipIdPep").removeAttr("disabled");
                            passName = false;
                        }


                        //Mostrar el Formulario PEP  
                        if (self.isfirstLoad()) {
                            self.isfirstLoad(false);
                        }

                        if (self.isfirstLoad() == false && self.PEP().length <= 0) {
                            $(".PepPOP").show();
                        }

                        if (self.PEP().length <= 0) {
                            prepareNewPep(passName);
                        }
                        return true;
                    }
                }
            }
        }
        //Esconder el Formulario PEP      
        //LIMPIAR EL MODELO   
        if (currentStepId == 4) {

            if (self.PEP().length > 0) {

                var pep = _.find(self.PEP(), function (d) { return d.driverID() == self.infoAdDriver().id() && d.id() == self.infoAdPep().id(); });

                if (pep != undefined) {
                    self.PEP.remove(pep);
                }

            } else {
                self.PEP.removeAll();
            }
            $(".PepPOP").hide();
            $('#PepPopup').hide();
        }
        return false;
    });

    self.PEP.subscribe(function (changes) {

        _.each(changes, function (change) {
            if (change.status == 'added') {
                if (self.PEP().length > 0) {
                    self.loadPepDriver(self.PEP()[0]);
                }
            }
        });
    }, null, "arrayChange");

    self.ListPepByDriver = ko.computed(function () {

        var listPep = ko.utils.arrayFilter(self.PEP(), function (d) { return d.driverID() == self.infoAdDriver().id(); });
        return listPep;
    });

    self.DisablePepIfRNC = ko.computed(function () {

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() == 'RNC') {

            $("#PepFormularyOptionsId").attr("disabled", "disabled");

            self.infoAdDriver().PepFormularyOptionsId(null);
            $(".PepPOP").hide();
            $('#PepPopup').hide();
        }
    });

    //#endregion



    //#region Beneficiary

    self.loadFinalBeneficiaryDriver = function (beneficiary) {

        if (beneficiary != undefined) {

            self.infoAdBeneficiaryFinal().id(beneficiary.id());
            self.infoAdBeneficiaryFinal().fullNameBeneficiary(beneficiary.fullNameBeneficiary());
            self.infoAdBeneficiaryFinal().percentageBeneficiary(beneficiary.percentageBeneficiary());
            self.infoAdBeneficiaryFinal().driverID(beneficiary.driverID());
        }
        else {
            self.infoAdBeneficiaryFinal(new finalBeneficiaryViewModel());
        }
    };

    function prepareNewBeneficiaryFinal() {

        var newBeneficiary = new finalBeneficiaryViewModel();
        var driver = _.find(self.drivers(), function (d) { return d.id() == self.infoAdDriver().id(); });
        if (driver != null) {
            newBeneficiary.driverID(driver.id());
        }
        self.FinalBeneficiary.push(newBeneficiary);

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {
            var currentStepId = self.parent.currentStepId();

            if (currentStepId == 4) {
                $(".percentageBeneficiary").attr("disabled", "disabled");
                $('.percentageBeneficiary').removeClass("errorBorder");
            }
        }
    }

    self.addNewBeneficiaryFinal = function () {
        prepareNewBeneficiaryFinal();
        $(".tbl.agregar_vh tbody tr:last td:first select").focus();
    };

    self.SetBeneficiaryFinal = function (formElement) {
        /*Beneficiario Final*/
        if ($('#beneficiaryfinalForm').valid()) {

            var incompletes = _.filter(self.FinalBeneficiary(), function (item) { return !item.finalBeneficiaryDataComplete(); });
            if (incompletes.length > 0) {
                showError(['Debe completar los datos de los Beneficiarios Finales indicados en rojo.'], 'Guardar Beneficiario Final');
            } else if (self.FinalBeneficiary().length <= 0) {
                showError(['Debe agregar un Beneficiario, sino presione el boton Cancelar.'], 'Guardar Beneficiario Final');
            }
            else {
                $('#BeneficiaryPopup').hide();
            }
        }
        return false;
        /**/
    };

    self.ShowButtonBeneficiaryFinal = function () {
        if (self.FinalBeneficiary().length > 0) {
            return true;
        }
        return false;
    };

    self.OpenModalButtonBeneficiaryFinal = function () {

        if (self.FinalBeneficiary().length > 0) {
            $('#BeneficiaryPopup').show();
            return true;
        }
        $('#BeneficiaryPopup').hide();
        return false;
    };

    self.CancelSetBeneficiaryFinal = function () {

        if (self.FinalBeneficiary().length > 0) {

            var bene = _.find(self.FinalBeneficiary(), function (d) { return d.driverID() == self.infoAdDriver().id() && d.id() == self.infoAdBeneficiaryFinal().id(); });

            if (bene != undefined) {
                self.FinalBeneficiary.remove(bene);
            }

        } else {
            self.FinalBeneficiary.removeAll();
        }

        $('#BeneficiaryPopup').hide();
    };

    self.removeBeneficiaryFinal = function (BeneficiaryToRemove) {
        self.FinalBeneficiary.remove(BeneficiaryToRemove);
    };

    self.showOrNotIdentificationFinalBeneficiaryForm = ko.computed(function () {

        var currentStepId = self.parent.currentStepId();

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() == 'RNC') {

            /*$("#PepFormularyOptionsId").attr("disabled", "disabled");
            self.infoAdDriver().PepFormularyOptionsId(null);
            self.PEP.removeAll();*/

            if (self.IdentificationFinalBeneficiaryOptionsList() && self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId()) {
                var idfibeOption = _.find(self.IdentificationFinalBeneficiaryOptionsList(), function (item) { return item.id == self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(); });
                if (idfibeOption.allowed == true) {


                    if (currentStepId == 4) {

                        //Mostrar el Formulario Identificacion Beneficiario Final

                        if (self.isfirstLoadBF()) {
                            self.isfirstLoadBF(false);
                        }

                        if (self.isfirstLoadBF() == false && self.FinalBeneficiary().length <= 0) {
                            $(".IdentificationFinalBeneficiaryPOP").show();
                        }

                        if (self.FinalBeneficiary().length <= 0) {
                            prepareNewBeneficiaryFinal();
                        }
                        return true;
                    }
                }
            }
        }
        //Esconder el Formulario Identificacion Beneficiario Final        
        //LIMPIAR EL MODELO   
        if (currentStepId == 4) {

            if (self.FinalBeneficiary().length > 0) {

                var bene = _.find(self.FinalBeneficiary(), function (d) { return d.driverID() == self.infoAdDriver().id() && d.id() == self.infoAdBeneficiaryFinal().id(); });

                if (bene != undefined) {
                    self.FinalBeneficiary.remove(bene);
                }

            } else {
                self.FinalBeneficiary.removeAll();
            }
            $(".IdentificationFinalBeneficiaryPOP").hide();
            $('#BeneficiaryPopup').hide();
        }
        return false;
    });

    self.FinalBeneficiary.subscribe(function (changes) {

        _.each(changes, function (change) {
            if (change.status == 'added') {
                if (self.FinalBeneficiary().length > 0) {
                    self.loadFinalBeneficiaryDriver(self.FinalBeneficiary()[0]);
                }
            }
        });
    }, null, "arrayChange");

    self.ListBeneficiaryByDriver = ko.computed(function () {

        var listBene = ko.utils.arrayFilter(self.FinalBeneficiary(), function (d) { return d.driverID() == self.infoAdDriver().id(); });
        return listBene;
    });

    self.disabledPercentajeBF = ko.computed(function () {
        var currentStepId = self.parent.currentStepId();

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {

            if (self.IdentificationFinalBeneficiaryOptionsList() && self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId()) {
                var idfibeOption = _.find(self.IdentificationFinalBeneficiaryOptionsList(), function (item) { return item.id == self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(); });
                if (idfibeOption.allowed == true) {
                    if (currentStepId == 4) {
                        $(".percentageBeneficiary").attr("disabled", "disabled");
                        $('.percentageBeneficiary').removeClass("errorBorder");
                        return true;
                    }
                }
            }
        }
        $(".percentageBeneficiary").removeAttr("disabled");
        return false;
    });

    self.newShowBFExplication = ko.computed(function () {

        var befshow = null;

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC') {

            $('#spanBF').qtip({ // Grab some elements to apply the tooltip to
                content: {
                    text: self.ShowBeneficiaryFinalExplication(),
                    title: '¿Que es esto?'
                }
            });
            befshow = self.ShowBeneficiaryFinalExplication();
        } else {
            $('#spanBF').qtip({ // Grab some elements to apply the tooltip to
                content: {
                    text: self.ShowBeneficiaryFinalExplicationCompany(),
                    title: '¿Que es esto?'
                }
            });

            befshow = self.ShowBeneficiaryFinalExplicationCompany();
        }
        if (befshow != null) {
            befshow = befshow.replace("<p>", "").replace("</p>", "");
            self.ShowBeneficiaryFinalExplicationFootPage(befshow);
        }
    });

    //#endregion

    //#region [Driver edition methods]

    self.addDriver = function (formElement) {

        //$('#dateOfBirth').removeAttr('readonly');
        if ($('#addDriverForm').valid()) {

            var driver = null;

            var isEditing = self.editingDriver != null;

            if (isEditing)
                driver = self.editingDriver;
            else
                driver = new driverViewModel();

            self.isEditingDriver(false);

            if (self.newDriver.principal()) {
                _.each(self.drivers(), function (item) {
                    item.principal(false);
                });
            }

            driver.provinceId(self.newDriver.provinceId());
            driver.municipalityId(self.newDriver.municipalityId());
            driver.cityId(self.newDriver.cityId());
            driver.dateOfBirth(self.newDriver.dateOfBirth());
            driver.email(self.newDriver.email());
            driver.firstName(self.newDriver.firstName());
            driver.phoneNumber(self.newDriver.phoneNumber());
            driver.surname(self.newDriver.surname());
            driver.principal(self.newDriver.principal());
            driver.selectedSex(self.newDriver.selectedSex());
            driver.identificationType(self.newDriver.identificationType());
            driver.license(self.newDriver.license());

            var realf = self.newDriver.ForeignLicense() == 2 ? 2 : self.newDriver.ForeignLicense() == 1 ? 1 : false;
            driver.ForeignLicense(realf);

            driver.IdentificationNumberValidDate(self.newDriver.IdentificationNumberValidDate());


            driver.PostalCode(self.newDriver.PostalCode());
            driver.AnnualIncome(self.newDriver.AnnualIncome());

            driver.PepFormularyOptionsId(self.newDriver.PepFormularyOptionsId());
            driver.SocialReasonId(self.newDriver.SocialReasonId());
            driver.OwnershipStructureId(self.newDriver.OwnershipStructureId());
            driver.IdentificationFinalBeneficiaryOptionsId(self.newDriver.IdentificationFinalBeneficiaryOptionsId());

            //Julisy Amador
            driver.HomeOwner(self.newDriver.HomeOwner());
            driver.QtyPersonsDepend(self.newDriver.QtyPersonsDepend());
            driver.QtyEmployees(self.newDriver.QtyEmployees());
            //driver.Linked(self.newDriver.Linked());
            driver.Linked('NI');
            //driver.segment(self.newDriver.segment());
            driver.segment('010000');
            driver.Fax(self.newDriver.Fax());
            driver.URL(self.newDriver.URL());

            if (isEditing)
                self.editingDriver = null;
            else
                self.drivers.push(driver);

            var ppal = _.find(self.drivers(), function (item) { return item.principal(); });
            if (ppal == null && self.drivers().length > 0) {
                self.drivers()[0].principal(true);
            }

            self.newDriver.clear();
            self.newDriver.id(undefined);



        }
        //$('#dateOfBirth').attr('readonly', 'readonly');
    }

    self.isEditingDriver = ko.observable(false);


    self.enableContinueStep1 = ko.computed(function () {
        return self.drivers().length > 0 && !self.isEditingDriver();
    });

    self.editDriver = function (pos) {
        self.editingDriver = self.drivers()[self.drivers().indexOf(pos)];

        self.newDriver.id(self.editingDriver.id());
        self.newDriver.provinceId(self.editingDriver.provinceId());
        self.newDriver.municipalityId(self.editingDriver.municipalityId());
        self.newDriver.cityId(self.editingDriver.cityId());
        //self.newDriver.dateOfBirth(self.editingDriver.dateOfBirth());
        self.newDriver.email(self.editingDriver.email());
        self.newDriver.firstName(self.editingDriver.firstName());
        self.newDriver.phoneNumber(self.editingDriver.phoneNumber());
        self.newDriver.surname(self.editingDriver.surname());
        self.newDriver.principal(self.editingDriver.principal());
        self.newDriver.selectedSex(self.editingDriver.selectedSex());
        self.newDriver.identificationType(self.editingDriver.identificationType());
        self.newDriver.license(self.editingDriver.license());

        if (self.newDriver.identificationType() != 'RNC') {
            self.newDriver.dateOfBirth(self.editingDriver.dateOfBirth());
        } else {
            self.newDriver.dateOfBirth('');
        }

        var realf = self.editingDriver.ForeignLicense() == 2 ? 2 : self.editingDriver.ForeignLicense() == 1 ? 1 : 2;
        self.newDriver.ForeignLicense(realf);

        self.newDriver.IdentificationNumberValidDate(self.editingDriver.IdentificationNumberValidDate());


        self.newDriver.PostalCode(self.editingDriver.PostalCode());
        self.newDriver.AnnualIncome(self.editingDriver.AnnualIncome());

        //Julisy Amador

        self.newDriver.HomeOwner(self.editingDriver.HomeOwner());
        self.newDriver.QtyPersonsDepend(self.editingDriver.QtyPersonsDepend());
        self.newDriver.QtyEmployees(self.editingDriver.QtyEmployees());
        //self.newDriver.Linked(self.editingDriver.Linked());
        self.newDriver.Linked('NI');
        // self.newDriver.segment(self.editingDriver.segment());
        self.newDriver.segment('010000');
        self.newDriver.Fax(self.editingDriver.Fax());
        self.newDriver.URL(self.editingDriver.URL());

        self.newDriver.PepFormularyOptionsId(self.editingDriver.PepFormularyOptionsId());
        self.newDriver.SocialReasonId(self.editingDriver.SocialReasonId());
        self.newDriver.OwnershipStructureId(self.editingDriver.OwnershipStructureId());
        self.newDriver.IdentificationFinalBeneficiaryOptionsId(self.editingDriver.IdentificationFinalBeneficiaryOptionsId());

        self.isEditingDriver(true);

        self.parent.disableEditVehicle(true);
        return false;

    }

    self.removeDriver = function (pos) {
        var driverToRemove = self.drivers()[self.drivers().indexOf(pos)];
        self.drivers.remove(driverToRemove);
        if (self.editingDriver != null) {
            self.editingDriver = null;
            self.newDriver.clear();
        }
        var principal = _.find(self.drivers(), function (item) { return item.principal() });
        if (principal == null && self.drivers().length > 0)
            self.drivers()[0].principal(true);

        self.parent.disableEditVehicle(false);
    }

    self.drivers.subscribe(function (changes) {

        _.each(changes, function (change) {
            if (change.status == 'added') {
                if (self.drivers().length > 0) {
                    self.loadDriversInfoAd(self.drivers()[0]);
                }
            }
        });
    }, null, "arrayChange");

    self.getCountryUser = function () {
        //$.get('/PoSAuto/SendReportForVO', { quotationId: self.parent.quotation().id });
        var userCountry = "";


        $.ajax({
            url: "http://freegeoip.net/json/",
            dataType: 'json',
            async: false,
            data: {},
            success: function (data) {
                var country = data.country_name;
                var ip = data.ip;

                //return country;
                userCountry = country;
            }
        });




        //$.getJSON("http://freegeoip.net/json/", function (data) {

        //    var country = data.country_name;
        //    var ip = data.ip;
        //    
        //    //return country;
        //    userCountry = country;
        //});

        return userCountry;
    }

    self.phoneNumberIsRequired = ko.computed(function () {

        $("#SomePhoneIsValid").val("True");

        if (self.infoAdDriver() && self.infoAdDriver().phoneNumber()/*.length == 0*/ && (!self.infoAdDriver().mobile()/*.length == 0*/ || !self.infoAdDriver().workPhone()/*.length == 0*/)) {

            $("#SomePhoneIsValid").val("False");
            return false;
        } else if (self.infoAdDriver() && self.infoAdDriver().mobile() && (!self.infoAdDriver().phoneNumber() || !self.infoAdDriver().workPhone())) {

            $("#SomePhoneIsValid").val("False");
            return false;
        }
        else if (self.infoAdDriver() && self.infoAdDriver().workPhone() && (!self.infoAdDriver().phoneNumber() || !self.infoAdDriver().mobile())) {

            $("#SomePhoneIsValid").val("False");
            return false;
        }
        else if (self.infoAdDriver() && self.infoAdDriver().workPhone() && self.infoAdDriver().phoneNumber() && self.infoAdDriver().mobile()) {

            $("#SomePhoneIsValid").val("False");
            return false;
        }

        return true;
    });

    self.loadDriversInfoAd = function (driver) {

        if (driver != undefined) {
            self.infoAdDriver().id(driver.id());
            self.infoAdDriver().firstName(driver.firstName());
            self.infoAdDriver().surname(driver.surname());
            self.infoAdDriver().provinceId(driver.provinceId());
            ;
            self.infoAdDriver().municipalityId(driver.municipalityId());
            self.infoAdDriver().cityId(driver.cityId());
            //self.infoAdDriver().dateOfBirth(driver.dateOfBirth());
            self.infoAdDriver().email(driver.email());
            self.infoAdDriver().phoneNumber(driver.phoneNumber());

            self.infoAdDriver().address(driver.address());

            self.infoAdDriver().InvoiceTypeId(driver.InvoiceTypeId());

            self.infoAdDriver().mobile(driver.mobile());
            self.infoAdDriver().workPhone(driver.workPhone());

            self.infoAdDriver().identificationType(driver.identificationType());
            self.infoAdDriver().license(driver.license());

            if (self.infoAdDriver().identificationType() != 'RNC') {
                self.infoAdDriver().dateOfBirth(driver.dateOfBirth());
            } else {
                //self.infoAdDriver().dateOfBirth('');
            }

            var realf = driver.ForeignLicense() == 2 ? 2 : driver.ForeignLicense() == 1 ? 1 : 2;

            self.infoAdDriver().ForeignLicense(realf);

            self.infoAdDriver().IdentificationNumberValidDate(driver.IdentificationNumberValidDate());


            self.infoAdDriver().nationality(driver.nationality());//OROGINAL 06-10-2016
            self.infoAdDriver().job(driver.job());

            self.infoAdDriver().company(driver.company());
            self.infoAdDriver().selectedSexText(driver.selectedSex());
            self.infoAdDriver().PostalCode(driver.PostalCode());
            self.infoAdDriver().AnnualIncome(driver.AnnualIncome());
            self.infoAdDriver().PepFormularyOptionsId(driver.PepFormularyOptionsId());
            self.infoAdDriver().SocialReasonId(driver.SocialReasonId());
            //self.infoAdDriver().OwnershipStructureId(driver.OwnershipStructureId());
            self.infoAdDriver().OwnershipStructureId(driver.OwnershipStructureId);
            self.isAFisicPerson();

            var anuualIncomes = self.infoAdDriver().AnnualIncome();
            var Company = self.infoAdDriver().company();
            var job = self.infoAdDriver().job();

            //var quoTotalPremium = parseFloat($('#QuotationTotalPremium').val()); // prima con impuesto de la cotizacion
            //var totalPremiumValidation = parseFloat($('#ParameterTotalPremium').val()); // monto parametro de validacion

            //if (quoTotalPremium > totalPremiumValidation) { //  si la prima es mayor a 20000, toda la informacion laboral debe ser requerida
            //    if (anuualIncomes <= 0) {
            //        $('#AnnualIncome').addClass('errorBorder');
            //    } else {
            //        $('#AnnualIncome').removeClass('errorBorder');
            //    }

            //    if (Company == null || Company == '') {
            //        $('#company').addClass('errorBorder');
            //    } else {
            //        $('#company').removeClass('errorBorder');
            //    }
            //    if (job == null || job == '') {
            //        $('#job').addClass('errorBorder');
            //    } else {
            //        $('#job').removeClass('errorBorder');
            //    }

            //} else { }

                if ($('#OwnershipStructureId').val() == 4) { // Validando si es persona fisca para obligar al usuario a que coloque el ingreso anual
                    if (anuualIncomes <= 0) {
                        $('#AnnualIncome').addClass('errorBorder');
                    } else {
                        $('#AnnualIncome').removeClass('errorBorder');
                    }

                    if (Company == null || Company == '') {
                        $('#company').addClass('errorBorder');
                    } else {
                        $('#company').removeClass('errorBorder');
                    }
                    if (job == null || job == '') {
                        $('#job').addClass('errorBorder');
                    } else {
                        $('#job').removeClass('errorBorder');
                    }
                } else {
                    if (anuualIncomes > 0) {
                        $('#AnnualIncome').removeClass('errorBorder');
                    }

                    if (Company == null || Company == '') {
                        $('#company').removeClass('errorBorder');
                    }
                }

            
            self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(driver.IdentificationFinalBeneficiaryOptionsId());


            self.infoAdDriver().yearsDriving(0);
            self.infoAdDriver().accidentsLast3Years(0);
            self.infoAdDriver().maritalStatus(0);
            self.infoAdDriver().yearsInCompany(0);

            //Julisy Amador
            self.infoAdDriver().HomeOwner(driver.HomeOwner());
            self.infoAdDriver().QtyPersonsDepend(driver.QtyPersonsDepend());
            self.infoAdDriver().QtyEmployees(driver.QtyEmployees());
            //self.infoAdDriver().Linked(driver.Linked);
            self.infoAdDriver().Linked('NI');
            self.infoAdDriver().segment('010000');
            self.infoAdDriver().Fax(driver.Fax());
            self.infoAdDriver().URL(driver.URL());


            //
            var bene = _.find(self.FinalBeneficiary(), function (d) { return d.driverID() == driver.id(); });
            if (bene != undefined) {
                self.loadFinalBeneficiaryDriver(bene);
            }

            var pep = _.find(self.PEP(), function (d) { return d.driverID() == driver.id(); });
            if (pep != undefined) {
                self.loadPepDriver(pep);
            }

            if (self.infoAdDriver() && self.infoAdDriver().identificationType() == 'RNC') {

                $("#SocialReasonId").removeAttr("disabled");
                $("#OwnershipStructureId").removeAttr("disabled");
                self.infoAdDriver().PepFormularyOptionsId(null);

            } else if (self.infoAdDriver()) {
                self.infoAdDriver().SocialReasonId(null);
                self.infoAdDriver().OwnershipStructureId(null);

                $("#SocialReasonId").attr("disabled", "disabled");
                $("#OwnershipStructureId").attr("disabled", "disabled");
            }


            /*//ORIGINAL 06-10-2016
            self.infoAdDriver().yearsDriving(driver.yearsDriving());
            self.infoAdDriver().accidentsLast3Years(driver.accidentsLast3Years());
            self.infoAdDriver().maritalStatus(driver.maritalStatus());            
            self.infoAdDriver().yearsInCompany(driver.yearsInCompany());*/
        }
        else {
            self.infoAdDriver(new driverViewModel());
        }
    };

    self.IdentificationNumberValidDateRequired = ko.computed(function () {

        $("#IdentificationNumberValidDateValid").val("False");

        if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().identificationType() != 'RNC'
            && self.AllAreLawProducts() == false && !self.infoAdDriver().IdentificationNumberValidDate()) {

            $("#IdentificationNumberValidDateValid").val("True");
            return true;
        }
        return false;
    });

    self.enableContinueStep4 = ko.computed(function () {
        return $('#setAditionalDriverInfoForm')[0] != undefined && $('#setAditionalDriverInfoForm').valid();
    });

    self.setAditionalDriverInfo = function (formElement) {
        self.setAditionalDriverInfoMethod(formElement);
        return false;
    }

    self.setAditionalDriverInfoMethod = function (formElement, onlySaveInvoiceTypeID) {

        if (onlySaveInvoiceTypeID == true) {

            var driver = _.find(self.drivers(), function (d) { return d.id() == self.infoAdDriver().id(); });

            if (driver) {

                driver.provinceId(self.infoAdDriver().provinceId());
                driver.municipalityId(self.infoAdDriver().municipalityId());
                driver.cityId(self.infoAdDriver().cityId());
                driver.dateOfBirth(self.infoAdDriver().dateOfBirth());
                driver.email(self.infoAdDriver().email());
                driver.phoneNumber(self.infoAdDriver().phoneNumber());

                driver.address(self.infoAdDriver().address());

                driver.InvoiceTypeId(self.infoAdDriver().InvoiceTypeId());

                driver.mobile(self.infoAdDriver().mobile());
                driver.workPhone(self.infoAdDriver().workPhone());

                driver.identificationType(self.infoAdDriver().identificationType());
                driver.license(self.infoAdDriver().license());

                var realf = self.infoAdDriver().ForeignLicense() == 2 ? 2 : self.infoAdDriver().ForeignLicense() == 1 ? 1 : 2;
                driver.ForeignLicense(realf);

                driver.IdentificationNumberValidDate(self.infoAdDriver().IdentificationNumberValidDate());

                driver.nationality(self.infoAdDriver().nationality());
                driver.job(self.infoAdDriver().job());

                driver.yearsDriving(0);
                driver.accidentsLast3Years(0);
                driver.maritalStatus(0);
                driver.yearsInCompany(0);

                driver.surname(self.infoAdDriver().surname());
                driver.firstName(self.infoAdDriver().firstName());

                driver.company(self.infoAdDriver().company());
                driver.PostalCode(self.infoAdDriver().PostalCode());
                driver.AnnualIncome(self.infoAdDriver().AnnualIncome());

                driver.PepFormularyOptionsId(self.infoAdDriver().PepFormularyOptionsId());
                driver.SocialReasonId(self.infoAdDriver().SocialReasonId());
                driver.OwnershipStructureId(self.infoAdDriver().OwnershipStructureId());
                driver.IdentificationFinalBeneficiaryOptionsId(self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId());

                //Julisy Amador
                driver.HomeOwner(self.infoAdDriver().HomeOwner());
                driver.QtyPersonsDepend(self.infoAdDriver().QtyPersonsDepend());
                driver.QtyEmployees(self.infoAdDriver().QtyEmployees());
                //driver.Linked(self.infoAdDriver().Linked());
                driver.Linked('NI');
                //driver.segment(self.infoAdDriver().segment());
                driver.segment('010000');
                driver.Fax(self.infoAdDriver().Fax());
                driver.URL(self.infoAdDriver().URL());

                var currIndex = self.drivers().indexOf(driver);

                if (self.drivers().length > currIndex + 1)
                    self.loadDriversInfoAd(self.drivers()[currIndex + 1])
                else
                    self.loadDriversInfoAd(self.drivers()[0]);
            }
            return true;
        }
        else if ($('#setAditionalDriverInfoForm').valid()) {
            var driver = _.find(self.drivers(), function (d) { return d.id() == self.infoAdDriver().id(); });

            if (driver) {

                driver.provinceId(self.infoAdDriver().provinceId());

                driver.municipalityId(self.infoAdDriver().municipalityId());
                driver.cityId(self.infoAdDriver().cityId());
                driver.dateOfBirth(self.infoAdDriver().dateOfBirth());
                driver.email(self.infoAdDriver().email());
                driver.phoneNumber(self.infoAdDriver().phoneNumber());

                driver.address(self.infoAdDriver().address());

                driver.InvoiceTypeId(self.infoAdDriver().InvoiceTypeId());

                driver.mobile(self.infoAdDriver().mobile());
                driver.workPhone(self.infoAdDriver().workPhone());

                driver.identificationType(self.infoAdDriver().identificationType());
                driver.license(self.infoAdDriver().license());

                var realf = self.infoAdDriver().ForeignLicense() == 2 ? 2 : self.infoAdDriver().ForeignLicense() == 1 ? 1 : 2;
                driver.ForeignLicense(realf);

                driver.IdentificationNumberValidDate(self.infoAdDriver().IdentificationNumberValidDate());

                driver.nationality(self.infoAdDriver().nationality());
                driver.job(self.infoAdDriver().job());

                driver.yearsDriving(0);
                driver.accidentsLast3Years(0);
                driver.maritalStatus(0);
                driver.yearsInCompany(0);

                driver.surname(self.infoAdDriver().surname());
                driver.firstName(self.infoAdDriver().firstName());

                driver.company(self.infoAdDriver().company());
                driver.PostalCode(self.infoAdDriver().PostalCode());
                driver.AnnualIncome(self.infoAdDriver().AnnualIncome());

                driver.PepFormularyOptionsId(self.infoAdDriver().PepFormularyOptionsId());
                driver.SocialReasonId(self.infoAdDriver().SocialReasonId());
                driver.OwnershipStructureId(self.infoAdDriver().OwnershipStructureId());
                driver.IdentificationFinalBeneficiaryOptionsId(self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId());

                //Julisy Amador
                driver.HomeOwner(self.infoAdDriver().HomeOwner());
                driver.QtyPersonsDepend(self.infoAdDriver().QtyPersonsDepend());
                driver.QtyEmployees(self.infoAdDriver().QtyEmployees());
                //driver.Linked(self.infoAdDriver().Linked());
                driver.Linked('NI');
                driver.segment('010000');
                driver.Fax(self.infoAdDriver().Fax());
                driver.URL(self.infoAdDriver().URL());

                var currIndex = self.drivers().indexOf(driver);

                if (self.drivers().length > currIndex + 1) {
                    self.loadDriversInfoAd(self.drivers()[currIndex + 1])
                }
                else {
                    self.loadDriversInfoAd(self.drivers()[0]);
                }

                //Success message
                var pending = $.map(self.drivers(), function (a, index) { if (!a.driverAditionalDataComplete()) return a.toString(); });
                if (pending.length)
                    showSuccess("Los datos del conductor " + driver.toString() + " han sido completados exitosamente.",
                        "Está pendiente por completar los datos de los siguientes conductores:",
                        pending
                    );
            }
            return true;
        }
        else {
            return false;
        }
    };
    

    //#endregion

    //#region [Vehicle edition methods]

    self.addVehicle = function () {

        var newVehicle = new vehicleViewModel(this);
        var veh = self.vehicles();
        var lastVeh = veh[self.vehicles().length - 1];

        var qtyVehicles = 1;
        if (lastVeh) {
            //var qtyVehicles = (self.vehicles().length + 1);//Original 18-08-2017
            qtyVehicles = (lastVeh.SecuenciaVehicleSysflex() + 1);//Cambio
        }

        newVehicle.SecuenciaVehicleSysflex(qtyVehicles);


        self.vehicles.push(newVehicle);

        $(".tbl.agregar_vh tbody tr:last td:first select").focus();

        self.showButtonDuplicate(false);
    };

    self.enableContinueStep2 = ko.computed(function () {
        /*ORIGINAL 11-10-2016*/
        //var incompletes = ko.utils.arrayFilter(self.vehicles(), function (a) { return !a.vehicleDataComplete(); });
        //return incompletes.length === 0;

        var incompletes = ko.utils.arrayFilter(self.vehicles(), function (a) { return !a.vehicleDataComplete(); });
        var iscomplete = (incompletes.length === 0);

        var agent = self.parent.agent();
        var agentAlist = self.parent.agentList();

        var hasAgent = (agent != undefined && agent != "");

        /*Esto es para saber cuando sea el usuario por default, osea el usuario de ventas directas*/
        if (agentAlist.length == 0 && agent == undefined) {
            hasAgent = true;
        }

        if (hasAgent && iscomplete) {

            return false;
        }

        return true;
    });

    self.stepVehicleCompleted = function () {
        var incompletes = $.map(self.vehicles(), function (a, index) { if (!a.vehicleDataComplete()) return a.toString(); });
        if (incompletes.length > 0) {
            showError(['Debe completar los datos de los vehículos indicados en rojo.'], 'Agregar Vehículos');
        }
        else {
            self.parent.nextStep(self.sendQuotationToVo);
            self.showButtonDuplicate(true);
        }
    }

    self.sendQuotationToVo = function () {
        //$.get('/PoSAuto/SendReportForVO', { quotationId: self.parent.quotation().id });
    }

    self.removeVehicle = function (vehicleToRemove) {

        self.vehicles.remove(vehicleToRemove);

        var qtyVehicles = self.qtyVehiclesCreated();

        $.ajax({
            url: '/PoSAuto/GetPercentByQtyVehicle',
            type: 'POST',
            dataType: 'json',
            data: { qtyVehicles: qtyVehicles },
            async: false,
            success: function (data) {
                self.PercentByQtyVehicle(data);

                if (data > 0) {
                    self.isFlotilla(true);
                } else {
                    self.isFlotilla(false);
                }
            }
        });

        self.showButtonDuplicate(false);

        if (vehicleToRemove.SecuenciaVehicleSysflex() > 0) {
            $.ajax({
                url: '/PoSAuto/DeleteVehicleOnSysflex',
                type: 'POST',
                dataType: 'json',
                data: { SecuenciaVehicleSysflex: vehicleToRemove.SecuenciaVehicleSysflex(), quotationCoreNumber: self.quotationCoreNumber() },
                async: false,
                success: function (data) {
                    if (data == "ERROR") {
                        showError(['A ocurrido un error Eliminando el Vehículo'], 'Eliminando Vehículo');
                    }
                }
            });
        }
    };

    self.getAdditionalsPrime = function () {
        _.each(self.additionalProductList(), function (additional) { additional.prime(0); });
        var selected = _.filter(self.additionalProductList(), function (additional) { return additional.selected(); });

        _.each(selected, function (additional) { additional.prime(20000); })
    }

    self.calculatedServicesPrime = ko.computed(function () {
        if (self.currentProductLimitSet() && self.currentProductLimitSet().ServicesCoverages) {
            var selected = _.filter(self.currentProductLimitSet().ServicesCoverages(), function (item) { return item.IsSelected(); });
            var total = 0;
            _.each(selected, function (item) { total += item.Amount(); });
            self.currentProductLimitSet().ServicesPrime(total);
            return total;
        }
        else {
            return 0;
        }
    });

    self.vehicles.subscribe(function (changes) {
        _.each(changes, function (change) {
            if (change.status == 'added') {

                if (self.vehicles().length > 0) {
                    self.loadInfoAdVehicle(self.vehicles()[0]);
                }
            }
        });
    }, null, "arrayChange");

    self.loadInfoAdVehicle = function (vehicle) {
        self.infoAdVehicle().id(vehicle.id());
        self.infoAdVehicle().chassis(vehicle.chassis());
        self.infoAdVehicle().plate(vehicle.plate());
        self.infoAdVehicle().cylinders(vehicle.cylinders());
        self.infoAdVehicle().color(vehicle.color());
        self.infoAdVehicle().passengers(vehicle.passengers());
        self.infoAdVehicle().year(vehicle.year());
        self.infoAdVehicle().weight(vehicle.weight());
        self.infoAdVehicle().usage(vehicle.usage());
        self.infoAdVehicle().driver(vehicle.driver());

        self.infoAdVehicle().NumeroFormulario(vehicle.NumeroFormulario());



        var vehicleName = vehicle.toString();
        self.infoAdVehicle().selectedVehicleToStringStatic(vehicleName);

        var brand = '';
        if (vehicle.brand && vehicle.brand())
            brand = vehicle.brandName();
        self.infoAdVehicle().selectedVehicleBrandNameStatic(brand);

        var model = '';
        if (vehicle.model && vehicle.model())
            model = vehicle.modelName();
        self.infoAdVehicle().selectedVehicleModelNameStatic(model);

        var type = '';
        if (vehicle.selectedVehicleType && vehicle.selectedVehicleType())
            type = vehicle.selectedVehicleType().Name;
        self.infoAdVehicle().selectedVehicleTypeNameStatic(type);

        var year = '';
        if (vehicle.year && vehicle.year())
            year = vehicle.year();
        self.infoAdVehicle().selectedVehicleYearStatic(year);


        $('.datepicker.effectivedate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('#effectivedate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('.datepicker.effectivedateend').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('#effectivedateend').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });
    }

    self.saveAditionalVehicleInfo = function (formElement, keepThisVehicle) {
        ;
        var vehicle = _.find(self.vehicles(), function (v) { return v.id() == self.infoAdVehicle().id(); });
        if (vehicle) {
            vehicle.chassis(self.infoAdVehicle().chassis());
            vehicle.plate(self.infoAdVehicle().plate());
            vehicle.color(self.infoAdVehicle().color());
            vehicle.passengers(self.infoAdVehicle().passengers());
            vehicle.usage(self.infoAdVehicle().usage());
            vehicle.driver(self.infoAdVehicle().driver());
            vehicle.weight(self.infoAdVehicle().weight());
            vehicle.cylinders(self.infoAdVehicle().cylinders());

            vehicle.NumeroFormulario(self.infoAdVehicle().NumeroFormulario());

            var currIndex = self.vehicles().indexOf(vehicle);

            if (!keepThisVehicle) {
                if (self.vehicles().length > currIndex + 1)
                    self.loadInfoAdVehicle(self.vehicles()[currIndex + 1])
                else
                    self.loadInfoAdVehicle(self.vehicles()[0]);
            }

            var pending = $.map(self.vehicles(), function (a, index) { if (!a.vehicleAditionalDataComplete()) return a.toString(); });

            if (self.vehicles().length > 1) {

                //If this vehicle is complete, show success message with pendings 
                if (vehicle.vehicleAditionalDataComplete()) {
                    if (pending.length)
                        showSuccess("Los datos del " + vehicle.toString() + " han sido completados exitosamente.",
                            "Está pendiente por completar los datos de los siguientes vehículos:",
                            pending
                        );
                }
                else { //else, show error message with pendings
                    if (pending.length)
                        showErrorAuto("Los datos del " + vehicle.toString() + " no están completos.",
                            "Está pendiente por completar los datos de los siguientes vehículos:",
                            pending
                        );
                    return false;
                }
            }
            else {
                if (pending.length) {
                    showErrorAuto("Los datos del " + vehicle.toString() + " no están completos.",
                        "Está pendiente por completar los datos de los siguientes vehículos:",
                        pending
                    );
                    return false;
                }
            }

            var isRequired = self.isRequiredEffectiveDate();
            var isRequiredEndDate = self.isRequiredEffectiveDateEnd();

            if (isRequired /*&& self.AllAreLawProducts()*/) {
                showError(['La Fecha Inicio de Vigencia es Requerida'], 'Fecha Inicio de Vigencia');
                return false;
            }

            if (isRequiredEndDate /*&& self.AllAreLawProducts()*/) {
                showError(['La Fecha Fin de Vigencia es Requerida'], 'Fecha Fin de Vigencia');
                return false;
            }


            if (self.payment.applicant && self.payment.applicant.frequency() == undefined) {
                showError(['La Frecuencia de Pago es Requerida'], 'Frecuencia de Pago');
                return false;
            }

        }
        return true;
    }

    self.setAditionalVehicleInfo = function (formElement) {

        self.saveAditionalVehicleInfo(formElement);
        return false;

    };

    self.servicesAvailable = ko.computed(function () {
        var result = false;
        if (self.currentProductLimitSet()) {
            if (self.currentProductLimitSet() && self.currentProductLimitSet().ServicesCoverages) {
                if (self.currentProductLimitSet().ServicesCoverages() && self.currentProductLimitSet().ServicesCoverages().length > 0)
                    result = true;
            }
        }
        return result;
    })

    self.selfDamagesAvailable = ko.computed(function () {
        var result = false;
        if (self.currentProductLimitSet()) {
            if (self.currentProductLimitSet() && self.currentProductLimitSet().SelfDamagesCoverages) {
                if (self.currentProductLimitSet().SelfDamagesCoverages() && self.currentProductLimitSet().SelfDamagesCoverages().length > 0)
                    result = true;
            }
        }
        return result;
    })

    self.showSelfDamagesResume = ko.pureComputed(function () {
        var result = false;
        self.vehicles().forEach(function (v) {
            if (v.productLimitSet() && v.productLimitSet().SelfDamagesCoverages() && v.productLimitSet().SelfDamagesCoverages().length > 0)
                result = result || true;
        });

        return result;
    });

    self.showDeduciblesResume = ko.pureComputed(function () {
        var result = false;
        self.vehicles().forEach(function (v) {
            if (v.deductibleList() && v.deductibleList().length > 0)
                result = result || true;
        });

        return result;

    });

    self.showSuplementsResume = ko.computed(function () {
        var result = false;

        self.vehicles().forEach(function (v) {
            if (v.productLimitSet() && v.productLimitSet().ServicesCoverages() && v.productLimitSet().ServicesCoverages().length > 0) {
                _.each(v.productLimitSet().ServicesCoverages(), function (item) {
                    if (item.Coverages() && item.Coverages().length > 0) {
                        _.each(item.Coverages(), function (covs) {
                            result = result || covs.IsSelected();
                        });
                    }
                });
            }
        });
        return result;
    });

    //#endregion


    //#region [Side quotation resume methods]

    self.resumePricing = ko.computed(function () {
        var resume = new resumePricingViewModel();

        var columnsNames = eval($('#columnNames').val());
        var secondColumnsNames = eval($('#secondColumnNames').val());

        resume.columns.push(new resumePricingItemViewModel().item(columnsNames[0]).align("center").className("c1"));
        resume.columns.push(new resumePricingItemViewModel().item(columnsNames[1]).align("center").className("c2"));
        resume.columns.push(new resumePricingItemViewModel().item("").align("right").className("c3").style("width: 32px;"));

        _.each(self.drivers(), function (driver, index) {
            var driverName = new resumePricingItemViewModel().item(driver.toString()).align("center").className("c1");
            var birthDate = new resumePricingItemViewModel().item(driver.identificationType() != 'RNC' ? driver.dateOfBirth() : "N/A").align("center").className("c2");
            var driverEdit = new resumePricingItemViewModel().align("left").className("c3");
            if (self.parent.currentStepId() < 6) {
                driverEdit.action.className("grid_icons cazul edit");
                driverEdit.action.funct = function () {
                    self.parent.mainData().initSteps(true);
                    self.parent.setSelectedStep(1);
                    self.parent.setHistory(1);
                    self.editDriver(driver);
                };
            }

            var resumeItem = [driverName, birthDate, driverEdit];
            resume.items.push(resumeItem);
        });

        resume.secondColumns.push(new resumePricingItemViewModel().item(secondColumnsNames[0]).align("center").className("c1"));
        resume.secondColumns.push(new resumePricingItemViewModel().item(secondColumnsNames[1]).align("center").className("c2"));
        resume.secondColumns.push(new resumePricingItemViewModel().item(secondColumnsNames[4]).align("center").className("c3"));
        resume.secondColumns.push(new resumePricingItemViewModel().item(secondColumnsNames[3]).align("center").className("c3"));
        resume.secondColumns.push(new resumePricingItemViewModel().item(secondColumnsNames[2]).align("center").className("c3"));
        resume.secondColumns.push(new resumePricingItemViewModel().item("").align("center").className("c4").style("width: 32px;"));

        var vehiclesToEvaluate = _.filter(self.vehicles(), function (v) { return v.selectedProduct() != undefined });
        if (vehiclesToEvaluate.length > 0) {
            _.each(vehiclesToEvaluate, function (vehicle, index) {
                var vehicleName = new resumePricingItemViewModel().item(vehicle.toString()).align("center").className("c1");
                var vehicleEdit = new resumePricingItemViewModel().align("center").className("c4");
                if (self.parent.currentStepId() < 6) {
                    vehicleEdit.action.className("grid_icons cazul edit");
                    vehicleEdit.action.funct = function () { self.parent.mainData().initSteps(true); self.parent.setSelectedStep(2); self.parent.setHistory(2); };
                }

                var productName = new resumePricingItemViewModel().item(vehicle.getSelectedProductName()).align("center").className("c2");
                var prime = new resumePricingItemViewModel().item(vehicle.totalPrime()).align("center").className("c3");

                var VehiclesQty = new resumePricingItemViewModel().item(vehicle.VehicleQuantity()).align("center").className("c3").formatMoney("F");
                var PrimeByVehiclesQty = (vehicle.totalPrime() * vehicle.VehicleQuantity());
                var PrimeByVehiclesQtyCell = new resumePricingItemViewModel().item(PrimeByVehiclesQty).align("center").className("c3");

                var resumeItem = [vehicleName, productName, prime, VehiclesQty, PrimeByVehiclesQtyCell, vehicleEdit];
                resume.secondItems.push(resumeItem);
            });
        }

        var PercentByQtyVehicle = self.PercentByQtyVehicle();

        if (self.isFlotilla()) {

            var qtyVehi = false;
            var qtyVehiBiggerThanOne = self.qtyVehiclesCreated();
            if (qtyVehiBiggerThanOne > 1) {
                qtyVehi = true;
            }

            if (PercentByQtyVehicle == 0 && qtyVehi) {

                $.ajax({
                    url: '/PoSAuto/GetPercentByQtyVehicle',
                    type: 'POST',
                    dataType: 'json',
                    data: { qtyVehicles: qtyVehiBiggerThanOne },
                    async: false,
                    success: function (data) {

                        self.PercentByQtyVehicle(data);
                        PercentByQtyVehicle = self.PercentByQtyVehicle();

                        if (data > 0) {
                            self.isFlotilla(true);
                        } else {
                            self.isFlotilla(false);
                        }
                    }
                });
            }
        }

        if (PercentByQtyVehicle > 0) {

            resume.totalPrime(self.totalPrime());

            resume.percentFlotillaDiscount(PercentByQtyVehicle);
            resume.TotalFlotillaDiscount(self.TotalByQtyVehicle());

            /*New TotalPrime*/
            var newTotal = self.totalPrime() - self.TotalByQtyVehicle();
            var percentInsurance = self.GetPercentToInsured();
            var Totaltaxes = newTotal * (percentInsurance / 100);

            var it = self.getInfoDriverInvoiceTypeID();

            if (it == true) {
                Totaltaxes = 0;
            }

            resume.totalPrimeFlotillaDiscount(newTotal);

            resume.totalIsc(Totaltaxes);

            resume.total(newTotal + Totaltaxes);

            /**/

        } else {

            /*Original*/
            resume.totalPrime(self.totalPrime());

            var newtotalIsc = self.totalIsc();
            var percentInsurance = self.GetPercentToInsured();

            if (isNaN(percentInsurance)) {
                percentInsurance = 16;
            }

            if (isNaN(newtotalIsc)) {
                newtotalIsc = (self.totalPrime() * (percentInsurance / 100));
            }

            resume.totalIsc(newtotalIsc);
            resume.total(self.totalPrime() + newtotalIsc);
        }

        return resume;

    });

    //#endregion

    //#region [Reports]

    self.showBuyReport = function () {
        self.getReporteCotizacionAuto(function (reportUrl) {
        });
    }

    self.showContract = function (quotId) {
        if (quotId) {
            $.getJSON("/PosAuto/CrearImpresionContratoVenta", { nroCotizacion: quotId }, function (data) {
                if (!data.error) {
                    $('#reportIframe').attr('src', data.reportName);
                    $('.modal.autoPDF.pag_17').show();
                }
            });
        }
        else
            alert("Debe guardar la cotización.");
    }

    self.showReportQuotation = function () {
        self.getReporteCotizacionAuto(function (reportUrl) {
            window.open(reportUrl, '_blank');
            //original
            //window.open('/ReportViewer?reportPath=' + reportUrl + '&idQuotation=' + self.parent.quotation().id, '_blank');//, 'left=100,top=100,width=400,height=300,toolbar=1,resizable=0');
        });
    };

    self.downloadReportQuotation = function () {
        self.getReporteCotizacionAuto(function (reportUrl) {
            $("#a_load").remove();

            var a = document.createElement('a');
            a.id = "a_load";
            a.target = "_blank";
            a.download = "Cotizacion";
            a.href = reportUrl;

            a.click();
        });
    }

    self.getReporteCotizacionAuto = function (callback) {
        var quotationNumber = self.parent.quotation();

        if (quotationNumber) {
            $.getJSON("/PosAuto/GetReport", { quotationId: quotationNumber.id }, function (data) {
                if (!data.error) {
                    callback(data.reportName);
                }
                else {
                    showError([data.error], "Ver Cotización en Progreso");
                }
            });
        }
        else
            showError(["Debe tener seleccionada una cotización, o guardar la cotización en curso."], "Ver Cotización en Progreso");
    }

    self.printReporteCotizacion = function () {
        self.getReporteCotizacionAuto(function (reportUrl) {

            $.getJSON("/PosAuto/PrintReport", { sourceFile: reportUrl }, function (data) {
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
        $.getJSON("/PosAuto/EnviarReporteEmail", { destinatarios: JSON.stringify(ko.toJS(emailDestList)), idCotizacion: self.parent.quotation().id, sourceFile: fileName }, function (data) {
            if (data.error) {
                showErrorAuto("Envío de reporte", data.error, null, function () { $('#reportFrame').show(); });
            }
            else {
                $('.modal.popup03.popupEmail').hide();
                showSuccess("Envío de reporte", "El reporte se envió correctamente a los destinatarios.", null, null, function () { $('#reportFrame').show(); });
            }
        });
    };

    self.showMarbete = function (quotId) {

        if (quotId) {
            $.getJSON("/PosAuto/CrearMarbete", { nroCotizacion: quotId }, function (data) {
                if (!data.error) {
                    $('#reportIframe').attr('src', data.reportName);
                    $('.modal.autoPDF.pag_17').show();
                }
            });
        }

    };

    self.showMarbeteTH = function (quotId) {

        if (quotId) {
            $.getJSON("/PosAuto/CrearMarbeteTH", { quotationId: quotId }, function (data) {
                if (!data.error) {
                    //$('#reportIframe').attr('src', data.reportName);
                    //$('.modal.autoPDF.pag_17').show();

                    showReport(data.reportName, null);
                }
            });
        }
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

                if (self.payment.applicant.wayToPay() == 2) {
                    self.Messaging(false);

                    //Guardando los cambios antes de hacer el pago
                    self.saveQuotation(true);

                    $('#paymentFormContainer').load('/CardNet/CardnetPayment/GeneratePostFormForAuthorization', { quotationId: quotationId }, function () {
                        $('#paymentFormContainer>form').submit();
                    });
                }

                if (self.payment.applicant.wayToPay() == 4) {
                    self.Messaging(false);

                    //Guardando los cambios antes de hacer el pago
                    self.saveQuotation(true);


                    $.getJSON("/PosAuto/AchPayment", {
                        quotationId: quotationId,
                        achName: self.payment.ach.name(), //Nombre cuenta habiente
                        achBankRoutingNumber: self.payment.ach.achBankRoutingNumber(), //Routing number
                        achAccountHolderGovernmentId: self.payment.ach.achAccountHolderGovernmentId(), //No. Identificación Cuenta Habiente
                        achType: self.payment.ach.type(), //Tipo de Cuenta
                        achAccountNumber: self.payment.ach.number() //Número de Cuenta
                    }, function (data) {
                        if (data.success) {
                            $('#marbeteReciboQuotId').val(data.quotationId);
                            var policyNo = data.policyNo
                            if (data.policyNo == null || data.policyNo == undefined || data.policyNo === "") {
                                policyNo = "N/A";
                            }

                            if (data.goodandbad === "S") {
                                $("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja, pero, se genero correctamente el número de póliza en SysFlex......... No. Póliza: " + policyNo);
                                $('.suCompra').show();
                                window.history.replaceState({}, '', '/Auto/PosAuto');

                                $(".overlaypp").show();
                            } else if (data.goodandbad === "GP") {
                                //$("#noPolicyMarbete").html("Ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder, de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + policyNo);

                                $("#noPolicyMarbete").html(data.errorGPToSysflexMessage.replace("{0}", policyNo));
                                $('.suCompra').show();
                                window.history.replaceState({}, '', '/Auto/PosAuto');

                                $(".overlaypp").show();
                            }
                            else if (data.goodandbad === "GP2") {
                                //$("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja y ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder,  de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + policyNo);

                                $("#noPolicyMarbete").html(data.errorGPToSysflexMessage2.replace("{0}", policyNo));
                                $('.suCompra').show();
                                window.history.replaceState({}, '', '/Auto/PosAuto');

                                $(".overlaypp").show();
                            }
                            else {
                                $("#noPolicyMarbete").html("No. Poliza: " + policyNo);
                                $('.suCompra').show();
                                window.history.replaceState({}, '', '/Auto/PosAuto');

                                $(".overlaypp").show();
                            }
                        }
                        else {
                            showError([data.message], "Pago ACH");

                            $(".overlaypp").hide();
                        }
                    });
                }

                if (self.payment.applicant.wayToPay() == 1) {

                    self.allReadyPay(false);

                    var allReadyPay = self.allReadyPay();

                    if (self.Messaging() == true) {

                        var agent = "";
                        if (self.parent.agent() && self.parent.agent().NameId) {
                            agent = self.parent.agent();

                            var NotifyMessagingAgent = self.NotifyMessagingAgent();

                            showQuestion("Notificar Mensajería", "¿" + NotifyMessagingAgent + " " + agent.FullNameAll + "?",
                                function () {
                                    self.Messaging(true);
                                    docashPayment(quotationId, allReadyPay);
                                    self.allReadyPay(true);
                                    return true;
                                },
                                function () { return false; }
                            );
                        } else {
                            self.Messaging(false);
                            docashPayment(quotationId, allReadyPay);
                        }
                    } else {
                        self.Messaging(false);
                        docashPayment(quotationId, allReadyPay);
                    }
                }
            });
        }
    };

    self.skipPayment = function (formElement) {
        if (userType !== 'Assistant' && userType !== 'Agent')
            return;

        self.Messaging(false);
        self.saveQuotation(true);
        var paramAmount = 0;
        var quotationId = self.parent.quotation().id;
        var MinimumAmountToPay = self.minAllowedAmountToPayShow();
        var AmountToPay = self.payment.amountToPayEntered();

        if (AmountToPay >= MinimumAmountToPay)
            paramAmount = AmountToPay;
        else
            paramAmount = MinimumAmountToPay

        $.getJSON("/PosAuto/ChargeQuotation",
            { quotationId: quotationId, MinimumAmountToPay: paramAmount },
            function (data) {

                if (data.success) {
                    window.history.replaceState({}, '', '/Auto/PosAuto');
                    //showSuccess("Cotización", "La cotización se ha dado por finalizada correctamente.", null, null, function () { self.parent.newQuotationNoQuestion(); });
                    showSuccess("Cotización", data.message, null, null, function () { self.parent.newQuotationNoQuestion(); location.reload(); }, false);
                }
                else
                    showError([data.message], "");
            });
    };

    function docashPayment(quotationId, allReadyPay) {

        if (allReadyPay == false) {
            //Guardando los cambios antes de hacer el pago        
            self.saveQuotation(true);

            $.getJSON("/PosAuto/CashPayment", {
                quotationId: quotationId
            }, function (data) {
                if (data.success) {
                    $('#marbeteReciboQuotId').val(data.quotationId);
                    var policyNo = data.policyNo
                    if (data.policyNo == null || data.policyNo == undefined || data.policyNo === "") {
                        policyNo = "N/A";
                    }

                    if (data.goodandbad === "S") {
                        $("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja, pero, se genero correctamente el número de póliza en SysFlex......... No. Póliza: " + policyNo);
                        $('.suCompra').show();
                        window.history.replaceState({}, '', '/Auto/PosAuto');

                        $(".overlaypp").show();
                    }
                    else if (data.goodandbad === "GP") {
                        //$("#noPolicyMarbete").html("Ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder, de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + policyNo);
                        $("#noPolicyMarbete").html(data.errorGPToSysflexMessage.replace("{0}", policyNo));
                        $('.suCompra').show();
                        window.history.replaceState({}, '', '/Auto/PosAuto');

                        $(".overlaypp").show();
                    }
                    else if (data.goodandbad === "GP2") {
                        //$("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja y ha ocurrido un error al generar la factura en SysFlex, comuníquese con el departamento de cobros para saber como proceder,  de igual manera, se genero correctamente el número de póliza en SysFlex....... No. Póliza: " + policyNo);
                        $("#noPolicyMarbete").html(data.errorGPToSysflexMessage2.replace("{0}", policyNo));
                        $('.suCompra').show();
                        window.history.replaceState({}, '', '/Auto/PosAuto');

                        $(".overlaypp").show();
                    }
                    else {
                        $("#noPolicyMarbete").html("No. Poliza: " + policyNo);
                        $('.suCompra').show();
                        window.history.replaceState({}, '', '/Auto/PosAuto');

                        $(".overlaypp").show();
                    }
                    return;
                }
                else {
                    showError([data.message], "Pago Efectivo");

                    $(".overlaypp").hide();
                }
            });
        }
    }

    //#endregion

    //#region [Initialization methods]

    self.getMinAgeForBirthDate = function (callback) {
        $.getJSON("/PosAuto/GetMinAgeForDriving", function (data) {
            var currDate = moment(new Date());
            var minDate = currDate.add(data.value * -1, 'years');

            callback(minDate);
        });
    }

    self.initSteps = function (quickSteps) {

        if (!self.quickStepsComplete() || quickSteps) {//initQuickSteps
            self.showPayment(false);
        }
        else {
            self.showPayment(true);
        }
    }

    //#endregion



    //Julisy Amador
    self.showAmortizationTableTH = function () {
        var quotationNumber = self.parent.quotation();
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };

        if (quotationNumber != null) {
            $.getJSON("/PosAuto/ShowAmortizationTable", { quotationId: quotationNumber.id, LoanType: loanTypes[3], monto: Monto }, function (data) {
                if (!data.error) {
                    //window.open(data.reportName, '_blank');
                    showReport(data.reportName, null);
                }
            });
        }
    };

    self.enableCrditCardNumber = function () {
        $('#creditCardNumber').val('');
        ;
        var CardType = self.creditCardTypeId();
        if (CardType == null || CardType <= 0) {
            showError(["Debe seleccionar el tipo de tarjeta"], "Ver amortización");
            return false;
        }

        if (CardType != null && CardType > 0) {
            if (CardType == 2) {
                $('#creditCardNumber').inputmask('9999-999999-99999');
            } else {
                $('#creditCardNumber').inputmask('9999-9999-9999-9999');
            }
        }
        $('#creditCardNumber').removeAttr('disabled');
    }


    self.showAmortizationTableTH = function () {
        ;
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };

        var period = self.period();
        if (period == null || period <= 0) {
            showError(["Debe seleccionar la cantidad de meses del financiamiento"], "Ver amortización");
            return false;
        }

        if (Monto == null || Monto <= 0) {
            showError(["El monto del financiamiento debe ser mayor que cero, favor verificar"], "Ver amortización");
            return false;
        }

        self.getReporteAmortization(function (reportUrl) {
            window.open(reportUrl, '_blank');
        });
    };

    self.getReporteAmortization = function (callback) {
        var quotationNumber = self.parent.quotation();
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };
        var period = self.period();

        if (quotationNumber) {
            $.getJSON("/PosAuto/ShowAmortizationTable", { quotationId: quotationNumber.id, LoanType: loanTypes[3], monto: Monto, Period: period }, function (data) {
                if (!data.error) {
                    callback(data.reportName);
                }
                else {
                    showError([data.error], "Ver documento");
                }
            });
        }
        else
            showError(["La amortización no pudo ser generada"], "Ver documento");
    }

    self.getReporteFinancingAgreement = function (callback) {
        var quotationNumber = self.parent.quotation();
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };
        var period = self.period();

        if (quotationNumber) {
            $.getJSON("/PosAuto/ShowFinancingAgreement", { quotationId: quotationNumber.id, LoanType: loanTypes[3], monto: Monto, Period: period }, function (data) {
                if (!data.error) {
                    callback(data.reportName);
                }
                else {
                    showError([data.error], "Ver documento");
                }
            });
        }
        else
            showError(["El contrato no pudo ser generado"], "Ver documento");
    }

    self.showFinancingAgreementTH = function () {
        ;
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };

        var period = self.period();
        if (period == null || period <= 0) {
            showError(["Debe seleccionar la cantidad de meses del financiamiento"], "Ver Contrato");
            return false;
        }

        if (Monto == null || Monto <= 0) {
            showError(["El monto del financiamiento debe ser mayor que cero, favor verificar"], "Ver Contrato");
            return false;
        }

        self.getReporteFinancingAgreement(function (reportUrl) {
            window.open(reportUrl, '_blank');
        });
    };

    // Julisy Amador
    function MostrarContrato() {
        ;
        var Monto = self.totalIsc() + self.totalPrime();
        if (Monto != '') { Monto = Monto.toFixed(2) };

        var period = self.period();
        if (period == null || period <= 0) {
            showError(["Debe seleccionar la cantidad de meses del financiamiento"], "Ver Contrato");
            return false;
        }

        if (Monto == null || Monto <= 0) {
            showError(["El monto del financiamiento debe ser mayor que cero, favor verificar"], "Ver Contrato");
            return false;
        }

        self.getReporteFinancingAgreement(function (reportUrl) {
            window.open(reportUrl, '_blank');
        });

    }
    $(document).ready(function () {
        //Julisy Amador
        self.MunicipesByProvinces = ko.computed(function () {

            if (self.newDriver && self.newDriver.provinceId) {

                var newDriverProvince = self.newDriver.provinceId();

                if (newDriverProvince != undefined) {
                    $.ajax({
                        url: '/PoSAuto/GetMunicipalities',
                        data: { countryId: null, provinceID: newDriverProvince },
                        dataType: 'json',
                        async: false,
                        success: function (data) {
                            self.parent.Municipalities(data);
                        }
                    });
                }
            }

        });


        self.MunicipesByProvinces2 = ko.computed(function () {
            if (self.infoAdDriver() && self.infoAdDriver().provinceId()) {

                var infoDriverProvince = self.infoAdDriver().provinceId();

                $.ajax({
                    url: '/PoSAuto/GetMunicipalities',
                    data: { countryId: null, provinceID: infoDriverProvince },
                    dataType: 'json',
                    async: false,
                    success: function (data) {
                        self.parent.Municipalities(data);
                    }
                });
            }
        });

        self.SectorsByMunicipes = ko.computed(function () {
            if (self.newDriver && self.newDriver.municipalityId) {

                var newDriverProvince = self.newDriver.provinceId();
                var newDrivermunicipality = self.newDriver.municipalityId();

                if (newDrivermunicipality != undefined) {
                    $.ajax({
                        url: '/PoSAuto/GetCities',
                        data: { countryId: null, provinceID: newDriverProvince, municipalityID: newDrivermunicipality },
                        dataType: 'json',
                        async: false,
                        success: function (data) {
                            self.parent.cities(data);
                        }
                    });
                }
            }
        });

        self.SectorsByMunicipes2 = ko.computed(function () {
            if (self.infoAdDriver() && self.infoAdDriver().municipalityId()) {
                var infoDriverProvince = self.infoAdDriver().provinceId();
                var infoDrivermunicipality = self.infoAdDriver().municipalityId();

                $.ajax({
                    url: '/PoSAuto/GetCities',
                    data: { countryId: null, provinceID: infoDriverProvince, municipalityID: infoDrivermunicipality },
                    dataType: 'json',
                    async: false,
                    success: function (data) {
                        self.parent.cities(data);
                    }
                });
            }
        });

        self.GetFinancingMonths = ko.computed(function () {

            if (self.IsFinanced()) {
                ;
                var infoDriverIsFinanced = self.IsFinanced();
                if (infoDriverIsFinanced) {
                    $('#hdfIsFinanced').val('S');
                    $('#applicantWayToPay').attr('disabled', 'disabled');
                    $('#InstruccionContrato').css('display', 'block');

                    // Limpio la frecuencia de pago para solo dejarle los que pertenecen a financiamiento
                    self.payment.frequencyList([]);
                    self.payment.frequencyList.push({ id: 5, name: "Financiado a 5 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 6, name: "Financiado a 6 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 7, name: "Financiado a 7 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 8, name: "Financiado a 8 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 9, name: "Financiado a 9 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 10, name: "Financiado a 10 Cuotas", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 11, name: "Financiado a 11 Cuotas", discountPercentage: 0 });
                    //self.payment.frequencyList.push({ id: 12, name: "Financiado a 12 Cuotas", discountPercentage: 0 });



                    //self.parent.FinancingMonths(self.frequencyList());
                    //$.ajax({
                    //    url: '/PoSAuto/GetFinancingMonths',
                    //    data: {},
                    //    dataType: 'json',
                    //    async: false,
                    //    success: function (data) {
                    //self.parent.FinancingMonths(JSON.parse(data));
                    $('#row_financed').css('display', 'block');
                    $('#ViewAmortization').css('display', 'block');
                    $('#DatosFinanciamiento').css('display', 'block');
                    $('#DatosFinanciamiento2').css('display', 'block');
                    $('#ContratoFinanciamiento').css('display', 'block');
                    $('#IsDomiciliation').attr('disabled', 'disabled');
                    self.IsDomiciliation(true);
                    self.ActievateDomiciliation();
                    //    }
                    //});


                    //$.ajax({
                    //    url: '/PoSAuto/GetCreditCardTypes',
                    //    data: {},
                    //    dataType: 'json',
                    //    async: false,
                    //    success: function (data) {
                    //        self.parent.CreditCardTypes(JSON.parse(data));
                    //    }
                    //});

                } else {
                    $('#row_financed').css('display', 'none');
                    $('#ViewAmortization').css('display', 'none');
                    $('#DatosFinanciamiento').css('display', 'none');
                    $('#DatosFinanciamiento2').css('display', 'block');
                    $('#ContratoFinanciamiento').css('display', 'none');
                    self.period(ko.observable(0));
                    self.monthlyPayment(0);
                    self.creditCardNumber(undefined);
                    $('#hdfIsFinanced').val('N');
                    //$('#creditCardNumber').removeAttr('disabled');
                    $('#applicantWayToPay').removeAttr('disabled');
                    $('#InstruccionContrato').css('display', 'none');
                    self.payment.frequencyList([]);
                    self.payment.frequencyList.push({ id: 0, name: "Pago Único (5% de Descuento)", discountPercentage: 5 });
                    self.payment.frequencyList.push({ id: 1, name: "Inicial + 1 Cuota", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 2, name: "Inicial + 2 Cuota", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 3, name: "Inicial + 3 Cuota ", discountPercentage: 0 });
                    self.payment.frequencyList.push({ id: 4, name: "Inicial + 4 Cuota", discountPercentage: 0 });
                    $('#IsDomiciliation').removeAttr('disabled');
                    self.IsDomiciliation(true);
                    self.ActievateDomiciliation();
                    self.infoAdDriver().HomeOwner(false);
                    //self.infoAdDriver().QtyPersonsDepend(ko.observable());
                    //self.infoAdDriver().QtyEmployees(ko.observable());
                    //self.infoAdDriver().Fax(ko.observable());
                    //self.infoAdDriver().URL(ko.observable());

                    //self.newDriver.HomeOwner(false);
                    //self.newDriver.QtyPersonsDepend(0);
                    //self.newDriver.QtyEmployees(0);
                    //self.newDriver.Fax(ko.observable());
                    //self.newDriver.URL(ko.observable());

                }
            } else {
                $('#row_financed').css('display', 'none');
                $('#ViewAmortization').css('display', 'none');
                $('#ContratoFinanciamiento').css('display', 'none');
                self.monthlyPayment(0);
                self.expirationDateYear(undefined);
                self.expirationDateMonth(undefined);
                self.creditCardNumber(undefined);
                self.cardHolder(undefined);
                self.creditCardTypeId(undefined)
                self.period(undefined)

                self.amortizationTable([]);
                $('#DatosFinanciamiento').css('display', 'none');
                $('#DatosFinanciamiento2').css('display', 'block');
                $('#creditCardNumber').removeAttr('disabled');
                self.creditCardNumber(undefined);
                $('#hdfIsFinanced').val('N');
                //$('#creditCardNumber').removeAttr('disabled');
                $('#applicantWayToPay').removeAttr('disabled');
                $('#InstruccionContrato').css('display', 'none');
                self.payment.frequencyList([]);
                self.payment.frequencyList.push({ id: 0, name: "Pago Único (5% de Descuento)", discountPercentage: 5 });
                self.payment.frequencyList.push({ id: 1, name: "Inicial + 1 Cuota", discountPercentage: 0 });
                self.payment.frequencyList.push({ id: 2, name: "Inicial + 2 Cuota", discountPercentage: 0 });
                self.payment.frequencyList.push({ id: 3, name: "Inicial + 3 Cuota ", discountPercentage: 0 });
                self.payment.frequencyList.push({ id: 4, name: "Inicial + 4 Cuota", discountPercentage: 0 });
                $('#IsDomiciliation').removeAttr('disabled');
                self.IsDomiciliation(true);

                //self.infoAdDriver().HomeOwner(ko.observable(false));
                //self.infoAdDriver().QtyPersonsDepend(ko.observable());
                //self.infoAdDriver().QtyEmployees(ko.observable());
                //self.infoAdDriver().Fax(ko.observable());
                //self.infoAdDriver().URL(ko.observable());
                //self.infoAdDriver().segment(ko.observable());
                //self.infoAdDriver().Linked(ko.observable());

                //self.newDriver.HomeOwner(false);
                //self.newDriver.QtyPersonsDepend(ko.observable());
                //self.newDriver.QtyEmployees(ko.observable());
                //self.newDriver.Fax(ko.observable());
                //self.newDriver.URL(ko.observable());
                //self.newDriver.segment(ko.observable());
                //self.newDriver.Linked(ko.observable());
                //$('#creditCardTypeId').val(0);
            }
        });

        self.GetPaymentMonths = ko.computed(function () {
            if (self.period()) {
                var monto = self.totalIsc() + self.totalPrime();
                if (monto != '') { monto = monto.toFixed(2) };

                var periodo = parseInt(self.period());
                if (periodo > 0) {
                    //self.applicantWayToPay(periodo);
                    self.payment.applicant.frequency(periodo);
                    $.ajax({
                        url: '/PoSAuto/GetPaymentMonths',
                        data: { Amount: monto, periodoId: periodo, loanType: loanTypes[3] },
                        dataType: 'json',
                        async: false,
                        success: function (data) {
                            self.amortizationTable([]);
                            self.amortizationTable(data);
                            $.each(data, function (i, item) {
                                self.monthlyPayment(item.Payment);

                                //recorro la tabla de amortizacion que devuelve el servicio para desplegarla
                                //self.amortizationTable.push({
                                //                                periodNumber: item.PeriodNumber,
                                //                                balance: FormatearMonto(item.Balance),
                                //                                date: item.Date,
                                //                                interest: FormatearMonto(item.Interest),
                                //                                payment: FormatearMonto(item.Payment),
                                //                                principal: FormatearMonto(item.Principal),
                                //                                previousBalance: FormatearMonto(item.PreviousBalance)
                                //                            });

                            });
                        }
                    });
                } else {
                    self.monthlyPayment(0)
                }
            } else {
                self.monthlyPayment(0)
            }
        });

        self.GetExpirationYeaMonths = ko.computed(function () {
            if (self.expirationDateYear()) {
                var actualDate = new Date();
                var ActualMonth = actualDate.getMonth() + 1;
                var ActualYear = actualDate.getFullYear();

                var year = self.expirationDateYear();
                self.parent.yearMonths([]);
                var InitialMonth = 1;
                if (year == ActualYear) {
                    InitialMonth = ActualMonth;
                }
                for (i = InitialMonth; i <= 12; i++) {
                    self.parent.yearMonths.push({ expirationDateMonth: i, name: i.toString() });
                }
            }
        });
        //$('#creditCardNumber').inputmask('9999-9999');
        self.GetMaskCreditCardType = ko.computed(function () {
            if (self.creditCardTypeId()) {
                var CardType = self.creditCardTypeId();
                if (CardType != null && CardType > 0) {
                    $('#creditCardNumber').val('');
                    if (CardType == 2) {
                        $('#creditCardNumber').inputmask('9999-999999-99999');
                        $('#creditCardNumber').removeAttr('disabled');
                    } else {
                        $('#creditCardNumber').inputmask('9999-9999-9999-9999');
                        $('#creditCardNumber').removeAttr('disabled');
                    }
                }
            }
        });

        self.ActievateDomiciliation = ko.computed(function () {
            if (self.IsDomiciliation()) {

                var domiciled = self.IsDomiciliation();
                if (domiciled) {
                    $('#creditCardTypeId').removeAttr('disabled');
                    $('#creditCardNumber').removeAttr('disabled');
                    $('#editCreditCard').removeAttr('disabled');
                    $('#expirationDateYear').removeAttr('disabled');
                    $('#expirationDateMonth').removeAttr('disabled');
                    $('#cardHolder').removeAttr('disabled');

                    if (!self.IsFinanced()) {
                        $('#DomicileInitialPayment').removeAttr('disabled');
                    }
                    else {
                        $('#DomicileInitialPayment').attr('disabled', 'disabled');
                        $('#DomicileInitialPayment').prop('checked', false);
                    }

                }
                else {
                    $('#creditCardTypeId').attr('disabled', 'disabled');
                    $('#creditCardNumber').attr('disabled', 'disabled');
                    $('#editCreditCard').attr('disabled', 'disabled');
                    $('#expirationDateYear').attr('disabled', 'disabled');
                    $('#expirationDateMonth').attr('disabled', 'disabled');
                    $('#cardHolder').attr('disabled', 'disabled');
                    $('#DomicileInitialPayment').attr('disabled', 'disabled');
                    $('#DomicileInitialPayment').prop('checked', false);
                }
            } else {
                $('#creditCardTypeId').attr('disabled', 'disabled');
                $('#creditCardNumber').attr('disabled', 'disabled');
                $('#editCreditCard').attr('disabled', 'disabled');
                $('#expirationDateYear').attr('disabled', 'disabled');
                $('#expirationDateMonth').attr('disabled', 'disabled');
                $('#cardHolder').attr('disabled', 'disabled');
                $('#DomicileInitialPayment').attr('disabled', 'disabled');
                $('#DomicileInitialPayment').prop('checked', false);
            }
        });


        self.ChangeValueMonthlyPayment = ko.computed(function () {
            if (self.monthlyPayment()) {
                $('.montoMesual').html('$' + FormatearMonto(self.monthlyPayment()));
            } else {
                $('.montoMesual').html(0);
            }
        });


        self.setEndDateSubscriptionStatus(true);

        self.currentStartDateSelected(moment(new Date()).format(getCurrentDateTimeMomentFormat()));

        self.initSteps();

        $("#addDriverForm").validate(new driverViewModel(new Date()).validationRules);
        $("#saveVehicleForm").validate(new vehicleViewModel().validationRules);

        $("#setAditionalDriverInfoForm").validate(new driverViewModel().validationRules);
        $("#setAditionalVehicleInfoForm").validate(new vehicleViewModel().validationRules);
        $("#payForm").validate(self.payment.validationRules);

        $("#beneficiaryfinalForm").validate(new finalBeneficiaryViewModel().validationRules);
        $("#PepForm").validate(new pepViewModel().validationRules);

        $('#startDate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('.datepicker.dateOfBirth').datepicker({
            changeMonth: true,
            changeYear: true,
            //yearRange: "-100:+0" //100 Years Limit
            yearRange: "-80:+0"//80 Years Limit
        });

        //$.ajax({
        //    url: '/PoSAuto/GetPolicyVigencyDays',
        //    dataType: 'json',
        //    async: isNewQ,
        //    success: function (data) {
        //        self.maxDatePolicyVigency('+' + data);
        //    }
        //});


        $('.datepicker.effectivedate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('#effectivedate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('.datepicker.effectivedateend').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('#effectivedateend').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        $('.datepicker.IdentificationNumberValidDate').datepicker({
            changeMonth: true,
            changeYear: true,
            //yearRange: "-100:+0" //100 Years Limit
            yearRange: "-0:+10"
        });

        //Julisy Amador
        $('#expirationDate').datepicker({
            changeMonth: true,
            changeYear: true,
            minDate: new Date()
        });

        self.getMinAgeForBirthDate(function (value) {
            $('.dateOfBirth').datepicker("option", "maxDate", new Date(value));
        });

        self.setEndDateDatepickerStatus(false);
        self.setEndDateSubscriptionStatus(true);

        //#region [List-initialization methods]

        var isNewQ = $('#loadQuotationId').val() == undefined; //Si se va a cargar una cotización guardada, debe ser sincronico

        $.ajax({
            url: '/PoSAuto/GetVehicleAvailableYearsList',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.currentYear(data.currentYear);
                self.vehicleAvailableYears(data.yearList);
            }
        });

        $.ajax({
            //url: '/PoSAuto/GetVehicleBrands',//DESCOMENTAR SYSFLEX VIEJO
            url: '/PoSAuto/GetVehicleBrands_New',
            dataType: 'json',
            async: isNewQ,
            success: function (data) { self.vehicleBrandList(data); }
        });

        $.ajax({
            url: '/PoSAuto/GetStoreStates',
            dataType: 'json',
            async: isNewQ,
            success: function (data) { self.storeList(data); }
        });

        //#endregion

        $.getJSON('/PoSAuto/GetCurrentIsc', function (data) {
            if (self.payment)
                self.payment.iscPercentage(data.isc);
        });

        /*Jheiron Dotel 15-09-2016*/
        $.ajax({
            url: '/PoSAuto/GetSurchargePercentage',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.surchargePercentList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetMinAllowedAmountToPay',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.GetMinAllowedAmountToPayPercent(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetNotifyMessagingAgent',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.NotifyMessagingAgent(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetQtyYearsBack0KmVip',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.QtyYearsBack0KmVip(data);
            }
        });


        $.getJSON('/PoSAuto/GetAgents', function (data) {
            ko.utils.arrayForEach(data.agents, function (item) {
                item.Name = item.FullNameAll.trim();
            });

            self.parent.agentList(data.agents);

            if (self.parent.quotation()) //Selecciona el agente del suscriptor
            {
                //console.log("Entre al IF");
                //console.log(data.agent);
                self.parent.agent(ko.utils.arrayFirst(data.agents, function (item) { return item.NameId === self.parent.quotation().user }));

                //console.log(self.parent.quotation());
                //console.log("Soy el objeto self.parent.agent() : " + self.parent.agent());
                //console.log("Entre al IF - self.parent");
                //console.log(self.parent.agent());
            }
            else if (data.agents.length === 1) //Agente logueado
            {
                self.parent.agent(data.agents[0]);

                //console.log("Entre al ELSE");
                //console.log(data.agents[0]);
            }
            //console.log("FUERA DE TODO");
            //console.log(data.agents);
        });



        $.ajax({
            url: '/PoSAuto/GetRncCedulaValidation',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.urlValidationCedulaRnc(data);
            }
        });


        $.ajax({
            url: '/PoSAuto/GetRncCedulaValidationShow',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.urlValidationCedulaRncShow(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/ShowSelectInvoiceType',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {

                if (data == 0) {
                    self.showSelectOptionInvoiceType(false);
                } else if (data == 1) {
                    self.showSelectOptionInvoiceType(true);
                }
            }
        });


        $.ajax({
            url: '/PoSAuto/GetPepOptions',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.PepOptionsList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetSocialReason',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.SocialReasonList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetOwnerShipStructure',
            dataType: 'json',
            async: isNewQ,
            success: function (data) {
                self.OwnerShipStructureList(data);
            }
        });

        $.ajax({
            url: '/PoSAuto/GetCreditCardTypes',
            data: {},
            dataType: 'json',
            async: false,
            success: function (data) {
                self.parent.CreditCardTypes(JSON.parse(data));
            }
        });

        //$.ajax({
        //    url: '/PoSAuto/GetEconomicActivities',
        //    data: {},
        //    dataType: 'json',
        //    async: false,
        //    success: function (data) {
        //        self.EconomicActivities([]);
        //        var datos = JSON.parse(data);

        //        $.each(datos, function (item) {
        //            self.EconomicActivities.push({
        //                segment: item.Code,
        //                name: item.Description
        //            });
        //        });                              
        //    }
        //});

        $.ajax({
            url: '/PoSAuto/GetYearList',
            dataType: 'json',
            async: false,
            success: function (data) {
                self.parent.yearListCreditCard([]);
                $.each(data, function (i, item) {
                    self.parent.yearListCreditCard.push({ expirationDateYear: item.Id, Name: item.Name });
                });

            }
        });

        //$.ajax({
        //    url: '/PoSAuto/getParameterTotalPremium',
        //    dataType: 'json',
        //    async: false,
        //    success: function (data) {
        //        $('#ParameterTotalPremium').val(data);
        //    }
        //});

        $(window).on('unload', function () {
            var commingfromUnload = true;

            self.saveQuotation(true, false, commingfromUnload);
        });

        self.parent.sideViewCustom("sideViewCustom");

        $("#cedMask").change(function () {
            var $this = $(this);
            self.whatMask($this.val());
        });

        activateDatePickers();


        $('#dateOfBirth').datepicker().on("change", function (e) {
            var dateOfBirth = $("#dateOfBirth").val();
            if (dateOfBirth != undefined && dateOfBirth != "") {

                if (IsPrincipalClient()) {
                    self.changedDateBirthFirst(true);

                    $("#NewdateOfBirth").val(dateOfBirth);
                    return true;
                }
            }
            self.changedDateBirthFirst(false);
            return false;
        });

        $('#clientSex').on("change", function (e) {
            var optionSelected = $(this);

            if (optionSelected.val() !== "") {

                if (IsPrincipalClient()) {

                    var ident = $('#identificationType').val();
                    var sel = optionSelected.val();

                    if (ident === "RNC") {
                        sel = "Empresa";
                    }

                    $("#NewclientSex").val(sel);

                    self.changedClientSexFirst(true);
                    return true;
                }
            }

            self.changedClientSexFirst(false);
        });

        $('#ForeingLicence').on("change", function (e) {
            var optionSelected = $(this);

            if (optionSelected.val() !== "") {

                if (IsPrincipalClient()) {
                    self.changedForeingLicenceFirst(true);

                    $("#NewForeingLicence").val(optionSelected.val());
                    return true;
                }
            }
            self.changedForeingLicenceFirst(false);
        });
    });

    function dialogRncCedula(nodoc) {
        if (nodoc != "") {
            nodoc = nodoc.replace("-", "").replace("-", "").replace("-", "");
            //var url = "http://www.dgii.gov.do/app/WebApps/Consultas/rnc/RncWeb.aspx?__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE=%2FwEPDwUKMTY4ODczNzk2OA9kFgICAQ9kFgQCAQ8QZGQWAWZkAg0PZBYCAgMPPCsACwBkZHTpAYYQQIXs%2FJET7TFTjBqu3SYU&__EVENTVALIDATION=%2FwEWBgKl57TuAgKT04WJBAKM04WJBAKDvK%2FnCAKjwtmSBALGtP74CtBj1Z9nVylTy4C9Okzc2CBMDFcB&rbtnlTipoBusqueda=0&txtRncCed=nodoc&btnBuscaRncCed=Buscar";
            //var options = "location=no,width=600,height=300,scrollbars=yes,top=100,left=700,resizable = no";
            //window.open(url.replace("nodoc", nodoc), "Rnc Cedula Check", options);

            var url = self.urlValidationCedulaRnc();

            $("#docIframe").attr('src', url.replace("{0}", nodoc));
            $('.docValidate').show();
        } else {
            $('.docValidate').hide();
        }
    }

    function getRuleLessThan() {
        return {
            lessThan: $('#fromYear').val().length
        };
    }

    function getRuleBiggerThan() {
        return {
            biggerThan: $('#toYear').val().length
        };
    }

    function ValidPepOrBF() {
        var currentStepId = self.parent.currentStepId();
        var valid = true;
        var msj = "";

        if (currentStepId == 4) {

            //Preguntar aqui si el formulario pep o el formulario de beneficiario esta completo
            if (self.PepOptionsList() && self.infoAdDriver().PepFormularyOptionsId()) {
                var idfibeOption = _.find(self.PepOptionsList(), function (item) { return item.id == self.infoAdDriver().PepFormularyOptionsId(); });
                if (idfibeOption.allowed == true) {

                    if (self.PEP().length > 0) {
                        var incompletes = _.filter(self.PEP(), function (item) { return !item.pepDataComplete(); });
                        if (incompletes.length > 0) {
                            msj = 'Debe completar los datos de los PEP indicados en rojo. Debe corregir dichos errores para poder continuar.'
                            valid = false;
                        }
                    }
                }
            }

            if (self.IdentificationFinalBeneficiaryOptionsList() && self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId()) {
                var idfibeOption = _.find(self.IdentificationFinalBeneficiaryOptionsList(), function (item) { return item.id == self.infoAdDriver().IdentificationFinalBeneficiaryOptionsId(); });
                if (idfibeOption.allowed == true) {

                    if (self.FinalBeneficiary().length > 0) {
                        var incompletes = _.filter(self.FinalBeneficiary(), function (item) { return !item.finalBeneficiaryDataComplete(); });
                        if (incompletes.length > 0) {
                            msj = 'Debe completar los datos de los Beneficiarios Finales indicados en rojo. Debe corregir dichos errores para poder continuar.'
                            valid = false;
                        }
                    }
                }
            }
        }

        return valid + "|" + msj;
    }

    function activateDatePickers() {
        //$('#date').datepicker('option', 'minDate', new Date(startDate));
        //$('#date').datepicker('option', 'maxDate', new Date(endDate));

        $("#effectivedate").change(function () {
            var $this = $(this);
            var makeDate = getCorrectDateFormat($this.val());

            var neDat = $.datepicker.formatDate(getCurrentDateFormat(), moment(makeDate).toDate());
            var neDatMax = getNewDateYear(makeDate);

            $('#effectivedateend').datepicker('option', 'minDate', neDat);
            $('#effectivedateend').datepicker('option', 'maxDate', neDatMax);//Un Ano a partir de la Fecha Seleccionada

            var startDate = moment(neDat, getCurrentDateTimeMomentFormat());
            var endDate = moment(startDate).add(12, 'months').startOf('day');

            self.effectiveDateEnd($.datepicker.formatDate(getCurrentDateFormat(), moment(endDate).toDate()));
            self.changeDate(true);
        });

        $("#effectivedateend").change(function () {
            var $this = $(this);
            var makeDate = getCorrectDateFormat($this.val());

            var neDat = $.datepicker.formatDate(getCurrentDateFormat(), moment(makeDate).toDate());
            $('#effectivedate').datepicker('option', 'maxDate', neDat);
            self.changeDate(true);
        });
    }

    function getNewDateYear(date) {
        var result = new Date(date);
        var yearOnDays = 365;
        result.setDate(result.getDate() + yearOnDays);
        return result;
    }

    function getAbrevMonthOfDate(montAbrev) {

        var monthNamesEn = ["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"];
        var monthNamesEs = ["ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic"];

        if (monthNamesEs.indexOf(montAbrev.replace('.', '')) != -1) {
            return monthNamesEn[monthNamesEs.indexOf(montAbrev)]
        }
        return "";
    }

    function getCorrectDateFormat(value) {
        var makeDate = "";

        if (value !== "") {

            var spl = value.replace('.', '').split('-');
            if (spl.length > 1) {
                var monthEsPosition = getAbrevMonthOfDate(spl[1]);
                makeDate = monthEsPosition + '/' + spl[0] + '/' + spl[2];
            }
        }
        return makeDate;
    }

    function isValidTheDocument() {
        var currentStepId = self.parent.currentStepId();
        var pass = false;

        if (currentStepId == 4) {

            if (self.infoAdDriver() && self.infoAdDriver().identificationType() && self.infoAdDriver().license()) {

                var DocumentType = self.infoAdDriver().identificationType();
                var Number = self.infoAdDriver().license();
                var messageError = "";

                if (DocumentType == 'Cédula') {
                    DocumentType = 'Cedula';
                }
                else if (DocumentType == 'RNC') {
                    DocumentType = 'Rnc';
                }

                var noQuot = "";

                if (self.parent.quotation() && self.parent.quotation().quotationNumber) {
                    noQuot = self.parent.quotation().quotationNumber;
                }

                $.ajax({
                    url: '/PoSAuto/DocumentValidator',
                    data: { Number: Number, DocumentType: DocumentType, noQuot: noQuot },
                    dataType: 'json',
                    async: false,
                    success: function (data) {

                        if (data === true) {

                            $("#continueToVehicle").removeAttr("disabled");
                            $("#license").removeClass("errorBorder");
                            self.documetInvalid(false);


                            pass = true;
                        }
                        else {
                            messageError = "El Número de Identificación '" + Number + "' no es valido, por favor verifique.";
                            //$("#continueToVehicle").attr("disabled", "disabled");
                            $("#license").addClass("errorBorder");
                            self.documetInvalid(true);

                            showError([messageError], 'Validando Número de Identificación');
                            pass = false;
                        }
                    }
                });
            }
        }
        return pass;
    }

    function IsPrincipalClient() {
        return $("#prinTJ").is(":checked");
    };

    //Julisy Amador 2017-10-18
    function FormatearMonto(valor) {
        return valor.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")
    }

    $('#editCreditCard').click(function () {
        ;
        $('#creditCardNumber').removeAttr('disabled');
    });


};