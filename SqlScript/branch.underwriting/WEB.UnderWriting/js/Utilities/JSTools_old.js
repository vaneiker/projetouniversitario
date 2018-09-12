
var divLoading = '<div class="loading2" id="LondingImage" style="display: none;z-index: 15000000000;">';

function BeginRequestHandler(sender, args)
{
    $("body").append(divLoading);
    $("#LondingImage").css("display", "block");    
}

function EndRequestHandler(sender, args)
{
    $("#LondingImage").remove();
}

hasScroll = function (divnode)
{
    return (divnode.scrollHeight > divnode.clientHeight);
};

setPosAllScroll = function () {
    var vHiddenField = $("#hdnPosScrollDivs");
    var parsearJson = JSON.parse(vHiddenField.val());
                                     
    $.each(parsearJson, function (key, value) {
        $('#' + key).scrollTop(value);
    });
};

setRemaindAllScrollPage = function () {
    var vHiddenField = $("#hdnPosScrollDivs");

    if (vHiddenField.val() == "") {
        var vjson = "{";

        $("body").find("div").each(function () {

            var vScroll = hasScroll(this);
            var hasId = $(this).attr("id") != "";

            var visible = $(this).css("overflow");

            if (vScroll & visible != "hidden" & hasId) {
                var xPos = $(this).scrollTop();

                //Armar el Json
                vjson += ('"' + this.id) + '":"' + xPos + '",';

                $(this).scroll(function () {
                    var vScroll = $(this).scrollTop();
                    var parsearJson = JSON.parse(vHiddenField.val());
                    parsearJson[this.id] = vScroll;
                    vHiddenField.val(JSON.stringify(parsearJson));
                });
            }
        });

        vjson = vjson.substring(0, vjson.toString().length - 1);
        vjson += "}";

        vHiddenField.val(vjson);
    } else {
        //El hiddenfield tiene data 
        var parsearJson = JSON.parse(vHiddenField.val());

        $.each(parsearJson, function (key, value) {
            var vScroll = $('#' + key).scrollTop();
            parsearJson[key] = vScroll;
            vHiddenField.val(JSON.stringify(parsearJson));
        });
    }
};

function sValidosarCadena(string) {
    var ValidCharacter = "123456789abcdefghijklmnopqrstuvwyzABCDEFGHIJKLMNOPQRSTUVWXYZ@()+=.";

    for (var i = 0, output = '', sValidos = ValidCharacter; i < string.length; i++)
        if (sValidos.indexOf(string.charAt(i)) != -1)
            output += string.charAt(i);
    return output;
}

ExportarHTMLExcel = function (idDivData) {

    window.open('data:application/vnd.ms-excel,' + encodeURIComponent($(idDivData).html()));
    e.preventDefault();
};

MyJSRound = function (cantidad, decimales) {
    var cantidad = parseFloat(cantidad);
    var decimales = parseFloat(decimales);
    decimales = (!decimales ? 2 : decimales);
    return Math.round(cantidad * Math.pow(10, decimales)) / Math.pow(10, decimales);
};

//Author: Lic. Carlos Ml. Lebron B.
CountCheck = function (gridView) {

    var count = 0;

    $(gridView).find("input:checkbox").each(function () {
        if (this.checked == true) {
            count++;
        }
    });

    return count;
};

HoverRowGrid = function (gridView) {

    $("#" + gridView).find("tr").mouseover(function () {
        var x = $(this).attr("class");
        if (x != 'SelectedRowStyle') {
            if ($(this).attr("class") === undefined) {
                $(this).css({ "background-color": "#ACD392", "cursor": "pointer" });
                $(this).find("span").css({ "color": "#555" });
            }
        }
    });

    $("#" + gridView).find("tr").mouseout(function () {
        var x = $(this).attr("class");
        if (x != 'SelectedRowStyle') {
            if ($(this).attr("class") === undefined) {
                $(this).css({ "background-color": "white" });
                $(this).find("span").css({ "color": "#333" });
            }
        }
    });
};

/*
Function: MaxMinWindowAjaxModalPopup
Author  : Lic. Carlos ML. Lebron
*/
MaxMinWindowAjaxModalPopup = function (obj) {

    var objWindowParent = $(obj).parent().parent().parent().parent().parent();

    $(objWindowParent).css("width", "100%");
    $(objWindowParent).css("height", "100%");

    var AltoVentana = screen.height; // contiene la altura en pixels de la pantalla 
    var AnchoVentana = screen.width; // contiene la anchura en pixels de la pantalla 

    //Maximizar
    if ($("#btnMaxMin").attr("alt") == "0") {

        var objAlto = $(objWindowParent).css("height").replace("px", ""); //Alto del Objeto
        var objAncho = $(objWindowParent).css("width").replace("px", ""); //Ancho del Objeto

        var X = (AnchoVentana / 2) - (objAncho / 2);
        var Y = (AltoVentana / 2) - (objAlto / 2);

        //Centralizar el Objeto
        $(objWindowParent).css("top", Y + "px");
        $(objWindowParent).css("left", X + "px");

        //Esto es para el jodio explorer
        if (navigator.appVersion.indexOf("MSIE 7.") != -1 ||
            navigator.appVersion.indexOf("MSIE 8.") != -1 ||
            navigator.appVersion.indexOf("MSIE 9.") != -1 ||
            navigator.appVersion.indexOf("MSIE 10.") != -1
        ) {
            var objObject = $(".PdfViewer").find("object")[0];
            $(objObject).css("width", (AnchoVentana - 25) + "px");
            $(objObject).css("height", (AltoVentana - 180) + "px");
        } else {
            //Esto es para todos los navegadores que funcionan correctamente 
            $(".PdfViewer > object > embed").css("width", (AnchoVentana - 13) + "px");
            $(".PdfViewer > object > embed").css("height", (AltoVentana - 180) + "px");
        }

        $(document).scrollTop(600);
        $(document).scrollTop(0);
        $("#btnMaxMin").css("background-image", "url('../../Images/MIN.png')");
        $("#btnMaxMin").attr("alt", "1");
    } else
        //Minimizar
        if ($("#btnMaxMin").attr("alt") == "1") {
            $(objWindowParent).css("width", "1177px");
            $(objWindowParent).css("height", "700px");
            var objAlto = $(objWindowParent).css("height").replace("px", "");
            var objAncho = $(objWindowParent).css("width").replace("px", "");

            var X = (AnchoVentana / 2) - (objAncho / 2);
            var Y = (AltoVentana / 2) - (objAlto / 2);

            $(objWindowParent).css("top", Y + "px");
            $(objWindowParent).css("left", X + "px");

            //Esto es para el jodio explorer
            if (navigator.appVersion.indexOf("MSIE 7.") != -1 ||
            navigator.appVersion.indexOf("MSIE 8.") != -1 ||
            navigator.appVersion.indexOf("MSIE 9.") != -1 ||
            navigator.appVersion.indexOf("MSIE 10.") != -1
            ) {
                var objObject = $(".PdfViewer").find("object")[0];
                $(objObject).css("width", "1177px");
                $(objObject).css("height", "700px");
            } else {
                //Esto es para todos los navegadores que funcionan correctamente 
                $(".PdfViewer > object > embed").css("width", "1177px");
                $(".PdfViewer > object > embed").css("height", "700px");
            }
            $(document).scrollTop(600);
            $("#btnMaxMin").css("background-image", "url('../../Images/MAXIM.png')");
            $("#btnMaxMin").attr("alt", "0");
        }

};

/*
Fin Max Window
*/

//Author:Lic. Carlos ML. Lebron
MyjConfirm = function (options) {

    jConfirm('Do you wish to proceed with this action/task?', 'Confirmation', function (r) {
        if (r) {
            options.pFunctionOK();
        } else
            options.pFunctionCancel();
    });

    return false;
};


//Author: Lic. Carlos Ml. Lebron B.
DiscardPreviewPDF = function () {
    $('#hdnShowPreviewPDF').val('false');
    $find('ModalPopupPDFViewer').hide();
};

//Author: Lic. Carlos Ml. Lebron B.
function redondeo2decimales(numero) {
    var original = parseFloat(numero);

    var result = Math.round(original * 100) / 100;
    return result;
}

//Author: Lic. Carlos Ml. Lebron B.
ReplaceAll = function (cadena, caracterBuscado, caracterRemplazar) {
    var cadenaSalida = "";

    for (var i = 0; i < cadena.length; i++) {
        // si es igual al caracter buscado lo remplazamos 
        if (caracterBuscado == "" + cadena.charAt(i))
            cadenaSalida = cadenaSalida + "" + caracterRemplazar;
        else
            cadenaSalida = cadenaSalida + "" + cadena.charAt(i);
    }
    return cadenaSalida;
};


//Author: Lic. Carlos Ml. Lebron B.
AlternateRow = function (gridView) {
    var rows = $(gridView + " > tbody > tr");

    for (var rowIndex = 0; rowIndex <= rows.length - 1; rowIndex++) {
        var mod = (rowIndex % 2);
        if (mod == 0)
            $(rows[rowIndex]).attr("class", "AlternateRow");
    }
};

//Author: Lic. Carlos Ml. Lebron B.
HasSelectedItemInGriView = function (gridView) {
    var lockPanelBar = false;
    var objTbody = $(gridView).find("tbody")[0];
    var rows = $(objTbody).find("tr");
    for (var x = 0; x <= rows.length - 1; x++) {
        var rowClass = $(rows[x]).attr("class");
        if (rowClass == "SelectedRowStyle") {
            lockPanelBar = true;
            break;
        }
    }
    return lockPanelBar;
};

//Author: Lic. Carlos Ml. Lebron B.
CustomDialogMessage = function (msj) {

    var divToCreate = "<div id='dvMessage'></div>";
    $("body").append(divToCreate);

    var divCreated = $("#dvMessage");

    $(divCreated).dialog({
        autoOpen: false,
        resizable: false,
        height: 126,
        width: 402,
        modal: true,
        show: { effect: "fadeIn", duration: 260 },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $(divCreated).remove();
        },
        open: function ()
        {
            $(divCreated).html(msj);
            AddPopIframe();
        }
    }).dialog("open");   
};

//getTranslation = function (msj) {
//    $.ajax({
//        url: "../../ShareHolderView/Services/Services.aspx/GetTraduction",
//        type: "POST",
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        data: "{'Lang' : '" + $("#hdnLang").val() + "','Text':'" + msj + "'}",
//        dataFilter: function (data) { return data; },
//        success: function (data) {
//            Traduccion = data.d;
//        },
//        error: function (result) {
//            CustomDialogMessage("Error" + result);
//        }
//    });
//}


//Author: Lic. Carlos Ml. Lebron B.
DlgConfirm = function (obj) {
    var divToCreate = "<div id='dvConfirmDialog'></div>";

    $("body").append(divToCreate);

    var divCreated = $("#dvConfirmDialog");

    divCreated.html("Do you wish to proceed with this action/task?");

    //Botones en Ingles
    var pButtonsEn = {
        "Yes": function () {
            __doPostBack(obj.name, '');
            $(divCreated).dialog("close");
        },
        "No": function () { $(divCreated).dialog("close"); }
    };

    //Botenes en español
    var pButtonsEs = {
        "Si": function () {
            __doPostBack(obj.name, '');
            $(divCreated).dialog("close");
        },
        "No": function () { $(divCreated).dialog("close"); }
    };

    $(divCreated).dialog(
    {
        draggable: true,
        height: 126,
        width: 402,
        show: { effect: "fadeIn", duration: 260 },
        buttons: $("#hdnLang").val() == "EN" ? pButtonsEn : pButtonsEs,
        title: $("#hdnLang").val() == "EN" ? "Confirmation" : "Confirmacion",
        autoOpen: false,
        modal: true,
        open: function () {
            AddPopIframe();
        },
        close: function () {
            $(divCreated).remove();
        }
    }).dialog("open");

    return false;
};

//Author: Lic. Carlos Ml. Lebron B.
var JQueryDateTimePicker = function (options) {

    options.ptimeFormat = options.ptimeFormat || "";

    $(options.ElementIDorClass).datepicker({
        changeYear: true,
        changeMonth: true,
        showOn: "button",
        buttonImage: "../../image/botones/date.gif",
        buttonImageOnly: true,
        timeFormat: "hh:mm tt"
    });
};


//(function ($) {
//    $.fn.JQueryPopup = function (options) 
//    {

//        //Variables por defecto
//        var defaults = {
//            pdraggable: true,
//            pautoOpen: false,
//            presizable: false,
//            pmodal: true,
//            pTitle: "",
//            pShowTitleBar: true,
//            OnCLose: function() {},
//            OnOpen: function() {}
//        };

//        var options = $.extend(defaults, options);
//        return this.each(function () {

//        });
//    };
//})(jQuery);

/*
  Author: Lic. Carlos Ml. Lebron B.
  JQuery Popup es una Objeto que crea un dialog de JQuery UI
*/
var JQueryPopup = function (options) {

    //Configurar el Popup
    var popup = ".ui-dialog:has(" + options.ElementIDorClass + ")";

    options.pposition = options.pposition || { my: "center", at: "center", of: window };

    options.pButtons = options.pButtons || {};

    //Remover el popup para inicializarlo nuevamente
    $(popup).remove();

    //Agregar padding 0px y margin 0px al div

    $(options.ElementIDorClass).css("padding", "0");
    $(options.ElementIDorClass).css("margin", "0");

    options.pdraggable = options.pdraggable || true;
    options.pautoOpen = options.pautoOpen || false;
    options.presizable = options.presizable || false;
    options.pmodal = true;
    options.pTitle = (options.pTitle) ? options.pTitle : "";
    options.pShowTitleBar = (options.pShowTitleBar || options.pShowTitleBar == false) ? options.pShowTitleBar : true;
    options.OnCLose = (options.OnCLose == null) ? options.OnCLose = function () { } : options.OnCLose;
    options.OnOpen = (options.OnOpen == null) ? options.OnOpen = function () { } : options.OnOpen;
    options.pwidth = (options.pwidth == null) ? "auto" : options.pwidth;
    options.pheight = (options.pheight == null) ? "auto" : options.pheight;
    options.peffect = (options.peffect == null) ? { effect: "fadeIn", duration: 260 } : {};

    $(options.ElementIDorClass).dialog(
    {
        draggable: options.pdraggable,
        width: options.pwidth,
        height: options.pheight,
        closeOnEscape: true,
        show: options.peffect,
        buttons: options.pButtons,
        title: options.pTitle,
        autoOpen: options.pautoOpen,
        position: options.pposition,
        resizable: options.presizable,
        modal: options.pmodal,
        open: function () { $(".ui-widget-overlay").css("z-index", "99"); },
        create: function () {
            options.OnOpen();
            $(".ui-dialog-titlebar").css("display", (options.pShowTitleBar == false) ? "none" : "block");               
            $(".ui-dialog-titlebar > span").css("height", "30px");
            $(".ui-dialog-titlebar > span").css("line-height", "28px");            
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog").css("border", "0");
            $(".ui-button").css("display", "none");

            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });

            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });            
            $(".ui-dialog-titlebar").addClass("HeaderPopup").addClass("head");
            AddPopIframe();
        },
        beforeClose: options.OnCLose,
        close: function () {
            $(options.ElementIDorClass).dialog("close");
        }
    }).parent().appendTo(jQuery("form:first"));

    this.Open = function () {
        ///$(".ui-widget-overlay").css("z-index", "1");     
        $(options.ElementIDorClass).dialog("open");
    };

    this.Close = function () {
        $(options.ElementIDorClass).dialog("close");
    };
};
/* Fin JQuery Popup */

//Author: Lic. Carlos Ml. Lebron B.
ShowToolTipMessage = function (element, pcontent, pposition, ptitle,ptheme) {

    pposition = (pposition == null) ? 'top' : pposition;
    ptheme = (ptheme == null) ? 'bootstrap' : ptheme;

    var divTitle = "<div style='float:left;padding-left: 4px;color:#5C5C5C;'>" + ptitle + "</div>";

    $(element).jqxTooltip
    ({
        content: "<div class='CloseToolTip' style='width:100%;text-align:right;font-weight: bold;position: relative;top: -4px;left: -4px;font-size: 17px;cursor:pointer'>" + divTitle + " x </div>" + pcontent,
        name: '',
        theme: ptheme,
        autoHide: false,
        position: pposition,
        closeOnClick: false,
        trigger: 'click'
    });

    if (
        $(element).is("input") |
            $(element).is("tr") |
            $(element).is("button") |
            $(element).is("a") |
            $(element).is("div") |
            $(element).is("td")
    )
        $(element).css("cursor", "pointer");
    else
        $(element).css("cursor", "default");

    $(element).jqxTooltip('open');

    $(".CloseToolTip").click(function () {
        // $(element).find("input:first").attr("alt", "");
        $(element).jqxTooltip('destroy');
    });

};

setToolTipInputFile = function () {
    $("input[type='file']").mouseover(function () {

        var msj = $("#hdnLang").val() != "EN" ? "Haga Click o Doble Click para agregar un documento" : "Click or Double Click to add a document";

        $(this).attr("alt", msj);

        ShowToolTips(this, "top", true);
    });
};

//Author: Lic. Carlos Ml. Lebron B.
ShowToolTips = function (element, pposition, pautoHide, ptheme) {

    var msj = "";

    if ($(element).is("input"))
        msj = $(element).val();
    else if ($(element).is("a"))
        msj = $(element).html();

    pposition = (pposition == null) ? 'top' : pposition;
    pautoHide = (pautoHide == null) ? true : pautoHide;
    ptheme = (ptheme == null) ? 'ui-sunny' : ptheme;

    var message = $(element).attr("alt") != "" ? $(element).attr("alt") : "";

    $(element).jqxTooltip
    ({
        content: message + msj,
        position: pposition,
        name: '',
        theme: ptheme,
        autoHide: pautoHide
    });

    if (
        $(element).is("input") |
            $(element).is("tr") |
            $(element).is("button") |
            $(element).is("a") |
            $(element).is("div")
    )
        $(element).css("cursor", "pointer");
    else
        $(element).css("cursor", "default");

    $(element).jqxTooltip('open');
};


//Author: Lic. Carlos Ml. Lebron B.
ShowToolTipsEx = function (element, pposition, pautoHide, ptheme) {


    pposition = (pposition == null) ? 'top' : pposition;
    pautoHide = (pautoHide == null) ? true : pautoHide;
    ptheme = (ptheme == null) ? 'ui-sunny' : ptheme;

    var message = $(element).attr("alt");

    $(element).jqxTooltip
    ({
        content: message,
        position: pposition,
        name: '',
        theme: ptheme,
        autoHide: pautoHide
    });

    if (
        $(element).is("input") |
            $(element).is("tr") |
            $(element).is("button") |
            $(element).is("a") |
            $(element).is("div")
    )
        $(element).css("cursor", "pointer");
    else
        $(element).css("cursor", "default");

    $(element).jqxTooltip('open');
};


//Author: Lic. Carlos Ml. Lebron B.
CustomToolTips = function (elementIdOrClass, message, pposition, pduration) {
    var theme = 'ui-sunny';

    pposition = (pposition == null) ? 'top' : pposition;

    pduration = (pduration == null) ? 2000 : pduration;

    $(elementIdOrClass).jqxTooltip(
    {
        content: message,
        position: pposition,
        name: '',
        theme: theme,
        autoHideDelay: pduration,
        autoHide: true
    });

    $(elementIdOrClass).focus();

    $(elementIdOrClass).jqxTooltip('open');    

    setTimeout(function () {
        $(elementIdOrClass).jqxTooltip('destroy');
    }, pduration);

};

//Author: Lic. Carlos Ml. Lebron B.
$$ = function (ElementIDOrClass, pheight, pwidth, ListOfValueType, Pk) {
    $(ElementIDOrClass).click(function () {
        ListOfValuePopup(ElementIDOrClass, pheight, pwidth, ListOfValueType, Pk);
    });
};

//Author: Lic. Carlos Ml. Lebron B.
ListOfValuePopup = function (ElementIDOrClass, pheight, pwidth, ListOfValueType, Pk) {
    $.ajax({
        url: "../../ShareHolderView/Services/Services.aspx/GetData",
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: "{'ListOfValueType' : '" + ListOfValueType + "','ColumnPrimayKey':'" + Pk + "'}",
        dataFilter: function (data) { return data; },
        success: function (data) {
            DataBindGrid(ElementIDOrClass, data.d, pheight, pwidth);
        },
        error: function (result) {
            CustomDialogMessage("Error:" + result);
        }
    });
};

//Author: Lic. Carlos Ml. Lebron B.
DataBindGrid = function (ElementIDOrClass, data, pheight, pwidth) {

    //Crear el div   
    var div = $("<div style ='display: none;padding:0px !important;' id= '" + getNextIDDivListOfValuePopup() + "' class = 'ListOfValue'> <div style ='margin:0px !important;' id= 'jqxgrid'> <div/>  </div>");

    $("#ListOfValueContainer").append(div);


    var Datos = JSON.parse(data);
    var vDataFields = JSON.parse(Datos[0].datafields);
    var vColumns = JSON.parse(Datos[0].columns);
    var PrimaryKey = Datos[0].columnPrimayKey;

    //Preparar la data
    var source =
    {
        localdata: Datos,
        datatype: "json",
        datafields: vDataFields,
        id: PrimaryKey
    };

    var dataAdapter = new $.jqx.dataAdapter(source);

    var DivGrid = div.find("#jqxgrid");

    $(DivGrid).jqxGrid(
    {
        width: pwidth,
        height: pheight,
        editable: false,
        showfilterrow: true,
        filterable: true,
        altrows: true,
        source: dataAdapter,
        columnsresize: true,
        columns: vColumns
    });

    $(DivGrid).jqxGrid('hidecolumn', PrimaryKey);
    $(DivGrid).jqxGrid('autoresizecolumns');

    $(DivGrid).on('rowdoubleclick', function (event) {
        var args = event.args;
        var row = args.rowindex;
        var rowid = $(DivGrid).jqxGrid('getrowid', row);
        var data = $(DivGrid).jqxGrid('getrowdata', row);
        $(ElementIDOrClass).val(data["Name"]);
        $(div).dialog("close");
    });

    $(DivGrid).on("filter", function (event) {
        $(DivGrid).jqxGrid('autoresizecolumns');
    });

    CustomListOfValue(div);

};

getNextIDDivListOfValuePopup = function () {
    return Math.floor(Math.random() * (999999 - 1 + 1)) + 1;
};

//Author: Lic. Carlos Ml. Lebron B.
CustomListOfValue = function (div) {
    $(div).dialog({
        autoOpen: false,
        resizable: false,
        height: 490,
        width: 605,
        modal: true,
        show: { effect: "fadeIn", duration: 260 },
        close: function (event, ui) {

        },
        buttons: {
            "Ok": function () {
                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $(div).dialog("open");
};

//Author: Lic. Carlos Ml. Lebron B.
setClickCheckBoxGridView = function (GridView, objSelectAll) {
    $(GridView).find("input:checkbox").each(function () {
        $(this).click(function () {
            var Checkeados = 0;
            var objChecks = $(GridView).find("input:checkbox");
            var TotalChecks = objChecks.length;
            //Buscar todos los que estan chequeados
            objChecks.each(function () {
                if (this.checked == true)
                    Checkeados++;
            });
            $(objSelectAll).prop("checked", (Checkeados == TotalChecks));
        });
    });
};


/*PREVIEW  */
function Preview(FileName, PreviewStatement, ContentStatement) {

    if (UCPreviewPath != null) {

        //UCRightPanel_ResetPanels();
        var DivUCPreview = document.getElementById(PreviewStatement);

        var UCPreviewContent = document.getElementById(ContentStatement);


        var FullName = UCPreviewPath + FileName;

        DivUCPreview.style.display = 'block';
        var View = document.createElement('object');
        View.setAttribute("data", FullName);
        View.setAttribute("type", "application/pdf");
        View.setAttribute("width", "100%");
        View.setAttribute("height", "100%");

        for (var Index = 0; Index < UCPreviewContent.childNodes.length; Index++) {
            UCPreviewContent.removeChild(UCPreviewContent.childNodes[Index]);
        }

        UCPreviewContent.appendChild(View);

    }
}

function validarPorciento(evt) {

    var value = parseInt((evt.which) ? evt.which : event.keyCode);
    if (value != 8) {

        if ((value >= 48 && value <= 57) || value == 46) {

            return true;
        }
        else {
            return false;
        }

    }
}

function AddPopIframe() {
    var popdiv = document.querySelectorAll('.ui-dialog');

    for (var i = 0, len = popdiv.length; i < len; i++) {
        var PopIframe = $get('popIframe' + popdiv[i].childNodes[1].id);
        if (PopIframe != null) {
            var result = $(popdiv[i]).find(PopIframe);
            if (result.lenght > 0) {
                popdiv[i].removeChild(PopIframe);
            }
        }



        var iframeid = 'popIframe' + popdiv[i].childNodes[1].id;
        var iframe = CreateNewPopFrame();
        iframe.setAttribute('id', iframeid);

        popdiv[i].appendChild(iframe);
    }
}

function CreateNewPopFrame() {
    var newiframe = document.createElement('iframe');
    var iframeid = 'popIframe';
    var iframesrc = 'about:blank';
    var iframeposition = 'absolute';
    var iframeborder = 'none';
    var iframetop = '0';
    var iframeleft = '0';
    var iframeheight = '100%';
    var iframewidth = '100%';
    var iframezindex = '-1';

    newiframe.setAttribute('id', iframeid);
    newiframe.setAttribute('src', iframesrc);
    newiframe.style.position = iframeposition;
    newiframe.style.border = iframeborder;
    newiframe.style.top = iframetop;
    newiframe.style.left = iframeleft;
    newiframe.style.height = iframeheight;
    newiframe.style.width = iframewidth;
    newiframe.style.zIndex = iframezindex;

    return newiframe;
}

function UncheckSelectAll(chk, chkSelectID) {
    var chkSelect = $get(chkSelectID);

    if (!chk.checked) {
        chkSelect.checked = false;
    }
}

