var AppObjects = {
    Document: {
        Html: {
            /**
             * vbarrera | 12 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Visor de documentos para mostrar los documentos que son generados desde ThunderHead
             */
            New_EmbedForThunderHeadDocument: function (QueueId, IdRequirement) {
                return $("<embed class=\"embed-responsive-item\" src=\"/Document/GenerateFromThunderHeadAndVisualize?QueueId=" + QueueId + "&IdRequirement=" + IdRequirement + "\" onload=\"EndRequestHandler()\">");
            },
            /**
             * vbarrera | 26 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Visor de documentos para mostrar los documentos que son generados desde ONBASE
             */
            New_EmbedForOnbaseDocument: function (QueueId, IdRequirement) {
                return $("<embed class=\"embed-responsive-item\" src=\"/Document/GenerateFromOnbaseAndVisualize?QueueId=" + QueueId + "&IdRequirement=" + IdRequirement + "\" onload=\"EndRequestHandler()\">");
            },
            /**
             * vbarrera | 12 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Fondo que se muestra cuando el visor de documentos esta vacio
             */
            New_EmptyDocumentBackground: function () {
                return $('<div style="background-color:#d0d0d0; width:100%; height:600px; vertical-align: middle; text-align: center;"></div>')
                    .append($('<i class="fa fa-eye-slash" style="font-size: 20em; color:#fff; margin-top: 160px;"></i>'));
            },
        }
    },
    Dispatcher: {
        Html: {
            /**
             * vbarrera | 02 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Modal contenedor de movimientos
             */
            New_MovementContainer: function() {
                return $('<div id="ModalMovement" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel"><div class="modal-dialog modal-lg modal-big2" role="document"><div class="modal-content"><div class="modal-header"><button type="button" class="close" onclick="Dispatcher.CloseMovementContainer();"><span aria-hidden="true">&times;</span></button><h4 class="modal-title"><i class="" aria-hidden="true"></i><span id="ModalMovementTitle"></span></h4></div><div id="ContainerMovement" class="modal-body"></div><div class="modal-footer"><div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="MessageContainerMovement" style="text-align: left;"></div></div><div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="FooterMovement"></div></div><div id="HiddenPropertiesMovement"><input type="hidden" id="Dispatcher_Modal_Hdd_QueueId" name="QueueId" value="0" /><input type="hidden" id="Dispatcher_Modal_Hdd_IdMovement" name="IdMovement" value="0" /><input type="hidden" id="Dispatcher_Modal_Hdd_UserConfirmsStatusChange" name="UserConfirmsStatusChange" value="False" /></div></div></div></div></div>');
            },
            /**
             * vbarrera | 05 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Lista de requisitos pendientes
             */
            New_PrerequisitesPendingList: function (QueueId, PrerequisitesPending) {
                var Content = "<ul>";
                $.each(PrerequisitesPending, function (Index, Item) {
                    Content += "<li style='text-align: left;'>";
                    Content += "<a href='#' data-toggle='tooltip' data-placement='top' title='" + Item.HelpContent + "' onclick='Dispatcher.LoadMovement(" + QueueId + "," + Item.IdPrerequisiteMovement + ")' style='text-align: left;'>";
                    Content += "<b>";
                    Content += "<i class='fa fa-question-circle' aria-hidden='true'></i> ";
                    Content += Item.PrerequisiteMovementName;
                    Content += "</b>";
                    Content += "</a>";
                    Content += "</li>";
                });
                Content += "</ul>";
                return $(Content);
            }
        },
        /**
         * vbarrera | 05 Mar 2019
         * Mensajes relacionados al Dispatcher
         */
        String: {
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Mensaje para indicar que el movimiento que se desea levantar tiene requisitos pendientes
             */
            ThereArePendingPrerequisites: function (PrimaryMovementName) { return "Lo sentimos, hay <b>movimientos</b> que son necesarios completar para que pueda trabajar el <b>movimiento</b>: <b>" + PrimaryMovementName + "</b>.<br /> Click en los siguientes enlaces para proceder:"; },
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Mensaje para indicar que se ha realizado el cambios de estado satisfactoriamente
             */
            SuccessfulChangeOfState: function () { return "Cambio de estado realizado satisfactoriamente."; },
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Mensaje para pedir confirmacion de cambio de estado
             */
            StatusChangeConfirmation: function (QueueId, CurrentStatusName, NextStatusName) { return "Confirma que desea mover el caso No. <b>" + QueueId + "</b> del estatus <b>" + CurrentStatusName + "</b> al estatus <b>" + NextStatusName + "</b>?"; },
            /**
             * vbarrera | 14 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Mensaje que aparece en la confirmación cuando el usuario presiona el botón de cerrar el modal contenedor de movimientos
             */
            CloseMovementContainerConfirmation: function (MovementName) { return "Confirma que desea <b>salir</b> del <b>movimiento</b>: <b>" + MovementName + "</b>? Si decide <b>salir</b> asegurese de haber <b>guardado sus cambios</b>."; }
        }
    },
    Common: {
        Html: {
            /**
             * vbarrera | 05 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Confirmacion Jquery dialog
             */
            New_Confirm: function () {
                return $('<div id="ContainerConfirm" style="display: none;"><div class="row"><div class="col-lg-1 col-md-1 col-sm-12 col-xs-12"><i class="fa fa-question-circle-o fa-3x" aria-hidden="true"></i></div><div class="col-lg-11 col-md-11 col-sm-12 col-xs-12"><div id="ContainerConfirmMessage" style="text-align: center; padding-top: 10px;"></div></div></div></div>');
            },
            /**
             * vbarrera | 05 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Notificacion Jquery dialog
             */
            New_Notification: function () {
                return $('<div id="ContainerNotification" style="display: none;"><div class="row"><div class="col-lg-1 col-md-1 col-sm-12 col-xs-12"><i class="" id="NotificationIcon" aria-hidden="true"></i></div><div class="col-lg-11 col-md-11 col-sm-12 col-xs-12"><div id="ContainerNotificationMessage" style="text-align: center; padding-top: 10px;"></div></div></div></div>');
            },
            /**
             * vbarrera | 22 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Alerta para indicar que todo salio bien
             */
            New_SuccessAlert: function (Message) {
                return $("<div class=\"alert alert-success\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + Message + "</div>");
            },
            /**
             * vbarrera | 22 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Alerta para mostrar algun texto informativo
             */
            New_InfoAlert: function (Message) {
                return $("<div class=\"alert alert-info\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + Message + "</div>");
            },
            /**
             * vbarrera | 22 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Alerta para mostrar algun texto de error
             */
            New_DangerAlert: function (Message) {
                return $("<div class=\"alert alert-danger\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + Message + "</div>");
            },
            /**
             * vbarrera | 22 Feb 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Alerta para mostrar algun texto con advertencia
             */
            New_WarningAlert: function (Message) {
                return $("<div class=\"alert alert-warning\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>" + Message + "</div>");
            },
        },
        String: {
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Mensaje cuando se guardan los cambios satisfactoriamente
             */
            Save_Successfully: function () { return "Sus cambios fueron guardados satisfactoriamente."; },
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Clase de icono cuando un determinado proceso se realiza exitosamente | Lib.:fontawesome
             */
            IconCssClass_Successfully: function () { return "fa-check-circle-o"; },
            /**
             * vbarrera | 13 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Clase de icono cuando ocurre un error al mometo de realizar un determinado proceso | Lib.:fontawesome
             */
            IconCssClass_WhenAnErrorOccurs: function () { return "fa-exclamation-triangle"; },
            /**
             * vbarrera | 14 Mar 2019
             * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
             * Clase de icono cuando se muestra informacion al usuario | Lib.:fontawesome
             */
            IconCssClass_WhenInformationIsDisplayed: function () { return "fa-info-circle"; }
        }
    }
};