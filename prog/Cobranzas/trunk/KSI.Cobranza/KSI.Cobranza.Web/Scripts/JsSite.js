class KrediSite {

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 13/Mar/2018
     * Levanta un movimiento 
     * para ello debe estar perfilado en la tabla [Flow].[Movement]
     * Parametros:
     * [IdQuotation] (Identificador de la cotizacion)
     * [SelectedMovement] (Movimiento el cual se mostrara)
     */
    static RaiseMovementView(IdQuotation, SelectedMovement) {

        Helper.DoGet('/Quotation/_PartialSwitchMovement', {
            IdQuotation: IdQuotation,
            SelectedMovement: SelectedMovement
        }).done(function (data) {

            if (data.ActionName != undefined)
                window.location.href
                    = "/" + data.ControllerName + "/" + data.ActionName + "?IdQuotation=" + data.IdQuotation + "&IdMovement=" + data.Id;
            else {

                $('#ModalMovimiento').modal({
                    backdrop: "static"
                });
                $('#ModalMovimiento').html(data);

                $.validator.unobtrusive.parse($('#ModalMovimiento'));
            }
        });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 12/Abr/2018
     * Obtiene un documento y lo coloca en un visor
     */
    static GetDocument(IdQuotation, IdRequirement, Callback) {
        Helper.DoAjax('/Services/LoadDocument', {
            IdQuotation: IdQuotation,
            IdRequirement: IdRequirement
        }).done(function (data) {
            $("#ViewerDocReqDocuments").attr("src", '/' + data.Path);
            $("#ViewerDoc").collapse('show');
            if (Callback != null)
                Callback(data);
        })
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 12/Abr/2018
     * Es utilizado por el CrudDataItemFramework para cargar los DropdownList en cascada
     */
    static GetDropDownListItems(
        IdFieldCategory, IdParentCatalogHeader, IdCatalogHeader, Url) {

        var DropDownListParent = $("#DropDownList_" + IdFieldCategory + "_" + IdParentCatalogHeader);
        var DropDownListChildren = $("#DropDownList_" + IdFieldCategory + "_" + IdCatalogHeader);

        AppDelegates.OnChangeCrudDropDownList(
            DropDownListParent, DropDownListChildren);

        if (IdCatalogHeader == 0)
            return;

        Helper.FillDropDownList(
            DropDownListChildren, Url, {
                IdParentCatalogHeader: IdParentCatalogHeader,
                IdCatalogHeader: IdCatalogHeader,
                SelectedCode: DropDownListParent.val()
            });
    };

    /**
     * // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- // >>
     * vbarrera | 17/Abr/2018
     * Solicita una confirmación al usuario
     */
    static RequestConfirmation(Message, Callback) {
        $("#ContainerConfirm").dialog({
            closeOnEscape: false,
            height: 200,
            width: 450,
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
     * vbarrera | 20/Abr/2018
     */
    static ToggleTypeInstaller() {
        /**
         * [Flow].[FieldCategory]
         * [{19: "Datos relacionados al GPS del vehículo" }]
         */
        var IdFieldCategory = 19;
        /**
         * [Catalog].[CatalogData]
         * [{5: "Tipos de instalador de GPS" }]
         */
        var IdCatalogHeader = 5;
        /**
         * [Flow].[Field]
         * [{349: "Instalador" }]
         */
        var IdFieldInstaller = 349;
        /**
         * [Flow].[Field]
         * [{348: "Empresa" }]
         */
        var IdFieldCompany = 348;
        /**
         * [Catalog].[CatalogData]
         * [{1: "Interno" }]
         */
        var CodeInternal = 1;
        /**
         * [Catalog].[CatalogData]
         * [{2: "Externo" }]
         */
        var CodeExternal = 2;
        /*
         // -- -- -- // >>
         */

        ToggleTypeInstaller();

        /*
         // -- -- -- // >>
         */
        AppDelegates.OnChangeCrudDropDownList
            = function (DropDownListParent, DropDownListChildren) {

                var Id = DropDownListParent.selector;
                var ThisIdCatalogHeader = Id.split("_")[2];

                if (ThisIdCatalogHeader == IdCatalogHeader)
                    ToggleTypeInstaller(DropDownListParent)
            }

        /*
         // -- -- -- // >>
         */
        function ToggleTypeInstaller(DropDownListParent) {

            if (DropDownListParent == null)
                DropDownListParent
                    = $("#DropDownList_" + IdFieldCategory + "_" + IdCatalogHeader);

            var ContainerInstaller
                = $("#ContainerControl_" + IdFieldCategory + "_" + IdFieldInstaller);
            var ContainerCompany
                = $("#ContainerControl_" + IdFieldCategory + "_" + IdFieldCompany);

            if (DropDownListParent.val() == CodeInternal) {
                ContainerInstaller.show();
                ContainerCompany.hide();

            } else if (DropDownListParent.val() == CodeExternal) {
                ContainerInstaller.hide();
                ContainerCompany.show();
            }
            else {
                ContainerInstaller.hide();
                ContainerCompany.hide();
            }
        }
    };
}