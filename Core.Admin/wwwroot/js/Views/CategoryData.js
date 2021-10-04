var CategoryDiv = $("#divListCategory");
$(function () {

    $('#btnSearch').click(function (evt) {
        debugger;
        var form = $('#frmCategorySearch');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            CategoryDiv.html(res);
        });

    });
});

function DeleteCategory(id) {
    debugger;
    var url = $("#btnCategoryDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateCategory();
            alert("تم الحذف بنجاح");
        }
        else
            warningAlert("لا يمكن حذف هذه الفئة لارتباطها بملفات صوت");
    });
}

function ChangeStatusCategory(id) {
    debugger;
    var url = $("#btnCategoryStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateCategory();
            alert("تم التعديل بنجاح");
        }
    });
}

function ConfirmChangeStatusCategory(id) {
    debugger;
    confirmAlert("هل تريد تغير الحالة؟", ChangeStatusCategory, id);
}
function ConfirmDeleteCategory(id) {
    debugger;
    confirmAlert("هل تريد حذف  فئات الكتب؟", DeleteCategory, id);
}


function updateCategory() {
    var urlCategory = CategoryDiv.data('request-url');
    $.get(urlCategory).done(function (res) {
        debugger;
        CategoryDiv.html(res);
    });

}