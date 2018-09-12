var id;
function setRequirementId(req, val) {
    if (val == "-1" || val == "1") {
        $(req).closest('tr')
                             .find('td')
                             .eq(2)
                             .children("input[name='ReqRowID']").val(val);
    }
}

function ValidateSavePdf() {
    if ($('#SaveBtn').attr('disabled') == 'disabled') {
        CustomDialogMessage('Please browse for a file before saving');
        return false;
    }
    else {
        $('#SaveBtn').click();
    }
}

function GetRequirementValues(reqId) {
    var requirement = new Object();

    requirement.ID = $(reqId)
                                .closest('tr')
                                 .find('td')
                                 .eq(3)
                                 .children("input[name='ReqRowID']").val();

    requirement.CategoryID = $(reqId)
                                .closest('tr')
                                 .find('td')
                                 .eq(3).children("input[name='ReqRowCatID']").val();

    requirement.TypeID = $(reqId)
                                .closest('tr')
                                 .find('td')
                                 .eq(3).children("input[name='ReqRowTypeID']").val();

    requirement.ContactID = $(reqId)
                                .closest('tr')
                                 .find('td')
                                 .eq(3).children("input[name='ReqRowContactID']").val();

    requirement.DocId = $(reqId)
                               .closest('tr')
                                .find('td')
                                .eq(3).children("input[name='ReqRowDocId']").val();


    var oCase = JSON.parse($("#hdnCase").val());

    requirement.CorpId = oCase.CorpId;
    requirement.RegionId = oCase.RegionId;
    requirement.CountryId = oCase.CountryId;
    requirement.DomesticregId = oCase.DomesticregId;
    requirement.StateProvId = oCase.StateProvId;
    requirement.CityId = oCase.CityId;
    requirement.CaseSeqNo = oCase.CaseSeqNo;
    requirement.HistSeqNo = oCase.HistSeqNo;
    requirement.OfficeId = oCase.OfficeId;

    return requirement;
}

function alertME(oj)

{ alert(oj); }

function ViewRequirement(reqId) {
    var pdfAnchor = $(reqId)
                                .closest('tr')
                                 .find('td')
                                 .eq(2)
                                 .find('a');
    if (pdfAnchor && pdfAnchor.attr('class') == 'upload_file') {
        // TODO:  hay que implementar traducciones.
        CustomDialogMessage('This requirement doesn\'t have a document attached to it. Please upload a document for the requirement before previewing');
        return false;
    }

    var requirement = GetRequirementValues(reqId);


    $('#panelViewPdf').load(
                '../UserControls/AddNewClient/Requirements/PartialShowRequirementPdf.aspx?' +
                'ContactID=' + requirement.ContactID +
                '&CategoryID=' + requirement.CategoryID +
                '&TypeID=' + requirement.TypeID +
                '&ID=' + requirement.ID +
                '&DocId=' + requirement.DocId
            );

    JQueryPopup(
    {
        ElementIDorClass: '#panelViewPdf',
        pautoOpen: true,
        pwidth: 900,
        pheight: 900,
        pTitle: 'Requirement'
    });

    return false;
}


function formatBrowseButton() {
    $('#fuRequirementFile_Browse0').attr('class', 'dxBB  boton  ');
    $('#fuRequirementFile_TextBox0').unbind('mouseenter mouseleave');
    $('#fuRequirementFile_TextBox0').removeClass();
    //$('#fuRequirementFile_TextBox0').css("display", "none");
    $('#fuRequirementFile_TextBox0').css("width", "1");
}

function UploadRequirement(reqId) {
    var result = false;
    var requirement = GetRequirementValues(reqId);
    $("#txtPath").val("");
    var requirementsValues;

    if (requirementsValues = $('#RequirementsValues')) {
        requirementsValues.val(JSON.stringify(requirement));
    }
    if ($(reqId).attr('class') == 'pdf_ico') {
        CustomDialogMessageEx(null, 400, 160, false, lang == "en" ? "Requirement Documents" : "Documentos de requerimientos", "UploadingValidation");
    }
    else {
        $find('popupBhvr').show();
    }

    return false;
}

function SaveBtnClick() {
    $('#SaveBtn').click();
    return true;
}

function CloseRequirementPDFPop() {
    $find("popupBhvr").hide();
    if ($.browser.mozilla)
        $('#pdfViewerPdfPopUp').find('object').remove();
    return false;
}

function uploadFileRequirementComplete(sender, event) {

    if (event != '') {

        $('#txtPath').val(event.callbackData.split('~~')[1]);
        if (event.callbackData != '') {
            $('#btnRequirementPreviewPDF').trigger('click');
            sender.ClearText();
        }

    }
}

function uploadFileChange(sender, event) {
    sender.Upload();
}
