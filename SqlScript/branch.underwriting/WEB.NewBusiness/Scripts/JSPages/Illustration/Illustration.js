var divIllustration;

function pageLoadIllustration() {
    ConfigurationIllustration();
    if (document.getElementById("hdnCheckedAvailableIllustrations") != undefined)
        configurationCompareIllustrationCheckbox();
}

function configurationCompareIllustrationCheckbox() {
    var checkedAvailableIllustrations = document.getElementById("hdnCheckedAvailableIllustrations").value.split("|");
    var checkedCompareIllustrations = document.getElementById("hdnCheckedCompareIllustrations").value.split("|");

    for (var i = 0; i < checkedAvailableIllustrations.length; i++) {
        if (checkedAvailableIllustrations[i] == "") continue;
        var id = "chkSelect_" + checkedAvailableIllustrations[i];
        var chk = document.getElementById(id);
        if (chk != undefined)
            chk.checked = true;
    }

    for (var i = 0; i < checkedCompareIllustrations.length; i++) {
        if (checkedCompareIllustrations[i] == "") continue;
        var id = "chkSelect_" + checkedCompareIllustrations[i];
        var chk = document.getElementById(id);
        if (chk != undefined)
            chk.checked = true;
    }
}

function compareIllustrationCheckedChange(chk, customerPlanNo, hdnId) {
    var hdn = document.getElementById(hdnId);
    if (chk.checked)
        hdn.value += "|" + customerPlanNo;
    else
        hdn.value = hdn.value.replace("|" + customerPlanNo, "");
}

function ConfigurationIllustration() {
    divIllustration = $("#divIllustration");

    var temp = "P";
    divIllustration.find("#ddlCalculate").val(temp);//Seteamos por defecto la cotizacion por prima
    divIllustration.find("#ddlCalculate").attr('disabled', false);//Desahbilitamos para que el usuario no pueda cambiar la opcion
    
    ChangeCalculate();
    ChangeInitialContribution();
    ChangeContributionType();
    setCurrentAccordeonForIndex("#hdnLnkAccordeon");

    divIllustration.find("#ddlCalculate").change(ChangeCalculate);
    divIllustration.find("#ddlInitialContribution").change(ChangeInitialContribution);
    divIllustration.find("#ddlContributionType").change(ChangeContributionType);
    var ddlFinantialGoal = divIllustration.find("#ddlFinancialGoal");
    if (ddlFinantialGoal) {
        ddlFinantialGoal.change(ChangeFinancialGoal);
        ChangeFinancialGoal();
    }
    var ddlAccidentalDeathBenefit = divIllustration.find("#ddlAccidentalDeathBenefit");
    if (ddlAccidentalDeathBenefit) {
        ddlAccidentalDeathBenefit.change(ChangeAccidentalDeathBenefit);
        ChangeAccidentalDeathBenefit();
    }
    var ddlSpouseInsured = divIllustration.find("#ddlSpouseInsured");
    if (ddlSpouseInsured) {
        ddlSpouseInsured.change(ChangeSpouseInsured);
        ChangeSpouseInsured();
    } else {
        divIllustration.find(".requirementotherinsured").hide();
        if (!divIllustration.find("li.requirementprimaryinsured").hasClass("selected")) {
            divIllustration.find("li.requirementprimaryinsured").addClass("selected");
            divIllustration.find("div.requirementprimaryinsured").show();
        }
    }
    var ddlCriticalIllness = divIllustration.find("#ddlCriticalIllness");
    if (ddlCriticalIllness) {
        ddlCriticalIllness.change(ChangeCriticalIllness);
        ChangeCriticalIllness();
    }
    //Bmarroquin 09-01-2017 Se agrega el DropDownList de Gastos Funerarios
    var ddlGastosFunerarios = divIllustration.find("#ddlGastosFunerarios");
    if (ddlGastosFunerarios) {
        ddlGastosFunerarios.change(ChangeGastosFunerarios);
        ChangeGastosFunerarios();
    }
    var ddlAdditionalTermInsurance = divIllustration.find("#ddlAdditionalTermInsurance");
    if (ddlAdditionalTermInsurance) {
        ddlAdditionalTermInsurance.change(ChangeAdditionalTermInsurance);
        ChangeAdditionalTermInsurance();
    }

    divIllustration.find("#txtClientSearch").click(OpenClientSearch);

    divIllustration.find("#chkClientSearch").click(ClientSearchCheckedChange);

    if ($('div#mySliderRequirementTabs, div#mySliderBeneficiariesTabs').length != 0) {
        var slider = $("div#mySliderRequirementTabs, div#mySliderBeneficiariesTabs").sliderTabs({
            autoplay: false,
            mousewheel: false,
            position: "top"
        });
    }

    var txtDateOfBirth = divIllustration.find("#divOtherInsuredInfo #txtOtherInsuredDateOfBirth"),
        txtAge = divIllustration.find("#divOtherInsuredInfo #txtAge"),
        hdnAge = divIllustration.find("#divOtherInsuredInfo #hdnAge");

    if (txtDateOfBirth) {

        txtDateOfBirth.datepicker({
            changeMonth: true,
            changeYear: true,
            yearRange: "c-100:c+100",
            onSelect: function (selectedDate) {
                ChangeOtherInsuredDateOfBirth(selectedDate);
            }
        }).each(DatePickerEachFunc);

        txtAge.val(hdnAge.val());
        var format = 'mm/dd/yyyy',
            today = new Date();

        txtAge.bind("blur", function () {
            var age = this.value;
            if (age == "" || age == "0") {
                txtDateOfBirth.val("");
                this.value = "";
                return;
            }
            hdnAge.val(age);
            today.setYear(today.getFullYear() - age);
            txtDateOfBirth.val(today.ToFormatedString(format));
        });
    }

    var txtInsuredProspectAge = divIllustration.find("#txtInsuredProspectAge, #txtInsuredPeriod");
    if (txtInsuredProspectAge.length > 0) {
        if (txtInsuredProspectAge.val() == "")
            CalculateStartPeriodAtAge();
        divIllustration.find("#txtContributionPeriod, #ddlDefermentPeriod, #txtStudentAge, #txtAge").change(CalculateStartPeriodAtAge);
    }

    var ddlPlanInformation = divIllustration.find("#ddlPlanInformation");
    ddlPlanInformation.change(changePlanInformation)
    changePlanInformation();

    divIllustration.find("#ddlCriticalIllness").attr("disabled", "disabled");
    //Bmarroquin 27-03-2017 Mejora para que se calcule automaticamente el valor de la cobertura Funeral Expenses, al cambiar el monto de vida Basico
    divIllustration.find("#txtInsuredBenefitRetirementAmount").blur(ChangeGastosFunerarios);
}

function changePlanInformation() {
    var ddlPlanInformation = divIllustration.find("#ddlPlanInformation");
    var divReturnPremium = divIllustration.find("#divReturnPremium");
    var divTermInsuranceFooter = divIllustration.find("#divTermInsuranceFooter");
    var divTax = divIllustration.find("#divTax");
    if (ddlPlanInformation.val() == "SNT") {
        if (divReturnPremium.length > 0)
            divReturnPremium.show();
        if (divTermInsuranceFooter.length > 0)
            divTermInsuranceFooter.addClass("de_6");
        if (divTax.length > 0)
            divTax.hide();
    }
    else {
        if (divReturnPremium.length > 0)
            divReturnPremium.hide();
        if (divTermInsuranceFooter.length > 0) {
            if (ddlPlanInformation.val() == "LGT") {
                if (divTax.length > 0)
                    divTax.hide();
                divTermInsuranceFooter.addClass("de_6");
            } else {
                if (divTax.length > 0)
                    divTax.show();
                divTermInsuranceFooter.addClass("de_7");
            }
        }
    }
}

function CalculateStartPeriodAtAge() {
    var txtInsuredProspectAge = divIllustration.find("#txtInsuredProspectAge, #txtInsuredPeriod");
    if (txtInsuredProspectAge.length == 0) return false;

    var txtContributionPeriod = divIllustration.find("#txtContributionPeriod");
    var contributionPeriod = parseInt(txtContributionPeriod.length == 0 || txtContributionPeriod.val() == "" ? 0 : txtContributionPeriod.val());

    var ddlDefermentPeriod = divIllustration.find("#ddlDefermentPeriod");
    var defermentPeriod = parseInt(ddlDefermentPeriod.length == 0 || ddlDefermentPeriod.val() == "" ? 0 : ddlDefermentPeriod.val());

    var txtStudentAge = divIllustration.find("#txtStudentAge");
    var studentAge = parseInt(txtStudentAge.length == 0 || txtStudentAge.val() == "" ? 0 : txtStudentAge.val());

    var txtAge = divIllustration.find("#txtAge");
    var customerAge = parseInt(txtAge.val() == "" ? 0 : txtAge.val());

    var age = studentAge == 0 ? customerAge == 0 && txtStudentAge.length == 0 ? 0 : customerAge : studentAge;

    var startPeriod =
        contributionPeriod +
        defermentPeriod +
        age;
    txtInsuredProspectAge.val(startPeriod);
}

function ChangeOtherInsuredDateOfBirth(date) {
    var txtDateOfBirth = divIllustration.find("#divOtherInsuredInfo #txtOtherInsuredDateOfBirth"),
        txtAge = divIllustration.find("#divOtherInsuredInfo #txtAge"),
        hdnAge = divIllustration.find("#divOtherInsuredInfo #hdnAge"),
        format = 'mm/dd/yyyy';
    if (date == "" || !date.IsDate(format)) {
        txtAge.val("");
        txtDateOfBirth.val("");
        return;
    } else if (date.YearDiff("", format) < 0) {
        ChangeOtherInsuredDateOfBirth(new Date().ToFormatedString(format));
        return;
    }

    txtAge.val(date.YearDiff("", format));
    txtDateOfBirth.val(date);
    hdnAge.val(date.YearDiff("", format));

}

function ChangeCalculate() {
    var calculate = divIllustration.find("#ddlCalculate").val();
    divIllustration.find("#txtPeriodicPremiumAmount, #txtInsuredBenefitRetirementAmount").removeAttr("disabled").removeAttr("validation");
    switch (calculate) {
        case "P":
            divIllustration.find("#txtPeriodicPremiumAmount").attr("disabled", "disabled");
            divIllustration.find("#txtInsuredBenefitRetirementAmount").attr("validation", "Required");
            break;
        case "A":
        case "I":
            divIllustration.find("#txtInsuredBenefitRetirementAmount").attr("disabled", "disabled");
            divIllustration.find("#txtPeriodicPremiumAmount").attr("validation", "Required");
            break;
        case "V":
            divIllustration.find("#txtPeriodicPremiumAmount").attr("validation", "Required");
            divIllustration.find("#txtInsuredBenefitRetirementAmount").attr("validation", "Required");
            break;
    }
}

function ChangeInitialContribution() {
    var initialContribution = divIllustration.find("#ddlInitialContribution").val();
    var txtInitialContributionAmount = divIllustration.find("#divInitialContribution").find("#txtInitialContributionAmount");
    if (initialContribution == "1") {
        divIllustration.find("#divInitialContribution").show();
        if (txtInitialContributionAmount.length > 0)
            txtInitialContributionAmount.attr("validation", "Required");
    }
    else {
        divIllustration.find("#divInitialContribution").hide();
        if (txtInitialContributionAmount.length > 0)
            txtInitialContributionAmount.removeAttr("validation");
    }
}

function ChangeAccidentalDeathBenefit() {
    var accidentalDeathBenefit = divIllustration.find("#ddlAccidentalDeathBenefit").val();
    if (accidentalDeathBenefit == "1")
        divIllustration.find("#txtAccidentalDeathBenefitInsuredAmount").attr("validation", "Required").removeAttr("disabled");
    else {
        divIllustration.find("#txtAccidentalDeathBenefitInsuredAmount").removeAttr("validation").attr("disabled", "disabled");
        divIllustration.find("#txtAccidentalDeathBenefitInsuredAmount").val('0.00');
    }

}

function ChangeSpouseInsured() {
    var spouseInsured = divIllustration.find("#ddlSpouseInsured").val();
    var ddlSpouseInsuredUntilAge = divIllustration.find("#ddlSpouseInsuredUntilAge");

    if (!divIllustration.find("li.requirementprimaryinsured").hasClass("selected")) {
        divIllustration.find("li.requirementprimaryinsured").addClass("selected");
        divIllustration.find("div.requirementprimaryinsured").show();
    }

    if (spouseInsured == "1") {
        divIllustration.find("#txtSpouseInsuredInsuredAmount").attr("validation", "Required").removeAttr("disabled");
        ddlSpouseInsuredUntilAge.removeAttr("disabled");
        var changeUntilAge = function () {
            if (ddlSpouseInsuredUntilAge.val() == "C")
                divIllustration.find("#txtSpouseInsuredYears").removeAttr("validation", "Required").attr("disabled", "disabled");
            else
                divIllustration.find("#txtSpouseInsuredYears").attr("validation", "Required").removeAttr("disabled");
        };

        changeUntilAge();
        ddlSpouseInsuredUntilAge.change(function () {
            changeUntilAge();
        });

        divIllustration.find("#divOtherInsuredInfo input, #divOtherInsuredInfo select").removeAttr("disabled");
        divIllustration.find("#divOtherInsuredInfo").find("#txtName, #txtLastName, #ddlRelationship, #txtOtherInsuredDateOfBirth, #ddlGender, #ddlMaritalStatus, #ddlSmoker, #ddlSmoker, #txtAge").attr("validation", "Required").removeAttr("disabled");

        divIllustration.find("li.requirementotherinsured").show();
    }
    else {
        ddlSpouseInsuredUntilAge.attr("disabled", "disabled");
        divIllustration.find("#txtSpouseInsuredInsuredAmount, #txtSpouseInsuredYears, #divOtherInsuredInfo input, #divOtherInsuredInfo select")
            .removeAttr("validation", "Required").attr("disabled", "disabled");
        divIllustration.find(".requirementotherinsured").hide();
        divIllustration.find("li.requirementotherinsured").removeClass("selected");
    }
}

function ChangeCriticalIllness() {
    var criticalIllness = divIllustration.find("#ddlCriticalIllness").val();
    if (criticalIllness == "1")
        divIllustration.find("#txtCriticalIllnessInsuredAmount").attr("validation", "Required").removeAttr("disabled");
    else {
        divIllustration.find("#txtCriticalIllnessInsuredAmount").removeAttr("validation").attr("disabled", "disabled");
        divIllustration.find("#txtCriticalIllnessInsuredAmount").val('0.00');
    }

}

//Bmarroquin 09-01-2017 Se agrega el Logoica para Controles de Gastos Funerarios
function ChangeGastosFunerarios() {
    var ddlGastosFunerariosValue = divIllustration.find("#ddlGastosFunerarios").val();
    if (ddlGastosFunerariosValue == "1") {
        divIllustration.find("#txtGastosFunerariosInsuredAmount").attr("validation", "Required").removeAttr("disabled");
        //Bmarroquin 27-03-2017 Mejora para que se actualice automaticamente el valor de suma Asegurada de GF en base al 10% de suma asegurada de Vida Basico
        var lIntSumaAsegVidaBasico = divIllustration.find("#txtInsuredBenefitRetirementAmount").val();
        if (lIntSumaAsegVidaBasico !== undefined && lIntSumaAsegVidaBasico != "") {

            //Bmarroquin 06-04-2017 correccion a Issue pa q no se pierda cuando la cantidad es >= a 1 Millon, se usa La Regular Expression
            lIntSumaAsegVidaBasico = parseFloat(lIntSumaAsegVidaBasico.replace(/,/g, '')).toFixed(2);

            if (lIntSumaAsegVidaBasico > 0) {
                var lNum_SumaAsegGF = 0.00;

                lNum_SumaAsegGF = lIntSumaAsegVidaBasico * 0.10;

                //Verificar minimos y maximos 
                if (lNum_SumaAsegGF < 1000.00) {
                    lNum_SumaAsegGF = 0.00;
                }

                if (lNum_SumaAsegGF > 2500.00) {
                    lNum_SumaAsegGF = 2500;
                }
                divIllustration.find("#txtGastosFunerariosInsuredAmount").val(lNum_SumaAsegGF);
            }
        }
        //Fin Mejora Bmarroquin 27-03-2017
    }
    else {
        divIllustration.find("#txtGastosFunerariosInsuredAmount").removeAttr("validation").attr("disabled", "disabled");
        divIllustration.find("#txtGastosFunerariosInsuredAmount").val('0.00');
    }

}

function ChangeAdditionalTermInsurance() {
    var additionalTermInsurance = divIllustration.find("#ddlAdditionalTermInsurance").val();
    var ddlAdditionalTermInsuranceUntilAge = divIllustration.find("#ddlAdditionalTermInsuranceUntilAge");
    if (additionalTermInsurance == "1") {
        divIllustration.find("#txtAdditionalTermInsuranceInsuredAmount").attr("validation", "Required").removeAttr("disabled");
        ddlAdditionalTermInsuranceUntilAge.removeAttr("disabled");
        var changeUntilAge = function () {
            if (ddlAdditionalTermInsuranceUntilAge.val() == "C")
                divIllustration.find("#txtAdditionalTermInsuranceYears").removeAttr("validation", "Required").attr("disabled", "disabled");
            else
                divIllustration.find("#txtAdditionalTermInsuranceYears").attr("validation", "Required").removeAttr("disabled");
        };

        changeUntilAge();
        ddlAdditionalTermInsuranceUntilAge.change(function () {
            changeUntilAge();
        });
    }
    else {
        ddlAdditionalTermInsuranceUntilAge.attr("disabled", "disabled");
        divIllustration.find("#txtAdditionalTermInsuranceInsuredAmount, #txtAdditionalTermInsuranceYears").removeAttr("validation", "Required").attr("disabled", "disabled");
    }
}

function ChangeFinancialGoal() {
    var finantialGoal = divIllustration.find("#ddlFinancialGoal").val();
    if (finantialGoal == "1")
        divIllustration.find(".divFinancialGoal").show().find("#txtAmountGoal, #txtAtAge").attr("validation", "Required");
    else
        divIllustration.find(".divFinancialGoal").hide().find("#txtAmountGoal, #txtAtAge").removeAttr("validation");
}

function ChangeContributionType() {
    var contributionType = divIllustration.find("#ddlContributionType").val();
    if (contributionType == "C" || contributionType == "-1") {
        divIllustration.find("#divContributionPeriod").hide().find("#txtContributionPeriod").removeAttr("validation").removeAttr("");
        divIllustration.find("#divContributionPeriodMonth").hide().find("#txtContributionPeriodMonth").removeAttr("validation").removeAttr("");
    }
    else if (contributionType == "Y") {
        divIllustration.find("#divContributionPeriodMonth").hide().find("#txtContributionPeriodMonth").removeAttr("validation").removeAttr("");
        divIllustration.find("#divContributionPeriod").show().find("#txtContributionPeriod").attr("validation", "Required");
    }
    else if (contributionType == "M") {
        divIllustration.find("#divContributionPeriod").hide().find("#txtContributionPeriod").removeAttr("validation").removeAttr("");
        divIllustration.find("#divContributionPeriodMonth").show().find("#txtContributionPeriodMonth").attr("validation", "Required");
    }

}

function ValidateBeneficiary(btnAdd) {
    return validateForm($(btnAdd.parentNode).find(":hidden").val());
}

function OpenClientSearch() {
    if (document.getElementById("chkClientSearch").checked) {
        document.getElementById("txtClientSearch").blur();
        getTranslate("OwnerIsDifferentThanMainInsured",
            function (data) {
                CustomDialogMessageEx(data.d);
            },
            function (XMLHttpRequest, textStatus, errorThrown) {
                CustomDialogMessageEx(textStatus);
            });
    }
    else
        ppcListClient.Show();
    return false;
}

function ClientSearchCheckedChange() {
    if (document.getElementById("chkClientSearch").checked) {
        ppcListClient.Show();
        document.getElementById("chkClientSearch").checked = false;
    }
    else
        document.getElementById("hdnOwnerId").value = document.getElementById("txtClientSearch").value = "";
}

function ValidatePlan() {
    if (!validateForm("frmHeaderIllustrationInformation"))
        return false;
    if (!validateForm("frmPlanIllustrationInformation"))
        return false;
    if (!validateForm("frmRiderInformation"))
        return false;
    return true;
}

function ValidateRequirement(btnAdd) {
    var pnl = $("#" + $(btnAdd.parentNode).find(":hidden").val());
    if (!validateForm(pnl[0].id))
        return false;
    if (pnl.find(".annuityamount").val() == "" && pnl.find(".insuredamount").val() == "") {
        getTranslate("InsuredAnnuityAmountCannotBeEmpty",
            function (data) {
                CustomDialogMessageEx(data.d);
            },
            function (XMLHttpRequest, textStatus, errorThrown) {
                CustomDialogMessageEx(textStatus);
            });
        return false;
    }
}

function SelectRow(s, e) {
    var keys = s.keys[e.visibleIndex - (s.pageIndex * s.pageRowSize)];
    var ownerId = keys.split("|")[0];
    var ownerName = keys.split("|")[1] + " " + keys.split("|")[2];
    document.getElementById("hdnOwnerId").value = ownerId;
    document.getElementById("txtClientSearch").value = document.getElementById("hdnClientName").value = ownerName;
    document.getElementById("chkClientSearch").checked = true;
    ppcListClient.Hide();
}

function btnSaveAgent() {
    if (!validateForm("frmAgentToSubmit"))
        return false;
    ppcAgentToSubmit.HideWindow();
    return true;
}

function SaveWithAgent() {
    var hdnCanSaveWithOtherAgentValue = document.getElementById("hdnCanSaveWithOtherAgent").value.toLowerCase();
    if ($("#ppcAgentToSubmit_PW-1").css("display") == "none" && hdnCanSaveWithOtherAgentValue == "true") {
        ppcAgentToSubmit.Show();
        return false;
    }
    return true;
}

function SaveIllustration() {
    if (ValidatePlan() && SaveWithAgent()) {
        ppcAgentToSubmit.HideWindow();
        BeginRequestHandler(this);
        return true;
    }
    return false;
}

function ConfirmDelete(sender) {
    return DlgConfirm(sender);
};


$(document).ready(function () {
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(setDisability);
    function setDisability() {
        $('.aspNetDisabled').prop('disabled', 'disabled');
    }
});