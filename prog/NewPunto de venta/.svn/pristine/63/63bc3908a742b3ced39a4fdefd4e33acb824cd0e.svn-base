function selectQuotationViewModel() {
    var self = this;
    self.selectedYear = ko.observable();
    self.selectedMonth = ko.observable();
    self.selectedDay = ko.observable();
    self.selectedQuotationNumber = ko.observable('');
    self.selectedIdNumber = ko.observable();
    self.maxSelectableYear = ko.observable();

    self.years = ko.computed(function () {
        var years = new Array();
        if (self.maxSelectableYear()) {
            for (var i = self.maxSelectableYear() ; i > self.maxSelectableYear() - 100; i--)
                years.push(i);
        }
        return years;
    });

    self.months = ko.observableArray();

    self.days = ko.computed(function () {
        var days = new Array();
        if (self.selectedYear() && self.selectedMonth()) {

            var thisMonth = moment([self.selectedYear(), self.selectedMonth() - 1]);
            var totalDays = thisMonth.daysInMonth();

            for (var i = 1; i <= totalDays; i++)
                days.push(i);
        }

        return days;

    });

    self.yearPressKey = function (data, event) {
        if (event.which == 13) {
            self.redirect();
        }
        else
            return true;
    }

    self.redirect = function () {
        window.location = '/Home/SelectQuotationByFilter?quotationNumber=' + self.selectedQuotationNumber() + '&principalId=' + self.selectedIdNumber() + '&day=' + self.selectedDay() + '&month=' + self.selectedMonth() + '&year=' + self.selectedYear();
    }

    $.ajax({
        dataType: "json",
        url: '/Home/GetServerDate',
        async: false,
        success: function(data) {
            self.maxSelectableYear(new Date(parseInt(data.currentDate.substr(6))).getFullYear());
        }
    });

    $.ajax({
        dataType: "json",
        url: '/Home/GetMonths',
        async: false,
        success: function (data) {
            self.months(data);
        }
    });

}