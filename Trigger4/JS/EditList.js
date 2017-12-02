$(document).ready(function () {
    $("button").click(function () {
        var fullId = $(this).attr('id');
        var idNum;
        if (fullId.substring(0, 3) == "but") {
            idNum = fullId.substring(6, 7);
            PageMethods.DeleteFromList(idNum, onSuccess, onFail);
        } //of
    });//button click
    function onFail(error) {

    }
    function onSuccess(response) {
        location.reload();
    }

    $("#litUsername").click(function () {
        $("#lnkSignout").show();
        $(this).hide();
    });//litUsername click
});//on ready