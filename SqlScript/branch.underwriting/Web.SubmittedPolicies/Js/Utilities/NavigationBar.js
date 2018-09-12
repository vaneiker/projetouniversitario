function TabSelect() {
    var currentTab = $("#hdnTabSelect").val();

    $($("main_menu").find("div:first").find("ul:first")).find("li").removeClass("active");


    switch (currentTab) {
        case "Automatic":
            $("#lnk_Automatic").addClass("active");
            break;
        case "NoMatches":
            $("#lnk_NoMatches").addClass("active");
            break;

        case "Individual":
            $("#lnk_Individual").addClass("active");
            break;

        case "NightlyWatch":
            $("#lnk_NightlyWatch").addClass("active");
            break;

        case "HistoricalResults":
            $("#lnk_HistoricalResults").addClass("active");
            break;

        case "GeneralSearch":
            $("#lnk_GeneralSearch").addClass("active");
            break;
    }
}

function bg_filterChange() {
    $('.dxGridView_gvHeaderFilter').attr('src', "");
    $('.dxGridView_gvHeaderFilter').addClass('filterBackground');
}

