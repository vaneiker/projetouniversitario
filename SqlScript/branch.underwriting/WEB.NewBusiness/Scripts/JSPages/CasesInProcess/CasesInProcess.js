var lang = "";
function pageLoad() {   
   
    lang = $("#hdnLang").val();
    sessionTimeout = $("#hdnTimeOut").val();

    Configutations();
    fixheight();
    SetDatePicker();

    $("select").attr('onkeydown', 'return (event.keyCode!=8 && event.keyCode!=13)');

    $(".dxWeb_pcCloseButton").hide();

    var checkMark = "<div> <input type='checkbox' id='chkAll'/> </div>";

    //Insertar el checkMark SelectAll        
    var Grid = $("#gvCasesInProcess");

    var td = $(Grid).find("tr[id*='DXHeadersRow']").find("td:first");
    td.html("");
    td.append(checkMark);

    setClickCheckBoxGridView('#gvCasesInProcess', 'chkAll');

    $("#gvCasesInProcess").find("input[id='chkAll']").click(function () {
        SelectAll(this, "#gvCasesInProcess");
    });

    $('#chkAll').click(function () {
        SelectAll(this, ".gvResult");
    });

    if ($("#hdnShowPopAddCommment").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopAddComment",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: lang=="en"?"COMMENTS":"COMENTARIOS",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hdnShowPopAddCommment").val("false"); }
        });
    }
}

CloseNotesCommentPop = function () {
    $("#dvPopAddComment").dialog("close");
};  

ConfirmPrintList = function (sender) {

    var TotalCheck = CountCheck('#gvCasesInProcess');

    if (TotalCheck == 0) {
        CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", "gridSelectionValidation");
        return false;
    }
}; 

ConfirmReadyToReview = function (sender) {

    var TotalCheck = CountCheck('#gvCasesInProcess');

    if (TotalCheck == 0) {
        CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", "gridSelectionValidation");        
        return false;
    }
    return DlgConfirm(sender);
};

CloseNotesCommentPop = function () {
    $("#dvPopAddComment").dialog("close");
};

function CancelNotesCommentPop() {
    $('#txtNewComment').val("");
    $('#pnComment').toggle();
    RelocatePops();
    return false;
}

ValidateCommentNote = function () {
    if ($.trim($('#txtNewComment').val()) == "") {
        CustomDialogMessageEx(null, 350, 150, true, lang == "en" ? "Warning" : "Advertencia", 'CommentMessage');
        return false;
    }
}

