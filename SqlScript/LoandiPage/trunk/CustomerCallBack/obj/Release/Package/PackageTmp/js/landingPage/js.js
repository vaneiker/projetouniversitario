(function($, window) {
    var $ls;
    function autoheight() {
        var max = 0;
        $ls.each(function() {
            $t = $(this);
            $t.css('height','');
            max = Math.max(max, $t.height());
        });
        $ls.height(max);
    }
    $(function() {
        $ls = $('.my-inline-block-class'); // the inline-block selector
        autoheight(); // first time
        $ls.on('load', autoheight); // when images in content finish loading
        $(window).load(autoheight); // when all content finishes loading
        $(window).resize(autoheight); // when the window size changes
    });
})(jQuery, window);