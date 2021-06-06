$(document).ready(function () {
    $("#MainTable").DataTable();
});
$(function () {
    var place = $('#place');
    $('button[data-toggle="ajax-modal"]').
        click(function (event) {
            var url = $(this).data('url');
            var DecodedUrl = decodeURIComponent(url);
            $.get(DecodedUrl).done(function (data) {
                place.html(data);
                place.find('.modal').modal('show');
            })
        })
    place.on('click', '[data-save="modal"', function (event) {
        event.preventDefault();
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        var IndexUrl = 'Index';
        $.post(actionUrl, sendData).done(function (data) {
            place.find('.modal').modal('hide');
            window.location.href = IndexUrl;
        })
    })
})