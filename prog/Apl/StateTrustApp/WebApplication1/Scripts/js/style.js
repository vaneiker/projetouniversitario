var opc = document.getElementById("opciones").getElementsByTagName("a");
var pr = document.getElementById("bar");
//alert(pr);

for (var i = 0 ; i < opc.length ; i++) {

   // pr.innerText = pr.innerText +"<br/>"+ opc[i];
    CrearEvento(opc[i], "click", OpcionActual)

}


function CrearEvento(opcion, evento, funcion) {
    if (opcion.addEventListener) {
        opcion.addEventListener(evento, funcion, false);
    } else {
        opcion.attachEvent("on" + evento, funcion);
    }
}

function OpcionActual(opcion) {
    var x = document.getElementById(opcion);
    aler(x)
    
    x.classList.add("Seleted");
}


function ValidarAnos() {
    var desde = document.getElementById('ddlAnoDesde');
    var hasta = document.getElementById('ddlAnoHasta');

    if (desde.selectedIndex > hasta.selectedIndex) {
        hasta.focus();
        alert('Debe Selecionar una ano mayor');

    }
}


function ValidarNumero(objecto) {
    var x = document.getElementById(objecto);
    if (isNaN(x.value)) {
        // alert("Debe Introducir un valor Númerico");
        x.style.borderColor = "red";
        x.focus();
    }
    else {
        x.style.borderColor = "";
    }
}

