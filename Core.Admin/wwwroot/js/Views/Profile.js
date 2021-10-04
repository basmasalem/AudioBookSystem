var changeImgAction = $("#frmChangePhoto").attr('action');
var restPassAction = $("#frmChangePassword").attr('action');

function SaveChangePhoto() {
    debugger;
    if ($("#frmChangePhoto").valid()) {
        $.post(changeImgAction, $("#frmChangePhoto").serialize(), function (res) {

            if (res.code == "1") {
                debugger;
                alert("تم التعديل بنجاح");
                $("#adminImg").attr("src", res.imgSrc);
            }

        });
    }

}


function SavePassword() {
    debugger;
    if ($("#frmChangePassword").valid()) {
        $.post(restPassAction, $("#frmChangePassword").serialize(), function (res) {
            debugger;
            alert("تم التعديل بنجاح");
        })
    }

}

