<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
<link rel="stylesheet" href="/resources/demos/style.css"> 
 

Buscar : <input type="text" id="autocomplete" />
 
<script src="~/Scripts/jquery-3.3.1.js"></script>
<script src="~/Scripts/jquery-ui-1.12.1.js"></script>
<script src="~/Scripts/Home.js"></script>

<script> 
$(document).ready(function () {
    $("#autocomplete").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Home/GetContacts",
                data: JSON.stringify({ searchString: $.trim($("#autocomplete").val()) }),
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                beforeSend: function () {
                    //$("#txtABANumber").css("background-repeat", "no-repeat");
                    //$("#txtABANumber").css("background-position", "right");
                    //$("#txtABANumber").css("background-image", "url('../../images/ui-anim_basic_16x16.gif')");
                },
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.Nombre,
                            id: item.Id
                        };
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(textStatus);
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
             alert('Usted selecciono el id = ' + ui.item.id);
            
        },
        response: function (event, ui) {
            var len = ui.content.length;
        },
        delay: 5
    }).on('keyup', function (event) {
       
    });
});
</script>
