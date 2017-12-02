$(document).ready(function () {


    //Declarations
    var buttonArray = ['.hiring', '.merger', '.sales', '.contracts', '.training', '.location', '.cfo', '.all'];
    var searchTerm = "";
    var indexNum = 0;
    var imageName = ["http://www.triggerfind.com/images/menu.png", "http://www.triggerfind.com/images/x.png"];

    //Sets "disabled" look for all but selected Trigger Buttons
    function SelectTrigger(triggerIndex) {
        for (i = 0; i < 8; i++) {
            if (i != triggerIndex) {
                $(buttonArray[i]).css("background-color", "#8e8e8e");
                $(buttonArray[i]).css("border", "solid #ffffff 1px");
            }
        }
    }

    $("#about").click(function () {
        $("#menuBar").slideToggle(300);
        $("#aboutBox").show(300);
        $(".fullMenu").slideToggle(300);
        $("#menuList").slideToggle(300);
    });
    $("#closeAbout").click(function () {
        $("#menuBar").slideToggle(300);
        $("#aboutBox").hide(300);
        $(".fullMenu").slideToggle(300);
        $("#menuList").slideToggle(300);
    });
    $("#contact").click(function () {
        $("#menuBar").slideToggle(300);
        $("#contactBox").show(300);
        $(".fullMenu").slideToggle(300);
        $("#menuList").slideToggle(300);
    });
    $("#closeContact").click(function () {
        $("#menuBar").slideToggle(300);
        $("#contactBox").hide(300);
        $(".fullMenu").slideToggle(300);
        $("#menuList").slideToggle(300);
    });

    //For each trigger button clicked, changes to "selected" look and sets proper search term
    $(".hiring").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "hiring";
        SelectTrigger(0);
    });
    $(".merger").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "merger";
        SelectTrigger(1);
    });
    $(".sales").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "sales";
        SelectTrigger(2);
    });
    $(".contracts").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "contracts";
        SelectTrigger(3);
    });
    $(".training").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "training";
        SelectTrigger(4);
    });
    $(".location").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "location";
        SelectTrigger(5);
    });
    $(".cfo").click(function () {
        $(this).css("border", "solid #ffffff 5px");
        $(this).css("background-color", "Transparent");
        searchTerm = "cfo";
        SelectTrigger(6);
    });
    $(".all").click(function () {
        $(this).css("border", "solid #ffffff 5px");
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
                indexNum = 0;
            } else {
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
        $(this).fadeOut(300);r
        $("#results").fadeIn(300);
    });

    // Performs the search.
    function search(query, serviceOp) {
        $("#nothing").append('<h2>Got Insidesearch function</h2>');
        // Establish the data to pass to the proxy.
        var data = { q: query, sop: serviceOp, market: 'en-us' };
        // Calls the proxy, passing the query, service operation and market.
        $.getJSON('/bing_proxy.php', data, function (obj) {
            $("#nothing").append('<h2>Got Inside Json Bing</h2>');
            if (obj.d !== undefined) {
                var items = obj.d.results;
                for (var k = 0, len = items.length; k < len; k++) {
                    var item = items[k];
                    switch (item.__metadata.type) {
                        case 'WebResult':
                            //showWebResult(item);
                            break;
                        case 'ImageResult':
                            //showImageResult(item);
                            break;
                    }
                }
            }
        });
    }

    $("#searchBtn").click(function () {
        //$(".loader").show();
        $("#nothing").fadeIn(300);
        searchCompany = document.getElementById('search').value;
        var searchCompanyArray = searchCompany.split(" ");
        //newSearchTerm = searchCompanyArray[0];
        newSearchTerm = encodeURIComponent(searchCompany.trim());
        queryURL = queryURLstart + newSearchTerm + '%20' + searchTerm + queryURLend;
        //Faroo Shit
  /*      $.ajax({
            type: 'GET',
            url: queryURL,
            success: function (data) {
                for (i = 0; i < data.results.length; i++) {
                    storyText = data.results[i].kwic;
                    titleText = data.results[i].title;
                    finalTitle = RemovePunct(titleText);
                    finalString = RemovePunct(storyText);
                    articleDate = data.results[i].date;
                    result = TestForTriggers(newSearchTerm, finalString, finalTitle);
                    if (result == "Found") {
                        var currentDate = new Date().getTime();
                        var daysSince = currentDate - articleDate;
                        daysToSearch = 60;
                        if (daysSince < daysToSearch * 86400000) {
                            //happened within two weeks
                            alerted = true;
                            $("#nothing").append('<h2>' + alerted.toString()  + 'faroo' + '</h2>');
                            articleURL = data.results[i].url;
                            imageURL = data.results[i].iurl;
                            $("#results").append('<li>' + "<a href=\"" + articleURL + "\">" + "<img width=\"150\" height=\"150\" src=\"" + imageURL + "\">" + "</a>" + "<a href=\"" + articleURL + "\">" + titleText + "</a>");
                        }
                    }
                }
            }
        });   */
		//And now the Webhose.io shit
		queryURL = "https://webhose.io/search?token=36d3fb42-05c0-4a29-94d2-6c6bd647e16e&format=json&q=";
		queryURL = queryURL + newSearchTerm + '%20' + searchTerm + "&ts=1444187627017&site_type=news";
		$("#nothing").append('<h2>' + 'Got before success' + '</h2>');
        /*
		$.ajax({
            type: 'GET',
            url: queryURL,
            success: function (data) {
                $("#nothing").append('<h2>' + 'Got inside ajax' + '</h2>');
                for (i = 0; i < data.posts.length; i++) {
                    storyText = data.posts[i].text;
                    titleText = data.posts[i].title;
                    finalTitle = RemovePunct(titleText);
                    finalString = RemovePunct(storyText);
                    //articleDate = data.results[i].date;
                    result = TestForTriggers(newSearchTerm, finalString, finalTitle);
                    $("#nothing").append('<h2>' + alerted.toString() + '</h2>');
                    if (result == "Found") {
                        //var currentDate = new Date().getTime();
                        //var daysSince = currentDate - articleDate;
                        daysToSearch = 60;
                        //if (daysSince < daysToSearch * 86400000) 
                            //happened within two weeks
                            alerted = true;
                            articleURL = data.posts[i].url;
                            //imageURL = data.results[i].iurl;
                            $("#results").append('<li>' + "<a href=\"" + articleURL + "\">" + titleText + "</a>");
                        //
                    }
                }
            }
		});    */
        //Bing Shit
		queryURL = "https://api.datamarket.azure.com/Bing/Search/v1/Composite?Sources=%27news%2Bweb%27&Query=%27";
		queryURL = queryURL + newSearchTerm + '%20' + searchTerm + '%27&Market=%27en-US%27&NewsSortBy=%27Date%27';
		var query = newSearchTerm + '%20' + searchTerm;
		$("#nothing").append('<h2>' + 'Got before bing' + '</h2>');
		search(query, 'News');
		//accountKey = AHNwSNt5H24iDyClfGym1tG2FAR7JXku3BpmlKF4e4o;
		//var accountKeyEncoded = base64_encode(":" + accountKey);
        
		$("#nothing").append('<h2>' + alerted.toString() + '</h2>');
		$("#nothing").append('<h2>' + "Nothing Found" + '</h2>');
		$("#nothing").fadeIn(300);
		$("#newSearch").append('<h2>' + "New Search" + '</h2>');
		$("#newSearch").fadeIn(300);
		$(".loader").hide();
		var t = setTimeout(Finalize, 6000);
		//Finalize().delay(6000);
    });
});