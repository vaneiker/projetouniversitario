var changePasswordValidationRules = {
    onsubmit: true,
    rules: {
        Password: {
            required: true,
            maxlength: 50
        },
        NewPassword: {
            required: true,
            maxlength: 50
        },
        ConfirmNewPassword: {
            required: true,
            maxlength: 50
        }
    },
    messages: {
        Password: {
            required: 'La Contraseña original es requerida.',
            maxlength: 'La Contraseña original no puede tener más de 50 caracteres de longitud.'
        },
        NewPassword: {
            required: 'Debe ingresar una Nueva Contraseña.',
            maxlength: 'La Nueva Contraseña no puede tener más de 50 caracteres de longitud.'
        },
        ConfirmNewPassword: {
            required: 'Debe confirmar la Nueva Contraseña.',
            maxlength: 'La confirmación de Nueva Contraseña no puede tener más de 50 caracteres de longitud.'
        }
    },
}


$(document).ready(function () {
    $('#changePasswordForm').validate(changePasswordValidationRules);

    var errStr = $('#Errors').val();

    if (errStr) {

        var errors = JSON.parse(errStr);

        if (errors && errors.length) {
            showError(errors, "Login");
        }
    }

    var redirectUrl = $('#RedirectUrl').val();
    if (redirectUrl) {
        showSuccessCallback('Cambio de contraseña', "Su contraseña se ha actualizado exitosamente.", function () {
            window.location = redirectUrl;
        })
    }

});