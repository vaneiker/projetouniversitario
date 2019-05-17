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


 
$(document).on('click', '#btnNextShiDet', function () {
   

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
    }).on('keyup', function (event) { });

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

  
    ShipRandomID = Math.floor((Math.random() * -20000) + (-1));

    var $this = $(this);
    var tbl = $("#tblShipmentDetails");
    var $Tbody = tbl.find("tbody");
    var $trLast = $Tbody.find("tr:last");
    var newTr = $('<tr>').attr('id', 'trShip_' + ShipRandomID).addClass('trShip').attr('data-Shipclerandomid', ShipRandomID);
    newTr = generateNewRow(newTr); 
    $trLast.after(newTr); 


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

function OnSuccess(data) {


    var a = data;

    
 
    $.ajax({
        type: 'POST',
        url: '/ShioLogs/SaveShipMantenDetail',
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (data) {
            if (data.status) {
                alert('Successfully saved');
                //here we will clear the form
                list = [];
                $('#orderNo,#orderDate,#description').val('');
                $('#orderdetailsItems').empty();
            }
            else {
                alert('Error');
            }
            $('#submit').text('Save');
        },
        error: function (error) {
            console.log(error);
            $('#submit').text('Save');
        }
    });
}
 
    });

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
 
 
       
        


        
        //$('#ddCarrier').on('change', function () {
        //    var text = this.value;
        //    tblShip.columns(0).search(text).draw();
        //});

        //$('#ShipmentNumber').on('change', function () {
        //    var text = this.value;
        //    tblShip.columns(2).search(text).draw();
        //});

        //$('#ShipmentSender').on('change', function () {
        //    var text = this.value;
        //    tblShip.columns(4).search(text).draw();
        //});

        //$('#ShipmentReceiver').on('change', function () {
        //    var text = this.value;
        //    tblShip.columns(5).search(text).draw();
        //});

        //$('#ddLogType').on('change', function () {
        //    var text = this.value;
        //    var a = tblShip.columns(6).search(text).draw();

        //});


      
 