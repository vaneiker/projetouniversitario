var lang = "";

function pageLoad() {

    lang = $("#hdnLang").val();
    sessionTimeout = $("#hdnTimeOut").val();

    Configutations();

    fixheight();

    $(".dxWeb_pcCloseButton").hide();

    $(".dxucBrowseButton_DevEx").remove();
    $(".dxucTextBox_DevEx").css("border-right-width", "1px");

    //Cambiar de Tab
    var CurrentTab = $("#hdnCurrentTabSubmittedPolicies").val();

    if (CurrentTab != null && CurrentTab != "")
        ChangeTab(CurrentTab);

    var CurrentTabReceiptPopUp = $("#hdnCurrentTabUploadReceiptPopUp").val();

    if (CurrentTabReceiptPopUp != null && CurrentTabReceiptPopUp != "")
        ChangeTabReceipt(CurrentTabReceiptPopUp);

    var checkMark = "<div> <input type='checkbox' id='chkAll'/> </div>";

    //Insertar el checkMark SelectAll        
    var Grid = $("#gvSubmittedPolcies,#gvEffectivePendingReceipt");

    var td = $(Grid).find("tr[id*='DXHeadersRow']").find("td:first");
    td.html("");
    td.append(checkMark);

    setClickCheckBoxGridView('#gvSubmittedPolcies', 'chkAll');

    $("#gvSubmittedPolcies").find("input[id='chkAll']").click(function () {
        SelectAll(this, "#gvSubmittedPolcies");
    });

    $("#gvEffectivePendingReceipt").find("input[id='chkAll']").click(function () {
        SelectAll(this, "#gvEffectivePendingReceipt");
    });

    if ($("#hdnShowPopAddCommment").val() == "true") {
        JQueryPopup({
            ElementIDorClass: "#dvPopAddComment",
            pautoOpen: true,
            pShowTitleBar: true,
            pTitle: "COMMENTS",
            pmodal: true,
            presizable: false,
            OnCLose: function () { $("#hdnShowPopAddCommment").val("false"); }
        });
    }

    $("#txtClienSignatureDateReceipt").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(),//fecha de hoy
        defaultDate: new Date(),
        yearRange: "c-100:c+100",
        onSelect: function (selectedDate) {
            changeBorderColor(this);
        },
        onClose: function (selectedDate) {
            changeBorderColor(this);
        }
        ,
        beforeShow: function () {
            setPositionElementDatePicker($("#ui-datepicker-div"), $(this))
        }
    }).inputmask('mm/dd/yyyy');

    $("#txtClienSignatureDateAmmedment").datepicker({
        changeMonth: true,
        changeYear: true,
        maxDate: new Date(), //la fecha de hoy
        minDate: $("#hdnAmmendmentDate").val(),//la fecha que me manda es el from
        defaultDate: new Date(),
        yearRange: "c-100:c+100",
        onSelect: function (selectedDate) {
            changeBorderColor(this);
        },
        onClose: function (selectedDate) {
            changeBorderColor(this);
        },
        beforeShow: function () {
            setPositionElementDatePicker($("#ui-datepicker-div"), $(this))
        }
    }).inputmask('mm/dd/yyyy');

    SetDatePicker();
}

uploadFile = function () {
    $("#btnUploadFile").click();
}

function ClosePendingReceiptPop() {
    $('#btnClearPdf').trigger('click');
    $find("popupBhvr").hide();
    return false;
}

CallExecuteOnCloseEventAmmedment = function (sender, selectedDate) {
    if (selectedDate != "") {
        var fecha = new Date();
        var pDate = (fecha.getMonth() + 1) + "/" + fecha.getDate() + "/" + fecha.getFullYear();
        var maxDateAttr = $(sender).datepicker("option", "maxDate");
        pDate = $.datepicker._determineDate($("#tb_WUC_PI_DateBirth").data("datepicker"), maxDateAttr, new Date());
        message = 'The age of this contact cannot be less than 2 years, please try again.';

    }
}

function uploadFilePendingReceiptComplete(sender, event) {

    if (event != '') {
        if (event.callbackData != '') {
            $("#hdnCurrentTabUploadReceiptPopUp").val("lnkReceipt");
            $('#btnPendingReceiptPreviewPDF').trigger('click');
            sender.ClearText();
        }
    }
}

function validateEmptyField() {
    var returnVal = true;

    if (!$("#txtClienSignatureDateAmmedment").prop('disabled')) {
        if ($("#txtClienSignatureDateAmmedment").val().trim() == "") {

            returnVal = false;
            CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", 'SignatureClientAmendmentValidation');
            $("#txtClienSignatureDateAmmedment").focus();
        }
    }
    if (!$("#txtClienSignatureDateReceipt").prop('disabled')) {
        if ($("#txtClienSignatureDateReceipt").val().trim() == "") {

            returnVal = false;
            CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", 'SignatureClientReceiptValidation');
            $("#txtClienSignatureDateReceipt").focus();
        }
    }

    return returnVal;
}

function uploadFilePendingAmedmentComplete(sender, event) {
    if (event != '') {
        $("#hdnCurrentTabUploadReceiptPopUp").val("lnkAmendment");
        if (event.callbackData != '') {
            $('#btnPendingAmedmentFilePDF').trigger('click');
            sender.ClearText();
        }
    }
}

CloseNotesCommentPop = function () {
    $("#dvPopAddComment").dialog("close");
};

function CancelNotesCommentPop() {
    $('#txtNewComment').val("");
    $('#pnComment').toggle();
    RelocatePops();
    return false;
}

ChangeTab = function (Tab) {

    //Limpiar
    $("#MenuTabs li").removeClass("active");

    vTab = $('#' + Tab);

    $(vTab).parent().addClass("active");

};

ChangeTabReceipt = function (Tab) {

    //Limpiar
    $("#MenuTabsPopUp li").removeClass("active");

    vTab = $('#' + Tab);

    $(vTab).parent().addClass("active");

};

ActiveCurrentLink = function (sender) {
    var currentTab = $(sender).attr('id');
    $("#hdnCurrentTabUploadReceiptPopUp").val(currentTab);
}

ConfirmPrintList = function (sender) {
    var CurrentTab = $("#hdnCurrentTabSubmittedPolicies").val();

    var TotalCheck = CountCheck('#' + (CurrentTab == "lnkSubmittedPolicies" ? "gvSubmittedPolcies" : "gvEffectivePendingReceipt"));

    if (TotalCheck == 0) {
        CustomDialogMessageEx(null, 500, 150, true, lang == "en" ? "Warning" : "Advertencia", "gridSelectionValidation");
        return false;
    }
};

ValidateCommentNote = function () {

    if ($.trim($('#txtNewComment').val()) == "") {
        CustomDialogMessageEx(null, 350, 150, true, lang == "en" ? "Warning" : "Advertencia", 'CommentMessage');
        return false;
    }
};

function uploadFileChange(sender, event) {
    sender.Upload();
}

validateDate = function () {
    var FromTxt = $("#FromTxt");
    var Totxt = $("#ToTxt");
    var DateFrom = FromTxt.val().ToDate("mm/dd/yyyy");
    var DateTo = Totxt.val().ToDate("mm/dd/yyyy");

    if (FromTxt.val() != "" && Totxt.val() != "") {
        if (DateTo < DateFrom) {
            CustomDialogMessageEx(null, null, null, true, lang == "en" ? "Warning" : "Advertencia", "DateRangeValidation");
            return false;
        }
    }

    return true;
};

CallExecuteOnCloseEvent = function (sender, selectedDate) {

}

