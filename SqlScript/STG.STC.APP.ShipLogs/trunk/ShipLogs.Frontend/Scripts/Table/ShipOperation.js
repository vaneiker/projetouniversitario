//$(document).ready(function () {

//   getInvoices();
//});

//    function getInvoices() {

     
//        var tblBody = $("#ShipdataTablesBody");
//        tblBody.empty();

//        var plno = $("#hdnPolicyNoEncr").val();

//        if (plno !== "" && plno !== undefined) {
//            $.ajax({
//                url: "/ShipLogs/_ShipLogSearch",
//                data: { policyNo: plno },
//                dataType: 'json',
//                async: true,
//                success: function (data) {

//                    if (data.cdata) {
//                        var vdata = JSON.parse(data.pinvdata);

//                        $.each(vdata, function (i, obj) {
//                            var tbltr = $('<tr>');

//                            var btn = $('<a>').attr('href', 'javascript:void(0);').addClass("btn btn-info btn-sm btnSeeInvoicePdfDetail").attr('data-plno', plno).attr('data-invoicenumber', obj.FacturaNumero);
//                            var iTag = $('<i>').addClass("fas fa-eye");
//                            btn.append(iTag);
//                            btn.append(" Ver factura");

//                            var tbltdButton = $('<td>').addClass("text-center").append(btn);

//                            var tbltd1 = $('<td>').addClass("text-center").text(obj.FacturaNumero);
//                            var tbltd2 = $('<td>').addClass("text-center").text(obj.FechaString);
//                            var tbltd3 = $('<td>').addClass("text-center").text(obj.ValorFacturaString);
//                            var tbltd4 = $('<td>').addClass("text-center").text(obj.CantidadFacturados);

//                            tbltr.append(tbltdButton);
//                            tbltr.append(tbltd1);
//                            tbltr.append(tbltd2);
//                            tbltr.append(tbltd3);
//                            tbltr.append(tbltd4);

//                            tblBody.append(tbltr);
//                        });

//                        $('.btnSeeInvoicePdfDetail').on('click', function () {

//                            var $btn = $(this);
//                            var plno = $btn.data('plno');
//                            var invoicenumber = $btn.data('invoicenumber');

//                            $.ajax({
//                                url: "/Queue/getInvoicePdf",
//                                data: { policyNo: plno, invoiceNumber: invoicenumber },
//                                dataType: 'json',
//                                async: true,
//                                success: function (data) {
//                                    window.open(data, '_blank');
//                                }
//                            });
//                        });
//                    }
//                },
//                complete: function (jqXHR, textStatus) {

//                    $('#tbltblPolicyDetailInvoicing').DataTable({
//                        paging: true,
//                        responsive: true,
//                        sort: false,
//                        pageLength: 8,
//                        fixedColumns: false,
//                        lengthChange: false,
//                        Info: true,
//                        language: {
//                            zeroRecords: "No registros disponibles"
//                        }
//                    });

//                }
//            });
//        }
//    }