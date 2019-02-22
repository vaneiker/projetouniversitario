function DetailsModal(btn, url) {
    ShowModal(btn, url)
}

function EditModal(btn, url) {
    ShowModal(btn, url)
}
 
function DeleteModal(btn, url) {
    ShowModal(btn, url)
}
function CreateModal(btn, url) {
    ShowModalPopup(btn, url)
}


function ShowModal(btn, url) {
    var $buttonClicked = $(btn);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: { "Id": id },
        datatype: "json",
        success: function (data) {
            //debugger;
            $('#myModalContent').html(data);
            $('#myModal').modal(options);
            $('#myModal').modal('show');

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}
function ShowModalPopup(btn, url) {
    var $buttonClicked = $(btn);
    var id = $buttonClicked.attr('data-id');
    var options = { "backdrop": "static", keyboard: true };
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
      //  data: { "Id": id },
        datatype: "json",
        success: function (data) {
            //debugger;
            $('#myModalContent').html(data);
            $('#myModal').modal(options);
            $('#myModal').modal('show');

        },
        error: function () {
            alert("Dynamic content load failed.");
        }
    });
}
 