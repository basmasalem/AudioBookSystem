$(function () {

    $('#btnSavePodcast').click(function (evt) {
        debugger;
        $('#btnSavePodcast').attr('disabled', 'disabled');
        if ($('#frmPodcast').valid()) {

            if ($("#DescAr").val() == "" || $("#DescEn").val() == "" || $("#hdfAttachments").val() == "0" || $("#hdfFileAttachments").val() == "0") {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSavePodcast').removeAttr('disabled');
                return false;
            }
            var form = $('#frmPodcast');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    alert("تم الحفظ بنجاح");
                    setTimeout(function () { window.location = "/Podcast/Index"; }, 1000);
                }
                else if (res == -2) {
                    $('#btnSavePodcast').removeAttr('disabled');
                    warningAlert("تاريخ البدايه لازم اكبر من تاريخ اليوم");
                }
                else {
                    $('#btnSavePodcast').removeAttr('disabled');
                    warningAlert("حصل خطأ اثناء الحفظ");
                }

            });
        }
        else
            $('#btnSavePodcast').removeAttr('disabled');



    });
});
