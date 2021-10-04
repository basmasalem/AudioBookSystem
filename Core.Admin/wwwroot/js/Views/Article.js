var ArticleDiv = $("#divListArticle");
$(function () {

    $('#btnSearchArticle').click(function (evt) {
        debugger;
        var form = $('#frmSearchArticle');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();
        $.post(actionUrl, sendData).done(function (res) {
            ArticleDiv.html(res);
        });

    });
});

function DeleteArticle(id) {
    debugger;
    var url = $("#btnArticleDelete_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateArticle();
            alert("تم الحذف بنجاح");
        }
    });
}

function ChangeStatusArticle(id) {
    debugger;
    var url = $("#btnArticleStatus_" + id).data('url');
    $.post(url, { "id": id }, function (res) {
        if (res == "1") {
            updateArticle();
            alert("تم التعديل بنجاح");
        }
    });
}

function ConfirmChangeStatusArticle(id) {
    debugger;
    confirmAlert("هل تريد تغير حالةالمقال؟", ChangeStatusArticle, id);
}
function ConfirmDeleteArticle(id) {
    debugger;
    confirmAlert("هل تريد حذف هذا المقال؟", DeleteArticle, id);
}


function updateArticle() {
    var urlArticle = ArticleDiv.data('request-url');
    $.get(urlArticle).done(function (res) {
        debugger;
        ArticleDiv.html(res);
    });

}