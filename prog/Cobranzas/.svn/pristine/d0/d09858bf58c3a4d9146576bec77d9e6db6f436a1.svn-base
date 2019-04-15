class Common {
    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 17/Abr/2018
     * Utilice para solicitar una confirmacion al usuario
     */
    static RequestConfirmation(Message, Callback) {
        $("#ContainerConfirm").dialog({
            closeOnEscape: false,
            minHeight: 235,
            minWidth: 475,
            modal: true,
            title: "Confirmación",
            open: function (event, ui) {
                $("#ContainerConfirmMessage").html(Message);
            },
            buttons: {
                "Si": function () {
                    $(this).dialog("close");
                    if (Callback)
                        Callback();
                },
                "No": function () {
                    $(this).dialog("close");
                }
            }
        });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 17/Abr/2018
     * Utilice para mostrar una notificación al usuario
     */
    static Notification(Message, Callback, ClassIcon) {

        ClassIcon = typeof ClassIcon !== 'undefined' ? ClassIcon : "fa-info-circle";

        $("#ContainerNotification").dialog({
            closeOnEscape: false,
            minHeight: 235,
            minWidth: 475,
            modal: true,
            title: "Notificación",
            open: function (event, ui) {
                Common.Fontawesome_SetIcon($("#NotificationIcon"), ClassIcon);
                $("#ContainerNotificationMessage").html(Message);
            },
            buttons: {
                "Cerrar": function () {
                    $(this).dialog("close");
                    if (Callback)
                        Callback();
                }
            }
        });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 02 Mar 2019
     * Inyecta el html necesario para que Common pueda funcionar
     */
    static AppendHtmlUtilities() {
        if ($('#ContainerConfirm').length == 0)
            AppObjects.Common.Html.New_Confirm().prependTo($("body"));
        if ($('#ContainerNotification').length == 0)
            AppObjects.Common.Html.New_Notification().prependTo($("body"));
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 25/Oct/2018
     * Establece el icono de la notificación
     */
    static Fontawesome_SetIcon(InstanceOfIcon, CssIconClass) {
        InstanceOfIcon.prop('class', '');
        InstanceOfIcon.addClass("fa fa-3x");
        InstanceOfIcon.addClass(CssIconClass);
    };
}