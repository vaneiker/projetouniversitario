﻿function vehicleViewModel(autovm) {
    var self = this;

    //This method helps serialization to get the exact info
    self.toJSON = function () {

        var mapping = {
            ignore: ['parent',
                '__ko_mapping__',
                'modelList',
                'parent',
                'validationRules',
                'productsList',
                'brandSubscribe',
                'modelSubscribe',
                'brandSubscribe',
                'modelSubscribe',
                'yearSubscribe',
                'selectedCoverageSubscribe',
                'vehiclePriceSubscribe',
                'selectedDeductibleSubscribe',
                'selectedSurchargePercentSubscribe',
                'selectedusageSubscribe',
                'VehicleQuantitySubscribe',
                'storeSubscribe']
        };

        var copy = ko.mapping.toJS(self, mapping); // ko.toJS(self);

        return copy;
    };

    self.coverageDetailMapping = {
        'Amount': {
            create: function (options) {
                //return ko.observable(options.data).money();//DESCOMENTAR SYSFLEX VIEJO
                if (options != null) {
                    return ko.observable(options.data).money();
                } else { return ko.observable(0).money(); }
            }
        }
    }

    self.selectedVehicleTypeName = ko.computed(function () {
        if (self.selectedVehicleType && self.selectedVehicleType())
            return self.selectedVehicleType().Name;
        else
            return '';
    });

    self.selectedVehicleTypeNameStatic = ko.observable();
    self.selectedVehicleToStringStatic = ko.observable();
    self.selectedVehicleBrandNameStatic = ko.observable();
    self.selectedVehicleModelNameStatic = ko.observable();
    self.selectedVehicleYearStatic = ko.observable();

    self.servicesDetailMapping = {
        'Coverages': {
            create: function (options) {
                return ko.observableArray(options.data);
            }
        }
    }

    self.productLimitMapping = {
        'IsSelected': {
            create: function (options) {
                return ko.observable(options.data);
            }
        },
        'deducibles': {
            create: function (options) {
                return ko.observable(options.data);
            }
        },
        'TpPrime': {
            create: function (options) {
                return ko.observable(options.data).money();
            }
        },
        'SdPrime': {
            create: function (options) {
                return ko.observable(options.data).money();
            }
        },
        'ServicesPrime': {
            create: function (options) {
                return ko.observable(options.data).money();
            }
        },
        'ServicesCoverages': {
            create: function (options) {
                var vm = ko.mapping.fromJS(options.data, self.coverageDetailMapping);
                return vm;
            }
        },
        'ThirdPartyCoverages': {
            create: function (options) {
                var vm = ko.mapping.fromJS(options.data, self.coverageDetailMapping);
                return vm;
            }
        },
        'SelfDamagesCoverages': {
            create: function (options) {
                var vm = ko.mapping.fromJS(options.data, self.coverageDetailMapping);
                return vm;
            }
        }
    }

    self.id = ko.observable(-1 * Math.floor((Math.random() * 10000) + 1));

    self.clear = function () {
        self.brand(0);
        self.model(null);
        self.year(0);
        self.cylinders(0);
        self.weight(0);
        self.passengers(0);
        self.usage(0);
        self.store(0);
        self.driver(null);
        self.chassis('');
        self.color('');
        self.plate('');
        self.SecuenciaVehicleSysflex(0);
        self.productLimitSet(null);
        self.primesRetrieved(false);
        self.selectedSurchargePercent(0);
        self.NumeroFormulario('');
        self.rateJson('');
        self.selectedVehicleYearsOld(null);
        self.flagVehicleToDelete(false);
        self.IsFacultative(false);
        self.AmountFacultative(0);
        self.VehicleQuantity = ko.observable(1).extend({ numeric: 0 });
    }

    // STEP 2
    self.parent = autovm;

    self.brand = ko.observable(-1);

    self.brandName = ko.computed(function () {

        if (self.parent && self.brand() && self.parent.vehicleBrandList() && self.parent.vehicleBrandList().length > 0) {
            var brand = _.find(self.parent.vehicleBrandList(), function (item) { return item.id == self.brand(); });
            if (brand)
                return brand.name;
            else
                return "";
        }
        else
            return "";
    });

    self.modelList = ko.observableArray([]);
    self.model = ko.observable(-1);

    self.modelName = ko.computed(function () {

        if (self.parent && self.model && self.model() && self.modelList() && self.modelList().length > 0) {
            var model = _.find(self.modelList(), function (item) { return item.id == self.model(); });
            if (model)
                return model.name;
            else
                return "";
        }
        else
            return "";
    });

    self.selectedVehicleYearsOld = ko.observable();
    self.isFirstLoading = ko.observable(false);

    self.year = ko.observable();
    self.cylinders = ko.observable().extend({ numericRange: [0, 255] });
    self.weight = ko.observable().extend({ numericRange: [0, 2147483647] });
    self.passengers = ko.observable().extend({ numericRange: [0, 65535] });
    self.usage = ko.observable(-1);
    self.usageName = ko.observable('');
    self.store = ko.observable(-1);
    self.driver = ko.observable();

    self.SecuenciaVehicleSysflex = ko.observable();
    self.IsFacultative = ko.observable();
    self.AmountFacultative = ko.observable();
    self.VehicleQuantity = ko.observable(1).extend({ numeric: 1 });

    self.NotFirstLoading = ko.observable(true);


    self.popupSelectedServices = ko.observableArray();
    self.popupServices = ko.observableArray();
    self.popupAnnualTotal = ko.observable().money();
    self.popupCalculateAnnualTotal = function () {
        var total = 0;

        _.each(self.popupSelectedServices(), function (item) {
            var service = _.find(self.productLimitSet().ServicesCoverages(), function (sc) { return sc.Name() == item.id });
            if (service) {
                var selectedCoverage = _.find(service.Coverages(), function (cov) { return cov.Id() == item.value(); });
                if (selectedCoverage) {
                    total += selectedCoverage.Amount();
                }
            }

        });

        self.popupAnnualTotal(total);
    };


    //STEP 3
    self.vehiclePrice = ko.observable(0).money();

    //Aqui se declara    
    self.selectedSurchargePercent = ko.observable();

    self.isNotUsageValid = ko.computed(function () {
        if (self.usage() > 0) {

            var UsageFound = _.find(self.UsagesListByVehicleType(), function (item) { return item.idUso == self.usage(); });
            if (UsageFound) {

                var allowed = UsageFound.allowed;
                var message = UsageFound.message;
                var UsageInvalidMessageShow = self.parent.getLastStep();

                self.usageName(UsageFound.descUso);

                if (allowed == 2) {
                    //mensaje error
                    if (UsageInvalidMessageShow == false) {
                        showError([message], 'Uso Principal');
                    } else {
                        //$(".popupError").hide();
                    }
                    $("#UsageInvalid").val("True");

                } else if (allowed == 3) {
                    //mensaje advertencia
                    if (UsageInvalidMessageShow == false) {
                        showWarning([message], 'Uso Principal');
                    } else if (UsageInvalidMessageShow == true) {
                        $(".popupWarning").hide();
                    }
                    $("#UsageInvalid").val("False");
                } else {
                    $("#UsageInvalid").val("False");
                }
            }
        }
        //}
    });

    self.remove0kmIfIsNotNew = ko.computed(function () {
        if (self.parent && self.parent.vehicleYearsOldList() && self.selectedVehicleYearsOld()) {

            //if (self.currentProducts().length > 0) {//El que estaba 04-08-2017
            if (self.ProductListByUsages().length > 0) {

                //var prods = _.find(self.currentProducts(), function (item) { return item.Name.indexOf('0 KM') != -1 });//El que estaba 04-08-2017
                var prods = _.find(self.ProductListByUsages(), function (item) { return item.Name.indexOf('0 KM') != -1 });

                if (prods) {

                    var exit = false;

                    if (self.selectedVehicleYearsOld() == "Usado") {
                        $("#ddlAllProducts option").each(function () {
                            var t = this;

                            if (t.text.indexOf('0 KM') != -1) {
                                var index = t.index;
                                document.getElementById("ddlAllProducts").options[index].disabled = true;
                                exit = true;
                            }

                            if (exit) {
                                return false;
                            }
                        });
                    }
                    else {

                        $("#ddlAllProducts option").each(function () {
                            var t = this;
                            //"0 KM (FULL)"                       
                            if (t.text.indexOf('0 KM') != -1) {
                                var index = t.index;
                                document.getElementById("ddlAllProducts").options[index].disabled = false;
                                exit = true;
                            }

                            if (exit) {
                                return false;
                            }
                        });
                    }

                } else {

                    $("#ddlAllProducts option").each(function () {
                        var t = this;
                        //"0 KM (FULL)"                       
                        if (t.text.indexOf('0 KM') != -1) {
                            var index = t.index;
                            document.getElementById("ddlAllProducts").options[index].disabled = false;
                            exit = true;
                        }

                        if (exit) {
                            return false;
                        }
                    });
                }
            }
        }
    });


    self.percentageToInsure = ko.observable(100);
    self.porcImpuesto = ko.observable(16);

    self.idCapacidad = ko.observable();
    self.DescCapacidad = ko.observable();

    self.insuredAmount = ko.computed(function () {
        if (self.vehiclePrice() && self.percentageToInsure())
            return self.vehiclePrice() * (self.percentageToInsure() / 100);
        else
            return 0;
    }).money();
    self.percentageToInsureList = ko.observable();

    self.vehicleTypeList = ko.observableArray();
    self.deductibleList = ko.observableArray();

    //Vehicle type
    self.selectedVehicleType = ko.observable();
    self.selectedVehicleTypeId = ko.observable();
    self.currentProducts = ko.computed(function () {
        if (self.selectedVehicleType() && self.selectedVehicleType().Products)
            return self.selectedVehicleType().Products;
        else
            return [];
    });

    self.SetIdCapacidad = ko.computed(function () {
        //self.vehicleTypeList().length > 0 && 
        if (self.selectedVehicleType() && self.selectedVehicleType().Products && self.selectedProduct()) {

            var pr = self.selectedProduct();

            if (pr != null) {
                self.idCapacidad(pr.IdCapacidad);
            } else {
                self.idCapacidad(0);
            }
        }
        else {
            self.idCapacidad(0);
        }
    });

    self.SetDescCapacidad = ko.computed(function () {
        if (self.selectedVehicleType() && self.selectedVehicleType().Products && self.selectedProduct()) {
            var pr = self.selectedProduct();

            if (pr != null) {
                self.DescCapacidad(pr.DescCapacidad);
            }
            else {
                self.DescCapacidad("");
            }
        } else {
            self.DescCapacidad("");
        }
    });

    self.UsagesListByVehicleType = ko.computed(function () {

        if (self.selectedVehicleType()) {
            if (self.selectedVehicleType().NewUsages) {

                var usagebytype = self.selectedVehicleType().NewUsages;

                $.ajax({
                    url: '/PoSAuto/GetUsageStates_New',
                    dataType: 'json',
                    async: false,
                    success: function (data) {

                        _.each(data, function (us) {
                            var obj = {
                                idUso: us.id,
                                descUso: us.name,
                                allowed: us.allowed,
                                message: us.message
                            }

                            usagebytype.push(obj);
                        });
                    }
                });

                return usagebytype;
            }
        }
        return [];

    });

    self.NewCurrentProductList = ko.observableArray([]);

    self.NewCurrentCoveragesProductList = ko.observableArray([]);

    self.ProductListByUsages = ko.computed(function () {

        if (self.selectedVehicleType()) {
            if (self.selectedVehicleType().ProductByUsages) {

                if (self.usage()) {

                    var UsageFound = _.find(self.UsagesListByVehicleType(), function (item) { return item.idUso == self.usage(); });
                    if (UsageFound) {

                        var AllProductListByUsages = self.selectedVehicleType().ProductByUsages;

                        var FilteredProductList = _.filter(AllProductListByUsages, function (item) { return item.UsoDescripcion.indexOf(UsageFound.descUso) != -1 });

                        if (FilteredProductList != undefined && FilteredProductList != null && FilteredProductList != "") {

                            self.NewCurrentProductList([]);

                            _.each(FilteredProductList, function (plist) {
                                var prodsNews = _.find(self.currentProducts(), function (currProd) { return currProd.Name.indexOf(plist.ProductoDescripcion) != -1 });

                                if (prodsNews != undefined) {
                                    self.NewCurrentProductList.push(prodsNews);
                                }
                            });

                            return self.NewCurrentProductList();
                        }
                    }
                }
            }
        }

        return [];
    });

    //Product
    self.selectedProduct = ko.observable();
    /*self.currentCoverages = ko.computed(function () {
        if (self.selectedProduct() && self.selectedVehicleType().Coverages)
            return self.selectedProduct().Coverages;
        else
            return [];
    });*/

    //Coverage
    self.selectedCoverage = ko.observable();

    self.currentCoveragesByUsage = ko.computed(function () {

        if (self.selectedProduct() && self.selectedVehicleType()) {

            if (self.selectedVehicleType().CoveragesByUsages) {

                if (self.usage()) {

                    var UsageFound = _.find(self.UsagesListByVehicleType(), function (item) { return item.idUso == self.usage(); });
                    if (UsageFound) {

                        var AllCoveragesListByUsages = self.selectedVehicleType().CoveragesByUsages;
                        self.NewCurrentCoveragesProductList([]);

                        var FilteredCovList = _.filter(AllCoveragesListByUsages, function (item) { return item.UsoDescripcion.indexOf(UsageFound.descUso) != -1 && item.ProductName == self.selectedProduct().Name });
                        self.NewCurrentCoveragesProductList(FilteredCovList);


                        return self.NewCurrentCoveragesProductList();
                    }
                }
            }
        }
        self.NewCurrentCoveragesProductList([]);
        return [];
    });





    //Deducible
    self.selectedDeductible = ko.observable();

    self.productLimitSet = ko.observable();
    self.primesRetrieved = ko.observable(false);

    //STEP 5
    self.chassis = ko.observable();
    self.plate = ko.observable();
    self.color = ko.observable();

    self.NumeroFormulario = ko.observable();
    self.rateJson = ko.observable();
    self.flagVehicleToDelete = ko.observable(false);

    self.showRechargeAllLawProducts = function () {

        if (self.selectedCoverage()) {

            var prod = self.selectedCoverage();

            if (prod) {
                var whatis = prod.IsLaw;


                if (whatis == false) {
                    //Chequeao que no sea un semifull
                    var isSemifull = prod.Name.toLowerCase().indexOf('semi');
                    var issemi = (isSemifull != -1);

                    if (issemi) {
                        self.selectedSurchargePercent(null);
                    }

                    return issemi;
                }
                self.selectedSurchargePercent(null);

                return whatis;
            }
        }
        else {
            return false;
        }
    }

    self.validationRules = {
        rules: {
            brand: {
                required: true
            },
            model: {
                required: true
            },
            year: {
                required: true
            },
            vehiclePrice: {
                moneyRequired: true,
                moneyRange: [0.01, 9999999999.99]
                //moneyRange: function (element) {
                //    var allLaw = self.isLawProduct();
                //    alert(allLaw);
                //    if (allLaw)
                //    {
                //        console.log("Entre en la validacion")
                //        return [0.00, 9999999999.99];
                //    }
                //    console.log("NO Entre en la validacion")
                //    return [0.01, 9999999999.99];
                //}
            },
            insuredAmount: {
                moneyRequired: true,
                moneyRange: [0.01, 9999999999.99]
            },
            chassis: {
                required: true,
                maxlength: 50
            },
            plate: {
                required: true,
                maxlength: 50
            },
            color: {
                required: true,
                maxlength: 50
            },
            driver: {
                required: true
            },

            VehicleQuantity: {
                required: true,
                number: true,
                min: 1
            }
        },
        messages: {
            brand: {
                required: 'Debe seleccionar una Marca.',
            },
            model: {
                required: 'Debe seleccionar un Modelo.',
            },
            year: {
                required: 'Debe seleccionar un Año.',
            },
            vehiclePrice: {
                moneyRequired: 'Debe ingresar el precio del vehículo.',
                moneyRange: 'Debe ingresar un precio válido.'
            },
            insuredAmount: {
                moneyRequired: 'Debe ingresar el monto asegurado.',
                moneyRange: 'Debe ingresar un monto asegurado válido.'
            },
            chassis: {
                required: 'El Chasis es requerido.',
                maxlength: 'El Chasis no puede tener más de 50 caracteres de longitud.'
            },
            plate: {
                required: 'La Placa es requerida.',
                maxlength: 'La Placa no puede tener más de 50 caracteres de longitud.'
            },
            color: {
                required: 'Debe seleccionar un Color.',
                maxlength: 'El Color no puede tener más de 50 caracteres de longitud.'
            },
            driver: {
                required: 'Debe seleccionar un Conductor Principal.'
            },

            VehicleQuantity: {
                required: 'La Cantidad de Vehiculos es requerida.',
                number: 'La Cantidad de Vehiculos debe ser un número.',
                min: 'La Cantidad de Vehiculos debe ser igual o mayor a 1.',
            }

        }
    }

    //step6

    self.totalPrime = ko.computed(function () {
        var total = 0;
        if (self.productLimitSet()) {
            total = self.productLimitSet().SdPrime() + self.productLimitSet().TpPrime() + self.productLimitSet().ServicesPrime();
        }
        return roundToTwoDecimals(total);
    }).money();


    self.totalDiscount = ko.computed(function () {
        if (self.parent && self.parent.payment) {

            var t = $("#hdnIsAMotor").val();
            var realVehicleSelectedType = self.selectedVehicleType();

            if (t === "true2" && realVehicleSelectedType != null && realVehicleSelectedType.Name.indexOf("Motocicleta") == -1) {

                var PrimeNoMotors = self.parent.totalPrimeNoMotors();

                var total = self.totalPrime() * (self.parent.payment.currentDiscountPercentage() / 100);
                return roundToTwoDecimals(total);

            } else if (realVehicleSelectedType != null && realVehicleSelectedType.Name.indexOf("Motocicleta") != -1) {
                var total = 0;
                return roundToTwoDecimals(total);
            } else {
                var total = self.totalPrime() * (self.parent.payment.currentDiscountPercentage() / 100);
                return roundToTwoDecimals(total);
            }
        }
        else
            return 0;
    });

    self.totalIsc = ko.computed(function () {
        if (self.productLimitSet()) {

            return self.productLimitSet().TotalIsc();
        }
        else
            return 0;
    });

    self.getSelectedProduct = function (idProductToSearch) {
        if (idProductToSearch && self.selectedProductUsage())
            return _.find(self.selectedProductUsage().Coverages, function (item) { return item.Id == idProductToSearch });
        else
            return self.selectedProduct();
    }

    self.getSelectedUsageProduct = function (idProductToSearch) {
        if (idProductToSearch && self.selectedProductType())
            return _.find(self.selectedProductType().Products, function (item) { return item.Id == idProductToSearch });
        else
            return self.selectedProductUsage();
    }

    self.getSelectedProductName = function () {
        var prod = self.selectedProduct();
        if (prod)
            return prod.Name;
        else
            return '';
    }

    self.isLawProduct = ko.computed(function () {
        var prod = self.selectedCoverage();

        if (prod) {
            return prod.IsLaw;
        }
        else
            return true;
    });

    self.getDriver = function () {
        return _.find(self.parent.drivers(), function (item) { return self.driver() == item.id(); });
    }

    self.getForeingLicenceDriver = function () {
        var driv = _.find(self.parent.drivers(), function (item) { return self.driver() == item.id(); });
        return driv.ForeignLicense;
    }

    self.toString = ko.computed(function () {
        var output = '-';
        if (self.parent && self.brand() && self.model()) {
            var brand = _.find(self.parent.vehicleBrandList(), function (item) { return item.id == self.brand(); });
            var model = _.find(self.modelList(), function (item) { return item.id == self.model(); });
            if (brand && model)
                output = brand.name + '-' + model.name;
        }

        return output;
    });


    self.vechileBrandModelYear = ko.computed(function () {
        var output = '-';
        if (self.parent && self.brand() && self.model()) {
            var brand = _.find(self.parent.vehicleBrandList(), function (item) { return item.id == self.brand(); });
            var model = _.find(self.modelList(), function (item) { return item.id == self.model(); });
            if (brand && model)
                output = brand.name + ' - ' + model.name + ' - ' + self.year();
        }

        return output;
    });

    self.vehicleDataComplete = function () {
        UsageInvalid = $("#UsageInvalid").val();

        var completed = self.brand() &&
            self.model() &&
            self.year() &&
            self.store() &&
            self.usage() &&
            self.driver() &&
            self.selectedVehicleType() &&
            self.vehiclePrice() &&
            self.selectedProduct() &&
            self.selectedCoverage() &&
            (self.deductibleList && self.deductibleList().length > 0 ? self.selectedDeductible() : true) &&
            (UsageInvalid === "False") &&
            self.selectedVehicleYearsOld() &&
            self.VehicleQuantity() > 0;

        return completed;
    }

    self.coverageDataCompleteErrors = function () {
        var msgs = [];
        if (!self.vehiclePrice())
            msgs.push('Debe ingresar el Precio del vehículo.');

        if (!self.selectedProduct())
            msgs.push('Debe seleccionar un producto para el vehículo.');
        else {
            if (!self.primesRetrieved())
                msgs.push('Debe cotizar el producto seleccionado, haciendo click en el botón Cotizar.');
            var prod = self.getSelectedProduct();
            if (prod && prod.ProductType > 0 && !self.insuredAmount()) {
                msg.push('Debe ingresar el monto a cotizar para el vehículo.');
            }
        }

        return msgs;
    }

    self.vehicleAditionalDataComplete = function () {
        var completed = self.usage() > 0 &&
            self.driver() != undefined &&
            self.chassis() && self.chassis() != '' &&
            self.plate() && self.plate() != '' &&
            self.color();

        return completed;
    }

    self.loadVehicleTypes = function () {

    }

    //To use for enabling/disabling cascade
    self.brandSubscribe = null;
    self.modelSubscribe = null;
    self.yearSubscribe = null;
    self.selectedCoverageSubscribe = null;
    self.vehiclePriceSubscribe = null;
    self.selectedDeductibleSubscribe = null;
    self.selectedSurchargePercentSubscribe = null;
    self.selectedusageSubscribe = null;

    self.VehicleQuantitySubscribe = null;
    self.storeSubscribe = null;

    self.setVehicleCascadeStatus = function (enabled) {
        if (self.brandSubscribe)
            self.brandSubscribe.dispose();
        if (self.modelSubscribe)
            self.modelSubscribe.dispose();
        if (self.yearSubscribe)
            self.yearSubscribe.dispose();
        if (self.selectedCoverageSubscribe)
            self.selectedCoverageSubscribe.dispose();
        if (self.vehiclePriceSubscribe)
            self.vehiclePriceSubscribe.dispose();
        if (self.selectedDeductibleSubscribe)
            self.selectedDeductibleSubscribe.dispose();

        if (self.selectedSurchargePercentSubscribe) {
            self.selectedSurchargePercentSubscribe.dispose();
        }

        if (self.selectedusageSubscribe) {
            self.selectedusageSubscribe.dispose();
        }

        if (self.VehicleQuantitySubscribe) {
            self.VehicleQuantitySubscribe.dispose();
        }

        if (self.storeSubscribe) {
            self.storeSubscribe.dispose();
        }


        if (enabled) {
            self.brandSubscribe = self.brand.subscribe(function (brandId) {
                self.modelList([]);
                if (brandId != null) {
                    $.ajax({
                        url: "/PosAuto/GetModelsFromBrand",
                        dataType: 'json',
                        async: false,
                        data: { brandId: brandId },
                        success: function (data) {
                            self.modelList(data);
                        }
                    });
                }
            });
            self.modelSubscribe = self.model.subscribe(function (modelId) {
                self.year(null);
                self.cylinders(null);
                self.weight(null);
                self.passengers(null);

                var lastModelSelected = parseInt($("#lastModelSelected").val());
                var modelIdActual = modelId;

                if (lastModelSelected > 0) {

                    if (lastModelSelected != modelIdActual) {
                        $("#lastModelSelected").val(modelIdActual);
                        self.updateProductList();
                    }
                }
            });
            self.yearSubscribe = self.year.subscribe(function () {
                self.primesRetrieved(false);
                self.productLimitSet(null);

                self.updateProductList();
            });
            self.selectedCoverageSubscribe = self.selectedCoverage.subscribe(self.updateProductLimits);
            self.vehiclePriceSubscribe = self.vehiclePrice.subscribe(self.updateProductLimits);
            self.selectedDeductibleSubscribe = self.selectedDeductible.subscribe(self.updateProductLimits);
            self.selectedusageSubscribe = self.usage.subscribe(self.updateProductLimits);

            self.selectedSurchargePercentSubscribe = self.selectedSurchargePercent.subscribe(function () { self.getPrimes(); });
            self.VehicleQuantitySubscribe = self.VehicleQuantity.subscribe(function () { self.getPrimes(); });
            self.storeSubscribe = self.store.subscribe(function () { self.getPrimes(); });
        }
    }

    self.updateProductLimits = function () {

        if (self.selectedCoverage()
            && self.brand()
            && self.model()
            && self.year()
            && self.vehiclePrice()) {
            $.ajax({
                url: "/PosAuto/GetCoverageDetailsOfVehicle",
                dataType: 'json',
                data: {
                    coverageCoreId: self.selectedCoverage().Id,
                    makeId: self.brand(),
                    modelId: self.model(),
                    vehiclePrice: self.vehiclePrice
                },
                success: function (data) {

                    var viewModel = ko.mapping.fromJS(data, self.productLimitMapping);
                    self.productLimitSet(viewModel.coverageLimits);

                    self.deductibleList(data.deductibles);

                    self.getPrimes();
                }
            });
        }
        else {
            self.productLimitSet(null);
        }
    }

    self.updateProductList = function () {
        if (self.brand() && self.model() && self.year()
            && self.brand() > 0 && self.model() > 0 && self.year() > 0) {

            $.ajax({
                //url: "/PosAuto/GetVehicleTypes",//DESCOMENTAR SYSFLEX VIEJO
                url: "/PosAuto/GetVehicleTypes_New",
                dataType: 'json',
                async: false,
                cache: false,
                data: {
                    brandId: self.brand(),
                    modelId: self.model(),
                    vehicleYear: self.year()
                },
                success: function (data) {
                    self.vehicleTypeList(data);
                    $("#lastModelSelected").val(self.model());
                }
            });
        }
        else
            self.vehicleTypeList([]);
    }

    self.loadModel = function (model, setAsync) {

        //setAsync default: true
        setAsync = typeof setAsync !== 'undefined' ? setAsync : true;

        self.id(model.Id);
        self.usage(model.UsageId);
        self.usageName(model.UsageName);
        self.store(model.StoreId);
        self.vehiclePrice(model.VehiclePrice);
        self.driver(model.Driver.Id);
        self.plate(model.Plate);
        self.color(model.Color);
        self.chassis(model.Chassis);
        self.cylinders(model.Cylinders);
        self.weight(model.Weight);
        self.passengers(model.Passengers);
        self.percentageToInsureList(model.Percentages);
        self.deductibleList(model.Deductibles);

        self.SecuenciaVehicleSysflex(model.SecuenciaVehicleSysflex);

        var selectedVehicleYearsOldFind = _.find(self.parent.vehicleYearsOldList(), function (item) { return item.id == model.VehicleYearOld; });

        if (selectedVehicleYearsOldFind != null) {
            self.selectedVehicleYearsOld(selectedVehicleYearsOldFind.id);
            self.isFirstLoading(true);
            $("#LastSelectedVehicleYearsOld").val(self.selectedVehicleYearsOld());
        } else {
            self.selectedVehicleYearsOld(null);
            self.isFirstLoading(false);
            $("#LastSelectedVehicleYearsOld").val(self.selectedVehicleYearsOld());
        }


        self.vehicleTypeList(model.VehicleTypes);

        self.NumeroFormulario(model.NumeroFormulario);
        self.rateJson(model.rateJson);

        self.flagVehicleToDelete(false);

        self.VehicleQuantity(model.VehicleQuantity);

        self.loadCascade(model, setAsync);


    }

    self.loadCascade = function (model, setAsync) {

        self.setVehicleCascadeStatus(false);
        self.brand(model.VehicleModel.Make_Id);
        self.model(model.VehicleModel.Model_Id);
        self.year(model.Year);

        self.modelList([]);

        if (model.ProductLimits && model.ProductLimits.length > 0) {
            var viewModel = ko.mapping.fromJS(model.ProductLimits[0], self.productLimitMapping);
            if (viewModel) {
                self.productLimitSet(viewModel);
                self.primesRetrieved(true);
                var deductibleId = viewModel.SelectedDeductibleCoreId();
                self.deductibleList(model.Deductibles);
                self.selectedDeductible(deductibleId);
            }
        }

        if (model.SurChargePercentage) {

            var surchargepercentlist = _.find(self.parent.surchargePercentList(), function (item) { return item.id == model.SurChargePercentage; });
            self.selectedSurchargePercent(surchargepercentlist);
        }

        if (model.SelectedVehicleTypeName) {
            self.selectedVehicleTypeId(model.SelectedVehicleTypeId);

            var vType = _.find(model.VehicleTypes, function (item) { return item.Name == model.SelectedVehicleTypeName });

            self.selectedVehicleType(vType);

            if (model.SelectedProductCoreId) {
                if (model.SelectedCoverageCoreId) {
                    //var coverage = _.find(product.Coverages, function (item) { return item.Id == model.SelectedCoverageCoreId });//ORIGINAL 30-08-2017


                    if (self.usage()) {

                        var UsageFound = _.find(self.UsagesListByVehicleType(), function (item) { return item.idUso == self.usage(); });
                        if (UsageFound) {

                            var coverage = _.find(vType.CoveragesByUsages, function (item) { return item.Id == model.SelectedCoverageCoreId && item.UsoDescripcion.indexOf(UsageFound.descUso) != -1 });
                            self.selectedCoverage(coverage);
                        }
                    }
                }


                var product = _.find(vType.Products, function (item) { return item.Id == model.SelectedProductCoreId });
                self.selectedProduct(product);
            }
        }


        if (self.productLimitSet && self.productLimitSet() != null && self.productLimitSet().ServicesCoverages && self.productLimitSet().ServicesCoverages() != null && self.productLimitSet().ServicesCoverages().length > 0) {
            var servicescov = self.productLimitSet().ServicesCoverages();

        }

        $.ajax({
            url: "/PosAuto/GetModelsFromBrand",
            dataType: 'json',
            async: setAsync,
            data: {
                brandId: model.VehicleModel.Make_Id
            },
            success: function (data) {
                self.modelList(data);
                self.model(model.VehicleModel.Model_Id);
                self.getPrimes();
                self.setVehicleCascadeStatus(true);
            }
        });

    }

    self.additionalsEnabled = ko.computed(function () {
        return self.productLimitSet && self.productLimitSet() != null && self.productLimitSet().ServicesCoverages && self.productLimitSet().ServicesCoverages() != null && self.productLimitSet().ServicesCoverages().length > 0;
    });

    self.showAdditionals = function (vehicle) {

        if (self.productLimitSet().ServicesCoverages().length > 0) {
            var container = $('#popupContainer');
            var results = new Array();
            for (var i = 0; i < self.productLimitSet().ServicesCoverages().length; i++) {
                var sc = self.productLimitSet().ServicesCoverages()[i];
                var obj = { id: sc.Name(), value: ko.observable() };
                obj.value.subscribe(self.popupCalculateAnnualTotal);
                var selected = _.find(sc.Coverages(), function (cov) { return cov.IsSelected(); });
                if (selected)
                    obj.value(selected.Id());
                results.push(obj);
            }

            self.popupSelectedServices(results);
            self.popupCalculateAnnualTotal();

            var temp = ko.renderTemplate('popupServicesTemplate', this, {}, container[0]);

            var popup = $('#popupServices');

            popup.show();
        }
        else {
            showError(['La cobertura seleccionada para este vehículo no posee Servicios Adicionales'], 'Guardar Cotización');
        }
    }

    self.popupSave = function () {
        var popup = $('#popupServices');
        popup.hide();

        _.each(self.popupSelectedServices(), function (item) {
            var service = _.find(self.productLimitSet().ServicesCoverages(), function (sc) { return sc.Name() == item.id });
            _.each(service.Coverages(), function (cov) { cov.IsSelected(cov.Id() == item.value()); });
        });
        self.popupAnnualTotal(0);
        var container = $('#popupContainer');
        container.empty();

        self.popupSelectedServices.removeAll();

        self.getPrimes();
    }

    self.validateGetRates = function () {
        var msgs = [];
        //if (!self.termTypeSelected()) {
        //    msgs.push('Debe seleccionar un Tipo de Término para poder obtener su cotización.');
        //} //Removed due a change in requirements (Tipo de Termino 1 year)
        if (!self.vehiclePrice())
            msgs.push('Debe ingresar el Precio del Vehículo para poder obtener su cotización.')

        if (!self.productLimitSet())
            msgs.push('Debe seleccionar un Tipo de Producto para poder obtener su cotización.');

        if (!self.driver())
            msgs.push('Debe seleccionar un Conductor para poder obtener su cotización.');

        //if (!self.currentProductUsageSelected())
        //    msgs.push('Debe seleccionar un Producto para poder obtener su cotización.');

        if (!self.selectedCoverage())
            msgs.push('Debe seleccionar una Cobertura para poder obtener su cotización.');

        if (!self.deductibleList() || (self.deductibleList() && self.deductibleList().length > 0 && !self.selectedDeductible()))
            msgs.push('Debe seleccionar un Deducible para poder obtener su cotización.');

        //if (!self.currentProductUsageSelected())
        //    msgs.push('Debe seleccionar un Producto para poder obtener su cotización.')

        if (msgs.length > 0) {
            //showError(msgs, "Obtener Cotización");
            return false;
        }
        else
            return true;
    }

    self.getPrimes = function () {

        if (self.productLimitSet()) {

            if (self.validateGetRates()) {

                var servicesIdList = [];

                if (self.productLimitSet().ServicesCoverages) {
                    var allCoverages = new Array();
                    _.each(self.productLimitSet().ServicesCoverages(), function (item) { _.each(item.Coverages(), function (sItem) { allCoverages.push(sItem) }); });
                    _.each(_.filter(allCoverages, function (item) { return item.IsSelected(); }), function (item) { servicesIdList.push(item.CoverageDetailCoreId()); });
                }

                var getQuotationNumberForRates = self.parent.getQuotationNumberForRates();
                var getQuotationNumber = self.parent.getQuotationNumber();

                var principalDateOfBirth = self.getDriver().dateOfBirth;

                var qtyVehicles = self.parent.qtyVehiclesCreated();
                
                if (qtyVehicles == 0) {
                    qtyVehicles = self.VehicleQuantity();
                }
                else if (self.VehicleQuantity() > qtyVehicles) {
                    qtyVehicles = self.VehicleQuantity();
                } else if (qtyVehicles > self.VehicleQuantity()) {
                    qtyVehicles = qtyVehicles;
                }

                var quotationCoreNumber = self.parent.quotationCoreNumber();

                //Original
                var NewAgentID = "";
                var NewAgent = self.parent.getNewAgentSelected();

                if (NewAgent != null) {
                    NewAgentID = NewAgent.NameId;
                }

                var getActualAgentSelected = self.parent.getOldAgent();
                var ActualAgentSelected = "";

                if (getActualAgentSelected != null) {
                    ActualAgentSelected = getActualAgentSelected.NameId;
                }



                var wasChangeDateBirth = false;
                if (self.parent && self.parent.changedDateBirth() == true && self.parent.changedDateBirthFirst() == false) {
                    wasChangeDateBirth = true;
                    principalDateOfBirth = $("#dateOfBirthAdd").val() == "" ? self.getDriver().dateOfBirth : $("#dateOfBirthAdd").val();
                }

                if (self.parent && self.parent.changedDateBirthFirst() == true /*&& self.parent.changedDateBirth() == false*/) {
                    wasChangeDateBirth = true;
                    //principalDateOfBirth = $("#dateOfBirth").val() == "" ? self.getDriver().dateOfBirth : $("#dateOfBirth").val();

                    principalDateOfBirth = $("#NewdateOfBirth").val() == "" ? self.getDriver().dateOfBirth : $("#NewdateOfBirth").val();
                }


                var wasChangeClientSex = false;
                var clientSex = self.getDriver().selectedSex();
                if (self.parent && self.parent.changedClientSexFirst() == true) {
                    wasChangeClientSex = true;
                    //clientSex = $("#clientSex").val() == "" ? self.getDriver().selectedSex() : $("#clientSex").val();
                    clientSex = $("#NewclientSex").val() == "" ? self.getDriver().selectedSex() : $("#NewclientSex").val();

                }


                var getForeingLicenceDriver = self.getForeingLicenceDriver();
                if (self.parent && self.parent.changedForeingLicenceFirst() == true) {
                    //getForeingLicenceDriver = $("#ForeingLicence").val() == "" ? self.getForeingLicenceDriver() : $("#ForeingLicence").val();
                    getForeingLicenceDriver = $("#NewForeingLicence").val() == "" ? self.getForeingLicenceDriver() : $("#NewForeingLicence").val();
                }


                var arraySelfAndThirdsDamage = [];
                var arrayServiceCoverages = [];

                if (self.productLimitSet().SelfDamagesCoverages) {
                    _.each(self.productLimitSet().SelfDamagesCoverages(), function (item) {
                        var AsociativeArraySelfAndThirdsDamage = {}
                        AsociativeArraySelfAndThirdsDamage["CoverageDetailCoreId"] = item.CoverageDetailCoreId();
                        AsociativeArraySelfAndThirdsDamage["Limit"] = item.Limit();
                        AsociativeArraySelfAndThirdsDamage["Name"] = item.Name();

                        arraySelfAndThirdsDamage.push(AsociativeArraySelfAndThirdsDamage);
                    });
                }

                if (self.productLimitSet().ThirdPartyCoverages) {
                    _.each(self.productLimitSet().ThirdPartyCoverages(), function (item) {
                        AsociativeArraySelfAndThirdsDamage = {}
                        AsociativeArraySelfAndThirdsDamage["CoverageDetailCoreId"] = item.CoverageDetailCoreId();
                        AsociativeArraySelfAndThirdsDamage["Limit"] = item.Limit();
                        AsociativeArraySelfAndThirdsDamage["Name"] = item.Name();

                        arraySelfAndThirdsDamage.push(AsociativeArraySelfAndThirdsDamage);
                    });
                }


                if (self.productLimitSet().ServicesCoverages) {
                    var allCoverages = new Array();
                    _.each(self.productLimitSet().ServicesCoverages(), function (item) {
                        _.each(item.Coverages(), function (sItem) {

                            var AsociativearrayServiceCoverages = {}
                            AsociativearrayServiceCoverages["CoverageDetailCoreId"] = sItem.CoverageDetailCoreId();
                            AsociativearrayServiceCoverages["Limit"] = sItem.Limit();
                            AsociativearrayServiceCoverages["Name"] = sItem.Name();
                            AsociativearrayServiceCoverages["isSelected"] = sItem.IsSelected();

                            arrayServiceCoverages.push(AsociativearrayServiceCoverages);
                        });
                    });
                }

                var limitSelfThirdJson = JSON.stringify(arraySelfAndThirdsDamage);
                var serviceCoberageJson = JSON.stringify(arrayServiceCoverages);


                var UsageFound = _.find(self.UsagesListByVehicleType(), function (item) { return item.idUso == self.usage(); });
                if (UsageFound) {
                    self.usageName(UsageFound.descUso);

                    var allowed = UsageFound.allowed;
                    var message = UsageFound.message;
                    var UsageInvalidMessageShow = self.parent.getLastStep();

                    //No debe generar prima
                    if (allowed == 2) {
                        return;
                    }
                }

                var asyncOrNo = self.parent.changeDate() ? false : true;


                var secuence = self.SecuenciaVehicleSysflex();
                /*Get Rates Nuevo Nueva forma 28-10-2017*/
                $.ajax({
                    url: '/PoSAuto/GetRates_New',
                    type: 'POST',
                    dataType: 'json',
                    data: {
                        coverageCoreId: self.selectedCoverage().Id,
                        productId: self.selectedVehicleType().Name,
                        brandId: self.brand(),
                        modelId: self.model(),
                        vehicleYear: self.year(),
                        coveragePercent: self.percentageToInsure(),
                        startDate: self.parent.currentStartDateSelected(),
                        endDate: self.parent.currentEndDateSelected(),
                        insuredAmount: self.insuredAmount(),
                        servicesIdList: servicesIdList.join(),
                        deductibleId: self.selectedDeductible(),
                        gender: clientSex,
                        principalDateOfBirth: principalDateOfBirth,
                        storageId: self.store(),
                        percentSurCharge: self.selectedSurchargePercent() ? self.selectedSurchargePercent().id : 0,
                        QuotationNumberForRates: getQuotationNumberForRates,
                        LicenciaExtranjera: getForeingLicenceDriver,
                        qtyVehicles: qtyVehicles,
                        usage: self.usage(),
                        secuencia: secuence,
                        agentChangeSelected: NewAgentID,
                        quotationCore: quotationCoreNumber,
                        Esdeley: self.isLawProduct(),
                        idCapacidad: self.idCapacidad(),
                        descCapacidad: self.DescCapacidad(),
                        coverages: serviceCoberageJson,
                        limitself: limitSelfThirdJson,
                        usagename: self.usageName(),
                        isSemifull: self.selectedCoverage().Name,
                        QuotationNumber: getQuotationNumber,
                        wasChangeDateBirth: wasChangeDateBirth,
                        wasChangeClientSex: wasChangeClientSex,
                        actualAgentSelected: ActualAgentSelected
                    },
                    async: asyncOrNo,
                    success: function (data) {

                        if (self.productLimitSet()) {

                            if (data.TpPrime != undefined) {

                                self.productLimitSet().TpPrime(data.TpPrime);
                                self.productLimitSet().SdPrime(data.SdPrime);
                                self.productLimitSet().ServicesPrime(data.ServicesPrime);
                                //self.productLimitSet().TotalIsc(data.TotalIsc);//ORIGINAL 28-11-2016

                                var total = data.SdPrime + data.TpPrime + data.ServicesPrime;
                                var iscPercentage = parseFloat(self.parent.payment.iscPercentage());
                                self.productLimitSet().TotalIsc(total * (iscPercentage / 100));

                                self.selectedVehicleTypeId(data.VehicleTypeId);
                                self.primesRetrieved(true);
                                self.rateJson(data.jsonRates);

                                self.porcImpuesto(iscPercentage);

                                if (self.NotFirstLoading() == true) {
                                    $.ajax({
                                        url: '/PoSAuto/GetPercentByQtyVehicle',
                                        type: 'POST',
                                        dataType: 'json',
                                        data: { qtyVehicles: qtyVehicles },
                                        async: true,
                                        success: function (data) {
                                            self.parent.PercentByQtyVehicle(data);

                                            if (data > 0) {
                                                self.parent.isFlotilla(true);
                                            } else {
                                                self.parent.isFlotilla(false);
                                            }

                                        }
                                    });
                                } else {
                                    self.NotFirstLoading(true);
                                }

                                var subRamo = self.selectedCoverage().Id;
                                var make = self.brandName();
                                var model = self.modelName();
                                var year = self.year();
                                var vehiclePrice = self.vehiclePrice();

                                //Solos los que no son de Ley
                                if (!self.isLawProduct()) {
                                    /*Reaseguro*/
                                    $.ajax({
                                        url: '/PoSAuto/getMaximoReaseguroSubRamo_New',
                                        dataType: 'json',
                                        data: { SecuenciaVehicleSysflex: secuence, quotationCoreNumber: quotationCoreNumber, make: make, model: model, year: year },
                                        async: false,
                                        success: function (data) {

                                            if (data.IsFacultative) {
                                                self.IsFacultative(data.IsFacultative);
                                                self.AmountFacultative(data.AmountFacultative);
                                                showWarning([data.message], 'Advertencia Reaseguro');
                                            } else {
                                                self.IsFacultative(false);
                                                self.AmountFacultative(0);
                                            }
                                        }
                                    });
                                }
                            }
                        }
                    }
                });



                /*Get Rates Nuevo 28-10-2017 - Jheiron*/
                //$.post("/PosAuto/GetRates_New", {
                //    coverageCoreId: self.selectedCoverage().Id,
                //    productId: self.selectedVehicleType().Name,
                //    brandId: self.brand(),
                //    modelId: self.model(),
                //    vehicleYear: self.year(),
                //    coveragePercent: self.percentageToInsure(),
                //    startDate: self.parent.currentStartDateSelected(),
                //    endDate: self.parent.currentEndDateSelected(),
                //    insuredAmount: self.insuredAmount(),
                //    servicesIdList: servicesIdList.join(),
                //    deductibleId: self.selectedDeductible(),
                //    gender: clientSex,
                //    principalDateOfBirth: principalDateOfBirth,
                //    storageId: self.store(),
                //    percentSurCharge: self.selectedSurchargePercent() ? self.selectedSurchargePercent().id : 0,
                //    QuotationNumberForRates: getQuotationNumberForRates,
                //    LicenciaExtranjera: getForeingLicenceDriver,
                //    qtyVehicles: qtyVehicles,
                //    usage: self.usage(),
                //    secuencia: secuence,
                //    agentChangeSelected: NewAgentID,
                //    quotationCore: quotationCoreNumber,
                //    Esdeley: self.isLawProduct(),
                //    idCapacidad: self.idCapacidad(),
                //    descCapacidad: self.DescCapacidad(),
                //    coverages: serviceCoberageJson,
                //    limitself: limitSelfThirdJson,
                //    usagename: self.usageName(),
                //    isSemifull: self.selectedCoverage().Name,
                //    QuotationNumber: getQuotationNumber,
                //    wasChangeDateBirth: wasChangeDateBirth,
                //    wasChangeClientSex: wasChangeClientSex,
                //    actualAgentSelected: ActualAgentSelected
                //},
                //    function (data) {

                //        if (self.productLimitSet()) {

                //            if (data.TpPrime != undefined) {

                //                self.productLimitSet().TpPrime(data.TpPrime);
                //                self.productLimitSet().SdPrime(data.SdPrime);
                //                self.productLimitSet().ServicesPrime(data.ServicesPrime);
                //                //self.productLimitSet().TotalIsc(data.TotalIsc);//ORIGINAL 28-11-2016

                //                var total = data.SdPrime + data.TpPrime + data.ServicesPrime;
                //                var iscPercentage = parseFloat(self.parent.payment.iscPercentage());
                //                self.productLimitSet().TotalIsc(total * (iscPercentage / 100));

                //                self.selectedVehicleTypeId(data.VehicleTypeId);
                //                self.primesRetrieved(true);
                //                self.rateJson(data.jsonRates);

                //                self.porcImpuesto(iscPercentage);

                //                if (self.NotFirstLoading() == true) {
                //                    $.ajax({
                //                        url: '/PoSAuto/GetPercentByQtyVehicle',
                //                        type: 'POST',
                //                        dataType: 'json',
                //                        data: { qtyVehicles: qtyVehicles },
                //                        async: true,
                //                        success: function (data) {
                //                            self.parent.PercentByQtyVehicle(data);

                //                            if (data > 0) {
                //                                self.parent.isFlotilla(true);
                //                            } else {
                //                                self.parent.isFlotilla(false);
                //                            }

                //                        }
                //                    });
                //                } else {
                //                    self.NotFirstLoading(true);
                //                }

                //                var subRamo = self.selectedCoverage().Id;
                //                var make = self.brandName();
                //                var model = self.modelName();
                //                var year = self.year();
                //                var vehiclePrice = self.vehiclePrice();

                //                //Solos los que no son de Ley
                //                if (!self.isLawProduct()) {
                //                    /*Reaseguro*/
                //                    $.ajax({
                //                        url: '/PoSAuto/getMaximoReaseguroSubRamo_New',
                //                        dataType: 'json',
                //                        data: { SecuenciaVehicleSysflex: secuence, quotationCoreNumber: quotationCoreNumber, make: make, model: model, year: year },
                //                        async: false,
                //                        success: function (data) {

                //                            if (data.IsFacultative) {
                //                                self.IsFacultative(data.IsFacultative);
                //                                self.AmountFacultative(data.AmountFacultative);
                //                                showWarning([data.message], 'Advertencia Reaseguro');
                //                            } else {
                //                                self.IsFacultative(false);
                //                                self.AmountFacultative(0);
                //                            }
                //                        }
                //                    });
                //                }
                //            }
                //        }
                //    });
            }
        }
    }

    self.enableVehicleOldCombo = ko.computed(function () {

        if (self.parent && self.year()) {

            //if ((self.parent.currentYear() - 1) <= self.year() &&

            var QtyYearsBack0KmVip = self.parent.QtyYearsBack0KmVip();

            if (!QtyYearsBack0KmVip) {
                QtyYearsBack0KmVip = 2;
            }

            if ((self.parent.currentYear() - QtyYearsBack0KmVip) <= self.year() && self.year() <= (self.parent.currentYear() + 1)) {


                var isFirstLoading = self.isFirstLoading();
                var isDisabled = $("#VehicleYearsOld").is("disabled");
                var lastvalue = $("#LastSelectedVehicleYearsOld").val();
                var actualvalue = self.selectedVehicleYearsOld();


                if (isFirstLoading == false && lastvalue == actualvalue) {
                    self.selectedVehicleYearsOld(null);

                    $("#LastSelectedVehicleYearsOld").val(self.selectedVehicleYearsOld());
                }

                return true;
            }
            else {

                var value = self.parent.vehicleYearsOldList()[1];
                self.selectedVehicleYearsOld(value.id);
                $("#LastSelectedVehicleYearsOld").val(self.selectedVehicleYearsOld());
                self.isFirstLoading(false);
                return false;
            }
        }
        else
            return true;

    });

    //Start cascades immediately
    self.setVehicleCascadeStatus(true);

};