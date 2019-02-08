$(document).ready(function () {
    Init();
});
function SetStage(index, obj) {
    $("#UlMainMenu").find("li").removeClass("active");
    $(obj).addClass("active");
    $("#dvMenues").find("div").hide();
    switch (index) {
        case 1:
            $("#dvPromesasDelDia").show();
            GetQueueData(1);
            break;
        case 2:
            $("#dvCobranzasCorrectivas").show();

            GetQueueData(1001);


            break;
        case 3:
            $("#dvCobranzasJudiales").show();
            GetQueueData(2000);
            break;
    }



}

function goToProcess(LoanNumber){

    window.location.href = "/Process/Index";
}

function GetQueueData(QueueId) {
    GetPartialView("/Queue/_QueueData", JSON.stringify({ QueueId: QueueId }), function (data) {
        var ContainerId = "#divQueueData";

        var $Container = $(ContainerId);
        $Container.html(data);
        Init();
    }, true);
}


function Init() {

    var $grid = $("#gvLoansQueue");

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