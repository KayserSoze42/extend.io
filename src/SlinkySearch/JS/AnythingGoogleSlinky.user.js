// ==UserScript==
// @name         Search for Anything on Google
// @namespace    http://tampermonkey.net/
// @version      0.1
// @description  SlinkySearch Script For A Custom Search
// @author       You
// @match        *
// @grant        GM_openInTab
// @run-at       context-menu
// ==/UserScript==
(function() {
'use strict';
var selectedText = window.getSelection().toString();
var url = "https://www.google.rs/search?q=" + selectedText + "";
GM_openInTab(url, false);
})();
