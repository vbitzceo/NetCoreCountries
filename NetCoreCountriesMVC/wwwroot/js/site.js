// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('input.maxlength').maxlength({
        alwaysShow: true,
        threshold: 10,
        warningClass: "label label-info",
        limitReachedClass: "label label-warning",
        placement: 'top',
        preText: 'used ',
        separator: ' of ',
        postText: ' chars.'
    });

    $('.summernote').summernote({
        height: 250
    });
});
