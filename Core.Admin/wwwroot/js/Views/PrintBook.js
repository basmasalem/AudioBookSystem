function DeletePrintBook(id) {
    debugger;
    var url = $("#btnPrintBookDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == 1) {
            updatePrintBook();
            alert("تم الحذف بنجاح");
        }
    });
}

function ChangeStatusPrintBook(id) {
    debugger;
    var url = $("#btnPrintBookStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == 1) {
            updatePrintBook();
            alert("تم التعديل بنجاح");
        }
    });
}

function ConfirmChangeStatusPrintBook(id) {
    debugger;
    confirmAlert("هل تريد تغير الحالة؟", ChangeStatusPrintBook, id);
}
function ConfirmDeletePrintBook(id) {
    debugger;
    confirmAlert("هل تريد حذف  هذا الكتاب؟", DeletePrintBook, id);
}


function updatePrintBook() {
    var urlBook = $("#divListPrintBook").data('request-url');
    $.get(urlBook).done(function (res) {
        debugger;
        $("#divListPrintBook").html(res);
    });

}