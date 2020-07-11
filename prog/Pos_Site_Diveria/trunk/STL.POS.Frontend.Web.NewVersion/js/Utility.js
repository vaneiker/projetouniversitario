﻿var divLoading = '<div class="loading"></div>';
//var divImageLoading = '<div id="loading2Image" class="loading" style="display: none;z-index: 99999999;"> <iframe src="about:blank" style="border:none; top: 0; left: 0; height:100%; width:100%; z-index:-1; position: absolute;"/></div> ';

BeginRequestHandler = function (sender, args) {
    //$("main").addClass("loading");

    $(".loading").remove();

    $("body").append(divLoading);

    //$("body").append(divImageLoading);
    //$("#loading2Image").addClass("loading");
    //$("#loading2Image").css("display", "block");
};

EndRequestHandler = function (sender, args) {
    //$("main").removeClass('loading');
    //$("#loading2Image,.loading").remove();
    $(".loading").remove();
};

function altFind(arr, callback) {
    for (var i = 0; i < arr.length; i++) {
        var match = callback(arr[i]);
        if (match) {
            return arr[i];
            break;
        }
    }
}

function replaceAll(find, replace, str) {
    var result;
    try {
        result = str.replace(new RegExp(find, 'g'), replace);
    } catch (e) {

    }
    return result;
}

function RenderScript(Urls) {
    for (var i = 0; i < Urls.length; i++) {
        $.getScript(Urls[i], function (data, estado) {
            if (estado != 'success')
                console.log("Error al cargar la librería");
        });
    }
}

function number_format(amount, decimals) {

    amount += ''; // por si pasan un numero en vez de un string
    amount = parseFloat(amount.replace(/[^0-9\.]/g, '')); // elimino cualquier cosa que no sea numero o punto

    decimals = decimals || 0; // por si la variable no fue fue pasada

    // si no es un numero o es igual a cero retorno el mismo cero
    if (isNaN(amount) || amount === 0)
        return parseFloat(0).toFixed(decimals);

    // si es mayor o menor que cero retorno el valor formateado como numero
    amount = '' + amount.toFixed(decimals);

    var amount_parts = amount.split('.'),
        regexp = /(\d+)(\d{3})/;

    while (regexp.test(amount_parts[0]))
        amount_parts[0] = amount_parts[0].replace(regexp, '$1' + ',' + '$2');

    return amount_parts.join('.');
}

function getNewDateYear(date) {
    var result = new Date(date);
    var yearOnDays = 365;
    result.setDate(result.getDate() + yearOnDays);
    return result;
}

function getCorrectDateFormat(value) {
    var makeDate = "";

    if (value !== "") {

        var spl = value.replace('.', '').split('-');
        if (spl.length > 1) {
            var monthEsPosition = getAbrevMonthOfDate(spl[1].toLowerCase());
            makeDate = monthEsPosition + '/' + spl[0] + '/' + spl[2];
        }
    }
    return makeDate;
}

function getAbrevMonthOfDate(montAbrev) {

    var monthNamesEn = ["jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec"];
    var monthNamesEs = ["ene", "feb", "mar", "abr", "may", "jun", "jul", "ago", "sep", "oct", "nov", "dic"];

    if (monthNamesEn.indexOf(montAbrev.replace('.', '')) != -1) {
        //return monthNamesEn[monthNamesEs.indexOf(montAbrev)]
        return monthNamesEn[monthNamesEn.indexOf(montAbrev)]
    }
    return "";
}


/*****************************************************************/
/************************* FIX HEIGHT ****************************/
/********** Altos iguales para todos los elementos ***************/
/*********** que contengan la clase "fix_height" *****************/
/*****************************************************************/
equalheight = function (container) {

    var currentTallest = 0,
        currentRowStart = 0,
        rowDivs = new Array(),
        $el,
        topPosition = 0;
    $(container).each(function () {

        $el = $(this);
        $el.height('auto');
        topPostion = $el.position().top;

        if (currentRowStart != topPostion) {
            for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
                rowDivs[currentDiv].height(currentTallest);
            }
            rowDivs.length = 0; // empty the array
            currentRowStart = topPostion;
            currentTallest = $el.height();
            rowDivs.push($el);
        } else {
            rowDivs.push($el);
            currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
        }
        for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
            rowDivs[currentDiv].height(currentTallest);
        }
    });
}

function fixheight() {
    equalheight('.fix_height');//siempre que la cantidad de columnas sean las mismas en todos los pisos
    equalheight('.fix_height1');//si varian de un piso a otro, ej arriba tengo 2 abajo 3 abajo debo llamar fix_height1 etc
    equalheight('.fix_height2');
    equalheight('.fix_height3');
    equalheight('.fix_height4');
}



//function listProductsNotShow(appMode) {

    
//    var arrProds = [];
//    arrProds.push("DE LEY");
//    arrProds.push("ULTRA");
//    arrProds.push("DECLARATIVA");
//    arrProds.push("AUTO EXCESO");
//    arrProds.push("DECLARATIVA");
//    arrProds.push("PERDIDA TOTAL");
//    arrProds.push("Total Fijo");


//    return arrProds;

//}


function validLengthPhone(phonenumber) {

    var PhoneNumberLength = 11;

    if (phonenumber) {

        var realPhoneNumber = phonenumber.replace(/-/g, '').replace(/_/g, '');
        if (realPhoneNumber)
        {
            return (realPhoneNumber.length == PhoneNumberLength);
        }
    }


    return false;
}