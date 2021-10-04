var AudioTypeDiv = $("#divListAudioType");
$(function () {

    $('#btnSearch').click(function (evt) {
        debugger;
        var form = $('#frmAudioTypeSearch');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            AudioTypeDiv.html(res);
        });

    });
});

function DeleteAudioType(id) {
    debugger;
    var url = $("#btnAudioTypeDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateAudioType();
            alert("تم الحذف بنجاح");
        }
        else
            warningAlert("لا يمكن حذف هذا النوع لارتباطه بملفات الصوت");
    });
}


function ConfirmDeleteAudioType(id) {
    debugger;
    confirmAlert("هل تريد حذف هذا النوع ؟", DeleteAudioType, id);
}


function updateAudioType() {
    var urlAudioType = AudioTypeDiv.data('request-url');
    $.get(urlAudioType).done(function (res) {
        debugger;
        AudioTypeDiv.html(res);
    });

}