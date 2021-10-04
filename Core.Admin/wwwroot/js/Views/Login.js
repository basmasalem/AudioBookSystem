$(function () {
    $('#btnLogin').click(function (evt) {
        if ($('#frmLogin').valid()) {
            var form = $('#frmLogin');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1)
                    window.location.href = "/Home/Index";
                else
                    $("#divError").text("البريد الإلكتروني او كلمه المرور غير صحيحه");

            });
        }
       
    });
});

