$(document).ready(function () {
    SetMask();
    SetDatePicker();
    SetClickCalendar();
    SetDraggableModal();
    CustomValidation();
    //Deshabilitar el autocompletado en los inputs
    RemoveInputAutoComplete();
});

$.validator.setDefaults({
    showErrors: function (errorMap, errorList) {
        if (errorList.length > 0) {
            var ShowError = $(".validation-summary-errors").length == 0;
            var messages = $.map(errorList, function (item) {
                var $Element = $(item.element);
                $Element.css("border", "1px solid red");
                $Element.change(function () {
                    var $this = $(this);
                    $this.css("border", "1px solid #ccc");
                })
                return "<li>" + item.message + "</li>";
            });

            if (ShowError) {
                var msgTemp = "";
                for (var i = 0; i < messages.length; i++)
                    msgTemp += messages[i];

                var Msgs = "<div class='alert alert-danger validation-summary-errors'> <ul>" + msgTemp + "</ul> <div>";
                ShowMessageBS(Msgs, "Advertencia", function () {
                    $(".validation-summary-errors").remove();
                });
            }
        }
    },
    onfocusout: false,
    onkeyup: false,
    onclick: false,
    onsubmit: true,
    focusInvalid: false
});

function RemoveInputAutoComplete() {
    $("body").find("input:text").attr("autocomplete", "off");
}

function validateLoadedFile(obj) {
    var hasFile = obj.files.length != 0;
    $("#hdnHasLoadedFile").val(hasFile);
}

function SetProgressBar(frm, callBack) {
    var bar = $('.progress-bar');
    var percent = $('.progress-bar');
    var status = $('#status');

    $(frm).ajaxForm({
        beforeSend: function () {
            $("#dvCargando").show();
            status.empty();
            var percentVal = '0%';
            bar.width(percentVal)
            percent.html(percentVal);
        },
        uploadProgress: function (event, position, total, percentComplete) {
            var percentVal = percentComplete + '%';
            bar.width(percentVal)
            percent.html(percentVal);
        },
        success: function () {
            var percentVal = '100%';
            bar.width(percentVal)
            percent.html(percentVal);
            if (callBack != undefined) {
                callBack();
            }
        },
        complete: function (xhr) {
            setTimeout(function () {
                $("#dvCargando").hide();
                var percentVal = '0%';
                bar.width(percentVal)
                percent.html(percentVal);
            }, 1000);
            status.html(xhr.responseText);
        }
    });
}

function CustomValidation() {
    //$.validator.addMethod('DependencyNumericValueValidator',
    //    function (value, element, parameters) {
    //        var id = '#' + parameters['dependentProperty'];
    //        // get the target value (as a string, 
    //        // as that's what actual value will be)
    //        var targetvalue = parameters['targetvalue'];
    //        targetvalue = (targetvalue == null ? '' : targetvalue).toString();

    //        var targetvaluearray = targetvalue.split('|');

    //        for (var i = 0; i < targetvaluearray.length; i++) {

    //            // get the actual value of the target control
    //            // note - this probably needs to cater for more 
    //            // control types, e.g. radios
    //            var control = $(id);
    //            var controltype = control.attr('type');
    //            var actualvalue =
    //            controltype === 'checkbox' ?
    //            control.attr('checked') ? "true" : "false" :
    //            control.val();

    //            // if the condition is true, reuse the existing 
    //            // required field validator functionality
    //            if (targetvaluearray[i] === actualvalue) {
    //                return $.validator.methods.required.call(this, value, element, parameters);
    //            }
    //        }

    //        return true;
    //    }
    //);

    //$.validator.unobtrusive.adapters.add(
    //    'requiredif',
    //    ['dependentproperty', 'targetvalue'],
    //    function (options) {
    //        options.rules['requiredif'] = {
    //            dependentproperty: options.params['dependentproperty'],
    //            targetvalue: options.params['targetvalue']
    //        };
    //        options.messages['requiredif'] = options.message;
    //    });
}

function SetDraggableModal() {
    $(".modal").draggable({
        handle: ".modal-header"
    }).find(".modal-header").css("cursor", "move");;
}

function SetClickCalendar() {
    $(".fa-calendar").parent().click(function () {
        var $this = $(this);
        var $object = $this.parents().eq(1).find("input:text");
        $object.focus();
    });
}

function InitializeGrid($grid) {
    $grid.find("tbody tr").click(function () {
        var $thisRow = $(this);
        $grid.find("tbody tr").removeClass("rowActive");
        $thisRow.addClass("rowActive");
    });
}

function GotoSearch() {
    location.href = "/Home/Index";
}

function SetMask() {

    $("[data-inputmask]").inputmask();

    $("[number = 'number4']").inputmask({ alias: 'integer', autoGroup: false, digits: 0, repeat: 4, allowMinus: false, allowPlus: false, rightAlign: false });

    $("[numberWithoutValidation = 'numberWithoutValidation']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 3, digits: 0, allowMinus: false, allowPlus: false });

    $("[number = 'number3']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 3, digits: 0, allowMinus: false, allowPlus: false });

    $("[number = 'number2']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 2, digits: 0, allowMinus: false, allowPlus: false });

    $("[number = 'number']").inputmask({ alias: 'integer', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 0, allowMinus: false, allowPlus: false });

    $("[rncNumber = 'rncNumber']").attr('data-inputmask-regex', "[0-9\(\)\.\+/ ]*");

    $("[rncNumber = 'rncNumber']").inputmask("999-99999-9",
        {
            "onincomplete": function () {
                if ($(this).val() != "")
                    OnMaskIncomplete(this);
            },
            "oncomplete": function () {
                if ($(this).val() != "")
                    OnMaskComplete(this);
            }
        });

    $("[cedula = 'cedula']").inputmask("999-9999999-9",
        {
            "onincomplete": function () {
                if ($(this).val() != "")
                    OnMaskIncomplete(this);
            },
            "oncomplete": function () {
                if ($(this).val() != "")
                    OnMaskComplete(this);
            }
        });

    $("[phonenumber='PhoneNumber']").inputmask("(999)999-9999",
       {
           "onincomplete": function () {
               if ($(this).val() != "")
                   OnMaskIncomplete(this);
           },
           "oncomplete": function () {
               if ($(this).val() != "")
                   OnMaskComplete(this);
           }
       });

    $("[decimal='decimal']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 2, allowMinus: false, allowPlus: false, rightAlign: true });

    $("[decimalWithsign='decimalWithsign']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 9, digits: 2, allowMinus: true, allowPlus: false, rightAlign: true });

    $("[decimal='decimal3']").inputmask({ alias: 'decimal', groupSeparator: ',', autoGroup: true, repeat: 3, digits: 2, allowMinus: false, allowPlus: false, rightAlign: true });

    $("[Policy='Policy']").attr('data-inputmask-regex', "[0-9A-Za-z-\\sñÑ]*");

    $("[alphabetical='alphabetical']").attr('data-inputmask-regex', "[A-Za-z.\\sñÑáéíóúÁÉÍÓÚ']*");

    $("[alphabetical='alphabeticalLastName']").attr('data-inputmask-regex', "[A-Za-z.'-\\sñÑáéíóúÁÉÍÓÚ']*");

    $("[alphabetical='alphabetical']").inputmask("Regex");

    $("[RncNumber = 'RncNumber']").inputmask("Regex");

    $("[alphabetical='alphabeticalLastName']").inputmask("Regex");
}

function OnMaskComplete(obj) {
    var $obj = $(obj);
    $obj.attr("completeMask", "true");
}

function OnMaskIncomplete(obj) {
    var $obj = $(obj);
    var Message = $obj.attr("mydataMessage");
    ShowMessageBS("El campo " + Message + " no esta completo! ", "Advertencia");
    $obj.attr("completeMask", "false");
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

function ClearFields(obj) {
    var $thisForm = $(obj);  
    $thisForm.find("input:text,select,input:checkbox,textarea").each(function () {
        var $this = $(this);
        var isNoClear = $this.attr("noclear") != undefined;
        if (!isNoClear) {
            if ($this.is("input:text") || $this.is("select") || $this.is("textarea"))
                $this.val("");

            if ($this.is("input:checkbox"))
                $this.prop("checked", false);
        }
    });
}

function GotoLogout() {
    location.href = "/Login/UserLogout";
}

function SetDatePicker() {
    $('.datepicker').datepicker({
        "dateFormat": 'mm/dd/yy'
    });
    SetClickCalendar();
}
