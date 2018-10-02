$(document).ready(function () {

    InitializeSelect2();

    var table = $('#tableManagements').DataTable({
        //scrollY: "300px",
        //scrollX: true,
        //scrollCollapse: true,
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 8
        //filter:true
        //fixedColumns: false
    });



    $("#btnOpenModal").click(function () {
        $("#newRegistryModal").modal({ backdrop: 'static', keyboard: false, show: true });
        fillManagementTypes();
        fillManagementResult();
    });

    $(".btnSave").click(function () {
        var result = setManagement();
    });

    $("#txtAgentCode").focusout(function () {
        var $this = $(this);
        if ($this.val() !== "") {
            searchAgentInfo($this.val());
        }
    });

});

function showError(errorList, title) {

    var errorContainer = $("#ppError");
    var errorTitle = $("#errorTitle");
    var errorListContainer = $("#errorListContainer");

    if (title) {
        errorTitle.html(title);
    }

    errorListContainer.empty();
    if (errorList) {
        $.each(errorList, function (item, i) {
            errorListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }
    errorContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function showSucess(sucessList, title, okCallback, OcultarBoton) {

    var sucessContainer = $("#ppSucess");
    var sucessTitle = $("#sucessTitle");
    var sucessListContainer = $("#sucessListContainer");
    var okButton = $('#btnSucessOk');

    if (title) {
        sucessTitle.html(title);
    }

    sucessListContainer.empty();
    if (sucessList) {
        $.each(sucessList, function (item, i) {
            sucessListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }

    if (OcultarBoton == false) {
        $("#RedirectToOtherApp").css("display", "block");
    } else {
        $("#RedirectToOtherApp").css("display", "none");
    }

    //cuando no haya usuario logueado no mostrar el boton de ir a la bandeja
    if ($("#hdnOnlyLoggedUsers").val() === "False" || $("#hdnOnlyLoggedUsers").val() === "false") {
        $("#RedirectToOtherApp").css("display", "none");
    }


    okButton.focus();

    if (okCallback) {
        okButton.unbind('click');
        okButton.click(function () {
            sucessContainer.modal('hide');
            okCallback();
        });
    }

    //sucessContainer.modal('show');
    sucessContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}


function InitializeSelect2() {

    $('.dropdown').select2({
        theme: "bootstrap",
        allowClear: true,
        minimumResultsForSearch: 10,
        width: "95%",
        language: {
            noResults: function (params) {
                return "No se han encontrado resultados.";
            }
        }
    });
}

function fillManagementTypes() {

    $.ajax({
        url: "/Home/GetListSellerTypeManagement",
        dataType: "json",
        data: {},
        async: false,
        success: function (result) {

            var $select_elem = $("#dropAgenTypeManagement");
            $select_elem.empty();

            if (result.data) {
                $select_elem.append('<option value="">Seleccionar Tipo</option>');

                var selec = "";

                $.each(result.data, function (idx, obj) {
                    $select_elem.append("<option value='" + obj.id + "' " + selec + ">" + obj.name + "</option>");
                    selec = "";
                });

                $select_elem.trigger("change.select2");
            }
        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}

function fillManagementResult() {

    $.ajax({
        url: "/Home/GetListSellerResultsManagement",
        dataType: "json",
        data: {},
        async: false,
        success: function (result) {

            var $select_elem = $("#dropAgenResultManagement");
            $select_elem.empty();

            if (result.data) {
                $select_elem.append('<option value="">Seleccionar Resultado</option>');

                var selec = "";

                $.each(result.data, function (idx, obj) {
                    $select_elem.append("<option value='" + obj.id + "' " + selec + ">" + obj.name + "</option>");
                    selec = "";
                });

                $select_elem.trigger("change.select2");
            }
        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}

function searchAgentInfo(agentcode) {

    $.ajax({
        url: "/Home/getAgentInfo",
        dataType: "json",
        data: { agentCode: agentcode },
        async: false,
        success: function (result) {

            if (result.success && result.data) {
                $("#txtAgentName").val(result.data.FullName);
                $("#txtAgentChannel").val(result.data.AgentChannel);
                $("#txtAgentOffice").val(result.data.AgentOffices);
                $("#txtAgentPhone").val(result.data.Phones);
            }
            else if (!result.success && result.message) {

                showError([result.message], "Código Incorrecto");

                $(".toclean").each(function (id, obj) {
                    $(obj).val("");
                });
            }
            else {

                showError(['Codigo Incorrecto'], "Código Incorrecto");
                $(".toclean").each(function (id, obj) {
                    $(obj).val("");
                });
            }
        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}

function setManagement() {

    var agentCode = $("#txtAgentCode").val();
    var AgenTypeManagement = $("#dropAgenTypeManagement option:selected").val();
    var AgenResultManagement = $("#dropAgenResultManagement option:selected").val();
    var CommentManagement = $("#txtCommentManagement").val();
    var SuggestedImprovementManagement = $("#txtSuggestedImprovementManagement").val();

    var arrayMessages = [];
    //validando campos
    if (agentCode === "") {
        arrayMessages.push("El Código no debe estar vacio.");
    }

    if (AgenTypeManagement === "") {
        arrayMessages.push("El Tipo no debe estar vacio.");
    }

    if (AgenResultManagement === "") {
        arrayMessages.push("El Resultado no debe estar vacio.");
    }
    //

    if (arrayMessages.length > 0) {
        showError([arrayMessages], "Error");
        return false;
    }

    $.ajax({
        url: "/Home/setManagement",
        dataType: "json",
        data: {
            agentCode: agentCode,
            AgenTypeManagement: AgenTypeManagement,
            AgenResultManagement: AgenResultManagement,
            CommentManagement: CommentManagement,
            SuggestedImprovementManagement: SuggestedImprovementManagement
        },
        async: false,
        success: function (result) {

            if (result.success) {
                showError([result.message], "Datos Guardados");
                $("#newRegistryModal").modal('hide');
                location.reload();                
            }

        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}