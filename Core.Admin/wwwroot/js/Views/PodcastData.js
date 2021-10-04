var PodcastDiv = $("#divListPodcast");
$(function () {

    $('#btnSearchPodcast').click(function (evt) {
        debugger;
            var form = $('#frmPodcastSearch');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            PodcastDiv.html(res);
            });
      


    });
});

function DeletePodcast(id) {
    debugger;
    var url = $("#btnPodcastDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updatePodcast();
            alert("تم الحذف بنجاح");
        }
        else
            warningAlert("لا يمكن حذف هذا التدوين الصوتي لارتباطه بمستخدمين");
    });
}

function ChangeStatusPodcast(id) {
    debugger;
    var url = $("#btnPodcastStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updatePodcast();
            alert("تم التعديل بنجاح");
        }
    });
}

function ConfirmChangeStatusPodcast(id) {
    debugger;
    confirmAlert("هل تريد تغير حالة المبادرة؟", ChangeStatusPodcast, id);
}
function ConfirmDeletePodcast(id) {
    debugger;
    confirmAlert("هل تريد حذف هذه المبادرة؟", DeletePodcast, id);
}


function updatePodcast() {
    var urlPodcast = PodcastDiv.data('request-url');
    $.get(urlPodcast).done(function (res) {
        debugger;
        PodcastDiv.html(res);
    });

}