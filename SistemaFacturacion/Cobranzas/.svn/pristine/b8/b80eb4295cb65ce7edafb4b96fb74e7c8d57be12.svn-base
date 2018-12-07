function closeNotificacion() {
    $('#dialogo').slideUp('slow');
}
function MostrarAlerta(type, title, mensaje) {
    if (type == 1) {
        $('#dialogo').css({
            'backgroundColor': '#dff0d8',
            'border': '1px solid #3c763d',
            'borderRadius': '0 0 8px 8px',
            'top': '0',
            'display': 'block',
            'height': '50px',
            'marginLeft': '25%',
            'marginRight': 'auto',
            'position': 'absolute',
            'width': '50%',
            'zIndex': '10'
        }).show("slow", function () {
            setTimeout('closeNotificacion()', 3000);
        });
        $('#dialogomensaje').css({
            'color': '#3c763d'
        });
    }
    if (type == 2) {
        $('#dialogo').css({
            'backgroundColor': '#fcf8e3',
            'border': '1px solid #faebcc',
            'borderRadius': '0 0 8px 8px',
            'top': '0',
            'display': 'block',
            'height': '50px',
            'marginLeft': '25%',
            'marginRight': 'auto',
            'position': 'absolute',
            'width': '50%',
            'zIndex': '10'
        }).show("slow", function () {
            setTimeout('closeNotificacion()', 3000);
        });
        $('#dialogomensaje').css({
            'color': '#8a6d3b'
        });
    }
    if (type == 0) {
        $('#dialogo').css({
            'backgroundColor': '#f2dede',
            'border': '1px solid #ebccd1',
            'borderRadius': '0 0 8px 8px',
            'top': '0',
            'display': 'block',
            'height': '50px',
            'marginLeft': '25%',
            'marginRight': 'auto',
            'position': 'absolute',
            'width': '50%',
            'zIndex': '10'
        }).show("slow", function () {
            setTimeout('closeNotificacion()', 3000);
        });
        $('#dialogomensaje').css({
            'color': '#a94442'
        });
    }
    $('#dialogomensaje').html(mensaje);
}


//jq3 = $.noConflict();

function MostrarAlerta2(mensaje) {
    $("#dialogo2").dialog({
        closeOnEscape: false,
        height: 200,
        width: 300,
        modal: true,
        title: "Advertencia",
        open: function (event, ui) {
            $("#dialogo2").html(mensaje);
            return false;
        },
        //show: {
        //    effect: "fade",
        //    duration: 1000
        //},
        //hide: {
        //    effect: "fade",
        //    duration: 1000
        //},
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
            }
        }
    });
}

function loading() {
    $("#loading").css({
        'display':'block'
    });
    return false;
}
function enviarComentario() {
    var Caso = document.getElementById('txtQuotationID').value;
    var IdSubjectNotes = document.getElementById('IdSubjectNotes').value;
    var comentario = document.getElementById('comentarioNotes').value;

    if (IdSubjectNotes != '') {
        $.ajax({
            async: true,
            type: "POST",
            dataType: "html",
            contentType: "application/x-www-form-urlencoded",
            url: "/Quotation/CreateNotesOfCase",
            data: "Comments=" + encodeURIComponent(comentario) + "&IdNoteSubject=" + encodeURIComponent(IdSubjectNotes) + "&StringIdsQuotation=" + encodeURIComponent(Caso),
            beforeSend: function () {
                $("#notificacionModuloNotesAtlantica").css('display', 'block');
                $("#notificacionModuloNotesAtlantica").html('<img src="/Content/images/loading2.gif" /> Enviando el comentario...');
                $("#notificacionModuloNotesAtlantica").removeClass("alert alert-success");
            },
            success: function (datos2) {
                if (datos2 == '"Nota almacenada al caso"') {
                    $("#comentarioNotes").val("");
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-success");
                    $("#notificacionModuloNotesAtlantica").html(datos2);
                } else {
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-danger");
                    $("#notificacionModuloNotesAtlantica").html(datos2);
                }

                RefreshGridNotes();
            },
            timeout: 8000,
            error: function () { $("#notificacionModuloNotesAtlantica").text('Problemas en el servidor.'); }
        });
        return false;
    } else {
        MostrarAlerta2('Por favor seleccione un asunto en su mensaje');
        document.getElementById('IdSubjectNotes').focus();
    }
}

function GuardarOposicion() {
    var Caso = document.getElementById('txtQuotationID').value;
    var IdSubjectNotes = document.getElementById('IdSubjectNotes').value;
    var comentario = document.getElementById('comentarioNotes').value;

    if (IdSubjectNotes != '') {
        $.ajax({
            async: true,
            type: "POST",
            dataType: "html",
            contentType: "application/x-www-form-urlencoded",
            url: "/Quotation/CreateNotesOfCase",
            data: "Comments=" + encodeURIComponent(comentario) + "&IdNoteSubject=" + encodeURIComponent(IdSubjectNotes) + "&StringIdsQuotation=" + encodeURIComponent(Caso),
            beforeSend: function () {
                $("#notificacionModuloNotesAtlantica").css('display', 'block');
                $("#notificacionModuloNotesAtlantica").html('<img src="/Content/images/loading2.gif" /> Enviando el comentario...');
                $("#notificacionModuloNotesAtlantica").removeClass("alert alert-success");
            },
            success: function (datos2) {
                if (datos2 == '"Nota almacenada al caso"') {
                    $("#comentarioNotes").val("");
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-success");
                    $("#notificacionModuloNotesAtlantica").html(datos2);
                } else {
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-danger");
                    $("#notificacionModuloNotesAtlantica").html(datos2);
                }

                RefreshGridNotes();
            },
            timeout: 8000,
            error: function () { $("#notificacionModuloNotesAtlantica").text('Problemas en el servidor.'); }
        });
        return false;
    } else {
        MostrarAlerta2('Por favor seleccione un asunto en su mensaje');
        document.getElementById('IdSubjectNotes').focus();
    }
}

function uploadAjax() {
    var inputFileImage = document.getElementById("fileupload");
    var file = inputFileImage.files[0];
    var url = "/Quotation/UploadFile";
    var dat= "IdQuotation=207&Filepath" +  $("#fileupload").value;
    debugger
    $.ajax({
        async:true,
        url: url,
        type: 'POST',
        contentType: false,
        data:dat,
        processData: false,
        cache: false
    }).done(function () {
        alert("Cargado");

    });
}



function enviarComentario2() {
    var Casos = document.getElementById('txtQuotationID').value;
    var IdSubjectNotes = document.getElementById('IdSubjectNotes').value;
    var comentario = document.getElementById('comentarioNotes').value;

    if (IdSubjectNotes != '') {
        $.ajax({
            async: true,
            type: "POST",
            dataType: "html",
            contentType: "application/x-www-form-urlencoded",
            url: "/Quotation/CreateNotesOfCase",
            data: "Comments=" + encodeURIComponent(comentario) + "&IdNoteSubject=" + encodeURIComponent(IdSubjectNotes) + "&StringIdsQuotation=" + encodeURIComponent(Casos),
            beforeSend: function () {
                $("#notificacionModuloNotesAtlantica").css('display', 'block');
                $("#notificacionModuloNotesAtlantica").html('<img src="/Content/images/loading2.gif" /> Enviando el comentario...');
                $("#notificacionModuloNotesAtlantica").removeClass("alert alert-success");
            },
            success: function (datos2) {
                if (datos2 == '"Nota almacenada al caso"') {
                    $("#comentarioNotes").val("");
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-success");
                    $("#notificacionModuloNotesAtlantica").html(datos2);

                    setTimeout(function () {
                        minizarModalSTSV();
                        var btnMaximizarmoduloNotesAtlantica = document.getElementById('btnMaximizarmoduloNotesAtlantica');
                        btnMaximizarmoduloNotesAtlantica.style.display = 'none';
                        var btnMinimizarmoduloNotesAtlantica = document.getElementById('btnMinimizarmoduloNotesAtlantica');
                        btnMinimizarmoduloNotesAtlantica.style.display = 'none';
                        btnMaximizarmoduloNotesAtlantica.onclick = function () { };

                    }, 3000);
                } else {
                    $("#notificacionModuloNotesAtlantica").css('display', 'block');
                    $("#notificacionModuloNotesAtlantica").addClass("alert alert-danger");
                    $("#notificacionModuloNotesAtlantica").html(datos2);
                }
            },
            timeout: 8000,
            error: function () { $("#notificacionModuloNotesAtlantica").text('Problemas en el servidor.'); }
        });
        return false;
    } else {
        MostrarAlerta2('Por favor seleccione un asunto en su mensaje');
        document.getElementById('IdSubjectNotes').focus();
    }
}

function RefreshGridNotes() {

    $.get('/Quotation/_PartialNotesSummary/' + parseInt(document.getElementById('txtQuotationID').value), function (data) {
        $('#TableNotesSummary').html(data);
    });

    /*
    Helper.DoAjax(
        "/Quotation/AjaxNotesSummary",
        {
            IdQuotation: parseInt(document.getElementById('txtQuotationID').value)
        }).done(function (Response) {

            $("#TableNotesSummary").html("");

            var Render = "<tr>";
            Render += "<th>Asunto</th>";
            Render += "<th>Nota</th>";
            Render += "<th>Usuario</th>";
            Render += "<th>Fecha</th>";
            Render += "</tr>";

            $.each(Response, function (k, v) {
                Render += "<tr>";
                Render += "<td>" + v.QuickMessageDesc + "</td>";
                Render += "<td>" + v.Comments + "</td>";
                Render += "<td>" + v.NameUser + "</td>";
                Render += "<td>" + v.CreateDate + "</td>";
                Render += "</tr>";
            });

            $("#TableNotesSummary").html(Render);
        });
    */
}

function minizarModalSTSV() {
    $("#moduloNotesAtlantica").css({
        'height': '30px'
    });
    $("#btnMinimizarmoduloNotesAtlantica").css({
        'display': 'none'
    });
    $("#btnMaximizarmoduloNotesAtlantica").css({
        'display': 'block'
    });
}
function maximizarModalSTSV() {
    $("#moduloNotesAtlantica").css({
        'height': '405px'
    });
    $("#btnMinimizarmoduloNotesAtlantica").css({
        'display': 'block'
    });
    $("#btnMaximizarmoduloNotesAtlantica").css({
        'display': 'none'
    });
}

/**
* // -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- >>
*/
window.addEventListener('load', function () {

    $("#st-content").scroll(function () {
    });

}, false);
$('document').ready(function () {
    $('.dropdown-toggle').dropdown();
    $('#btnNuevo').click(function () {
        $('#NewForm').slideDown("slow");
    });
});