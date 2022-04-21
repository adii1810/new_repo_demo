


var pagination = $('#pagination'),
    totalRecords = 0,
    records = [],
    response = [],
    recPerPage = 5,
    page = 1,
    totalPages = 0;


var location2 = "https://localhost:44397/Restaurant/Restaurant/";
var location3 = "https://localhost:44397/Client/Client/";

showInPopup = (url, title) => {

    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').show();
        }
    })
}

$('.close').click(() => {
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
                    <td data-label="Product Price">${response[i].product_Price}</td><td><div class="Stars" style="--rating:${response[i].rate};"></div><br/><div>${response[i].user} Users Rated</div></td><td data-label="Product Status">${data}</td><td><button class="btn btn-primary"  onClick="Update(${response[i].product_Id})"><i class="fa-solid fa-file-pen"></i></button><button class="btn btn-danger"><i class="fa-solid fa-trash-can"></i></button></td></tr>`);
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
            }
        });
    }
})

const changeStatus = (data) => {
    var Status;
    if ($("#status_" + data).html() == "Active") {
        alert("true");
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
        }

    });
}

const Update = (Id) => {

    window.location.href = location2 + `EditProduct/${Id}`
}


$("#Name").autocomplete({

    maxShowItems: 3,

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

/*======================================================Customer========================================================================================================== */


/*======================================================Pagination=========================================================================================================*/
var state = {
    'querySet': null,
    'page': 1,
    'rows': 10,
    'window': 5
}

function Custpagination(querySet, page, rows) {
    var trimStart = (page - 1) * rows;
    var trimEnd = trimStart + rows;
    var trimmedData = querySet.slice(trimStart, trimEnd);
    var pages = Math.ceil(querySet.length / rows);
    return {
        'querySet': trimmedData,
        'pages': pages
    }

}

function pageButton(pages) {
    var wrapper = document.getElementById('pagination-wrapper');
    wrapper.innerHTML = ""
    var maxLeft = (state.page - Math.floor(state.window / 2));
    var maxRight = (state.page - Math.floor(state.window / 2));
    if (maxLeft < 1) {
        maxLeft = 1;
        maxRight = state.window;
    }
    if (maxRight > pages) {
        maxLeft = pages - (state.window - 1);
        maxRight = pages;
        if (maxLeft < 1) {
            maxLeft = 1;
        }
    }
    for (var page = maxLeft; page <= maxRight; page++) {
        wrapper.innerHTML += `<button value=${page} class="page btn btn-sm btn-warning text-white">${page}</button>`
    }
    if (state.page != 1) {
        wrapper.innerHTML = `<button value="${state}" class="page btn btn-sm btn-warning text-white">&#171; First</button>` + wrapper.innerHTML;
    }
    if (state.page != pages) {
        wrapper.innerHTML += `<button value="${pages}" class="page btn btn-sm btn-warning text-white"> Last &#187;</button>`;
    }

    $('.page').click(function () {

        state.page = $(this).val();
        buildTable();
    })
}
function buildTable(str) {
    var data = Custpagination(state.querySet, state.page, state.rows);
    console.log(data);
    var myData = data.querySet
    $(`#${str} #product`).empty();
    for (var i = 0; i < myData.length; i++) {
        $(`#${str} #product`).append(` <div class="col-lg-6" onclick="getProductId(${myData[i].product_Id})" >
                            <div class="d-flex align-items-center">
                                <img class="flex-shrink-0 img-fluid rounded" src="${myData[i].imgLink}" style="max-width: 3.5rem;" >
                                <div class="w-100 d-flex flex-column text-start ps-4">
                                    <h5 class="d-flex justify-content-between border-bottom pb-2">
                                        <span>${myData[i].product_Name}</span>
                                        <span class="text-primary">${myData[i].product_Price}</span>
                                    </h5>
                                    <small class="fst-italic d-flex justify-content-between">${myData[i].description}
                                    <span class="text-primary" id="btnchange_${myData[i].product_Id}"><button class="btn btn-warning text-white" onclick="AddProduct(${myData[i].product_Id})" id="btn_${myData[i].product_Id}">Add</button></span></small>
                                </div>
                            </div>
                        </div>`);
    }
    pageButton(data.pages);
}


/*======================================================Pagination=========================================================================================================*/

$("#tab1").click(() => {
    if (window.location == location3 + "CustomerIndex") {
        $("#tab1").addClass("active")
        $("#tab2").removeClass("active")
        $("#tab3").removeClass("active")
        $("#tab-1").addClass("active")
        $("#tab-2").removeClass("active")
        $("#tab-3").removeClass("active")
        $.ajax({
            url: location3 + "ShowProduct",
            type: "Get",
            data: { Tab: "tab1" },
            success: (response) => {
                state.querySet = response;
                buildTable("tab-1")
                console.log(response)
            }
        })
    }
})
$("#tab2").click(() => {
    if (window.location == location3 + "CustomerIndex") {
        $("#tab2").addClass("active")
        $("#tab1").removeClass("active")
        $("#tab3").removeClass("active")
        $("#tab-2").addClass("active")
        $("#tab-1").removeClass("active")
        $("#tab-3").removeClass("active")
        $.ajax({
            url: location3 + "ShowProduct",
            type: "Get",
            data: { Tab: "tab2" },
            success: (response) => {
                state.querySet = response;
                buildTable("tab-2")
                console.log(response)
            }
        })
    }
})
$("#tab3").click(() => {
    if (window.location == location3 + "CustomerIndex") {
        $("#tab3").addClass("active")
        $("#tab1").removeClass("active")
        $("#tab2").removeClass("active")
        $("#tab-3").addClass("active")
        $("#tab-1").removeClass("active")
        $("#tab-2").removeClass("active")
        $.ajax({
            url: location3 + "ShowProduct",
            type: "Get",
            data: { Tab: "tab3" },
            success: (response) => {
                state.querySet = response;
                buildTable("tab-3")
                console.log(response)
            }
        })
    }
})

function getProductId(id) {
    //alert(id);
}
const AddProduct = (id) => {
    alert(id)
    $("#btn_" + id).remove();
    //Add product to cart
    $.ajax({
        url: location3 + "AddProductCart",
        type: "Post",
        data: { prodId: id },
        success: (response) => {
            if (response == "true") {
                $("#btnchange_" + id).append(`<button class="btn btn-warning text-white" onclick="funcCheckout(${id})" id="btn_${id}">Checkout</button>`);
            }
            else {
                $("#btnchange_" + id).append(`<button class="btn btn-warning text-white" onclick="AddProduct(${id})" id="btn_${id}">Add</button>`);
            }
        }
    })
}


    //$('button').click(function (event) {
    //    console.log(event)
    //    alert(event.target.id);
    //});

//<button class= 'btn btn-warning btn-sm' > <i class='bi bi-dash'></i></button ><input type='text'  maxlength='1' size='1' /><button class='btn btn-warning btn-sm'><i class='bi bi-plus'></i></button>");



/*======================================================Customer========================================================================================================== */