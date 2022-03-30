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

$(document).ready(() => {
    $.ajax({
        url: `/Admin/Admin/ShowProduct1`,
        type: "Get",
        //data: { Drop: id, Name: name },
        success: function (response) {
            console.log(response);
           
            $(".customtbl .table tbody").empty();
            for (var i = 0; i < response.length; i++) {
                if (response[i].product_Status === true) {
                    var data = "<label class='btn btn-success text - white'>Active</label>"
                }
                else {
                    data = "<label class='btn btn-danger text-white'>InActive</label>"
                }
                $('.customtbl .table tbody').append(`<tr><td data-label="Product Id">${response[i].product_Id}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td data-label="Product Status">${data}</td></tr>`);
            }
           
        },
        failure: function (response) {
            console.log("failure")

            alert(response.responseText);
        },
        error: function (response) {
            console.log("error")

            alert(response.responseText);
        }
    })

})

$("#btnSearch").click(function(){
        var id = document.getElementById("Drop").value;
    var name = document.getElementById("Name").value;
    //api/Adminapi/Showproduct/{MyDrop}/{restaurant_Name}
    //`Admin/Admin/ShowProduct1/${id}/${name}`
        $.ajax({
            url: `/Admin/Admin/ShowProduct1`,
            type: "Post",
            data: {Drop : id,Name : name},
           // dataType: "json",
            success: function (response) {
                console.log(response);
                //$(response).each(function () {
                //    $("#table1 tr").each(function () {
                //        this.show();
                //    })
                //})
                $(".customtbl .table tbody").empty();
                for (var i = 0; i < response.length; i++) {
                    if (response[i].product_Status === true) {
                        var data = "<label class='btn btn-success text - white'>Active</label>"
                    }
                    else {
                        data = "<label class='btn btn-danger text-white'>InActive</label>"
                    }
                    $('.customtbl .table tbody').append(`<tr><td data-label="Product Id">${response[i].product_Id}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td data-label="Product Status">${data}</td></tr>`);
                }
                //$(response).each(function () {
                //    console.log(this.product_Name);
                //    $("#product_Id").html(this.product_Id);
                //    $("#product_Name").html(this.product_Name);
                //    $("#product_Price").html(this.product_Price);
                //    $("#product_Description").html(this.description);
                //    $("#product_Status").html(this.product_Status);

                //})
            },
            failure: function (response) {
                console.log("failure")

                alert(response.responseText);
            },
            error: function (response) {
                console.log("error")

                alert(response.responseText);
            }
        })
    
});
