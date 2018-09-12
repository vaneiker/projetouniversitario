/*
  JSTools Framework 1.0
  Author: Lic. Carlos Ml. Lebron
*/
/*
  JSTools Framework 1.0
  Author: Lic. Carlos Ml. Lebron
*/

var divLoading = '<div class="loading2" style="z-index: 99999999;">  </div> ';
var divImageLoading = '<div id="loading2Image" style="display: none;z-index: 99999999;"> <iframe src="about:blank" style="border:none; top: 0; left: 0; height:100%; width:100%; z-index:-1; position: absolute;"/></div> ';




var xPos, yPos;

CustomDialogMessageWithCallBack = function (Message, FuncCallBack, titlex, OnCloseFunc, key) {

    titles = (titlex == null) ? "Title" : titlex;
    OnCloseFunc = (OnCloseFunc == null) ? function () { } : OnCloseFunc;

    var DialogMessage = Message == "" || Message == null ? data.d : Message;

    var divToCreate = "<div id='dvMessage'></div>";
    $("body").append(divToCreate);

    var divCreated = $("#dvMessage");

    $(divCreated).dialog({
        title: titles,
        autoOpen: false,
        resizable: false,
        height: 150,
        position: { my: "center", at: "center", of: $("body") },
        width: 402,
        modal: true,
        show: {
            effect: "puff",
            duration: 260
        },
        hide: {
            effect: "puff",
            duration: 260
        },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
                FuncCallBack();
            }
        },
        create: function () {
            $(".ui-widget-overlay").css("z-index", "12999");
            $(".ui-dialog-buttons").css("z-index", "13000");
            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });

            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");

        },
        close: function () {
            OnCloseFunc();
            $(divCreated).remove();
        },
        open: function () {
            $(divCreated).html(Message);
            AddPopIframe();
            RelocatePops();
        }
    }).dialog("open");

    //if (key != "") {
    //    //Traductor
    //    getTranslate(key, function (data) {
    //        divCreated.html(DialogMessage);
    //    });
    //}
};

BeginRequestHandler = function (sender, args) {
    $("body").append(divLoading);
    $("body").append(divImageLoading);

    $("#loading2Image").css("display", "block");

    if (document.getElementById('scroll_2') == null)
        return;

    xPos = $get('scroll_2').scrollLeft;
    yPos = $get('scroll_2').scrollTop;

};

EndRequestHandler = function (sender, args) {
    $("#loading2Image,.loading2").remove();

    if (document.getElementById('scroll_2') == null)
        return;

    $get('scroll_2').scrollLeft = xPos;
    $get('scroll_2').scrollTop = yPos;
};

//Función para calcular los días transcurridos entre dos fechas
GetDaysDateBetween = function (f1, f2) {
    var aFecha1 = f1.split('/');
    var aFecha2 = f2.split('/');
    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    return dias;
};

CalculateDateDiff = function (dateFrom, dateTo) {
    var dateTo = new Date(dateTo);
    var dateFrom = new Date(dateFrom);

    var difference = (dateTo - dateFrom);

    var years = Math.floor(difference / (1000 * 60 * 60 * 24 * 365));

    difference -= years * (1000 * 60 * 60 * 24 * 365);

    var dif = '';

    if (years > 0)
        dif = years

    return dif
};

validateForm = function (form) {

    var result = true;
    var validationSummary = "";
    var labelName = "span:first";


    if ($("#hdnValidate").val() == "true") {

        //Buscar los campos que son requeridos   
        $("#" + form).find("[validation='Required']").each(function () {

            //Validar los input del tipo text
            if ($(this).is("input[type='text']")) {
                //Validar si esta vacio
                if ($(this).attr("alt") == "decimal-us") {
                    if ($(this).val() == "0.00") {
                        result = false;
                        var Field =  getLabelField($(this));
                        validationSummary += '<strong> * </strong> El campo "' + Field + '" es obligatorio' + '</br>';
                        $(this).focus();
                    }
                }
                else {

                    if ($.trim($(this).val()) == "") {
                        result = false;
                        var Field = getLabelField($(this));
                        if (!$(this).hasClass("datepicker"))
                            $(this).focus();
                        validationSummary += '<strong> * </strong> El campo "' + Field + '" es obligatorio' + '</br>';
                    }
                }

                //validar si tiene el tamaño correcto
                var Length = $(this).attr("validateLength");
                if (Length != null) {
                    if ($(this).val().length != Length) {
                        result = false;
                        var Field = getLabelField($(this));
                        validationSummary += '<strong> * </strong> The length of field "' + Field + '" must be' + '"' + Length + ' characters"</br>';
                    }
                }
                //validar si es email y que sea valido
                var isEmailType = $(this).attr("inputtype") == "Email";

                if (isEmailType) {
                    if (!isEmail($(this).val())) {
                        result = false;
                        var Field = getLabelField($(this));
                        validationSummary += '<strong> * </strong> The email provided for the email field is invalid </br>';
                    }
                }
            }

            if ($(this).is("textarea")) {
                if ($.trim($(this).val()) == "") {
                    result = false;
                    var Field = getLabelField($(this));
                    $(this).focus();
                    validationSummary += '<strong> * </strong> El campo "' + Field + '" es obligatorio' + '</br>';
                }
            }

            //Validar los select
            if ($(this).is("select")) {
                if ($(this).find("option").length > 0) {
                    if ($(this).val() == "-1") {
                        result = false;
                        var Field = getLabelField($(this));
                        validationSummary += '<strong> * </strong> El campo "' + Field + '" es obligatorio' + '</br>';
                    }
                } else {
                    result = false;
                    var Field = getLabelField($(this));
                    validationSummary += '<strong> * </strong> El campo "' + Field + '" es obligatorio' + '</br>';
                }
            }

            EndRequestHandler();
        });

        //Mostrar el summary de validaciones
        if (validationSummary != "")
            CustomDialogMessageEx(validationSummary, null, null, true, "Resumen de Validaciones");
    }
    return result;
};

function ValidateURL(URL) {
    //var urlregex = new RegExp("(http(s)?://|www?.|).*");

    var urlregex = new RegExp("^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$");
    if (urlregex.test(URL)) {
        return true;
    }
    CustomDialogMessageEx('Please provide a valid URL.', 500, 150, true, "Invalid URL");
    return false;
}

function ValidateDate(dtValue) {
    var urlregex = new RegExp("(0[1-9]|1[012])[- \/.](0[1-9]|[12][0-9]|3[01])[- \/.](19|20)\d\d");
    if (urlregex.test(URL)) {
        return true;
    }
    CustomDialogMessageEx('Please provide a valid Date.', 500, 150, true, "Invalid Date");
    return false;

}

function validateFileSize(FileSize, fileSizeBytesLimit) {

    var fileSize = FileSize;
    var isValidFile = false;

    if (fileSize !== 0 && fileSize <= fileSizeBytesLimit) {
        isValidFile = true;
    }

    return isValidFile;
}

hasScroll = function (divnode) {
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
        $(objWindowParent).css("top", 0 + "px");
        $(objWindowParent).css("left", 0 + "px");

        //Esto es para el jodio explorer
        if (navigator.appVersion.indexOf("MSIE 7.") != -1 ||
            navigator.appVersion.indexOf("MSIE 8.") != -1 ||
            navigator.appVersion.indexOf("MSIE 9.") != -1 ||
            navigator.appVersion.indexOf("MSIE 10.") != -1 ||
            navigator.appVersion.indexOf("MSIE 11.") != -1
        ) {
            var objObject = $(".PdfViewer").find("object")[0];
            $(objObject).css("width", "100%");
            $(objObject).css("height", "100%");
        } else {
            //Esto es para todos los navegadores que funcionan correctamente 
            $(".PdfViewer > object > embed").css("width", (AnchoVentana - 5) + "px");
            $(".PdfViewer > object > embed").css("height", (AltoVentana - 170) + "px");
        }

        $(document).scrollTop(600);
        $(document).scrollTop(0);
        $("#btnMaxMin").css("background-image", "url('../../Images/MIN.png')");
        $("#btnMaxMin").attr("alt", "1");
    } else
        //Minimizar
        if ($("#btnMaxMin").attr("alt") == "1") {
            $(objWindowParent).css("width", "1180px");
            $(objWindowParent).css("height", "710px");
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
                $(objObject).css("width", (AnchoVentana - 747) + "px");
                $(objObject).css("height", (AltoVentana - 415) + "px");
            } else {
                //Esto es para todos los navegadores que funcionan correctamente 
                $(".PdfViewer > object > embed").css("width", (AnchoVentana - 747) + "px");
                $(".PdfViewer > object > embed").css("height", (AltoVentana - 415) + "px");
                $(".PdfViewer").css("width", (AnchoVentana - 747) + "px");
                $(".PdfViewer").css("height", (AltoVentana - 415) + "px");
            }
            // $(document).scrollTop(600);
            $("#btnMaxMin").css("background-image", "url('../../Images/MAXIM.png')");
            $("#btnMaxMin").attr("alt", "0");
        }

};

/*
Fin Max Window
*/
MyjConfirm = function (options) {

    jConfirm('Do you wish to proceed with this action/task?', 'Confirmation', function (r) {
        if (r) {
            options.pFunctionOK();
        } else
            options.pFunctionCancel();
    });

    return false;
};

DiscardPreviewPDF = function () {
    $('#hdnShowPreviewPDF').val('false');
    $find('ModalPopupPDFViewer').hide();
};

function redondeo2decimales(numero) {
    var original = parseFloat(numero);

    var result = Math.round(original * 100) / 100;
    return result;
}

function replaceAll(find, replace, str) {
    return str.replace(new RegExp(find, 'g'), replace);
}

AlternateRow = function (gridView) {
    var rows = $(gridView + " > tbody > tr");

    for (var rowIndex = 0; rowIndex <= rows.length - 1; rowIndex++) {
        var mod = (rowIndex % 2);
        if (mod == 0)
            $(rows[rowIndex]).attr("class", "AlternateRow");
    }
};

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

CustomDialogMessageEx = function (msj, pwidth, pheight, isModal, titlex) {

    $("#dvMessage").remove();

    var divToCreate = "<div id='dvMessage'></div>";

    $("body").append(divToCreate);

    var divCreated = $("#dvMessage");
    titles = (titlex == null) ? "Title" : titlex;
    isModal = (isModal == null) ? true : isModal;
    pheight = pheight == null ? 'auto' : pheight;
    pwidth = pwidth == null ? 'auto' : pwidth;

    $(divCreated).dialog({
        title: titles,
        autoOpen: false,
        resizable: true,
        position: { my: "center", at: "center", of: window },
        height: pheight,
        width: pwidth,
        modal: isModal,
        show: { effect: "fadeIn", duration: 260 },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
            }
        },
        create: function () {
            $(".ui-dialog-buttons").css("z-index", "13000");
            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%", "font-family": "Arial, Helvetica, sans-serif" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });

            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");
        },
        close: function () {
            $(divCreated).remove();
        },
        open: function () {

            $(divCreated).html(msj);
            AddPopIframe();
        }
    }).dialog("open");
};

ClosePopupAddCase = function () {
    PopupAddCase.Close();
}

CustomDialogMessage = function (msj) {

    var divToCreate = "<div id='dvMessage'></div>";
    $("body").append(divToCreate);

    var divCreated = $("#dvMessage");

    $(divCreated).dialog({
        autoOpen: false,
        resizable: false,
        height: 200,
        position: { my: "center", at: "center", of: window },
        width: 402,
        modal: true,
        show: { effect: "fadeIn", duration: 260 },
        buttons: {
            "OK": function () {
                $(this).dialog("close");
            }
        },
        create: function () {
            $(".ui-dialog-buttons").css("z-index", "13000");
            //$(".ui-dialog").css("z-index", "13000");
            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });

            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");

        },
        close: function () {
            //$(".ui-dialog").css("z-index", "0");
            $(divCreated).remove();
        },
        open: function () {
            $(".ui-widget-overlay").css("z-index", "99");

            $(divCreated).html(msj);
            AddPopIframe();
        }
    }).dialog("open");
};

DlgConfirmWithFuncCallBack = function (Message, pwidth, pheight, Func, FuncNo) {

    var divToCreate = "<div id='dvConfirmDialog'></div>";

    $("body").append(divToCreate);

    var divCreated = $("#dvConfirmDialog");

    //Botones en Ingles
    var pButtonsEn = {
        "Yes": function () {
            if (Func != null)
                Func();
            $(divCreated).dialog("close");
        },
        "No": function () {
            if (FuncNo != null)
                FuncNo();
            $(divCreated).dialog("close");
        }
    };

    //Botenes en español
    var pButtonsEs = {
        "Si": function () {
            if (Func != null)
                Func();
            $(divCreated).dialog("close");
        },
        "No": function () {
            if (FuncNo != null)
                FuncNo();
            $(divCreated).dialog("close");
        }
    };

    $(divCreated).dialog(
    {
        draggable: true,
        height: pheight == null ? 126 : pheight,
        width: pwidth == null ? 402 : pwidth,
        show: {
            effect: "puff",
            duration: 260
        },
        hide: {
            effect: "puff",
            duration: 260
        },
        buttons: $("#hdnLang").val() == "English" ? pButtonsEn : pButtonsEs,
        title: $("#hdnLang").val() == "English" ? "Confirmation" : "Confirmación",
        autoOpen: false,
        position: { my: "center", at: "center", of: $("body") },
        modal: true,
        open: function () {
            AddPopIframe();
            RelocatePops();
        },
        create: function () {

            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../Content/images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });
            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");
        },
        close: function () {
            $(divCreated).remove();
        }
    }).dialog("open");

    var key = "ActionTaskWarning";

    //Traductor
    //getTranslate(key, function (data) {
    //    var DialogMessage = Message == "" || Message == null ? data.d : Message;
    //    divCreated.html(DialogMessage);
    //});

    return false;
};

DlgConfirm = function (obj, Title, pwidth, pheight) {
    var lang = $("#hdnLang").val();

    var divToCreate = "<div id='dvConfirmDialog'></div>";

    $("body").append(divToCreate);

    var divCreated = $("#dvConfirmDialog");

    var DialogTitle = Title == "" || Title == null ? (lang != "ES" ? "Do you wish to proceed with this action/task?" : "Desea proceder con esta acción/tarea?") : Title;

    divCreated.html(DialogTitle);

    //Botones en Ingles
    var pButtonsEn = {
        "Yes": function () {
            if (!$(obj).is("a"))
                __doPostBack(obj.name, '');
            else {
                BeginRequestHandler();
                eval($(obj).prop("href"));
            }

            $(divCreated).dialog("close");
        },
        "No": function () { $(divCreated).dialog("close"); }
    };

    //Botenes en español
    var pButtonsEs = {
        "Si": function () {
            if (!$(obj).is("a"))
                __doPostBack(obj.name, '');
            else {
                BeginRequestHandler();
                eval($(obj).prop("href"));
            }

            $(divCreated).dialog("close");
        },
        "No": function () { $(divCreated).dialog("close"); }
    };

    $(divCreated).dialog(
    {
        draggable: true,
        height: pheight == null ? 126 : pheight,
        width: pwidth == null ? 402 : pwidth,
        show: { effect: "fadeIn", duration: 260 },
        buttons: lang != "ES" ? pButtonsEn : pButtonsEs,
        title: lang != "ES" ? "Confirmation" : "Confirmacion",
        autoOpen: false,
        position: { my: "center", at: "center", of: window },
        modal: true,
        open: function () {
            AddPopIframe();
        },
        create: function () {
            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": "center", "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });

            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");
        },
        close: function () {
            $(divCreated).remove();
        }
    }).dialog("open");

    return false;
};


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

/*
  Author: Lic. Carlos Ml. Lebron.
  JQuery Popup ahora es un Pluggin de JQuery
*/

(function ($) {
    $.fn.JQueryPopup_pluggin = function (poptions) {

        var options = {
            pdraggable: (poptions.pdraggable == null) ? true : poptions.pdraggable,
            pautoOpen: (poptions.pautoOpen == null) ? false : poptions.pautoOpen,
            presizable: (poptions.presizable == null) ? false : poptions.presizable,
            pmodal: (poptions.pmodal == null) ? true : poptions.pmodal,
            pTitle: (poptions.pTitle) ? options.pTitle : "",
            pShowTitleBar: (poptions.pShowTitleBar || poptions.pShowTitleBar == false) ? poptions.pShowTitleBar : true,
            OnCLose: (poptions.OnCLose == null) ? poptions.OnCLose = function () { } : poptions.OnCLose,
            OnOpen: (poptions.OnOpen == null) ? poptions.OnOpen = function () { } : poptions.OnOpen,
            pwidth: (poptions.pwidth == null) ? "auto" : poptions.pwidth,
            pheight: (poptions.pheight == null) ? "auto" : poptions.pheight,
            peffect: (poptions.peffect == null) ? { effect: "fadeIn", duration: 260 } : {},
            titlePosition: (poptions.titlePosition == null) ? "center" : poptions.titlePosition
        };

        // var options = $.extend(options);

        return this.each(function (options) {
            var $this = $(this);

            //Configurar el Popup
            var popup = ".ui-dialog:has(" + options.ElementIDorClass + ")";

            options.pposition = options.pposition || { my: "center", at: "center", of: window };

            options.pButtons = options.pButtons || {};

            //Remover el popup para inicializarlo nuevamente
            $(popup).remove();

            //Agregar padding 0px y margin 0px al div

            $this.css("padding", "0");
            $this.css("margin", "0");

            $($this).dialog(
            {
                draggable: pdraggable,
                width: pwidth,
                height: pheight,
                closeOnEscape: true,
                show: peffect,
                buttons: pButtons,
                title: pTitle,
                autoOpen: pautoOpen,
                position: pposition,
                resizable: presizable,
                modal: pmodal,
                open: function () {
                    $(".ui-widget-overlay").css("z-index", "99");
                },
                create: function () {
                    OnOpen();
                    $(".ui-dialog-titlebar").css("display", (pShowTitleBar == false) ? "none" : "block");
                    $(".ui-dialog-titlebar > span").css("height", "25px");
                    $(".ui-dialog-titlebar > span").css("line-height", "24px");
                    $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": titlePosition, "width": "100%" });
                    $(".ui-dialog-titlebar > button").css("background", "transparent");
                    $(".ui-button-icon-primary").css("display", "none");
                    $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
                    $(".ui-dialog-titlebar > button").css("border", "0");
                    $(".ui-dialog-titlebar > button").mouseover(function () {
                        $(this).removeClass("ui-state-hover");
                    });
                    $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
                    $(".ui-dialog-titlebar").addClass("HeaderPopup");

                    AddPopIframe();
                },
                beforeClose: OnCLose,
                close: function () {
                    $(this).dialog("close");
                }
            }).parent().appendTo(jQuery("form:first"));

            this.Open = function () {
                $(".ui-widget-overlay").css("z-index", "1");
                //$(".ui-button-icon-primary").css("background-image", "url('../images/close_pop_up.png')");
                $($this).dialog("open");
            };

            this.Close = function () {
                $($this).dialog("close");
            };

            this.setTitle = function (ptitle) {
                $($this).dialog({ title: ptitle });
            };
        });
    };
})(jQuery);

/*    
  JQuery Popup es una Objeto que crea un dialog de JQuery UI
*/

function isEmail(Email) {
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (!filter.test(Email))
        return false;
    else
        return true;
}

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
    options.pmodal = (options.pmodal == null) ? true : options.pmodal;
    options.pTitle = (options.pTitle) ? options.pTitle : "";
    options.pShowTitleBar = (options.pShowTitleBar || options.pShowTitleBar == false) ? options.pShowTitleBar : true;
    options.OnCLose = (options.OnCLose == null) ? options.OnCLose = function () { } : options.OnCLose;
    options.OnOpen = (options.OnOpen == null) ? options.OnOpen = function () { } : options.OnOpen;
    options.pwidth = (options.pwidth == null) ? "auto" : options.pwidth;
    options.pheight = (options.pheight == null) ? "auto" : options.pheight;
    options.peffect = (options.peffect == null) ? { effect: "fadeIn", duration: 260 } : {};
    options.titlePosition = (options.titlePosition == null) ? "center" : options.titlePosition

    $(options.ElementIDorClass).dialog(
    {
        draggable: options.pdraggable,
        width: options.pwidth,
        height: options.pheight,
        closeOnEscape: true,
        //show: options.peffect,
        buttons: options.pButtons,
        title: options.pTitle,
        autoOpen: options.pautoOpen,
        position: options.pposition,
        resizable: options.presizable,
        modal: options.pmodal,
        open: function () {
            $(".ui-widget-overlay").css("z-index", "99");
        },
        create: function () {
            options.OnOpen();
            $(".ui-dialog-titlebar").css("display", (options.pShowTitleBar == false) ? "none" : "block");
            $(".ui-dialog-titlebar > span").css("height", "25px");
            $(".ui-dialog-titlebar > span").css("line-height", "24px");
            $(".ui-dialog-titlebar > span").css({ "color": "white", "text-align": options.titlePosition, "width": "100%" });
            $(".ui-dialog-titlebar > button").css("background", "transparent");
            $(".ui-button-icon-primary").css("display", "none");
            $(".ui-dialog-titlebar > button").css("background-image", "url('../../images/close_pop_up.png')");
            $(".ui-dialog-titlebar > button").css("border", "0");
            $(".ui-dialog-titlebar > button").mouseover(function () {
                $(this).removeClass("ui-state-hover");
            });
            $(".ui-dialog-titlebar > button").css({ "width": "24px", "height": "24px" });
            $(".ui-dialog-titlebar").addClass("HeaderPopup");

            AddPopIframe();
        },
        beforeClose: options.OnCLose,
        close: function () {
            $(this).dialog("close");
        }
    }).parent().appendTo(jQuery("form:first"));

    this.Open = function () {
        $(".ui-widget-overlay").css("z-index", "1");
        //$(".ui-button-icon-primary").css("background-image", "url('../images/close_pop_up.png')");
        $(options.ElementIDorClass).dialog("open");
    };

    this.Close = function () {
        $(options.ElementIDorClass).dialog("close");
    };

    this.setTitle = function (ptitle) {
        $(options.ElementIDorClass).dialog({ title: ptitle });
    };
};
/* Fin JQuery Popup */

ShowToolTipMessage = function (element, pcontent, pposition, ptitle, ptheme) {

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

CustomToolTips = function (elementIdOrClass, message, pposition, pduration) {
    //var theme = 'ui-sunny';
    var theme = 'black';

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

$$ = function (ElementIDOrClass, pheight, pwidth, ListOfValueType, Pk) {
    $(ElementIDOrClass).click(function () {
        ListOfValuePopup(ElementIDOrClass, pheight, pwidth, ListOfValueType, Pk);
    });
};

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

function SelectAll(chk, gridName) {

    $(gridName).find("input:checkbox").each(function () {
        if ($(this).attr("disabled") != "disabled")
            this.checked = chk.checked;
    });

    var ch = document.getElementsByName(chk.name);
    ch.checked = true;
}

setClickCheckBoxGridView = function (GridView, objSelectAll) {
    $(GridView).find("input:checkbox").each(function () {
        if ($(this).attr("id") != objSelectAll.replace("#", "")) {
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
        }

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


//Obtiene un elemento basado en el Id, la Clase y El tipo, esto sirve para identificar un elemento cuando se utilize el mismo UserControl mas de una vez en la misma pagina.
function GetElementByClassAndId(Id, Class, Type) {
    var arrayFile = new Array();

    $(Type).each(function () {
        if ($(this).attr("id") == Id) {
            arrayFile.push($(this));
        }
    });

    var Element = null;

    for (var x = 0; x <= arrayFile.length; x++) {
        if ($(arrayFile[x]).hasClass(Class)) {
            Element = $(arrayFile[x]);
            break;
        }
    }

    return Element;
}

//Obtiene una lista de elementos basado en el Id, la Clase y el Tipo, el Id funciona con Contains.
function GetArrayByClassAndIdLike(Id, Class, Type) {
    var arrayFile = new Array();

    var FullType2 = Type + "[id*='" + Id + "']";

    $(FullType2).each(function () {

        if ($(this).parent().hasClass(Class)) {
            arrayFile.push($(this));
        }
    });

    return arrayFile;
}

function ValidateEmail() {

    var Domain = $get('ddlDomain').options[$get('ddlDomain').selectedIndex].text;
    var Email = $get('txtEmail').value + Domain;

    if (!isEmail(Email)) {
        CustomDialogMessage('Please provide a valid email address');
        $get('txtEmail').focus;
        return false;
    }
    else {
        return true;
    }
}

function ValidateEmail(Email) {
    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

    if (filter.test(Email))
        return true;

    CustomDialogMessageEx('Please provide a valid Email.', 500, 150, true, "Invalid Email Address");
    return false;
}

function RelocatePops() {
    $(".ui-dialog-content:visible").dialog({ position: { my: "center", at: "center", of: window } });
}

  function getLabelField (obj) {
    var result = null;
    var labelObj = $(obj).attr("label");

    if (labelObj == null) {
        var Parents = obj.parents();

        Parents.each(function () {

            var label = label = $(this).find("span:first");

            if (label.length > 0) {
                result = label.text();
                return false;
            }
        });
    } else
        result = labelObj;

    return result;
}