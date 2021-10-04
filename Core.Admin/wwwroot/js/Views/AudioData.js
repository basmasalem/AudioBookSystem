var AudioDiv = $("#divListAudio");
$(function () {

    $('#btnSearch').click(function (evt) {
        debugger;
        var form = $('#frmAudioSearch');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            AudioDiv.html(res);
        });

    });
});

function DeleteAudio(id) {
    debugger;
    var url = $("#btnAudioDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateAudio();
            alert("تم الحذف بنجاح");
        }
        else
            warningAlert("لا يمكن حذف هذا الملف لانه مضاف على تدوين صوتي");
    });
}


function ConfirmDeleteAudio(id) {
    confirmAlert("هل تريد حذف هذا الملف ؟", DeleteAudio, id);
}


function updateAudio() {
    var urlAudio = AudioDiv.data('request-url');
    $.get(urlAudio).done(function (res) {
        AudioDiv.html(res);
    });

}


function ConfirmChangeStatusAudio(id) {
    debugger;
    confirmAlert("هل تريد تغير حالة الملف؟", ChangeStatusAudio, id);
}

function ChangeStatusAudio(id) {
    debugger;
    var url = $("#btnAudioStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateAudio();
            alert("تم التعديل بنجاح");
        }
    });
}