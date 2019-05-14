var vdeleted = [];
CotRenovaInitialize = function (Title) {

    $('#HideInHistory, #HideInHistory2').show();

    InitializeChosen();

    //$("#quotationID").val('');
    //$("#spQuotationNumber").text('');
    //$("#QuotationNumber").val('');

    //InitializeCustom();

    var $AgentList = $("#AgentList");
    $AgentList.prop("disabled", true);

    var $filtroHistorico = $("#filtroHistorico");
    $filtroHistorico.val("7");
    $filtroHistorico.trigger("change.select2");

    $("#btnRenoSearch").on("click", function () {
        _SearchPolicy();
    });

    $("#hdnTitle").val(Title);

    $("#btnCancel").click(function () {
        var Title = $("#hdnTitle").val();
        $("#txtPolicyNo").val('');
        LoadCotRenov(false, Title);
    });

    $(document).on("click", ".vehicleCheck", function () {
        var $this = $(this);

        var allchecks = $('.vehicleCheck');
        var checksCheckeds = 0;

        $.each(allchecks, function (index, obj) {
            var $this2 = $(this);
            if ($this2.is(':checked')) {
                checksCheckeds += 1;
            }
        });

        if (checksCheckeds == 0) {
            showWarning(['No puede excluir todos los vehiculos.']);
            $this.prop('checked', false);
            return false;
        }

        //if ($this.is(":checked") == false) {
        SelectedVehicleData();
        //}
    });

    GlobalOnlyForEmission = false;

    componentHandler.upgradeAllRegistered();
}

function LoadCotRenov(isFromHistory, Title) {

    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/CotizarRenovacion",
        data: { isFromHistory: isFromHistory },
        dataType: "html",
        success: function (response) {

            $('#TitleView').html(Title);
            $('#main').removeClass('hist');
            $('#dvContainer').html(response);

            CotRenovaInitialize(Title);

            isFromHistory = isNaN(isFromHistory) ? false : isFromHistory;

            if (isFromHistory) {
                //LoadProspectFormData(,,isFromHistory);
                _SearchPolicy(isFromHistory);
            } else {
                $("#quotationID").val('');
                $("#spQuotationNumber").text('');
                $("#QuotationNumber").val('');
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function _SearchPolicy(isFromHistory) {

    //Validar que se introduzca un numero de poliza
    var PolicyNumber = $("#txtPolicyNo").val();

    if (isFromHistory) {
        PolicyNumber = $("#hdnPolicyNoMain").val();
    }

    if (PolicyNumber == "") {
        showWarning(['Por favor digite un número de Póliza'], 'Advertencia');
        return false;
    }
    var title = $("#hdnTitle").val();

    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/GetBasicDataCustomerFromPolicy",
        data: JSON.stringify({ PolicyNumber: PolicyNumber }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            var hasCode = !isNaN(data.code);
            if (hasCode) {
                var PolicyIsNotFound = data.code == "001";
                var ClientISnotCorrect = data.code == "002";
                var PolicyDontActive = data.code == "003";
                var UserDontAgentChain = data.code == "004";

                if (UserDontAgentChain) {
                    showWarning([data.msg], 'Adventencia');
                    return false;
                }

                if (!PolicyDontActive) {
                    var IsValidAgent = data.IsvalidAgent;

                    if (PolicyIsNotFound) {
                        showWarning([data.msg], 'Póliza no encontrada');
                        return false;
                    }

                    if (ClientISnotCorrect) {
                        showWarning([data.msg], 'Adventencia');
                        return false;
                    }

                    if (!IsValidAgent) {
                        showWarning(['El agente de esta póliza no esta en su cadena, comuniquese con el departamento tecnico'], 'Advertencia');
                        return false;
                    }
                } else {
                    showWarning([data.msg], 'Adventencia');
                    return false;
                }
            }

            LoadDataClient(data.DataCoreCustomer, data.userAgenCode);

            getVehiclesDataFromPolicy(PolicyNumber, isFromHistory);

            SelectedVehicleData();
            $("#hdnToNotExclude").val('');

        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function getVehiclesDataFromPolicy(PolicyNumber, isFromHistory) {
    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/GetDataVehicleFromPolicy",
        data: JSON.stringify({ PolicyNumber: PolicyNumber, isFromHistory: isFromHistory }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {

            if (data.Message !== "") {
                showWarning([data.Message]);
                return false;
            }

            var secuencias = [];
            var TrReplace = "";
            var $Tbody = $("#tblVehiclesReno").find("tbody");
            $Tbody.find("tr").remove();
            var Title = $("#hdnTitle").val();
            //<td>{PolicyNumber}</td>
            var trText =
                "<tr><th scope='row'>{NumOrd}</th><td>{Make}</td><td>{Model}</td><td>{Year}</td><td>{Plate}</td><td>{chassis}</td><td>{Color}</td>  <td>{CurrentPlan}</td> <td>{CurrentPrime}</td>  <td>{ProposedPlan}</td> <td>{ProposedPrime}</td>  <td><input id='{checkid}' class='vehicleCheck' checked='checked' type='checkbox'></td></tr>";


            var dataVehicle = data.DataCoreVehicle;
            var itemPolicyNumber = data.PolicyNumber;
            var qtyVehicles = dataVehicle.length;
            $("#hdnExcludeVehiclesQuantity").val(qtyVehicles);
            var isFinanced = false;
            var isFinanceSet = false;

            $("#hdnToNotExclude").val(data.toNotExclude);


            if (data.QuotationNumber) {
                $("#spQuotationNumber").text(data.QuotationNumber);

                $("#QuotationNumber").val(data.QuotationNumber);
            }

            $.each(dataVehicle, function (index, value) {

                $("#hdnEndDate").val(moment(value.FechaFinString.replace(".", "")).format(getCurrentDateMomentFormat()));
                TrReplace = trText.replace("{NumOrd}", (index + 1));
                //TrReplace = TrReplace.replace("{PolicyNumber}", itemPolicyNumber);
                TrReplace = TrReplace.replace("{Make}", value.Marca);
                TrReplace = TrReplace.replace("{Model}", value.Modelo);
                TrReplace = TrReplace.replace("{Year}", value.Ano);
                TrReplace = TrReplace.replace("{Plate}", value.placa);
                TrReplace = TrReplace.replace("{chassis}", value.chasis);
                TrReplace = TrReplace.replace("{Color}", value.color);

                TrReplace = TrReplace.replace("{CurrentPlan}", value.DescripcionSubramo);
                TrReplace = TrReplace.replace("{CurrentPrime}", number_format(value.Prima, 2));

                TrReplace = TrReplace.replace("{ProposedPlan}", value.DescripcionSubramoNew);
                TrReplace = TrReplace.replace("{ProposedPrime}", number_format(value.PrimaBrutaNew, 2));

                TrReplace = TrReplace.replace("{checkid}", "vehicle_secuence_" + value.Item);
                $Tbody.append(TrReplace);
                var $trLast = $Tbody.find("tr:last");
                $trLast.addClass("dataVh");
                $trLast.data("dataVehicle", JSON.stringify(value));
                secuencias.push(value.Item);

                if (!isFinanceSet) {

                    isFinanced = value.Financed;

                    if (!isFinanced && value.TieneEndoso) {
                        isFinanced = value.TieneEndoso;
                    }

                    isFinanceSet = true;
                }
            });

        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function SelectedVehicleData() {

    var tbl = $("#tblVehiclesReno tr.dataVh");
    var $selecCober = $('#selecCoberReno');

    if (tbl.length > 0) {

        $selecCober.show();
        $selecCober.find('div.cleanme').empty();

        var toNotExclude = $("#hdnToNotExclude").val();

        $.each(tbl, function () {
            var $this = $(this);

            var chk = $this.find('.vehicleCheck');

            var id = chk.attr("id");

            id = id.split('_')[2];

            if (toNotExclude !== '' && toNotExclude.indexOf(id) === -1) {
                chk.prop("checked", false);
                return;
            }

            if ($this.data("dataVehicle") !== '' && chk.is(':checked')) {
                var jsonDataVh = $this.data("dataVehicle");

                PaintVehicleData(jsonDataVh, $selecCober);
            } else if ($this.data("dataVehicle") !== '' && !chk.is(':checked')) {

                var jsonDataVh = JSON.parse($this.data("dataVehicle"));

                if (jsonDataVh && jsonDataVh.vehicleId) {

                    if (vdeleted.length > 0 && vdeleted.indexOf(jsonDataVh.vehicleId) !== -1) {
                        return;
                    }
                    deleteVehicle(jsonDataVh.vehicleId);
                }
            }
        });

    } else {
        $selecCober.find('div.cleanme').empty();
        $selecCober.hide();
    }
}

function PaintVehicleData(dataVehicle, paintHere) {
    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/VehicleData",
        data: { dataVehicle: dataVehicle },
        dataType: "html",
        async: false,
        success: function (data) {

            //paintHere.find("div:first").append(data);
            paintHere.find("div.cleanme").append(data);

            //InitializePartialControls();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function SaveDataCotizarReno() {

    var $selecCober = $('#selecCoberReno');
    var $DataVehiclesSection = $selecCober.find("div.parentSectionVehicle");

    var vehicleListData = [];

    var currentStartDateSelected = moment(new Date()).format(getCurrentDateTimeMomentFormat());
    var endDate = moment(currentStartDateSelected, getCurrentDateTimeMomentFormat()).add(12, 'months').startOf('day');
    var currentEndDateSelected = (endDate.format(getCurrentDateTimeMomentFormat()));

    var quotData = {};

    quotData.quotationID = $("#quotationID").val() !== '' ? $("#quotationID").val() : 0;
    quotData.agentSelected = $("#AgentList option:selected").val();
    quotData.StartDate = currentStartDateSelected;
    quotData.EndDate = currentEndDateSelected;

    if ($("#txtPolicyNo").val() !== '' && $("#txtPolicyNo").val() !== undefined) {
        quotData.Poliza = $("#txtPolicyNo").val();
    }
    else if ($("#hdnPolicyNoMain").val() !== '' && $("#hdnPolicyNoMain").val() !== undefined) {
        quotData.Poliza = $("#hdnPolicyNoMain").val();
    }

    quotData.driverId = $("#hdnDriverID").val();

    $DataVehiclesSection.each(function () {

        var $this = $(this);
        var jsonVehicleData = $this.find("input[id='currentDataVehicle']").val();
        var vehicleData = JSON.parse(jsonVehicleData);

        var objData = {};

        objData.id = vehicleData.vehicleId;
        objData.vehicleDescription = vehicleData.Marca + " " + vehicleData.Modelo;
        objData.Year = vehicleData.Ano;
        objData.VehiclePrice = vehicleData.ValorVehiculo == null ? 0 : vehicleData.ValorVehiculo;
        objData.insuredAmount = vehicleData.ValorVehiculo == null ? 0 : vehicleData.ValorVehiculo;
        objData.percentageToInsure = 100;
        objData.totalPrime = vehicleData.PrimaBrutaNew;
        objData.totalIsc = (vehicleData.PrimaBrutaNew * (0.16));
        objData.totalDiscount = 0;
        objData.selectedProductName = vehicleData.TipoPolizaDescripcionNew;
        objData.vehicleMakeName = vehicleData.Marca;
        objData.usageId = vehicleData.Iduso;
        objData.usageName = vehicleData.Uso;
        objData.storeId = vehicleData.IdEstacionamiento;
        objData.storeName = vehicleData.Estacionamiento;
        objData.vehicleModel_Model_Id = vehicleData.Idmodelo;
        objData.selectedProductCoreId = vehicleData.TipoPolizaNew;
        objData.vehicleYearOld = "Usado";
        objData.selectedVehicleTypeId = vehicleData.Idtipovehiculo;
        objData.selectedVehicleTypeName = vehicleData.DescripcionTarifa;
        objData.selectedCoverageCoreId = vehicleData.SubramoNew;
        objData.selectedCoverageName = vehicleData.DescripcionSubramoNew;
        objData.surChargePercentage = 0;
        objData.numeroFormulario = null;
        objData.rateJson = "";
        objData.secuenciaVehicleSysflex = vehicleData.Item;
        objData.isFacultative = false;
        objData.amountFacultative = 0;
        objData.ProratedPremium = 0;
        objData.SelectedVehicleFuelTypeId = null;
        objData.SelectedVehicleFuelTypeDesc = null;
        objData.VehicleQuantity = 1;
        objData.chassis = vehicleData.chasis;
        objData.plate = vehicleData.placa;
        objData.color = vehicleData.color;

        objData.SelectedDeductibleCoreId = vehicleData.Iddeducible == null ? 0 : vehicleData.Iddeducible;
        objData.SelectedDeductibleName = vehicleData.Deducible;

        objData.secuenciaMov = vehicleData.Secuenciamov;
        objData.coreQuotationNumber = vehicleData.Cotizacion;

        objData.randomId = Math.floor((Math.random() * -20000) + (-1));

        objData.ModeloDesc = vehicleData.Modelo;

        objData.IdCapacidad = vehicleData.IdCapacidad;
        objData.Capacidad = vehicleData.Capacidad;
        objData.PorcientoRecargoVenta = vehicleData.PorcientoRecargoVenta;
        objData.IdTipoCombustible = vehicleData.IdTipoCombustible;
        objData.TipoCombustible = vehicleData.TipoCombustible;
        objData.IdMarca = vehicleData.IdMarca;
        objData.Idmodelo = vehicleData.Idmodelo;
        objData.Idano = vehicleData.Idano;


        vehicleListData.push(objData);
    });

    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/SaveDataCotizarReno",
        data: { jsoVhnData: JSON.stringify(vehicleListData), jsonQtData: JSON.stringify(quotData) },
        dataType: "html",
        async: false,
        success: function (data) {

            var datav = JSON.parse(data);

            if (datav.MessageError) {
                showError([datav.MessageError]);
                return false;
            }

            $("#spQuotationNumber").text(datav.QuotationNumber);

            $("#QuotationNumber").val(datav.QuotationNumber);
            $("#quotationID").val(datav.QuotationId);
            $("#hdnDriverID").val(datav.DriverId);

            //var datav = JSON.parse(data.VehicleDataMatch);
            vdeleted = [];

        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function LoadDataClient(DataCoreCustomer, userAgenCode) {

    //Cargar Data del cliente
    var isRNC = false;

    var $FullName = $("#FullName");
    $FullName.val(DataCoreCustomer.NombreCliente);
    $FullName.parent().addClass("is-dirty");

    var $Identification = $("#Identification");
    $Identification.val(DataCoreCustomer.RNC);
    $Identification.parent().addClass("is-dirty");

    var $labelId = $Identification.parent().find("label:first");
    var Tipo = DataCoreCustomer.IdentificationType;
    $labelId.text("Numero de Identificación ({0})".replace("{0}", Tipo));

    if (Tipo == "RNC") {
        isRNC = true;
    }

    var $DateOfBirth = $("#DateOfBirth");
    $DateOfBirth.val(moment(DataCoreCustomer.FechaNacimiento).format('DD-MMM-YYYY'));
    $DateOfBirth.parent().addClass("is-dirty");

    var $Sex = $("#Sex");
    $Sex.val(DataCoreCustomer.Sexo);
    $Sex.parent().addClass("is-dirty");

    var $LicenciaExt = $("#LicenciaExt");
    $LicenciaExt.val(DataCoreCustomer.Licencia_Extranjera);
    $LicenciaExt.parent().addClass("is-dirty");

    if (isRNC) {
        $DateOfBirth.val("N/A");
        $Sex.val("N/A");
    }

    var $AgentList = $("#AgentList");
    $AgentList.find("option").each(function () {
        var $this = $(this);
        if ($this.text() == userAgenCode.FullNameAll) {
            $AgentList.val($this.val());
            $AgentList.trigger("change.select2");
            $AgentList.trigger("change");
            return false;
        }
    });

}

function LoadProspectFormData(DataCoreCustomer, userAgenCode) {

    LoadDataClient(DataCoreCustomer, userAgenCode)
}



function deleteVehicle(vehicleID) {
    $.ajax({
        type: "POST",
        url: "/CotizarRenovacion/deleteVehicle",
        data: { vehicleID: vehicleID },
        dataType: "html",
        async: false,
        success: function (data) {

            if (data.message) {
                console.log(data.message);
            } else {
                vdeleted.push(vehicleID);
            }

        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
