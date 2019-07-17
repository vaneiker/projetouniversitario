

$(document).ready(function () {

});

function obtenerArray() {
    var lines = $('#textarea').val().split(/\n/);
    var texts = []
    for (var i = 0; i < lines.length; i++) {
        // only push this line if it contains a non whitespace character.
        if (/\S/.test(lines[i])) {
            texts.push($.trim(lines[i]));
        }
    }
    let t = JSON.stringify(texts)
    alert(t)

    ValidateLoggin(t);
}

function ValidateLoggin(t) {
    $.ajax({
        type: "POST",
        url: "Home/CreateUserAgentNew",
        data: t,
        contentType: "application/json; charset=utf-8",
        dataType: "json", 
        success: function (data) {
            alert(data)
        },
        error: function (data) {
            alert(data)
        }
    });
}