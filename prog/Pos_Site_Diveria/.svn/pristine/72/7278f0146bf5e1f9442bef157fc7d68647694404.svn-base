var loginValidationRules = {
    onsubmit: true,
    rules: {
        Username: {
            email: true,
            required: true,
            maxlength: 255
        },
        Password: {
            required: true,
            maxlength: 50
        }
    },
    messages: {
        Username: {
            email: 'El E-Mail no tiene el formato correcto.',
            required: 'El E-Mail es requerido.',
            maxlength: 'El E-Mail no puede tener más de 255 caracteres de longitud.'
        },
        Password: {
            required: 'La Contraseña es requerida.',
            maxlength: 'La Contraseña no puede tener más de 50 caracteres de longitud.'
        },

    }
}

var registerValidationRules = {
    onsubmit: true,
    rules: {
        Name: {
            required: true,
            maxlength: 50
        },
        Surname: {
            required: true,
            maxlength: 50
        },
        Telephone: {
            required: true,
            maxlength: 50
        },
        Email: {
            required: true,
            maxlength: 255,
            email: true
        },
        ConfirmEmail:
        {
            required: true,
            maxlength: 255,
            email: true
        }
    },
    messages: {
        Name: {
            required: 'El Nombre es requerido.',
            maxlength: 'El Nombre no puede tener más de 50 caracteres de longitud.'
        },
        Surname: {
            required: 'El Apellido es requerido.',
            maxlength: 'El Apellido no puede tener más de 50 caracteres de longitud.'
        },
        Telephone: {
            required: 'El Teléfono es requerido.',
            maxlength: 'El Teléfono no puede tener más de 50 caracteres de longitud.'
        },
        Email: {
            email: 'El E-Mail no tiene el formato correcto.',
            required: 'El E-Mail es requerido.',
            maxlength: 'El E-Mail no puede tener más de 255 caracteres de longitud.'
        },
        ConfirmEmail: {
            email: 'El E-Mail de Confirmación no tiene el formato correcto.',
            required: 'El E-Mail de Confirmación es requerido.',
            maxlength: 'El E-Mail de Confirmación no puede tener más de 255 caracteres de longitud.'
        }
    },
}

function callChangePassword() { $('#askPasswordChangePopup').show();}

$(document).ready(function () {
    $('#loginForm').validate(loginValidationRules);

    $('#registerForm').validate(registerValidationRules);

    $('#askPasswordChangeAccept').click(function () {
        var userName = $('#usernamePopup').val();
        if (userName) {
            $.getJSON("AskForPasswordChange", { username: userName }, function (data) {
                $('#askPasswordChangePopup').hide();
                if (data && data.length)
                    showError(data, "Cambio de Contraseña");
                else
                    showSuccess("Cambio de Contraseña", "Se ha enviado un E-mail a la dirección de correo electrónico del usuario.");
            });
        }
        else
            showError(['Debe ingresar un nombre de usuario'], "Cambio de Contraseña");
    });

    var errStr = $('#Errors').val();

    if (errStr) {

        var errors = JSON.parse(errStr);

        if (errors && errors.length) {
            showError(errors, "Login");
        }
    }

    var infoStr = $('#UserCreatedMessage').val();
    if (infoStr)
    {
        showSuccess('Registro', infoStr, null, true);
        $('#Name').val("");
        $('#Surname').val("");
        $('#Telephone').val("");
        $('#Email').val("");
        $('#ConfirmEmail').val("");
    }

});