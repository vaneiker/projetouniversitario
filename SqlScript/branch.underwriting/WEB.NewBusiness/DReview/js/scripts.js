window.onerror = function (errorMsg, url, lineNumber, column, errorObj) {
    /* if (errorMsg == "Uncaught TypeError: Cannot read property 'style' of null" ||
         errorMsg == "TypeError: contentElement is null" ||
         errorMsg == "Unable to get property 'style' of undefined or null reference")
     return false;
 
     CustomDialogMessageEx('Error: ' + errorMsg, 500, 200, true, "Error");
     */
}

divScroll = function () {
    $("#dvScroll").scroll(function () {
        try {

            //Posicion de los DatePickers
            if ($("#CurrentDatePickerShow").val() != "") {
                var objP = $("#ui-datepicker-div");
                var objR = $($("#CurrentDatePickerShow").val().split(",")[0]);
                var offset = objR.offset();
                var ArribaOrAbajo = $("#CurrentDatePickerShow").val().split(",")[1];
                if (ArribaOrAbajo == "AR") {
                    var TopArriba = parseInt(objP.css("height").replace("px", ""));
                    $(objP).offset({ top: offset.top - TopArriba, left: offset.left });
                } if (ArribaOrAbajo == "AB") {
                    var TopAbajo = parseInt(objR.css("height").replace("px", ""));
                    $(objP).offset({ top: offset.top + TopAbajo, left: offset.left });
                }
            }
            //End Posicion de los DatePickers
            $("#hdnPosScroll").val($(this).scrollTop());
        } catch (e) {
            console.log(e.message);
        }
    });
};

/**
* Determine the mobile operating system.
* This function either returns 'iOS', 'Android' or 'unknown'
*
* @returns {String}
*/
function getMobileOperatingSystem() {
    var userAgent = navigator.userAgent || navigator.vendor || window.opera;
    if (userAgent.match(/iPad/i) || userAgent.match(/iPhone/i) || userAgent.match(/iPod/i))
        return 'iOS';
    else if (userAgent.match(/Android/i))
        return 'Android';
    else
        return 'unknown';
}

setPositionElementDatePicker = function (ObjPosition, ObjRelation) {
    setTimeout(function () {
        var objP = $(ObjPosition);
        var objR = $(ObjRelation);
        $('body').prepend(objP);
        var offset = objR.offset();
        var Top = parseInt($(objP).css("height").replace("px", ""));
        $(objP).offset({ top: offset.top - Top, left: offset.left });
    }, 10);
};

var ObjAcordeon = "#ulAvaliableDashboard,#STFCUserProfile1_acordeon_agent_profile,#accAddress,#acc1,#accordeonEforms,#acordeon_agent_profile, #acc2,#acc3, #acc4, #acc5, #acc6,#accBeneficiaries,#ClientInfo";

Notify = function (sender) {
    var span = $(sender).find("span")[1];

    var msj = "";
    if (span != null)
        msj = $(span).html();
    else
        msj = $(sender).html();

    CustomDialogMessageEx(msj + " tab is disabled", 350, null, true, "Warning");
};

setIconDatePicker = function () {
    $("body").find("table").find("td.dxeButton").find("img:first").addClass("datepicker_02");
}

Configutations = function () {
    var CurrentMenu = $("#hdnCurrentMenuSelectedMenuLeft").val();

    if (CurrentMenu != null & CurrentMenu != "") {
        $("#Menu >li > a").removeClass("activo");
        $("#" + CurrentMenu).addClass("activo");
    }

    setAccordeaons();
    //Setear el lenguaje de la application
    setLanguage();

    $("body").find("table").find("td.dxeButton").css("width", "20%");
    setIconDatePicker();

    $('.dxWeb_pcCloseButton_DevEx').hide();

    $("[data-inputmask]").inputmask();

    $("[number = 'number4']").inputmask({ alias: 'integer', autoGroup: false, digits: 0, allowMinus: false, allowPlus: false, rightAlign: false });

    $("[number = 'number3']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 3, digits: 0, allowMinus: false, allowPlus: false });

    $("[number = 'number2']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 2, digits: 0, allowMinus: false, allowPlus: false });

    $("[number = 'number']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 0, allowMinus: false, allowPlus: false });

    $("[decimal='decimal']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 2, allowMinus: false, allowPlus: false, rightAlign: true });

    $("[decimalWithsign='decimalWithsign']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 2, allowMinus: true, allowPlus: false, rightAlign: true });

    $("[decimal='decimal3']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 3, digits: 2, allowMinus: false, allowPlus: false, rightAlign: true });

    $("[Policy='Policy']").attr('data-inputmask-regex', "[0-9A-Za-z-\\sñÑ]*");

    $("[alphabetical='alphabetical']").attr('data-inputmask-regex', "[A-Za-z.\\sñÑáéíóúÁÉÍÓÚ']*");

    $("[alphabetical='alphabeticalLastName']").attr('data-inputmask-regex', "[A-Za-z.'-\\sñÑáéíóúÁÉÍÓÚ']*");

    $("[alphabetical='alphabetical']").inputmask("Regex");
    $("[Policy = 'Policy']").inputmask("Regex");
    $("[alphabetical='alphabeticalLastName']").inputmask("Regex");

    $("#tb_WUC_PI_Age").setMask("age");

    //var CurrentTab = $("#hdnCurrentTab").val();

    //if (CurrentTab == "btnQuestionaries")
    //    setInterval("fixheight();", 500);    

    $("select").each(function () {
        if ($(this).attr("Policy") == null)
            $(this).attr('onkeydown', 'return (event.keyCode!=8 && event.keyCode!=13)');
        else
            $(this).attr('onkeydown', 'return (event.keyCode!=8)');
    });


    $("input:text").each(function () {
        var $this = $(this);
        var AllowEnter = ($this.attr('AllowEnter') != null && $this.attr('AllowEnter') == "true");

        if (!AllowEnter) {
            if ($this.attr("Policy") == null) {
                var decimal = $this.attr("decimal");
                var number = $this.attr("number");
                if (decimal == null && number == null && !$this.hasClass("dxeEditArea_DevEx"))
                    $this.attr('onkeydown', 'return (event.keyCode!=13)');
            }
        }
    });

    $("input:text[readonly='readonly']").attr('onkeydown', 'return (event.keyCode!=8 && event.keyCode!=13)');

    if ($('#hdnLangChange').val() == "true") {
        //Seleccionar todos los valores que estaban en los drops
        var objects = JSON.parse($("#hdnDropsValues").val());

        for (var x = 0; x < objects.length; x++) {
            var $this = objects[x];
            var DropId = '#' + replaceAll(' ', '_', $this.IdDrop);
            $(DropId).val($this.value);
        }

        $('#hdnLangChange').val("false");
    }

};

validateFilter = function () {
    var result = true;
    var FromTxt = $("#FromTxt").val();
    var ToTxt = $("#ToTxt").val();

    if (FromTxt != "" || ToTxt != "") {
        if (FromTxt == "" || ToTxt == "") {
            result = false;
            CustomDialogMessageEx(null, 350, 150, true, $("#hdnLang").val() == "en" ? 'Warning' : 'Advertencia', 'DateRangeValidation');
        }
    }

    return result;
};

CorfimRedirect = function (sender) {
    if ($(sender).attr("alt") == "Disabled")
        return false;
    var CurrentMenu = $("#hdnCurrentMenuSelectedMenuLeft").val();
    if (CurrentMenu == "MenulnkClientInfo") {
        var lang = $("#hdnLang").val();
        var msj = lang == "en" ? "The data that you edit or insert will be lose. Do you want go out of this page?"
                                  :
                                  "Los datos que se han editado o capturado van a perderse. Esta seguro que desea abandonar la pagina?";
        return DlgConfirm(sender, msj);
    } else BeginRequestHandler();
};

showAlert = function (msg) {
    CustomDialogMessage(msg);
};

function showCommonLoading() {
    BeginRequestHandler();
}

function hideCommonLoading() {
    EndRequestHandler();
}

function commonAlert(val) {
    CustomDialogMessage(val, null);
}

RemenberSelectionDropDowns = function () {
    var ArrayObjects = [];
    $("body").find("select").each(function () {
        var $this = $(this);
        var ObjectDrops = {};
        if ($this.val() != "" || $this.val() == undefined) {
            ObjectDrops.IdDrop = $this.attr("id");
            ObjectDrops.value = $this.val();
            ArrayObjects.push(ObjectDrops);
        }
    });

    var jsonResult = JSON.stringify(ArrayObjects);
    $("#hdnDropsValues").val(jsonResult);
};

changeLanguage = function (lang) {
    $("#hdnLang").val(lang);
    BeginRequestHandler();
    RemenberSelectionDropDowns();
    setTimeout(function () { PostBack(); }, 100);
};

function PostBack() {
    var CurrentTab = $("#hdnCurrentTab").val();        
    if (CurrentTab != null && CurrentTab == "btnBeneficiaries") {
        $("#hdnPendingRefreshBeneficiariesTab").val("false");
        $("#hdnRefreshBeneficiariesTab").val("true");
        $("#btnRefresh").click();
    }
    else {
        $("#hdnPendingRefreshBeneficiariesTab").val("true");
        __doPostBack();
    }
}

setLanguage = function () {
    var dvIdiomas = $("#divLanguage");
    var idioma = $("#hdnLang").val();
    dvIdiomas.removeAttr("class").addClass("idiomas").addClass(idioma);
    var text = dvIdiomas.find("ul > li[class~='" + (idioma) + "']").html();
    var label = dvIdiomas.find("label")[0];
    $(label).html(text).removeAttr("class");
    $(label).addClass(idioma);
};

$(document).ready(function () {

    $(window).resize(function () {
        $(".ui-dialog-content:visible").dialog({ position: { my: "center", at: "center", of: window } });
    });

    $("body").find("a[alt='Disabled']").each(function () {
        $(this).click(function () {
            CustomDialogMessageEx($(this).html() + "tab is disabled", 350, null, true, "Warning");
            EndRequestHandler();
            return false;
        });
    });

    // Scripts
    //************************************//
    /*	
        Funciones usadas para mejorar 
        compatibilidad, estetica y apariencia
        en los distos browsers
    */

    /*****************************************************************/
    /********************** DETECTA NAVEGADOR ************************/
    /*****************************************************************/
    var browser = {
        chrome: false,
        mozilla: false,
        opera: false,
        msie: false,
        safari: false
    };

    var sUsrAg = navigator.userAgent;
    if (sUsrAg.indexOf("Chrome") > -1) {
        browser.chrome = true;
    } else if (sUsrAg.indexOf("Safari") > -1) {
        getWidth();
    } else if (sUsrAg.indexOf("Opera") > -1) {
        getWidth();
    } else if (sUsrAg.indexOf("Firefox") > -1) {
        getWidth();
    } else if (sUsrAg.indexOf("MSIE") > -1) {
        getWidth();
    }

    /*****************************************************************/
    /*********************** MENU SUPERIOR ***************************/
    /*****************************************************************/

    //  The function to change the class
    var changeClass = function (r, className1, className2) {
        var regex = new RegExp("(?:^|\\s+)" + className1 + "(?:\\s+|)");
        if (regex.test(r.className)) {
            r.className = r.className.replace(regex, ' ' + className2 + ' ');
        }
        else {
            r.className = r.className.replace(new RegExp("(?:^|\\s+)" + className2 + "(?:\\s+|)"), ' ' + className1 + ' ');
        }
        return r.className;
    };

    //  afecta menu para pantallas mas pequenas
    var menuElements = document.getElementById('menu');
    menuElements.insertAdjacentHTML('afterBegin', '<button type="button" id="menutoggle" class="navtoogle" aria-hidden="true"><i aria-hidden="true" class="icon-menu"> </i> Menu</button>');

    //  Toggle the class on click to show / hide the menu
    document.getElementById('menutoggle').onclick = function () {
        changeClass(this, 'navtoogle active', 'navtoogle');
    }
    document.onclick = function (e) {
        var mobileButton = document.getElementById('menutoggle'),
            buttonStyle = mobileButton.currentStyle ? mobileButton.currentStyle.display : getComputedStyle(mobileButton, null).display;

        if (buttonStyle === 'block' && e.target !== mobileButton && new RegExp(' ' + 'active' + ' ').test(' ' + mobileButton.className + ' ')) {
            changeClass(mobileButton, 'navtoogle active', 'navtoogle');
        }
    }

    $(window).load(function () {
        equalheight('.fix_height');//siempre que la cantidad de columnas sean las mismas en todos los pisos
        equalheight('.fix_height1');//si varian de un piso a otro, ej arriba tengo 2 abajo 3 abajo debo llamar fix_height1 etc
        equalheight('.fix_height2');
        equalheight('.fix_height3');
        equalheight('.fix_height4');

    });

    $(window).resize(function () {
        equalheight('.fix_height');
        equalheight('.fix_height1');
        equalheight('.fix_height2');
        equalheight('.fix_height3');
        equalheight('.fix_height4');

    });

    $('.refresh_height').on('change', function () {
        equalheight('.fix_height');
        equalheight('.fix_height1');
        equalheight('.fix_height2');
        equalheight('.fix_height3');
        equalheight('.fix_height4');
    });

    $('.checkbox_left').on('change', '.refresh_height', function () {
        equalheight('.fix_height');
        equalheight('.fix_height1');
        equalheight('.fix_height2');
        equalheight('.fix_height3');
        equalheight('.fix_height4');
    });

    /*****************************************************************/
    /********************* RESPONSIVE TABS ***************************/
    /*****************************************************************/


    if ($('div#mySliderTabs').length != 0) {
        var slider = $("div#mySliderTabs").sliderTabs({
            autoplay: false,
            mousewheel: false,
            position: "top"
        });
    }

    /*****************************************************************/
    /************************ NICE SCROLL ****************************/
    /****** SCROLL PERSONALIZADO QUE SALE EN EL PERFIL DEL AGENTE ****/
    /*****************************************************************/

    var nice = $("").niceScroll();  // The document page (body)

    $("#div1").html($("#div1").html() + ' ' + nice.version);

    $("#scroll_1").niceScroll({ cursorborder: "", cursorcolor: "#8D8D8E", boxzoom: false }); // First scrollable DIV	


    /*****************************************************************/
    /************************* EDIT PROFILE **************************/
    /*****************************************************************/


    // ~ .content_tabs input[type="text"], .tabs input.tab-selector-6:checked ~ .content_tabs select, .tabs input.tab-selector-6:checked ~ .content_tabs textarea 


});

setOccupationAutoComplete = function () {
    $("#txtOccupation").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../SearchMethods.asmx/GetOccupation",
                data: JSON.stringify({ description: $.trim($("#txtOccupation").val()), _LanguageId: $("#hdnLang").val() }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    $("#txtOccupation").css("background-repeat", "no-repeat");
                    $("#txtOccupation").css("background-position", "right");
                    $("#txtOccupation").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.description,
                            id: item.value,
                            descGroup: item.OccupationGroupDesc,
                            GroupId: item.OccupationGroupId
                        };
                    }));

                    $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                    $("#txtOccupation").css("background-image", "");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            $("#txtProfession").val(ui.item.descGroup);
            $("#hdnOccupationId").val(ui.item.id);
            $("#hdnOccupationGroupId").val(ui.item.GroupId);
        },
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    }).on('keyup', function (event) {
        //Limpiar los campos
        if (event.which != 13 && event.which != 37 && event.which != 39 && event.which != 40 && event.which != 38) {
            $("#txtProfession").val("");
            changeBorderColor($("#txtProfession"));
        }
    });
};

setOccupationTypeAutoComplete = function () {
    $("#txtProfession").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../SearchMethods.asmx/GetOccupationType",
                data: JSON.stringify({ description: $.trim($("#txtProfession").val()) }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    $("#txtProfession").css("background-repeat", "no-repeat");
                    $("#txtProfession").css("background-position", "right");
                    $("#txtProfession").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.description,
                            id: item.value
                        };
                    }));

                    $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                    $("#txtProfession").css("background-image", "");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 1,
        select: function (event, ui) {
            if ($("#ddl_WUC_PI_Profession") != null)
                $("#ddl_WUC_PI_Profession").val(ui.item.id).change();

            if ($("#ddlProfession") != null)
                $("#ddlProfession").val(ui.item.id).change();

            if ($("#ddlOccupationTpye") != null)
                $("#ddlOccupationTpye").val(ui.item.id).change();


        },
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    }).on('keyup', function (event) {
        //Limpiar los campos
        if (event.which != 13 && event.which != 37 && event.which != 39 && event.which != 40 && event.which != 38) {
            if ($("#ddl_WUC_PI_Occupation") != null)
                $("#ddl_WUC_PI_Occupation option").remove();

            if ($("#ddlOccupation") != null)
                $("#ddlOccupation option").remove();

            changeBorderColor($("#txtProfession"));
        }
    });
};


setPositionnAutoComplete = function () {
    $("#txtPosition").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../SearchMethods.asmx/GetOccupation",
                data: JSON.stringify({
                    description: $.trim($("#txtPosition").val()), _LanguageId: $("#hdnLang").val()
                }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    $("#txtPosition").css("background-repeat", "no-repeat");
                    $("#txtPosition").css("background-position", "right");
                    $("#txtPosition").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.description,
                            id: item.value,
                            descGroup: item.OccupationGroupDesc,
                            GroupId: item.OccupationGroupId
                        };
                    }));
                    console.log('Voy a quitar el back');
                    $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                    $("#txtPosition").css("background-image", "");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 1,
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    });
};

setPositionnAutoCompleteDesignated = function () {
    $("#txtPosition_Designated").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../SearchMethods.asmx/GetOccupation",
                data: JSON.stringify({
                    description: $.trim($("#txtPosition_Designated").val()), _LanguageId: $("#hdnLang").val()
                }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    $("#txtPosition_Designated").css("background-repeat", "no-repeat");
                    $("#txtPosition_Designated").css("background-position", "right");
                    $("#txtPosition_Designated").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.description,
                            id: item.value,
                            descGroup: item.OccupationGroupDesc,
                            GroupId: item.OccupationGroupId
                        };
                    }));

                    $(".ui-autocomplete").css({ "height": "200px", "overflow-y": "scroll", "overflow-x": "hidden" });
                    $("#txtPosition_Designated").css("background-image", "");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 1,
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    });
};


//Autocomplete para el ABA number
setABAautoComplete = function () {
    $("#txtABANumber").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "../../SearchMethods.asmx/GetBankABANumber",
                data: JSON.stringify({ abaNumber: $.trim($("#txtABANumber").val()) }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    $("#txtABANumber").css("background-repeat", "no-repeat");
                    $("#txtABANumber").css("background-position", "right");
                    $("#txtABANumber").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data.d, function (item) {
                        return {
                            label: item.AbaNumber,
                            id: item.BankDesc
                        };
                    }));

                    $(".ui-autocomplete").css({ "height": "285px", "overflow-y": "scroll", "overflow-x": "hidden" });
                    $("#txtABANumber").css("background-image", "");
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
            $("#txtBankName").val(ui.item.id);
            changeBorderColor($("#txtBankName"));
        },
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    }).on('keyup', function (event) {
        //Limpiar los campos
        if (event.which != 13 && event.which != 37 && event.which != 39 && event.which != 40 && event.which != 38) {
            $("#txtBankName").val("");
            changeBorderColor($("#txtBankName"));
        }
    });

};

/*****************************************************************/
/*************************** FUNCIONES ***************************/
/*****************************************************************/

function getWidth() {

    $('fieldset .details_grid').width(($('.content_fondo_blanco').width() - 20))

    $(window).resize(function () {
        //console.log($( window ).width());
        $('fieldset .details_grid').width(($('.content_fondo_blanco').width() - 20))
    });
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
        $($el).height('auto')
        topPostion = $el.position().top;

        if (currentRowStart != topPostion) {
            for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
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

        for (currentDiv = 0 ; currentDiv < rowDivs.length ; currentDiv++) {
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

/*****************************************************************/
/************************ ACCORDION ****************************/
/*****************************************************************/

$("html").addClass("js");


function setAccordeaons() {
    $.fn.accordion.defaults.container = false;
    $(ObjAcordeon).accordion({
        initShow: "#current",
        collapsible: true
    });
}
/*****************************************************************/
/************************ DATE PICKER ****************************/
/*****************************************************************/

SetDatePicker = function () {

    $(".datepicker").datepicker({
        defaultDate: $("#hdnGetDate").val(),
        changeMonth: true,
        changeYear: true,
        yearRange: "c-10:c+50",
        onSelect: function (selectedDate) {
            changeBorderColor(this);
            CallExecuteOnCloseEvent(this, selectedDate);
        },
        onClose: function (selectedDate) {
            CallExecuteOnCloseEvent(this, selectedDate);
            changeBorderColor(this);
        },
        beforeShow: function () {
            SavePosDatePicker(this);
        }
    }).each(function () {
        //if (!$(this).prop("disabled"))
        $(this).inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy", "clearIncomplete": true });

        if (this.getAttribute("date") == "birth")
            $(this).datepicker("option", "maxDate", "0");

        if (this.getAttribute("maxDate") != "") {
            var maxDate = this.getAttribute("maxDate");
            $(this).datepicker("option", "maxDate", maxDate);
            $(this).datepicker("option", "defaultDate", maxDate);
        }
    });
};

SavePosDatePicker = function (Sender) {
    var Obj = $(Sender);
    setTimeout(function () {
        var datePickerTop = $("#ui-datepicker-div").offset().top;

        var inputTop = $(Obj).offset().top;

        var AbajoOrArriba = (datePickerTop > inputTop) ? "AB" : "AR";

        $("#CurrentDatePickerShow").val("#" + $(Obj).attr("id") + "," + AbajoOrArriba);
    }, 40);
}

setCurrentAccordeonForIndex = function (hiddenfield) {
    if ($(hiddenfield).val() != "" & $(hiddenfield).val() != null) {
        var divActiveAccordeon = $(hiddenfield).val().split("|")[0];
        var ActiveAccordeonIndex = $(hiddenfield).val().split("|")[1];
        var lnk = $("#" + divActiveAccordeon + " > li").find("a[lnk='lnk']");
        $(lnk).attr("id", "");
        $(lnk[ActiveAccordeonIndex]).addClass("shown").addClass("open").attr("id", "current");
    }

    $(ObjAcordeon).accordion({ initShow: "#current" });
};

setCurrentAccordeon = function (obj, hiddenfield) {
    var index = 0;
    var isOpen = $(obj).parent().find("ul:first").css("display") == "block";

    if (!isOpen) {
        $($(obj).parents()[1]).find("li").find("a[lnk='lnk']").removeAttr("alt");

        //Marcar el Objeto como abierto
        $(obj).attr("alt", "Open");

        var hrefArray = $($(obj).parents()[1]).find("li").find("a[lnk='lnk']");

        var divParent = $($(obj).parents()[1]).attr("id");

        for (var x = 0; x <= hrefArray.length - 1; x++) {
            if ($(hrefArray[x]).attr("alt") == "Open") {
                $(hiddenfield).val(divParent + "|" + x);
                break;
            }
        }
    }
                                                          
    var intervalo = setInterval(fixheight, 100);
    setTimeout(function () { clearInterval(intervalo) }, 400);
};

function validateDateRange(FromTxt, Totxt, sender) {
    var lang = $("#hdnLang").val();
    if (FromTxt.length > 0 && Totxt.length > 0) {
        if (FromTxt.val() != "" && Totxt.val() != "") {

            var DateFrom = FromTxt.val().ToDate("mm/dd/yyyy");
            var DateTo = Totxt.val().ToDate("mm/dd/yyyy");
            if (DateTo < DateFrom) {
                $(sender).val("");
                $(sender).focus();
                var message = lang == "en" ? "The deadline can not be less than the initial date" : "La fecha final no puede ser menor que la fecha inicial";
                CustomDialogMessageEx(message, null, null, true, lang == "en" ? "Warning" : "Advertencia");
                return false;
            }
        }
    }
}

getTranslate = function (key, success) {
    $.ajax({
        url: "../../SearchMethods.asmx/GetTranslate",
        data: JSON.stringify({ key: $.trim(key), lang: $.trim($("#hdnLang").val()) }),
        dataType: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataFilter: function (data) { return data; },
        beforeSend: function () {

        },
        success: success,
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr);
            //CustomDialogMessage(xhr.responseText);
        }
    });
};