function countryBlViewModel() {
    var self = this;

    self.countries = ko.observableArray();

    self.selectedCountry = ko.observable();
    self.selectedBusinessLine = ko.observable();

    self.businessLines = ko.computed(function () {
        if (self.selectedCountry()) {
            return self.selectedCountry().BusinessLines;
        }
        else
            return [];
    });

    self.updateInfoContact = ko.computed(function () {
        if (self.selectedBusinessLine()) {
            ChangeContactInformation(self.selectedBusinessLine());
        }
    });


    self.redirect = function () {
        var id = self.selectedBusinessLine();
        $.ajax({
            url: "/Home/SelectAction",
            method: 'POST',
            dataType: 'json',
            data: { businessLineId: id },
            async: false,
            success: function (data) {
                if (data.sucess) {
                    window.location = data.pathredirect;
                } else if (!data.sucess) {
                    if (data.message != "") {
                        showErrores([data.message], 'Error');
                    }
                }
            }
        });
    }
}

function showErrores(errorList, title, message, outCallback) {

    if (errorList.length > 0) {
        var errorContainer = $('#errorContainerIndex');
        var errorListContainer = $('#errorListIndex');
        var errorMessagePar = $('#errorMessageIndex');
        var closeButton = $('#popupError > div > button');
        errorListContainer.empty();
        _.each(errorList, function (item) {
            errorListContainer.append('<li>' + item + '</li>');
        });

        if (title)
            $('#errorTitleIndex').html(title);

        if (message) {
            errorMessagePar.html(message);
            errorMessagePar.show();
        }
        else
            errorMessagePar.hide();
        closeButton.focus();
        errorContainer.show();
        if (outCallback)
            closeButton.unbind('click');
        closeButton.click(function () {
        })
    }
}

$(document).ready(function () {
    $.ajax({
        url: "/Home/GetCountriesBl",
        method: 'GET',
        dataType: 'json',
        async: false,
        success: function (data) {
            var model = new countryBlViewModel();
            model.countries(data);

            var dominican = _.find(data, function (item) { return item.Global_Country_Id == 129; });
            model.selectedCountry(dominican);

            //ko.applyBindings(model);
            //<!-- Agregado por StateTrust -->            var bindDiv = document.getElementById("divBody");            ko.applyBindings(model, bindDiv);            //<!-- Agregado por StateTrust -->
        }
    });
})