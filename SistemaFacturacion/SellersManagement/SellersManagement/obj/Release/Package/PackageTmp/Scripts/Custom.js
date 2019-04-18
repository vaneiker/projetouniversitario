var divLoading = '<div class="loading"></div>';
var globalFirstTime = true;
var thFiltersAux = null;
var jsonFilterAux = null;

$(document).ready(function () {

    InitializeSelect2();

    $(document).ajaxStart(function () {
        BeginRequestHandler();
    });

    $(document).ajaxStop(function () {
        EndRequestHandler();
    });

    $("#btnOpenModal").click(function () {
        $("#newRegistryModal").modal({ backdrop: 'static', keyboard: false, show: true });
        fillManagementTypes();
        fillManagementResult();
    });


    $('#btnLoadProfile').on('click', function (e) {
        var $this = $(this);
        $('#scroll_1').css("visibility", 'hidden');
    });

    $('body').on('click', function (e) {
        $('#scroll_1').css("visibility", 'hidden');
    });

    $('#dropFilterTbl').on('change', function (e) {
        var $this = $(this);
        LoadData($this.val());
    });

    $(document).on('click', '.deletecookie', function () {
        eraseCookie('WasloadData');
    });
    
    var IsManamegements = window.location.href.indexOf('Home') > 0;
    if (IsManamegements) {
        var WasReload = readCookie('WasloadData');
        if (WasReload == null) {
            LoadData();
        }
    }
});


function refreshFilters(table) {

    $('#SellerCode').on('change', function () {
        table
            .columns(1)
            .search(this.value)
            .draw();
        prepareEventTable();
    });

    $('#SellerName').on('change', function () {
        table
            .columns(2)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerChannels').on('change', function () {
        table
            .columns(3)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerOffices').on('change', function () {
        table
            .columns(4)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerPhones').on('change', function () {
        table
            .columns(5)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerSupervisor').on('change', function () {
        table
            .columns(6)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerDate').on('change', function () {
        table
            .columns(7)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerTypeManagement').on('change', function () {
        table
            .columns(8)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerResultManagement').on('change', function () {
        table
            .columns(9)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerComment').on('change', function () {
        table
            .columns(10)
            .search(this.value)
            .draw();

        prepareEventTable();
    });

    $('#SellerSuggestedImprovement').on('change', function () {
        table
            .columns(11)
            .search(this.value)
            .draw();

        prepareEventTable();
    });
}

function LoadData2(allData) {
    if (globalFirstTime) { BeginRequestHandler(); globalFirstTime = false; }

    $.ajax({
        type: "POST",
        url: "/Home/_SellerManagementTable",
        data: { allData: allData },
        dataType: "html",
        success: function (response) {

            $('#tblContainer').html(response);
            initializeDatatable();
            InitializeSelect2();
            prepareEventTable();

            //
            eraseCookie('WasloadData');
            //
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando las informacines");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando la data");
        }
    });
}


function initializeDatatable() {

    var table = $('#tableManagements').DataTable({
        //scrollY: "300px",
        //scrollX: true,
        //scrollCollapse: true,
        paging: true,
        responsive: true,
        sort: false,
        pageLength: 10,
        //filter:true
        //fixedColumns: false
        drawCallback: function () {
            $('.paginate_button.next', this.api().table().container())
            .on('click', function () {
                prepareEventTable();
            });
        }
    });


    refreshFilters(table);

    $(document).on('click', '.paginate_button, #tableManagements_previous', function () {
        prepareEventTable();
    });
}

function prepareEventTable() {

    $(document).on('click', '#linkCode, #linkCode_New', function () {
        //$('#myRow, .myRow').trigger('dblclick');
        var datos = $(this).attr('data-json');
        if (datos.length <= 0) {
            return;
        }
        var row = JSON.parse(datos);
        redirectAgent(row.AgentCode, row.SupervisorAgentCode)
    });

    $('#myRow, .myRow').dblclick(function () {
        var datos = $(this).attr('data-json');
        if (datos.length <= 0) {
            return;
        }
        var row = JSON.parse(datos);
        redirectAgent(row.AgentCode, row.SupervisorAgentCode)
        //window.location.href = "/Agent/AddNewAgentInfo?a=" + row.AgentCode;
        //window.history.replaceState({}, document.title, "/Agent/AddNewAgentInfo?agentCode=" + row.AgentCode);

        //window.location.reload();
    });
}

function redirectAgent(AgentCode, supervisorCode) {
    //
    createCookie('WasloadData', true, 1);
    //
    window.location.href = "/Agent/AddNewAgentInfo?a=" + AgentCode + "&b=" + supervisorCode;
}

$('#scroll_1').css("visibility", 'hidden');


function LoadData(allData, paramFiltersJson, thFilters) {
    if (globalFirstTime) { BeginRequestHandler(); globalFirstTime = false; }

    if (allData == undefined)
        allData = "";

    if (thFilters == undefined)
        thFilters = thFiltersAux;

    if (paramFiltersJson == undefined)
        paramFiltersJson = jsonFilterAux;

    GetPartialView("/Home/_PartialManagementGrid", JSON.stringify({ allData: allData, paramFiltersJson: paramFiltersJson }), function (data) {
        $('#tblContainer').html(data);
        SetManagementGridPagination(allData, paramFiltersJson, thFilters);
        prepareEventTable();
        eraseCookie('WasloadData');
    }, true);
}

function SetManagementGridPagination(allData, paramFiltersJson, thFilters) {
    var GridId = "managementsGrid";
    var $GridId = $("#" + GridId);
    if (allData == undefined)
        allData = "";

    if (thFilters == undefined)
        thFilters = thFiltersAux;

    if (paramFiltersJson == undefined || paramFiltersJson == null)
        paramFiltersJson = (jsonFilterAux == null || jsonFilterAux == undefined) ? "" : jsonFilterAux;

    $GridId.find("tfoot a").each(function () {
        var $this = $(this);
        var parameter = "&allData=" + allData + "&paramFiltersJson=" + paramFiltersJson;

        var urlBase = "/Home/_PartialManagementGrid?page=";
        var newURL = GetPagesGrid(urlBase, parameter, $GridId, $this);
        $this.attr("href", newURL);
    });

    GenerateFiltersGrid(GridId, true, 1, function (paramFiltersJson, thFilters) { LoadData(allData, paramFiltersJson, thFilters); });

    SetSearchButtonGrid($GridId, thFilters);
}


function GenerateFiltersGrid(idGrid, AddSearchButtonOnLastColumn, IndexBegin, callback) {
    IndexBegin = IndexBegin == undefined ? 0 : IndexBegin;

    var $Grid = $("#" + idGrid);
    //Generar filtros        
    var hdnDataColumnVal = $Grid.parents().eq(1).find("#hdnDataColumns").val();
    var dataCol = hdnDataColumnVal != "" ? JSON.parse(hdnDataColumnVal)
                                         : null;

    var $thead = $Grid.find("thead");
    var Ccount = $thead.find("tr").find("th").length;
    //Agregar el nuevo tr
    $thead.append("<tr/>");
    var $TrLast = $thead.find("tr:last");

    //Agregar los ths
    for (var i = 0; i < Ccount ; i++)
        $TrLast.append("<th/>");

    var $thSearch = $TrLast.find("th:last");

    if (AddSearchButtonOnLastColumn) {
        $thSearch.html("<i class='fa fa-search' style='margin-bottom: 11px !important;' onclick='' id='search" + idGrid + "'></i>");

        var $i = $thSearch.find("i:last");

        $("#search" + idGrid).click(function () {
            SendFilters(IndexBegin, idGrid, callback);
            SetKeyPressTxtFilter($thSearch, $Grid);
        });

    }

    var $ths = $TrLast.find("th");
    var index = 0;
    var totalTh = $ths.length - 1;
    for (var i = IndexBegin; i < totalTh ; i++) {
        try {
            $element = $($ths[i]);
            var Draw = !$element.hasClass("fa-search");
            if (Draw) {
                var idtxt = "txt" + dataCol[index].FieldTableName;
                var isNumber = dataCol[index].IsNumber;
                var input = "<input type='text' autocomplete='off' " + (isNumber ? "decimal=decimal" : "") + " isnumber='" + isNumber + "' class='form-control' id='" + idtxt + "'>"
                $element.html(input);
                index++;
            }
        } catch (e) {
            console.log(e.message + idtxt);
        }
    }
   SetKeyPressTxtFilter($thSearch, $Grid);
}

function SendFilters(IndexBegin, IdGrid, callback) {
    IndexBegin = IndexBegin == undefined ? 0 : IndexBegin;
    var oFilter = [];
    var $Grid = $("#" + IdGrid);
    var $theadFilters = $Grid.find("thead tr").eq(1);
    var $ths = $theadFilters.find("th");

    var totalTh = ($ths.length - IndexBegin);

    for (var i = IndexBegin; i <= totalTh ; i++) {
        $element = $($ths[i]);
        var $input = $element.find("input:text");
        var inputId = $input.attr("id");
        var FieldName = replaceAll("txt", "", inputId);
        var esNumero = $input.attr("isnumber") == "true";
        var Value = $input.val();
        var item = { Key: FieldName, Value: Value, isNumber: esNumero };
        oFilter.push(item);
    }

    var jsonFilter = JSON.stringify(oFilter);
    var thFilters = $ths;
    thFiltersAux = thFilters;
    jsonFilter = jsonFilter == "[]" ? "" : jsonFilter;
    jsonFilterAux = jsonFilter;

    if (callback != undefined)
        callback(jsonFilter, thFilters);
}


function GetPagesGrid(urlBase, Parameters, $gridId, $this) {

    var ValueText = $this.text();
    var CurrentPage = $gridId.parents().eq(1).find("#hdnCurrentPage").val();
    var LastPage = $gridId.parents().eq(1).find("#hdnLastPage").val();

    if (ValueText == ">")
        CurrentPage++;
    else if (ValueText == "<")
        CurrentPage--;
    else if (ValueText == "<<")
        CurrentPage = 1;
    else if (ValueText == ">>")
        CurrentPage = LastPage;
    else
        CurrentPage = ValueText;

    urlBase += CurrentPage
    if (Parameters != null)
        urlBase += Parameters;

    return encodeURI(urlBase);
}


function SetKeyPressTxtFilter($thSearch, $Grid) {
    var $inputs = $Grid.find("thead tr").eq(1).find("input:text");
    $(document).off("keypress");
    $(document).on('keypress', $inputs, function (event) {

        if (event.which == 13)
            $thSearch.find("#search" + $Grid.attr("id")).click();
    });
}




function CallAjax(vUrl, vParameter, vDataType, vSucess, RequestType, isAsync) {
    $.ajax({
        type: RequestType,
        url: vUrl,
        data: vParameter != undefined ? vParameter : {},
        contentType: "application/json; charset=utf-8",
        dataType: vDataType,
        success: vSucess,
        async: isAsync != undefined ? isAsync : true,
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            if (data.status == 0) {
                showError(["Se ha perdido ha la conexión con el servidor remoto"], "Advertencia");
                return false;
            }
            if (data.status != 200) {
                if (data != undefined && data.ErrorDescription != undefined)
                    showError([data.ErrorDescription], "Advertencia");
                else
                    if (data != undefined) {
                        showError([data.responseText], "Advertencia");
                    }
            }
        }

    });
}

function GetPartialView(vUrl, vParameter, vSucess, IsAsync) {
    CallAjax(vUrl, vParameter, "html", vSucess, "POST", (IsAsync == undefined ? true : IsAsync));
}

function replaceAll(find, replace, str) {
    var result;
    try {
        result = str.replace(new RegExp(find, 'g'), replace);
    } catch (e) {

    }
    return result;
}

function SetSearchButtonGrid($grid, thFilters) {
    if (thFilters != undefined) {
        var $trHeadFiltersdata = $grid.find("thead tr");
        var $trHeadFilters0 = $trHeadFiltersdata.eq(0);
        var $trHeadFilters1 = $trHeadFiltersdata.eq(1);

        var $ths = $trHeadFilters1.find("th");
        var $LastTH = $trHeadFilters1.find("th:last");
        $LastTH.hide();
        $trHeadFilters0.append($LastTH);
        $trHeadFilters1.find("th").remove();
        for (var i = 0; i < thFilters.length - 1; i++) {
            $trHeadFilters1.append(thFilters[i]);
        }

        var thTarget = $trHeadFilters0.find("th:last");
        $trHeadFilters1.append(thTarget);
        thTarget.show();

        $trHeadFilters1.find("input:text").each(function () {
            var $element = $(this);
            if ($element.val() != "") {
                $element.focus();
                return;
            }
        });
    }
}