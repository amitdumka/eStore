﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//Model PopUp
$(function () {
    $.ajaxSetup({ cache: false });
    $(document).on('click', 'a[data_modal]',/* $("a[data_modal]").on("click",*/ function (e) {
   
        if (this.id == "edit") {
            $("#myModalLabel").html("Edit Items");
            $("#modalHead").addClass("modal-warning");
        }
        else if (this.id == "detail") {
            $("#myModalLabel").html("Detail Items");
            $("#modalHead").addClass("modal-success");
        }
        else if (this.id == "create") {
            $("#myModalLabel").html("Create Items");
            $("#modalHead").addClass("modal-primary");
        }
        else if (this.id == "delete") {
            $("#myModalLabel").html("Delete Items");
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

// TODO Function
$(document).ready(function () {
   
    $('.done-checkbox').on('click', function (e) {
        markCompleted(e.target);
    });
});

function markCompleted(checkbox) {
    checkbox.disabled = true;

    var row = checkbox.closest('tr');
    $(row).addClass('done');

    var form = checkbox.closest('form');
    form.submit();
}

(function () {
    var reformatTimeStamps = function () {
        var timeStamps = document.getElementsByClassName("timeStampValue");
        for (var ts of timeStamps) {
            var thisTimeStamp = ts.getAttribute("data-value");
            var date = new Date(thisTimeStamp);
            ts.textContent = moment(date).format('LLL');
        }
    }
    reformatTimeStamps();
})();

(function () {
    var modernizeTimeStamps = function () {
        var timeStamps = document.getElementsByClassName("timeStampValueModernized");
        for (var ts of timeStamps) {
            var thisTimeStamp = ts.getAttribute("data-value");
            var date = new Date(thisTimeStamp);
            ts.textContent = moment(date).fromNow();
        }
    }
    modernizeTimeStamps();
})();



