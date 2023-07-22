echo 'SlinkyFactory'
echo 'Create custom searches for TamperMonkey'
echo 'Enter the item and search name for label "Search for X on Y"'
echo 'Enter the first and second(optional) part of the url'
echo 'The factory will generate a XYSlinky.user.js file in current directory'
echo '-----'
read -p 'Enter the name of the item to be searched: (e.g. Ticket Number, ID...): ' SEARCH_ITEM
echo '-----'
read -p 'Enter the name of the search used: (e.g. Seznam, Database...): ' SEARCH_PLACE
echo '-----'

FILE_NAME="${SEARCH_ITEM}${SEARCH_PLACE}Slinky.user.js"

read -p 'Enter the first part of the URL: ' URL_START
echo -----
read -p 'Enter the second part of the URL(Optional): ' URL_END
echo -----

echo Generating and writing file:

echo "// ==UserScript==">> $FILE_NAME
echo "// @name         Search for ${SEARCH_ITEM} on ${SEARCH_PLACE}">> $FILE_NAME
echo "// @namespace    http://tampermonkey.net/" >> $FILE_NAME
echo "// @version      0.1" >> $FILE_NAME
echo "// @description  SlinkySearch Script For A Custom Search" >> $FILE_NAME
echo "// @author       You" >> $FILE_NAME
echo "// @match        *" >> $FILE_NAME
echo "// @grant        GM_openInTab" >> $FILE_NAME
echo "// @run-at       context-menu" >> $FILE_NAME
echo "// ==/UserScript==" >> $FILE_NAME
echo "(function() {" >> $FILE_NAME
echo "'use strict';" >> $FILE_NAME
echo "var selectedText = window.getSelection().toString();" >> $FILE_NAME
echo "var url = '${URL_START}' + selectedText + '${URLEND}';" >> $FILE_NAME
echo "GM_openInTab(url, false);" >> $FILE_NAME
echo "})();" >> $FILE_NAME

echo 'All Done! Exiting.'

