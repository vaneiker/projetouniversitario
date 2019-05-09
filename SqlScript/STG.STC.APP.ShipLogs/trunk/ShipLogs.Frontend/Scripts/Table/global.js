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

    //$('#ddCarrier').on('change', function () {
    //    tblShip.columns(1).search(this.value).draw();
    //});



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


});




 