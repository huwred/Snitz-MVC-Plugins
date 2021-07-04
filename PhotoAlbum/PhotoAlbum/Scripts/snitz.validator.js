//excluded chars validator
$.validator.unobtrusive.adapters.addSingleVal("exclude", "chars");
$.validator.addMethod("exclude", function (value, element, exclude) {
    if (value) {
        for (var i = 0; i < exclude.length; i++) {
            if (jQuery.inArray(exclude[i], value) != -1) {
                return false;
            }
        }
    }
    return true;
});

//conditional validator
$.validator.unobtrusive.adapters.add(
    'conditional',
    ['dependentproperty', 'targetvalue'],
    function (options) {
        options.rules['conditional'] = {
            conditional: options.params['dependentproperty'],
            targetvalue: options.params['targetvalue']
        };
        options.messages['conditional'] = options.message;
    });

$.validator.addMethod("conditional", function (value, element, parameters) {

    var ctl = $("[id$='" + parameters['conditional'] + "']");

    if (ctl.length > 0) {
        if (element.value.length > 0) {
            return true;
        }
        if (ctl.val() != parameters['targetvalue']) {
            return true;
        }

    } else {
        return false;
    }
    return false;
});
