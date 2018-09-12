function pageLoad() {
    var TabSelected = $("#hfCurrentTabSelected").val();

    $("#menu").find("a").each(function () {
        $(this).removeClass("active");
    });

    $("#" + TabSelected).addClass("active");
}
