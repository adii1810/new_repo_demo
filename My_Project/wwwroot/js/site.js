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
var location1 = "https://localhost:44397/Admin/Admin/";

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

$(document).ready(function () {
    $("#pager").hide();
})

$("#btnSearch").click(function () {

    $("#pager").show();
    var id = document.getElementById("Drop").value;
    var name = document.getElementById("Name").value;
    var $pagination = $('#pagination'),
        totalRecords = 0,
        records = [],
        response = [],
        recPerPage = 5,
        page = 1,
        totalPages = 0;
    $.ajax({
        url: `/Admin/Admin/ShowProduct1`,
        type: "Post",
        data: { Drop: id, Name: name },

        success: function (mydata) {
            records = mydata;
            console.log(records);
            totalRecords = records.length;
            totalPages = Math.ceil(totalRecords / recPerPage);
            apply_pagination();
        },
        failure: function (response) {
            console.log("failure")

            alert(response.responseText);
        },
        error: function (response) {
            console.log("error")

            alert(response.responseText);
        }
    });
    function generate_table() {
        var tr;
        $(".customtbl .table tbody").empty();

        for (var i = 0; i < response.length; i++) {
            if (response[i].product_Status === true) {
                var data = "<label class='btn btn-success text - white'>Active</label>"
            }
            else {
                data = "<label class='btn btn-danger text-white'>InActive</label>"
            }
            $('.customtbl .table tbody').append(`<tr><td data-label="Product Id">${response[i].product_Id}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td><div class="Stars" style="--rating:${response[i].rate};"></div><br/><div>${response[i].user} Users Rated</div></td><td data-label="Product Status">${data}</td></tr>`);
        }
    }

    function apply_pagination() {

        if ($('#pagination').data("twbs-pagination"))
            $('#pagination').twbsPagination('destroy');

        $pagination.twbsPagination({
            totalPages: totalPages,
            visiblePages: 6,
            onPageClick: function (event, page) {
                displayRecordsIndex = Math.max(page - 1, 0) * recPerPage;
                endRec = (displayRecordsIndex) + recPerPage;

                response = records.slice(displayRecordsIndex, endRec);
                generate_table();
            }
        });
    }

});

$(document).ready(() => {
    if (window.location == location1 + "ShowProduct") {

        $("#pager").show();
        var $pagination = $('#pagination'),
            totalRecords = 0,
            records = [],
            response = [],
            recPerPage = 5,
            page = 1,
            totalPages = 0;
        $.ajax({
            url: `/Admin/Admin/ShowProduct1`,

            success: function (data) {
                records = data;
                console.log(records);
                totalRecords = records.length;
                totalPages = Math.ceil(totalRecords / recPerPage);
                apply_pagination();
            }
        });
        function generate_table() {

            $(".customtbl .table tbody").empty();

            for (var i = 0; i < response.length; i++) {
                if (response[i].product_Status === true) {
                    var data = "<label class='btn btn-success text - white'>Active</label>"
                }
                else {
                    data = "<label class='btn btn-danger text-white'>InActive</label>"
                }
                $('.customtbl .table tbody').append(`<tr><td data-label="Product Id">${response[i].product_Id}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td><div class="Stars" style="--rating:${response[i].rate};"></div><br/><div>${response[i].user} Users Rated</div></td><td data-label="Product Status">${data}</td></tr>`);
            }
        }

        function apply_pagination() {

            if ($('#pagination').data("twbs-pagination"))
                $('#pagination').twbsPagination('destroy');

            $pagination.twbsPagination({
                totalPages: totalPages,
                visiblePages: 6,
                onPageClick: function (event, page) {
                    displayRecordsIndex = Math.max(page - 1, 0) * recPerPage;
                    endRec = (displayRecordsIndex) + recPerPage;

                    response = records.slice(displayRecordsIndex, endRec);
                    generate_table();
                }
            });
        }
    }
});



$(document).ready(() => {
    if (window.location == location1 + "ShowRestaurant") {
        $("#pager").show();
        
        var $pagination = $('#pagination');
        var totalRecords = 0;
        var records = [];
        var response = [];
        var recPerPage = 5;
        var page = 1;
        var totalPages = 0;

     
        $.ajax({
            url: `/Admin/Admin/ShowRestaurant1`,
            type:"Get",
            success: function (data) {
                console.log(data);
                records = data;
                console.log(records);
                totalRecords = records.length;
                totalPages = Math.ceil(totalRecords / recPerPage);
                apply_pagination();
            }
        });


        function generate_table() {

            $(".customtbl .table tbody").empty();

            for (var i = 0; i < response.length; i++) {

                alert(typeof response[i].restaurant_Detail_Email)
                if (response[i].status_by_Admin == true) {
                    var data = `<div><div><input type="checkbox" checked class="switch_1" id="restaurantStatus" onClick="resStatus( ${response[i].restaurant_Detail_Id},' ${ response[i].restaurant_Detail_Email } ')"></div></div>`;
                    alert(data);
                }
                else {
                    data = `<div><div><input type="checkbox" class="switch_1" id="restaurantStatus" onClick="resStatus( ${response[i].restaurant_Detail_Id},'${response[i].restaurant_Detail_Email} ')"></div></div>`;
                    }
                $('.customtbl .table tbody').append(`<tr><td data-label="Product Id">${response[i].restaurant_Detail_Id}</td><td data-label="Product Name">${response[i].restaurant_Detail_Name}</td>
                    <td data-label="Product Price" id='Restaurant_Email'>${response[i].restaurant_Detail_Email}</td></td><td data-label="Product Status">${data}</td></tr>`);
            }
        }

        function apply_pagination() {

            if ($('#pagination').data("twbs-pagination"))
                $('#pagination').twbsPagination('destroy');

            $pagination.twbsPagination({
                totalPages: totalPages,
                visiblePages: 6,
                onPageClick: function (event, page) {
                    displayRecordsIndex = Math.max(page - 1, 0) * recPerPage;
                    endRec = (displayRecordsIndex) + recPerPage;

                    response = records.slice(displayRecordsIndex, endRec);
                    generate_table();
                }
            });
        }
    }


});

$("#restaurantStatus").click(function(){
    debugger;
    var data = document.getElementById("restaurantStatus");
    console.log(data);
    alert(data);
});

function resStatus(value,email) {
   
    debugger;
    const statusFunction = (status) => {
        $.ajax({
            url: `/Admin/Admin/UpdateStatus`,
            type: "Post",
            data: { Status: status,Id:value ,Email:email },
            success: function (response) {
                alert("Update Success");
            }
        });
    }
    if ($('#restaurantStatus').prop('checked')) {
        statusFunction(true);
       
    }
    else {
       // $('#restaurantStatus').prop('checked', false);
        statusFunction(false);
    }
    console.log(data);
   // alert(data);
}



