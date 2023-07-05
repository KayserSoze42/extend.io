@echo off

echo SlinkyFactory
echo Create custom searches for TamperMonkey
echo Enter the item and search name for label "Search for X on Y"
echo Enter the first and second(optional) part of the url
echo The factory will generate a XYSlinky.user.js file in current directory
echo -----
echo Enter the name of the item to be searched: (e.g. Ticket Number, ID...)
set /p searchItem=
echo -----
echo Enter the name of the search used: (e.g. Seznam, Database...)
set /p searchName=
echo -----

set fileName=%searchItem: =%%searchName: =%Slinky.user.js

echo Enter the first part of the url:
set /p firstPart=
echo -----
echo Enter the second part of the url: (Optional)
set /p secondPart=
echo -----
echo Generating and writing file:

echo // ==UserScript==>> %fileName%
echo // @name         Search for %searchItem% on %searchName%>> %fileName%
echo // @namespace    http://tampermonkey.net/>> %fileName%
echo // @version      0.1>> %fileName%
echo // @description  SlinkySearch Script For A Custom Search>> %fileName%
echo // @author       You>> %fileName%
echo // @match        *>> %fileName%
echo // @grant        GM_openInTab>> %fileName%
echo // @run-at       context-menu>> %fileName%
echo // ==/UserScript==>> %fileName%
echo (function() {>> %fileName%
echo 'use strict';>> %fileName%
echo var selectedText = window.getSelection().toString();>> %fileName%
echo var url = "%firstPart%" + selectedText + "%secondPart%";>> %fileName%
echo GM_openInTab(url, false);>> %fileName%
echo })();>> %fileName%

echo All Done! Exiting.

