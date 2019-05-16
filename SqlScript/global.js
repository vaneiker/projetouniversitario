var tblShip;
function CargarShipLogsjs(id) {
    var url = "/ShipLogs/CargarShipLogs?data=" + id;
    location.href = url;
}



//------===========START para duplicar una tabla =====================
$(document).on('click', '#btnNextShiDet', function () {

    ShipRandomID = Math.floor((Math.random() * -20000) + (-1));

    var $this = $(this);
    var tbl = $("#tblShipmentDetails");
    var $Tbody = tbl.find("tbody");
    var $trLast = $Tbody.find("tr:last");
    var newTr = $('<tr>').attr('id', 'trShip_' + ShipRandomID).addClass('trShip').attr('data-Shipclerandomid', ShipRandomID);
    newTr = generateNewRow(newTr);

    //$trLast.after(newTr);

    //generateDinamycEvents();

    //$('div.table-responsive').animate({ scrollLeft: '0' }, 300);

    //CollectData_Flot(ShipRandomID);

    //applyEventsRequiredFields(true);
});
function generateNewRow(newTr) {
    var newInput = "";
    var newButton = "";
    var newSpan = ""; 


    //vehiclePrice
    newTd = $('<td>'); 
    newInput = $('<input>').attr('id', "txtAssignedTo" + ShipRandomID).addClass("form-control").attr('data-ShipRandomID', ShipRandomID).attr('value', 0);

    //vehiclePrice
    newTd = $('<td>'); 
    newInput = $('<input>').attr('id', "txtTypethedetails" + ShipRandomID).addClass("form-control").attr('data-ShipRandomID', ShipRandomID).attr('value', 0);



    //Action
    newTd = $('<td>');
    newDiv = $('<div>');
    newButton = $('<button>').attr('id', "btnNextShiDet" + ShipRandomID)
        .addClass("btn btn-success")
        .attr('data-ShipRandomID', ShipRandomID)
        .attr('title', 'Siguiente Vehículo')
        .attr('type', 'button');
    newButton.append('<i class=glyphicon glyphicon-plus"></i>');
    newTd.append(newButton);

    newButton = $('<button>').attr('id', "btndeleteShipDet" + ShipRandomID)
        .addClass("btn btn-danger")
        .attr('data-ShipRandomID', ShipRandomID)
        .attr('title', 'Borrar Vehículo')
        .attr('type', 'button');
    newButton.append('<i class="glyphicon glyphicon-minus"></i>');
    newTd.append(newButton);

    newTr.append(newTd);

    return newTr;
}


//------===========END para duplicar una tabla =====================
            
                 
$(document).ready(function () {

    //*************START CHECK AREA************

    $('#ddCarrierSelect').on('change', function () {
        var text = this.value;
        var hdfCarrier = $("#hdfCarrierName");
        hdfCarrier.val(text);
    });


    $('#ddoperator').on('change', function () {
        var text = this.value;
        var Hdfoperator = $("#hdfoperator");
        Hdfoperator.val(text);
    });


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

   
    //*************END CHECK AREA************

 //*************STARD RESPONSE SERVICES AREA************
    function OnSuccess(data) {
        var parameter1 = data.responseJSON.param1;
        var parameter2 = data.responseJSON.param2;
        var parameter3 = data.responseJSON.param3; 

        if (parameter1 === 202) {
            alertify.alert(
                '<h1 style="color: #0a95c4; position:center; text-align:center;">¡Success!</h1>',
                '<strong>' + parameter3 + '<br/><hr/>¡Successfully saved log!' + parameter2 + '</strong > ',
                function () {
                    alertify.success('¡SUCCESSFUL!');
                });

            //CargarShipLogsjs("null")
        }
        else if (parameter1 === 404) {
            alertify.alert(
                'Cliente y Póliza',
                '<strong> Registration could not be saved successfully ' + parameter2 + '</strong>',
                function () {
                    alertify.error('¡Error!');
                });
        }
    }
    function OnFailure(data) {
        var cedulaerror = data.responseJSON.param2;
        alertify.alert(
            'Cliente y Póliza',
            '<strong>Error al generar ganador ' + cedulaerror + '</strong>',
            function () {
                alertify.error('¡Vuelva a intentarlo!');
            });


    }
    

 //*************END RESPONSE SERVICES AREA************



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

