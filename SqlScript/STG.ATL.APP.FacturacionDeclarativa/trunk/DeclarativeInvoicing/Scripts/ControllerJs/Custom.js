var gTblActiveVh;
var gTblExcludeVh;
var gTblIncludeVh;
var qtblQueue;
var qtblHistoric;

$(document).ready(function () {

    $(document).ajaxStart(function () {
        BeginRequestHandler();
    });

    $(document).ajaxStop(function () {
        EndRequestHandler();
    });

    $('.mydatepicker').datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date(),
        onSelect: function (dateText) {
        }
    });

    $('.mydatepickerAllDate').datepicker({
        changeMonth: true,
        changeYear: true,
        minDate: new Date(2019, 0, 1),
        onSelect: function (dateText) {
        }
    });

    prepareJqDatatables();

    $("#tblQueue").on("click", ".btnPolicyDetail", function () {

        var $btn = $(this);

        var plno = $btn.data('plno');

        var pdata = $btn.data('pdata');

        $.ajax({
            url: "/Policy/Index",
            data: { Policy: plno, Period: pdata },
            //dataType: 'json',
            async: true,
            success: function (data) {

                $("#content").html(data);
                
                var realUrl = "/Policy/Index?Policy=" + plno + "&Period=" + pdata + "&partial=No";
                window.history.replaceState({}, document.title, realUrl);
            },
            complete: function (jqXHR, textStatus) {
            }
        });
    });

    $("#btnCloseModalTblInvoices").on("click", function () {
        $("#tblInvoices").off("click", ".btnSeeInvoicePdf");
        return true;
    });

    $("#tblQueue").on("click", ".btnAllPolicyItems", function () {

        if ($.fn.DataTable.isDataTable('#tblPolicyItems')) {
            $('#tblPolicyItems').DataTable().destroy();
        }

        var $btn = $(this);

        var plno = $btn.data('plno');

        $("#txtPolicy").val("");
        $("#txtInsured").val("");
        $("#txtVigencyStart").val("");
        $("#txtVigencyEnd").val("");
        var tblBody = $("#tblBodyPolicyItems");
        tblBody.empty();

        if (plno !== "") {

            $.ajax({
                url: "/Queue/getPolicyItems",
                data: { policyNo: plno },
                dataType: 'json',
                async: true,
                success: function (data) {

                    if (data.cdata) {
                        var vdata = JSON.parse(data.vdata);
                        var cldata = JSON.parse(data.cdata);

                        $("#txtPolicy").val(cldata.Policy);
                        $("#txtInsured").val(cldata.Insured);
                        $("#txtVigencyStart").val(cldata.StartDate);
                        $("#txtVigencyEnd").val(cldata.EndDate);

                        $.each(vdata, function (i, obj) {
                            var tbltr = $('<tr>');
                            var tbltd1 = $('<td>').addClass("text-center").text(obj.Item);
                            var tbltd2 = $('<td>').addClass("text-center").text(obj.Marca);
                            var tbltd3 = $('<td>').addClass("text-center").text(obj.Modelo);
                            var tbltd4 = $('<td>').addClass("text-center").text(obj.Ano);
                            var tbltd5 = $('<td>').addClass("text-center").text(obj.chasis);
                            var tbltd6 = $('<td>').addClass("text-center").text(obj.placa);

                            var colorClass = "text-success";

                            if (obj.EstatusItem === "EXCLUIDO" || obj.EstatusItem === "EXCLUSION") {
                                colorClass = "text-danger";
                            }

                            var c = $('<strong>').addClass(colorClass).text(obj.EstatusItem);
                            var tbltd7 = $('<td>').addClass("text-center").append(c);

                            tbltr.append(tbltd1);
                            tbltr.append(tbltd2);
                            tbltr.append(tbltd3);
                            tbltr.append(tbltd4);
                            tbltr.append(tbltd5);
                            tbltr.append(tbltd6);
                            tbltr.append(tbltd7);

                            tblBody.append(tbltr);
                        });
                    }
                },
                complete: function (jqXHR, textStatus) {

                    $('#tblPolicyItems').DataTable({
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

                    $("#items_modal").modal({ backdrop: 'static', keyboard: false, show: true });
                }
            });
        }
    });

    $("#tblQueue").on("click", ".btnInvoices", function () {

        if ($.fn.DataTable.isDataTable('#tblInvoices')) {
            $('#tblInvoices').DataTable().destroy();
        }

        var $btn = $(this);

        var plno = $btn.data('plno');

        $("#txtPolicy").val("");
        $("#txtInsured").val("");
        $("#txtVigencyStart").val("");
        $("#txtVigencyEnd").val("");

        var tblBody = $("#tblBodyPolicyInvoices");
        tblBody.empty();

        $.ajax({
            url: "/Queue/getPolicyInvoices",
            data: { policyNo: plno },
            dataType: 'json',
            async: true,
            success: function (data) {

                if (data.cdata) {
                    var vdata = JSON.parse(data.pinvdata);
                    var cldata = JSON.parse(data.cdata);

                    $("#txtPolicyInv").val(cldata.Policy);
                    $("#txtInsuredInv").val(cldata.Insured);
                    $("#txtVigencyStartInv").val(cldata.StartDate);
                    $("#txtVigencyEndInv").val(cldata.EndDate);

                    $.each(vdata, function (i, obj) {
                        var tbltr = $('<tr>');

                        var btn = $('<a>').attr('href', 'javascript:void(0);').addClass("btn btn-info btn-sm btnSeeInvoicePdf").attr('data-plno', plno).attr('data-invoicenumber', obj.FacturaNumero);
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
                }
            },
            complete: function (jqXHR, textStatus) {

                $('#tblInvoices').DataTable({
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

                $("#invoices_modal").modal({ backdrop: 'static', keyboard: false, show: true });

                $("#tblInvoices").on("click", ".btnSeeInvoicePdf", function () {

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
        });
    });

    $("#tblHistoric").on("click", ".btnSeeInvoiceHistoricPdf", function () {

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

});

function prepareJqDatatables() {
    
    qtblQueue = $('#tblQueue').DataTable({
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

    $('#txtQueuePolicy').on('keyup', function () {
        var text = this.value;
        qtblQueue.columns(1).search(text).draw();
    });

    //$('#txtQueueDate').on('keyup', function () {
    //    var text = this.value;
    //    qtblQueue.columns(5).search(text).draw();
    //});

    $('#ddlQueueDate').on('change', function () {
        var text = this.value;
        qtblQueue.columns(4).search(text).draw();
    });

    $('#txtQueueInsured').on('keyup', function () {
        var text = this.value;
        qtblQueue.columns(2).search(text).draw();
    });

    $('#txtQueueAgent').on('keyup', function () {
        var text = this.value;
        qtblQueue.columns(3).search(text).draw();
    });


    qtblHistoric = $('#tblHistoric').DataTable({
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

    //$('#ddlQueueDateHistoric').on('change', function () {
    //    var text = this.value;
    //    qtblHistoric.columns(3).search(text).draw();
    //});

}