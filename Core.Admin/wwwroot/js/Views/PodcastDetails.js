

var placeHolderElment = $('#AudioSrcDiv');
function GetPodcastAudioSrc(id) {
    debugger;
    var url = $("#btnShowAudioSrc_"+id).data('url');
    var decodeUrl = decodeURIComponent(url);

    $.get(decodeUrl).done(function (data) {
        placeHolderElment.html(data);
        $('#PodcastAudioCenterModal').modal('show');
    });
}