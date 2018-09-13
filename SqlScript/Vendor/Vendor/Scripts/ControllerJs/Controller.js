function MostrarVendedor(id) {
    var url = "/Home/MostrarVendor?data="+id;
    location.href = url; 
}


function EditarVendedor(id) {
    var url = "/Home/SaveVendor?data="+id;
    location.href = url; 
}

