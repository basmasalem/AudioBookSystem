

function ConfirmDeleteSubscriber(id) {

    var func = "DeleteSubscriber('" + id + "')";
    var msg = message.subscriberMsg;
    ConfirmDelete(msg, func);
}


function DeleteSubscriber(id) {

    $.ajax({
        type: "GET",
        url: "/Client/DeleteSubscriber",
        data: 'key=' + id,
        success: function (res) {
            CloseConfirmDelete();
        
            $("#divSubscribersList").html(' ').append(res);
            SuccessArlet(message.SuccessDeleteMsg);
        }
    });
}


function GetSubscribers(key) {
    $.ajax({
        type: "GET",
        url: "/Client/ClientSubscribersModal",
        data: { key: key},
        success: function (res) {
            $("#clientDetailsModal").html(' ').append(res);
        }
    });
}


function GetFollowers(key) {
    $.ajax({
        type: "GET",
        url: "/Client/ClientFollowersModal",
        data: { key: key },
        success: function (res) {
            $("#clientDetailsModal").html(' ').append(res);
        }
    });
}


function ShowModal(ItemType, key) {
    debugger;
    if (ItemType == "followers") {
        GetFollowers(key);
    } else if (ItemType == "subscribers") {
        GetSubscribers(key);
    }

    $('#exampleModalCenter').modal('show');
}


function UnFollowClient(key) {
    $.ajax({
        type: "GET",
        url: "/Client/UnFollowClient",
        data: { key: key },
        success: function (res) {
            debugger;
            $("#followDiv").html(" ").append(`<div class='user_add2'><a href='javascript:void(0)' onclick="FollowClient('` + key + `');"><img id='followImg' src='/assets/img/icon/user-add2.svg'></a></div>`);
        }
    });
}


function FollowClient(key) {
    $.ajax({
        type: "GET",
        url: "/Client/FollowClient",
        data: { key: key },
        success: function (res) {
            debugger;
            //$("#followDiv").html(" ").append("<div class='user_add'><a href='javascript:void(0)' onclick='UnFollowClient('" + key + "')'><img id='unfollowImg' src='/assets/img/icon/u.png'></a></div>");
            $("#followDiv").html(" ").append(`<div class='user_add'><a href='javascript:void(0)' onclick="UnFollowClient('` + key + `');"><img id='unfollowImg' src='/assets/img/icon/u.png'></a></div>`);

        }
    });
}