function pagingQuotationViewModel() {
    var self = this;

    self.agentList = ko.observableArray();
    self.operatorList = ko.observableArray(['=', '>', '<']);
    self.quotationsList = ko.observableArray();
    self.currencyList = ko.observableArray();
    self.principalNameList = ko.observableArray();
    self.quotationDateList = ko.observableArray();
    self.businessLineList = ko.observableArray();
    self.planList = ko.observableArray();
    self.selectedQuotationId = ko.observable();
    self.identificationList = ko.observableArray();

    self.AgentQuotationList = ko.observableArray();

    self.agent = ko.observable();
    //self.agent(ko.utils.arrayFirst(self.agentList, function (item) { return item.NameId === self.filter.agentNameId }));

    self.pageSize = ko.observable();
    self.totalRegisters = ko.observable();
    self.currentPage = ko.observable();
    self.registers = ko.observableArray();
    self.currentPage = ko.observable();

    self.filter = {
        agentNameId: ko.observable(),
        quotationId: ko.observable(),
        identification: ko.observable(),
        principalName: ko.observable(),
        quotationDate: ko.observable(),
        businessLine: ko.observable(),
        plan: ko.observable(),
        currency: ko.observable(),
        annualPrime: ko.observable(),
        taxes: ko.observable(),
        total: ko.observable(),
        currentPage: ko.observable(),
        pageSize: ko.observable(),
        primeOperatorSelected: ko.observable(),
        taxesOperatorSelected: ko.observable(),
        totalOperatorSelected: ko.observable(),
        currentUserName: document.getElementById("currentUserName").value,
        AgentQuotationNameID: ko.observable()
    }

    self.filter.agentNameId.subscribe(function (value) {
        self.refresh();
    });
    self.filter.quotationId.subscribe(function (value) {
        self.refresh();
    });
    self.filter.identification.subscribe(function (value) {
        self.refresh();
    });
    self.filter.principalName.subscribe(function (value) {
        self.refresh();
    });
    self.filter.quotationDate.subscribe(function (value) {
        self.refresh();
    });
    self.filter.businessLine.subscribe(function (value) {
        self.refresh();
    });
    self.filter.plan.subscribe(function (value) {
        self.refresh();
    });
    self.filter.currency.subscribe(function (value) {
        self.refresh();
    });
    self.filter.annualPrime.subscribe(function (value) {
        self.refresh();
    });
    self.filter.taxes.subscribe(function (value) {
        self.refresh();
    });
    self.filter.total.subscribe(function (value) {
        self.refresh();
    });

    self.filter.primeOperatorSelected.subscribe(function (value) {
        self.refresh();
    });

    self.filter.taxesOperatorSelected.subscribe(function (value) {
        self.refresh();
    });

    self.filter.totalOperatorSelected.subscribe(function (value) {
        self.refresh();
    });

    self.filter.AgentQuotationNameID.subscribe(function (value) {
        self.refresh();
    });

    self.totalPages = ko.computed(function () {
        if (self.pageSize() > 0) {
            return Math.ceil(self.totalRegisters() / self.pageSize());
        }
        else
            return 0;
    });

    self.newPageNumberShow = ko.observable();

    function LimitOfNumberPages() {
        if (self.totalPages() && self.totalPages() < 10) {
            var eree = self.totalPages();
            return eree;
        } else if (self.totalPages()) {
            return 10;
        }
    };

    self.firstCharge = ko.observable(true);

    self.lastCurrentPage = ko.observable(0);

    self.pagesList = ko.computed(function () {
        var list = new Array();

        if (self.firstCharge() && self.totalPages()) {

            self.newPageNumberShow(LimitOfNumberPages());
            self.firstCharge(false);
        }
        var newPageNumberShow = self.newPageNumberShow();

        for (var i = 0; i < newPageNumberShow; i++) {
            list.push(i + 1);
        }
        return list;

        //ORIGINAL 24-08-2017
        //var list = new Array();
        //for (var i = 0; i < self.totalPages() ; i++)
        //    list.push(i + 1);
        //return list;
    });

    self.moveNext = function () {

        if (self.currentPage() < self.totalPages() - 1) {
            newCurrentPage = self.currentPage() + 1;
            self.setCurrentPage(newCurrentPage);


            var d = self.newPageNumberShow() + 1;
            self.newPageNumberShow(d);

            self.lastCurrentPage(newCurrentPage);
        }
    }

    self.movePrev = function () {
        if (self.currentPage() > 0) {
            newCurrentPage = self.currentPage() - 1;
            self.setCurrentPage(newCurrentPage);

            if (self.newPageNumberShow() >= LimitOfNumberPages()) {
                var d = self.newPageNumberShow() - 1;
                self.newPageNumberShow(d);
            }

            self.lastCurrentPage(newCurrentPage);
        }
    }

    self.setCurrentPage = function (newCurrentPage) {

        if (newCurrentPage < self.totalPages() - 1) {

            var lastCurrentPage = self.lastCurrentPage();

            if (newCurrentPage > lastCurrentPage) {
                var d = self.newPageNumberShow() + 1;
                self.newPageNumberShow(d);
                self.lastCurrentPage(newCurrentPage);
            }

            if (newCurrentPage < lastCurrentPage) {

                if (self.newPageNumberShow() > LimitOfNumberPages()) {
                    var d = self.newPageNumberShow() - 1;
                    self.newPageNumberShow(d);
                    self.lastCurrentPage(newCurrentPage);
                }
            }
        }

        self.currentPage(newCurrentPage);
        self.refresh();
    };

    self.redirect = function () {
        if (self.selectedQuotationId())
            window.location = '/Home/SelectQuotationByFilter?quotationId=' + self.selectedQuotationId();
        else
            showError(["Debe seleccionar una cotización"], "Buscar cotización");
    }

    self.refresh = function () {
        
        if (self.currentPage() >= 0) {
            self.filter.currentPage(self.currentPage());
            self.filter.pageSize(self.pageSize());          

            $.ajax({
                url: "/Home/GetQuotations",
                method: 'GET',
                dataType: 'json',
                async: false,
                data: ko.toJS(self.filter),
                success: function (data) {
                    self.currentPage(data.currentPage);
                    self.totalRegisters(data.totalRegisters);
                    self.registers(data.registers);
                    self.selectedQuotationId(null);
                },
                error: function () {
                    //self.currentRate(0);
                }
            });
        }
        else
            self.registers([]);        
    }
}

$(document).ready(function () {

    ////ajaxloader
    //$(document).ajaxStart(function () {
    //    $("#ajaxLoader").show();
    //});
    //$(document).ajaxStop(function () {
    //    $("#ajaxLoader").hide();
    //});

    var model = new pagingQuotationViewModel();
    model.pageSize(10);

    //ko.applyBindings(model);    var bindDiv = document.getElementById("divBody");    ko.applyBindings(model, bindDiv);

    $.getJSON('/Home/GetFilterLists', { currentUserName: document.getElementById("currentUserName").value }, function (data) {
        //ko.utils.arrayForEach(data.agentList, function (item) {
        //    item.Name = (item.LastName + ' ' + item.FirstName).trim();
        //});

        //ko.utils.arrayForEach(data.agentList, function (item) {
        //    //console.log(item);
        //    item.FullNameAll = (item.FullNameAll).trim();
        //});

        model.agentList(data.agentList);
        model.quotationsList(data.quotationList);
        model.principalNameList(data.principalNameList);
        model.quotationDateList(data.quotationDateList);
        model.currencyList(data.currencyList);
        model.businessLineList(data.businessLineList);
        model.planList(data.planList);
        model.identificationList(data.identificationList);
        model.setCurrentPage(0);

        model.AgentQuotationList(data.AgentQuotationList);
    });

    var widget = $('.ui-autocomplete')[0];
    var width = $('#quotNumberFilter').width();
    $(widget).css('width', width + "px");


    $(document).on("click", ".declinedQuotCheck", function () {
        var ck = $(".declinedQuotCheck:checked").length;
        if (ck > 0) {
            $(".declinedButton").removeAttr("disabled");
        } else {
            $(".declinedButton").attr("disabled", "disabled");
        }
    });


    $(document).on("click", ".declinedButton", function () {
        var btn = $(this);

        showQuestion("Declinar Cotización", "¿Está seguro que desea declinar la(s) Cotizaciónes seleccionadas?",
                               function () {


                                   //mi funcion
                                   var quotationID = 0;
                                   $('.declinedQuotCheck:checked').each(function () {
                                       quotationID += $(this).val() + ",";
                                   });

                                   declinedQuotations(quotationID);
                                   return;
                               });
    });



    function declinedQuotations(quotationID) {
        if (quotationID !== '') {

            $.ajax({
                url: "/Home/SetDeclinedQuotations",
                data: {
                    quotationID: quotationID
                },
                success: function (data) {
                    if (data.sucess) {
                        //showSuccess("Declinar Cotización", data.message);
                        window.location.reload();
                    } else {
                        showError(["Una o más Cotizaciones no fueron declinadas."], "Declinar Cotización");
                    }
                }
            });

        }
    }


});


function isempty(filter) {

    if (!$('#agentId').val()) {

        filter.agentNameId(null);
    }
}