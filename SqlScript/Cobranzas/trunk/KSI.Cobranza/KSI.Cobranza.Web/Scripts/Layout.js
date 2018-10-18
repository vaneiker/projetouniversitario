﻿$(document).ready(function () {
    SetMask();
    SetDatePicker();
    SetClickCalendar();
});

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

        if ($this.is("input:text") || $this.is("select") || $this.is("textarea"))
            $this.val("");

        if ($this.is("input:checkbox"))
            $this.prop("checked", false);

    });

}

function GotoLogout() {
    location.href = "/Login/UserLogout";
}

function SetDatePicker() {
    $('.datepicker').datepicker({
        "dateFormat": 'mm/dd/yy'
    });
}