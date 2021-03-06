﻿/// <reference path="../jquery-2.1.3.intellisense.js" />
function RateUp(e) {
    var icon = $(e.target);
    var userItemId = icon.data("item-id");
    $("#ratingError").slideToggle();
    $.ajax({
        url: "/Ajax/RatingUp/?userItemId=" + userItemId,
        method:"POST",
        success: function(response) { RateUpSuccess(icon, response) },
        error: errorToggle
    });
};

function RateDown(e) {
    var icon = $(e.target);
    var userItemId = icon.data("item-id");
    $("#ratingError").hide();
    $.ajax({
        url: "/Ajax/RatingDown/?userItemId=" + userItemId,
        method: "POST",
        success: function(response) { RateDownSuccess(icon, response) },
        error: errorToggle
    });
};

function errorToggle() {
    $("#ratingError").show();
}

function RateUpSuccess(icon, response) {
    var up = icon.parent().find(".up");
    up.hide();
    var down = icon.parent().find(".down");
    down.show();
    var greenLabel = icon.parent().find(".green");
    var greenLabelValue = Number(greenLabel.html());
    greenLabel.html(greenLabelValue + 1);
    if (response) {
        var redLabel = icon.parent().find(".red");
        var redLabelValue = Number(redLabel.html());
        redLabel.html(redLabelValue - 1);
    }
}

function RateDownSuccess(icon, response) {
    var up = icon.parent().find(".up");
    up.show();
    var down = icon.parent().find(".down");
    down.hide();
    if (response) {
        var greenLabel = icon.parent().find(".green");
        var greenLabelValue = Number(greenLabel.html());
        greenLabel.html(greenLabelValue - 1);
    }
    var redLabel = icon.parent().find(".red");
    var redLabelValue = Number(redLabel.html());    
    redLabel.html(redLabelValue + 1);
}

function RateIconsInitialization(idx,e) {
    
    var show = $(e).data("item-rate");
    if (show == "True") {
        $(e).hide();
    }
}