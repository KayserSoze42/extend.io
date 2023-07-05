Write-Output "SlinkyFactory"
Write-Output "Create custom searches for TamperMonkey"
Write-Output "Enter the item and search name for label 'Search for X on Y'"
Write-Output "Enter the first and second(optional) part of the url"
Write-Output "The factory will generate a XYSlinky.user.js file in current directory"
Write-Output "-----"
Write-Output "Enter the name of the item to be searched: (e.g. Ticket Number, ID...)"
$searchItem = Read-Host -Prompt :
Write-Output "-----"
Write-Output "Enter the name of the search used: (e.g. Seznam, Database...)"
$searchName = Read-Host -Prompt :
Write-Output -----

$fileName = $searchItem.Trim() + $searchName.Trim() + "Slinky.user.js"

Write-Output "Enter the first part of the url:"
$firstPart = Read-Host -Prompt :
Write-Output "-----"
Write-Output "Enter the second part of the url: (Optional)"
$secondPart = Read-Host -Prompt :
Write-Output "-----"
Write-Output "Generating and writing file:"

$fileLines = @(
"// ==UserScript==",
"// @name         Search for $searchItem on $searchName",
"// @namespace    http://tampermonkey.net/",
"// @version      0.1",
"// @description  SlinkySearch Script For A Custom Search",
"// @author       You",
"// @match        *",
"// @grant        GM_openInTab",
"// @run-at       context-menu",
"// ==/UserScript==",
"(function() {",
"'use strict';",
"var selectedText = window.getSelection().toString();",
"var url = '$firstPart' + selectedText + '$secondPart';",
"GM_openInTab(url, false);",
"})();"
)

$fileLines | Out-File -Append $fileName 

Write-Output "All Done! Exiting."
