$(document).ready(function () {

    //InizitializeControls();
    //InitializeChosen();

    $(document).on('click', '#HideInHistory', function () {
        getFamilyBrochure()
    });

    $(document).on('click', '.myBrochure', function () {
        var id = $(this).attr('rowID');
        var href = $(this).attr('href');
        GetBrochureByProduct(id, href);
    });

    $(document).on('click', '.submyBrochure', function () {
        var id = $(this).attr('rowID');
        var href = $(this).attr('href');
        getCoverageTypesBrochure(id, href);
    });

    componentHandler.upgradeAllRegistered();
}); /// fin de document ready

function getFamilyBrochure() {
    $('#segundoTab').empty();
    $.ajax({
        type: "POST",
        url: "/Home/GetProductTypeFamily",
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            //recorro el listado de tipos de brochure
            $.each(result, function (idx, obj) {
                //formulo el id del registro
                var rowId = "#" + obj.name.toLowerCase() + "-tab";
                var element = "<li class='nav-item'>";
                element += "<a class='nav-link myBrochure' rowID='" + obj.Value + "' id='" + obj.name.toLowerCase() + "-tab' data-toggle='tab' href='#" + obj.name.toLowerCase() + "' role='tab' aria-controls='" + obj.name.toLowerCase() + "' aria-selected='true'>" + obj.name + "</a>";
                element += "</li>";

                $('#segundoTab').append(element);
                if (obj.Value == 1) {
                    $(rowId).addClass('active');
                    GetBrochureByProduct(obj.Value);
                }

            });

            /*var compare = "<li class='nav-item'>"
            compare += "<a class='nav-link' id='tblComparativos-tab' data-toggle='tab' href='#tblComparativos' role='tab' aria-controls='tblComparativos' aria-selected='false'>Tabla comparativos</a>";
            compare += "</li>";
            $('#segundoTab').append(compare);
            */
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando el listado de Brochure");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando el listado de Brochure");
        }
    });
}

function GetBrochureByProduct(ProductFamilyId, href) {

    $.ajax({
        url: "/Home/GetBrochureByProduct",
        dataType: 'json',
        async: false,
        data: { productTypeID: ProductFamilyId },
        success: function (result) {
            //recorro el listado de tipos de brochure            
            $('#dvtabContent').empty();
            $('#tercerTab').empty();

            var idDiv = href ? href.replace("#", "") : "ley";
            var elementDiv = "<div class='tab-pane fade show active' id='" + idDiv + "' role='tabpanel' aria-labelledby='" + idDiv + "-tab'>";
            var elementUl = "<ul class='nav nav-tabs justify-content-center' id='tercerTab' role='tablist'>";

            var firstTabSelected = true;
            var callCoveragesTypes = false;

            var objidBk = 0;
            var NameCleanBK = "";

            $.each(result, function (idx, obj) {

                var element = "<li class='nav-item'>";
                var rowId = ""
                var Name = obj.Name.toLowerCase().replace(" ", "").replace("á", "a").replace("é", "a").replace("í", "a").replace("ó", "a").replace("ú", "a");
                var NameClean = obj.Name.toLowerCase().replace(" ", "").replace("á", "a").replace("é", "a").replace("í", "a").replace("ó", "a").replace("ú", "a");

                NameClean = NameClean.replace(" ", "");

                if (firstTabSelected) {

                    rowId = "#" + NameClean.toLowerCase() + "i-tab";
                    element += "<a class='nav-link submyBrochure active' rowID='" + obj.Id + "' id='" + rowId.replace("#", "") + "' data-toggle='tab' href='#" + NameClean + "i' role='tab' aria-controls='" + NameClean + "i' aria-selected='true'>" + obj.Name + "</a>";

                    objidBk = obj.Id;
                    NameCleanBK = NameClean;

                    firstTabSelected = false;
                    callCoveragesTypes = true;
                }
                else if (obj.Id == 12) {

                    rowId = "#" + NameClean.toLowerCase() + "P-tab";
                    element += "<a class='nav-link submyBrochure' rowID='" + obj.Id + "' id='" + rowId.replace("#", "") + "' data-toggle='tab' href='#" + NameClean + "P' role='tab' aria-controls='" + NameClean + "P' aria-selected='false'>" + obj.Name + "</a>";

                } else {

                    rowId = "#" + NameClean.toLowerCase() + "-tab";
                    element += "<a class='nav-link submyBrochure' rowID='" + obj.Id + "' id='" + rowId.replace("#", "") + "' data-toggle='tab' href='#" + NameClean + "' role='tab' aria-controls='" + NameClean + "' aria-selected='false'>" + obj.Name + "</a>";
                }

                element += "</li>";
                elementUl += element;
            });

            elementUl += "</ul>";
            elementDiv += "</div>";

            $('#dvtabContent').append(elementDiv);
            $("#" + idDiv).append(elementUl);

            if (callCoveragesTypes) {
                getCoverageTypesBrochure(objidBk, NameCleanBK);
            }
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando el listado de Brochure");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando el listado de Brochure");
        }
    });
}

function getCoverageTypesBrochure(ProductTypeBrochureId, NameClean) {
    $.ajax({
        url: "/Home/GetCoverageTypesBrochure",
        dataType: 'json',
        async: false,
        data: { ProductTypeBrochureId: ProductTypeBrochureId },
        success: function (result) {

            var tblReturned = createNewTableWithHeader(NameClean, result);

            getCoverageDetailBrochure(ProductTypeBrochureId, tblReturned);

        },
        failure: function (response) {
            showError([response.responseText], "Error cargando los tipos de coberturas de Brochure");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando los tipos de coberturas de Brochure");
        }
    });
}

function createNewTableWithHeader(NameClean, coveragesLimitsHeaders) {

    $('#dvtabContent > #dvTabContentTableCoverages').remove();

    var dvTabContentTableCoverages = $("<div>").attr("id", "dvTabContentTableCoverages").addClass("tab-content");

    var row = "";

    var elementDiv = $("<div>").attr("id", "" + NameClean + "").attr("role", "tabpanel").attr("aria-labelledby", "" + NameClean + "-tab").addClass("tab-pane fade show active");
    var elementDiv2 = $("<div>").addClass("col-12 row float-none m-auto mdl-shadow--2dp");

    var responsetbl = IsAMobile() ? " table-responsive" : "";

    var tblCoverages = $("<table>").attr('id', 'coverageTable').addClass("table " + responsetbl + " table-striped");

    var tblHeader = $('<thead>');

    var tblHeaderTrRow = $('<tr>').addClass('coverageTypes');

    var tblHeaderTrRowHeader = $('<th>').attr('align', 'left').addClass('c1').text("");//&nbsp;
    tblHeaderTrRow.append(tblHeaderTrRowHeader);

    var arrNotRepeatLimit = [];

    //Dinamicamente traer los limites de las coberturas
    $.each(coveragesLimitsHeaders, function (idx, obj) {

        if (arrNotRepeatLimit.indexOf(obj.name) == -1) {

            var tblHeaderTrRowHeaderDyna = $('<th>').attr('align', 'center').addClass('bg-info mdl-color-text--white');
            $("<span>" + obj.name + "</span>").prependTo(tblHeaderTrRowHeaderDyna);
            tblHeaderTrRow.append(tblHeaderTrRowHeaderDyna);

            arrNotRepeatLimit.push(obj.name);
        }
    });
    //

    tblHeader.append(tblHeaderTrRow);

    tblCoverages.append(tblHeader);

    elementDiv2.append(tblCoverages);
    elementDiv.append(elementDiv2);

    dvTabContentTableCoverages.append(elementDiv);

    $('#dvtabContent').append(dvTabContentTableCoverages);

    return tblCoverages;
}

function getCoverageDetailBrochure(ProductTypeBrochureId, tblCoverages) {
    $.ajax({
        url: "/Home/GetCoverageDetailBrochure",
        dataType: 'json',
        async: false,
        data: { CoverageBrochureId: ProductTypeBrochureId },
        success: function (result) {

            var arrUsedCovTypes = [];
            var arrUsedCovName = [];

            if (result.result) {

                var tblHeaderTrRowNew = $('<tr>').addClass('bg-info mdl-color-text--white');

                var rowCount = $('#' + tblCoverages.attr("id") + '> thead >tr.coverageTypes > th').length;
                var oneTIme = false;
                var tblDetailRow = $('<tr>');
                var count = 0;
                var realHeader = $('#' + tblCoverages.attr("id") + '> thead');

                var generateNewTbl = 0;
                var beforeDv = tblCoverages.closest('div');
                var responsetbl = IsAMobile() ? " table-responsive" : "";
                var tblCoverages_New = $("<table>").attr('id', 'coverageTable_new').addClass("table " + responsetbl + " table-striped");
                var realHeader_New = $('<thead>');


                $.each(result.result, function (idx, obj) {

                    if (arrUsedCovTypes.indexOf(obj.CoverageType) == -1) {

                        if (generateNewTbl == 0) {

                            var tblHeaderTrcovname = $('<th>').attr('align', 'left').addClass('c1');
                            $("<span>" + obj.CoverageType + "</span>").prependTo(tblHeaderTrcovname);
                            tblHeaderTrRowNew.append(tblHeaderTrcovname);

                            arrUsedCovTypes.push(obj.CoverageType);
                            generateNewTbl = 1;
                        }
                        else if (generateNewTbl == 1) {

                            tblHeaderTrRowNew = $('<tr>').addClass('bg-info mdl-color-text--white');

                            var tblHeaderTrcovname = $('<th>').attr('align', 'left').addClass('c1');
                            $("<span>" + obj.CoverageType + "</span>").prependTo(tblHeaderTrcovname);
                            tblHeaderTrRowNew.append(tblHeaderTrcovname);

                            oneTIme = false;
                            generateNewTbl = 3;
                            arrUsedCovTypes.push(obj.CoverageType);
                            count = 0;
                            arrUsedCovName = [];
                        }
                    }

                    if (!oneTIme) {

                        for (var i = 1; i < rowCount; i++) {
                            var tblHeaderTrRowNewFixed = $('<th>').attr('align', 'center').addClass('c2');
                            $("<span>Límite</span>").prependTo(tblHeaderTrRowNewFixed);
                            tblHeaderTrRowNew.append(tblHeaderTrRowNewFixed);
                        }
                        oneTIme = true;
                        if (generateNewTbl !== 3) {
                            realHeader.append(tblHeaderTrRowNew);
                        }
                        else if (generateNewTbl == 3) {

                            realHeader_New.append(tblHeaderTrRowNew);
                            tblCoverages_New.append(realHeader_New);
                        }
                    }

                    if (arrUsedCovName.indexOf(obj.CoverageName.toLowerCase()) == -1) {

                        tblDetailRow = $('<tr>').attr('id', (count++));

                        var tblDetailRowCoverageName = $('<td>').attr('align', 'left').text(obj.CoverageName);
                        tblDetailRow.append(tblDetailRowCoverageName);
                        arrUsedCovName.push(obj.CoverageName.toLowerCase());

                        var valueByCoverageName = result.result.filter(function (item) {
                            return item.CoverageName.indexOf(obj.CoverageName) != -1;
                        });

                        $.each(valueByCoverageName, function (idx, objvalue) {
                            var tblDetailRowTdValue = $('<td>').attr('align', 'center').text(objvalue.Value);
                            tblDetailRow.append(tblDetailRowTdValue);
                        });

                        if (generateNewTbl != 3) {
                            tblCoverages.append(tblDetailRow);
                        }
                        else {
                            tblCoverages_New.append(tblDetailRow);
                        }
                    }
                });

                beforeDv.append(tblCoverages_New);
            }
        },
        failure: function (response) {
            showError([response.responseText], "Error cargando los tipos de coberturas de Brochure");
        },
        error: function (response) {
            showError([response.responseText], "Error cargando los tipos de coberturas de Brochure");
        }
    });
}

function createTableCoverageHeader(coverageName, NameClean) {

    //$('#dvTabContentTableCoverages').empty();

    //var elementDiv = "<div class='tab-pane fade show active' id='" + NameClean + "' role='tabpanel' aria-labelledby='" + NameClean + "-tab'>";
    //var elementDiv2 = "<div class='col-12 row float-none m-auto mdl-shadow--2dp'>";
    //var tblCoverages = "<table id='coverageTable' class='table table-responsive table-striped'>";
    //var tblHeaderTr = "<thead> <tr class='coverageTypes'>";


    var row = "";
    //var tableHeader = $('#coverageTable thead');
    //tableHeader.empty();

    //row = "<tr class='coverageTypes'></tr>";

    row += "<tr class='bg-info mdl-color-text--white'>";
    row += "<th align='left' class='c1'><span>" + coverageName + "</span></th>";
    row += "<th align='center' class='c2'><span>Límite</span></th>";
    row += "<th align='center' class='c2'><span>Límite</span></th>";
    row += "<th align='center' class='c2'><span>Límite</span></th>";
    row += "<th align='center' class='c2'><span>Límite</span></th>";
    row += "<th align='center' class='c2'><span>Límite</span></th>";
    row += "</tr>";

    //tblHeaderTr += row;
    //tblHeaderTr += "</tr> </thead>";

    //tableHeader.append(row);

    //elementDiv2 += tblCoverages;

    //elementDiv2 += "</div>";

    //elementDiv += elementDiv2;
    //elementDiv += "</div>";

}