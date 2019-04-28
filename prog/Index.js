$(document).ready(function () {
    $('body').scrollspy({ target: '#navbar-example' });
});

function OnSuccess(data) {
    var parameter1 = data.responseJSON.param1;
    var parameter2 = data.responseJSON.param2;

    if (parameter1 === 202) {
        alertify.alert(
            'Cliente y Poliza',
            '<strong>AGRACIADOS ' + parameter2 + '</strong>',
            function () {
                alertify.success('¡Gracias por participar!');
            }); 
    } 
    else if (parameter1 === 402) {
        alertify.alert(
            'Cliente y Poliza',
            '<strong>Error al generar ganador ' + parameter2 + '</strong>',
            function () {
                alertify.error('¡Vuelva a intentarlo!');
            });
    } 
}
function OnFailure(data) {
    var cedulaerror = data.responseJSON.param2; 
    alertify.alert(
        'Cliente y Poliza',
        '<strong>Error al generar ganador ' + cedulaerror + '</strong>',
        function () {
            alertify.error('¡Vuelva a intentarlo!');
        });


}
/*
var app = new Vue({
    el: "#APP",
    data: {
        ganadorpoliza:"El cliente ganador es pedro 00118159979"
    }
});*/