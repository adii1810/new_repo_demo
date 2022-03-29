// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//showInPopup = (url, title) => {
//    alert("hello");
//    $.ajax({
//        type: 'GET',
//        url: url,
//        success: function (res) {
//            $('#form-modal .modal-body').html(res);
//            $('#form-modal .modal-title').html(title);
//            $('#form-modal').modal('show');
//        }
//    })
//}

$("#Name").autocomplete({
    maxShowItems: 1,
        source: function (request, response) {
        $.ajax({
            url: "/Admin/Admin/myResturant",
            type: "POST",
            dataType: "json",
            data: { Prefix: request.term },
            success: function (data) {
                var data2 = JSON.parse(data);
                console.log(typeof (data2));
                console.log(data2);
                response($.map(data2, function (item) {
                    return item;
                }))

            }
        })
    },
    messages: {
        noResults: "", results: ""
        }
});

$("#btnSearch").click(function(){
  
    
        var id = document.getElementById("Drop");
        var name = document.getElementById("Name");
        $.ajax({
            url: "/Admin/Admin/ShowProduct",
            type: "POST",
            dataType: "json",
            data: { mainId: id, Name: name },
            success: function(data) {
                console.log(typeof (data));
            }
        })
    
});