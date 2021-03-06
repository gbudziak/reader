﻿//Function that assigns destination for Go to channel button.
function GoTo() {
    var url = $("#Url").val();
    window.location.assign("/RssReader/ShowUserItemsByUrl/?url=" + url);
}

//Feature method for user convenience, it uses ajax call for controller action, if user has the rss channel he tryes to add on his list already button to go to channel is shows, else create button is shown.
function IsUrlInUserDatabase() {
    var url = $("#Url").val();
    $("#createSubmit").hide();
    $("#btnGoToChannel").hide();
    $.ajax({
        url: "/Validation/IsLinkInUserDatabe/?url=" + url,
        success: function (result) {
            if (result) {
                $("#createSubmit").show();
            } else {
                $("#btnGoToChannel").show();
            }
        }
    });    
    $("#wrongUrl").hide();
};

//Validation method from user side. It axaj calls controller action, if validation is true it unbinds and submits the form, if not is shows a message.
$("#AddRssForm").submit(function (event) {
    event.preventDefault();
    var url = $("#Url").val();
    $.ajax({
        url: "/Validation/IsLinkValid/?url=" + url,
        success: function (result) {
            if (result) {
                $("#AddRssForm").unbind("submit").submit();
            } else {
                $("#wrongUrl").show();
            }

        }
    });
});


$("#keyword").submit(function (event) {
    event.preventDefault();
    var id = $("#id").val();
    $.ajax({
        url: "/Search/Index/" + id,
        success: function (result) {
            if (result) {
                $("#keyword").unbind("submit").submit();
            } else {
                $("#wrongUrl").show();
            }

        }
    });
});