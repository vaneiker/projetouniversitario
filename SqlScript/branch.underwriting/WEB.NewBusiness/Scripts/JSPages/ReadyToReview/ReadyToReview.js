var popRejectComment = null;
var lang = "";
function pageLoad() {      

    lang = $("#hdnLang").val();
    sessionTimeout = $("#hdnTimeOut").val();
    Configutations();
    fixheight();
    SetDatePicker();

    $(".dxWeb_pcCloseButton").hide();

    var checkMark = "<div> <input type='checkbox' id='chkAll'/> </div>";

    //Insertar el checkMark SelectAll        
    var Grid = $("#gvReadyToReview");

    var td = $(Grid).find("tr[id*='DXHeadersRow']").find("td:first");
    td.html("");
    td.append(checkMark);

    setClickCheckBoxGridView('#gvReadyToReview', 'chkAll');

    $("#gvReadyToReview").find("input[id='chkAll']").click(function () {
        SelectAll(this, "#gvReadyToReview");
    });

    $('#chkAll').click(function () {
        SelectAll(this, ".gvResult");
    });

    if ($("#hdnShowPopReject").val() == "true") {
        popRejectComment = new JQueryPopup({
            ElementIDorClass: "#dvCommentReject",
            pautoOpen: true,
            pmaxwidth: 702,
            pShowTitleBar: true,
            pTitle: lang == "en" ? "REJECT COMMENT":"COMENTARIOS DE RECHAZO",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hdnShowPopReject").val("false"); }
        });
    }

    if ($("#hdnShowPopComment").val() == "true") {
        popRejectComment = new JQueryPopup({
            ElementIDorClass: "#dvPopAddComment",
            pautoOpen: true,
            pmaxwidth:750,
            pShowTitleBar: true,
            pTitle: lang == "en" ? "COMMENTS":"COMENTARIOS",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hdnShowPopComment").val("false"); }
        });
    } 
}

validaReject = function (sender) {
    if ($.trim($('#CommentTxt').val()) == "")
    {
        CustomDialogMessageEx(null, 250, 150, true, lang == "en" ? 'Warning' : 'Advertencia', 'RejectReasonMessage');
        return false;
    }   
    return DlgConfirmWithFuncCallBack(null, "", null, null, function () { BeginRequestHandler(); setTimeout(function () { __doPostBack($(sender).attr("name"), ''); }, 100); }, null);
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
        CustomDialogMessageEx(null, 350, 150, true, lang == "en" ? 'Warning' : 'Advertencia', 'CommentMessage');
        return false;
    }
}

ConfirmSubmitToSTL = function (sender) {
    var TotalCheck = CountCheck('#gvReadyToReview');

    if (TotalCheck == 0) {
        CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", "gridSelectionValidation");
        return false;
    }
};

ConfirmPrintList = function (sender) {
    var TotalCheck = CountCheck('#gvReadyToReview');

    if (TotalCheck == 0) {
        CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", "gridSelectionValidation");
        return false;
    }
};

CallExecuteOnCloseEvent = function (sender, selectedDate) { 
    if (selectedDate != "") {

        var FromTxt = $("#FromTxt");
        var Totxt = $("#ToTxt");

        if (FromTxt.val() != "" && Totxt.val() != "") {

            var DateFrom = FromTxt.val().ToDate("mm/dd/yyyy");
            var DateTo = Totxt.val().ToDate("mm/dd/yyyy");
            if (DateTo < DateFrom) {
                $(sender).val("");
                $(sender).focus();
                CustomDialogMessageEx(null, null, null, true, lang == "en" ? 'Warning' : 'Advertencia', "DateRangeValidation");
            }
        }
    }
}



