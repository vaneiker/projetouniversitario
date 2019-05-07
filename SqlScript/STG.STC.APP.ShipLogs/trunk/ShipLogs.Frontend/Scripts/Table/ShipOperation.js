function CargarShipLogsjs(id) {
    var url = "/ShipLogs/CargarShipLogs?data=" + id;
    location.href = url;
}

$(document).ready(function () {

    $(document).ready(function () {
        $('#ShipdataTables').DataTable();
    });
}