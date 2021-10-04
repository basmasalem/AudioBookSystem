function UploadPodcastImage() {
    $("#filImage").click();
}
function UploadPodcastFile() {
    $("#uploadFile").click();
}


function SavePodcast() {
    debugger;
    $('#addPodcast').attr('disabled', 'disabled');
    if ($('#frmPodcast').valid()) {

        if ($("#hdfAttachments").val() == "0" || $("#hdfFileAttachments").val() == "0") {
            warningAlert(podcastMsg.dataWarning);
            $('#addPodcast').removeAttr('disabled');
            return false;
        }
        var form = $('#frmPodcast');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            if (res == 1) {
                SuccessArlet(podcastMsg.podcastSaved);
                setTimeout(function () { window.location = "/Home/Index"; }, 1000);
            }
            else if (res == -2) {
                $('#addPodcast').removeAttr('disabled');
                warningAlert(podcastMsg.dateWarning);
            }
            else {
                $('#addPodcast').removeAttr('disabled');
                warningAlert(podcastMsg.error);
            }

        });
    }
    else
        $('#addPodcast').removeAttr('disabled');
}


function SubscribePodcast(id, flag) {
    $.get("/Podcast/SubscribePodcast", { Id: id, flag: flag }).done(function (res) {
        if (res == 1) {
            var count = parseInt($("#lblPodcastSubscribers").html(), 10) ;
            if (flag == true) {
                $("#lblPodcastSubscribers").html(count + 1);
                SuccessArlet(podcastDetails.addSubscribeMsg);
                $("#divBtnbtnSubscribePodcast").html(`
 <div class="user_add">
                                        <a id="btnSubscribePodcast" onclick="SubscribePodcast('`+ id+`',false)"><img src="/assets/img/icon/u.png"></a>
                                    </div>
`);
            }
            else {
                $("#lblPodcastSubscribers").html(count - 1);
                SuccessArlet(podcastDetails.cancelSubscribeMsg);
                $("#divBtnbtnSubscribePodcast").html(`
 <div class="user_add2">
                                        <a id="btnSubscribePodcast" onclick="SubscribePodcast('`+ id + `',true)"><img src="/assets/img/icon/user-add2.svg"></a>
                                    </div>
`);


            }
        }
    });
}