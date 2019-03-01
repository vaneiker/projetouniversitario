﻿$(document).ready(function () {

    var $inpPayment = $('.applyCurrency');
    var $paymentTypeList = $('#paymentTypeId');
    var $paymentFrecuencyList = $('#paymentFrecuency');
    var $totalDiscount = $('#TotalDiscount');
    var $taxes = $('#TotalISC');
    var $amountToPayEnteredByUser = $('#AmountToPayEnteredByUser');

    $('#btnDissmisPayment').show();

    InitializeChosen();

    $inpPayment.inputmask('currency', { showMaskOnFocus: true });

    $paymentTypeList.on('change', function () {
        var $element = $(this);

        if ($element.val() == '1') {
            $('#divNotifyMessaging').show();
            $('#divTextCard').hide();
        } else if ($element.val() == '2') {
            $('#divTextCard').show();
            $('#divNotifyMessaging').hide();
        } else {
            $('#divTextCard').hide();
            $('#divNotifyMessaging').hide();
        }
    });

    var isInlcusion = $("#hdnIsInclusion").val() == "S";
    if (isInlcusion) {
        $paymentFrecuencyList.parent().appendTo($("#DropPaymentFreq"));
    }

    $paymentFrecuencyList.on('change', function () {
        var $element = $(this);
        var objValue = JSON.parse(ReplaceString($element.val(), '\'', '"'));
        var dDiscount = 0;
        var dTotalWN = 0;
        var dporcentage = 0;
        var dTaxes = 0;
        var dTotalW = 0;

        if (objValue.Id == '0') {

            var realDiscount = (MontoParseFloat($('#TotalPrimeToDiscount').val()) - MontoParseFloat($('#TotalFlotillaDiscount').val()));

            dDiscount = (realDiscount * parseFloat(objValue.Discount)); //MontoParseFloat($('#TotalPrimeToDiscount').val()) * parseFloat(objValue.Discount);
            $amountToPayEnteredByUser.attr('disabled', 'disabled');
        } else {
            $amountToPayEnteredByUser.removeAttr('disabled');
        }

        var couponPercentageDiscount = MontoParseFloat($('#couponPercentageDiscount').val());
        dTotalWN = MontoParseFloat($('#TotalPrime').val()) - (dDiscount + MontoParseFloat($('#TotalFlotillaDiscount').val()) + couponPercentageDiscount);


        dporcentage = $taxes.attr('data-percentage');
        dTaxes = dTotalWN * dporcentage;
        dTotalW = dTotalWN + dTaxes;

        $totalDiscount.val(dDiscount);
        $('#TotalAmountWithDiscount').val(dTotalWN);
        $taxes.val(dTaxes)
        $('#Total').val(dTotalW);
        $('#MinimunAmountToPay').val(dTotalW * objValue.Initial);
        $amountToPayEnteredByUser.val(dTotalW * objValue.Initial);
        $('#sInitial').html((100 * objValue.Initial) + '%');
    });

    $('#btnDissmisPayment').on('click', function () {

        var qid = parseInt($('#quotationID').val());

        var MinimumAmountToPay = MontoParseFloat($('#MinimunAmountToPay').val());
        //var MinimumAmountToPay = $('#MinimunAmountToPay').val().replace('$', '').replace(',', '').replace(' ', '');
        //var AmountToPay = $('#AmountToPayEnteredByUser').val().replace('$', '').replace(',', '').replace(' ', '');

        var AmountToPay = MontoParseFloat($('#AmountToPayEnteredByUser').val())
        var paramAmount = 0;

        MinimumAmountToPay = parseFloat(MinimumAmountToPay);
        AmountToPay = parseFloat(AmountToPay);

        if (AmountToPay >= MinimumAmountToPay)
            paramAmount = AmountToPay;
        else
            paramAmount = MinimumAmountToPay

        if (qid > 0) {

            $.ajax({
                url: "/Home/DismissPayment",
                type: "POST",
                data: { quotationID: qid, MinimumAmountToPay: paramAmount },
                cache: false,
                success: function (data, textStatus, jqXHR) {
                    if (data.success) {

                        window.history.replaceState({}, '', '/Home/Index');

                        showSucess([data.message], "Cotización", function () { location.reload(); }, true);

                        changeOptionFilter();
                    }
                    else {
                        showError([data.message], "Error Omitiendo Pago");
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
        }

        return false;
    });

    $('#aPagar').on('click', function () {
        PaymentCheckoutSave(true);
        return false;
    });

    $paymentFrecuencyList.trigger("change");
    $paymentTypeList.trigger("change");

    $(".continueWithAgent").show();


    var isInlcusion = $("#hdnIsInclusion").val() == "S";
    if (isInlcusion) {
        $("#paymentFrecuency").parent().appendTo($("#DropPaymentFreq"))
    }


    $(".chkPaymentFrequency").change(function () {
        var opt = $(this);
        var amountToPay = 0;
        //BUscando los checkbox marcados y si es diferente al actual quitarle el check
        $.each($(".chkPaymentFrequency"), function (el) {
            var current = $(this);
            var currentid = current.attr("id");

            if (currentid != opt.attr('id') && current.is(":checked")) {
                current.prop('checked', false);                
            }
        });
        //
        if (opt.is(":checked")) {            
            var txt = opt.closest('td').next('td').find('input.chkValue');
            if (txt.length > 0) {
                amountToPay = txt.val();
            }
            $("#AmountToPayEnteredByUser").val(amountToPay);
        } else {
            $("#AmountToPayEnteredByUser").val(amountToPay);
        }
    });

});

function ReplaceString(v, r, rw) {
    var result = '';

    result = v.replace(new RegExp(r, 'g'), rw);

    return result;
}

function MontoParseFloat(value) {
    try {
        return parseFloat(ReplaceString(value.substring(1, 1000), ',', ''))
    } catch (e) {
        return 0;
    }
}

function PaymentCheckoutSave(isPay) {
    //var objValue = JSON.parse(ReplaceString($('#paymentFrecuency').val(), '\'', '"'));

    var objValue = "";

    $.each($(".chkPaymentFrequency"), function (el) {
        var current = $(this);

        if (current.is(":checked")) {
            objValue = JSON.parse(ReplaceString(current.val(), '\'', '"'));
            return;
        }
    });

    if (objValue == "" || objValue == undefined) {
        showError(['Debe seleccionar una opción de pago.']);
        return;
    }


    var totalDiscount = 0;

    var totalAm = MontoParseFloat($('#TotalAmountWithDiscountAndTax').val());

    totalDiscount = (totalAm * objValue.Discount);

    var quotationID = parseInt($('#quotationID').val());

    var data = {
        PaymentWay: $('#paymentTypeId').val(),
        PaymentFrequencyId: parseInt(objValue.Id),
        AmountToPayEnteredByUser: MontoParseFloat($('#AmountToPayEnteredByUser').val()),
        TotalDiscount: totalDiscount, //MontoParseFloat($('#TotalDiscount').val()),
        DiscountPercentage: objValue.Discount, //$('#TotalISC').attr('data-percentage'),
        Messaging: $('#Messaging').is(':checked'),
        QuotationID: quotationID
    };

    $.ajax({
        url: "/Home/_PaymentCheckoutSave",
        type: "POST",
        data: data,
        cache: false,
        dataType: 'json'
    }).done(function (data, textStatus, jqXHR) {
        if (!data.canMovement) {
            showWarning(["A esta poliza no se le puede hacer movimientos ya que la misma esta en transito"], "Advertencia");
            return false;
        }

        if (data.Result) {
            if (isPay) {
                if ($('#paymentTypeId').val() == '2') {//TC

                    $('#cardnetFormContainer').load('/Home/_SendToCardnet', function () {
                        $('#cardnetFormContainer>form').submit();
                    });

                    //Forma Origina con un IFRAME
                    //$('#divCardnetForm').html('<iframe style="height:500px;width:100%;" src="/Home/_SendToCardnet" scrolling="no" target="_top"></iframe>');                    
                    //$('#ppCardnet').modal({ backdrop: 'static', keyboard: false, show: true });
                }
                else if ($('#paymentTypeId').val() == '1') {
                    //Efectivo 
                    $.ajax({
                        url: "/Home/CashPayment",
                        type: "POST",
                        data: { quotationId: quotationID },
                        cache: false,
                        success: function (data, textStatus, jqXHR) {

                            if (data.success) {
                                $('#noAuthorizationCode').hide();
                                $("#amountPay").hide();

                                var policyNo = data.policyNo
                                if (data.policyNo == null || data.policyNo == undefined || data.policyNo === "") {
                                    policyNo = "N/A";
                                }

                                if (data.goodandbad === "S") {
                                    $("#noPolicyMarbete").html("Ha ocurrido un error al tratar envíar la cotización a la Bandeja, pero, se genero correctamente el número de póliza en SysFlex......... No. Póliza: " + policyNo);
                                    $("#ppMarbete").modal({ backdrop: 'static', keyboard: false, show: true });
                                    window.parent.history.replaceState({}, '', '/Home/Index');
                                }
                                else if (data.goodandbad === "GP") {
                                    $("#noPolicyMarbete").html(data.errorGPToSysflexMessage.replace("{0}", policyNo));
                                    $("#ppMarbete").modal({ backdrop: 'static', keyboard: false, show: true });
                                    window.parent.history.replaceState({}, '', '/Home/Index');
                                }
                                else if (data.goodandbad === "GP2") {
                                    $("#noPolicyMarbete").html(data.errorGPToSysflexMessage2.replace("{0}", policyNo));
                                    $("#ppMarbete").modal({ backdrop: 'static', keyboard: false, show: true });
                                    window.parent.history.replaceState({}, '', '/Home/Index');
                                }
                                else {
                                    $("#noPolicyMarbete").html("No. Poliza: " + policyNo);
                                    $("#ppMarbete").modal({ backdrop: 'static', keyboard: false, show: true });
                                    window.parent.history.replaceState({}, '', '/Home/Index');
                                }

                                

                                changeOptionFilter();
                                return;
                            }
                            else {
                                showError([data.message], "Pago Efectivo");
                            }
                        },
                        error: function (data, textStatus, jqXHR) {
                            var textError = data + " " + textStatus + " " + jqXHR;
                            showError([textError], 'Error Pago Efectivo');
                            return false;
                        }
                    });
                }
            }
        } else {
            showError(['No se ha podido realizar su pago.'], 'Error en Pago');
        }
    }).fail(function (data, textStatus, jqXHR) {
        showError(['No se ha podido realizar su pago.'], 'Error en Pago');
    });

    return false;
}

