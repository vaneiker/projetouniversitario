$(function () {
    $('.table-endosatarios').DataTable({
        responsive: true
    });

    $('#btnNuevo').on('click', function (e) {
        e.preventDefault();
        transition($('#divCrearEditar'), $('#divListado'));
        $('#Ind_Nuevo').val(1);
        $('#nombre-endosatario').val('');
        $('#rnc-endosatario').val('');
        $("#nombre-contacto").val('');
        $("#telefono-contacto").val('');
        $("#email-contacto").val('');
        $('#estado-endosatario').checked = true;
        $('#endosatario-endorsementId').val(0);
        $('#direccion-endosatario').val('');
    });

    $('.datos-endosatario').on('click', function (e) {
        e.preventDefault();

        var $id = $(this)[0].id.toLowerCase(),
            accion = $id.replace('btn', '');

        if (accion == 'guardar')
            guardarEndosatario();
        else
            transition($('#divListado'), $('#divCrearEditar'));
    });

    $('#estado-endosatario').on('change', function () {
        var checked = $(this).prop('checked');
        $('#label-estado-endosatario').text(checked ? 'Activo' : 'Inactivo');
    });

});

function transition(show, hide) {
    $(hide).fadeOut('fast', 'swing', function () {
        $(show).fadeIn('fast');
    });
}

function guardarEndosatario() {

    if ($('#nombre-endosatario').val() == null || $('#nombre-endosatario').val() == '') {
        alert("Debe indicar el nombre del endosatario")
        $('#btnNuevo').preventDefault();
        transition($('#divCrearEditar'), $('#divListado'));
        return false;
    }

    if ($('#rnc-endosatario').val() == null || $('#rnc-endosatario').val() == '') {
        alert("Debe indicar el RNC del endosatario")
        $('#btnNuevo').preventDefault();
        transition($('#divCrearEditar'), $('#divListado'));
        return false;
    }

    var datos = {
        EndorsementId: $('#endosatario-endorsementId').val(), //tienes que enviarlo cuando sea EDIT cuando sea nuevo debe ser NULL
        Name: $('#nombre-endosatario').val(),
        Rnc: $('#rnc-endosatario').val(),
        ContactName: $('#nombre-contacto').val(),
        ContactTel: $('#telefono-contacto').val(),
        ContactAdress: $('#email-contacto').val(),
        EndorsementStatus: $('#estado-endosatario').prop('checked'),
        Direccion: $('#direccion-endosatario').val()
    }
    
    $.ajax({
        url: "/Endosatarios/Guardar",
        method: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: true,
        data: JSON.stringify(datos)
    }).done(function (result) {
        if (result.Error) {
            alert(result.Message);
            return false;
        }
        else {
            alert("Datos guardados correctamente!!!");
            window.location.reload(); // esto es para refrescar el navegador inmediatamente.
        }
    }).fail(function (jqXHR, textStatus) {
        alert("Error guardando los datos: " + textStatus);
        return false;
    });

    
}
