$(document).on('ready', function () {
    var $geSpans = $('.checkInToSpan');
    var $geChecks = $geSpans.find('input[type="checkbox"]');

    $geChecks.addClass('refresh_height');

    $geChecks.on('change', function () {
        var $leCheckClicked = $(this);
        var $leDivToShowOrHide = $leCheckClicked.parent().parent().find('div');

        if ($leCheckClicked.is(':checked')) {            
            $leDivToShowOrHide.removeClass('campos');
            $leDivToShowOrHide.addClass('camposShow');
        } else {
            $leDivToShowOrHide.removeClass('camposShow');
            $leDivToShowOrHide.addClass('campos');
        }
    });
});