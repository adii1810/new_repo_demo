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

/*======================================================Customer========================================================================================================== */


/*======================================================Pagination=========================================================================================================*/
//var state = {
//    'querySet': null,
//    'page': 1,
//    'rows': 2,
//    'window': 5
//}

//function Custpagination(querySet, page, rows) {
//    var trimStart = (page - 1) * rows;
//    var trimEnd = trimStart + rows;
//    var trimmedData = querySet.slice(trimStart, trimEnd);
//    var pages = Math.ceil(querySet.length / rows);
//    return {
//        'querySet': trimmedData,
//        'pages': pages
//    }

//}

//function pageButton(pages) {
//    var wrapper = document.getElementById('pagination-wrapper');
//    wrapper.innerHTML = ""
//    var maxLeft = (state.page - Math.floor(state.window / 2));
//    var maxRight = (state.page - Math.floor(state.window / 2));
//    if (maxLeft < 1) {
//        maxLeft = 1;
//        maxRight = state.window;
//    }
//    if (maxRight > pages) {
//        maxLeft = pages - (state.window - 1);
//        maxRight = pages;
//        if (maxLeft < 1) {
//            maxLeft = 1;
//        }
//    }
//    for (var page = maxLeft; page <= maxRight; page++) {
//        wrapper.innerHTML += `<button value=${page} class="page btn btn-sm btn-warning text-white">${page}</button>`
//    }
//    if (state.page != 1) {
//        wrapper.innerHTML = `<button value="${state}" class="page btn btn-sm btn-warning text-white">&#171; First</button>` + wrapper.innerHTML;
//    }
//    if (state.page != pages) {
//        wrapper.innerHTML += `<button value="${pages}" class="page btn btn-sm btn-warning text-white"> Last &#187;</button>`;
//    }

//    $('.page').click(function () {

//        state.page = $(this).val();
//        buildTable();
//    })
//}
function buildTable(str,myData) {
    //var data = Custpagination(state.querySet, state.page, state.rows);
    //console.log(data);
    //var myData = data.querySet
    $(`#${str} #product`).empty();
    for (var i = 0; i < myData.length; i++) {
        $(`#${str} #product`).append(` <div class="col-lg-6">
                            <div class="d-flex align-items-center">
                                <img class="flex-shrink-0 img-fluid rounded" src="${myData[i].imgLink}" style="max-width: 3.5rem;" onclick="getProductId(${myData[i].product_Id})" >
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
   /* pageButton(data.pages);*/
}


/*======================================================Pagination=========================================================================================================*/

$(document).ready(() => {
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
           // state.querySet = response;
            buildTable("tab-2",response)
            console.log(response)
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

    $.ajax({
        url: location3 + "ShowRestaurant",
        type: "Get",
        success: (response) => {
            console.log(response);
            for (var i = 0; i < response.length; i++) {
                if (i === 4)
                    break;
                $('#IndexRestaurant').append(` <div class="col-lg-3 col-md-6 wow fadeInUp" data-wow-delay="0.${i + 1}1s">
                        <div class="team-item text-center rounded overflow-hidden">
                            <div class="rounded-circle overflow-hidden m-4">
                                <img class="img-fluid" src="${response[i].profileImage}" alt="" />
                            </div>
                            <h5 class="mb-3">${response[i].restaurant_Detail_Name}</h5>
                            <small>${response[i].restaurant_Detail_City}</small>
                           
                        </div>
                    </div>`);
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
    })
    $("#tab1").click(() => {
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
               // state.querySet = response;
                buildTable("tab-1", response)
                console.log(response)
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

    })

    $("#tab2").click(() => {
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
              //  state.querySet = response;
                buildTable("tab-2", response)
                console.log(response)
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
    })


    $("#tab3").click(() => {

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
              //  state.querySet = response;
                buildTable("tab-3", response)
                console.log(response)
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
    })

})


const AddProduct = (id) => {
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
            else if (response == "Login") {
                $("#btnchange_" + id).append(`<button class="btn btn-warning text-white" onclick="AddProduct(${id})" id="btn_${id}">Add</button>`);
                showInPopup(location3 + "CustomerLogin", '');
            }
            else {
                toastMixin.fire({
                    title: "Products from another Restaurant is there in your cart please remove them first",
                    icon: "error"
                });
                $("#btnchange_" + id).append(`<button class="btn btn-warning text-white" onclick="AddProduct(${id})" id="btn_${id}">Add</button>`);
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
    })
}

$('#form-modal').ready(() => {
    $('#close').click(() => {
        $('#form-modal').hide();
        $('#Checkout').show();
    })
})

const minus = (id, price) => {
    var total = Number($('#total').text());
    var data = Number($(`#quantity__input_${id}`).val());
    if (data > 1) {
        data--;
        $(`#quantity__input_${id}`).val(data);
        $(`#total_${id}`).html(` <i class="fa-solid fa-indian-rupee-sign"> ${data * price} </i>`);
        $('#total').html(`<i class="fa-solid fa-indian-rupee-sign"> ${total - price}</i>`);

    }
    $.ajax({
        url: location3 + "IncrementDecrement",
        type: "Post",
        data: { status: "minus", ProdId: id },
        success: (response) => {
            if (response != "true") {
                alert("something went wrong");
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
    })
}
const plus = (id, price) => {
    var total = Number($('#total').text());
    var data = Number($(`#quantity__input_${id}`).val());
    console.log(data);
    data++;
    console.log("after Increment:" + data);
    $(`#quantity__input_${id}`).val(data);
    $.ajax({
        url: location3 + "IncrementDecrement",
        type: "Post",
        data: { status: "plus", ProdId: id },
        success: (response) => {
            if (response != "true") {
                alert("something went wrong");
            }
            else {
                $(`#total_${id}`).html(`<i class="fa-solid fa-indian-rupee-sign"> ${data * price}</i>`);
                $('#total').html(`<i class="fa-solid fa-indian-rupee-sign"> ${total + price}</i>`);
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
    })
}

const funcCheckout = (id) => {
    showInPopup(location3 + 'Cart', 'Cart');
}


$("#Name").autocomplete({

    maxShowItems: 3,

    source: function (request, response) {
        $.ajax({
            url: location3 + "myResturant",
            type: "POST",
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


const deleteProduct1 = (id) => {
    $.ajax({
        url: location3 + "deleteProduct",
        type: "Post",
        data: { ProdId: id },
        success: (response) => {
            if (response == "true") {
                showInPopup(location3 + "Cart", 'Cart');
            }
            else {
                alert("something went wrong");
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
    })
}

$('#Checkout').click(() => {
    $.ajax({
        url: location3 + "CheckOut",
        type: "Post",
        success: (response) => {
            if (response == "true") {
                window.location = location3 + "ShowOrders";
            }
            else
                alert("failure")
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
})

$('#SearchRes').click(() => {

    var data = document.getElementById("Name").value;
    window.location = location3 + "ShowRestaurantProduct?resName=" + data;
})

function getProductId(id) {
    $.ajax({
        //url: location3 + "Rating",
        type: "Get",
        data: { prodId: id },
        success: (response) => {
            showInPopup(location3 + 'Rating?Prodid=' + id, 'Rating');
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


/*=================================Rating========================================*/
function select(smiley, rate, id) {
    if (smiley.classList.contains("active")) {
        smiley.classList.remove("active");
        return;
    }
    const active = document.querySelector(".smiley.active");
    if (active) {
        active.classList.remove("active");
    }
    smiley.classList.add("active");

    $.ajax({
        url: location3 + "Rating",
        type: "Post",
        data: {
            ProdId: id, Rate: rate
        },
        success: (response) => {
            if (response == "RatingAdded") {
                toastMixin.fire({
                    animation: true,
                    title: "Successfully Rated"
                });
            }
            else if (response == "RatingUpdated") {
                toastMixin.fire({
                    animation: true,
                    title: "Successfully Updated Rating"
                });
            }
            else
                alert("failure");
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

//document.querySelector(".first").addEventListener("click", function () {
//    Swal.fire({
//        toast: true,
//        icon: "success",
//        title: "Posted successfully",
//        animation: false,
//        position: "bottom",
//        showConfirmButton: false,
//        timer: 3000,
//        timerProgressBar: true,
//        didOpen: (toast) => {
//            toast.addEventListener("mouseenter", Swal.stopTimer);
//            toast.addEventListener("mouseleave", Swal.resumeTimer);
//        }
//    });
//});

//document.querySelector(".second").addEventListener("click", function () {
//    toastMixin.fire({
//        animation: true,
//        title: "Signed in Successfully"
//    });
//});

//document.querySelector(".third").addEventListener("click", function () {
//    toastMixin.fire({
//        title: "Wrong Password",
//        icon: "error"
//    });
//});

/*=================================Rating========================================*/






/* Script for Categories page*/
/*=============================================================================================================================================*/

