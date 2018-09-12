function EnlazarEventos() {
    $(document).ready(function () {
        $('#txtOccupation').on('blur', function () {
            var OccupationId = $.trim($("#hdnOccupationId").val());
            if (OccupationId == "") {
                $("#txtOccupation").val("");
                $("#hdnOccupationGroupId").val("");
                $("#txtProfession").val("");
                changeBorderColor($("#txtProfession"));
            };
        });
        $('#txtOccupation_Legal').on('blur', function () {
            var OccupationId = $.trim($("#hdnOccupationId_Legal").val());
            if (OccupationId == "") {
                $("#txtOccupation_Legal").val("");
                $("#hdnOccupationGroupId_Legal").val("");
                $("#txtProfession_Legal").val("");
                changeBorderColor($("#txtProfession_Legal"));
            };
        });

        if ((eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 7) || (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 3)) {
            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("9999-999999-999-9");
        }
        else if (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 1) {
            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("99999999-9");
        }
        else { var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("remove"); }


        if ((eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 7) ||
            (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 5) ||
            (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 9) ||
            (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 6)) {
            $("#txtExpDate").removeAttr("validation");
        }
        else { $("#txtExpDate").attr("validation", "Required"); }

    });
};

var lang = "";
function pageLoad() {

    lang = $("#hdnLang").val();
    sessionTimeout = $("#hdnTimeOut").val();
    var isEdit = $("#isEdit").val() == "true";
    //Cambiar de Tab
    var CurrentTab = $("#hdnCurrentTabContact").val();

    if (CurrentTab == 'lnkContactInformation') {
        $("#frmPhoneNumbers").removeClass('col-1-3');
        $($("#frmPhoneNumbers").find(".fondo_blanco").find("div")[1]).css("min-height", isEdit ? "301px" : "180px");
        $("#frmPhoneNumbersLegal").removeClass('col-1-3');
        $($("#frmPhoneNumbersLegal").find(".fondo_blanco").find("div")[1]).css("min-height", isEdit ? "301px" : "180px");
        var frmEmailAddressHeight = parseInt($("#frmEmailAddress").css("height").replace("px"));
        $($("#frmIllustration").find(".fondo_blanco").find("div")[1]).css("height", (frmEmailAddressHeight - 51) + "px");
    } else if (CurrentTab == 'lnkIllustrations')
        pageLoadIllustration();

    $("#frmPhoneNumbers").show();

    $("#frmPhoneNumbersLegal").show();

    if ($("#frmEmailAddress").css("display") == "none") {
        $("#frmEmailAddress").fadeIn(500);
    }

    $(".dxWeb_pcCloseButton").hide();

    if (isEdit) {
        var AdditionalInformationContainer = $("#AdditionalInformationContainer");
        var dvAdditionalInformation = $("#dvAdditionalInformation");
        var divs = dvAdditionalInformation.find("div");
        $(divs[0]).hide();
        AdditionalInformationContainer.append(dvAdditionalInformation);
        AdditionalInformationContainer.show();

        var dvIdentification = $("#dvIdentification");
        $("#dvParentAdditionalInformation").append(dvIdentification);
        $("#frmIdentifications").removeClass("col-1-3");
        $("#frmIdentifications_Legal").removeClass("col-1-3");
    }

    ChangeTab(CurrentTab);

    $("#txtDateOfBirth").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: '-3m',
        minDate: '-65y',
        defaultDate: '-3m',
        yearRange: "c-100:c+100",
        onSelect: function (selectedDate) {
            changeBorderColor(this);
            CallExecuteOnCloseEvent(this, selectedDate);
        },
        onClose: function (selectedDate) {
            changeBorderColor(this);
            CallExecuteOnCloseEvent(this, selectedDate);
        }, beforeShow: function () {
            SavePosDatePicker(this);
        }
    }).inputmask('mm/dd/yyyy');

    $("#txtEffectiveDate").datepicker({
        changeMonth: true,
        changeYear: true,
        //maxDate: '-3m',
        //minDate: '-65y',
        defaultDate: new Date(),
        yearRange: "c-100:c+100"
        /*onSelect: function (selectedDate) {
            changeBorderColor(this);
            CallExecuteOnCloseEvent(this, selectedDate);
        },
        onClose: function (selectedDate) {
            changeBorderColor(this);
            CallExecuteOnCloseEvent(this, selectedDate);
        }, beforeShow: function () {
            SavePosDatePicker(this);
        }*/
    }).inputmask('mm/dd/yyyy');

    SetDatePicker();

    var hdnShowFormAddNewContact = $("#hdnShowFormAddNewContact").val();

    $("#liContactInformation").css("display", hdnShowFormAddNewContact == "true" ? "block" : "none");
    $("#liSurvey").css("display", hdnShowFormAddNewContact == "true" ? "block" : "none");
    setCurrentAccordeonForIndex("#hfMenuAccordeonContact");
    Configutations();
    setOccupationTypeAutoComplete();
    setOccupationAutoComplete();
    setOccupationTypeAutoComplete2();
    setOccupationAutoComplete2();

    $(".st-content-inner").scroll(function () {

        if ($("#CurrentDatePickerShow").val() != "") {
            var objP = $("#ui-datepicker-div");
            var objR = $($("#CurrentDatePickerShow").val().split(",")[0]);
            var offset = objR.offset();
            var ArribaOrAbajo = $("#CurrentDatePickerShow").val().split(",")[1];
            if (ArribaOrAbajo == "AR") {
                var TopArriba = parseInt(objP.css("height").replace("px", ""));
                $(objP).offset({ top: offset.top - TopArriba, left: offset.left });
            } if (ArribaOrAbajo == "AB") {
                var TopAbajo = parseInt(objR.css("height").replace("px", ""));
                $(objP).offset({ top: offset.top + TopAbajo, left: offset.left });
            }
        }
    });
    fixheight();
    $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').change(function () {
        validateTypeDocument($(this).val());

        //NIT
        //Licencia
        if ((eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 7) || (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 3)) {

            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");
        }
            //DUI
        else if (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 1) {

            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("999-9999999-9");

        }
            //Pasaporte
        else if (eval($('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_cbxIDType').val()) == 2) {

            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("remove");

        }
            //RNC--> Registro de Compañia
            //Carnet de Residente
            //Cerificado de Nacimiento
        else {
            //mavelar 18-03-2017 Cambio para dejar abierto los documentos se cambia .inputmask("integer")  por .inputmask("remove");
            var $txt = $('#bodyContent_ContactContainer_WUCContactInformation_WUCIdentification_txtIDNumber').inputmask("remove");
        }

    });

    /*
    $("#bodyContent_ContactContainer_WUCContactInformation_WUCPhoneNumber_cbxPhoneType").change(function () {


        var txtCountryCode = document.getElementById('txtCountryCode');
        if (txtCountryCode.value.length == 0) {
            $('#txtCountryCode').val('809');
            $('#txtCityCode').val('1');
        }


    });
    */



}

validaTab = function (sender) {
    BeginRequestHandler(this);
    var result = true;

    var validar = $("#hdnShowFormAddNewContact").val() == "true";

    if (validar)
        result = validateForms();

    return result;
};

function validateTypeDocument(val) {
    //7 hace referencia al tipo de documento NIT
    //5 hace referencia al tipo de documento Registro de Compañia
    //9 hace referencia al tipo de documento Registro Fiscal
    //6 hace referencia al certificado de nacimiento
    if (val == "7") {
        $("#txtExpDate").attr("validation", "");
    }
    else if (val == "5") {
        $("#txtExpDate").attr("validation", "");
    }
    else if (val == "9") {
        $("#txtExpDate").attr("validation", "");
    }
    else if (val == "6") {
        $("#txtExpDate").attr("validation", "");
    }
    else {
        $("#txtExpDate").attr("validation", "Required");
    }
};

function validateForms() {
    var result = true;

    result = validateForm('frmPersonalInformation');

    if (result)
        result = validateForm('frmPersonalInformation2');


    if (result) {
        //validar Home Address
        if ($("#tb_WCU_A_HomeAddress").val().trim() != "" ||
           ($("#ddl_WUC_A_HomeCountry").val() != null && $("#ddl_WUC_A_HomeCountry").val() != "-1") ||
           ($("#ddl_WUC_A_HomeState").val() != null && $("#ddl_WUC_A_HomeState").val() != "-1") ||
           ($("#ddl_WUC_A_HomeCity").val() != null && $("#ddl_WUC_A_HomeCity").val() != "-1")
           ) {
            result = validateForm("frmHomeAddress");

        } else if ($("#tb_WCU_A_BusinessAddress").val().trim() != "" ||
                ($("#ddl_WUC_A_BusinessCountry").val() != null && $("#ddl_WUC_A_BusinessCountry").val() != "-1") ||
                ($("#ddl_WUC_A_BusinessState").val() != null && $("#ddl_WUC_A_BusinessState").val() != "-1") ||
                ($("#ddl_WUC_A_BusinessCity").val() != null && $("#ddl_WUC_A_BusinessCity").val() != "-1")
            ) {
            //validar Business Address
            result = validateForm("frmbusinessAddress");

        }
    }

    if (result) {
        //var PersonalIncome = $("#txtPersonalIncome");
        //var YearLyFamilyIncome = $("#txtYearlyFamilyIncome");

        //var valPersonalIncome = parseFloat(replaceAll(",", "", $("#txtPersonalIncome").val()));
        //var valYearLyFamilyIncome = parseFloat(replaceAll(",", "", $("#txtYearlyFamilyIncome").val()));

        //if (valPersonalIncome > valYearLyFamilyIncome) {
        //    EndRequestHandler();
        //    result = false;
        //    CustomDialogMessageEx(null, null, null, true, lang == "en" ? "Warning" : "Advertencia", 'PersonalIncomeValidation');
        //}
    }

    return result
}

ChangeTab = function (Tab) {

    //Limpiar
    $("#MenuTabs li").removeClass("active");

    vTab = $('#' + Tab);

    $(vTab).parent().addClass("active");

};

validateFormIdentification = function (form) {

    var resultado = validateForm(form);
    return resultado;
};

validateFormEmailAddress = function (sender, form) {

    var resultado = validateForm(form);
    return resultado;
};

validateFormPhoneNumbers = function (sender, form) {

    var resultado = validateForm(form);
    return resultado;
};

validateFormIdentification_Legal = function (form) {

    var resultado = validateForm(form);
    return resultado;
};

validateFormEmailAddress_Legal = function (sender, form) {

    var resultado = validateForm(form);
    return resultado;
};

validateFormPhoneNumbers_Legal = function (sender, form) {

    var resultado = validateForm(form);
    return resultado;
};

calculateAge = function (birthday) {
    var now = new Date();
    var anio = birthday.substring(6);
    var mes = birthday.substring(3, 5);
    var dia = birthday.substring(0, 2);
    //var past = new Date(birthday.substring(6), birthday.substring(3, 5), birthday.substring(0, 2));
    /*var past = new Date(anio, mes - 1, dia);
    var nowYear = now.getFullYear();
    var pastYear = past.getFullYear(); //past.getFullYear();
    var age = nowYear - pastYear;*/

    // cogemos los valores actuales
    var fecha_hoy = new Date();
    var ahora_ano = now.getYear();
    var ahora_mes = now.getMonth();
    var ahora_dia = now.getDate();

    // realizamos el calculo
    var edad = (ahora_ano + 1900) - anio;
    if (ahora_mes < (mes - 1)) {
        edad--;
    }
    if (((mes - 1) == ahora_mes) && (ahora_dia < dia)) {
        edad--;
    }
    if (edad > 1900) {
        edad -= 1900;
    }

    return edad;
};

CallExecuteOnCloseEvent = function (sender, selectedDate) {

    if (selectedDate != "") {
        var fecha = new Date();

        if ($(sender).attr('id') == "tb_WUC_PI_DateBirth" ||
            $(sender).attr('id') == "txtDateOfBirth" ||
            $(sender).attr('id') == 'txtDateOfBirthDesignatedPensioner') {
            var BeforeVal = $("#hdnDateOfBirthBefore").val();

            var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();

            if (selectedDate.ToDate('mm/dd/yyyy') > pDate.ToDate('mm/dd/yyyy')) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx('The date of birth can not be future, the date "' + selectedDate + '" is a future date!', null, null, true, "Warning");
                return false;
            }

            //var age = selectedDate.YearDiff("", "dd/mm/yyyy"); 
            var age = calculateAge(selectedDate);

            if ($(sender).attr('id') == "tb_WUC_PI_DateBirth" && age < 18) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx('La edad de la persona no puede ser menor a 18 años', null, null, true, "Warning");
                return false;
            }

            if ($(sender).attr('id') == "txtDateOfBirth" && age < 18) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx('La edad de la persona no puede ser menor a 18 años', null, null, true, "Warning");
                return false;
            }

            $("#hdnAge").val(age);
            $("#tb_WUC_PI_Age").val(age);
            $("#txtAge").val(age);
            $("#txtAge").attr('readOnly', 'true');
            $("#txtAge").focus();

        } else
            if ($(sender).attr('id') == 'txtExpDate' ||
                $(sender).attr('id') == 'txtExpirationDate') {

                var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();

                var FechaSeleccionada = selectedDate.split("/");

                var FechaFinal = FechaSeleccionada[0] + "/" + FechaSeleccionada[1] + "/" + FechaSeleccionada[2];

                var Days = pDate.DayDiff(FechaFinal, 'mm/dd/yyyy');

                if (Days < 61) {
                    $(sender).val("");
                    CustomDialogMessageEx("The expiration date can not be less than 61 days", null, null, true, "Warning");
                }
            } else if ($(sender).attr('id') == 'txtRegistrationDate') {

                var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();

                if (selectedDate.ToDate('mm/dd/yyyy') > pDate.ToDate('mm/dd/yyyy')) {
                    $(sender).val("");
                    $(sender).focus();
                    CustomDialogMessageEx('The date of registration of the company should not be a future date, the date "' + selectedDate + '" is a future date.', null, null, true, "Warning");
                }
            } else if ($(sender).attr("alt") == 'validateFutureDateofBirth' ||
                       $(sender).attr("alt") == 'validateFutureDate') {

                var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();

                if (selectedDate.ToDate('mm/dd/yyyy') > pDate.ToDate('mm/dd/yyyy')) {
                    $(sender).val("");
                    $(sender).focus();
                    CustomDialogMessageEx('The date can not be future, the date "' + selectedDate + '" is not valid.', null, null, true, "Warning");
                }
            }
            else if (divIllustration && $(sender).attr('id') == 'txtDateOfBirth') {
                ChangeOtherInsuredDateOfBirth(selectedDate);
            }
    }
}