var dataQuotarion = [];
var selected = "0";
QuoationSeachInitialize = function () {
    InizitializeControls();
    InitializeChosen();
    $('#filtroHistorico').val(selected);
    //$("#filtroHistorico").trigger("chosen:updated");
    $("#filtroHistorico").trigger("change.select2");

    $('#AgentList').val('');
    //$("#AgentList").trigger("chosen:updated");
    $("#AgentList").trigger("change.select2");

    $('#AllowRedirect').val('true');
    $(document).on('click', '#DeclineSelected', function () {
        return validateDeclination();
    });


    $('#ContinueFromHistory').click(function () {
        return continueFromHistory();
    });

    var table = $('#tableHistory').DataTable({
        //scrollY: "300px",
        //scrollX: true,
        //scrollCollapse: true,
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8
        //filter:true
        //fixedColumns: false
    });


    $('#quotationId').on('change', function () {
        table
            .columns(2)
            .search(this.value)
            .draw();
    });

    $('#PrincipalIdentificationNumber').on('change', function () {
        table
            .columns(5)
            .search(this.value)
            .draw();
    });

    $('#principalName').on('change', function () {
        table
            .columns(4)
            .search(this.value)
            .draw();
    });

    $('#Created').on('change', function () {
        table
            .columns(6)
            .search(this.value)
            .draw();
    });

    $('#Product').on('change', function () {
        table
            .columns(7)
            .search(this.value)
            .draw();
    });

    $('#AgentList').on('change', function () {

        var datosAgente = $(this).val();
        var agente = "";
        if (datosAgente != '') {
            agente = JSON.parse(datosAgente).FullName;
        }

        table
            .columns(3)
            .search(agente)
            .draw();
    });
    $('#RequestTypeId').on('change', function () {

        var valor = $(this).val();

        table
            .columns(1)
            .search(valor)
            .draw();
    });

    $('#annualPrime').focusout(function () {
        refresh();
    });

    $('#taxes').focusout(function () {
        refresh();
    });

    $('#total').focusout(function () {
        refresh();
    });

    $(document).on('click', '#RefreshHistory', function () {
        LoadQuotationSearch();
    });
    componentHandler.upgradeAllRegistered();
    $("#primeOperatorSelected").val("=");
    //$("#primeOperatorSelected").trigger("chosen:updated");
    $("#primeOperatorSelected").trigger("change.select2");

    $("#taxesOperatorSelected").val("=");
    //$("#taxesOperatorSelected").trigger("chosen:updated");
    $("#taxesOperatorSelected").trigger("change.select2");

    $("#totalOperatorSelected").val("=");
    //$("#totalOperatorSelected").trigger("chosen:updated");
    $("#totalOperatorSelected").trigger("change.select2");
};


function LoadQuotationSearch() {

    $.ajax({
        type: "POST",
        url: "/QuotationSearch/QuotationSearch",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#TitleView').html('HISTORICO DE COTIZACIONES');
            $('#main').addClass('hist');
            $('#HideInHistory, #HideInHistory2').css('display', 'none');
            $('#dvContainer').html(response);
            QuoationSeachInitialize();
            $('#filtroHistorico').val('2'); //Selecciono la opcion Historico de Cotizaciones del dropdown
            //$("#filtroHistorico").trigger("chosen:updated");
            $("#filtroHistorico").trigger("change.select2");
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando las cotizaciones");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando las cotizaciones");
        }
    });
}

function validateDeclination() {
    var quotations = [];
    //;
    $('.chk').each(function (idx, obj) {
        if ($(obj).prop('checked')) {
            quotations.push({ Id: $(obj).attr('Id'), Declined: true });
        }
    });

    if (quotations.length == 0) {
        showError(["Debe seleccionar al menos una cotización"], "Declinar cotización");
        return false;
    } else {

        showQuestion("Declinar Cotización", "¿Está seguro que desea declinar la(s) Cotizaciónes seleccionadas?",
            function () {
                DeclineQuotationSelected(quotations);
            });
    }
}

function DeclineQuotationSelected(quotations) {
    $.ajax({
        url: "/QuotationSearch/DeclineQuotation",
        dataType: 'json',
        async: false,
        data: { quotations: JSON.stringify(quotations) },
        success: function (result) {
            if (result == false) {
                LoadQuotationSearch()
            } else {
                showError(["Una o más cotizaciones no fueron declinadas"], "Error declinando las cotizaciones")
                return false;
            }
        },
        error: function (ex) {
            showError([ex.responseText], "Error declinando las cotizaciones");
        }
    });
}

function loadCotationHistory() {
    $.ajax({
        type: "POST",
        url: "/QuotationSearch/QuotationSearch",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#dvContainer').html('');
            $('#dvContainer').html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function continueFromHistory() {
    //;
    var cotation = "";
    var reqType = 0;
    $('.myradio').each(function (idx, obj) {
        if ($(obj).prop('checked')) {
            cotation = $(obj).attr('Id');
            reqType = $(obj).attr('requestTypeId');
            return;
        }
    });

    if (cotation == '') {
        showError(["Debe seleccionar al menos una cotización"], "Información");
        return false;
    } else {
        //$.post('/QuotationSearch/SetVariable', { value: cotation }, function (data) {
        //    //encripted
        //    
        //    cotation = data.quotationEncripted;
        //});

        $.ajax({
            type: 'POST',
            url: '/QuotationSearch/SetVariable',
            data: { value: cotation },
            async: false,
            success: function (data) {
                //encripted

                $("#quotationID").val(cotation);

                cotation = data.quotationEncripted;

            }, error: function (response) {
                alert(response.responseText);
            }
        });

        if (reqType > 0) {
            reqType = parseInt(reqType);

            switch (reqType) {
                case 1: //emision
                    var url = window.history.pushState({ order: 1 }, document.title, '/Home/Index/' + cotation);
                    window.location.reload();
                    break;
                case 2: //Inclusion
                    LoadInclusion(true, 'INCLUSIONES');
                    break;
                case 3: //Exclusion
                    LoadInclusion(true, 'EXCLUSIONES');
                    break;
                case 5: //Cambios Vehiculo
                    LoadInclusion(true, 'CAMBIOS');
                    break;
                default: //emision
                    var url = window.history.pushState({ order: 1 }, document.title, '/Home/Index/' + cotation);
                    window.location.reload();
            }
        }
    }
}

function refresh() {
    //int pageSize,  
    var agentNameId = $('#AgentList').val();
    var quotationId = $('#quotationId').val();
    var principalName = $('#principalName').val();
    var identification = $('#PrincipalIdentificationNumber').val();
    var quotationDate = $('#Created').val();
    var businessLine = $('#BusinessLine').val();
    var plan = $('#Product').val();
    var currency = $('#Currency').val();
    var annualPrime = parseFloat($('#annualPrime').val().replace(",", ""));
    var taxes = parseFloat($('#taxes').val().replace(",", ""));
    var total = parseFloat($('#total').val().replace(",", ""));
    var primeOperatorSelected = $('#primeOperatorSelected').val();
    var taxesOperatorSelected = $('#taxesOperatorSelected').val();
    var totalOperatorSelected = $('#totalOperatorSelected').val();
    //var AgentQuotationNameID pendiente por setear este filtro

    $.ajax({
        type: "POST",
        url: "/QuotationSearch/QuotationSearch2",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        data: JSON.stringify({ agentNameId: agentNameId, quotationId: quotationId, principalName: principalName, identification: identification, quotationDate: quotationDate, businessLine: businessLine, plan: plan, currency: currency, annualPrime: annualPrime, taxes: taxes, total: total, primeOperatorSelected: primeOperatorSelected, taxesOperatorSelected: taxesOperatorSelected, totalOperatorSelected: totalOperatorSelected }),
        success: function (response) {
            $('#TitleView').html('HISTORICO DE COTIZACIONES');
            $('#main').addClass('hist');
            $('#HideInHistory, #HideInHistory2').css('display', 'none');
            $('#dvContainer').html(response);
            QuoationSeachInitialize();
            $('#filtroHistorico').val('2'); //Selecciono la opcion Historico de Cotizaciones del dropdown
            //$("#filtroHistorico").trigger("chosen:updated");
            $("#filtroHistorico").trigger("change.select2");
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando las cotizaciones");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando las cotizaciones");
        }
    });
}

function createFilterHistory() {
    var quotationsNumbers = [];

    var tableHistory = $("#tableHistory").find('tbody');
    var $select_elemQ = $("#quotationId");
    $select_elemQ.empty();
    $select_elemQ.append('<option value=""></option>');

    tableHistory.find('tr').each(function () {
        var $tds = $(this).find('td');
        var quotationId = $tds.eq(1).text();
        if (!quotationsNumbers.includes(quotationId))
            $select_elemQ.append('<option value="' + quotationId + '">' + quotationId + '</option>');

        quotationsNumbers.push(quotationId);
    });

    //$select_elemQ.trigger("chosen:updated");
    $select_elemQ.trigger("change.select2");
}

function continueToHistory() {
    var identification = $('#IdentificationNumberFilter').val();
    var DateOfBirth = $('#DateOfBirthFilter').val();
    var QuotationNumber = $('#QuotationNumberFilter').val();

    if (identification == '' && DateOfBirth == '' && QuotationNumber == '') {
        showError(["Debe indicar el número de cotización o su número de identificación y Fecha de nacimiento"], "Historico de Cotizaciones");
        return false;
    } else if (identification != '' && DateOfBirth == '') {
        showError(["Debe indicar la Fecha de nacimiento"], "Historico de Cotizaciones");
        return false;
    }

    if (DateOfBirth == '') {
        DateOfBirth = new Date(1753, 01, 01);
    }

    if (QuotationNumber != '') {
        $.ajax({
            type: "POST",
            url: "/QuotationSearch/RedirectQuotation",
            data: { quotationNumber: QuotationNumber },
            dataType: "json",
            success: function (datos) {
                if (datos.name == 'success') {
                    var url = window.history.pushState({ order: 1 }, document.title, '/Home/Index/' + datos.Value);
                    window.location.reload();

                } else {
                    showError([datos.Value], "Cotización incorrecta");
                }
            },
            failure: function (response) {
                showError([response.responseText], "Error buscando la cotización");
            },
            error: function (response) {
                showError([response.responseText], "Error buscando la cotización");
            }
        });
    } else {
        $.ajax({
            type: "POST",
            url: "/QuotationSearch/QuotationSearch",
            data: { pQuotationNumber: QuotationNumber, pIdentification: identification, pDateOfBirth: DateOfBirth },
            dataType: "html",
            success: function (response) {
                $('#ppCustomerFilter').modal('hide');
                $('#IdentificationNumberFilter').val('');
                $('#DateOfBirthFilter').val('');
                $('#QuotationNumberFilter').val('');

                $('#TitleView').html('HISTORICO DE COTIZACIONES');
                $('#main').addClass('hist');
                $('#HideInHistory, #HideInHistory2').css('display', 'none');
                $('#dvContainer').html(response);
                $('#filtroHistorico').val('2');
                //$('#filtroHistorico').trigger("chosen:updated");
                $('#filtroHistorico').trigger("change.select2");
                QuoationSeachInitialize();
            },
            failure: function (response) {
                showError([response.responseText], "Error cargando las cotizaciones");
            },
            error: function (response) {
                showError([response.responseText], "Error cargando las cotizaciones");
            }
        });
    }

}