$(document).ready(function () {

    $(document).on('click', '.btnUploadDoc', function () {
        var bdoc = $(this);
        var bdocData = bdoc.attr("data-info");
        var spl = bdocData.split("|");
        var title = spl[3];
        var filename = spl[6];
        var doc = spl[1];
        var validated = spl[7];

        $("#hdnDocumentRequiredIDs").val(bdocData);

        var wasUpload = bdoc.hasClass('DocumentRequiredView');
        openDocumentRequiredUpload(title, wasUpload, filename, doc, validated);

        $("#fUpload").val('');

        $('#fUpload').inputFileText({ text: 'Buscar' });
        $("#fUpload").nextAll('span:first').html('');

        $(".btnSaveDocumentRequired").attr("disabled", "disabled");

    });

    $(document).on('click', '.btnDeleteDoc', function () {

        var bdoc = $(this);

        var canDelete = bdoc.hasClass('DocumentRequiredView');

        var bdocData = bdoc.attr("data-info");
        var hdnDocumentRequiredIDs = bdocData;
        var spl = hdnDocumentRequiredIDs.split("|");

        var jsonToSend = {};
        jsonToSend.quotationID = spl[0];
        jsonToSend.DocumentId = spl[1];
        jsonToSend.RequirementTypeId = spl[2];
        jsonToSend.RequirementTypeDesc = spl[3];
        jsonToSend.PersonId = spl[4];
        jsonToSend.VehicleId = spl[5];
        jsonToSend.DRActualPath = spl[6];

        var newjsonToSend = JSON.stringify(jsonToSend);

        $.ajax({
            url: '/Home/deleteRequiredDoc',
            type: 'POST',
            dataType: 'json',
            data: { jsondata: newjsonToSend },
            async: false,
            success: function (data) {
                if (data.success) {
                    refreshTableRequired();
                } else {
                    showError(['Ha ocurrido un error borrando el documento requerido.'], 'Error borrando documento');
                }
            }
        });
    });

    $(document).on('click', '.btnSaveDocumentRequired', function () {

        var bdoc = $(this);
        var hdnDocumentRequiredIDs = $("#hdnDocumentRequiredIDs").val();
        var spl = hdnDocumentRequiredIDs.split("|");

        var jsonToSend = {};
        jsonToSend.quotationID = spl[0];
        jsonToSend.DocumentId = spl[1];
        jsonToSend.RequirementTypeId = spl[2];
        jsonToSend.RequirementTypeDesc = spl[3];
        jsonToSend.PersonId = spl[4];
        jsonToSend.VehicleId = spl[5];
        jsonToSend.DRActualPath = $("#hdnDocumentRequiredActualPath").val();

        var newjsonToSend = JSON.stringify(jsonToSend);

        $.ajax({
            url: '/Home/saveRequiredDocument',
            type: 'POST',
            dataType: 'json',
            data: { jsondata: newjsonToSend },
            async: false,
            success: function (data) {
                if (data.success) {
                    refreshTableRequired();
                } else if (data.message) {
                    showError([data.message], 'Error guardando documento')
                } else {
                    showError(['Ha ocurrido un error guardando el documento requerido.'], 'Error guardando documento');
                }
            }
        });

    });

    $(document).on('change', '#fUpload', function (e) {

        var files = e.target.files;
        var myID = 0;
        if (files.length > 0) {
            if (window.FormData !== undefined) {
                var data = new FormData();
                for (var x = 0; x < files.length; x++) {
                    data.append("file" + x, files[x]);
                }

                $.ajax({
                    type: "POST",
                    url: '/Home/uploadFileLocal?s=' + myID,
                    contentType: false,
                    processData: false,
                    //async: false,
                    data: data,
                    success: function (result) {
                        if (result.success) {
                            var tmppath = result.path;
                            $("#showpdfIfra").fadeIn("fast").attr('src', tmppath);
                            $("#hdnDocumentRequiredActualPath").val(tmppath);
                            $(".btnSaveDocumentRequired").removeAttr("disabled");
                        }
                        else if (result.message) {
                            showError([result.message], 'Error cargando documento');
                        }
                        else {
                            showError(['Ha ocurrido un error cargando el documento.'], 'Error cargando documento');
                        }
                    },
                    error: function (xhr, status, p3, p4) {
                        var err = "Error " + " " + status + " " + p3 + " " + p4;
                        if (xhr.responseText && xhr.responseText[0] == "{")
                            err = JSON.parse(xhr.responseText).Message;
                        showError([err], 'Error cargando documento');
                    }
                });
            } else {
                alert("This browser doesn't support HTML5 file uploads!");
            }
        }
    });

    $(document).on('click', '#chkValidateDoc', function (e) {
        var $this = $(this);
        var validated = false;

        if ($this.is(":checked")) {
            validated = true;
        } else {
            validated = false;
        }

        var hdnDocumentRequiredIDs = $("#hdnDocumentRequiredIDs").val();
        var spl = hdnDocumentRequiredIDs.split("|");

        var jsonToSend = {};
        jsonToSend.quotationID = spl[0];
        jsonToSend.DocumentId = spl[1];
        jsonToSend.RequirementTypeId = spl[2];
        jsonToSend.RequirementTypeDesc = spl[3];
        jsonToSend.PersonId = spl[4];
        jsonToSend.VehicleId = spl[5];
        jsonToSend.DRActualPath = $("#hdnDocumentRequiredActualPath").val();

        var newjsonToSend = JSON.stringify(jsonToSend);

        $.ajax({
            url: '/Home/validateRequiredDoc',
            type: 'POST',
            dataType: 'json',
            data: { jsondata: newjsonToSend, validated: validated },
            success: function (data) {
                if (data.success) {
                    $("#ppUploadDoc").modal("hide");
                    refreshTableRequired();
                } else {
                    showError(['Ha ocurrido un error al validar el documento.'], 'Error al validar el documento');
                }
            }
        });
    });

    $("#btnSendToGlobalOther").off("click");
    $(document).on('click', '#btnSendToGlobalOther', function () {

        var _allRequiredsDocWasCompleted = allRequiredsDocWasCompleted();
        if (_allRequiredsDocWasCompleted == false) {
            return _allRequiredsDocWasCompleted;
        }

        var qid = parseInt($('#quotationID').val());

        if (qid > 0) {

            $.ajax({
                url: "/Home/SendQuotToGlobal",
                type: "POST",
                data: { quotationID: qid },
                cache: false,
                success: function (data, textStatus, jqXHR) {

                    if (data.success) {

                        //reemplazar div y mostrar partialview
                        $.ajax({
                            url: "/Home/FinalStepToInbox",
                            data: { quotationID: qid },
                            contentType: 'application/html; charset=utf-8',
                            type: 'GET',
                            dataType: 'html',
                            async: false,
                            success: function (html) {
                                $("#dvHeaderOption").hide();
                                $("#dvContainer").html(html);

                                changeOptionFilter();
                            },
                            error: function (req, status, error) {
                            }
                        });

                        window.history.replaceState({}, '', '/Home/Index');
                        var isfinanced = $("#isFinancedPolicy").val() == "True";
                        //showSucess([data.message], "Cotización", (!isfinanced) ? function () { location.reload(); } : null, false);
                        showSucess([data.message], "Cotización", null, false);
                    }
                    else {
                        showError([data.message], "Enviando Cotizacion a la Bandeja de Auto");
                    }
                },
                error: function (data, textStatus, jqXHR) {
                    if (data.messageError) {
                        showError([data.messageError]);
                    } else {
                        var textError = data + " " + textStatus + " " + jqXHR;
                        showError([textError]);
                    }
                }
            });
        }

        return false;
    });

});

function openDocumentRequiredUpload(title, wasUpload, filename, doc, validated) {

    var docContainerContainer = $("#ppUploadDoc");
    var DocTitle = $("#DocTitle");
    var DocListContainer = $("#errorListContainer");

    if (title) {
        DocTitle.html(title);
    }

    $("#dvShowPDF").show();

    if (wasUpload) {
        $("#dvfUpload").hide();
        getPreview(filename, doc);

        //Ocultando botones de guardar y cancelar
        $(".btnSaveDocumentRequired, .btnCancelDoc").hide();

        if (GlobalAppMode != "LEYMODE") {
            $("#dvShowValidateButton").show();
        }

        if (validated == "true") {
            $("#chkValidateDoc").prop('checked', true);
        } else {
            $("#chkValidateDoc").prop('checked', false);
        }
    } else {
        $("#dvfUpload").show();
        $(".btnSaveDocumentRequired, .btnCancelDoc").show();
        $("#showpdfIfra").fadeIn("fast").attr('src', '');
        $("#dvShowValidateButton").hide();
    }

    docContainerContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function getPreview(filename, doc) {

    $.ajax({
        url: '/Home/viewRequiredDoc',
        type: 'POST',
        dataType: 'json',
        data: { doc: doc, filename: filename },
        async: false,
        success: function (data) {
            if (data.success) {
                $("#showpdfIfra").fadeIn("fast").attr('src', data.path);
            } else {
                showError(['Ha ocurrido un error mostrando el documento.'], 'Error al mostrar el documento');
            }
        }
    });
}

function refreshTableRequired() {
    //reemplazar div y mostrar partialview
    $.ajax({
        url: "/Home/DocumentRequired",
        data: {},
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
        async: false,
        success: function (html) {
            $("#dvContainer").html(html);
        },
        error: function (req, status, error) { }
    });
}

function allRequiredsDocWasCompleted() {
    var pass = false;
    $.ajax({
        url: '/Home/allRequiredValidated',
        type: 'POST',
        dataType: 'json',
        data: {},
        cache: false,
        async: false,
        success: function (data) {
            if (data.success) {
                pass = true;
                //return pass;
            } else {
                showError(data.message, 'Validación de documento requeridos');
            }
        },
        error: function (data, textStatus, jqXHR) {
            if (data.message) {
                showError([data.message]);
            } else {
                var textError = data + " " + textStatus + " " + jqXHR;
                showError([textError]);
            }
        }
    });

    return pass;
}