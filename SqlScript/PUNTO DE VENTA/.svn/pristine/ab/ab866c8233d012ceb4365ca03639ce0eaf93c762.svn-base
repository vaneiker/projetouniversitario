function customValidationsMethods() {

    $.validator.addMethod('dateFormat', function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var ok = true;
        try {
            $.datepicker.parseDate(getCurrentDateFormat(), value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });
}