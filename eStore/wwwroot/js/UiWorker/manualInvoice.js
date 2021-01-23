//Manual Invoice: Worker js
//@Author: Amit Kumar
//@Comany: AKS Labs(India)
//@Year:   2020


//Show Modal.
function addNewOrder() {
    $("#newOrderModal").modal();
}
function editNewOrder(invNo) {

    $("#editInvoiceModal").modal();
    getInvoiceDetails(invNo);
}
//Add Multiple Order.
$("#addToList").click(function (e) {
    e.preventDefault();

    if ($.trim($("#productName").val()) == "" || $.trim($("#price").val()) == "" || $.trim($("#quantity").val()) == "") {
        alert("Kindly Enter all field(s).");
        return
    };
    if ($.trim($("#productName").val()) == "Not Found") { alert("Kinldy add product!!!."); return; }
    else if ($.trim($("#quantity").val()) == "" || $.trim($("#quantity").val()) == "0") { alert("Kinldy add quantity."); return; }

    var productName = $("#productName").val(),
        barcode = $("#barCode").val(),
        price = $("#price").val(),
        quantity = $("#quantity").val(),
        units = $("#units").val(),
        sman = $("#salesMan").val(),
        detailsTableBody = $("#detailsTable tbody");
    var amt = (parseFloat(price) * parseInt(quantity));

    var tamt = parseFloat($("#totalAmount").val()) + amt;
    tamt = Math.round(tamt);//RoundOff
    $("#totalAmount").val(tamt);
    var tqty = parseInt($("#totalQty").val()) + quantity;
    $("#totalQty").val(tqty);
    $("#totalItem").val((parseInt($("#totalItem").val()) + 1));


    var productItem = '<tr><td>' + sman + '</td><td>' + barcode + '</td><td>' + productName + '</td><td>' + price + '</td><td>' + quantity + '</td><td>' +
        (parseFloat(price) * parseInt(quantity)) + '</td><td>' + units + '</td><td><a data-itemId="0" href="#" class="btn btn-sm btn-outline-danger deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(productItem);
    clearItem();
});
$("#saveToList").click(function (e) {
    e.preventDefault();

    if ($.trim($("#productName").val()) == "" || $.trim($("#price").val()) == "" || $.trim($("#quantity").val()) == "") {
        alert("Kindly Enter all field(s).");
        return
    };
    if ($.trim($("#productName").val()) == "Not Found") { alert("Kinldy add product!!!."); return; }
    else if ($.trim($("#quantity").val()) == "" || $.trim($("#quantity").val()) == "0") { alert("Kinldy add quantity."); return; }

    var productName = $("#productName").val(),
        barcode = $("#barCode").val(),
        price = $("#price").val(),
        quantity = $("#quantity").val(),
        units = $("#units").val(),
        sman = $("#salesMan").val(),
        detailsTableBody = $("#detailsTable tbody");
    var amt = (parseFloat(price) * parseInt(quantity));

    var tamt = parseFloat($("#totalAmount").val()) + amt;
    tamt = Math.round(tamt);//RoundOff
    $("#totalAmount").val(tamt);
    var tqty = parseInt($("#totalQty").val()) + quantity;
    $("#totalQty").val(tqty);
    $("#totalItem").val((parseInt($("#totalItem").val()) + 1));


    var productItem = '<tr><td>' + sman + '</td><td>' + barcode + '</td><td>' + productName + '</td><td>' + price + '</td><td>' + quantity + '</td><td>' +
        (parseFloat(price) * parseInt(quantity)) + '</td><td>' + units + '</td><td><a data-itemId="0" href="#" class="btn btn-sm btn-outline-danger deleteItem">Remove</a></td></tr>';
    detailsTableBody.append(productItem);
    clearItem();
});
$("#getEBarCode").click(function (e) {
    e.preventDefault();
    if ($.trim($("#barCode").val()) == "") { alert("Kindly Enter BarCode"); return };
    var barcode = $("#barCode").val();
    var data = JSON.stringify({
        barCode: barcode
    });

    $.when(getBarCodeData(barcode)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });

});

$("#getBarCode").click(function (e) {
    e.preventDefault();
    if ($.trim($("#barCode").val()) == "") { alert("Kindly Enter BarCode"); return };
    var barcode = $("#barCode").val();
    var data = JSON.stringify({
        barCode: barcode
    });

    $.when(getBarCodeData(barcode)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });

});

//After Add A New Order In The List, Clear Clean The Form For Add More Order.
function clearItem() {
    $("#productName").val('');
    $("#price").val('');
    $("#quantity").val('');
    $("#barCode").val('');
}
// After Add A New Order In The List, If You Want, You Can Remove It.
$(document).on('click', 'a.deleteItem', function (e) {
    e.preventDefault();
    var $self = $(this);
    if ($(this).attr('data-itemId') == "0") {
        $(this).parents('tr').css("background-color", "#ff6347").fadeOut(800, function () {
            $(this).remove();
        });
    }
});
//After Click Save Button Pass All Data View To Controller For Save Database

function updateEditData(data) {

    $.each(data.invoice.saleItems, function (key, value) {
        var productName = value.productName,
            barcode = value.barCode,
            price = value.mrp,
            quantity = value.qty,
            sman = value.smCode,
            units = value.units,
            amount = value.billAmount,
            detailsTableBody = $("#editDetailsTable tbody");;
        var productItem = '<tr><td>' + sman + '</td><td>' + barcode + '</td><td>' + productName + '</td><td>' + price + '</td><td>' + quantity + '</td><td>' +
            (amount) + '</td><td>' + units + '</td><td><a data-itemId="0" href="#" class="btn btn-sm btn-outline-danger deleteItem">Remove</a></td></tr>';
        detailsTableBody.append(productItem);

    });

    $("#eTotalAmount").val(data.invoice.totalAmount);
    $("#eTotalQty").val(data.invoice.totalQty);
    $("#eTotalItem").val(data.invoice.noofItem);
    $("#eTotalDiscount").val(data.invoice.discount);

    $("#invoiceNo").val(data.invoice.invoiceNo);
    $("#eName").val(data.invoice.customerName);
    var now = new Date(data.invoice.onDate);
    var day = ("0" + now.getDate()).slice(-2);
    var month = ("0" + (now.getMonth() + 1)).slice(-2);
    var d = now.getFullYear() + "-" + (month) + "-" + (day);
    $("#eOnDate").val(d);
    //Add Card and Cash
    if (data.IsCardPayment) {
        $("#eCardAmt").val(data.invoice.cardAmount);
        $("#eCashAmt").val(data.invoice.cashAmount);
        $("#eCardType").val(data.invoice.cardType);

        $("#eCardNo").val(data.invoice.cardNumber);
        $("#eAuthCode").val(data.invoice.authCode);

    } else {

        $("#eCashAmt").val(data.invoice.cashAmount);
        $("#eCardAmt").val(0);

    }

}


function getInvoiceDetails(data) {
    console.log(data);
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'GET',
        url: "/Sales/ManualInvoice/GetInvoiceDetails?id=" + data,

        success: function (result) {
            console.log(result);
            if (result.error == "Error")
                alert(result.msg);
            else {
                updateEditData(result);

            }

        },
        error: function (res) {
            console.log(res);
            alert("Error!!!");
        }
    });

}

function deleteInvoiceNo(data) {
    var param = { id: data };
    var oP = JSON.stringify({ id: data });

    console.log(data);
    console.log(param);
    console.log(oP);

    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'GET',
        url: "/Sales/ManualInvoice/DeleteBillNo?id=" + data,
        data: oP,
        success: function (result) {
            console.log(result);
            alert(result.msg);
            location.reload();

        },
        error: function () {
            alert("Error!!!");
        }
    });
}

function getBarCodeData(data) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        type: 'GET',
        url: "/Sales/ManualInvoice/GetBarCode?barcode=" + data,
        data: data,
        success: function (result) {
            updateProductDetails(result);
        },
        error: function () { alert("Error!!!"); }
    });
}

function updateProductDetails(data) {
    $("#price").val(data.mrp);
    $("#quantity").val('0');
    $("#productName").val(data.productName);
    $("#units").val(data.units);

}

function saveOrder(data1) {
    return $.ajax({
        contentType: 'application/json; charset=utf-8',//'application / x - www - form - urlencoded',
        dataType: 'JSON',
        type: 'POST',
        url: '@Url.Action("SaveOrder", "ManualInvoice")',// "/Sales/ManualInvoice/SaveOrder",
        data: data1,
        success: function (result) {
            //if (result.FileName != "Error")
            // printJS({ printable: result.FileName, type: 'pdf', showModal: true });
            //else alert("Err: " + result.result);
            alert(result.result);
            location.reload();
        },
        error: function () {
            alert("Error!");
        }
    });
}

$("#paymentMode").change(function () {
    alert($("#paymentMode option:selected").text());
    
});
$("#deleteInvoice").click(function (e) {
    e.preventDefault();


    $.when(deleteInvoiceNo(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });
});
//Collect Multiple Order List For Pass To Controller
$("#saveOrder").click(function (e) {
    e.preventDefault();

    var orderArr = [];
    orderArr.length = 0;

    $.each($("#detailsTable tbody tr"), function () {
        orderArr.push({
            salesman: $(this).find('td:eq(0)').html(),
            barcode: $(this).find('td:eq(1)').html(),
            productName: $(this).find('td:eq(2)').html(),
            price: $(this).find('td:eq(3)').html(),
            quantity: $(this).find('td:eq(4)').html(),
            amount: $(this).find('td:eq(5)').html()
        });
    });

    var payar = {
        cardAmount: $("#cardAmt").val(),
        CashAmount: $("#cashAmt").val(),
        CardType: $("#cardType").val(),
        AuthCode: $("#authCode").val(),
        CardNo: $("#cardNo").val()
    };


    var data = JSON.stringify({
        name: $("#name").val(),
        address: $("#address").val(),
        mobileNo: $("#mobileNo").val(),
        onDate: $("#onDate").val(),
        saleItems: orderArr,
        paymentInfo: payar

    });
    console.log(data);
    $.when(saveOrder(data)).then(function (response) {
        console.log(response);
    }).fail(function (err) {
        console.log(err);
    });
});

// Here
var Salesman = [];
function LoadSaleman(element) {
    if (Salesman.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '@Url.Action("GetSalesmanList", "ManualInvoice")',//'/home/GetSalesmanList',
            success: function (data) {
                console.log(data);
                Salesman = data;
                //render catagory
                renderSalesman(element);
            }

        })
    }
    else {
        //render catagory to the element
        renderSalesman(element);
    }
}
function renderSalesman(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option />').val('0').text('Select'));
    $.each(Salesman, function (i, val) {
        $ele.append($('<option/>').val(val.salesmanId).text(val.salesmanName));
    })
}

// Call function to load.
LoadSaleman($('#salesMan'));
LoadSaleman($('#salesManEdit'));
