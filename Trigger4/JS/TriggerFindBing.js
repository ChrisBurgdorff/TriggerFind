$(document).ready(function () {


    //Declarations
    var buttonArray = ['.hiring', '.merger', '.sales', '.contracts', '.training', '.location', '.cfo', '.all'];
    var searchTerm = "";
    var indexNum = 0;
    var ema = "";
    var mes = "";
    var imageName = ["http://www.triggerfind.com/images/menublack.png", "http://www.triggerfind.com/images/xblack.png"];

    //Sets "disabled" look for all but selected Trigger Buttons
    function SelectTrigger(triggerIndex) {
        for (i = 0; i < 8; i++) {
            if (i != triggerIndex) {
                $(buttonArray[i]).css("background-color", "#8e8e8e");
                $(buttonArray[i]).css("border", "solid #ffffff 1px");
            }
        }
    }



    $("#closeError").click(function() {
        $("#errorBox").hide(300);
    });

    $(".about").click(function () {
        $("#menuBar").slideToggle(300);
        $("#aboutBox").show(300);
        if (indexNum != 0) {
            $(".fullMenu").slideToggle(300);
            $("#menuList").slideToggle(300);
        }
    });
    $("#closeAbout").click(function () {
        $("#menuBar").slideToggle(300);
        $("#aboutBox").hide(300);
        if (indexNum != 0) {
            $(".fullMenu").slideToggle(300);
            $("#menuList").slideToggle(300);
        }
    });
    $(".contact").click(function () {
        $("#menuBar").slideToggle(300);
        $("#contactBox").show(300);
        if (indexNum != 0) {
            $(".fullMenu").slideToggle(300);
            $("#menuList").slideToggle(300);
        }
    });
    $("#closeContact").click(function () {
        $("#menuBar").slideToggle(300);
        $("#contactBox").hide(300);
        if (indexNum != 0) {
            $(".fullMenu").slideToggle(300);
            $("#menuList").slideToggle(300);
        }
    });

    //For each trigger button clicked, changes to "selected" look and sets proper search term
    $(".hiring").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "hiring";
        SelectTrigger(0);
    });
    $(".merger").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "merger";
        SelectTrigger(1);
    });
    $(".sales").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "sales";
        SelectTrigger(2);
    });
    $(".contracts").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "contracts";
        SelectTrigger(3);
    });
    $(".training").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "training";
        SelectTrigger(4);
    });
    $(".location").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "location";
        SelectTrigger(5);
    });
    $(".cfo").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "cfo";
        SelectTrigger(6);
    });
    $(".all").click(function () {
        $(this).css("border", "solid #0d0d0d 5px");
        $(this).css("color", "#0d0d0d");
        $(this).css("background-color", "Transparent");
        searchTerm = "all";
        SelectTrigger(7);
    });

    //"Clicks" search button when enter is pressed within text box
    $("#search").keyup(function (event) {
        if (event.keyCode == 13) {
            $("#searchBtn").click();
        }
    });

    //hiring merger sales contracts
    //training location cfo all

    //Changes Menu Icon to X and Back with smooth fade
    $("#menuImage").click(function () {
        $("#menuImage").fadeOut(300, function () {
            if (indexNum > 0) {
                $("#navcontainer").fadeIn(300);
                indexNum = 0;
            } else {
                $("#navcontainer").fadeOut(300);
                indexNum = 1;
            }
            $("#menuImage").attr("src", imageName[indexNum]);
            $("#menuImage").fadeIn(500);
        });
    });

    //Display changes for blog:
    $(".commentsLink").click(function () {
        $('.comments').css('display', 'block');
    });

    $(".addCommentLink").click(function () {
        $('.commentMaker').css('display', 'block');
        $(this).css('display', 'none');
    });

    //Slides out or hides menu on click
    $(function () {
        var pull = $('#menuImage');
        menu = $('.fullMenu');
        menuHeight = menu.height();
        var menuOut = false;

        $(pull).on('click', function (e) {
            if (menuOut) {
                $("#menuList").animate({
                    "left": "-250px"
                }, 500);
                e.preventDefault();
                menu.delay(500).slideToggle();
                menuOut = false;
            } else {
                e.preventDefault();
                menu.slideToggle();
                $("#menuList").delay(300).animate({
                    "left": "20px"
                }, 500);
                menuOut = true;
            }
        });
    });

    //Intialize variables
    var queryURLstart = "http://www.faroo.com/api?q=";
    var queryURLend = "&start=1&length=10&l=en&src=news&i=false&f=json&key=zTRCQ6UGxYyA6Jp7PrCScYeYq6g_";
    var queryURL = "";
    var searchCompany = "";
    var newSearchTerm = "";
    var storyText = "";
    var storyTextArray;
    var result = "";
    var titleText = "";
    var finalTitle = "";
    var finalString = "";
    var resultString = "";
    var articleDate;
    var daysSince;
    var alerted = false;
    var articleURL = "";
    var imageURL = "";
    var daysToSearch;

    function Finalize() {
        if (alerted) {
            $("#nothing").append('<h2>' + 'inside alerted' + '</h2>');
            $("#alerts").append('<h2>' + "Possible Triggers - Click To Expand" + '</h2>');
            $("#alerts").fadeIn(300);
            $("#newSearch").append('<h2>' + "New Search" + '</h2>');
            $("#newSearch").fadeIn(300);
            $(".loader").hide();
        } else {
            $("#nothing").append('<h2>' + "Nothing Found" + '</h2>');
            $("#nothing").fadeIn(300);
            $("#newSearch").append('<h2>' + "New Search" + '</h2>');
            $("#newSearch").fadeIn(300);
            $(".loader").hide();
        }
    };

    function TestOne(trigger, testSearch, testStory, testTitle) {
        var myResult = "Null";
        var searchTermWords = testSearch.split(" ");
        var storyTextArray = testStory.split(" ");
        var titleTextArray = testTitle.split(" ");
        for (j = 0; j < storyTextArray.length; j++) {
            if (storyTextArray[j].toLowerCase() == trigger.toLowerCase()) {
                myResult = "Found";
            }
        }
        for (k = 0; k < titleTextArray.length; k++) {
            if (titleTextArray[k].toLowerCase() == trigger.toLowerCase()) {
                myResult = "Found";
            }
        }
        return myResult;
    }

    function TestTwoOr(trigger1, trigger2, testSearch, testStory, testTitle) {
        var myResult = "Null";
        var foundOne = false;
        var foundTwo = false;
        var searchTermWords = testSearch.split(" ");
        var storyTextArray = testStory.split(" ");
        var titleTextArray = testTitle.split(" ");
        for (j = 0; j < storyTextArray.length; j++) {
            if (storyTextArray[j].toLowerCase() == trigger1.toLowerCase()) {
                foundOne = true;
            }
        }
        for (k = 0; k < titleTextArray.length; k++) {
            if (titleTextArray[k].toLowerCase() == trigger1.toLowerCase()) {
                foundOne = true;
            }
        }
        for (l = 0; l < storyTextArray.length; l++) {
            if (storyTextArray[l].toLowerCase() == trigger2.toLowerCase()) {
                foundTwo = true;
            }
        }
        for (m = 0; m < titleTextArray.length; m++) {
            if (titleTextArray[m].toLowerCase() == trigger2.toLowerCase()) {
                foundTwo = true;
            }
        }
        if (foundOne || foundTwo) {
            myResult = "Found";
        }
        return myResult;
    }

    function TestTwoAnd(trigger1, trigger2, testSearch, testStory, testTitle) {
        var myResult = "Null";
        var foundOne = false;
        var foundTwo = false;
        var searchTermWords = testSearch.split(" ");
        var storyTextArray = testStory.split(" ");
        var titleTextArray = testTitle.split(" ");
        for (j = 0; j < storyTextArray.length; j++) {
            if (storyTextArray[j].toLowerCase() == trigger1.toLowerCase()) {
                foundOne = true;
            }
        }
        for (k = 0; k < titleTextArray.length; k++) {
            if (titleTextArray[k].toLowerCase() == trigger1.toLowerCase()) {
                foundOne = true;
            }
        }
        for (l = 0; l < storyTextArray.length; l++) {
            if (storyTextArray[l].toLowerCase() == trigger2.toLowerCase()) {
                foundTwo = true;
            }
        }
        for (m = 0; m < titleTextArray.length; m++) {
            if (titleTextArray[m].toLowerCase() == trigger2.toLowerCase()) {
                foundTwo = true;
            }
        }
        if (foundOne && foundTwo) {
            myResult = "Found";
        }
        return myResult;
    }


    //hiring merger sales contracts
    //training location cfo all
    function TestForTriggers(testSearch, testStory, testTitle) {
        var myResult = "Null";
        if (searchTerm == "hiring") {
            myResult = TestOne("hiring", testSearch, testStory, testTitle);
        } else if (searchTerm == "merger") {
            myResult = TestTwoOr("merger", "acquire", testSearch, testStory, testTitle);
        } else if (searchTerm == "sales") {
            myResult = TestTwoAnd("sales", "growth", testSearch, testStory, testTitle);
        } else if (searchTerm == "contracts") {
            myResult = TestOne("contract", testSearch, testStory, testTitle);
        } else if (searchTerm == "training") {
            myResult = TestOne("training", testSearch, testStory, testTitle);
        } else if (searchTerm == "location") {
            myResult = TestTwoAnd("office", "new", testSearch, testStory, testTitle);
        } else if (searchTerm == "cfo") {
            myResult = TestOne("cfo", testSearch, testStory, testTitle);
        } else if (searchTerm == "all") {
            myResult = TestOne("hiring", testSearch, testStory, testTitle);
            if (myResult == "Null") {
                myResult = TestTwoOr("merger", "acquire", testSearch, testStory, testTitle);
            }
            if (myResult == "Null") {
                myResult = TestTwoAnd("sales", "growth", testSearch, testStory, testTitle);
            }
            if (myResult == "Null") {
                myResult = TestOne("contract", testSearch, testStory, testTitle);
            }
            if (myResult == "Null") {
                myResult = TestOne("training", testSearch, testStory, testTitle);
            }
            if (myResult == "Null") {
                myResult = TestTwoAnd("office", "new", testSearch, testStory, testTitle);
            }
            if (myResult == "Null") {
                myResult = TestOne("cfo", testSearch, testStory, testTitle);
            }
        }
        return myResult;
    }

    function RemovePunct(words) {

        var punctuationless = words.replace(/[.,-\/#!$%\^&\*;:{}=\-_`~()]/g, "");
        var newWords = punctuationless.replace(/\s{2,}/g, " ");
        newWords = newWords.replace(/\"/g, "");
        newWords = newWords.replace(/['"]+/g, '');

        return newWords;
    }

    $("#newSearch").click(function () {
        location.reload(true);
    });

    $("#alerts").click(function () {
        $(this).fadeOut(300);
        $("#results").fadeIn(300);
    });

    function OnSuccess(response) {
        //$("#nothing").show();
        if (response.length > 0) {
            $("#results").append("<ul>");
            for (var i = 0; i < response.length; i = i + 2) {
                $("#results").append("<li>" + "<a href=\"" + response[i + 1] + "\">" + response[i] + "</a>" + "</li>");
                if (i == (response.length - 2)) {
                    $("#results").append("</ul>");
                }
            }
            $(".loader").hide();
            $("#results").fadeIn(300);
            $("html, body").scrollTop($("#results").offset().top);
        } else {
            $(".loader").hide();
            $("#nothing").append('<h2>' + "Nothing Found" + '</h2>');
            $("#nothing").fadeIn(300);
            $("html, body").scrollTop($("#nothing").offset().top);
        }
        $("#newSearch").append('<h2>' + "New Search" + '</h2>');
        $("#newSearch").fadeIn(300);
    }

    function OnFail(error) {
        $("#nothing").append("<h2>" + error + "</h2>");
        $("#nothing").fadeIn(300);
        $("html, body").scrollTop($("#nothing").offset().top);
        $("#newSearch").append('<h2>' + "New Search" + '</h2>');
        $("#newSearch").fadeIn(300);
    }

    function GetResultsFromServer(que) {
        PageMethods.MakeRequest(que, OnSuccess, OnFail);
    }

    $("#searchBtn").click(function () {
        searchCompany = document.getElementById('search').value;
        $("#results").empty();
        $("#nothing").empty();
        $("#newSearch").empty();
        if (searchTerm == "all") {
            newSearchTerm = searchCompany;
        } else {
            newSearchTerm = searchCompany + " " + searchTerm;
        }
        if(searchTerm==""||searchCompany=="")
        {
            $("#errorBox").show(300);

        } else {
            $(".loader").show();
            GetResultsFromServer(newSearchTerm);
        }
    });

});