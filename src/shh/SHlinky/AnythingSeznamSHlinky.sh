#!/bin/bash
URL_START='https://www.seznam.cz/?q='
URL_END=''
read -p "Search for Anything on Seznam: " USER_SEARCH
firefox "${URL_START}${USER_SEARCH}${URL_END}"
