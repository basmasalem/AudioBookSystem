function SuccessArlet(msg) {
    $("#divSuccess").html(msg);
    $("#successModalCenter").modal("show");
    setTimeout(function () { $("#successModalCenter").modal("hide"); }, 2000);
}

function warningAlert(msg) {
    $("#divErroralert").html(msg);
    $("#errorModalCenter").modal("show");
    setTimeout(function () { $("#errorModalCenter").modal("hide"); }, 2000);
}

function CloseConfirmDelete() {
    $("#confirmDeleteModalCenter").modal("hide");
}

function ConfirmDelete(msg, func) {

    $("#divConfirmDelete").html(msg);
    $('#btnConfirmDelete').attr('onClick', func);
}
function RemoveLabelError() {
    $("#divPalyList").find("label.error").remove();
}

function ChangeLanguage(val, url) {
    debugger;
    $.post("/Culture/SetCulture/", { culture: val, returnUrl: url }).done(function (res) {
        window.location.href = res;
    });
}

function ClientLike(id, flag) {
    $.get("/Audio/ClientLike", { audioId: id, like: flag }).done(function (res) {
        if (res == true) {
            $("#imgLike_" + id).attr("src", "/assets/img/icon/like2.png");
        }
        else {
            if ($("#LikePage").val() == "1") {
                $.get("/Client/FavoriteList").done(function (res) {
                    $("#divFavoriteList").html(res);
                });
            }
            else
                $("#imgLike_" + id).attr("src", "/assets/img/icon/link.png");
        }


        $("#imgLike_" + id).attr("onclick", "ClientLike(" + id + "," + res + ")");

    });
}
function OpenAddPlaylist() {
    if ($("#divPalyList").hasClass("form-popup")) {
        $("#divPalyList").removeClass("form-popup");
        $("#btnAddPlayList").removeClass("add-popup");

    }
    else {
        $("#divPalyList").addClass("form-popup");
        $("#btnAddPlayList").addClass("add-popup");
    }
}


function GetClientPlaylist(id) {
    $.get("/Audio/GetClientPlaylist", { audioId: id }).done(function (data) {
        $("#divClientPlayList").html(data);

    });
}

function AddClientPlayList() {
    debugger;
    $('#btnAddPlayList').attr('disabled', 'disabled');
    if ($('#frmAddPlaylist').valid()) {
        var audioId = $("#PlaylistAudioId").val();
        var form = $('#frmAddPlaylist');
        var sendData = form.serialize() + '&audioId=' + audioId;

        $.post("/Audio/SaveClientPlaylist", sendData).done(function (res) {
            if (res == 1) {
                $("#playListModalCenter").modal("hide");
                SuccessArlet(message.SuccessAddTpPlaylistMsg);
                $("#playlistAudio_" + audioId).html('<a onclick="ConfirmRemoveClientPlaylistAudio(' + audioId + ')" data-toggle="modal" data-target="#confirmDeleteModalCenter" ><img src="/assets/img/icon/red_delete.png"></a>');
            }

        });
    }
    else {
        $("#divPalyList").find("label.error").remove();
        $('#btnAddPlayList').removeAttr('disabled');
    }
}
function AddAudioPlaylist(id) {
    debugger;
    var audioId = $("#PlaylistAudioId").val();
    $.post("/Audio/SaveAudioPlaylist", { playlistId: id, audioId: audioId }).done(function (res) {
        if (res == 1) {
            $("#playListModalCenter").modal("hide");
            SuccessArlet(message.SuccessAddTpPlaylistMsg);
            $("#playlistAudio_" + audioId).html('<a onclick="ConfirmRemoveClientPlaylistAudio(' + audioId + ')" data-toggle="modal" data-target="#confirmDeleteModalCenter"><img src="/assets/img/icon/red_delete.png"></a>');
        }

    });
}

function ConfirmRemoveClientPlaylistAudio(id) {
    var func = "RemoveClientPlaylistAudio(" + id + ")";
    ConfirmDelete(message.playlistaudioMsg, func);
}

function RemoveClientPlaylistAudio(id, flag) {
    debugger;
    $.post("/Audio/RemoveClientPlaylistAudio", { audioId: id }).done(function (res) {
        if (res == 1) {
            SuccessArlet(message.SuccessDeleteMsg);
            CloseConfirmDelete();
            var playlistId = $("#playlistKey").val();
            if (playlistId == "0") {
                $("#playlistAudio_" + id).html('<a onclick="GetClientPlaylist(' + id + ')" data-toggle="modal" data-target="#playListModalCenter"><img src="/assets/img/icon/library.png"></a>');
            }
            else {
                $.get("/Client/GetPlaylistAudio", { Id: playlistId }).done(function (data) {
                    $("#divPlaylistAudio").html(data);
                });
            }
        }
    });
}
function ConfirmRemovePlaylist(id, name, flag) {
    var func = "RemovePlaylist('" + id + "'," + flag + ")";
    var msg = message.playlistMsg + '<span> ' + name + '</span>؟';
    ConfirmDelete(msg, func);
}

function RemovePlaylist(id, flag) {
    debugger;
    $.post("/Client/RemovePlaylist", { playlistId: id }).done(function (res) {
        if (res == 1) {
            SuccessArlet(message.SuccessDeleteMsg);
            CloseConfirmDelete();
            if (flag == true) {
                $.get("/Client/GetPlaylist").done(function (data) {
                    $("#divPlaylist").html(data);
                });
            }
            else {
                window.location.href = "/Client/Playlist";
            }

        }
    });
}

function PlayAudio(id, flag) {
    debugger;
    var playlistId = $("#playlistKey").val();
    var audio = document.getElementById("audio_" + id);
    if (flag == true) {
        var sounds = document.getElementsByTagName('audio');
        for (i = 0; i < sounds.length; i++) {
            if (sounds[i] != audio)
                sounds[i].pause();
        }
        if (playlistId != "0") {
            $("#btnplayClientPalyList").addClass("pauseBtn");
            $("#imgPlayList").attr("src", "/assets/img/icon/pause.png");
        }
        $.get("/Audio/SaveClientListenAudio", { Id: id, playlistId: "0", src: "" }).done(function () {
        });
        if (playlistId != "0") {
            if (typeof ($("#AudioPlaylist_" + id).attr('src')) == "undefined") {
                var files = [];
                $.get("/Client/GetAudioSrcOfPlaylist", { playlistId: playlistId }).done(function (data) {
                    debugger;
                    var music_player = document.getElementById("AudioPlaylist_" + playlistId);
                    files = data;
                    // Current index of the files array
                    var i = 0;
                    if (audio.src != '') {
                        i = files.indexOf(audio.src);
                    }
                    // Get the audio element

                    // function for moving to next audio file
                    function next() {
                        // Check for last audio file in the playlist
                        if (i === files.length - 1) {
                            i = 0;
                        } else {
                            i++;
                        }

                        // Change the audio element source
                        music_player.src = files[i];
                        var audioId = $('audio[src="' + files[i] + '"]')[1].id;
                        var audio = document.getElementById(audioId);
                        audio.play();
                        music_player.play();
                        $("#btnplayClientPalyList").addClass("pauseBtn");
                        $("#imgPlayList").attr("src", "/assets/img/icon/pause.png");
                        $.get("/Audio/SaveClientListenAudio", { Id: audioId.split("audio_")[1], playlistId: "0", src: "" }).done(function () {
                        });
                    }

                    // Check if the player is selected
                    if (music_player === null) {
                        throw "Playlist Player does not exists ...";
                    } else {
                        // Start the player
                        music_player.src = files[i];
                        // Listen for the music ended event, to play the next audio file
                        music_player.addEventListener('ended', next, false)


                    }
                });
            }
        }

    }
    else {
        audio.pause();
        if (playlistId != "0") {
            $("#btnplayClientPalyList").removeClass("pauseBtn");
            $("#imgPlayList").attr("src", "/assets/img/icon/v.png");
            var music_player = document.getElementById("AudioPlaylist_" + playlistId);
            music_player.pause();
        }
    }
}



function RunningPlaylist(id) {
    debugger;
    // Playlist array
    var music_player = document.getElementById("AudioPlaylist_" + id);
    var playlistId = $("#playlistKey").val();
    if (typeof (playlistId) == "undefined") {
        var sounds = document.getElementsByTagName('audio');
        for (i = 0; i < sounds.length; i++) {
            if (sounds[i] != music_player)
                sounds[i].pause();
        }
    }
    if (typeof ($("#AudioPlaylist_" + id).attr('src')) != "undefined") {
        if (typeof (playlistId) == "undefined") {
            if (music_player.duration > 0 && !music_player.paused) {

                music_player.pause();
                $("#btnplayClientPalyList_" + id).removeClass("pauseBtn");
                $("#imgPlayList_" + id).attr("src", "/assets/img/icon/v.png");

            } else {

                music_player.play();
                $("#btnplayClientPalyList_" + id).addClass("pauseBtn");
                $("#imgPlayList_" + id).attr("src", "/assets/img/icon/pause.png");
            }
        }
        else {
            debugger;
            music_player.pause();
            var audioId = $('audio[src="' + $("#AudioPlaylist_" + id).attr('src') + '"]')[1].id;
            var audio = document.getElementById(audioId);
            if (audio.duration > 0 && !audio.paused) {
                audio.pause();
                $("#btnplayClientPalyList").removeClass("pauseBtn");
                $("#imgPlayList").attr("src", "/assets/img/icon/v.png");


            } else {
                audio.play();
                $("#btnplayClientPalyList").addClass("pauseBtn");
                $("#imgPlayList").attr("src", "/assets/img/icon/pause.png");
            }
        }

    }
    else {
        var files = [];
        $.get("/Client/GetAudioSrcOfPlaylist", { playlistId: id }).done(function (data) {
            debugger;
            files = data;
            // Current index of the files array
            var i = 0;
            //if (src != '') {
            //    i = files.indexOf(src);
            //}
            // Get the audio element

            // function for moving to next audio file
            function next() {
                // Check for last audio file in the playlist
                if (i === files.length - 1) {
                    i = 0;
                } else {
                    i++;
                }

                // Change the audio element source
                music_player.src = files[i];
                if (playlistId == "undefined") {
                    debugger;
                    var audioId = $('audio[src="' + files[i] + '"]')[1].id;
                    var audio = document.getElementById(audioId);
                    if (audio.duration > 0 && !audio.paused) {
                        audio.pause();
                    } else {
                        audio.play();
                    }
                }
                else {
                    $.get("/Audio/SaveClientListenAudio", { Id: "0", playlistId: id, src: files[i].split("Audios/")[1] }).done(function () {
                    });
                }
            }

            // Check if the player is selected
            if (music_player === null) {
                throw "Playlist Player does not exists ...";
            } else {
                // Start the player
                music_player.src = files[i];
                // Listen for the music ended event, to play the next audio file
                music_player.addEventListener('ended', next, false)
                if (i == 0 && typeof (playlistId) == "undefined") {
                    $("#btnplayClientPalyList_" + id).addClass("pauseBtn");
                    music_player.play();
                    $("#imgPlayList_" + id).attr("src", "/assets/img/icon/pause.png");
                }


                else {
                    var audioId = $('audio[src="' + files[i] + '"]')[1].id;
                    document.getElementById(audioId).play();
                    $("#btnplayClientPalyList").addClass("pauseBtn");
                    $("#imgPlayList").attr("src", "/assets/img/icon/pause.png");
                }

            }
        });


    }

}

$(function () {
    $('#btnLogin').click(function (evt) {

        if ($('#frmLogin').valid()) {

            var form = $('#frmLogin');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                debugger;
                if (res == "1")
                    window.location.href = "/Home/Index";
                else if (res == "-1")
                    $("#divError").text(message.errorLogin);
                else if (res == "-2")  //emailverfied
                    $("#divError").text(message.notemailverfied);
                else if (res == "-3")  //notactive
                    $("#divError").text(message.notactive);
            });
        }

    });

    $('#btnRegister').click(function (evt) {
        debugger;
        if ($('#frmRegister').valid()) {
            debugger;

            if ($("#AgreeTerms").prop('checked') == false) {
                warningAlert(message.agreeterms);
                return false;
            }

            var form = $('#frmRegister');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == "1") {

                    $(".bd-example-modal-xl2").modal('hide');
                    SuccessArlet(message.activationlinksend);

                }
                else if (res == "2")
                    warningAlert(message.notactiveaccount);
                else if (res == "3")
                    warningAlert(message.emailexist);
            });
        }
    });


    $('.returnpassword').click(function (evt) {

        if ($('#frmForgetPassword').valid()) {

            var form = $('#frmForgetPassword');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == "1") {
                    $("#exampleModalCenter").modal('hide');
                    var email = $("#emailForgetPassword").val();
                    $("#exampleModalCenter2 #testmodal").text(email);
                    //document.getElementById("testmodal").href = "mailto:" + email;
                    $("#exampleModalCenter2").modal();
                    $("#emailForgetPassword").val("");
                }
                else if (res == "-1") {
                    warningAlert("email not found");
                }
                else if (res == "-2") {
                    warningAlert("error");
                }

            });
        }
        $("#email-error").css("display", "none");


    });

    $('#btnResetPassword').click(function (evt) {
        if ($('#frmResetPassword').valid()) {
            var form = $('#frmResetPassword');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == "1") {
                    SuccessArlet("Success");
                    window.location.href = "/";
                }
                else if (res == "-1") {
                    warningAlert("email not found");
                }

            });
        }
    });




    $(".hideLogin").click(function (evt) {
        $(".bd-example-modal-xl").modal('hide');
    });


    $(".hideRegister").click(function (evt) {

        $(".bd-example-modal-xl2").modal('hide');
    });



    $(".forgetPassword").click(function (evt) {
        $(".bd-example-modal-xl").modal('hide');
    });




});

function ShareFuncation(shareLink, SharedId, sharedType) {
    $.get("/Home/GetShareModal", { shareLink: shareLink, sharedId: SharedId, sharedType: sharedType }).done(function (res) {
        $("#exampleModalCenterShare").html("").append(res);
    });
}
function SaveShare(SharedType, SharedId, redirectUrl) {
    $.get("/Audio/ClientShare", { SharedType: SharedType, SharedId: SharedId, redirectUrl: redirectUrl }).done(function (res) {
        window.open(res, '_blank')
    });
}
