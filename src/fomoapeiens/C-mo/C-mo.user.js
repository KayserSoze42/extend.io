// ==UserScript==
// @name         C-mo
// @version      0.2.4
// @description  C mo or Less
// @author       Ydobon
// @match        *://<<REDACTED>>*
//
// @homepage     none
// @updateurl    none
//
// @grant        none
// ==/UserScript==

(function() {

    //----------------------------------------------------------------------------------------------------------------------------------------------------

    // Set variables

    // Set Regex Patterns

    const torrentsPattern = /(torrents\.php\?id\=\d+)/;
    const torrentsIDPattern = /(torrents\.php\?id\=\d+&torrentid\=\d+)/;

    // Get All Discog Elements By Class Name

    var GroupDiscogs = document.getElementsByClassName("group discog");
    var TorrentDiscogs = document.querySelectorAll("tr.group_torrent.discog");
    var FirstTorrentDiscogs = document.querySelectorAll("tr.group_torrent.discog.first");

    var heads = document.getElementsByClassName("head");
    var bodies = document.getElementsByClassName("body");

    var torTable = document.getElementsByClassName("torrent_table")[0];

    var torrentArray = [];
    var torrentNFOArray = [];
    var infoFlag = false;

    var commentArray = [];

    //------------------------------------------------------------

    var loadingDiv = document.createElement("div");
    loadingDiv.setAttribute("style", "display: none; text-align: center; background: black; border: thin solid white; position: fixed; z-index: 3; left: 4%; top: 25%");

    var loadingDivText = document.createElement("p");
    loadingDivText.innerHTML = "<strong>Fetching Torrent Info...</strong>";
    loadingDiv.appendChild(loadingDivText);

    // Create temp div for torrent info

    var infoDiv = document.createElement("div");

    infoDiv.setAttribute("style", "display: none; text-align: center; background: black; border: thin solid white; position: fixed; z-index: 3; padding: 5px; left: 37%");

    // Create text elements for torrent info

    var infoDivContent1 = document.createElement("p");
    var infoDivContent2 = document.createElement("p");
    var infoDivContent3 = document.createElement("p");

    var generalHeader = document.createElement("p");
    generalHeader.innerHTML = "<strong>General</strong>";
    generalHeader.style.fontSize = "12px";

    var videoHeader = document.createElement("p");
    videoHeader.innerHTML = "<strong>Video</strong>";
    videoHeader.style.fontSize = "12px";

    var audioHeader = document.createElement("p");
    audioHeader.innerHTML = "<strong>Audio</strong>";
    audioHeader.style.fontSize = "12px";

    infoDiv.appendChild(generalHeader);
    infoDiv.appendChild(videoHeader);
    infoDiv.appendChild(audioHeader);

    //------------------------------------------------------------

    // Create temp body for the comments and header div

    var tempBody = document.createElement("div");

    tempBody.setAttribute("style", "display: none; text-align: center; background: black; border: thin solid white; position: fixed; z-index: 4; padding: 5px");

    // Create Empty Div For The Header

    var tempHeaderDiv = document.createElement("div");

    tempHeaderDiv.style.position = "sticky";

    // Create Empty Div To Parent The Comments

    var tempDiv = document.createElement("div");

    tempDiv.setAttribute("style", "width: 95%; margin-left: 2.5%; height: 95%");

    // Create exit button for the header

    var tempExitDiv = document.createElement("a");
    var tempExitDivText = document.createTextNode("");

    tempExitDiv.appendChild(tempExitDivText);
    tempExitDiv.innerHTML = "<strong>EXIT[X]</strong>";

    // Add on click listener for the exit button

    tempExitDiv.addEventListener("click", function() {

        tempDiv.innerHTML = "";
        tempBody.innerHTML = "";
        tempBody.style.display = "none";

    });

    tempHeaderDiv.appendChild(tempExitDiv);

    //------------------------------------------------------------

    // Check If The Page Loaded Is Torrent

    if ( ( window.location.href.indexOf("torrents.php") > -1 ) && (window.location.href.indexOf("searchstr") == -1) ) {

        //------------------------------------------------------------

        // Add Show/Hide Torrents Button above the Torrent Table

        var hideTorrentsDiv = document.createElement("div");
        hideTorrentsDiv.className = "head";

        var hideTorrents = document.createElement("a");
        var hideTorrentsText = document.createTextNode("");

        hideTorrents.appendChild(hideTorrentsText);
        hideTorrentsDiv.appendChild(hideTorrents);
        hideTorrentsDiv.id = "HIDETORRENTS";
        hideTorrents.innerHTML = "<strong>Hide Torrents</strong>";

        document.getElementsByClassName("main_column")[0].prepend(hideTorrentsDiv);

        // Add On Click Listener for the Show/Hide Torrents Button

        hideTorrentsDiv.addEventListener("click", function() {

            if (torTable.style.display != "none") {

                torTable.style.display = "none";
                hideTorrents.innerHTML = "<strong>Show Torrents</strong>";

            } else {

                torTable.style.display = "";
                hideTorrents.innerHTML = "<strong>Hide Torrents</strong>";

            }

        });

        //------------------------------------------------------------

        // Iterate Over All Head Elements

        for (var k = 0; k < heads.length; k++) {

            // Add On Click Event Listener For Title (Head) Of The Info Box

            if (heads[k].innerHTML == "<strong>Show info</strong>" || heads[k].innerHTML == "<strong>Hide info</strong>") {

                heads[k].innerHTML = ( heads[k].innerHTML == "<strong>Show info</strong>" ) ? "<strong>Hide info</strong>" : "<strong>Show info</strong>";

                heads[k].addEventListener("click", function() {

                    toggleInfo(this, bodies[1]);

                });

                heads[k].click();

            }

        }

        //------------------------------------------------------------

        // Else if it's on the search page

    } else if ( ( window.location.href.indexOf("series.php") > -1 ) && (window.location.href.indexOf("searchstr") == -1) ) {

        // Iterate Over GroupDiscogs Elements

        for (var i = 0; i < GroupDiscogs.length; i++ ) {

            // Create C MO Button Element

            var ALink = document.createElement("a");
            var ALinkText = document.createTextNode("C-mo");

            // Get Torrent IDs From Links

            const foundTorrentIDs = GroupDiscogs[i].innerHTML.match(torrentsPattern);
            torrentArray.push(foundTorrentIDs[0]);

            // Add Text To The Button

            ALink.appendChild(ALinkText);

            ALink.title="C some MO";

            // Add On Click Event Listener For The C MO Button

            ALink.addEventListener("click", function() {

                tempBody.innerHTML = "";
                tempDiv.innerHTML = "";
                tempBody.style.display = "block";

                var xmlRequest = new XMLHttpRequest();

                xmlRequest.onreadystatechange = function () {

                    if (this.readyState == 4 && this.status == 200) {

                        // Manage comments

                        manageComments("https://<<REDACTED>>/" + foundTorrentIDs[0], xmlRequest.responseText);

                    }

                };

                // Send the request for the torents page

                xmlRequest.open("GET", "https://<<REDACTED>>/" + foundTorrentIDs[0], true);

                xmlRequest.send();

            });

            // And Add Button To The GroupDiscogs Element

            GroupDiscogs[i].appendChild(ALink);

        }

        //------------------------------------------------------------

        document.getElementById("series").prepend(loadingDiv);

        loadingDiv.style.display = "block";

        torrentInfoManager(torrentArray.pop());

    }

    //----------------------------------------------------------------------------------------------------------------------------------------------------

    // Toggle Info Visibility

    function toggleInfo (infoHead, infoElement) {

        if (infoElement.style.display == "none") {

            infoElement.style.display = "";
            infoHead.innerHTML = "<strong>Hide info</strong>";


        } else {

            infoElement.style.display = "none";
            infoHead.innerHTML = "<strong>Show info</strong>";

        }

    }

    //------------------------------------------------------------

    // Comments Manager

    function manageComments (currentURL, xmlResponse) {

        xmlResponse = (new DOMParser()).parseFromString(xmlResponse, "text/html");

        // Reset Comment Array

        commentArray.length = 0;

        // Check if there are multiple pages

        if (xmlResponse.getElementsByClassName("linkbox")[xmlResponse.getElementsByClassName("linkbox").length-1].innerHTML.indexOf("Last") > -1) {

            var tempCommentPages = xmlResponse.getElementsByClassName("linkbox")[xmlResponse.getElementsByClassName("linkbox").length-1].children;

            for (var linkboxChildCount = tempCommentPages.length-3; linkboxChildCount >= 0; linkboxChildCount--) {

                // Append URLs to the Array, starting with the last page

                if (tempCommentPages[linkboxChildCount].href != null) {

                    commentArray.push(tempCommentPages[linkboxChildCount].href);

                }

            }

        }

        // Append current page's URL, reverse them and then start appending to the div

        commentArray.push(currentURL);

        commentArray = commentArray.reverse();

        getAndAppend(commentArray.pop());


    }

    //------------------------------------------------------------

    // Comments Fetcher

    function getAndAppend (url) {

        var tempXMLR = new XMLHttpRequest();

        tempXMLR.onreadystatechange = function () {

            if (this.readyState == 4 && this.status == 200) {

                var tempResponse = tempXMLR.responseText;
                tempResponse = (new DOMParser()).parseFromString(tempResponse, "text/html");

                // Get the main columns comments

                const tempPageComments = tempResponse.querySelectorAll(".forum_post.box.vertical_margin");

                // Iterate from the last one

                for (var tempCount = tempPageComments.length-1; tempCount >= 0; tempCount--) {

                    // Append them to the div

                    tempDiv.appendChild(tempPageComments[tempCount]);

                }

                // If there are no comments

                if (tempPageComments.length == 0) {

                    // Create and append No Comments header to the div

                    var noCommentDiv = document.createElement("h1");
                    var noCommentDivText = document.createTextNode("NO COMMENTS");

                    noCommentDiv.appendChild(noCommentDivText);
                    noCommentDiv.style.marginTop = "22%";
                    tempDiv.appendChild(noCommentDiv);

                    // Set the body width and height

                    tempBody.style.width = "30%";
                    tempBody.style.height = "30%";
                    tempBody.style.left = "30%";
                    tempDiv.style.overflow = "hidden";

                } else {

                    tempBody.style.left = "22.5%";
                    tempBody.style.height = "50%";
                    tempBody.style.width = "55%";

                    tempDiv.style.overflowY = "scroll";

                }

                tempBody.appendChild(tempHeaderDiv);
                tempBody.appendChild(tempDiv);

                if (commentArray.length) {

                    getAndAppend(commentArray.pop());

                } else {

                    document.getElementsByClassName("thin")[0].prepend(tempBody);

                }

            }

        };

        tempXMLR.open("GET", url, true);
        tempXMLR.send();

    }

    //------------------------------------------------------------

    // Torrent Info Div Manager

    function torrentInfoManager(url) {

        var infoXMLR = new XMLHttpRequest();

        infoXMLR.onreadystatechange = function () {

            if (this.readyState == 4 && this.status == 200) {

                var tempResponse = infoXMLR.responseText;
                tempResponse = (new DOMParser()).parseFromString(tempResponse, "text/html");

                var tempTorrentInfo = Array.from(tempResponse.getElementsByClassName("torrent_table")[0].getElementsByClassName("pad"));

                for (var i = tempTorrentInfo.length - 1; i >=0;i--){

                    try {

                        torrentInfoRegex(tempTorrentInfo[i].getElementsByTagName("blockquote")[1].innerHTML);

                    } catch (e) {

                        torrentInfoRegex("N/a");

                    }



                }

                if (torrentArray.length) {

                    torrentInfoManager(torrentArray.pop());

                } else {

                    setInfoListeners();

                }



            }

        }

        infoXMLR.open("GET", "https://<<REDACTED>>/" + url, true);
        infoXMLR.send();

    }

    function torrentInfoRegex(text) {

        // console.log(text);

        // General Info

        let tempFormat = "N/A";
        let tempFileSize = "N/A";
        let tempFileLength = "N/A";


        // Video Info

        let tempVideoFormat = "N/A";
        let tempResolution = "N/A";
        let tempAspect = "N/A";
        let tempFramerate = "N/A";
        let tempVideoBitrate = "N/A";

        // Audio Info

        let tempAudioFormat = "N/A";
        let tempChannels = "N/A";
        let tempAudioBitrate = "N/A";

        try {
            tempFormat = text.match(/Format\s+:\s+(\w+)|Container\s+:\s+(\w+)/)[1] == null ? text.match(/Format\s+:\s+(\w+)|Container\s+:\s+(\w+)/)[2] : text.match(/Format\s+:\s+(\w+)|Container\s+:\s+(\w+)/)[1];
        } catch (e) {

            try {
                tempFormat = text.match(/([Aa][Vv][Ii]|[Mm][Kk][Vv]|[Mm][Pp][Ee][Gg])/)[1];
            } catch (e) {}

        }

        try {
            tempFileSize = text.match(/[Ff]*ile*\s+[Ss]ize\s+:\s+(\W*\d+\.*\s*\d*\s+\w+)/)[1];

        } catch (e) {}

        try {
            tempFileLength = text.match(/[Dd]uration\s+:\s+(\W*\d+\s*\w*\s*\d+\s*\w*)/)[1];

        } catch (e) {}


        try {
            tempVideoFormat = text.match(/(AVC|[Xx][Vv][Ii][Dd]|[Dd][Ii][Vv][Xx]|[Mm][Pp][Ee][Gg])/)[1];
        } catch (e) {}

        let tempW = "";
        let tempH = "";

        try {
            tempW = text.match(/[Ww]idth\s*:\s*(\d+\s*\d*)/)[1];
        } catch (e) {}

        try {
            tempH = text.match(/[Hh]eight\s*:\s*(\d+\s*\d*)/)[1];
        } catch (e) {}

        if (tempW != "" && tempH != "") {
            tempW = tempW.replace(" ", "");
            tempH = tempH.replace(" ", "");
            tempResolution = tempW + "x" + tempH;
        } else {
            try {
                tempResolution = text.match(/(\d+\s*\d*[Xx]\d+\s*\d*)/)[1];
            } catch (e) {}
        }

        try {
            tempAspect = text.match(/[Rr]atio\s*:\s*(\d+\s*:\s*\d+)/)[1];
        } catch (e) {}

        try {
            tempFramerate = text.match(/(\d+\.*\d*\s*[Ff][Pp][Ss])/)[1];
        } catch (e) {}

        let tempDivContent1 = "Container: " + tempFormat + " || File Size: " + tempFileSize + " || Length: " + tempFileLength;
        let tempDivContent2 = "Codec: " + tempVideoFormat + " || Resolution: " + tempResolution + " || Aspect Ratio: " + tempAspect + " || Framerate: " + tempFramerate + " || Bitrate: " + tempVideoBitrate;
        let tempDivContent3 = "Codec: " + tempAudioFormat + " || Channels: " + tempChannels + " || Bitrate: " + tempAudioBitrate;

        let tempArray = [];
        tempArray.push(tempDivContent1);
        tempArray.push(tempDivContent2);
        tempArray.push(tempDivContent3);

        torrentNFOArray.push(tempArray);

    }

    function torrentInfoShow (tempArray) {

        infoDivContent1.innerHTML = tempArray[0];
        infoDivContent2.innerHTML = tempArray[1];
        infoDivContent3.innerHTML = tempArray[2];

        infoDiv.insertBefore(infoDivContent1, videoHeader);
        infoDiv.insertBefore(infoDivContent2, audioHeader);
        infoDiv.appendChild(infoDivContent3);

        infoDiv.style.display = "block";

        document.getElementById("series").prepend(infoDiv);

    }

    function torrentInfoHide () {

        infoDivContent1.innerHTML = "";
        infoDivContent2.innerHTML = "";
        infoDivContent3.innerHTML = "";

        infoDiv.style.display = "none";

    }

    function setInfoListeners() {

        Array.from(document.querySelectorAll("td > a")).forEach(element => {

            if (element.href.match(torrentsIDPattern)){

                let tempArray = torrentNFOArray.pop();

                element.addEventListener("mouseover", function(event) {

                    infoDiv.style.top = (event.clientY + 50) + "px";
                    torrentInfoShow(tempArray);

                });

                element.addEventListener("mouseout", function(event) {

                    torrentInfoHide();

                });

            }



        });

        loadingDiv.style.display = "none";

    }

})();