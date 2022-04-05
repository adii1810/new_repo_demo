// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var location1 = "https://localhost:44397/Admin/Admin/";

//====================Pagination============================================================

var pagination = $('#pagination'),
    totalRecords = 0,
    records = [],
    response = [],
    recPerPage = 5,
    page = 1,
    totalPages = 0;

function apply_pagination() {

    if ($('#pagination').data("twbs-pagination"))
        $('#pagination').twbsPagination('destroy');

    pagination.twbsPagination({
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

function generate_table() {

    if (window.location == location1 + "ShowProduct") {
        $(".customtbl .table tbody").empty();

        for (var i = 0; i < response.length; i++) {
            if (response[i].product_Status === true) {
                var data = "<label class='btn btn-success text - white'>Active</label>"
            }
            else {
                data = "<label class='btn btn-danger text-white'>InActive</label>"
            }
            $('.customtbl .table tbody').append(`<tr ><td data-label="Sr.No" class="col-2">${i+1}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td><div class="Stars" style="--rating:${response[i].rate};"></div><br/><div>${response[i].user} Users Rated</div></td><td data-label="Product Status">${data}</td></tr>`);
        }
    }
    else if (window.location == location1 + "ShowRestaurant") {
        $(".customtbl .table tbody").empty();
        for ( i = 0; i < response.length; i++) {

            if (response[i].status_by_Admin == true) {
                 data = `<div><div><input type="checkbox" resid="${response[i].restaurant_Detail_Id}" checked class="switch_1" id="restaurantStatus_${response[i].restaurant_Detail_Id}" onClick="resStatus( ${response[i].restaurant_Detail_Id},' ${response[i].restaurant_Detail_Email} ')"></div></div>`;
            }
            else {
                data = `<div><div><input type="checkbox" class="switch_1" id="restaurantStatus_${response[i].restaurant_Detail_Id}" onClick="resStatus( ${response[i].restaurant_Detail_Id},'${response[i].restaurant_Detail_Email} ')"></div></div>`;
            }
            $('.customtbl .table tbody').append(`<tr><td data-label="Sr.No">${i+1}</td><td data-label="Product Name">${response[i].restaurant_Detail_Name}</td>
                    <td data-label="Product Price" id='Restaurant_Email'>${response[i].restaurant_Detail_Email}</td><td data-label="Product Status">${data}</td></tr>`);
        }
    }
    else if (window.location == location1 + "ShowUser") {
        $(".customtbl .table tbody").empty();
        for (var i = 0; i < response.length; i++) {

            $('.customtbl .table tbody').append(`<tr><td data-label="User Name">${i + 1}</td><td data-label="User Name" >${response[i].user_FirstName + response[i].user_LastName}</td><td data-label="User Email">${response[i].user_Email}</td>
                    <td data-label="User Phone No" >${response[i].user_PhoneNo}</td><td><a href='${location1}ShowOrders/${response[i].user_Id}'><label class='btn btn-success text - white'  onClick='ShowDetails()'>Show Details</label></a></td></tr>`);
        }
    }
}

function page1(data) {
    records = data;
    console.log(records);
    totalRecords = records.length;
    totalPages = Math.ceil(totalRecords / recPerPage);
    apply_pagination();
}

//======================================================================================================

// Function for showing Order Details

$("#UserName").autocomplete({

    maxShowItems: 3,
    source: function (request, response) {
    $.ajax({
        url: location1 + "myUser",
        type: "POST",
        dataType: "json",
        data: { Prefix: request.term },
        success: function (data) {
            var data2 = JSON.parse(data);
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


$("#Name").autocomplete({
   
    maxShowItems: 3,
    
    source: function (request, response) {
            $.ajax({
                url: location1 + "myResturant",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    var data2 = JSON.parse(data);
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
    $.ajax({
        url: location1 + `ShowProduct1`,
        type: "Post",
        data: { Drop: id, Name: name },
        success: function (data) {
            if (data.length == 0) {
                $(".customtbl .table tbody").empty();
            }
            page1(data);
        },
        failure: function (response) {
            console.log("failure");
            alert(response.responseText);
        },
        error: function (response) {
            console.log("error");
            alert(response.responseText);
        }
    });
});

$("#btnSearchUser").click(function () {

    $("#pager").show();
   
    var name = document.getElementById("UserName").value;
    $.ajax({
        url: location1 + `FindUser`,
        type: "Post",
        data: { Name: name },
        success: function (data) {
                $(".customtbl .table tbody").empty();
            page1(data);
        },
        failure: function (response) {
            console.log("failure");
            alert(response.responseText);
        },
        error: function (response) {
            console.log("error");
            alert(response.responseText);
        }
    });
});
$("#btnSearchRestaurant").click(function () {

    $("#pager").show();

    var name = document.getElementById("Name").value;
    $.ajax({
        url: location1 + `FindRestaurant`,
        type: "Post",
        data: { Name: name },
        success: function (data) {
            $(".customtbl .table tbody").empty();
            page1(data);
        },
        failure: function (response) {
            console.log("failure");
            alert(response.responseText);
        },
        error: function (response) {
            console.log("error");
            alert(response.responseText);
        }
    });
});


$(document).ready(() => {
    if (window.location == location1 + "ShowProduct") {
        $("#pager").show();
        $.ajax({
            url: location1 + `ShowProduct1`,

            success: function (data) {
                page1(data);
            }
        });
    }
});

$(document).ready(() => {
    if (window.location == location1 + "ShowRestaurant") {
        $("#pager").show();

        $.ajax({
            url: location1 + `ShowRestaurant1`,
            type: "Get",
            success: function (data) {
                console.log(data);
                page1(data);
            }
        });
    }
});

$(document).ready(() => {
    if (window.location == location1 + "ShowUser") {
        $("#pager").show();

        $.ajax({
            url: location1 + `ShowUser1`,
            type: "Get",
            success: function (data) {
                console.log(data);
                page1(data);
            }
        });
    }
});

$('a.pagerlink').click(function () {
    var id = $(this).attr('id');
    $container.cycle(id.replace('#', ''));
    return false;
});

function resStatus(value, email) {
    $('#restaurantStatus_' + value).addClass('lds-dual-ring');
    const statusFunction = (status) => {
        $.ajax({
            url: location1 + `UpdateStatus`,
            type: "Post",
            data: { Status: status, Id: value, Email: email },
            success: function (response) {
                $('#restaurantStatus_' + value).removeClass('lds-dual-ring');
                alert("Update Success");
            }
        });
    }
    if ($('#restaurantStatus_' + value).prop('checked')) {
        statusFunction(true);
    }
    else {
        statusFunction(false);
    }
    //console.log(data);
}



