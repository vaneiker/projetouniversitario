/**
 * vbarrera | 19 Abril 2019
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * Delegado que se invoca despues que la pagina ha sido cargada
 */
$(function () {

    /**
     * Captura la solicitud POST del formulario y la envia por ajax
     */
    $('#DataManager_Crud_Form').ajaxForm({
        beforeSend: function () { },
        uploadProgress: function (event, position, total, percentComplete) { },
        success: function (data) {
            if (data.State) {
                Common.Notification(
                    AppObjects.Common.String.Save_Successfully(), null,
                    AppObjects.Common.String.IconCssClass_Successfully());
            }
            else
            {
                Common.Notification(
                    data.Message, null, 
                    AppObjects.Common.String.IconCssClass_WhenAnErrorOccurs());
            }
        },
        complete: function (xhr) { }
    });

    /**
     * Estableciendo DatePicker para los campos de tipo fecha
     */
    $(".DataManager_Crud_DatePicker").datepicker({
        dateFormat: 'mm/dd/yy'
    });
});