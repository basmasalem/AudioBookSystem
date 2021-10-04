



$(function () {
    $('#btnEditprofile').click(function (evt) {
        if ($("#OldPassword").val() == "" && $("#NewPassword").val() == "" &&  $("#ConfirmNewPassword").val() == "") {
            var pass = $("#HiddenOldPassword").val();
            $("#OldPassword").val(pass);
            $("#NewPassword").val(pass);
            $("#ConfirmNewPassword").val(pass);
        }

        if ($('#frmEditProfile').valid()) {

            var form = $('#frmEditProfile');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == "1") {
                    SuccessArlet(message.successeditprofile);
                    window.location.href = "/Home/Index";
                }
                else if (res == "-1") {
                    warningAlert(message.erroreditprofile);
                }
                else if (res == "-2") {
                    warningAlert(message.erroroldpassword);
                }
     
            });
        }

    });



});




function uploadImage() {

    var formdata = new FormData();
    var fileInput = document.getElementById('clientImage');
    if (fileInput.files.length > 0) {
        $("#loaderImg").show();

        for (i = 0; i < fileInput.files.length; i++) {

            if (!fileInput.files[i].name.endsWith(".pdf") || !fileInput.files[i].name.endsWith(".doc") || !fileInput.files[i].name.endsWith(".docx")) {
                if (fileInput.files[i].size > 6000000) {
                    $("#loaderImg").hide();
                    $("#clientImage").val("");

                    warningAlert("لا يمكن رفع صورة اكبر من 600 كيلو ")
                    return false;
                }
            }
            else {
                $("#loaderImg").hide();

                $("#clientImage").val("");
                warningAlert(" يجب رفع صورة  ");
                return false;

            }

            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }


        var desc = "qqq";
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Base/UploadFile');
        xhr.send(formdata);
        xhr.onreadystatechange = function (ress) {

            if (xhr.readyState == 4 && xhr.status == 200) {
              
                var res = JSON.parse(ress.currentTarget.responseText);
                document.getElementById("userImage").src = res.path;
                $('#clientImageval').val(res.src);
                $("#loaderImg").hide();
  

            }
        }
    } else {
        console.log("no files");
    }

}
