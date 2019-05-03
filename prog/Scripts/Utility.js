var divLoading = '<div class="loading"></div>';

//var divLoading = '<div class="loading"><div class="imgloading"><img src="/Content/images/loading.gif" alt="Loading" class="img-fluid" /></div></div>';
BeginRequestHandler = function (sender, args) {   
    $(".loading").remove();    
    $("body").append(divLoading);    
};

EndRequestHandler = function (sender, args) {
    $(".loading").remove();
};

function showError(errorList, title) {

    var errorContainer = $("#ppError");
    var errorTitle = $("#errorTitle");
    var errorListContainer = $("#errorListContainer");

    if (title) {
        errorTitle.html(title);
    }

    errorListContainer.empty();
    if (errorList) {
        $.each(errorList, function (item, i) {
            errorListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }
    errorContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function showSucess(sucessList, title, okCallback, OcultarBoton) {

    var sucessContainer = $("#ppSucess");
    var sucessTitle = $("#sucessTitle");
    var sucessListContainer = $("#sucessListContainer");
    var okButton = $('#btnSucessOk');

    if (title) {
        sucessTitle.html(title);
    }

    sucessListContainer.empty();
    if (sucessList) {
        $.each(sucessList, function (item, i) {
            sucessListContainer.append('<li class="text-left">' + i + '</li>');
        });
    }

    if (OcultarBoton == false) {
        $("#RedirectToOtherApp").css("display", "block");
    } else {
        $("#RedirectToOtherApp").css("display", "none");
    }

    //cuando no haya usuario logueado no mostrar el boton de ir a la bandeja
    if ($("#hdnOnlyLoggedUsers").val() === "False" || $("#hdnOnlyLoggedUsers").val() === "false") {
        $("#RedirectToOtherApp").css("display", "none");
    }
    
    okButton.focus();

    if (okCallback) {
        okButton.unbind('click');
        okButton.click(function () {
            sucessContainer.modal('hide');
            okCallback();
        });
    }

    //sucessContainer.modal('show');
    sucessContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}

function showQuestion(question, title, acceptAction, CancelAction) {

    var questionModalContainer = $("#ppQuestion");
    var questionTitle = $("#questionTitle");
    var questionContainer = $("#questionContainer");
    var okButton = $('#btnQuestionOk');
    var cancelButton = $('#btnQuestionCancel');

    if (title) {
        questionTitle.html(title);
    }

    questionContainer.empty();
    if (question) {
        questionContainer.html(question);
    }

    okButton.off("click");
    okButton.click(function () { questionModalContainer.modal('hide'); acceptAction(); });

    if (typeof CancelAction === "function") {
        cancelButton.off("click");
        cancelButton.click(function () { questionModalContainer.modal('hide'); CancelAction(); });
    } else {
        cancelButton.click(function () { questionModalContainer.modal('hide'); });
    }

    //questionModalContainer.modal('show');
    questionModalContainer.modal({ backdrop: 'static', keyboard: false, show: true });
}