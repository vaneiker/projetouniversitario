function resumePricingItemViewModel() {
    var self = this;

    self.item = ko.observable(undefined);
    self.align = ko.observable();
    self.className = ko.observable();
    self.style = ko.observable();
    self.cSpan = ko.observable(1);
    self.formatMoney = ko.observable('T');
    self.action = {
        title: ko.observable(),
        className: ko.observable(),
        funct: undefined
    }
}

function resumePricingViewModel() {
    var self = this;
    
    self.columns = ko.observableArray([]);
    self.items = ko.observableArray([]);

    self.secondColumns = ko.observableArray([]);
    self.secondItems = ko.observableArray([]);

    self.totalPrime = ko.observable(0).money();
    self.totalIsc = ko.observable(0).money();
    self.total = ko.observable(0).money();

    self.percentFlotillaDiscount = ko.observable(0).money();
    self.TotalFlotillaDiscount = ko.observable(0).money();
    self.totalPrimeFlotillaDiscount = ko.observable(0).money();

    self.FlotillaInfo = ko.observable('');

}