


var pagination = $('#pagination'),
    totalRecords = 0,
    records = [],
    response = [],
    recPerPage = 5,
    page = 1,
    totalPages = 0;


var location2 = "https://localhost:44397/Restaurant/Restaurant/";
var location3 = "https://localhost:44397/Client/Client/";
var location4 = "https://localhost:44397/Valet/Valet/";

showInPopup = (url, title) => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').show();
        },
        failure: function (response) {
            console.log("failure");
            alert(response.responseText);
        },
        error: function (response) {
            console.log("error");
            alert(response.responseText);
        }
    })
}
$(".close").click(() => {
    $('#form-modal').hide();
})


//====================Pagination============================================================


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

    if (window.location == location2 + "ShowProduct") {
        $(".customtbl .table tbody").empty();

        for (var i = 0; i < response.length; i++) {
            if (response[i].product_Status === true) {
                var data = "<label class='btn btn-success text - white' id='status_" + response[i].product_Id + "' onClick='changeStatus(" + response[i].product_Id + ")' >Active</label>"
            }
            else {
                data = "<label class='btn btn-danger text-white' id='status_" + response[i].product_Id + "' onClick='changeStatus(" + response[i].product_Id + ")'>InActive</label>"
            }
            $('.customtbl .table tbody').append(`<tr ><td data-label="Sr.No" class="col-2">${i + 1}</td><td data-label="Product Name">${response[i].product_Name}</td>
                    <td data-label="Product Price">${response[i].product_Price}</td><td><div class="Stars" style="--rating:${response[i].rate};"></div><br/><div>${response[i].user} Users Rated</div></td><td data-label="Product Status">${data}</td><td><button class="btn btn-primary"  onClick="Update(${response[i].product_Id})"><i class="fa-solid fa-file-pen"></i></button></td></tr>`);
        }
    }
    //else if (window.location == location1 + "ShowRestaurant") {
    //    $(".customtbl .table tbody").empty();
    //    for (i = 0; i < response.length; i++) {

    //        if (response[i].status_by_Admin == true) {
    //            data = `<div><div><input type="checkbox" resid="${response[i].restaurant_Detail_Id}" checked class="switch_1" id="restaurantStatus_${response[i].restaurant_Detail_Id}" onClick="resStatus( ${response[i].restaurant_Detail_Id},' ${response[i].restaurant_Detail_Email} ')"></div></div>`;
    //        }
    //        else {
    //            data = `<div><div><input type="checkbox" class="switch_1" id="restaurantStatus_${response[i].restaurant_Detail_Id}" onClick="resStatus( ${response[i].restaurant_Detail_Id},'${response[i].restaurant_Detail_Email} ')"></div></div>`;
    //        }
    //        $('.customtbl .table tbody').append(`<tr><td data-label="Sr.No">${i + 1}</td><td data-label="Product Name">${response[i].restaurant_Detail_Name}</td>
    //                <td data-label="Product Price" id='Restaurant_Email'>${response[i].restaurant_Detail_Email}</td><td data-label="Product Status">${data}</td></tr>`);
    //    }
    //}
    //else if (window.location == location1 + "ShowUser") {
    //    $(".customtbl .table tbody").empty();
    //    for (var i = 0; i < response.length; i++) {

    //        $('.customtbl .table tbody').append(`<tr><td data-label="User Name">${i + 1}</td><td data-label="User Name" >${response[i].user_FirstName + response[i].user_LastName}</td><td data-label="User Email">${response[i].user_Email}</td>
    //                <td data-label="User Phone No" >${response[i].user_PhoneNo}</td><td><a href='${location1}ShowOrders/${response[i].user_Id}'><label class='btn btn-success text - white'  onClick='ShowDetails()'>Show Details</label></a></td></tr>`);
    //    }
    //}
}

function page1(data) {
    records = data;
    console.log(records);
    totalRecords = records.length;
    totalPages = Math.ceil(totalRecords / recPerPage);
    apply_pagination();
}


$(document).ready(function () {
    $("#pager").hide();
})


$(document).ready(() => {

    if (window.location == location2 + "ShowProduct") {


        $("#pager").show();
        $.ajax({
            url: location2 + `ShowProduct1`,
            success: function (data) {
                console.log(data);
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
    }
})

const changeStatus = (data) => {
    var Status;
    if ($("#status_" + data).html() == "Active") {
        Status = false;
    }
    else
        Status = true;

    $.ajax({
        url: location2 + "ChangeStatus",
        type: "Post",
        data: { ProdId: data, status: Status },
        success: function (response) {
            if (response == "true") {
                if (Status == false) {
                    $("#status_" + data).html("InActive");
                    $("#status_" + data).removeClass("btn btn-success text-white");
                    $("#status_" + data).addClass("btn btn-danger text-white");
                }
                else if (Status == true) {
                    $("#status_" + data).html("Active");
                    $("#status_" + data).removeClass("btn btn-danger text-white");
                    $("#status_" + data).addClass("btn btn-success text-white");
                }
            }
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
}

const Update = (Id) => {

    window.location.href = location2 + `EditProduct/${Id}`
}


$("#Name").autocomplete({

    maxShowItems: 5,

    source: function (request, response) {

        $.ajax({
            url: location2 + "myProduct",
            type: "POST",
            dataType: "json",
            data: { Prefix: request.term },
            success: function (data) {
                var data2 = JSON.parse(data);
                response($.map(data2, function (item) {
                    return item;
                }))

            },
            failure: function (response) {
                console.log("failure");
                alert(response.responseText);
            },
            error: function (response) {
                console.log("error");
                alert(response.responseText);
            }
        })

    },
    messages: {
        noResults: "", results: ""
    }
});

$("#btnSearch").click(function () {

    $("#pager").show();

    var id = document.getElementById("Drop").value;
    var name = document.getElementById("Name").value;
    $.ajax({
        url: location2 + `ShowProduct1`,
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

var toastMixin = Swal.mixin({
    toast: true,
    icon: "success",
    title: "General Title",
    animation: false,
    position: "top-right",
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener("mouseenter", Swal.stopTimer);
        toast.addEventListener("mouseleave", Swal.resumeTimer);
    }
});









/*=============================================================================================================================================*/






/*======================================================Customer========================================================================================================== */