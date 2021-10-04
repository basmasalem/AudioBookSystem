var ContactUsDiv = $("#divListContactUs");
$(function () {

    $('#btnSearch').click(function (evt) {
        debugger;
        var form = $('#frmContactUsSearch');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            ContactUsDiv.html(res);
        });

    });
});

