// extend range validator method to treat checkboxes differently
var defaultRangeValidator = $.validator.methods.range;
$.validator.methods.range = function (value, element, param) {
    if (element.type === 'checkbox') {
        // if it's a checkbox return true if it is checked
        return element.checked;
    } else {
        // otherwise run the default validation function
        return defaultRangeValidator.call(this, value, element, param);
    }
}


$.validator.addMethod('dependencynumericvaluevalidator',
function (value, element, parameters) {
    var id = '#' + parameters['dependentproperty'];

    // get the target value (as a string,
    // as that's what actual value will be)
    var targetvalue = parameters['targetvalue'];
    targetvalue =
      (targetvalue == null ? '' : targetvalue).toString();

    // get the actual value of the target control
    // note - this probably needs to cater for more
    // control types, e.g. radios
    var control = $(id);
    var controltype = control.attr('type');
    var actualvalue =
        controltype === 'checkbox' ?
        control.prop('checked').toString() :
        control.val();

    // if the condition is true, reuse the existing
    // required field validator functionality
    if (targetvalue === actualvalue)
        return $.validator.methods.required.call(this, value, element, parameters);

    return true;
});

$.validator.addMethod('requiredif',
function (value, element, parameters) {
    var id = '#' + parameters['dependentproperty'];

    // get the target value (as a string,
    // as that's what actual value will be)
    var targetvalue = parameters['targetvalue'];
    targetvalue =
      (targetvalue == null ? '' : targetvalue).toString();

    // get the actual value of the target control
    // note - this probably needs to cater for more
    // control types, e.g. radios
    var control = $(id);
    var controltype = control.attr('type');
    var actualvalue =
        controltype === 'checkbox' ?
        control.prop('checked').toString() :
        control.val();

    // if the condition is true, reuse the existing
    // required field validator functionality
    if (targetvalue === actualvalue)
        return $.validator.methods.required.call(
          this, value, element, parameters);

    return true;
});



$.validator.addMethod('requiredifmultiple',
function (value, element, parameters) {
    var id = '#' + parameters['dependentproperty'];

    // get the target value (as a string,
    // as that's what actual value will be)
    var targetvalue = parameters['targetvalue'];
    targetvalue =
      (targetvalue == null ? '' : targetvalue).toString();

    // get the actual value of the target control
    // note - this probably needs to cater for more
    // control types, e.g. radios
    var control = $(id);
    var controltype = control.attr('type');
    var actualvalue =
        controltype === 'checkbox' ?
        control.prop('checked').toString() :
        control.val();

    // if the condition is true, reuse the existing
    // required field validator functionality
    if (targetvalue === actualvalue)
        return $.validator.methods.required.call(
          this, value, element, parameters);

    return true;
});



$.validator.unobtrusive.adapters.add(
    'requiredifmultiple',
    ['dependentproperty', 'targetvalue'],
    function (options) {
        options.rules['requiredifmultiple'] = {
            dependentproperty: options.params['dependentproperty'],
            targetvalue: options.params['targetvalue']
        };
        options.messages['requiredifmultiple'] = options.message;
    });

$.validator.unobtrusive.adapters.add(
    'requiredif',
    ['dependentproperty', 'targetvalue'],
    function (options) {
        options.rules['requiredif'] = {
            dependentproperty: options.params['dependentproperty'],
            targetvalue: options.params['targetvalue']
        };
        options.messages['requiredif'] = options.message;
    });


$.validator.addMethod('mustbetrue',
function (value, element, parameters) {
    var targetvalue = parameters['targetvalue'];
    return value === targetvalue.toLowerCase();
});

$.validator.unobtrusive.adapters.add(
    'mustbetrue',
    ['targetvalue'],
    function (options) {
        options.rules['mustbetrue'] = {
            targetvalue: options.params['targetvalue']
        };
        options.messages['mustbetrue'] = options.message;
    });

