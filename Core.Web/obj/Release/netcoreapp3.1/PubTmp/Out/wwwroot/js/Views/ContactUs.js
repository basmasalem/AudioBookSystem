$(function () {

    $('#btnSaveContactUs').click(function (evt) {

        $('#btnSaveContactUs').attr('disabled', 'disabled');
        if ($('#frmContactUs').valid()) {

            var form = $('#frmContactUs');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    SuccessArlet(message.sendcontactus);
                    $('#frmContactUs')[0].reset();
                    setTimeout(function () { window.location = "/"; }, 2000);
                }
                else if (res == -2) {
                    warningAlert(message.errorsendingcontact);
                    $('#btnSaveContactUs').removeAttr('disabled');

                }


            });
        }
        else {
            //$(".error").css("display", "none");
            $('#btnSaveContactUs').removeAttr('disabled');

        }
    });


});