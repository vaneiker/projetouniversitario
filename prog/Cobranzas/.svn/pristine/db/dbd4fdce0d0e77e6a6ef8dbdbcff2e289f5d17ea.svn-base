/**
 * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
 * vbarrera | 05 Mar 2019
 * Guarda el formulario de captura de datos
 */
function Save(QueueId, IdMovement) {
    CallAjax('/DataEntry/Save', JSON.stringify({
        QueueId: QueueId,
        IdMovement: IdMovement
    }), 'html',
    function (data) {

        Common.Notification(
            AppObjects.Common.String.Save_Successfully(), null,
            AppObjects.Common.String.IconCssClass_Successfully());

    }, 'POST', true);
};