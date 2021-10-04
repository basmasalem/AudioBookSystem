function SavePrintBook() {
    debugger;
    $('#btnPrintBook').attr('disabled', 'disabled');
    if ($('#frmPrintBook').valid()) {

        if ($("#hdfFileAttachments").val() == "0") {
            warningAlert(printBookMsg.dataWarning);
            $('#btnPrintBook').removeAttr('disabled');
            return false;
        }
        var form = $('#frmPrintBook');
        var sendData = form.serialize();
        $.post("/PrintBook/SavePrintBook", sendData).done(function (res) {
            if (res == 1) {
                SuccessArlet(printBookMsg.bookSaved);
                setTimeout(function () { window.location = "/Home/Index"; }, 1000);
            }
            else {
                $('#btnPrintBook').removeAttr('disabled');
                warningAlert(printBookMsg.error);
            }

        });
    }
    else
        $('#btnPrintBook').removeAttr('disabled');
}