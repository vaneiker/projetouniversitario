(function msg() {
    var url = "";
    ("#dialog-alert").dialog({
        autoOpen: false,
        resizable: false,
        height: 170,
        width: 350,
        show: { effect: 'drop', direction: "up" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close").hide();
        },
        buttons: {
            "OK": function () {
                $(this).dialog("close");

            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });



 ("#dialog-edit").dialog({
        title: ' ',
        autoOpen: false,
        resizable: false,
        width: 'auto',
        show: { effect: 'drop', direction: "center" },
        modal: true,
        draggable: true,
        open: function (event, ui) {
           (".ui-dialog-titlebar-close").hide();
           (this).load(url);
        }
    });

   
("#lnkCreate").live("click", function (e) {
        //e.preventDefault(); //use this or return false
        url = $(this).attr('href');
        $("#dialog-edit").dialog('open');

        return false;
    });
});