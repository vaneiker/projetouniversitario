var divLoading = '<div class="loading"></div>';

var globalFirstTime = true;
var globalWasReload = false;


$(document).ready(function () {

    InitializeSelect2();

    $(document).ajaxStart(function () {
        BeginRequestHandler();
    });

    $(document).ajaxStop(function () {
        EndRequestHandler();
    });

    //$("#btnOpenModal").click(function () {
    //    $("#newRegistryModal").modal({ backdrop: 'static', keyboard: false, show: true });
    //    fillManagementTypes();
    //    fillManagementResult();
    //});

    $(".btnSave").click(function () {
        var result = setManagement();
    });

    $("#btnCancel").click(function () {

        eraseCookie('WasloadData');
        window.location.href = "/Home/Index";;
    });

    /*
    $('#txtAgentCode').on('keydown focusout', function (e) {
        // e.type is the type of event fired
        //console.log(e.type); console.log(e.which);

        var $this = $(this);
        var callFunction = false;

        if ($this.val() !== "") {
            callFunction = true;
        }
        else {
            cleanFields();
        }

        if (e.which == 13) {
            // enter pressed
            if (callFunction) {
                searchAgentInfo($this.val().trim());
                callFunction = false;
            }
        }

    });*/

    // este codigo es para que cuando le den back en el navegador que borre la cookie
    var WasReload = readCookie('WasloadData');
    if (WasReload != null) {
        window.onbeforeunload = noBack;

    //    //noBack();
    //    //window.onload = noBack;
    //    //window.onpageshow = function (evt) { if (evt.persisted) noBack() }
        window.onunload = function () { void (0) }
    }
});

function noBack() {
    
       eraseCookie('WasloadData');
       
    //window.history.forward()
}


function fillManagementTypes() {

    $.ajax({
        url: "/Agent/GetListSellerTypeManagement",
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
        url: "/Agent/GetListSellerResultsManagement",
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
        //async: false,
        success: function (result) {

            if (result.success && result.data) {
                $("#txtAgentName").val(result.data.FullName);
                $("#txtAgentChannel").val(result.data.AgentChannel);
                $("#txtAgentOffice").val(result.data.AgentOffices);
                $("#txtAgentPhone").val(result.data.Phones);
            }
            else if (!result.success && result.message) {

                showError([result.message], "Código Incorrecto");

                cleanFields();
            }
            else {

                showError(['Codigo Incorrecto'], "Código Incorrecto");
                cleanFields();
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

    var AgentName = $("#txtAgentName").val();
    var AgentChannel = $("#txtAgentChannel").val();
    var AgentOffice = $("#txtAgentOffice").val();
    var AgentPhone = $("#txtAgentPhone").val();
    var SupervisorCode = $('#SupervisorCode').val();
    var $showGestion = $('#showGestion');

    var AllowShowGestion = true;
    
    if ($showGestion != null) {
        var ExistsCheckedProperty = $showGestion.prop('checked');

        if (ExistsCheckedProperty != null) {
            AllowShowGestion = ExistsCheckedProperty;
        }
    }

    var arrayMessages = [];
    //validando campos

    var isAProspect = $("#hdnisAProspect").val();

    if (isAProspect == "true") {
        if (AgentName === "") {
            arrayMessages.push("El campo Vendedor no debe estar vacio.");
        }
    }

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
        showError(arrayMessages, "Error");
        return false;
    }

    $.ajax({
        url: "/Agent/setManagement",
        dataType: "json",
        data: {
            agentCode: agentCode,
            AgenTypeManagement: AgenTypeManagement,
            AgenResultManagement: AgenResultManagement,
            CommentManagement: CommentManagement,
            SuggestedImprovementManagement: SuggestedImprovementManagement,
            supervisorCode: SupervisorCode,
            allowShowGestion: AllowShowGestion == null ? false : AllowShowGestion,
            isAProspect: isAProspect,
            AgentName: AgentName,
            AgentChannel: AgentChannel,
            AgentOffice: AgentOffice,
            AgentPhone: AgentPhone
        },
        async: false,
        success: function (result) {

            if (result.success) {
                $("#newRegistryModal").modal('hide');

                showSucess([result.message], "Datos Guardados",
                    function () {
                        window.location.href = "/Home/Index";
                        eraseCookie('WasloadData');
                    });
            }

        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}




function getStatisticHeader(source) {
    $.ajax({
        url: "/Agent/getStatisticHeader",
        dataType: "json",
        data: {},
        async: false,
        success: function (result) {
            var $table = $("#AgentStatistic > thead");
            var $header = $('#rowHeaderYear');
            //$table.html('');
            if (result.success && result.data) {
                //Agrego row con años
                $.each(result.years, function (idx, obj) {
                    var ActualMonth = new Date().getMonth() + 1;
                    var pctActual = 0;
                    if (source != null)
                        pctActual = ((ActualMonth / 12.7) * 100).toString();
                    else
                        pctActual = parseInt(((ActualMonth / 13) * 100).toString());

                    if (idx == result.years.length - 1) {
                        var pct = 100 - pctActual;
                        $header.append("<div class='alert alert-primary text-center' style='float: left; width:" + pct + "%; height: 41px;'><h4>" + obj + "</h4></div>")
                    }
                    else
                        $header.append("<div class='alert alert-success text-center' style='float: left; width:" + pctActual + "%; height: 41px;'><h4>" + obj + "</h4></div>")
                });

                $table.append("<tr class='bg-info mdl-color-text--white'></tr>");
                //Agrego los meses de la estadistica
                var $row = $('#AgentStatistic > thead > tr');
                $row.append("<th scope='col'>Tipo</th>");
                $.each(result.data, function (idx, obj) {
                    $row.append("<th scope='col' style='text-align:right'>" + obj.name + "</th>");
                });
            }
            else if (!result.success && result.message) {

            }
        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}


function searchAgentStatisticData() {
    var agent = $("#txtAgentCode").val();

    $.ajax({
        url: "/Agent/getAgentStatistic",
        dataType: "json",
        data: { agentCode: agent },
        async: false,
        success: function (result) {
            var $table = $("#AgentStatistic > tbody");

            if (result.success && result.data) {
                $table.html('');
               
                
                //Agrego la data de la estadistica
                var $row = $('#AgentStatistic > tbody > tr');
                $.each(result.data, function (idx, obj) {
                    var newRow = "<tr>";
                    obj.Sum1 = obj.Type != 'Cobranza' ? obj.Sum1 : number_format(obj.Sum1, 2)
                    obj.Sum2 = obj.Type != 'Cobranza' ? obj.Sum2 : number_format(obj.Sum2, 2)
                    obj.Sum3 = obj.Type != 'Cobranza' ? obj.Sum3 : number_format(obj.Sum3, 2)
                    obj.Sum4 = obj.Type != 'Cobranza' ? obj.Sum4 : number_format(obj.Sum4, 2)
                    obj.Sum5 = obj.Type != 'Cobranza' ? obj.Sum5 : number_format(obj.Sum5, 2)
                    obj.Sum6 = obj.Type != 'Cobranza' ? obj.Sum6 : number_format(obj.Sum6, 2)
                    obj.Sum7 = obj.Type != 'Cobranza' ? obj.Sum7 : number_format(obj.Sum7, 2)
                    obj.Sum8 = obj.Type != 'Cobranza' ? obj.Sum8 : number_format(obj.Sum8, 2)
                    obj.Sum9 = obj.Type != 'Cobranza' ? obj.Sum9 : number_format(obj.Sum9, 2)
                    obj.Sum10 = obj.Type != 'Cobranza' ? obj.Sum10 : number_format(obj.Sum10, 2)
                    obj.Sum11 = obj.Type != 'Cobranza' ? obj.Sum11 : number_format(obj.Sum11, 2)
                    obj.Sum12 = obj.Type != 'Cobranza' ? obj.Sum12 : number_format(obj.Sum12, 2)
                    obj.Sum13 = obj.Type != 'Cobranza' ? obj.Sum13 : number_format(obj.Sum13, 2)

                    newRow += "<td class='text-left' scope='col'>"+ obj.Type +"</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum1 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum2 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum3 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum4 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum5 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum6 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum7 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum8 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum9 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum10 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum11 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum12 + "</td>";
                    newRow += "<td scope='col' style='text-align:right'>" + obj.Sum13 + "</td>";
                    newRow += "</tr>";
                    $table.append(newRow);
                });
            }
            else if (!result.success && result.message) {

            }
        },
        error: function (response) {
            showError([response.responseText], "Error");
        }
    });
}