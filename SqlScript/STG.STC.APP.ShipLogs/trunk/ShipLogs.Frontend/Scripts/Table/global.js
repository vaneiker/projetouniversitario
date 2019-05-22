 
$(document).ready(function () {  
    //Verifico si es un Incoming o Outgoing
    //Para poder mostrar o no los detalles

    var hv = $('#IsIncomingHDN').val();  


    if (hv == "true") {
        $("#tblShipmentDetails").show();
        $("#ShipmentDetailsOu").hide();
    }else
    if (hv == "false") {
        $("#tblShipmentDetails").hide();
        $("#ShipmentDetailsOu").show();
        }

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

     
});



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
 


function generateNewRow(newTr) {
    var newInput = "";
    var newButton = "";
    var newSpan = "";

    //Ship Assigned To
    newTd = $('<td>');
    newInput = $('<input>').attr('id', "txtAssignedTo").addClass("form-control txtAssignedTo").attr('data-ShipRandomID', ShipRandomID).attr('value', '');
    newTd.append(newInput);
    newTr.append(newTd);

    //Ship Type the details
    newTd = $('<td>');
    newInput = $('<input>').attr('id', "txtTypethedetails").addClass("form-control txtTypethedetails").attr('data-ShipRandomID', ShipRandomID).attr('value', '');
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

function OnSuccess(data) {

    var idShip   = data.param3;
    var typeShip = data.param4;
    var typeoper = data.param5;
    var hdnShipId = $("#shipUniqueID");

    hdnShipId.val(idShip);
    
    if (typeShip == "Incoming" && typeoper == "UPDATE") {
        saveDateShip(idShip, typeoper);

    } else if (typeShip == "Incoming" && typeoper == "INSERT") {
        saveDateShip(idShip, typeoper);
    }
}

function OnFailure(data) {
    //var cedulaerror = data.responseJSON.param2;
    //alertify.alert(
    //    'Cliente y Póliza',
    //    '<strong>Error al generar ganador ' + cedulaerror + '</strong>',
    //    function () {
    //        alertify.error('¡Vuelva a intentarlo!');
    //    });
}

function saveDateShip(shipuniqueid, option) {

    var tblDetail = $("#tblShipmentDetails");
    var $Tbody = tblDetail.find("tbody tr");
    var listDetails = [];

    $.each($Tbody, function (index, vhs) {

        var $thisTr = $(this);

        var dShips = {};
        dShips.txtAssignedTo = "";
        dShips.txtTypethedetails = "";

        var obTxtAssignedTo = $thisTr.find('.txtAssignedTo');

        if (obTxtAssignedTo.length > 0) {
            dShips.txtAssignedTo = obTxtAssignedTo.val();
        }

        var txtTypethedetails = $thisTr.find('.txtTypethedetails');

        if (txtTypethedetails.length > 0) {
            dShips.txtTypethedetails = txtTypethedetails.val();
        }

        listDetails.push(dShips);
    });

    $.ajax({
        url: '/ShipLogs/SaveDet',
        type: 'POST',
        dataType: 'json',
        data: {
            jsonDataDetail: JSON.stringify(listDetails),
            idHeader: shipuniqueid,
            operation: option
        },
        async: true,
        success: function (data) {
          

            if (data.messageError) {
                showError([data.messageError], "Ha ocurrido el siguiente error");
                return false;
            }

            re = true;
            //$("#spQuotationNumber").text(data.QuotationNumber + " / " + );
            //$("#quotationID").val(data.QuotationId);

            //$("#lnkContinue").off("click");
        }
    });
}


 