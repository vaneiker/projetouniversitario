
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);
function beginReq(sender, args) {
    $("div.preloader").show();
}
function endReq(sender, args) {
    $("div.preloader").hide();
}

              