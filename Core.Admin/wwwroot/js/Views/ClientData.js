var ClientDiv = $("#divListClient");
$(function () {

    $('#btnSearch').click(function (evt) {
        debugger;
        var form = $('#frmClientSearch');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            ClientDiv.html(res);
        });

    });
});

function DeleteClient(id) {
    debugger;
    var url = $("#btnClientDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateClient();
            alert("تم الحذف بنجاح");
        }
        else
            warningAlert("لا يمكن حذف هذا المستخدم لارتباطه ب playList");
    });
}

function ChangeStatusClient(id) {
    debugger;
    var url = $("#btnClientStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateClient();
            alert("تم التعديل بنجاح");
        }
    });
}

function ConfirmChangeStatusClient(id) {
    debugger;
    confirmAlert("هل تريد تغير حالة المستخدم؟", ChangeStatusClient, id);
}
function ConfirmDeleteClient(id) {
    debugger;
    confirmAlert("هل تريد حذف هذا المستخدم؟", DeleteClient, id);
}


function updateClient() {
    var urlClient = ClientDiv.data('request-url');
    $.get(urlClient).done(function (res) {
        debugger;
        ClientDiv.html(res);
    });

}