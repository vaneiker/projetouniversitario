$(document).ready(function () {

    $("#pnFiltros input:text").keydown(function (event) {
        if (event.which == 13)
        {
            $("#txtSearch").click();
        }
    });
});

function Init() {

    var $grid = $("#gvLoans");

    var $rows = $grid.find("tbody tr");

    $rows.on({
        dblclick: function () {
            var $row = $(this);
            var $hidden = $row.find("input:hidden");
            GotoProcess($hidden.val());
        },
        mouseover: function () {
            var $row = $(this);
            $row.css("cursor", "pointer");
        }
    });

    InitializeGrid($grid);
}

function GotoProcess(dataRequest) {
    BeginRequestHandler();
    var HideVaribleURL = $("#HideVaribleURL").val() == "true";
    var Url = "/Process/Index/" + (HideVaribleURL ? dataRequest : "?data=" + dataRequest);
    location.href = Url;

}

function Search() {

    var identificationNumber = $("#txtIdentificacion").val();
    var clienteName = $("#txtNombre").val();
    var quotationId = $("#txtSolicitud").val();
    var accountId = $("#txtPrestamo").val();
    var collateralReference = $("#txtGarantia").val();
    var chasis = $('#txtChassis').val();

    var parameters = JSON.stringify({ clienteName: clienteName, identificationNumber: identificationNumber, quotationId: quotationId, accountId: accountId, collateralReference: collateralReference, chassisNumber: chasis });

    GetPartialView("/Home/_SearchResult", parameters, function (data) {
        var $Search = $("#dvSearch");
        $Search.html(data);
        Init();
    }, true);
}