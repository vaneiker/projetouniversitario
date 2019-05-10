var tblShip;
function CargarShipLogsjs(id) {
    var url = "/ShipLogs/CargarShipLogs?data=" + id;
    location.href = url;
}

$(document).ready(function () {

    tblShip = $('#ShipdataTables').DataTable({
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8,
        fixedColumns: false,
        lengthChange: false,
        "searching": false,
        Info: true,
        language: {
            zeroRecords: "No registros disponibles"
        }
    });
    $('#ddCarrier').on('change', function () {
        var text = this.value;
        tblShip.columns(0).search(text).draw();
    });

    $('#ShipmentNumber').on('change', function () {
        var text = this.value;
        tblShip.columns(2).search(text).draw();
    });

    $('#ShipmentSender').on('change', function () {
        var text = this.value;
        tblShip.columns(4).search(text).draw();
    });

    $('#ShipmentReceiver').on('change', function () {
        var text = this.value;
        tblShip.columns(5).search(text).draw();
    });

    $('#ddLogType').on('change', function () {
        var text = this.value;
        var a = tblShip.columns(6).search(text).draw();

    });


    //Auto completado de los curries
    $("#CarrierName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/ShipLogs/GetCurrier",
                data: JSON.stringify({ searchString: $.trim($("#CarrierName").val()) }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    //$("#txtABANumber").css("background-repeat", "no-repeat");
                    //$("#CarrierName").css("background-position", "right");
                    //$("#CarrierName1").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.CarrierName, value: item.CarrierName

                        };
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
            alert('Usted selecciono el id = ' + ui.item.id);

        },
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    }).on('keyup', function (event) {

    });
});


function setShiptmentMaterialsType(obj) {
    var $SelectedChk = $(obj);

    var $hdnMaterials = $("#Materials");
    if ($SelectedChk.attr("id") == "MaterialsShipment") {
        $hdnIncoming.val("true");
    }   
}


function setShiptmentType(obj) {
 
    var $SelectedChk = $(obj);

    AtiveModeShiptmentType($SelectedChk);
    var $hdnIncoming = $("#Incoming");
    if ($SelectedChk.attr("id") == "incomingShipment") {
        $hdnIncoming.val("true");
    } else
        if ($SelectedChk.attr("id") == "OutgoingShipment") {
            $hdnIncoming.val("false");
        }
}

function AtiveModeShiptmentType(obj) {
    var $SelectedChk = $(obj);
    var $hdnIncoming = $("#Incoming");
    if ($SelectedChk.attr("id") == "incomingShipment") {
        alert("Muestro la opcion para poder guardar Incoming");
        //$hdnIncoming.val("true");

    } else
        if ($SelectedChk.attr("id") == "OutgoingShipment") {
            alert("Muestro la opcion para poder guardar Ougoing");
            //$hdnIncoming.val("false");
        }
}
