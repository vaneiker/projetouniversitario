

/*BOTONES*/


var $signup = k$.modal(".marb_izq");


$($signup).hide();

$('.expan_marb').click(function(e) {
	$($signup).show();
	e.stopPropagation();
});
