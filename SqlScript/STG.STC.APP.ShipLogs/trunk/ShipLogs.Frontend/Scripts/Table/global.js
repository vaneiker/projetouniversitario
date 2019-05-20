 $("#tblShipmentDetails").hide();

var tblShip;
function CargarShipLogsjs(id) {
    var url = "/ShipLogs/CargarShipLogs?data=" + id;
    location.href = url;
} 

tblShip = $('#ShipdataTables').DataTable({
    paging: true,
    responsive: true,
    sort: false,
    pageLength: 8,
    fixedColumns: false,
    lengthChange: false,
    "searching": true,
    Info: true,
    language: {
        zeroRecords: "No registros disponibles"
    }
});


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


$(function () {
    $("#shipmentDate").datepicker({ dateFormat: "yy-mm-dd" }).val();
});

//Add New Register Detail
$(document).on('click', '#btnNextShiDet', function () { 
    ShipRandomID = Math.floor((Math.random() * -20000) + (-1));

    var $this = $(this);
    var tbl = $("#tblShipmentDetails");
    var $Tbody = tbl.find("tbody");
    var $trLast = $Tbody.find("tr:last");
    var newTr = $('<tr>').attr('id', 'trShip_' + ShipRandomID).addClass('trShip').attr('data-Shipclerandomid', ShipRandomID);
    newTr = generateNewRow(newTr); 
    $trLast.after(newTr); 


});

$(document).on('click', '#btnDeleteShiDet', function () {

    var $this = $(this);
    var randomID = $this.data('vehiclerandomid');

    var trLen = $(".trVehicle").length;
    if (trLen == 1) {
        showWarning(['Debe existir al menos un vehículo']);
        return false;
    }

    var current = altFind(AllVehicleDataToSave, function (item) {
        return item.randomId == randomID
    });

    if (current != undefined) {
        AllVehicleDataToSave = AllVehicleDataToSave.filter(function (item) {
            return item.randomId != randomID
        });
    }

    var quotationCoreNumber = getQuotationCoreNumber();
    var vehicleID = current.Id;

    if (current.SecuenciaVehicleSysflex > 0) {
        $.ajax({
            url: '/Home/DeleteVehicleOnSysflex',
            type: 'POST',
            dataType: 'json',
            data: { SecuenciaVehicleSysflex: current.SecuenciaVehicleSysflex, quotationCoreNumber: quotationCoreNumber, vehicleID: vehicleID },
            async: false,
            success: function (data) {
                if (data == "ERROR") {
                    showError(['A ocurrido un error Eliminando el Vehículo'], 'Eliminando Vehículo');
                }
            }
        });
    }

    //remuevo el Vehículo de la seccion de Vehículos
    var tr = getHtmlElementByClass("trVehicle", randomID);
    tr.remove();

    GlobalVehicleDelete = true;
});




    function generateNewRow(newTr) {
        var newInput = "";
        var newButton = "";
        var newSpan = ""; 

        //Ship Assigned To
        newTd = $('<td>');
        newInput = $('<input>').attr('id', "txtAssignedTo").addClass("form-control").attr('data-ShipRandomID', ShipRandomID).attr('value', '');
        newTd.append(newInput);
        newTr.append(newTd);

        //Ship Type the details
        newTd = $('<td>');
        newInput = $('<input>').attr('id', "txtTypethedetails").addClass("form-control").attr('data-ShipRandomID', ShipRandomID).attr('value', '');
        newTd.append(newInput);
        newTr.append(newTd);

        //Action
        newTd = $('<td>');
        newButton = $('<button>').attr('id', "btnNextShiDet")
            .addClass("btn btn-success") 
            .attr('title', 'Next Shipment Details')
            .attr('type', 'button');
            
        newButton.append('<i class="glyphicon glyphicon-plus"></i>');
        newTd.append(newButton);
        newTr.append(newTd);

        newButton = $(' <button>').attr('id', "btndeleteShipDet" + ShipRandomID)
            .addClass("btn btn-danger deleteShipDet") 
            .attr('title', 'Delete Shipment Details')
            .attr('type', 'button');
        newButton.append('<i class="glyphicon glyphicon-minus"></i>');
        newTd.append(newButton);
        newTr.append(newTd);


        return newTr;
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

               $("#ShipmentDetailsOu").hide(); 
                //$hdnIncoming.val("true");
               $("#tblShipmentDetails").show();
            } else
                if ($SelectedChk.attr("id") == "OutgoingShipment") {
                    $("#tblShipmentDetails").hide();
                    $("#ShipmentDetailsOu").show(); 
                    //$hdnIncoming.val("false");
                }
}

 

function OnSuccess(data)
{
    alert("Deja que primero yo me ejecute");
    CargarShipLogsjs(null);
}
 
function OnFailure(data)
{
    var cedulaerror = data.responseJSON.param2;
    alertify.alert(
        'Cliente y Póliza',
        '<strong>Error al generar ganador ' + cedulaerror + '</strong>',
        function () {
            alertify.error('¡Vuelva a intentarlo!');
        });
}
 
  