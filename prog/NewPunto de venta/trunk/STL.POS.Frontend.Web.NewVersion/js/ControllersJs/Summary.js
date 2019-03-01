﻿/*
   Author: Lic. Carlos Ml. Lebron
*/
InitializeSummary = function () {
    InitializeChosen();
    var $ddlMonth = $("#ddlMonth");
    $ddlMonth.change(function () { DropDownMonthChange(this) });

    var $IsFinancedChk = $("#IsFinanced");

    $IsFinancedChk.click(function () { CheckBoxIsFinancedChange(this) });

    $("#dvVehicleMenu").find("a:first").click();

    var IsFinanced = $("#hdnIsFinanced").val() == "1";
    var Period = $("#hdnPeriod").val();
    var MonthlyPayment = $("#hdnMonthlyPayment").val();

    if (IsFinanced) {
        $IsFinancedChk.prop("checked", IsFinanced);
        $("#QuotAmount").val(number_format(MonthlyPayment, 2));
        $ddlMonth = $("#ddlMonth");
        $ddlMonth.val(Period);
        CheckBoxIsFinancedChange($IsFinancedChk);
        DropDownMonthChange($ddlMonth);
    }
    $("#mail_btn").off('click');
    $("#mail_btn").on('click', function () {
        //$("#ppSendMail").modal('show');
        $('#ppSendMail').modal({ backdrop: 'static', keyboard: false, show: true });
    });

    $(".btnSendEmail").off('click');
    $(".btnSendEmail").on('click', function () {

        var quotationID = $("#quotationID").val();
        var txtEmail = $("#txtEmail").val();
        var agentId = ($('#AgentList').val() !== "" && $('#AgentList').val() != undefined) ? JSON.parse($('#AgentList').val()).NameId : "";

        if (txtEmail !== '') {

            $.ajax({
                url: "/Home/sendMail",
                data: { quotationID: quotationID, emails: txtEmail, pNameID: agentId },
                dataType: "json",
                type: "POST",
                success: function (data) {

                    if (data.success) {
                        showSucess(['La cotizacion fue enviada al/los correo(s) especificados'], 'Cotizacion enviada por correo');
                    } else {
                        showError(['Ha ocurrido un error al enviar la cotizacion al/los correo(s) especificados'], 'Cotizacion enviada por correo');
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    showError(['Ha ocurrido un error al enviar la cotizacion al/los correo(s) especificados'], 'Cotizacion enviada por correo');
                }
            });
        } else {
            showError(['Debe escribir una direccion de correo valida'], 'Cotizacion enviada por correo');
        }
    });

    $(".continueWithAgent").hide();

    $("#btnSendGlobalExclusion").off('click');
    $("#btnSendGlobalExclusion").on('click', function () {
        ProcessExclusion();
    });

    componentHandler.upgradeAllRegistered();
};


function CheckBoxIsFinancedChange(obj) {
    var $this = $(obj);
    var IsFinanced = $this.prop("checked");

    if (IsFinanced) {
        $("#tbFinanced").fadeIn(200);
    } else {
        $("#QuotAmount").text("0.00");
        $("#ddlMonth").val("-1");
        $("#lnkViewAmortizationTable").hide();
        $("#tbFinanced").fadeOut(200);
        $("#hdnMonthlyPayment").val("0");
    }
}

function DropDownMonthChange(obj) {
    var TotalPremium = $("#hdnTotalPrime").val();
    var $this = $(obj);
    var Period = $this.val();
    GetAmortizacionTable(Period, TotalPremium, function (data) {
        var dataAmortizationTable = data;
        if (data.Code == "000") {
            QuotAmount = dataAmortizationTable.productCalculatorResult.Payment;
            $("#lnkViewAmortizationTable").css("display", QuotAmount > 0 ? "block" : "none");
            $("#QuotAmount").text(number_format(QuotAmount, 2));
            $("#hdnMonthlyPayment").val(QuotAmount);
        }
    });
}

function GetCoverage(param) {
    var parameter = JSON.parse(param);

    $.ajax({
        url: "/Home/GetCoverage",
        data: JSON.stringify({ VehicleId: parameter.VehicleId }),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        beforeSend: function () {

        },
        success: function (data) {
            $("#dvCoverage").fadeIn(200);
            var DollarSign = "$";
            var dataCoverage = data;
            var $TableThirDamage = $("#ThirDamage");
            var $TitleThirDamage = $TableThirDamage.find("thead").find("tr").find("th:first");
            var $TitleProductName = $TableThirDamage.find("thead").find("tr").find("th").eq(1).find("span:first");
            //$TitleProductName.text(parameter.ProductName);
            $TitleThirDamage.text("Coberturas daños a terceros");
            var $TbodyThirdDamage = $TableThirDamage.find("tbody");
            var $TrToDelete = $TbodyThirdDamage.find("tr");
            if ($TrToDelete.length > 0)
                $TrToDelete.remove();

            //Daños a terceros
            $.each(dataCoverage.ThirdDamage, function (index, value) {
                var RowTr = "<tr> <td>{1}</td> <td style='text-align: right'>{2}</td> <td style='text-align: right'>-</td> </tr>";
                RowTr = RowTr.replace("{1}", value.Name).replace("{2}", number_format(value.Limit, 2));
                $TbodyThirdDamage.append(RowTr);
            });
            //Suma Limites Daños a terceros
            var RowTr = "<tr class='bg-medium-blue text-white'><th>{1}</th> <td <td style='text-align: right'>-</td> <td style='text-align: right'><strong>${2}</strong></td></tr>";
            RowTr = RowTr.replace("{1}", "Prima Daños a Terceros").replace("{2}", number_format(dataCoverage.ThirdDamageTotalLimit, 2));
            $TbodyThirdDamage.append(RowTr);

            var $TableSelfDamage = $("#SelfDamage");
            var $TitleSelfDamage = $TableSelfDamage.find("thead").find("tr").find("th:first");
            $TitleSelfDamage.text("Coberturas daños propios");
            var $TbodySelfDamage = $TableSelfDamage.find("tbody");

            var $TrToDelete = $TbodySelfDamage.find("tr");
            if ($TrToDelete.length > 0)
                $TrToDelete.remove();

            //Daños a propios
            $.each(dataCoverage.SelfDamage, function (index, value) {
                var RowTr = "<tr><td>{1}</td> <td style='text-align: right'>{2}</td> <td style='text-align: right'>-</td> </tr>";
                RowTr = RowTr.replace("{1}", value.Name).replace("{2}", number_format(value.Limit, 2));
                $TbodySelfDamage.append(RowTr);
            });
            //Suma Limites Daños a propios
            var RowTr = "<tr class='bg-medium-blue text-white'><th>{1}</th> <td style='text-align: right'>-</td> <td style='text-align: right'><strong>${2}</strong></td></tr>";
            RowTr = RowTr.replace("{1}", "Prima Daños Propios").replace("{2}", number_format(dataCoverage.SelfDamageTotalLimit, 2));
            $TbodySelfDamage.append(RowTr);


            //Adicionales
            var $TableAdditional = $("#Additional");
            var $TitleAdditional = $TableAdditional.find("thead").find("tr").find("th:first");
            $TitleAdditional.text("Servicios");
            var $TbodyAdditional = $TableAdditional.find("tbody");

            var $TrToDelete = $TbodyAdditional.find("tr");
            if ($TrToDelete.length > 0)
                $TrToDelete.remove();

            //Servicios
            $.each(dataCoverage.Additional, function (index, value) {
                var RowTr = "<tr><td>{1}</td> <td style='text-align: right'>{3}</td> <td style='text-align: right'>{2}</td> </tr>";

                var serviceLimit = "-";
                if (value.Limit > 0) {
                    serviceLimit = number_format(value.Limit, 2);
                }

                RowTr = RowTr.replace("{1}", value.Name).replace("{2}", number_format(value.Amount, 2)).replace("{3}", serviceLimit);
                $TbodyAdditional.append(RowTr);
            });
            //Suma Limites Servicios
            var RowTr = "<tr class='bg-medium-blue text-white'><th>{1}</th> <td <td style='text-align: right'>-</td> <td <td style='text-align: right'><strong>${2}</strong></td></tr>";
            RowTr = RowTr.replace("{1}", "Prima Servicios").replace("{2}", number_format(dataCoverage.AdditionalTotalLimit, 2));
            $TbodyAdditional.append(RowTr);


            //Desplegar la Prima Anual
            $("#TotalAnnualPrime").text(DollarSign + " " + number_format(parameter.TotalPrime, 2));
            $("#TotalTax").text(DollarSign + " " + number_format(parameter.TotalIsc, 2));
            var TotalAmountPay = parameter.TotalPrime + parameter.TotalIsc;
            $("#TotalAmountPay").text(DollarSign + " " + number_format(TotalAmountPay, 2));
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
        }
    });
}

function GetAmortizacionTable(Period, TotalPremium, CallBack) {
    $.ajax({
        url: "/Home/GetAmortizacionTable",
        data: JSON.stringify({ Period: Period, TotalPremium: TotalPremium }),
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
}

function ViewQuotation(IsResume) {
    var quotationId = parseInt($("#quotationID").val());
    var IsQuotationsResume = false;
    if (IsResume != null)
        IsQuotationsResume = IsResume;

    showQuotationTH(quotationId, IsQuotationsResume, function (data) {
        window.open(data, '_blank');
    });
}

function showQuotationTH(quotationId, IsResume, CallBack) {
    var agentId = $('#AgentList').val() != null ? JSON.parse($('#AgentList').val()).NameId : "";

    $.ajax({
        url: "/Home/ShowQuotation",
        data: JSON.stringify({ quotationId: quotationId, pNameID: agentId, pQuotationResume: IsResume }),
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
}

function ViewAmortizationTable() {
    var quotationId = parseInt($("#quotationID").val());
    var Period = $("#ddlMonth").val();
    var TotalPrime = parseFloat($("#hdnTotalPrime").val());
    showAmortizationTableTH(Period, quotationId, TotalPrime, function (data) {
        window.open(data, '_blank');
    });
}

function showAmortizationTableTH(Period, QuotationId, TotalPrime, CallBack) {
    $.ajax({
        url: "/Home/ShowAmortizationTable",
        data: JSON.stringify({ QuotationId: QuotationId, period: Period, TotalPrime: TotalPrime }),
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

function SaveFinanced() {

    var $hdnMonthlyPayment = $("#hdnMonthlyPayment").val()
    var MonthlyPayment = $hdnMonthlyPayment != "" ? parseFloat($hdnMonthlyPayment) : 0;

    var isFinanced = $("#IsFinanced").prop("checked") == undefined ? false : $("#IsFinanced").prop("checked");

    if (MonthlyPayment == 0 && isFinanced) {
        showError(["Debe elegir el numero de cuotas"], "");
        return false;
    }

    var Period = parseInt($("#ddlMonth").val());
    var financed = $("#IsFinanced").prop("checked") == undefined ? false : $("#IsFinanced").prop("checked");
    var paymentFrequencyId = Period;
    var params = JSON.stringify({ MonthlyPayment: MonthlyPayment, Period: Period, paymentFrequencyId: paymentFrequencyId, financed: financed });
    $.ajax({
        url: "/Home/SaveFinanced",
        data: params,
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        beforeSend: function () {
        },
        success: function () {
        }
    });
}

function ProcessExclusion() {
    var hdnQuotationId = $('#quotationID').val();

    $.ajax({
        url: "/Home/SendQuotToGlobal",
        type: "POST",
        data: { quotationID: hdnQuotationId },
        cache: false,
        async: false,
        success: function (data, textStatus, jqXHR) {

            if (data.success) {

                //reemplazar div y mostrar partialview
                $.ajax({
                    url: "/Home/FinalStepToInbox",
                    data: { quotationID: hdnQuotationId },
                    contentType: 'application/html; charset=utf-8',
                    type: 'GET',
                    dataType: 'html',
                    async: false,
                    success: function (html) {

                        $("#dvHeaderOption").hide();
                        $("#dvContainer").html(html);
                    },
                    error: function (req, status, error) {
                    }
                });

                window.history.replaceState({}, '', '/Home/Index');
                var isfinanced = $("#isFinancedPolicy").val() == "True";
                //showSucess([data.message], "Cotización", (!isfinanced) ? function () { location.reload(); } : null, false);
                showSucess([data.message], "Cotización", null, false);
            }
            else {
                showError([data.message], "Enviando Cotizacion a la Bandeja de Auto");
            }
        },
        error: function (data, textStatus, jqXHR) {
            if (data.messageError) {
                showError([data.messageError]);
            } else {
                var textError = data + " " + textStatus + " " + jqXHR;
                showError([textError]);
            }
        }
    });

    return false;
}