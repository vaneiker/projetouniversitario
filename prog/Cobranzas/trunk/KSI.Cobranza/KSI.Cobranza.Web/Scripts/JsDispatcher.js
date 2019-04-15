/// <reference path="JsAppObjects.js" />
class Dispatcher {

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 02 Mar 2019
     * Carga un movimiento
     */
    static LoadMovement(QueueId, IdMovement) {

        CallAjax('/Dispatcher/CheckPrerequisitesPending', JSON.stringify({
            QueueId: QueueId,
            IdMovement: IdMovement
        }), 'json',
        function (data) {

            if (data.PrerequisitesPending.length > 0) {

                Common.Notification(
                    AppObjects.Dispatcher.String.ThereArePendingPrerequisites(data.MovementEntityModel.Name)
                    + Utility.GetHtml(AppObjects.Dispatcher.Html.New_PrerequisitesPendingList(QueueId, data.PrerequisitesPending)))

                $("[data-toggle='tooltip']").tooltip(); // << -- Este tooltip, muestra información de ayuda
            }
            else {
                CallAjax('/Dispatcher/LoadMovement', JSON.stringify({
                    QueueId: QueueId,
                    IdMovement: IdMovement
                }), 'html',
                function (data) {

                    $('#ModalMovement').modal({
                        backdrop: "static"
                    });

                    $('#ContainerMovement').html(data);

                }, 'POST', true);
            }
        }, 'POST', true);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 04 Mar 2019
     * Cambia de estatus un caso
     */
    static ChangeEstatus(QueueTypeId) {
        CallAjax('/Dispatcher/ChangeEstatus', JSON.stringify({
            QueueId: $("#Dispatcher_Modal_Hdd_QueueId").val(),
            MovementEntityModel: { IdMovement: $("#Dispatcher_Modal_Hdd_IdMovement").val() },
            QueueTypeId: QueueTypeId,
            UserConfirmsStatusChange: $("#Dispatcher_Modal_Hdd_UserConfirmsStatusChange").val()
        }), 'json',
        function (data) {
            if (data.Response.State) {
                if (!data.UserConfirmsStatusChange)
                    Common.RequestConfirmation(
                        AppObjects.Dispatcher.String.StatusChangeConfirmation(data.QueueId, data.CurrentStatus.Name, data.NextStatus.Name), function () {
                            $("#Dispatcher_Modal_Hdd_UserConfirmsStatusChange").val("True");
                            Dispatcher.ChangeEstatus(QueueTypeId);
                        });
                else
                    Common.Notification(AppObjects.Dispatcher.String.SuccessfulChangeOfState(), function () {
                        window.location.replace('/Queue/Index')
                    }, AppObjects.Common.String.IconCssClass_Successfully());
            }
            else
                $("#MessageContainerMovement").empty().append(
                    AppObjects.Common.Html.New_WarningAlert(data.Response.Message));
        }, 'POST', true);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 07 Mar 2019
     * Carga el grid de ejecución de movimientos
     */
    static LoadMovementsExecutionGrid(QueueId) {
        GetPartialView("/Dispatcher/MovementsExecutionGrid", JSON.stringify({ QueueId: QueueId }), function (data) {
            var $Container = $("#MovementsExecutionGridContainer");
            $Container.html(data);
        }, true);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 04 Mar 2019
     * Carga el footer del movimiento
     */
    static LoadFooter(QueueId) {
        GetPartialView("/Dispatcher/Footer", JSON.stringify({ QueueId: QueueId }), function (data) {
            var $Container = $("#FooterMovement");
            $Container.html(data);
        }, true);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 02 Mar 2019
     * Inyecta el html necesario para que el Dispatcher pueda funcionar
     */
    static AppendHtmlUtilities() {
        if ($('#ContainerMovement').length == 0)
            AppObjects.Dispatcher.Html.New_MovementContainer().prependTo($("body"));
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 02 Mar 2019
     * Es de caracter obligatorio si usted abre un movimiento en modalidad modal
     * Que invoque este metodo al inicio de la vista
     */
    static InitializeMovement(QueueId, IdMovement, MovementTitle) {
        $(document).ready(Dispatcher.LoadFooter(QueueId));
        $("#Dispatcher_Modal_Hdd_QueueId").val(QueueId);
        $("#Dispatcher_Modal_Hdd_IdMovement").val(IdMovement);
        $("#ModalMovementTitle").html(MovementTitle);
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 03 Mar 2019
     * Limpia el contenedor de un movimiento
     */
    static CleanMovementContainer() {
        $("#Dispatcher_Modal_Hdd_QueueId").val(0);
        $("#Dispatcher_Modal_Hdd_IdMovement").val(0);
        $("#Dispatcher_Modal_Hdd_UserConfirmsStatusChange").val("False");
        $("#ModalMovementTitle").html("");
        $("#FooterMovement").html("");
        $("#MessageContainerMovement").html("");
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 14 Mar 2019
     * Cierra el modal contenedor de movimientos.
     * Solicita una confirmación antes
     */
    static CloseMovementContainer() {
        Common.RequestConfirmation(
            AppObjects.Dispatcher.String.CloseMovementContainerConfirmation($('#ModalMovementTitle').html()), function () {
                $('#ModalMovement').modal('hide');
                Dispatcher.CleanMovementContainer();
                Dispatcher.LoadMovementsExecutionGrid($('#Dispatcher_Launcher_Hdd_QueueId').val());
            });
    };
}