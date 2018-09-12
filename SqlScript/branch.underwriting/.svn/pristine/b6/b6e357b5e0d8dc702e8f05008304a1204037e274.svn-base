function pageLoad() {
    $('#hdnLang').val('ES');
    InsertHeaderSpan();
    ShowAmmendmentPop();
    ShowRejectPop();
    ShowEditNeverIssuedPop();
    ShowDocumentPop();
}

InsertHeaderSpan = function () {
    $('#gvRiders').find('th').each(function () {
        $(this).wrapInner('<span> </span>');
    });

    $('#gvPopAmmendments').find('th').each(function () {
        $(this).wrapInner('<span> </span>');
    });
};

function HyperLinkOnClick(s, e, index, eventName) {
    clbIssue.PerformCallback(eventName + "|" + index);
    return ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
}

function CloseAjaxPop(obj, hdnName) {
    var popName = $(obj).attr('popName');
    $find(popName).hide();
    $('#' + hdnName).val('false');
}

///Ammendments Events
btnUploadAmmendmentClick = function (rowIndex, hdnName) {
    document.getElementById('ContentPlaceHolder1_UCIssueContainer_UCIssue_UCAmmendments1_fuPopAmmendments_TextBox0_Input').click();
    $(hdnName).val(rowIndex);
    return false;
};

function uploadFileChange(sender, event) {
    sender.Upload();
}

function fuAmmendmentFileComplete(sender, event) {
    if (event != '') {
        if (event.callbackData != '') {
            $('#hdnAmmendmentPath').val(event.callbackData);
            $('#btnUploadAmmendment').trigger('click');
        }
    }
}

ValidateAndConfirm = function (obj, container) {
    if (validateForm(container))
        DlgConfirm(obj);
    return false;
};

ShowAmmendmentPop = function () {
    $("#dvPopAmmendment ").draggable({
        handle: "header"
    });

    var pop = $find('mpAmmendments');
    if (pop == null) return;

    if ($("#hdnShowAmmendments").val() == "true")
        pop.show();
    else
        pop.hide();
};

ShowRejectPop = function () {
    $("#dvPopReject ").draggable({
        handle: "header"
    });

    var pop = $find('mpReject');
    if (pop == null) return;

    if ($("#hdnShowReject").val() == "true")
        pop.show();
    else
        pop.hide();
};

ShowEditNeverIssuedPop = function () {
    $("#dvPopEditNeverIssued ").draggable({
        handle: "header"
    });

    var pop = $find('mpEditNeverIssued');
    if (pop == null) return;

    if ($("#hdnShowEditNeverIssued").val() == "true")
        pop.show();
    else
        pop.hide();
};

ShowDocumentPop = function () {
    $("#dvPopDocument ").draggable({
        handle: "header"
    });

    var pop = $find('mpDocuments');
    if (pop == null) return;

    if ($("#hdnShowDocuments").val() == "true")
        pop.show();
    else
        pop.hide();
};

ValidateSelectedGrid = function (obj, grid) {
    var selectedGrid = false;
    $(grid).find('.dxICheckBox').each(function () {
        if ($(this).hasClass('dxWeb_edtCheckBoxChecked'))
            selectedGrid = true;
    });

    if (selectedGrid)
        return DlgConfirm(obj);
    else {
        CustomDialogMessageEx("Debe seleccionar al menos una poliza, por favor intente nuevamente.", 500, 150, true, "Accción Invalida");
        return false;
    }
};