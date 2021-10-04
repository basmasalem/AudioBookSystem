



$(document).ready(function () {
    $(".re button").click(function () {
        $(".re").addClass("ani");

    });

});




function SearchAudio() {
    var data = $("#frmSerachAudio").serialize();
    $.get("/Audio/ListSound", data).done(function (res) {
        $("#divAudioList").html(res);
    });
}

function WriteComment(audioId) {
    var Text = $("#input_" + audioId).val();
    if (Text == "") {
        return false;
    }
    debugger;
    $.get("/Audio/WriteComment", { audioId: audioId, Text: Text }).done(function (res) {
        $("#audiocommentdiv_" + audioId).html(res);
        $("#input_" + audioId).val("");
    });
}


function EditComment(AudioCommentId) {
    $("#comment_" + AudioCommentId).css("display", "none");
    $("#commentitem_" + AudioCommentId).css("display", "block");
}

function EditCommentText(AudioCommentId) {
    var Text = $("#inputedit_" + AudioCommentId).val();
    if (Text == "") {
        return false;
    }
    debugger;
    $.get("/Audio/EditComment", { AudioCommentId: AudioCommentId, Text: Text }).done(function (res) {
        if (res == "1") {
            $("#comment_" + AudioCommentId).html("").append(Text);
            $("#comment_" + AudioCommentId).css("display", "block");
            $("#commentitem_" + AudioCommentId).css("display", "none");
            $("#inputedit_" + AudioCommentId).val(Text);
        }

    });
}


function ConfirmRemoveComment(AudioCommentId) {
    var func = "RemoveComment('" + AudioCommentId + "')";
    var msg = message.commentMsg;
    ConfirmDelete(msg, func);
}


function RemoveComment(AudioCommentId) {
    $.get("/Audio/RemoveComment", { AudioCommentId: AudioCommentId }).done(function (res) {
        if (res == "1") {
            CloseConfirmDelete();
            $("#li_" + AudioCommentId).remove();
        }

    });
}
function PlayAudioDetails(id) {
    var audio = document.getElementById("audio_" + id);
    if (audio.duration > 0 && !audio.paused) {
        audio.pause();
    } else {

        audio.play();
        $.get("/Audio/SaveClientListenAudio", { Id: id, playlistId: "0", src: "" }).done(function (res) {
            $("#lblListenerCount").html(res);
        });
    }

}
function GetClientAudioRate(id) {
    $.get("/Audio/GetAudioRate", { Id: id }).done(function (res) {
        $("#divAudioRate").html(res);
    });
}
function SaveClientAudioRate(id) {
    var Text = $("#rateText").val();
    var rate = document.querySelector('input[name="rate"]:checked')?.value;
    if (Text === "" || typeof (rate) === "undefined") {
        return false;
    }
    debugger;
    $.get("/Audio/SaveClientAudioRate", { Id: id, rateText: Text, rate: parseInt(rate, 10)}).done(function (res) {
        if (res == 1) {
            $("#rateModal").modal("hide");
            SuccessArlet(messageAudioDetails.evaluationMsg);
        }

    });
}


$(function () {



    $('#btnSaveAudio').click(function (evt) {
        debugger;
        $('#btnSaveAudio').attr('disabled', 'disabled');
        if ($('#frmAudio').valid()) {
            debugger;
            if ($("#DescriptionEn").val() == "" || $("#DescriptionAr").val() == "" || $("#hdfAttachments").val() == "0" || $("#hdfFileAttachments").val() == "0" || $("#hdfAudioAttachments").val() == "0") {
                warningAlert(message.enteralldata);
                $('#btnSaveAudio').removeAttr('disabled');
                return false;
            }
            var form = $('#frmAudio');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    SuccessArlet(message.addsuccess);
                    setTimeout(function () { window.location = "/"; }, 2000);
                }
                else
                    warningAlert(message.errorwhensave);
                $('#btnSaveAudio').removeAttr('disabled');

            });
        }
        else
            $('#btnSaveAudio').removeAttr('disabled');
    });

  
});



