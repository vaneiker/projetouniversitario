

/*BOTONES*/

$(document).ready(function() {
	
	
	//Popups Licencia
	var $licen640 = k$.modal(".licen640");
	
	$('.licen640').hide();
	
	$('.licen640_btn').click(function(e) {
		$($licen640).show();
		e.stopPropagation();
	});
	
	//Popups Detalles Cancelacion
	var $dtll_cancel = k$.modal(".dtll_cancel");
	
	$('.dtll_cancel').hide();
	
	$('.dtll_cancel_btn').click(function(e) {
		$($dtll_cancel).show();
		e.stopPropagation();
	});

	//Popups Declinar
	var $declinar_pp = k$.modal(".declinar_pp");
	
	$('.declinar_pp').hide();
	
	$('.declinar_pp_btn').click(function(e) {
		$($declinar_pp).show();
		e.stopPropagation();
	});

	//Popups Ajuste de pago
	var $ajpago500 = k$.modal(".ajpago500");
	
	$('.ajpago500').hide();
	
	$('.ajpago500_btn').click(function(e) {
		$($ajpago500).show();
		e.stopPropagation();
	});

/*======| ACORDEON |======*/
	
	var parentDivs = $('#cbp-ntaccordion li'),
        childDivs = $('#cbp-ntaccordion h3').siblings('div'),
        h3Event,
        h3Temp,
        sensitivity = 400;

  
    $('#cbp-ntaccordion h3').click(function () {
        childDivs.slideUp();
        if ($(this).next().is(':hidden')) {
            $(this).next().slideDown();
        } else {
            $(this).next().slideUp();
        }
    });
	
	/*======| FIN ACORDEON |======*/
});