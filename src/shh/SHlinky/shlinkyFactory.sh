#!/bin/bash

echo 'SHlinkyFactory'
echo 'Create cushtom .sh shearchesh for Shlinkey'
echo 'Enter the item and search place for label "Search for X on Y"'
echo 'Enter the first and second(optional) part for the url'
echo 'The factory will generate a XYSHlinkey.sh file in current directory'
echo '------'
read -p 'Enter the name of the item to be searched: (e.g. Ticket Number, ID, Term..): ' SEARCH_ITEM
echo '------'
read -p 'Enter the name of the palce to be searched: (e.g. Seznam, Database..): ' SEARCH_PLACE
echo '------'

FILE_NAME="${SEARCH_ITEM}${SEARCH_PLACE}SHlinkey.sh"

read -p 'Enter the first part of the URL: ' URL_START
echo '------'
read -p 'Enter the second part of the URL (Optional): ' URL_END
echo '------'

echo 'Generating and writing file..'

echo "URL_START='${URL_START}'">> $FILE_NAME
echo "URL_END='${URL_END}'">> $FILE_NAME
echo "read -p 'Search for ${SEARCH_ITEM} on ${SEARCH_PLACE}' USER_SEARCH: " >> $FILE_NAME
echo 'firefox "${URL_START}${USER_SEARCH}${URL_END}"' >> $FILE_NAME

echo 'All done! Exiting!'
