/**
 * vbarrera | 12 Feb 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Carga el visor de documentos para aquellos documentos
 * que son generados desde thunderhead
 */
function LoadDocumentViewerForGenerationFromThunderHead(QueueId, IdRequirement) {
    BeginRequestHandler();
    CleanDocumentContainers();
    $("#DocumentViewerContainer").append(
        AppObjects.Document.Html.New_EmbedForThunderHeadDocument(QueueId, IdRequirement));
};

/**
 * vbarrera | 12 Feb 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Carga el visor de documentos para aquellos documentos
 * que son generados desde ONBASE
 */
function LoadDocumentViewerForGenerationFromOnbase(QueueId, IdRequirement) {
    BeginRequestHandler();
    CleanDocumentContainers();
    $("#DocumentViewerContainer").append(
        AppObjects.Document.Html.New_EmbedForOnbaseDocument(QueueId, IdRequirement));
};

/**
 * vbarrera | 11 Mar 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Carga el visor de documentos para aquellos documentos
 * que son generados desde ONBASE y que al mismo tiempo deben validarse
 */
function LoadDocumentViewerForGenerationFromOnbaseAndValidation(QueueId, IdRequirement) {
    CallAjax('/Document/ValidationForm', JSON.stringify({
        QueueId: QueueId,
        IdRequirement: IdRequirement
    }), 'html',
    function (data) {
        CleanDocumentContainers();
        $("#DocumentInformationFormContainer").html(data);
        $("#DocumentViewerContainer").append(
               AppObjects.Document.Html.New_EmbedForOnbaseDocument(QueueId, IdRequirement));
    }, 'POST', true);
};

/**
 * vbarrera | 12 Feb 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Limpia el contenedor de visores
 * Ademas coloca en dicho contenedor el fondo de 'No hay nada que ver'
 */
function CleanDocumentContainers() {
    var DocumentViewerContainer
        = $("#DocumentViewerContainer");
    DocumentViewerContainer.html("");
    $("#DocumentInformationFormContainer").html("");
    DocumentViewerContainer.append(
        AppObjects.Document.Html.New_EmptyDocumentBackground());
};

/**
 * vbarrera | 22 Feb 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Este metodo recibe los valores (QueueId, IdRequirement) desde el grid de documentos 
 * y los coloca en los campos ocultos del formulario de carga de documentos
 */
function SetFileUploadFormFields(QueueId, IdRequirement, RequirementName) {
    $("#Document_Upload_QueueId").val(QueueId);
    $("#Document_Upload_IdRequirement").val(IdRequirement);
    $("#RequirementNameField").html(RequirementName);
};

/**
 * vbarrera | 22 Feb 2018
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Limpiar el formulario de carga de documentos
 */
function CleanUploadForm() {
    $('#status').empty();
    $('.progress-bar').width('0%');
    $('.progress-bar').html('0%');
    $("#Upload_Files").val('');
    $("#Document_Upload_QueueId").val(0);
    $("#Document_Upload_IdRequirement").val(0);
    $("#RequirementNameField").html('');
};

/**
 * vbarrera | 02 Mar 2019
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Cierra el modal de carga de documentos
 */
function CloseUpModal() {
    $('#FileUploadModal').modal('hide');
};

/**
 * vbarrera | 11 Mar 2019
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Guarda la informacion del formulario de validación
 */
function SaveDocumentValidationInformation() {
    CallAjax('/Document/SaveDocumentValidationInformation', JSON.stringify({
        QueueId: $("#Document_Launcher_QueueId").val(),
        IdRequirement: $("#Document_Form_IdRequirement").val(),
        IsValid: $("#Document_Form_RadDocumentIsValid").is(":checked"),
        IdShortAnswer: $("#Document_Form_DdlShortAnswers").val(),
        Observation: $("#Document_Form_TxtObservation").val(),
        MovementEntityModel: { IdMovement: $("#Document_Upload_IdMovement").val() }
    }), 'json',
    function (data) {

        if(data.State)
            Common.Notification(
                AppObjects.Common.String.Save_Successfully(), null,
                AppObjects.Common.String.IconCssClass_Successfully());
        else
            Common.Notification(data.Message, null,
                AppObjects.Common.String.IconCssClass_WhenAnErrorOccurs());

        GetPartialDocumentGrid();
    }, 'POST', true);
};

/**
 * vbarrera | 20 Feb 2019
 * // -- -- -- -- -- -- -- -- -- -- -- // >>
 * Invoca la vista parcial del grid de documentos
 */
function GetPartialDocumentGrid() {
    GetPartialView("/Document/Grid", JSON.stringify({
        QueueId: $("#Document_Launcher_QueueId").val(),
        AllowedGeneration: $("#Document_Launcher_AllowedGeneration").val(),
        AllowedLoad: $("#Document_Launcher_AllowedLoad").val(),
        AllowedValidation: $("#Document_Launcher_AllowedValidation").val()
    }), function (data) {
        var $Container = $("#gvDocumentContainer");
        $Container.html(data);
    }, true);
};

/**
 * vbarrera | 12 Feb 2019
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Delegado que se invoca despues que la pagina ha sido cargada
 */
$(document).ready(function () {
    /**
     * Al inicio, cuando la pagina ha terminado de cargar
     * Se limpia el visor de documentos y se coloca el fondo de 'No hay nada que ver'
     */
    CleanDocumentContainers();

    /**
     * Maneja solicitudes ajax para las cargas de archivos
     */
    $('#FileUploadForm').ajaxForm({
        beforeSend: function() {
            $('#status').empty();
            $('.progress-bar').width('0%');
            $('.progress-bar').html('0%');
        },
        uploadProgress: function(event, position, total, percentComplete) {
            $('.progress-bar').width(percentComplete + '%');
            $('.progress-bar').html(percentComplete + '%');
        },
        success: function(data) {
            $('.progress-bar').width('100%');
            $('.progress-bar').html('100%');
        },
        complete: function(xhr) {
            $('#status').append(AppObjects.Common.Html.New_InfoAlert(xhr.responseText));
            $("#Upload_Files").val('');
            GetPartialDocumentGrid();
        }
    });

    /**
     * LLama la vista que contiene el Grid de documentos
     */
    GetPartialDocumentGrid();
});