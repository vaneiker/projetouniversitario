﻿var rowPepTable = 0;
var rowBenefTable = 0;
var OperationResult = false;
var OperationMessage = "";
var BenefExplication = "";
var PepExplication = "";

InitializeDriver = function () {

    InizitializeControls(0);
    InitializeChosen();

    getParameterTotalPrimium();

    getDefaultCity();
    getAlertBenefRNC();

    if (GlobalIsMobile) {
        $("#AnnualIncome").inputmask('remove');
    } else {
        $("#AnnualIncome").inputmask("currency", { showMaskOnFocus: true });
    }

    if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {
        $("#dvHideWhenLeyFull").remove();
        $("#dvShowWhenLeyFull").show();
    }



    getProvinceList();

    $(document).on('change', '#City_Country_Id', function () {
        limpiarDropUbicacion('pais');
        getProvinceList();
    });

    $(document).on('change', '#City_State_Prov_Id', function () {
        $('#municipality_Id').html('');
        $('#municipality_Id').trigger("chosen:updated");

        $('#City_City_Id').html('');
        $('#City_City_Id').trigger("chosen:updated");

        var provinceID = $(this).val();
        if (provinceID == '' || provinceID == null) provinceID = 0;

        getMunicipalities(provinceID);

        if (provinceID > 0) {
            $(this).parent().removeClass('requerido');
        } else {
            $(this).parent().addClass('requerido');
        }
    });

    $(document).on('change', '#municipality_Id', function () {
        $('#City_City_Id').html('');
        $('#City_City_Id').trigger("chosen:updated");

        var municalityID = $(this).val();
        if (municalityID == null) municalityID = '';
        if (municalityID == '') {
            $(this).parent().addClass('requerido');
        } else {
            $(this).parent().removeClass('requerido');
        }

        GetSectors(municalityID);
    });
    $(document).on('change', '#City_City_Id', function () {
        var city = $(this).val();
        if (city == '') {
            $(this).parent().addClass('requerido');
        } else {
            $(this).parent().removeClass('requerido');
        }
    });
    $(document).on('change', '#Id', function () {
        var driver = $(this).val();
        getDriver(driver);

    });

    $(document).on('change', '#creditCardTypeId', function () {
        var type = $(this).val();
        if (type != '') {
            $(this).parent().removeClass('requerido');
        } else {
            if ($('#IsDomiciliation').prop('checked')) {
                $(this).parent().addClass('requerido');
            }
        }
        GetCreditCardTypeMask(type);
    });

    $(document).on('change', '#expirationDateYear', function () {
        var selectedYear = $(this).val();
        if (selectedYear != '') { selectedYear = parseInt(selectedYear) } else { selectedYear = 0; };

        if (selectedYear > 0) {
            $(this).parent().removeClass('requerido');
        } else {
            if ($('#IsDomiciliation').prop('checked')) {
                $(this).parent().addClass('requerido');
            }
        }
        getYearMonths(selectedYear);
        ValidateRequiredMonth();
    });
    $(document).on('change', '#expirationdatemonth', function () {
        ValidateRequiredMonth();
    });

    $(document).on('change', '#IsDomiciliation', function () {

        var IsChecked = $(this).prop('checked');
        if (IsChecked) {
            $("#creditCardTypeId").removeAttr('disabled');
            //$('#creditCardTypeId').trigger('chosen:updated');
            $('#creditCardTypeId').trigger('change.select2');


            $("#editCreditCard").removeAttr('disabled');
            $("#expirationDateYear").removeAttr('disabled');
            //$('#expirationDateYear').trigger('chosen:updated');
            $('#expirationDateYear').trigger('change.select2');
            $("#expirationdatemonth").removeAttr('disabled');
            //$('#expirationdatemonth').trigger('chosen:updated');
            $('#expirationdatemonth').trigger('change.select2');

            $("#cardHolder").removeAttr('disabled');
            $("#DomicileInitialPayment").removeAttr('disabled');
        } else {
            $('#creditCardTypeId').attr('disabled', 'disabled');
            //$('#creditCardTypeId').trigger('chosen:updated');
            $('#creditCardTypeId').trigger('change.select2');

            $("#creditCardNumber").attr('disabled', 'disabled');
            $("#editCreditCard").attr('disabled', 'disabled');
            $('#expirationDateYear').attr('disabled', 'disabled');
            //$('#expirationDateYear').trigger('chosen:updated');
            $('#expirationDateYear').trigger('change.select2');

            $('#expirationdatemonth').attr('disabled', 'disabled');
            //$('#expirationdatemonth').trigger('chosen:updated');
            $('#expirationdatemonth').trigger('change.select2');

            $("#cardHolder").attr('disabled', 'disabled');
            $("#DomicileInitialPayment").attr('disabled', 'disabled');
            $("#DomicileInitialPayment").prop('checked', false);
        }

        ValidateDomiciliationRequired();
    });

    $(document).on('change', '#PepFormularyOptionsId', function () { //pendiente de validar
        rowPepTable = 0;
        var $PepFormularyOptionsId = $(this);
        getRiskLevel(); //valido nivel de riesgo

        if ($('#Id').val() == '' || $('#Id').val() <= 0) {
            showError(["Debe seleccionar al menos un conductor."], "Información Incompleta");
            $PepFormularyOptionsId.val("");
            $PepFormularyOptionsId.trigger("chosen:updated");
            return false;
        } else {
            rowPepTable = 0;
            ValidateWorkingInformation();
            var Selected = $PepFormularyOptionsId.val();
            if ($('#TypeOfPerson').val() == 1 || $('#TypeOfPerson').val() == 3) {
                if (Selected != '') {
                    $PepFormularyOptionsId.parent().removeClass('requerido');
                    if (Selected != 3) {
                        $('#hdnOrigen').val('CalidadPep');
                        $('#DvPEP_BENEF').show();
                        $('#DisplayPepForm').show();
                        getPepsByDriver('true');
                    } else {
                        $('#DvPEP_BENEF').hide();
                        DeletePepsFromDataBase();
                    }
                } else
                    $PepFormularyOptionsId.parent().addClass('requerido');
            } else {
                $('#DvPEP_BENEF').hide();
            }
        }
    });
    $(document).on('change', '#IdentificationType', function () {
        isValidTheDocument();
        var selected = $(this).val();
        var numberLic = $("#IdentificationNumber");

        if (selected != '') {
            if (selected != 'RNC') {

                if ($('#DateOfBirth').val() === 'N/A') {
                    $('#DateOfBirth').val('');
                    $(".dateOfBirth.datepicker").parent().removeClass("erarequerido");
                    $(".dateOfBirth.datepicker").parent().removeClass("is-dirty");
                    $(".dateOfBirth.datepicker").parent().addClass("requerido");
                    $('#DateOfBirth').removeAttr('disabled');
                }
            } else {
                $('#DateOfBirth').val('N/A');
                $(".dateOfBirth.datepicker").parent().addClass("is-dirty");
                $(".dateOfBirth.datepicker").parent().removeClass("requerido");
                $(".dateOfBirth.datepicker").parent().addClass("erarequerido");
                $('#DateOfBirth').attr('disabled', 'disabled');
            }

            if (selected == 'RNC') {
                numberLic.inputmask("999-99999-9");
            }
            else if (selected == 'Cédula') {
                numberLic.inputmask("999-9999999-9");
            }
            else if (selected == 'Pasaporte') {
                numberLic.inputmask("remove");
            }
        }
    });

    $("#IdentificationNumber").focusout(function () {
        isValidTheDocument();
    })

    $(document).on('click', '#AddPep', function () {
        //var Selected = $('#PepFormularyOptionsId').val();
        //if (Selected != '' && Selected != 3) {
        AddPepNewRow();
        //} else {
        //    rowPepTable = 0;
        //}
    });

    $(document).on('click', '#CompletadoPep', function () {
        savePepsFormularyByDriver();
    });

    $(document).on('click', '#deletePep', function () {
        var selection = $(this);
        deletePep(selection);
    });

    $('#DisplayPepForm').on('click', function () {
        var pepSelected = $('#PepFormularyOptionsId').val();
        if (pepSelected == 3 || pepSelected == '') {
            showError(["Debe indicar que posee calidad PEP para capturar esta información"], "Advertencia");
        } else {
            rowPepTable = 0;
            $('#hdnOrigen').val('CalidadPep');
            getPepsByDriver('true');
        }
    });

    var IDDriver = $("#Id").val();
    getDriver(IDDriver);

    $(document).on('click', '#DisplayBenefForm', function () {
        getBeneficiariesByDriver('true');
        SetOnchangeEvent();
    });

    $(document).on('click', '#CancelarBenef, #CloseBenef', function () {
        ClearBeneficiaries();
    });

    $(document).on('click', '#deleteBenef', function () {
        var selection = $(this);
        deleteBenef(selection);
    });

    $(document).on('click', '#AddBenef', function () {
        var Selected = $('#IdentificationFinalBeneficiaryOptionsId').val();
        if (Selected != '' && Selected == 2) {
            AddBenefNewRow();
            SetOnchangeEvent();
        } else {
            rowBenefTable = 0;
        }
    });

    $(document).on('click', '#CompletadoBenef', function () {
        saveBeneficiary();
    });

    $(document).on('click', '#CancelarPep, #ClosePep', function () {
        ClearPeps();
    });

    getQuotation();


    $(document).on('click', '#editCreditCard', function () {

        var type = $('#creditCardTypeId').val();
        if (type == '') {
            showError(["Debe seleccionar el tipo de tarjeta de crédito"], "Domiciliación");
            return false;
        } else {
            GetCreditCardTypeMask(type);
        }
    });

    $("#PhoneNumber, #Mobile").focusout(function () {
        ValidateRequiredPhone();
        $(this).parent().addClass("is-dirty");        
    });

    $("#FirstName, #IdentificationNumber, #Address").focusout(function () {
        if ($(this).val() != '') {
            $(this).parent().removeClass('requerido');
            $(this).parent().addClass("is-dirty");
        } else {
            $(this).parent().addClass('requerido');
        }
    })

    $("#FirstSurname, #PlaceOfBirth").focusout(function () {
        if ($('#TypeOfPerson').val() == '1' || $('#TypeOfPerson').val() == '3') {
            if ($(this).val() == '') {
                $(this).parent().addClass("requerido");
            } else {
                $(this).parent().removeClass("requerido");
            }
        }
    })

    $("#QtyEmployees, #QtyPersonsDepend").focusout(function () {
        if ($(this).val() == '') {
            $(this).parent().addClass("requerido");
        } else {
            $(this).parent().removeClass("requerido");
        }

    });
    $("#creditCardNumber, #cardHolder").focusout(function () {
        var number = $(this).val();
        if (number != '') {
            $(this).parent().removeClass('requerido');
        } else {
            if ($('#IsDomiciliation').prop('checked')) {
                $(this).parent().addClass('requerido');
            }
        };
    });
    $(document).on('change', '#OwnershipStructureId', function () {
        var $this = $(this);
        var type = $this.val();
        var IdType = $('#IdentificationType').val();
        if (type == '') {
            if (IdType == 'RNC') {
                $this.parent().addClass('requerido');
            } else {
                $this.parent().removeClass('requerido');
            }
        } else {
            $this.parent().removeClass('requerido');
        }
    });

    $("#AnnualIncome").focusout(function () {
        var $this = $(this);
        if ($this.val() != '0') {
            $this.parent().removeClass("requerido");
            $this.parent().addClass("is-dirty");
        }
        ValidateWorkingInformation();
    });

    $("#Company").focusout(function () {
        if ($('#TypeOfPerson').val() == '1' || $('#TypeOfPerson').val() == '3') {
            if ($(this).val() == '') {
                $(this).parent().addClass("requerido");
            } else {
                $(this).parent().removeClass("requerido");
            }
        } else {
            $(this).parent().removeClass("requerido");
        }
    });

    $(document).on('change', '#Job', function () {
        var selected = $(this).val();
        if (selected != '') {
            $(this).parent().removeClass('requerido');
        } else {
            $(this).parent().addClass('requerido');
        }
    });


    $(".continueWithAgent").show();

    $(document).on('change', '#InvoiceTypeId', function () {
        var IdentificationType = $('#IdentificationType').val()
        var identification = $('#IdentificationNumber').val();
        if ($(this).val() == '1') {
            if (IdentificationType == 'RNC') {
                var show = urlValidationCedulaRncShow();
                if (show == 'SI')
                    dialogRncCedula(identification);
            }
        }
    });

    $(document).on('click', '#aShowPepExplication', function () {
        getPepExplication();
        $('#ppPepExplication').modal('show');
    });

    $(document).on('click', '#spanBF', function () {
        getBenefExplication('1');
        $('#ppBenefExplication').modal('show');
    });

    $('#IdentificationFinalBeneficiaryOptionsId').on('change', function () {
        var $this = $(this);
        var Selected = $this.val();
        ValidateFulfillmentInformation();
        if (Selected != '') {
            $this.parent().removeClass('requerido');
            if (Selected == 2) {
                $('#DvPEP_BENEF').show();
                getBeneficiariesByDriver('true');

            } else {
                rowBenefTable = 0;
                $('#DvPEP_BENEF').hide();
                DeleteBenefromDataBase();
            }
        } else {
            $('#DvPEP_BENEF').hide();
            if ($('#IdentificationType').val() == 'RNC')
                $this.parent().addClass('requerido')
        }
    });

    $(document).on('change', '#SocialReasonId, #OwnershipStructureId', function () {
        var $this = $(this);
        if ($this.val() != '')
            $this.parent().removeClass('requerido');
    });

    $("#WorkAddress, #WorkPhone").focusout(function () {
        var $this = $(this);

        if ($this.val() != '') {
            $this.parent().removeClass("requerido");
            $this.parent().addClass("is-dirty");
        }
        ValidateWorkingInformation();
    })

    $(document).on('change', '#TypeOfPerson', function () {
        $('#AdminPepFormularyOptionsId').val("");
        $('#AdminPepFormularyOptionsId').trigger('change.select2');
        var $IdentificationNumberValidDateO = $('#IdentificationNumberValidDateO');
        var $this = $(this);
        if ($this.val() != '') {

            $this.parent().removeClass('requerido');
            if ($this.val() != 1 && $this.val() != 3) {
                DisableWorkingInformation(false);
                ValidateWorkingInformation();
                ValidateFulfillmentInformation();

                $IdentificationNumberValidDateO.val('');
                $IdentificationNumberValidDateO.parent().removeClass('requerido');
                $IdentificationNumberValidDateO.attr('disabled', 'disabled');

                $('#PlaceOfBirth').val('');
                $('#PlaceOfBirth').parent().removeClass('requerido');
                $('#PlaceOfBirth').attr('disabled', 'disabled');

                $('#DvPEP_BENEF').hide();
                DeletePepsFromDataBase();

            } else {
                DisableWorkingInformation(true);
                if ($("#ManagerName").val() == '')
                    $("#ManagerName").parent().addClass('requerido');
                else
                    $("#ManagerName").parent().removeClass('requerido');

                $('#PlaceOfBirth').parent().addClass('requerido');
                $('#PlaceOfBirth').removeAttr('disabled');


                ValidateWorkingInformation();
                ValidateFulfillmentInformation();
                if ($IdentificationNumberValidDateO.val() == '') {
                    $IdentificationNumberValidDateO.parent().addClass('requerido');
                    $IdentificationNumberValidDateO.removeAttr('disabled');
                } else {
                    $IdentificationNumberValidDateO.parent().removeClass('requerido');
                }
            }
        }
        else
            $this.parent().addClass('requerido');
    });

    $("#ManagerName").focusout(function () {
        var $this = $(this);
        ValidateFulfillmentInformation();
        if ($this.val() == '') {
            if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3')
                $this.parent().addClass("requerido");
            else
                $this.parent().removeClass("requerido");
        } else {
            $this.parent().addClass("is-dirty");
            $this.parent().removeClass("requerido");
        }
    })

    $(document).on('change', '#AdminPepFormularyOptionsId', function () { //pendiente de validar
        rowPepTable = 0;
        $AdminPepFormularyOptionsId = $(this);

        rowPepTable = 0;
        var Selected = $AdminPepFormularyOptionsId.val();
        if (Selected != '') {
            $AdminPepFormularyOptionsId.parent().removeClass('requerido');
            if (Selected != 3) {
                $('#hdnOrigen').val('AdminPep');
                $('#AdminDisplayPepForm').show();
                getPepsByDriver('true');
            } else {
                $('#AdminDisplayPepForm').hide();
            }
        } else
            $AdminPepFormularyOptionsId.parent().addClass('requerido');
    });

    $('#AdminDisplayPepForm').on('click', function () {
        if ($('#AdminPepFormularyOptionsId').val() == '') {
            showError(['Debe indicar si el Gerente general, Administrador o Representante Legal, Posee calidad PEP o no'], 'Información de Cumplimiento');
            return false;
        }
        $('#hdnOrigen').val('AdminPep');
        getPepsByDriver('true');

    });

    $(document).on('change', '#Nationality_Global_Country_Id', function () {
        getRiskLevel();
        ValidateWorkingInformation();
    });

    $(document).on('change', '#Sex, #ForeignLicense', function () { //pendiente de validar
        var $this = $(this);

        if ($this.val() !== '') {
            $this.parent().parent().removeClass('requerido');
        }
        else {
            $this.parent().parent().addClass('requerido');
        }
    });

    frmAditionalInformationDriverValidations();

    componentHandler.upgradeAllRegistered();

    fixheight();


    if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

        var isleymode = (GlobalAppMode == "LEYMODE");
        var isfullmode = (GlobalAppMode == "FULLMODE");

        if (isleymode) {
            var fname = $("#FirstName").val();

            if (fname.toLowerCase().indexOf("defecto") != -1 || fname.toLowerCase().indexOf("prospecto") != -1) {
                $("#FirstName").val("");
                $("#FirstName").trigger("focusout");
                $("#FirstName").parent().removeClass("is-dirty");

                $("#DateOfBirth").val("");
                $('#DateOfBirth').parent().addClass('requerido');
                $("#DateOfBirth").trigger("focusout");
                $("#DateOfBirth").parent().removeClass("is-dirty");

                $("#Sex").val("");
                $("#Sex").trigger('change.select2');
                $('#Sex').parent().parent().addClass('requerido');

                $("#ForeignLicense").val("");
                $("#ForeignLicense").trigger('change.select2');
                $('#ForeignLicense').parent().parent().addClass('requerido');
            }
        }
        $("#IdentificationType").removeAttr('disabled');
    }
    else {
        $("#dvShowWhenLeyFull").remove();
        $("#DateOfBirth").datepicker("destroy");
    }

    $(".ChangeHeightOnLeyMode").css('height', 'auto');
}; /// fin de document ready

function getProvinceList() {
    $('#municipality_Id').html('');
    //$('#municipality_Id').trigger("chosen:updated");
    $('#municipality_Id').trigger("change.select2");

    $('#City_City_Id').html('');
    //$('#City_City_Id').trigger("chosen:updated");
    $('#City_City_Id').trigger("change.select2");


    $.ajax({
        url: "/Home/GetProvinces",
        dataType: 'json',
        async: false,
        data: {},
        success: function (result) {
            var $select_elem = $("#City_State_Prov_Id");
            $select_elem.empty();
            $select_elem.append('<option value=""></option>');

            $.each(result, function (idx, obj) {
                $select_elem.append('<option value="' + obj.Value + '">' + obj.name + '</option>');
            });
            $select_elem.val('');
            //$select_elem.trigger("chosen:updated");
            $select_elem.trigger("change.select2");
        }
    });
}

function getMunicipalities(provinceID) {
    $('#City_City_Id').html('');
    $('#City_City_Id').trigger("chosen:updated");
    $('#City_City_Id').trigger("change.select2");

    $.ajax({
        url: "/Home/GetMunicipalities",
        dataType: 'json',
        async: false,
        data: { provinceID: provinceID },
        success: function (result) {
            var $select_elem = $("#municipality_Id");
            $select_elem.empty();
            $select_elem.append('<option value=""></option>');

            $.each(result, function (idx, obj) {
                $select_elem.append('<option value="' + obj.Value + '">' + obj.name + '</option>');
            });
            $select_elem.trigger("chosen:updated");
            $select_elem.trigger("change.select2");
        }
    });
}

function GetSectors(municipalityID) {

    if (municipalityID == '') {
        limpiarDropUbicacion('municipio');
        return;
    }

    $.ajax({
        url: "/Home/GetSectors",
        dataType: 'json',
        async: false,
        data: { 'municipalityID': municipalityID },
        success: function (result) {
            var $select_elem = $("#City_City_Id");
            $select_elem.empty();
            $select_elem.append('<option value=""></option>');

            $.each(result, function (idx, obj) {
                $select_elem.append('<option value="' + obj.Value + '">' + obj.name + '</option>');
            });
            //$select_elem.trigger("chosen:updated");
            $select_elem.trigger("change.select2");
        }
    });
}

function limpiarDropUbicacion(origen) {

    if (origen == 'pais') {
        $("#City_State_Prov_Id").html('');
        //$("#City_State_Prov_Id").trigger("chosen:updated");
        $("#City_State_Prov_Id").trigger("change.select2");
        $("#City_State_Prov_Id").parent().addClass('requerido');

        $("#municipality_Id").html('');
        //$("#municipality_Id").trigger("chosen:updated");
        $("#municipality_Id").trigger("change.select2");
        $("#municipality_Id").parent().addClass('requerido');

        $("#City_City_Id").html('');
        //$("#City_City_Id").trigger("chosen:updated");
        $("#City_City_Id").trigger("change.select2");
        $("#City_City_Id").parent().addClass('requerido');

    } else if (origen == 'provincia') {
        $("#municipality_Id").html('');
        //$("#municipality_Id").trigger("chosen:updated");
        $("#municipality_Id").trigger("change.select2");
        $("#municipality_Id").parent().addClass('requerido');

        $("#City_City_Id").html('');
        //$("#City_City_Id").trigger("chosen:updated");
        $("#City_City_Id").trigger("change.select2");
        $("#City_City_Id").parent().addClass('requerido');
    }
    else if (origen == 'municipio') {
        $("#City_City_Id").html('');
        //$("#City_City_Id").trigger("chosen:updated");
        $("#City_City_Id").trigger("change.select2");
        $("#City_City_Id").parent().addClass('requerido');
    }
}

function getDriver(driver) {
    rowPepTable = 0;
    $.ajax({
        url: "/Home/GetDriver",
        dataType: 'json',
        async: false,
        data: { driverID: driver },
        success: function (result) {

            if (result != null) {
                $('#FirstName').val(result.FirstName);
                $('#FirstName').parent().addClass("is-dirty");
                $('#FirstName').parent().removeClass('requerido');
                $('#IsPrincipal').val(result.IsPrincipal);

                $('#FirstSurname').val(result.FirstSurname);
                $('#FirstSurname').parent().addClass("is-dirty");

                if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

                    if (result.Sex) {
                        $('#Sex').val(result.Sex);
                        $("#Sex").trigger("change.select2");
                        $("#Sex").parent().removeClass('requerido');
                    }

                    if (result.ForeignLicense !== null) {

                        if (result.ForeignLicense) {
                            $('#ForeignLicense').val("Si");
                        }
                        else {
                            $('#ForeignLicense').val("No");
                        }

                        $("#ForeignLicense").trigger("change.select2");
                        $("#ForeignLicense").parent().removeClass('requerido');
                    }

                } else {

                    $('#Sex').val(result.Sex);
                    $('#Sex').parent().addClass("is-dirty");

                    if (result.ForeignLicense) {
                        $('#ForeignLicense').val("SI");
                    }
                    else {
                        $('#ForeignLicense').val("NO");
                    }

                    $('#ForeignLicense').parent().addClass("is-dirty");
                }
                $("#IdentificationType").val(result.IdentificationType);
                //$("#IdentificationType").trigger("chosen:updated");
                $("#IdentificationType").trigger("change.select2");
                $('#IdentificationType').parent().addClass("is-dirty");

                ValidateIdentificationNumberMask();

                if (result.IdentificationNumber != '') {
                    $('#IdentificationNumber').val(result.IdentificationNumber);
                    $('#IdentificationNumber').parent().addClass("is-dirty");
                    $('#IdentificationNumber').parent().removeClass('requerido');

                    isValidTheDocument();
                } else {
                    $('#IdentificationNumber').parent().addClass('requerido');
                }

                if (result.IdentificationValidDate != "01-jan-0001") {
                    $('#IdentificationNumberValidDateO').val(result.IdentificationValidDate);
                    $('#IdentificationNumberValidDateO').parent().addClass("is-dirty");
                    $('#IdentificationNumberValidDateO').parent().removeClass("requerido");
                }


                if (result.Nationality_Global_Country_Id != null && result.Nationality_Global_Country_Id > 0) {
                    $('#Nationality_Global_Country_Id').val(result.Nationality_Global_Country_Id);
                } else {
                    $('#Nationality_Global_Country_Id').val("129"); // Republica dominicana
                }


                //$('#Nationality_Global_Country_Id').trigger("chosen:updated");
                $('#Nationality_Global_Country_Id').trigger("change.select2");
                $('#Nationality_Global_Country_Id').parent().removeClass('requerido');

                $("#PepFormularyOptionsId").val(result.PepFormularyOptionsId);
                //$("#PepFormularyOptionsId").trigger("chosen:updated");
                $("#PepFormularyOptionsId").trigger("change.select2");

                getRiskLevel();
                getProvinceList();


                $('#PostalCode').val(result.PostalCode);
                $('#PostalCode').parent().addClass("is-dirty");

                if (result.Address != null) {
                    $('#Address').val(result.Address);
                    $('#Address').parent().addClass("is-dirty");
                    $('#Address').parent().removeClass("requerido");
                } else {
                    $('#Address').parent().addClass("requerido");
                }

                $('#PhoneNumber').val(result.PhoneNumber);
                $('#PhoneNumber').parent().addClass("is-dirty");

                $('#Mobile').val(result.Mobile);
                $('#Mobile').parent().addClass("is-dirty");

                $('#WorkPhone').val(result.WorkPhone);
                $('#WorkPhone').parent().addClass("is-dirty");

                $('#Email').val(result.Email);
                $('#Email').parent().addClass("is-dirty");

                if (result.InvoiceTypeId != null && result.InvoiceTypeId > 0) {
                    $('#InvoiceTypeId').val(result.InvoiceTypeId);
                } else {
                    $('#InvoiceTypeId').val("7"); // Factura consumidor final
                }

                //$('#InvoiceTypeId').trigger("chosen:updated");
                $('#InvoiceTypeId').trigger("change.select2");
                //verifico si la ciudad que viene desde la db es la ciudad por default
                var DefaultCity = $('#hdnDefaultCityCode').val();
                if (result.City_City_Id != DefaultCity) {
                    if (result.City_State_Prov_Id != null) {
                        $("#City_State_Prov_Id").val(result.City_State_Prov_Id);
                        //$("#City_State_Prov_Id").trigger("chosen:updated");
                        $("#City_State_Prov_Id").trigger("change.select2");
                    }

                    getMunicipalities(result.City_State_Prov_Id);

                    var municipality = result.City_Domesticreg_Id + '-' + result.City_State_Prov_Id + '-' + result.municipality_Id;

                    $('#municipality_Id').val(municipality);
                    //$('#municipality_Id').trigger("chosen:updated");
                    $('#municipality_Id').trigger("change.select2");

                    GetSectors(municipality);


                    var city = result.City_Domesticreg_Id + '-' + result.City_State_Prov_Id + '-' + result.municipality_Id + '-' + result.City_City_Id;
                    $("#City_City_Id").val(city);
                    //$("#City_City_Id").trigger("chosen:updated");
                    $("#City_City_Id").trigger("change.select2");
                } else {
                    $("#City_State_Prov_Id").val('');
                    //$("#City_State_Prov_Id").trigger("chosen:updated");
                    $("#City_State_Prov_Id").trigger("change.select2");

                    $('#municipality_Id').val('');
                    //$('#municipality_Id').trigger("chosen:updated");
                    $('#municipality_Id').trigger("change.select2");

                    $("#City_City_Id").val('');
                    //$("#City_City_Id").trigger("chosen:updated");
                    $("#City_City_Id").trigger("change.select2");
                }

                ValidateUbicationRequired();


                if ($("#PepFormularyOptionsId").val() != null || $("#PepFormularyOptionsId").val() != '') {
                    $("#PepFormularyOptionsId").parent().removeClass('requerido');
                    if ($("#PepFormularyOptionsId").val() != 3) {
                        $('#DvPEP_BENEF').show();
                        $('#DisplayPepForm').show();
                    } else {
                        $('#DvPEP_BENEF').hide();
                        $('#DisplayPepForm').hide();
                    }
                } else {
                    $('#DvPEP_BENEF').hide();
                    $('#DisplayPepForm').hide();
                }


                $('#IdentificationFinalBeneficiaryOptionsId').val(result.IdentificationFinalBeneficiaryOptionsId);
                //$('#IdentificationFinalBeneficiaryOptionsId').trigger("chosen:updated");
                $('#IdentificationFinalBeneficiaryOptionsId').trigger("change.select2");

                if ($('#IdentificationFinalBeneficiaryOptionsId').val() != null || $('#IdentificationFinalBeneficiaryOptionsId').val() != '') {
                    $('#IdentificationFinalBeneficiaryOptionsId').parent().removeClass('requerido');
                    $('#DisplayBenefForm').show();
                } else {
                    $('#DisplayBenefForm').hide();
                }

                $('#SocialReasonId').val(result.SocialReasonId);
                //$('#SocialReasonId').trigger("chosen:updated");
                $('#SocialReasonId').trigger("change.select2");


                $('#OwnershipStructureId').val(result.OwnershipStructureId);
                //$('#OwnershipStructureId').trigger("chosen:updated");
                $('#OwnershipStructureId').trigger("change.select2");

                $('#Job').val(result.Job);
                //$('#Job').trigger("chosen:updated");
                $('#Job').trigger("change.select2");

                if ($('#Job').val() != '') {
                    $('#Job').parent().removeClass("requerido");
                } else {
                    $('#Job').parent().addClass("requerido");
                }

                $('#Company').val(result.Company);
                $('#Company').parent().addClass("is-dirty");

                if ($('#Company').val() != '')
                    $('#Company').parent().removeClass('requerido');


                $('#AnnualIncome').val(result.AnnualIncome);
                $('#AnnualIncome').parent().addClass("is-dirty");
                //$('#AnnualIncome').trigger("chosen:updated");
                $('#AnnualIncome').trigger("change.select2");

                if ($('#AnnualIncome').val() != '' || $('#AnnualIncome').val() != '0')
                    $('#AnnualIncome').parent().removeClass('requerido');

                $('#chkHomeOwner').prop('checked', result.Home_Owner);
                $('#TypeOfPerson').val(result.TypeOfPerson);
                $('#TypeOfPerson').trigger("change.select2");

                if ($('#TypeOfPerson').val() == '') {
                    if ($("#IdentificationType").val() != 'RNC') {
                        $('#TypeOfPerson').val('1') // si no es una empresa lo marco como persona fisica
                        $('#TypeOfPerson').trigger("change.select2");
                    } else {
                        $('#TypeOfPerson').val('2')
                        $('#TypeOfPerson').trigger("change.select2");
                    }
                }

                $('#TypeOfPerson').parent().removeClass('requerido');

                $('#ManagerName').val(result.ManagerName);
                $('#ManagerName').parent().addClass("is-dirty");

                if ($('#ManagerName').val() != '') {
                    $('#ManagerName').parent().removeClass('requerido');
                    $('#AdminPepFormularyOptionsId').val(result.ManagerPepOptionId);
                    //$('#AdminPepFormularyOptionsId').trigger('chosen:updated');
                    $('#AdminPepFormularyOptionsId').trigger('change.select2');
                }
                else {
                    $('#AdminPepFormularyOptionsId').val('');
                    //$('#AdminPepFormularyOptionsId').trigger('chosen:updated');
                    $('#AdminPepFormularyOptionsId').trigger('change.select2');

                    if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3') // persona juridica
                        $('#ManagerName').parent().addClass('requerido');
                }

                ValidateFulfillmentInformation();

                if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3') { // pregunto si es persona juridica
                    DisableWorkingInformation(false);

                    $('#DateOfBirth').val("N/A");
                    $('#DateOfBirth').parent().addClass("is-dirty");
                    $('#DateOfBirth').attr('readonly', 'readonly');
                    $("#QtyEmployeesRNC").css('display', 'block');
                    $("#chkhomeowner_Div").css('display', 'none');
                    $("#QtyPersonsDepend_Div").css('display', 'none');
                    $('#QtyPersonsDepend').val('');

                    if (result.QtyEmployees > 0) {
                        $('#QtyEmployees').val(result.QtyEmployees);
                        $('#QtyEmployees').parent().addClass('is-dirty');
                    }

                    $('#PepFormularyOptionsId').parent().removeClass('requerido');
                    $('#PepFormularyOptionsId').attr('disabled', 'disabled');
                    //$('#PepFormularyOptionsId').trigger("chosen:updated");
                    $('#PepFormularyOptionsId').trigger("change.select2");

                    if ($('#IdentificationFinalBeneficiaryOptionsId').val() == null || $('#IdentificationFinalBeneficiaryOptionsId').val() == '') {
                        $('#DvPEP_BENEF').hide();
                    } else {
                        if ($('#IdentificationFinalBeneficiaryOptionsId').val() == 5) // No
                            $('#DvPEP_BENEF').hide();
                        else {
                            $('#DvPEP_BENEF').show();
                            $('#DisplayBenefForm').show();
                        }
                    }

                    $('#FirstSurname').parent().removeClass('requerido');
                    $('#DisplayPepForm').hide();
                    getBenefPercents();

                    $('#IdentificationNumberValidDateO').val('');
                    $('#IdentificationNumberValidDateO').parent().removeClass('requerido');
                    $('#IdentificationNumberValidDateO').attr('disabled', 'disabled');

                    $('#DateOfBirth').val('');
                    $('#DateOfBirth').attr('readonly', 'readonly');
                    $('#PlaceOfBirth').parent().removeClass('requerido');
                    $('#PlaceOfBirth').attr('disabled', 'disabled');

                }
                else {
                    var realDob = moment(result.DateOfBirth).format("DD-MMM-YYYY");
                    $('#DisplayBenefForm').hide();
                    $('#DateOfBirth').val(realDob);

                    //$('#DateOfBirth').val(result.BirthDay);
                    $('#DateOfBirth').parent().addClass("is-dirty");
                    $('#DateOfBirth').attr('readonly', 'readonly');

                    $("#QtyEmployeesRNC").css('display', 'none');
                    $("#chkhomeowner_Div").css('display', 'block');
                    $("#QtyPersonsDepend_Div").css('display', 'block');
                    $('#chkHomeOwner').val(result.Home_Owner)
                    if (result.QtyPersonsDepend > 0) {
                        $('#QtyPersonsDepend').val(result.QtyPersonsDepend);
                        $('#QtyPersonsDepend').parent().addClass('is-dirty');
                        $('#QtyPersonsDepend').parent().removeClass('requerido');
                    }


                    $('#FirstSurname').parent().addClass('requerido');
                    $("#BenefPercentMin").val('');
                    $("#BenefPercentMax").val('');

                    if (result.FirstSurname != '') {
                        $('#FirstSurname').parent().removeClass('requerido');
                    } else {
                        $('#FirstSurname').parent().addClass('requerido');
                    }

                    if ($("#PepFormularyOptionsId").val() != null) {
                        if ($("#PepFormularyOptionsId").val() != '3') {
                            $('#DvPEP_BENEF').show();
                            $('#DisplayPepForm').show();
                        }
                    } else {
                        $('#DvPEP_BENEF').hide();
                        //$('#DisplayPepForm').hide();
                    }

                    $('#WorkAddress').val(result.WorkAddress);
                    $('#PlaceOfBirth').val(result.PlaceOfBirth);

                    if ($('#WorkAddress').val() != '') {
                        $('#WorkAddress').parent().removeClass('requerido');
                        $('#WorkAddress').parent().addClass('is-dirty');
                    }

                    if ($('#PlaceOfBirth').val() != '') {
                        $('#PlaceOfBirth').parent().removeClass('requerido');
                        $('#PlaceOfBirth').parent().addClass('is-dirty');
                    } else {
                        $('#PlaceOfBirth').parent().addClass('requerido');
                    }

                }

                ValidateRequiredPhone();
            } else {
                showError(["No se encontraron registros del contacto seleccionado, consulte al administrador del sistema"], "Contacto no encontrado");
            }
        },
        error: function (response) {
            showError([response.responseText], "Error buscando el Contacto");
        }
    });
}

function SetAditionalInfo() {

    if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {
        var dob = $("#DateOfBirth").val();
        if (dob === '') {
            showError(['La Fecha de Nacimiento es requerida.']);
            return false;
        }
    }

    if (!$('#FrmAditionalInformationDriver').valid()) {
        return false;
    }
    //if (!$('#FrmAditionalInformationDriver').valid()) {
    //    return false;
    //}

    var DateOfBirth = null;
    var validaIdDate = null;
    if ($('#IdentificationType').val() != 'RNC') {
        DateOfBirth = $('#DateOfBirth').val().replace('.', '');
    }
    var text = $('#IdentificationNumberValidDateO').val();
    if (text == '') {
        validaIdDate = new Date(1753, 01, 01);
    } else {
        validaIdDate = text;
    }
    var result = "";

    //var realAnualIncome = $('#AnnualIncome').val() != '' ? $('#AnnualIncome').val().replace(',', '').replace('$', '') : "";
    var realAnualIncome = $('#AnnualIncome').val().replace(/,/g, '').replace('$', '');

    var isleyorfullmode = (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE");


    var datos = {
        Id: $('#Id').val(),
        FirstName: $('#FirstName').val(),
        FirstSurname: $('#FirstSurname').val(),
        DateOfBirth: DateOfBirth,
        Sex: $('#Sex').val(),
        IdentificationType: $('#IdentificationType').val(),
        IdentificationNumber: $('#IdentificationNumber').val(),
        IdentificationNumberValidDate: validaIdDate,
        Nationality_Global_Country_Id: $('#Nationality_Global_Country_Id').val(),
        PostalCode: $('#PostalCode').val(),
        Address: $('#Address').val(),
        PhoneNumber: $('#PhoneNumber').val(),
        Mobile: $('#Mobile').val(),
        WorkPhone: $('#WorkPhone').val(),
        Email: $('#Email').val(),
        InvoiceTypeId: $('#InvoiceTypeId').val(),
        City_State_Prov_Id: $("#City_State_Prov_Id").val(),
        municipality_Id: $('#municipality_Id').val(),
        strCityID: $("#City_City_Id").val(),
        PepFormularyOptionsId: $('#PepFormularyOptionsId').val(),
        IdentificationFinalBeneficiaryOptionsId: $('#IdentificationFinalBeneficiaryOptionsId').val(),
        SocialReasonId: $('#SocialReasonId').val(),
        OwnershipStructureId: $('#OwnershipStructureId').val(),
        Job: $('#Job').val(),
        Company: $('#Company').val(),
        AnnualIncome: realAnualIncome,// $('#AnnualIncome').inputmask('remove').val(),
        IsPrincipal: $('#IsPrincipal').val(),
        Linked: "NI",
        Segment: "010000",
        Home_Owner: $('#chkHomeOwner').prop('checked'),
        QtyPersonsDepend: $('#QtyPersonsDepend').val(),
        QtyEmployees: $('#QtyEmployees').val(),
        WorkAddress: $('#WorkAddress').val(),
        PlaceOfBirth: $('#PlaceOfBirth').val(),
        TypeOfPerson: $('#TypeOfPerson').val(),
        ManagerName: $('#ManagerName').val(),
        ManagerPepOptionId: $('#AdminPepFormularyOptionsId').val(),
        ForeignLicense:
        isleyorfullmode
            ?
            $('#ForeignLicense').val() == "Si" ? true : false
            :
            null
    };


    $.ajax({
        url: "/Home/SetAditionalInformationDriver",
        dataType: 'json',
        async: false,
        data: datos,
        success: function (oresult) {
            if (oresult.result.Value == "Error") {
                OperationResult = false;
                OperationMessage = oresult.result.name;

                OperationResult = false;
                showError([OperationMessage], "Error guardando los datos adicionales del conductor")
            } else {
                OperationResult = SetDomiciliationQuotation()
                if (!OperationResult) {
                    showError([OperationMessage], "Error guardando los datos de la domiciliación")
                }
                ClearPeps();
            }
        },
        error: function (ex) {
            OperationResult = false;
            OperationMessage = ex.name;
        }
    });

    return OperationResult;
}

function GetCreditCardTypeMask(creditCardTypeId) {
    $('#creditCardNumber').val('');

    if (creditCardTypeId != null && creditCardTypeId > 0) {
        if (creditCardTypeId == 2) {
            $('#creditCardNumber').inputmask('9999-999999-99999');
        } else {
            $('#creditCardNumber').inputmask('9999-9999-9999-9999');
        }
        $('#creditCardNumber').removeAttr('disabled');
        $('#creditCardNumber').parent().addClass('is-dirty');
    }
}

function getYearMonths() {
    var expirationDateYear = $('#expirationDateYear').val();

    var actualDate = new Date();
    var ActualMonth = actualDate.getMonth() + 1;
    var ActualYear = actualDate.getFullYear();

    var InitialMonth = 1;
    if (expirationDateYear == ActualYear) {
        InitialMonth = ActualMonth;
    }
    var $select_elem = $("#expirationdatemonth");
    $select_elem.empty();
    $select_elem.append('<option value=""></option>');

    if (expirationDateYear != '') {
        for (i = InitialMonth; i <= 12; i++) {
            $select_elem.append('<option value="' + i + '">' + i + '</option>');
        }
    }
    //$select_elem.trigger("chosen:updated");
    $select_elem.trigger("change.select2");
}

function SetDomiciliationQuotation() {
    var result = "";
    var datos = {
        Credit_Card_Type_Id: $('#creditCardTypeId').val(),
        Credit_Card_Number: $('#creditCardNumber').val(),
        Expiration_Date_Year: $('#expirationDateYear').val(),
        Expiration_Date_Month: $('#expirationdatemonth').val(),
        Card_Holder: $('#cardHolder').val(),
        Domiciliation: $('#IsDomiciliation').prop('checked'),
        DomicileInitialPayment: $('#DomicileInitialPayment').prop('checked')
    };

    $.ajax({
        url: "/Home/SetDomiciliationQuotation",
        dataType: 'json',
        async: false,
        data: datos,
        success: function (oresult) {
            if (oresult.result.Value == "Error") {
                OperationResult = false;
                OperationMessage = oresult.result.name;
                return false;
            } else {

                OperationResult = true;
            }

            $('#creditCardNumber').inputmask('remove');
            $('#creditCardNumber').val(oresult.Credit_Card_Number);
            $('#creditCardNumber').attr('disabled', 'disabled');
            result = oresult.Value;
        },
        error: function (ex) {
            OperationResult = false;
            OperationMessage = ex.result.name;
        }
    });

    return OperationResult;
}

function getPepNewRow() {
    var row = "";
    var dropDown = "";
    var $pepOptions = $('#PepFormularyOptionsId');

    if ($pepOptions.val() == 1 || $('#AdminPepFormularyOptionsId').val() == 1) {
        dropDown = "<select id='RelationshipIdPep' name='RelationshipIdPep' class='RelationshipIdPep errorBorder form-control' disabled='disabled' style='width: 113px;'><option value=''>Seleccione</option>";
    } else {
        dropDown = "<select id='RelationshipIdPep' name='RelationshipIdPep' class='RelationshipIdPep errorBorder form-control' style='width: 113px;'><option value=''>Seleccione</option>";
    }

    var relationsShips = getRelationShip();
    dropDown += relationsShips;
    dropDown += "</select>";


    row += '<tr>';
    row += "<td align='center' class='font-weight-bold' rowID='" + rowPepTable + "'>" + rowPepTable + "</td>"; //columna 1
    row += "<td align='center'><input type='hidden' id='hdnBenefId' value='' />"; //columna rowPepTable

    if ($pepOptions.val() == 1) { // si es designado, le agrego el mismo nombre del cliente al textbox de nombre
        var CustomerFullName = $("#FirstName").val() + " " + $('#FirstSurname').val();
        row += "<input type='text' id='fullNamePep' name='fullNamePep' class='noWeirdChar  form-control' value='" + CustomerFullName + "' style='width: 202px;'>";
    } else if ($('#AdminPepFormularyOptionsId').val() == 1) { // si el generente tiene pep designado, le agrego el mismo nombre del gerente al textbox de nombre
        row += "<input type='text' id='fullNamePep' name='fullNamePep' class='noWeirdChar  form-control' value='" + $("#ManagerName").val() + "' style='width: 202px;'>";
    } else {
        row += "<input type='text' id='fullNamePep' name='fullNamePep' class='noWeirdChar  form-control' style='width: 202px;'>";
    }

    row += "</td>";

    row += "<td>"; // columna 3
    row += dropDown;
    row += "</td>";

    row += "<td align='center'>"; //columna 4
    row += "<input type='text' id='PositionPep' name='PositionPep' class='noWeirdChar errorBorder  form-control'>";
    row += '</td>';

    row += "<td align='center'>"; //columna 5
    row += "<input type='number' class='fromYear  form-control' id='fromYear' name='fromYear'>";
    row += '</td>';

    row += "<td align='center'>"; //columna 6
    row += "<input type='number' id='toYear' name='toYear' class=' form-control'>";
    row += '</td>';

    row += "<td align='center'>"; //columna 7
    row += "<button id='deletePep' class='mdl-button mdl-js-button mdl-button--icon mdl-button--colored'>'<i class='material-icons text-danger'>&#xE872;</i></button>";
    row += '</td>';

    row += '</tr>';

    return row;
}

function getPepExplication() {

    $.ajax({
        url: "/Home/ShowPepExplication",
        dataType: 'json',

        data: {},
        success: function (result) {
            PepExplication = result
            $('#PepExplication').html(result);
            $('#PepExplication2').html(result);
        }
    });
}

function getRelationShip() {
    var options = "";
    $.ajax({
        url: "/Home/GetRelationShip",
        dataType: 'json',
        async: false,
        data: {},
        success: function (result) {
            $.each(result, function (idx, obj) {
                options += '<option value="' + obj.Value + '">' + obj.name + '</option>';
            });
        }
    });

    return options;
}


function ShowPepExplication(ShowEmplication) {
    var HasEmptyRow = false;
    var table = $('#PepTable').find('tbody');

    rowPepTable += 1;

    if (ShowEmplication == 'true') {
        getPepExplication();
    }
    var row = getPepNewRow();

    table.append(row);

    //$('#ppPep').modal('show');
    $('#ppPep').modal({ backdrop: 'static', keyboard: false, show: true });
}

function AddPepNewRow(IsAddingNewRow) {
    var HasEmptyRow = false;
    var table = $('#PepTable').find('tbody');

    //valido si la tabla ya tiene rows vacios para no agregarle mas
    table.find('tr').each(function () {
        var $tds = $(this).find('td');
        var Id = $tds.eq(0).text();
        var nombre = $tds.eq(1).find('#fullNamePep').val();
        var relationShipID = $tds.eq(2).find('#RelationshipIdPep').val();
        var relationShipDisabled = $tds.eq(2).find('#RelationshipIdPep').prop('disabled');
        var position = $tds.eq(3).find('#PositionPep').val();
        var fromYear = $tds.eq(4).find('#fromYear').val();
        var toyear = $tds.eq(5).find('#toYear').val();
        if (!relationShipDisabled) {
            if (relationShipID == "" && position == "" && fromYear == "" && toyear == "") {
                HasEmptyRow = true;
            }
        } else {
            if (position == "" && fromYear == "" && toyear == "") {
                HasEmptyRow = true;
            }
        }
    });

    if (!HasEmptyRow) {
        rowPepTable += 1;
        var row = getPepNewRow();

        table.append(row);
        //$('#ppPep').modal('show');
        $('#ppPep').modal({ backdrop: 'static', keyboard: false, show: true });
    }
}

function savePepsFormularyByDriver() {
    var HasError = false;
    var pepsformulary = [];
    var $pepOptions = $('#PepFormularyOptionsId');
    var table = $("#PepTable").find('tbody');

    table.find('tr').each(function () {
        var $tds = $(this).find('td');
        var Id = $tds.eq(0).text();
        var nombre = $tds.eq(1).find('#fullNamePep').val();
        var benefId = $tds.eq(1).find('#hdnBenefId').val();
        var relationShipID = $tds.eq(2).find('#RelationshipIdPep').val();
        var relationShipDisabled = $tds.eq(2).find('#RelationshipIdPep').prop('disabled');
        var position = $tds.eq(3).find('#PositionPep').val();
        var fromYear = $tds.eq(4).find('#fromYear').val();
        var toyear = $tds.eq(5).find('#toYear').val();

        if (nombre == '') {
            HasError = true;
            showError(["El Nombre Completo es requerido."], "Información Incompleta:");
            return false;
        }
        //if ($pepOptions.val() != 1) { // pregunto si no es un PEP designado para que no valide el parentesco como requerido
        //    if (relationShipID == '') {
        //        HasError = true;
        //        showError(["El Parentezco es requerido."], "Información Incompleta");
        //        return false;
        //    }
        //}

        if (!relationShipDisabled) {
            if (relationShipID == '') {
                HasError = true;
                showError(["Debe indicar el Parentezco de " + nombre], "Información Incompleta");
                return false;
            }
        }


        if (position == '') {
            HasError = true;
            showError(["Debe indicar la Posición y/o Cargo de " + nombre], "Información Incompleta");
            return false;
        }

        if ($('#Id').val() == '' || $('#Id').val() <= 0) {
            HasError = true;
            showError(["Debe seleccionar al menos un conductor."], "Información Incompleta");
            return false;
        }

        if (fromYear != '' && toyear != '') {
            fromYear = parseFloat(fromYear);
            toyear = parseFloat(toyear);
            if (fromYear > toyear) {
                HasError = true;
                showError(["El Año Desde no puede ser mayor que el Año Hasta."], "Rango de año incorrecto");
                return false;
            }
        }

        var pep = {};
        pep.Id = 0;
        pep.PersonsID = $('#Id').val();
        pep.name = nombre;
        pep.RelationshipId = relationShipID;
        pep.Position = position;
        pep.FromYear = fromYear;

        if ($('#hdnOrigen').val() == 'CalidadPep')
            pep.IsPepManagerCompany = 0
        else
            pep.IsPepManagerCompany = 1;

        pep.ToYear = toyear;
        pep.BeneficiaryId = benefId;
        pepsformulary.push(pep);
    });

    if (pepsformulary.length <= 0) {
        var pep = {};
        pep.PersonsID = $('#Id').val();
        pepsformulary.push(pep);
    }

    if (!HasError) {
        $.ajax({
            url: "/Home/SetPepsFormularyDriver",
            dataType: 'json',
            data: { pep: JSON.stringify(pepsformulary) },
            success: function (result) {
                rowPepTable = 0;
                $('#DisplayPepForm').show();
                $('#ppPep').modal('hide');
                if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3') {
                    $('#DisplayBenefForm').show();
                } else { $('#DisplayBenefForm').hide(); }
            },
            error: function (ex) {
                showError([ex.name], "Error guardando los datos de PEP");
            }

        });
    } else {
        rowPepTable = 0;
    }
}

function deletePep(selected) {
    rowPepTable -= 1;
    $(selected).closest('tr').remove();
}

function getPepsByDriver(IsFromButton) {
    var table = $("#PepTable").find('tbody');
    table.empty();
    if (IsFromButton == 'true') {
        getPepExplication();
    }
    var driver = $('#Id').val();
    var source = $('#hdnOrigen').val();
    $.ajax({
        url: "/Home/getPepsFormularyByDriver",
        dataType: 'json',
        data: { driverID: driver, Source: source },
        success: function (result) {
            if (result.length > 0) {
                if (IsFromButton == 'true') {
                    $.each(result, function (idx, obj) {
                        if (rowPepTable != result.length) {
                            ShowPepExplication('false');
                        }
                    });

                    var table = $("#PepTable").find('tbody');
                    $.each(result, function (idx, obj) {
                        table.find('tr').each(function () {
                            var $tds = $(this).find('td');
                            var Id = $tds.eq(0).text();

                            if (Id == obj.Id) {
                                //if (obj.PepFormularyOptionsId == 1)
                                //    $tds.eq(1).find('#fullNamePep').val(obj.name);

                                $tds.eq(1).find('#fullNamePep').val(obj.name);

                                $tds.eq(1).find('#hdnBenefId').val(obj.BeneficiaryId);
                                if (obj.PepFormularyOptionsId == 1 || $('#AdminPepFormularyOptionsId').val() == '1') { //pregunto si el tipo de pep es: Si, Designado para deshabilitar el campo de parentesco
                                    $tds.eq(2).find('#RelationshipIdPep').prop('disabled', true);
                                }

                                $tds.eq(2).find('#RelationshipIdPep').val(obj.RelationshipId);

                                $tds.eq(3).find('#PositionPep').val(obj.Position);
                                $tds.eq(4).find('#fromYear').val(obj.FromYear);
                                $tds.eq(5).find('#toYear').val(obj.ToYear);

                            }
                        });
                    });
                }
            } else {
                AddPepNewRow();
            }

        }
    });
};

function ClearPeps() {
    rowPepTable = 0;
    var table = $('#PepTable').find('tbody');
    table.empty();

    $('#ppPep').modal('hide');
}


// PROCESAMIENTO DE BENEFICIARIOS
function ShowBenefExplication(ShowEmplication) {

    var table = $('#BenefTable').find('tbody');
    rowBenefTable += 1;

    if (ShowEmplication == 'true') {
        getBenefExplication();
    }
    var row = getBenefNewRow();

    table.append(row);

    //$('#ppBenef').modal('show');
    $('#ppBenef').modal({ backdrop: 'static', keyboard: false, show: true });
}

function AddBenefNewRow() {
    var table = $('#BenefTable').find('tbody');
    var HasEmptyRows = false;
    table.find('tr').each(function () {
        var $tds = $(this).find('td');
        var Id = $tds.eq(0).text();
        var nombre = $tds.eq(1).find('#fullNameBenef').val();
        var percentage = $tds.eq(2).find('#PercentageParticipation').val();
        percentage = parseInt(percentage);

        if (nombre == "" && (percentage == "" || percentage == 0)) {
            HasEmptyRows = true;
        }
    });

    if (!HasEmptyRows) {
        rowBenefTable += 1;
        var row = getBenefNewRow();
        table.append(row);
        $('#ppBenef').modal({ backdrop: 'static', keyboard: false, show: true });
    }
}

function getBeneficiariesByDriver(IsFromButton) {

    //if (IsFromButton == 'true') {
    getBenefExplication('2');
    //}
    var driver = $('#Id').val();
    $.ajax({
        url: "/Home/getBeneficiariesByDriver",
        dataType: 'json',
        data: { driverID: driver },
        success: function (result) {

            if (result.length > 0) {
                if (IsFromButton == 'true') {
                    $.each(result, function (idx, obj) {
                        ShowBenefExplication('false');
                    });

                    var table = $("#BenefTable").find('tbody');
                    $.each(result, function (idx, obj) {

                        table.find('tr').each(function () {
                            var $tds = $(this).find('td');
                            var Id = $tds.eq(0).text();

                            if (Id == obj.Id) {
                                $tds.eq(1).find('#fullNameBenef').val(obj.name);
                                $tds.eq(2).find('#PercentageParticipation').val(obj.percentageParticipation);
                                //$tds.eq(3).find('#IsPEP').attr('checked', obj.isPEP);
                                //$tds.eq(4).find('#PepOptionIDBenef').val(obj.pepFormularyOptionsId);
                                var TipoId = obj.IdentificationTypeId;

                                switch (TipoId) {
                                    case "1":
                                        $tds.eq(3).find('#IdentificationTypeBenef').val('Cédula');
                                        break;
                                    case "5":
                                        $tds.eq(3).find('#IdentificationTypeBenef').val('RNC');
                                        break;
                                    case "2":
                                        $tds.eq(3).find('#IdentificationTypeBenef').val('Pasaporte');
                                        break;
                                    case "3":
                                        $tds.eq(3).find('#IdentificationTypeBenef').val('Licencia');
                                        break;
                                }

                                $tds.eq(4).find('#txtIdentificationBenef').val(obj.IdentificationNumber);
                                if (obj.IdentificationNumber != null && obj.IdentificationNumber != '')
                                    $tds.eq(4).find('#txtIdentificationBenef').removeAttr('disabled');
                                $tds.eq(5).find('#NationalityBenef').val(obj.NationalityCountryId);
                            }
                        });
                    });
                }
            } else {
                AddBenefNewRow();
            }

            SetOnchangeEvent();
        }
    });
};

function deleteBenef(selected) {
    $(selected).closest('tr').remove();
    rowBenefTable -= 1;
    VerifyExistRNC();
}

function saveBeneficiary() {

    var Beneficiaries = [];
    var HasError = false;
    var min = $("#BenefPercentMin").val();
    var max = $("#BenefPercentMax").val();
    var table = $("#BenefTable").find('tbody');

    table.find('tr').each(function () {
        var $tds = $(this).find('td');
        var BenefId = $tds.eq(0).text();
        var nombre = $tds.eq(1).find('#fullNameBenef').val();
        var percentage = $tds.eq(2).find('#PercentageParticipation').val();
        //var IsPep = $tds.eq(3).find('#IsPEP').prop('checked');
        //var tipoPep = $tds.eq(4).find('#PepOptionIDBenef').val();
        var IdentificationTypeId = $tds.eq(3).find('#IdentificationTypeBenef').val();
        var IdentificationTypeNumber = $tds.eq(4).find('#txtIdentificationBenef').val();
        var NationalityCountryId = $tds.eq(5).find('#NationalityBenef').val();


        min = parseInt(min);
        max = parseInt(max);

        if (nombre == '') {
            HasError = true;
            showError(["Debe indicar el nombre del beneficiario"], "Información Incompleta:");
            return false;
        }

        if (percentage == '' || percentage == null) {
            HasError = true;
            showError(["Debe indicar el porcentaje del beneficiario"], "Información Incompleta");
            return false;
        }
        percentage = parseInt(percentage);

        if ($('#Id').val() == '' || $('#Id').val() <= 0) {
            HasError = true;
            showError(["Debe seleccionar al menos un conductor."], "Información Incompleta");
            return false;
        }
        var msgPercent = "El Porcentaje debe estar en el rango de " + min + " a " + max + ".";
        if (percentage < min) {
            HasError = true;
            showError([msgPercent], "Porcentaje Incorrecto");
            return false;
        }

        if (percentage > max) {
            HasError = true;
            showError([msgPercent], "Porcentaje Incorrecto");
            return false;
        }
        //if (IsPep) {
        //    if (tipoPep == '' || tipoPep == null) {
        //        HasError = true;
        //        showError(["Delebe seleccionar el tipo de PEP de " + nombre], "Información incompleta");
        //        return false;
        //    }
        //}

        if (IdentificationTypeId == null || IdentificationTypeId == '') {
            HasError = true;
            showError(["Delebe seleccionar el tipo de Identificación de " + nombre], "Información incompleta");
            return false;
        }

        if (IdentificationTypeNumber == null || IdentificationTypeNumber == '') {
            HasError = true;
            showError(["Delebe indicar el número de Identificación de " + nombre], "Información incompleta");
            return false;
        }

        if (NationalityCountryId == null || NationalityCountryId == '') {
            HasError = true;
            showError(["Delebe indicar la nacionalidad de " + nombre], "Información incompleta");
            return false;
        }

        var benef = {};
        benef.Id = BenefId;
        benef.personsID = $('#Id').val();
        benef.name = nombre;
        benef.percentageParticipation = percentage;
        //benef.IsPEP = IsPep;
        //benef.pepFormularyOptionsId = tipoPep;
        benef.IdentificationTypeId = IdentificationTypeId;
        benef.IdentificationNumber = IdentificationTypeNumber;
        benef.NationalityCountryId = NationalityCountryId;

        Beneficiaries.push(benef);
    });

    if (Beneficiaries.length <= 0) {
        var benef = {};
        benef.personsID = $('#Id').val();
        Beneficiaries.push(benef);
    }

    if (!HasError) {
        $.ajax({
            url: "/Home/SetDriverBeneficiaries",
            dataType: 'json',
            data: { beneficiaries: JSON.stringify(Beneficiaries) },
            success: function (result) {
                $('#DisplayBenefForm').show();
                ClearBeneficiaries();
                if (result.HasPep) {
                    var $DropDownPep = $('#PepFormularyOptionsId');
                    $DropDownPep.val('2');
                    //$DropDownPep.trigger('chosen:updated');
                    $DropDownPep.trigger('change.select2');
                    $('#DvPEP_BENEF').show();
                    $('#DisplayPepForm').show();
                    $('#hdnOrigen').val('CalidadPep');
                    getPepsByDriver('true');
                }
            },
            error: function (ex) {
                showError([ex.name], "Error guardando los beneficiarios");
            }
        });
    } else {
        rowBenefTable = 0;
    }
}

function getBenefExplication(Orgin) {
    if (Orgin == null)
        Orgin = "";

    $.ajax({
        url: "/Home/ShowBenefExplication",
        dataType: 'json',
        data: { pOrgin: Orgin },
        success: function (result) {
            BenefExplication = "<p>" + result; +"</p>";
            $('#BenefExplication').html(BenefExplication);
            $('#BenefExplication2').html(BenefExplication);
        }
    });
}

function getBenefNewRow() {
    var dropDown = "<select id='PepOptionIDBenef' name='PepOptionIDBenef' class='PepOptionIDBenef form-control' style='width: 130px;'><option value=''>Seleccione</option>";
    var $PepOptions = $("#PepFormularyOptionsId");
    $PepOptions.find("option").each(function () {
        var $this = $(this);
        if ($this.text() != "No" && $this.text() != "") {
            dropDown += '<option value="' + $this.val() + '">' + $this.text() + '</option>';
        }
    });

    dropDown += "</select>"
    dropDown = "<select id='IdentificationTypeBenef' name='IdentificationTypeBenef' class='PepOptionIDBenef form-control' style='width: 130px;'><option value=''>Seleccione</option>";
    var $IdentificationTypes = $("#IdentificationType");
    $IdentificationTypes.find("option").each(function () {
        var $this = $(this);
        if ($this.text() != "" && $this.text() != "Licencia") {
            dropDown += '<option value="' + $this.val() + '">' + $this.text() + '</option>';
        }
    });
    dropDown += "</select>"

    var row = "";

    row += '<tr>';

    row += "<td align='center' class='font-weight-bold' rowID='" + rowBenefTable + "'>" + rowBenefTable + "</td>"; //columna 1
    row += "<td align='center'>"; //columna 2
    row += "<input type='text' id='fullNameBenef' name='fullNameBenef' class='noWeirdChar form-control' style='width: 200px;'>";
    row += "</td>";

    row += "<td>"; //columna 3
    row += "<input type='number' id='PercentageParticipation' name='PercentageParticipation' class=' form-control'>";
    row += '</td>';

    //row += "<td>"; //columna 4
    //row += "<input type='checkbox' id='IsPEP' name='IsPEP' class='fl mT5'>";
    //row += '</td>';

    //row += "<td>"; //columna 5 estas columna y la siguiente se indico quitar, las comento por si mandan a activarlo nuevamente
    //row += dropDown;
    //row += '</td>';

    //row += "<td >"; //columna 6
    //row += "<button id='deleteBenef' class='mdl-button mdl-js-button mdl-button--icon mdl-button--colored'>'<i class='material-icons text-danger'>&#xE872;</i></button>";
    //row += '</td>';

    row += "<td>"; //columna 7 tipo identificacin
    row += dropDown;
    row += '</td>';

    row += "<td align='center'>"; //columna 8 identificacion
    row += "<input class='noWeirdChar form-control' disabled='disabled' type='text' id='txtIdentificationBenef' name='txtIdentificationBenef' style='width: 120px;'>";
    row += "</td>";

    //Llenando la nacionalidad
    dropDown = "<select id='NationalityBenef' name='NationalityBenef' class='chosen-select-deselect form-control' style='width: 220px; font-size: 10px !important;'><option value=''>Seleccione</option>";
    var $Nationalities = $("#Nationality_Global_Country_Id");
    $Nationalities.find("option").each(function () {
        var $this = $(this);
        if ($this.text() != "") {
            if ($this.val() == "129")
                dropDown += '<option selected="selected" value="' + $this.val() + '">' + $this.text() + '</option>';
            else
                dropDown += '<option value="' + $this.val() + '">' + $this.text() + '</option>';
        }
    });
    dropDown += "</select>"
    //Fin llenado Nacionalidad

    row += "<td align='center'>"; //columna 9 nacionalidad
    row += dropDown;
    row += "</td>";

    row += "<td >"; //columna 10
    row += "<button id='deleteBenef' class='mdl-button mdl-js-button mdl-button--icon mdl-button--colored'>'<i class='material-icons text-danger'>&#xE872;</i></button>";
    row += '</td>';

    row += '</tr>';
    return row;
}
function ClearBeneficiaries() {
    rowBenefTable = 0;
    var table = $('#BenefTable').find('tbody');
    table.empty();

    $('#ppBenef').modal('hide');
}

function getQuotation() {
    $.ajax({
        url: "/Home/GetQuotationData",
        dataType: 'json',
        data: {},
        success: function (result) {
            var totalPrimiumQuotation = parseFloat(result.TotalPrime + result.TotalISC);
            $("#QuotationTotalPrimium").val(totalPrimiumQuotation);
            ValidateWorkingInformation();

            //valido si es full
            if (result.SendInspectionOnly) {
                $('#IsFull').val('true');

                if ($('#IdentificationNumberValidDateO').val() == '') {
                    $('#IdentificationNumberValidDateO').parent().addClass('requerido');
                } else {
                    $('#IdentificationNumberValidDateO').parent().removeClass('requerido');
                }
            } else {
                $('#IsFull').val('false');
                $('#IdentificationNumberValidDateO').parent().removeClass('requerido');
            }
            if ($('#IdentificationType').val() == 'RNC') {
                $('#IdentificationNumberValidDateO').val('');
                $('#IdentificationNumberValidDateO').parent().removeClass('requerido');
                $('#IdentificationNumberValidDateO').attr('disabled', 'disabled');
                $('#PlaceOfBirth').parent().removeClass('requerido');
                $('#PlaceOfBirth').attr('disabled', 'disabled');
            }


            $('#DomicileInitialPayment').attr('checked', result.DomicileInitialPayment);

            if (result.Financed) {
                var financed = true;
                $('#IsFinanced').val('true');
            } else {
                var financed = false;
                $('#IsFinanced').val('false');
            }

            if (financed) {
                $('#DvInfoFinancing').css('display', 'block');
                $('#IsDomiciliation').attr('checked', true);
                $('#IsDomiciliation').attr('disabled', 'disabled');


                if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3') {
                    if ($("#QtyEmployees").val() == '') {
                        $("#QtyEmployees").parent().addClass('requerido');
                        $("#QtyPersonsDepend").parent().removeClass('requerido');
                    }
                } else {
                    if ($("#QtyPersonsDepend").val() == '') {
                        $("#QtyPersonsDepend").parent().addClass('requerido');
                        $("#QtyEmployees").parent().removeClass('requerido');
                    }
                }

                $('#creditCardTypeId').val(result.Credit_Card_Type_Id);
                //$('#creditCardTypeId').trigger("chosen:updated");
                $('#creditCardTypeId').trigger("change.select2");


                $('#creditCardNumber').inputmask('remove');
                $('#creditCardNumber').val(result.Credit_Card_Number_Key);
                $('#creditCardNumber').parent().addClass("is-dirty");

                $('#expirationDateYear').val(result.Expiration_Date_Year);
                //$('#expirationDateYear').trigger("chosen:updated");
                $('#expirationDateYear').trigger('change.select2');

                getYearMonths();

                $('#expirationdatemonth').val(result.Expiration_Date_Month);
                //$('#expirationdatemonth').trigger("chosen:updated");
                $('#expirationdatemonth').trigger("change.select2");

                $('#cardHolder').val(result.Card_Holder);
                $('#cardHolder').parent().addClass("is-dirty");

                $('#DomicileInitialPayment').attr('disabled', 'disabled');
                $('#DomicileInitialPayment').prop('checked', false);

                ValidateDomiciliationRequired();

            } else {
                $('#DvInfoFinancing').hide();
                $('#IsDomiciliation').removeAttr('disabled');
                $('#IsDomiciliation').attr('checked', true);

                $('#creditCardTypeId').val(result.Credit_Card_Type_Id);
                //$('#creditCardTypeId').trigger("chosen:updated");
                $('#creditCardTypeId').trigger("change.select2");

                $('#creditCardNumber').inputmask('remove');
                $('#creditCardNumber').val(result.Credit_Card_Number_Key);
                $('#creditCardNumber').parent().addClass("is-dirty");

                $('#expirationDateYear').val(result.Expiration_Date_Year);
                //$('#expirationDateYear').trigger("chosen:updated");
                $('#expirationDateYear').trigger('change.select2');

                getYearMonths();

                $('#expirationdatemonth').val(result.Expiration_Date_Month);
                //$('#expirationdatemonth').trigger("chosen:updated");
                $('#expirationdatemonth').trigger("change.select2");

                $('#cardHolder').val(result.Card_Holder);
                $('#DomicileInitialPayment').removeAttr('disabled');
                ValidateDomiciliationRequired();
            }
        },
        error: function (ex) {
            showError([ex.name], "Error buscando la cotización");
        }
    });
}

function isValidTheDocument() {
    var pass = false;
    var DocumentType = $("#IdentificationType").val()
    var Number = $('#IdentificationNumber').val();
    if (DocumentType != '' && DocumentType != 'Pasaporte' && Number != '') {

        var messageError = "";

        if (DocumentType == 'Cédula' || DocumentType == 'Licencia') {
            DocumentType = 'Cedula';
        }
        else if (DocumentType == 'RNC') {
            DocumentType = 'Rnc';
        }

        var noQuot = $('#QuotationNumber').val(); //quotationNumber

        $.ajax({
            url: '/Home/DocumentValidator',
            data: { Number: Number, DocumentType: DocumentType, noQuot: noQuot },
            dataType: 'json',
            success: function (data) {

                if (data === true) {
                    $("#SaveAditionalInfoDriver").removeAttr("disabled");
                    $("#license").removeClass("errorBorder");
                    //self.documetInvalid(false);

                    pass = true;
                }
                else {
                    $('#SaveAditionalInfoDriver').attr('disabled', 'disabled');
                    messageError = "El Número de Identificación '" + Number + "' no es valido, por favor verifique.";
                    //$("#continueToVehicle").attr("disabled", "disabled");
                    $("#IdentificationNumber").addClass("errorBorder");
                    //self.documetInvalid(true);

                    showError([messageError], 'Validando Número de Identificación');
                    pass = false;
                }
            }
        });
    }

    return pass;
}

function ValidateRequiredPhone() {
    if ($("#PhoneNumber").val() == '' && $("#Mobile").val() == '') { // && $("#WorkPhone").val() == '') {
        $("#PhoneNumber").parent().addClass('requerido');
        $("#Mobile").parent().addClass('requerido');
        //$("#WorkPhone").parent().addClass('requerido');
    }
    else {
        $("#PhoneNumber").parent().removeClass('requerido');
        $("#Mobile").parent().removeClass('requerido');
        //$("#WorkPhone").parent().removeClass('requerido');
    }
}

function getBenefPercents() {
    $.ajax({
        url: '/Home/getBeneficiaryPercents',
        dataType: 'json',
        success: function (result) {
            $("#BenefPercentMin").val(result.Value);
            $("#BenefPercentMax").val(result.name);
        }
    });
}
function ValidateRequiredMonth() {
    var selected = $('#expirationdatemonth').val();

    if (selected != '') {
        $('#expirationdatemonth').parent().removeClass('requerido');
    } else {
        if ($('#IsDomiciliation').prop('checked')) {
            $('#expirationdatemonth').parent().addClass('requerido');
        }
    }
}

function SaveAditionalInfoDriver() {

    if (!$('#FrmAditionalInformationDriver').valid()) {
        return false;
    }
    var IsDomiciliation = $('#IsDomiciliation').prop('checked');
    var result = "";
    var QuoId = $(this).attr("data");
    SetAditionalInfo(); //datos del contacto
    if (OperationResult) {
        //valido primero si lleva domiciliacion para no mandar a guarda la misma
        if (IsDomiciliation) {
            SetDomiciliationQuotation(QuoId); // datos de la domiciliacion

            //valido si no huvo error guardando la domiciliacion
            if (!OperationResult) {
                showError([OperationMessage], "Información Incompleta");
            }
        }
    } else {
        showError([OperationMessage], "Error guardando los datos");
    }

    if (!OperationResult) {
        showError([OperationMessage], "Información Incompleta");
    }

    //result = SetDomiciliationQuotation(QuoId); // datos de la domiciliacion
    return OperationResult;
}

function ValidateDomiciliationRequired() {
    var IsDomiciliation = $('#IsDomiciliation').prop('checked');

    if (IsDomiciliation) {
        if ($('#creditCardTypeId').val() == null) {
            $('#creditCardTypeId').parent().addClass('requerido');
        } else {
            $('#creditCardTypeId').parent().removeClass('requerido');

        }

        if ($('#creditCardNumber').val() == '') {
            $('#creditCardNumber').parent().addClass('requerido');
            $('#creditCardNumber').parent().removeClass("is-dirty");
        } else {
            $('#creditCardNumber').parent().removeClass('requerido');
            $('#creditCardNumber').parent().addClass("is-dirty");
        }

        if ($('#expirationDateYear').val() == null) {
            $('#expirationDateYear').parent().addClass('requerido');
        } else {
            $('#expirationDateYear').parent().removeClass('requerido');
        }

        if ($('#expirationdatemonth').val() == null) {
            $('#expirationdatemonth').parent().addClass('requerido');
        } else {
            $('#expirationdatemonth').parent().removeClass('requerido');
        }

        if ($('#cardHolder').val() == '') {
            $('#cardHolder').parent().addClass('requerido');
            $('#cardHolder').parent().removeClass("is-dirty");
        } else {
            $('#cardHolder').parent().removeClass('requerido');
            $('#cardHolder').parent().addClass("is-dirty");
        }
    } else {
        $('#creditCardTypeId').parent().removeClass('requerido');
        $('#creditCardNumber').parent().removeClass('requerido');
        $('#expirationDateYear').parent().removeClass('requerido');
        $('#expirationdatemonth').parent().removeClass('requerido');
        $('#cardHolder').parent().removeClass('requerido');
    }

    if ($('#IsFinanced').val() == 'true') {
        if ($('#IdentificationType') == 'RNC') {
            $('#QtyPersonsDepend').val('');
            $('#QtyPersonsDepend').parent().removeClass('requerido');

            if ($('#QtyEmployees').val() == '') {
                $('#QtyEmployees').parent().addClass('requerido');
            } else {
                $('#QtyEmployees').parent().removeClass('requerido');
            }
        } else {
            $('#QtyEmployees').val('');
            $('#QtyEmployees').parent().removeClass('requerido');

            if ($('#QtyPersonsDepend').val() == '') {
                $('#QtyPersonsDepend').parent().addClass('requerido');
            } else {
                $('#QtyPersonsDepend').parent().removeClass('requerido');
            }
        }

    }
}

function ValidateUbicationRequired() {
    var $Nationality_Global_Country_Id = $('#Nationality_Global_Country_Id');
    var $City_State_Prov_Id = $('#City_State_Prov_Id');
    var $municipality_Id = $('#municipality_Id');
    var $City_City_Id = $('#City_City_Id');
    if ($Nationality_Global_Country_Id.val() == null) {
        $Nationality_Global_Country_Id.parent().addClass('requerido');
    } else {
        $Nationality_Global_Country_Id.parent().removeClass('requerido');
    }

    if ($City_State_Prov_Id.val() == '') {
        $City_State_Prov_Id.parent().addClass('requerido');
    } else {
        $City_State_Prov_Id.parent().removeClass('requerido');
    }

    if ($municipality_Id.val() == null) {
        $municipality_Id.parent().addClass('requerido');
    } else {
        $municipality_Id.parent().removeClass('requerido');
    }

    if ($City_City_Id.val() == null) {
        $City_City_Id.parent().addClass('requerido');
    } else {
        $City_City_Id.parent().removeClass('requerido');
    }

}

function ValidateIdentificationNumberMask() {
    var numberLic = $("#IdentificationNumber");
    var IdType = $('#IdentificationType').val();

    switch (IdType) {
        case "Cédula":
        case "Licencia":
            numberLic.inputmask("999-9999999-9");
            break;
        case "RNC":
            numberLic.inputmask("999-99999-9");
            break;
        case "Pasaporte":
            numberLic.inputmask("remove");
            break;
        default:
    }
}

function dialogRncCedula(nodoc) {
    if (nodoc != "") {
        nodoc = nodoc.replace("-", "").replace("-", "").replace("-", "");
        //var url = "http://www.dgii.gov.do/app/WebApps/Consultas/rnc/RncWeb.aspx?__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE=%2FwEPDwUKMTY4ODczNzk2OA9kFgICAQ9kFgQCAQ8QZGQWAWZkAg0PZBYCAgMPPCsACwBkZHTpAYYQQIXs


        //var options = "location=no,width=600,height=300,scrollbars=yes,top=100,left=700,resizable = no";
        //window.open(url.replace("nodoc", nodoc), "Rnc Cedula Check", options);

        var url = urlValidationCedulaRnc();

        $("#docIframe").attr('src', url.replace("{0}", nodoc));
        $('.docValidate').modal('show');
    } else {
        $('.docValidate').hide();
    }
}

function urlValidationCedulaRnc() {
    var result = "";

    $.ajax({
        url: '/Home/GetRncCedulaValidation',
        dataType: 'json',
        async: false,
        success: function (data) {
            result = data;
        },
        error: function (response) {
            showError([response.responseText], "Validación RNC")
        }
    });
    return result;
}

function urlValidationCedulaRncShow() {
    var result = "NO";
    $.ajax({
        url: '/Home/GetRncCedulaValidationShow',
        dataType: 'json',
        async: false,
        success: function (data) {
            result = data;
        },
        error: function (response) {
            showError([response.responseText], "Error validando RNC")
        }
    });

    return result;
}

function getParameterTotalPrimium() {
    $.ajax({
        url: '/Home/getParameterTotalPrimium',
        dataType: 'json',
        success: function (data) {
            if (data != '') {
                $('#ParameterTotalPrimium').val(parseFloat(data));
            }
        }
    });

}

function getAlertBenefRNC() {
    $.ajax({
        url: '/Home/GetAlertBenefRNC',
        dataType: 'json',
        success: function (data) {
            if (data != '') {
                $('#hdnAlertRNC').val(data);
            }
        }
    });

}

function DisableWorkingInformation(enableFields) {
    var $Job = $('#Job');
    var $Company = $('#Company');
    var $AnnualIncome = $('#AnnualIncome');

    if (enableFields != null && enableFields == true) {
        $Job.removeAttr('disabled');
        //$Job.trigger('chosen:updated');
        $Job.trigger('change.select2');

        $Company.removeAttr('disabled');
        $AnnualIncome.removeAttr('disabled');


        if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {
            $('.hidemeWhenNoApply').show();
            $('.complianceSection').removeClass('w-100');
        }

    } else {
        $Job.val('');
        $Job.parent().removeClass('requerido');
        $Job.attr('disabled', 'disabled');
        //$Job.trigger('chosen:updated');
        $Job.trigger('change.select2');

        $Company.val('');
        $Company.attr('disabled', 'disabled');
        $Company.parent().removeClass('requerido');

        $AnnualIncome.val('');
        $AnnualIncome.attr('disabled', 'disabled');
        $AnnualIncome.parent().removeClass('requerido');


        if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

            $('.hidemeWhenNoApply').hide();
            $('.complianceSection').addClass('w-100');
        }


    }
}

function ValidateWorkingInformation() {
    var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val());
    var totalPrimiumQuotation = parseFloat($("#QuotationTotalPrimium").val());
    var $PepFormularyOptionsId = $('#PepFormularyOptionsId');
    var $RiskLevel = $('#hdnRiskLevel');

    var AnnualIncome = parseFloat($('#AnnualIncome').val().replace('$ ', ''));
    if ($('#TypeOfPerson').val() == 1 || $('#TypeOfPerson').val() == 3) { // persona fisica

        $("#ManagerName").parent().removeClass('requerido');

        if ($RiskLevel.val() == 'RA' || ($PepFormularyOptionsId.val() != null && $PepFormularyOptionsId.val() != '3')) {
            if ($("#WorkAddress").val() == '')
                $("#WorkAddress").parent().addClass('requerido');
            else
                $("#WorkAddress").parent().removeClass('requerido');

            $('#WorkAddress_Div').show();

            if ($("#WorkPhone").val() == '')
                $("#WorkPhone").parent().addClass('requerido');
            else
                $("#WorkPhone").parent().removeClass('requerido');

            $('#WorkPhone_Div').show();

            if ($("#Job").val() == '') {
                $("#Job").parent().addClass('requerido');
            } else {
                $("#Job").parent().removeClass('requerido');
            }

            if ($("#Company").val() == '') {
                $("#Company").parent().addClass('requerido');
            } else {
                $("#Company").parent().removeClass('requerido');
            }
            if ($("#AnnualIncome").val() == '' || AnnualIncome <= 00) {
                $("#AnnualIncome").parent().addClass('requerido');
            } else {
                $("#AnnualIncome").parent().removeClass('requerido');
            }

        } else if (totalPrimiumQuotation <= totalPrimiumValidation) {
            $("#WorkAddress").val('');
            $("#WorkAddress").parent().removeClass('requerido');
            $('#WorkAddress_Div').hide();

            $("#WorkPhone").val('');
            $("#WorkPhone").parent().removeClass('requerido');
            $('#WorkPhone_Div').hide();

            if ($("#Job").val() == '') {
                $("#Job").parent().addClass('requerido');
            } else {
                $("#Job").parent().removeClass('requerido');
            }

            if ($("#Company").val() == '') {
                $("#Company").parent().addClass('requerido');
            } else {
                $("#Company").parent().removeClass('requerido');
            }
            $("#AnnualIncome").parent().removeClass('requerido');
        } else {
            if ($("#Job").val() == '') {
                $("#Job").parent().addClass('requerido');
            } else {
                $("#Job").parent().removeClass('requerido');
            }

            if ($("#Company").val() == '' || $("#AnnualIncome").val() == "0") {
                $("#Company").parent().addClass('requerido');
            } else {
                $("#Company").parent().removeClass('requerido');
            }
            if ($("#WorkAddress").val() == '') {
                $("#WorkAddress").parent().addClass('requerido');
            } else {
                $("#WorkAddress").parent().removeClass('requerido');
            }

            if ($("#WorkPhone").val() == '') {
                $("#WorkPhone").parent().addClass('requerido');
            } else {
                $("#WorkPhone").parent().removeClass('requerido');
            }

            if ($("#AnnualIncome").val() == '' || AnnualIncome <= 0) {
                $("#AnnualIncome").parent().addClass('requerido');
            } else {
                $("#AnnualIncome").parent().removeClass('requerido');
            }
            $('#WorkAddress_Div').show();
            $('#WorkPhone_Div').show();
        }
    } else { // personas juridicas
        $("#WorkAddress").val('');
        $("#WorkAddress").parent().removeClass('requerido');
        $('#WorkAddress_Div').hide();

        $("#WorkPhone").val('');
        $("#WorkPhone").parent().removeClass('requerido');
        $('#WorkPhone_Div').hide();
    }
}

function ValidateFulfillmentInformation() {
    var $IdentificationFinalBeneficiaryOptionsId = $('#IdentificationFinalBeneficiaryOptionsId');
    var $SocialReasonId = $('#SocialReasonId');
    var $OwnershipStructureId = $('#OwnershipStructureId');
    var $ManagerName = $('#ManagerName');
    var $pepOptions = $('#PepFormularyOptionsId');
    var $AdminPepFormularyOptionsId = $('#AdminPepFormularyOptionsId');

    if ($('#TypeOfPerson').val() != 1 && $('#TypeOfPerson').val() != 3 && $('#TypeOfPerson').val() != 5 && $('#TypeOfPerson').val() != 6) { // persona juridica
        $IdentificationFinalBeneficiaryOptionsId.removeAttr('disabled');
        $IdentificationFinalBeneficiaryOptionsId.trigger('change.select2');

        $SocialReasonId.removeAttr('disabled');
        $SocialReasonId.trigger('change.select2');

        $OwnershipStructureId.removeAttr('disabled');
        $OwnershipStructureId.trigger('change.select2');

        $pepOptions.val('');
        $pepOptions.attr('disabled', 'disabled');
        $pepOptions.parent().removeClass('requerido');
        $pepOptions.trigger('change.select2');

        if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

            $IdentificationFinalBeneficiaryOptionsId.parent().removeClass('col-md-10');
            $IdentificationFinalBeneficiaryOptionsId.parent().addClass('col-md-11');

            $(".dvspanbf").parent().css('left', '-6%');
            $(".dvspanbf").parent().removeClass('col-md-2');
            $(".dvspanbf").parent().addClass('col-md-1');

            $pepOptions.parent().parent().parent().hide();

            $IdentificationFinalBeneficiaryOptionsId.parent().parent().parent().show();
            $SocialReasonId.parent().parent().show();
            $OwnershipStructureId.parent().parent().show();
            $ManagerName.parent().show();

            $SocialReasonId.parent().parent().removeClass('mdl-cell--12-col');
            $SocialReasonId.parent().parent().addClass('mdl-cell--6-col');
        }
        //else {

        //    $(".dvspanbf").parent().css('left', '-10%');
        //    $(".dvspanbf").parent().removeClass('col-md-1');
        //    $(".dvspanbf").parent().addClass('col-md-2');

        //    $IdentificationFinalBeneficiaryOptionsId.parent().removeClass('col-md-11');
        //    $IdentificationFinalBeneficiaryOptionsId.parent().addClass('col-md-10');
        //}

        if ($IdentificationFinalBeneficiaryOptionsId.val() == null || $IdentificationFinalBeneficiaryOptionsId.val() == '') {
            $IdentificationFinalBeneficiaryOptionsId.parent().addClass('requerido');
            $('#DvAdminPepFormularyOptionsId').hide();
            $AdminPepFormularyOptionsId.val('');
            $AdminPepFormularyOptionsId.parent().removeClass('requerido');
            $AdminPepFormularyOptionsId.trigger('change.select2');
            $('#AdminDisplayPepForm').hide();
        }
        else {
            $IdentificationFinalBeneficiaryOptionsId.parent().removeClass('requerido');
            if ($IdentificationFinalBeneficiaryOptionsId.val() != '5') { // pregunto si tiene beneficiario final para no tener que aplicar la validacion de pep al gerente general
                $('#DvAdminPepFormularyOptionsId').hide();
                $AdminPepFormularyOptionsId.val('');
                $AdminPepFormularyOptionsId.parent().removeClass('requerido');
                $AdminPepFormularyOptionsId.trigger('change.select2');
                $('#AdminDisplayPepForm').hide();
            } else {
                if ($ManagerName.val() != '') {
                    $AdminPepFormularyOptionsId.parent().addClass('requerido');
                    $('#DvAdminPepFormularyOptionsId').hide();
                    $('#AdminDisplayPepForm').hide();
                } else {
                    $('#DvAdminPepFormularyOptionsId').hide();
                    $AdminPepFormularyOptionsId.val('');
                    $AdminPepFormularyOptionsId.parent().removeClass('requerido');
                    $AdminPepFormularyOptionsId.trigger('change.select2');
                    $('#AdminDisplayPepForm').hide();
                }
            }
        }

        if ($SocialReasonId.val() == null || $SocialReasonId.val() == '')
            $SocialReasonId.parent().addClass('requerido');
        else
            $SocialReasonId.parent().removeClass('requerido');

        if ($OwnershipStructureId.val() == null || $OwnershipStructureId.val() == '')
            $OwnershipStructureId.parent().addClass('requerido');
        else
            $OwnershipStructureId.parent().removeClass('requerido');

        $ManagerName.prop('readonly', false);
        if ($ManagerName.val() == '') {
            $ManagerName.parent().addClass('requerido');
        }
        else {
            $ManagerName.parent().removeClass('requerido');
        }
    }
    else if ($('#TypeOfPerson').val() == 5 || $('#TypeOfPerson').val() == 6) //organismos nacionales e internacionales
    {
        $IdentificationFinalBeneficiaryOptionsId.val('');
        $IdentificationFinalBeneficiaryOptionsId.parent().removeClass('requerido');
        $IdentificationFinalBeneficiaryOptionsId.attr('disabled', 'disabled');
        $IdentificationFinalBeneficiaryOptionsId.trigger('change.select2');

        $pepOptions.val('');
        $pepOptions.attr('disabled', 'disabled');
        $pepOptions.parent().removeClass('requerido');
        $pepOptions.trigger('change.select2');

        $OwnershipStructureId.val('');
        $OwnershipStructureId.attr('disabled', 'disabled');
        $OwnershipStructureId.trigger('change.select2');
        $OwnershipStructureId.parent().removeClass('requerido');

        $SocialReasonId.removeAttr('disabled');

        if ($SocialReasonId.val() == null || $SocialReasonId.val() == '')
            $SocialReasonId.parent().addClass('requerido');
        else
            $SocialReasonId.parent().removeClass('requerido');


        $SocialReasonId.trigger('change.select2');

        $ManagerName.prop('readonly', false);
        $('#DvAdminPepFormularyOptionsId').hide();
        $AdminPepFormularyOptionsId.val('');
        $AdminPepFormularyOptionsId.parent().removeClass('requerido');
        $AdminPepFormularyOptionsId.trigger('change.select2');
        $('#AdminDisplayPepForm').hide();

        if ($ManagerName.val() != '') {
            $ManagerName.parent().removeClass('requerido');
        } else {
            $ManagerName.parent().addClass('requerido');
        }

        if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

            $pepOptions.parent().parent().parent().hide();
            $IdentificationFinalBeneficiaryOptionsId.parent().parent().parent().hide();
            $OwnershipStructureId.parent().parent().hide();

            $SocialReasonId.parent().parent().show();
            $SocialReasonId.parent().parent().removeClass('mdl-cell--6-col');
            $SocialReasonId.parent().parent().addClass('mdl-cell--12-col');

            $ManagerName.parent().show();
        }
    }
    else {

        $IdentificationFinalBeneficiaryOptionsId.val('');
        $SocialReasonId.val('');
        $OwnershipStructureId.val('');
        $pepOptions.removeAttr('disabled');
        $('#DvPEP_BENEF').hide();
        $IdentificationFinalBeneficiaryOptionsId.attr('disabled', 'disabled');
        $SocialReasonId.attr('disabled', 'disabled');
        $OwnershipStructureId.attr('disabled', 'disabled');
        if ($pepOptions.val() == null || $pepOptions.val() == '') {
            $pepOptions.parent().addClass('requerido');
        }

        $IdentificationFinalBeneficiaryOptionsId.parent().removeClass('requerido');
        $SocialReasonId.parent().removeClass('requerido');
        $OwnershipStructureId.parent().removeClass('requerido');

        $IdentificationFinalBeneficiaryOptionsId.trigger('change.select2');
        $SocialReasonId.trigger('change.select2');
        $OwnershipStructureId.trigger('change.select2');
        $pepOptions.trigger('change.select2');

        $ManagerName.val('');
        $ManagerName.parent().removeClass('is-dirty');
        $ManagerName.prop('readonly', true);

        $('#DvAdminPepFormularyOptionsId').hide();
        $('#AdminDisplayPepForm').hide();


        if (GlobalAppMode == "LEYMODE" || GlobalAppMode == "FULLMODE") {

            $pepOptions.parent().parent().parent().show();
            $IdentificationFinalBeneficiaryOptionsId.parent().parent().parent().hide();
            $SocialReasonId.parent().parent().hide();
            $OwnershipStructureId.parent().parent().hide();
            $ManagerName.parent().hide();

            $SocialReasonId.parent().parent().removeClass('mdl-cell--12-col');
            $SocialReasonId.parent().parent().addClass('mdl-cell--6-col');
        }
    }
}

function getDefaultCity() {
    $.ajax({
        url: '/Home/GetDefaultCityCode',
        dataType: 'json',
        async: false,
        success: function (result) {
            if (result.result != '') {
                $("#hdnDefaultCityCode").val(result.result);
            }
        }
    });
}

function frmAditionalInformationDriverValidations() {

    $("#FrmAditionalInformationDriver").validate(
        {
            rules: {
                Id: {
                    required: true
                },
                FirstName: {
                    required: true,
                    maxlength: 50
                },
                IdentificationType: {
                    required: true
                },
                IdentificationNumber: {
                    required: true
                },
                FirstSurname: {
                    required:
                    function (element) {
                        return $("#IdentificationType").val() != 'RNC';
                    }
                },
                Email: {
                    email: true
                },
                PepFormularyOptionsId: {
                    required:
                    function (element) {
                        return $("#TypeOfPerson").val() == '1' || $("#TypeOfPerson").val() == '3';
                    }
                },
                QtyPersonsDepend: {
                    required:
                    function (element) {
                        return $('#IsFinanced').val() == 'true' && $("#IdentificationType").val() != 'RNC';
                    }
                },
                QtyEmployees: {
                    required:
                    function (element) {
                        return $('#IsFinanced').val() == 'true' && $("#IdentificationType").val() == 'RNC';
                    }
                },
                creditCardNumber: {
                    required:
                    function (element) {
                        return $('#IsDomiciliation').prop('checked');
                    }
                },
                expirationDateYear: {
                    required:
                    function (element) {
                        return $('#IsDomiciliation').prop('checked');
                    }
                },
                expirationdatemonth: {
                    required:
                    function (element) {
                        return $('#IsDomiciliation').prop('checked');
                    }
                },
                cardHolder: {
                    required:
                    function (element) {
                        return $('#IsDomiciliation').prop('checked');
                    }
                },
                DateOfBirth: {
                    required:
                    function (element) {
                        return $("#IdentificationType").val() != 'RNC';
                    },
                    dateFormat: true
                },
                Nationality_Global_Country_Id: {
                    required: true
                },
                City_State_Prov_Id: {
                    required: true
                },
                municipality_Id: {
                    required: true
                },
                City_City_Id: {
                    required: true
                },
                Address: {
                    required: true
                },
                Job: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3') { //valido si no es persona fisica o es la cotizacion es de full
                            return false;
                        } else if ($('#PepFormularyOptionsId').val() != '' && $('#PepFormularyOptionsId').val() != '3') //valido si el cliente posee calidad pep para pedir la inforamcion laboral
                        {
                            return true;
                        } else {
                            var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val()); // parametro con el monto a validar vs la cotizacion
                            var qtotalPrimium = parseFloat($('#QuotationTotalPrimium').val()); //toal prima con impuesto de la cotizacion
                            if (qtotalPrimium <= totalPrimiumValidation)
                                return true;
                            else {
                                return false;
                            }
                        }
                    }
                },
                creditCardTypeId: {
                    required:
                    function (element) {
                        return $('#IsDomiciliation').prop('checked');
                    }
                },
                PhoneNumber: {
                    required:
                    function (element) {
                        return $('#PhoneNumber').val() == '' && $('#WorkPhone').val() == '' && $('#Mobile').val() == '';
                    },
                    phoneNumberLength: true
                },
                WorkPhone: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3') { //valido si no es persona fisica o es la cotizacion es de full
                            return false;
                        } else if ($('#PepFormularyOptionsId').val() != '' && $('#PepFormularyOptionsId').val() != '3') //valido si el cliente posee calidad pep para pedir la inforamcion laboral
                        {
                            return true;
                        } else {
                            var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val()); // parametro con el monto a validar vs la cotizacion
                            var qtotalPrimium = parseFloat($('#QuotationTotalPrimium').val()); //toal prima con impuesto de la cotizacion
                            if (qtotalPrimium <= totalPrimiumValidation)
                                return true;
                            else {
                                return false;
                            }
                        }
                    },
                    phoneNumberLength: true
                },
                Mobile: {
                    required:
                    function (element) {
                        return $('#PhoneNumber').val() == '' && $('#WorkPhone').val() == '' && $('#Mobile').val() == '';
                    },
                    phoneNumberLength: true
                },
                SocialReasonId: {
                    required:
                    function (element) {
                        return $("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3';
                    }
                },
                OwnershipStructureId: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3')
                            return true;
                        else
                            return false;
                    }
                },
                Company: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3') { //valido si no es persona fisica o es la cotizacion es de full
                            return false;
                        } else if ($('#PepFormularyOptionsId').val() != null && $('#PepFormularyOptionsId').val() != '3') //valido si el cliente posee calidad pep para pedir la inforamcion laboral
                        {
                            return true;
                        } else {
                            var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val()); // parametro con el monto a validar vs la cotizacion
                            var qtotalPrimium = parseFloat($('#QuotationTotalPrimium').val()); //toal prima con impuesto de la cotizacion
                            if (qtotalPrimium <= totalPrimiumValidation)
                                return true;
                            else {
                                return false;
                            }
                        }
                    }
                },
                AnnualIncome: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3') { //valido si no es persona fisica o es la cotizacion es de full
                            return false;
                        } else if ($('#hdnRiskLevel').val() == 'RA' || ($('#PepFormularyOptionsId').val() != null && $('#PepFormularyOptionsId').val() != '3')) //valido si el cliente posee calidad pep para pedir la inforamcion laboral
                        {
                            return true;
                        } else {
                            var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val()); // parametro con el monto a validar vs la cotizacion
                            var qtotalPrimium = parseFloat($('#QuotationTotalPrimium').val()); //toal prima con impuesto de la cotizacion
                            if (qtotalPrimium > totalPrimiumValidation)
                                return true;
                            else {
                                return false;
                            }
                        }
                    }
                },
                IdentificationNumberValidDateO: {
                    required:
                    function (element) {
                        return $('#IsFull').val() == 'true';
                    }
                },
                IdentificationFinalBeneficiaryOptionsId: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3' && $("#TypeOfPerson").val() != '5' && $("#TypeOfPerson").val() != '6')
                            return true;
                        else
                            return false;
                    }
                },
                PlaceOfBirth: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() == '1' || $("#TypeOfPerson").val() == '3')
                            return true;
                        else
                            return false;
                    }
                },
                WorkAddress: {
                    required:
                    function (element) {
                        if ($("#TypeOfPerson").val() != '1' && $("#TypeOfPerson").val() != '3') { //valido si no es persona fisica o es la cotizacion es de full
                            return false;
                        } else if ($('#PepFormularyOptionsId').val() != null && $('#PepFormularyOptionsId').val() != '3') //valido si el cliente posee calidad pep para pedir la inforamcion laboral
                        {
                            return true;
                        } else {
                            var totalPrimiumValidation = parseFloat($('#ParameterTotalPrimium').val()); // parametro con el monto a validar vs la cotizacion
                            var qtotalPrimium = parseFloat($('#QuotationTotalPrimium').val()); //toal prima con impuesto de la cotizacion
                            if (qtotalPrimium <= totalPrimiumValidation)
                                return true;
                            else {
                                return false;
                            }
                        }
                    }
                },
                TypeOfPerson: {
                    required: true
                },
                ManagerName: {
                    required:
                    function (element) {
                        if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3') {
                            return true;
                        } else
                            return false;
                    }
                },
                AdminPepFormularyOptionsId: {
                    required:
                    function (element) {
                        return false;
                        //var $IdentificationFinalBeneficiaryOptionsId = $('#IdentificationFinalBeneficiaryOptionsId');
                        //if ($IdentificationFinalBeneficiaryOptionsId.val() != '') {
                        //    if ($IdentificationFinalBeneficiaryOptionsId.val() != '5') {
                        //        return false;
                        //    } else {
                        //        if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3' && $('#TypeOfPerson').val() != '5' && $('#TypeOfPerson').val() != '6')
                        //            return true;
                        //        else
                        //            return false;
                        //    }
                        //} else {
                        //    if ($('#TypeOfPerson').val() != '1' && $('#TypeOfPerson').val() != '3' && $('#TypeOfPerson').val() != '5' && $('#TypeOfPerson').val() != '6')
                        //        if ($('#ManagerName').val() != '')
                        //            return true;
                        //        else
                        //            return false;
                        //    else
                        //        return false;
                        //}
                    }
                }
            },
            messages: {
                FirstName: {
                    required: 'El Nombre es requerido.',
                },
                DateOfBirth: {
                    required: 'La Fecha de Nacimiento es requerida',
                    dateFormat: 'Debe ingresar una Fecha de Nacimiento válida',
                },
                Email: {
                    email: 'El Email debe ser una dirección de correo electrónico válida'
                },
                FirstSurname: {
                    required: 'El Apellido es requerido'
                },
                Nationality_Global_Country_Id: {
                    required: 'Debe seleccionar la Nacionalidad'
                },
                City_State_Prov_Id: {
                    required: 'Debe seleccionar la Provincia'
                },
                municipality_Id: {
                    required: 'Debe seleccionar el Municipio'
                },
                City_City_Id: {
                    required: 'Debe seleccionar el Sector'
                },
                PepFormularyOptionsId: {
                    required: 'Debe indicar si posee calidad PEP o no'
                },
                QtyPersonsDepend: {
                    required: 'Debe indicar la cantidad de dependientes'
                },
                QtyEmployees: {
                    required: 'Debe indicar la cantidad de empleados'
                },
                expirationDateYear: {
                    required: 'Debe seleccionar el año de expiración de la tarjeta'
                },
                expirationdatemonth: {
                    required: 'Debe seleccionar el mes de expiración de la tarjeta'
                },
                Id: {
                    required: 'Debe seleccionar el conductor del vehículo'
                },
                IdentificationType: {
                    required: 'Debe indicar el Tipo de Identificación'
                },
                IdentificationNumber: {
                    required: 'Debe indicar el Número de Identificación'
                },
                Address: {
                    required: 'Debe indicar la Dirección'
                },
                creditCardTypeId: {
                    required: 'Debe seleccionar el Tipo de Tarjeta de Crédito'
                },
                PhoneNumber: {
                    required: 'Debe colocar al menos un Número de Teléfono',
                    phoneNumberLength: 'El Número de Teléfono no esta completo'
                },
                WorkPhone: {
                    required: 'Debe colocar el Número de Teléfono del trabajo',
                    phoneNumberLength: 'El Número de Teléfono del Trabajo no esta completo'
                },
                Mobile: {
                    required: 'Debe colocar al menos un Número de Teléfono',
                    phoneNumberLength: 'El Número de Celular no esta completo'
                },
                cardHolder: {
                    required: 'Debe colocar el Tarjetahabiente'
                },
                creditCardNumber: {
                    required: 'Debe colocar el Número de Tarjeta'
                },
                SocialReasonId: {
                    required: 'Debe indicar la Actividad o Razón Social de la Empresa'
                },
                OwnershipStructureId: {
                    required: 'Debe seleccionar la Estructura de Titularidad'
                },
                Job: {
                    required: 'Debe seleccionar la Ocupación o Actividad Económica'
                },
                AnnualIncome: {
                    required: 'Debe indicar el Ingreso Mensual'
                },
                Company: {
                    required: 'Debe indicar la Empresa en la que labora'
                },
                IdentificationNumberValidDateO: {
                    required: 'Debe indicar la fecha de fin de validez del documento'
                },
                IdentificationFinalBeneficiaryOptionsId: {
                    required: 'Debe indicar si posee beneficiarios finales o no'
                },
                PlaceOfBirth: {
                    required: 'Debe indicar el lugar de nacimiento'
                },
                WorkAddress: {
                    required: 'Debe indicar la dirección de la empresa donde labora'
                },
                TypeOfPerson: {
                    required: 'Debe seleccionar el tipo de persona'
                },
                ManagerName: {
                    required: 'Debe indicar el Nombre del Gerente General, Administrador o Representante Legal de la empresa'
                },
                AdminPepFormularyOptionsId: {
                    required: 'Debe indicar si el Gerente general, Administrador o Representante Legal, Posee calidad PEP o no '
                }
            }
        });
}

function SetOnchangeEvent() {

    var $DropsIdType = $("#BenefTable").find(".PepOptionIDBenef");
    $DropsIdType.off("change");

    $DropsIdType.change(function () {
        var $this = $(this);
        var TipoId = $this.val();
        var $Row = $this.parent().parent();
        var $input = $Row.find("td").eq(4).find("input:first");
        $input.inputmask('remove');
        $input.removeAttr('disabled');
        $input.val('');
        $input.focus();

        switch (TipoId) {
            case "Cédula":
                $input.inputmask("999-9999999-9");
                VerifyExistRNC();
                break;
            case "RNC":
                $('#lnkViewAutoCertificationFinalBeneficiary').show();
                $input.inputmask("999-99999-9");
                showError([$('#hdnAlertRNC').val()], "Advertencia");
                break;
        }

        if (TipoId == null || TipoId == '')
            $input.prop('disabled', 'disabled');
    });
}

function DeletePepsFromDataBase() {
    var driver = $('#Id').val();

    $.ajax({
        url: "/Home/DeletePeps",
        dataType: 'json',
        data: { driverID: driver },
        success: function (result) {
            var correcto = result.name;
        }
    });
};

function DeleteBenefromDataBase() {
    var driver = $('#Id').val();

    $.ajax({
        url: "/Home/DeleteBeneficiaries",
        dataType: 'json',
        data: { driverID: driver },
        success: function (result) {
            var correcto = result.Name;
        }
    });
};

function getRiskLevel() {
    var CustomerCountryId = $('#Nationality_Global_Country_Id').val();
    var totalPrimiumQuotation = parseFloat($("#QuotationTotalPrimium").val());
    var pTypeOfPerson = parseFloat($("#TypeOfPerson").val());
    var $RiskLevel = $('#hdnRiskLevel');
    var PepFormularyOptionsId = $('#PepFormularyOptionsId').val();

    if (CustomerCountryId != "" && CustomerCountryId != null) {

        $.ajax({
            url: "/Home/ValidateRiskLevelCountry",
            dataType: 'json',
            async: false,
            data: { 'CustomerNationalityID': CustomerCountryId, 'pTotalPremium': totalPrimiumQuotation, 'TypeOfPerson': pTypeOfPerson, 'PepOptionID': PepFormularyOptionsId },
            success: function (result) {
                if (result != "") {
                    $RiskLevel.val(result);
                }
            },
            error: function (response) {
                showError([response.responseText], "Error validando el nivel de riesgo del cliente");
            }
        });
    }
}

function getFinalBeneficiaryAutoCertification() {

    $.ajax({
        url: "/Home/ShowAutoCertificationFinalBeneficiaries",
        dataType: 'json',
        async: false,
        data: {},
        success: function (result) {

        }
    });
}


function ViewAutoCertification() {
    showAutoCertificationTH(function (data) {
        window.open(data, '_blank');
    });
}

function showAutoCertificationTH(CallBack) {
    $.ajax({
        url: "/Home/ShowAutoCertificationFinalBeneficiaries",
        data: {},
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        beforeSend: function () {

        },
        success: CallBack,
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
        }
    });
};


function VerifyExistRNC() {
    var HasRNC = false;
    var table = $("#BenefTable").find('tbody');

    table.find('tr').each(function () {
        var $tds = $(this).find('td');
        var IdentificationTypeId = $tds.eq(3).find('#IdentificationTypeBenef').val();

        if (IdentificationTypeId == "RNC") {
            HasRNC = true;
        }
    });


    if (HasRNC) {
        $('#lnkViewAutoCertificationFinalBeneficiary').show();
    } else {
        $('#lnkViewAutoCertificationFinalBeneficiary').hide();
    }
}