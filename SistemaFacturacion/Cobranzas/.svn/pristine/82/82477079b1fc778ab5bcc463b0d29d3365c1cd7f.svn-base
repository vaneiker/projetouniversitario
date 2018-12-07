(function () {
    var format = function (value, showCurrency) {
        var output = showCurrency ? "$0.00" : "0.00";
        if (value && !isNaN(value)) {
            var toks = value.toFixed(2).replace('-', '').split('.');
            var display = showCurrency ? '$' : "";
            display += $.map(toks[0].split('').reverse(), function (elm, i) {
                return [(i % 3 === 0 && i > 0 ? ',' : ''), elm];
            }).reverse().join('') + '.' + toks[1];
            output = value < 0 ? '-' + display : display;
        }

        return output;
    };

    ko.subscribable.fn.money = function () {
        var target = this;

        var writeTarget = function (value) {

            var stripped = "0.0";
            if (value) {
                if (value.replace) {
                    stripped = value
                        .replace(/[^0-9.-]/g, '');
                    if (isNaN(stripped))
                        stripped = "0.0";
                }
                else
                    stripped = value;
            }
            target(parseFloat(stripped));
        };

        var result = ko.computed({
            read: function () {
                return target();
            },
            write: writeTarget
        });

        result.formatted = ko.computed({
            read: function () {
                return format(target(), false);
            },
            write: writeTarget
        });

        result.currencyformatted = ko.computed({
            read: function () {
                return format(target(), true);
            },
            write: writeTarget
        });

        result.isNegative = ko.computed(function () {
            return target() < 0;
        });

        return result;
    };
})();