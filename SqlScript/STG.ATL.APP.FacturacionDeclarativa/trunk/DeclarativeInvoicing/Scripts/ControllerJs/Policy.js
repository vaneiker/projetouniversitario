$(document).ready(function () {

    $("#btnSendInvoicing").click(function () {
        var jsondata = $("#hdnPolicyData").val();
        var result = validateInvoicingDate(jsondata);
        return result;
    });

    preparejdtable();
    
    getInvoices();
});

function validateInvoicingDate(jsondata) {

    var result = false;

    $.ajax({
        url: "/Policy/validateInvoicingDate",
        data: { jsondata: jsondata },
        dataType: 'json',
        async: false,
        success: function (data) {

            if (data.messageError !== "") {
                showError([data.messageError], "Validando Periodo");
                result = false;

                //showQuestion(data.messageError, "Validando Periodo",
                //    function () {//Si precionan Ok
                //        ProcessDeclarativePolicy(jsondata);
                //    },
                //    function () {//Si precionan Cancelar
                //        result = false;
                //    });
            }
            else {
                ProcessDeclarativePolicy(jsondata);
            }
        }
    });

    return result;
}

function ProcessDeclarativePolicy(jsondata) {

    $.ajax({
        url: "/Policy/ProcessDeclarativePolicy",
        data: { jsondata: jsondata },
        dataType: 'json',
        async: true,
        success: function (data) {
            if (data.messageError !== "") {
                showError([data.messageError]);
            }

            if (data.success) {

                showSucess(['Facturacion realizada correctamente'], '', function () {
                    location.href = "/Queue/Index";
                });
                //redireccionar al queue
            }

        }
    });

}

function getInvoices() {
    
    if ($.fn.DataTable.isDataTable('#tbltblPolicyDetailInvoicing')) {
        $('#tbltblPolicyDetailInvoicing').DataTable().destroy();
    }

    var tblBody = $("#tblPolicyDetailInvoicingBody");
    tblBody.empty();

    var plno = $("#hdnPolicyNoEncr").val();

    if (plno !== "" && plno !== undefined) {
        $.ajax({
            url: "/Queue/getPolicyInvoices",
            data: { policyNo: plno },
            dataType: 'json',
            async: true,
            success: function (data) {

                if (data.cdata) {
                    var vdata = JSON.parse(data.pinvdata);

                    $.each(vdata, function (i, obj) {
                        var tbltr = $('<tr>');

                        var btn = $('<a>').attr('href', 'javascript:void(0);').addClass("btn btn-info btn-sm btnSeeInvoicePdfDetail").attr('data-plno', plno).attr('data-invoicenumber', obj.FacturaNumero);
                        var iTag = $('<i>').addClass("fas fa-eye");
                        btn.append(iTag);
                        btn.append(" Ver factura");

                        var tbltdButton = $('<td>').addClass("text-center").append(btn);

                        var tbltd1 = $('<td>').addClass("text-center").text(obj.FacturaNumero);
                        var tbltd2 = $('<td>').addClass("text-center").text(obj.FechaString);
                        var tbltd3 = $('<td>').addClass("text-center").text(obj.ValorFacturaString);
                        var tbltd4 = $('<td>').addClass("text-center").text(obj.CantidadFacturados);

                        tbltr.append(tbltdButton);
                        tbltr.append(tbltd1);
                        tbltr.append(tbltd2);
                        tbltr.append(tbltd3);
                        tbltr.append(tbltd4);

                        tblBody.append(tbltr);
                    });

                    $('.btnSeeInvoicePdfDetail').on('click', function () {

                        var $btn = $(this);
                        var plno = $btn.data('plno');
                        var invoicenumber = $btn.data('invoicenumber');

                        $.ajax({
                            url: "/Queue/getInvoicePdf",
                            data: { policyNo: plno, invoiceNumber: invoicenumber },
                            dataType: 'json',
                            async: true,
                            success: function (data) {
                                window.open(data, '_blank');
                            }
                        });
                    });
                }
            },
            complete: function (jqXHR, textStatus) {

                $('#tbltblPolicyDetailInvoicing').DataTable({
                    paging: true,
                    responsive: true,
                    sort: false,
                    pageLength: 8,
                    fixedColumns: false,
                    lengthChange: false,
                    Info: true,
                    language: {
                        zeroRecords: "No registros disponibles"
                    }
                });

            }
        });
    }
}


function preparejdtable() {
    //

    gTblActiveVh = $('#tblActiveVh').DataTable({
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8,
        fixedColumns: false,
        lengthChange: false,
        Info: true,
        language: {
            zeroRecords: "No registros disponibles"
        }
    });

    $('#txtActiveClient').on('keyup', function () {
        var text = this.value;
        gTblActiveVh.columns(1).search(text).draw();
    });

    $('#txtActiveChasis').on('keyup', function () {
        var text = this.value;
        gTblActiveVh.columns(5).search(text.toUpperCase()).draw();
    });

    //

    //

    gTblExcludeVh = $('#tblExcludeVh').DataTable({
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8,
        fixedColumns: false,
        lengthChange: false,
        Info: true,
        language: {
            zeroRecords: "No registros disponibles"
        }
    });

    $('#txtExcludeClient').on('keyup', function () {
        var text = this.value;
        gTblExcludeVh.columns(1).search(text).draw();
    });

    $('#txtExcludeChasis').on('keyup', function () {
        var text = this.value;
        gTblExcludeVh.columns(5).search(text.toUpperCase()).draw();
    });

    //

    //

    gTblIncludeVh = $('#tblIncludeVh').DataTable({
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8,
        fixedColumns: false,
        lengthChange: false,
        Info: true,
        language: {
            zeroRecords: "No registros disponibles"
        }
    });

    $('#txtIncludeClient').on('keyup', function () {
        var text = this.value;
        gTblIncludeVh.columns(1).search(text).draw();
    });

    $('#txtIncludeChasis').on('keyup', function () {
        var text = this.value;
        gTblIncludeVh.columns(5).search(text.toUpperCase()).draw();
    });

    //

}