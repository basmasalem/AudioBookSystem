$(document).ready(function () {
   
    $.ajax({
        type: "GET",
        url: "/Home/GetCategory",
        data: "{}",
        success: function (data) {
    
            $("#CategorySelect").html('');
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<a class="dropdown-item" onclick=SearchByCategory("' + data[i].text + '")>' + data[i].text + '</a>';
            }
            $("#CategorySelect").html(s);
        }
    });


   
});

function SearchByCategory(val) {
    if (val != "") {
        window.location.href = "/Audio/Index?Category=" + val;
    }
}

function SearchByName() {
    var search = $("#searchText").val();
    if (search != "") {
        window.location.href = "/Audio/Index?Name=" + search;
    }
}


function AddAudio(IsLogin) {
 
    if (IsLogin == 'False') {
        $(".bd-example-modal-xl").modal();
    } else {
        window.location.href = "/Audio/AddAudio";
    }

}