var TagDiv = $("#divListTag");
$(function () {

    $('#btnSearchTag').click(function (evt) {
        debugger;
        var form = $('#frmSearchTag');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            TagDiv.html(res);
        });

    });
});

function DeleteTag(id) {
    debugger;
    if (id != 1) {
        var url = $("#btnTagDelete_" + id).data('url');
        $.post(url, { "id": id }, function (res) {
            if (res == "1") {
                updateTag();
                alert("تم الحذف بنجاح");
            }
            else
                warningAlert("لا يمكن حذف هذا الوسام لارتباطه بمستخدمين");
        });
    }
    else
        warningAlert("لا يمكن حذف هذا الوسام ");
   
}

function ChangeStatusTag(id) {
    debugger;
    if (id != 1) {
        var url = $("#btnTagStatus_" + id).data('url');
        $.post(url, { "id": id }, function (res) {
            if (res == "1") {
                updateTag();
                alert("تم التعديل بنجاح");
            }
        });
    }
    else
        warningAlert("لا يمكن تغير حالة  هذا الوسام ");

   
}

function ConfirmChangeStatusTag(id) {
    debugger;
    confirmAlert("هل تريد تغير حالةالوسام؟", ChangeStatusTag, id);
}
function ConfirmDeleteTag(id) {
    debugger;
    confirmAlert("هل تريد حذف هذا الوسام؟", DeleteTag, id);
}


function updateTag() {
    var urlTag = TagDiv.data('request-url');
    $.get(urlTag).done(function (res) {
        debugger;
        TagDiv.html(res);
    });

}