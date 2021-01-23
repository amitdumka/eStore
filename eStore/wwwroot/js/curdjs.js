/*CURD Operation
 * @Author: Amit Kumar
 * MVC  CURD Operation for ASP .Net Core using JS 
*/

//helper functions
//Web Operations

//const host = "https://localhost:44335/";
//const uri = `${host}api/Stores`;

function objectifyForm(formArray) {
    //serialize data function
    var returnArray = {};
    for (var i = 0; i < formArray.length; i++) {
        returnArray[formArray[i]['name']] = formArray[i]['value'];
    }
    return returnArray;
}

$.fn.formToJson = function () {
    var a = this.serializeArray();
    //console.log(a);
    var aa = {};
    var lastName = "";
    for (var i = 0; i < a.length; i++) {
        if (a[i]['name'] != lastName) {
            aa[a[i]['name']] = a[i]['value'];
            // console.log(a[i]['name'] + ":" + a[i]['value']);
        }
        //else {
        //    console.log(a[i]['name'] + ":" + a[i]['value']);
        //    console.log("Check Box Encoutered");
        //}
        lastName = a[i]['name'];
    }
    return JSON.stringify(aa);

};
$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};
//init function to show modals
$(function () {

    $.ajaxSetup({ cache: false });
    $(document).on('click', 'a[data_modal]', function (e) {
        if (this.id == "edit") {
            $("#myModalLabel").html("Edit Items");
            $("modalHead").removeClass("model-success model-primary model-info");
            $("#modalHead").addClass("modal-warning");
        }
        else if (this.id == "detail") {
            $("#myModalLabel").html("Detail Items");
            $("modalHead").removeClass("model-warning model-primary model-info");
            $("#modalHead").addClass("modal-success");
        }
        else if (this.id == "create") {
            $("#myModalLabel").html("Create Items");

            $("modalHead").removeClass("model-success model-warning model-info");
            $("#modalHead").addClass("modal-primary");
        }
        else if (this.id == "delete") {
            $("#myModalLabel").html("Delete Items");

            $("modalHead").removeClass("model-success model-primary model-warning");
            $("#modalHead").addClass("modal-info");
        }
        $('#myModalContent').load(this.href, function () {
            $('#myModal').modal({
                keyboard: true
            }, 'show');
        });
        return false;
    });
});



// Add Function
function addData(formName, activityName, uri) {

    var newData = $(`#${formName}`).formToJson();
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: newData
    })
        .then(response => {
            if (response.ok) toastr.success(`New ${activityName} is Added Successfuly.`);
            else toastr.error(`Sorry!, Failed to add new ${activityName}.`);

        })
        .then(() => {

            location.reload();
        })
        .catch(error => {
            console.error(error); toastr.error(`Sorry!, Failed to add new ${activityName}.\n Error: ${error}`);
        });

}

//edit function

function updateData(formName, activityName, uri, id) {

    var updateFormData = $(`#${formName}`).formToJson();

    console.log(updateFormData);
    //var id = $(`#${idName}`).val();
    console.log(uri);
    fetch(`${uri}/${id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: updateFormData
    })
        .then(() => toastr.success(`${activityName} Details is saved!`))
        .then(() => location.reload())
        .catch(error => toastr.error("Unable to update item. :" + error));
    return false;

}

//delete function
function deleteModal(activityName, uri, id) {
    $('#delButton').attr('onClick', `deleteData('${activityName}', '${uri}', ${id})`);
    $('#deleteModal').modal({
        keyboard: true
    }, 'show');

}

function deleteData(activityName, uri, id) {

    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => {
            toastr.success(`${activityName} is deleted Successfully!`);
            $('#deleteModal').modal('dispose');
        })
        .then(() => location.reload())
        .catch(error => toastr.error("Unable to delete due to error : " + error));

}

//function for displaying datatable

function initDataTable(datatableID) {
    var table = $(`#${datatableID}`).dataTable({
        "pagingType": "full_numbers",
        columnDefs: [{
            orderable: false,
            className: 'select-checkbox select-checkbox-all',
            targets: 0
        }],
        select: {
            style: 'multi',
            selector: 'td:first-child'
        },
        initComplete: function () {
            this.api().columns().every(function () {
                var column = this;
                var search = $(`<input class="form-control form-control-sm" type="text" placeholder="Search">`)
                    .appendTo($(column.footer()).empty())
                    .on('change input', function () {
                        var val = $(this).val()

                        column
                            .search(val ? val : '', true, false)
                            .draw();
                    });

            });
        }
    });
    $('input.search').val('');
    return table;
}

//get functions

function getItems(uri) {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => toastr.error('Unable to get items.', error));
}
function getItem(uri, id) {
    fetch(`${uri}/${id}`)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => toastr.error('Unable to get items.', error));
}

//Function To add Card and header to table

function cardTableInit(tableId, title, activitName) {
    var titleBar = `<h3 class="white-text mx - 3 " id="titleHeader">${title}</h3>`;
    var leftButton = '<div><button type = "button" class="btn btn-outline-white btn-rounded btn-sm px-2" ><i class="fas fa-th-large mt-0"></i></button ><button type="button" class="btn btn-outline-white btn-rounded btn-sm px-2"><i class="fas fa-columns mt-0"></i></button></div >';
    var rightButton = `<div><a href="${activitName}/Create" class="btn btn-outline-white btn-rounded btn-sm px-2" id="create" data_modal=""> <i class="fas fa-plus-circle mt-0"></i></a><button type="button" class="btn btn-outline-white btn-rounded btn-sm px-2" onclick="toastr.success("Sorry!, Button is not Implemented.");"><i class="fas fa-pencil-alt mt-0"></i></button><button type="button" class="btn btn-outline-white btn-rounded btn-sm px-2" onclick="toastr.success("Sorry!, Button is not Implemented.");"><i class="far fa-trash-alt mt-0"></i></button><button type="button" class="btn btn-outline-white btn-rounded btn-sm px-2" onclick="toastr.success("Sorry!, Button is not Implemented.");"><i class="fas fa-info-circle mt-0"></i></button></div >`;
    var cardBar = '<div class="view view-cascade gradient-card-header blue-gradient narrower py-2 mx-4 rounded-pill mb-3 d-flex justify-content-between align-items-center">';
    var cardMain = '<div class="card card-cascade narrower mb-5"></div>';
    var cardBody = ' <div class="px-4"></div>';
    var tableWrapepr = ' <div class="table-wrapper "></div>';
    var tableAtt = 'cellspacing=" 0" width="100%"';
    var tableclass = "table bg-white table-hover  table-bordered table-sm  mb-0";
    var theadClass = "mdb-color-text text-center";
    var thClass = "th-small";
    var tbodyClass = "text-center text-primary";
    var tdSelect = '<td class="text-left"></td>';
    var thSelect = '<th></th>';

    $(`#${tableId}`).wrap(' <div class="card-deck"></div>');
    $(`#${tableId}`).wrap(cardMain);
    $(`#${tableId}`).before(cardBar + leftButton + titleBar + rightButton + "</div>");
    $(`#${tableId}`).wrap(cardBody);
    $(`#${tableId}`).wrap(tableWrapepr);
    $(`#${tableId}`).removeClass();
    $(`#${tableId}`).addClass(tableclass);
    $(`#${tableId}`).attr("cellspacing", "0");
    $(`#${tableId}`).attr("width", "100%");
    $(`#${tableId}`).find("thead").children().prepend(thSelect);
    $(`#${tableId}`).find("tbody").children().prepend(tdSelect);
    $(`#${tableId}`).find("a").addClass("btn btn-sm btn-rounded");
    $(`#${tableId}`).find("a").parent().addClass("btn-group d-inline-flex");
    $(`#${tableId}`).find("a").parent().attr("id", "btnGrpId");
    $(`#${tableId}`).find("thead").addClass(theadClass);
    $(`#${tableId}`).find("tbody").addClass(tbodyClass);
    $(`#${tableId}`).find("a").empty();
    $(`#${tableId}`).find("a").attr("id", "opsid");
    //$(`#${tableId}`).find("a").attr("data_modal", "");
    var par = $(`#${tableId}`).find("a").parent();
    par.children().contents("Edit").addClass("btn-danger");
    $("#btnGrpId").each(function () {
        $('a').each(function (i, link) {
            var newlink = link.href;
            if (newlink.includes("/Delete/")) {
                $(this).removeAttr("href");
                $(this).attr("id", "delete_JS");
                $(this).addClass("btn-danger")
                var i = newlink.lastIndexOf("/");
                var ids = newlink.substr(i + 1, 20);
                $(this).append('<i class="fas fa-trash-alt mt-0"></>');
                $(this).attr("onclick", ` return deleteM(${ids})`);
                $(this).removeAttr("data_modal");

            }
            if (newlink.includes("/Details/")) {
                $(this).attr("id", "detail");
                $(this).attr("data_modal", "");
                $(this).addClass("btn-info")
                $(this).append('<i class="fas fa-info-circle mt-0"></>');
            }
            if (newlink.includes("/Edit/")) {
                $(this).addClass("btn-amber")
                $(this).attr("data_modal", "");
                $(this).append('<i class="fas fa-pencil-alt mt-0"></>');
                $(this).attr("id", "edit");
            }
        });
    });

    initDataTable(tableId);

}


//function to handle edit details and create 

function cedUI() {
    $("input").each(function (i, link) {
        

    });

}