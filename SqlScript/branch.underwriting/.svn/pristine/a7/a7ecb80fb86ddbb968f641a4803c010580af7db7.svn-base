// Scripts
//************************************//
/*	
	Funciones usadas para mejorar 
	compatibilidad, estetica y apariencia
	en los distos browsers
*/
function ConfigSystem(){
    $(function () {

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

        /*****************************************************************/
        /************************ ACCORDION ****************************/
        /*****************************************************************/

        $("html").addClass("js");
        $.fn.accordion.defaults.container = false;
        $(function () {
            $("#acordeon_agent_profile, #acc1, #acc2, #acc3, #acc4, #acc5, #acc6").accordion({ initShow: "#current" });
        });


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
        /************************ DATE PICKER ****************************/
        /*****************************************************************/

        $("input.datepicker").datepicker({
            changeMonth: true,
            changeYear: true,
        }
        );
        $("#from, #from2, #from3, #from4, #from5, #from6").datepicker({
            defaultDate: "+1w",
            changeMonth: true,
            changeYear: true,
            onClose: function (selectedDate) {
                $("#to, #to2, #to3, #to4, #to5, #to6").datepicker("option", "minDate", selectedDate);
            }
        });
        $("#to, #to2, #to3, #to4, #to5, #to6").datepicker({
            defaultDate: "+1w",
            changeMonth: true,
            changeYear: true,
            onClose: function (selectedDate) {
                $("#from, #from2, #from3, #from4, #from5, #from6").datepicker("option", "maxDate", selectedDate);
            }
        });

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

        /*****************************************************************/
        /*************************** FUNCIONES ***************************/
        /*****************************************************************/

        function getWidth() {

            $('fieldset .details_grid').width(($('.content_fondo_blanco').width() - 20))

            $(window).resize(function () {
                //console.log($(window).width());
                $('fieldset .details_grid').width(($('.content_fondo_blanco').width() - 20))
            });
        }
    });





    $(function () {
        $(".static_class").click(function () {
            var $radiob = $(this);
            var $lediv = $(".extra");

            if ($(this).val() === "Yes") {
                $lediv.each(function () {
                    var $txtArea = $(this);
                    if ($txtArea.attr('data-input') == $radiob.attr('data-input')) {
                        //$txtArea.show("fast");
                        $txtArea.addClass('showContentClass');
                        $txtArea.removeClass('hideContentClass');
                    }
                });
            }
            else {
                $lediv.each(function () {
                    var $txtArea = $(this);
                    if ($txtArea.attr('data-input') == $radiob.attr('data-input')) {
                        //$txtArea.hide("fast");
                        $txtArea.addClass('hideContentClass');
                        $txtArea.removeClass('showContentClass');

                    }
                });
            }
            $('.refresh_height').trigger('change');
        });
    });




    /*	Dropdown with Multiple checkbox select with jQuery */







    $(function () {
        $(".checkbox-02").click(function () {
            var $radiob = $(this);
            var $lediv = $(".extra");

            if ($(this).val() === "checked") {
                $lediv.each(function () {
                    var $txtArea = $(this);
                    if ($txtArea.attr('data-input') == $radiob.attr('data-input')) {
                        //$txtArea.show("fast");
                        $txtArea.addClass('showContentClass');
                        $txtArea.removeClass('hideContentClass');
                    }
                });
            }
            else {
                $lediv.each(function () {
                    var $txtArea = $(this);
                    if ($txtArea.attr('data-input') == $radiob.attr('data-input')) {
                        //$txtArea.hide("fast");
                        $txtArea.addClass('hideContentClass');
                        $txtArea.removeClass('showContentClass');

                    }
                });
            }
            $('.refresh_height').trigger('change');
        });
    });



    $('#el_iframe').load(function () {
        var alto = $('#el_iframe').contents().height();
        //alert(alto);
        $('#el_iframe').css("height", alto);
    });


    $("select").attr('onkeydown', 'return (event.keyCode!=8)');
    $("input:text").each(function () {
        var input = $(this);

        if (input.attr('readonly'))
            input.attr('onkeydown', 'return (event.keyCode!=8)');
    });

    $("textarea").each(function () {
        var input = $(this);

        if (input.attr('readonly'))
            input.attr('onkeydown', 'return (event.keyCode!=8)');
    });


}
