
##

'''
Start the script

Print Current Time

Enter the time zone

Enter the start of the window

Enter the end of the window

Print the results

>> If the input is in the 24h format convert to usa zone and print in 12h format

>> If the input is in the 12h format convert to 24h, then usa zone and print in 12h format

Save the reminder

'''

from pytz import timezone
import pytz
import pyperclip

import re
from datetime import datetime
import time
import csv

listWin = {
"Date":"",
"TimeStart":"",
"TimeEnd":"",
"Zone":"",
"Format":""
}

listCon = {
"Date":"",
"TimeStart":"",
"TimeEnd":"",
"Zone":"CET",
"Format":""
}

listZone = {
"AKDT":'US/Alaska',
"PDT":'US/Pacific',
"MDT":'US/Mountain',
"CDT":'US/Central',
"EDT":'US/Eastern'
}

timeWindow = []
apWindow = []
timeConverted = []

currently = datetime.now()

class Ozone():

    def __init__(self, inputText):

        self.inputText = inputText

    def convertToUsa(self):

        timeWindow = []
        apWindow = []
        timeConverted = []

        ##28.12.2020 10:50 PM - 4:15 AM MDT
        ##21.12.2020 20:20 - 3:12 AKDT
        ##Group 1 Date
        ##Group 2 Time
        ##Group 3 Zone

        reConBase = re.compile(r'(\d+.\d+.\d+)\s*(\d+:\d+\s*(AM|PM|am|pm|Am|Pm|aM|pM)*\s*-\s*\d+:\d+\s*(AM|PM|am|pm|Am|Pm|aM|pM)*)\s*(AKDT|AKST|PDT|PST|MST|MDT|CDT|CST|EDT|EST)')

        reConSile = reConBase.findall(self.inputText)

        try:

            ## Manipulate the time string

            timeWindow = reConSile[0][1]
            timeWindow = timeWindow.split("-")
            listWin["TimeStart"] = str(timeWindow[0]).strip(" ")
            listWin["TimeEnd"] = str(timeWindow[1]).strip(" ")

            try:

                reConSpace = re.compile(r'(AM|PM|am|pm|Am|Pm|aM|pM)')

                reConTimeStart = reConSpace.findall(listWin["TimeStart"])
                reConTimeEnd = reConSpace.findall(listWin["TimeEnd"])

                apWindow.append(str(reConTimeStart[0]).upper() )
                apWindow.append(str(reConTimeEnd[0]).upper() )

                listWin["TimeStart"] = str(listWin["TimeStart"]).strip(str(reConTimeStart[0])).strip(" ") + " " +apWindow[0]
                listWin["TimeEnd"] = str(listWin["TimeEnd"]).strip(str(reConTimeEnd[0])).strip(" ") + " " +apWindow[1]

            except:

                pass

            if "AM" in listWin["TimeStart"] or "AM" in listWin["TimeEnd"] or "PM" in listWin["TimeEnd"] or "PM" in listWin["TimeEnd"] :

                listWin["Format"] = "12"

            else:

                listWin["Format"] = "24"

            ## Manipulate the date string

            listWin["Date"] = reConSile[0][0]

            listWin["Zone"] = reConSile[0][4]

            listWin["Zone"] = listZone[str(listWin["Zone"])]

        except:

            print("Err")

    def convertResult(self):

        print("=-"*69)

        print("")

        print("Current time :", currently.strftime("%d.%m.%Y %H:%M"))

        print("")

        print("=-"*69)

        timezoneLoco = timezone('Europe/Bratislava')
        timezoneUSA = timezone(listWin["Zone"])

        print("{:^20} {:^35} {:^45}".format("---LOCAL TIME---", str(timezoneLoco), "24 hour format") )

        print("")

        print("{:^20} {:^35} {:^45}".format("Date of the ticket", "Beginning time", "Ending time" ))

        print("{:^20} {:^35} {:^45}".format("^^^", "^^^", "^^^" ))

        ## For 24 hour format

        if listWin["Format"] == "24":

            dateStart = listWin["Date"] + " " + listWin["TimeStart"]
            dateStart = datetime.strptime(dateStart, "%d.%m.%Y %H:%M")

            dateEnd = listWin["Date"] + " " + listWin["TimeEnd"]
            dateEnd = datetime.strptime(dateEnd, "%d.%m.%Y %H:%M")

            usaTimeStart = timezoneUSA.localize(dateStart)
            usaTimeEnd = timezoneUSA.localize(dateEnd)

            localStart = usaTimeStart.astimezone(timezoneLoco)
            localEnd = usaTimeEnd.astimezone(timezoneLoco)

            localStart = localStart.strftime("%d.%m.%Y %H:%M")
            localEnd = localEnd.strftime("%d.%m.%Y %H:%M")

            timeConverted = localStart.split(" ")
            listCon["Date"] = timeConverted[0]
            listCon["TimeStart"] = timeConverted[1]

            timeConverted = localEnd.split(" ")
            listCon["TimeEnd"] = timeConverted[1]

            print("{:^20} {:^35} {:^45}".format(listCon["Date"], str(datetime.strptime(str(listCon["TimeStart"]), "%H:%M").strftime("%I:%M %p")), str(datetime.strptime(str(listCon["TimeEnd"]), "%H:%M").strftime("%I:%M %p")) ))
            print("{:^20} {:^35} {:^45}".format("XXXXXXXXXX", listCon["TimeStart"], listCon["TimeEnd"]) )

        ## For 12 hour format

        elif listWin["Format"] == "12":

            dateStart = listWin["Date"] + " " + listWin["TimeStart"]

            dateEnd = listWin["Date"] + " " + listWin["TimeEnd"]

            dateStart = datetime.strptime(dateStart, "%d.%m.%Y %I:%M %p")
            dateEnd = datetime.strptime(dateEnd, "%d.%m.%Y %I:%M %p")

            usaTimeStart = timezoneUSA.localize(dateStart)
            usaTimeEnd = timezoneUSA.localize(dateEnd)

            localStart = usaTimeStart.astimezone(timezoneLoco)
            localEnd = usaTimeEnd.astimezone(timezoneLoco)

            localStart = localStart.strftime("%d.%m.%Y %H:%M")
            localEnd = localEnd.strftime("%d.%m.%Y %H:%M")

            timeConverted = localStart.split(" ")
            listCon["Date"] = timeConverted[0]
            listCon["TimeStart"] = timeConverted[1]

            timeConverted = localEnd.split(" ")
            listCon["TimeEnd"] = timeConverted[1]

            print("{:^20} {:^35} {:^45}".format(listCon["Date"], listCon["TimeStart"], listCon["TimeEnd"]) )
            print("{:^20} {:^35} {:^45}".format(listCon["Date"], str(datetime.strptime(str(listCon["TimeStart"]), "%H:%M").strftime("%I:%M %p")), str(datetime.strptime(str(listCon["TimeEnd"]), "%H:%M").strftime("%I:%M %p")) ))


        print("=-"*69)

        print("{:^20} {:^35} {:^45}".format("---TICKET TIME---", str(timezoneUSA), listWin["Format"] + " hour format") )

        print("")

        print("{:^20} {:^35} {:^45}".format("Date of the ticket", "Beginning time", "Ending time" ))

        print("{:^20} {:^35} {:^45}".format("^^^", "^^^", "^^^" ))

        try:

            print("{:^20} {:^35} {:^45}".format(listWin["Date"], str(datetime.strptime(str(listWin["TimeStart"]), "%I:%M %p").strftime("%H:%M")), str(datetime.strptime(str(listWin["TimeEnd"]), "%I:%M %p").strftime("%H:%M")) ))
            print("{:^20} {:^35} {:^45}".format("XXXXXXXXXX", listWin["TimeStart"], listWin["TimeEnd"] ))

        except:

            print("{:^20} {:^35} {:^45}".format(listWin["Date"], str(datetime.strptime(str(listWin["TimeStart"]), "%H:%M").strftime("%I:%M %p")), str(datetime.strptime(str(listWin["TimeEnd"]), "%H:%M").strftime("%I:%M %p")) ))
            print("{:^20} {:^35} {:^45}".format("XXXXXXXXXX", listWin["TimeStart"], listWin["TimeEnd"] ))

        print("=-"*69)

def confirm():

    while True:

        inputContinue = input("Type in copy, save or press enter to restart\n>>")

        # On copy - copy local and / or ticket time

        if inputContinue == "copy":

            input12 = input("Type in 1 for local time, 2 for ticket time or 12 / 21 / 3 for both\n>>")

            if input12 == "1":

                pyperclip.copy(str(listCon["Date"] + " @ " + listCon["TimeStart"] + " - " + listCon["TimeEnd"] + " " + listCon["Zone"]) )

                print("Copied local time to clipboard")

            if input12 == "2":

                pyperclip.copy(str(listWin["Date"] + " @ " + listWin["TimeStart"] + " - " + listWin["TimeEnd"] + " " + list(listZone.keys())[list(listZone.values()).index(listWin["Zone"])]) )

                print("Copied ticket time to clipboard")

            if input12 == "12" or input12 == "21" or input12 == "3":

                pyperclip.copy(str(listCon["Date"] + " @ " + listWin["TimeStart"] + " - " + listWin["TimeEnd"] + " " + list(listZone.keys())[list(listZone.values()).index(listWin["Zone"])] + " / " + listCon["TimeStart"] + " - " + listCon["TimeEnd"] + " " + listCon["Zone"]) )

                print("Copied both local and ticket time to clipboard")

            print("-="*69)

        # On save - save both local and ticket times to savetheozone.txt

        if inputContinue == "save":

            with open('savetheozone.csv', mode = 'a') as csvfile:

                ozonewrite = csv.writer(csvfile, delimiter = ' ', quotechar = "#", quoting=csv.QUOTE_MINIMAL)

                ozonewrite.writerow([])

                ozonewrite.writerow([str("-="*42)])

                ozonewrite.writerow(["US TIME FORMAT", str(listCon["Date"] + " @ " + listWin["TimeStart"] + " - " + listWin["TimeEnd"] + "   " + list(listZone.keys())[list(listZone.values()).index(listWin["Zone"])])] )
                ozonewrite.writerow(["CENT E TIME FORMAT", str(listCon["Date"] + " @ " + listCon["TimeStart"] + " - " + listCon["TimeEnd"] + "   " + listCon["Zone"])] )

                ozonewrite.writerow([str("-="*42)])

                print("Saved the ozone!")

                print("-="*69)

        # On enter - restart the "shell"

        if inputContinue == "":

            print("\n"*50)

            return

def loop():

    menu()

def menu():

    while True:

        inputMenu = input("Type in the date and the window time with the time zone\nDD.MM.YYYY AA:BB (AM/PM) - CC:DD (AM/PM) XXX\n>>")

        try:

            new = Ozone(str(inputMenu))

            new.convertToUsa()

            new.convertResult()

            confirm()

        except:

            print("\n"*50)

            loop()



loop()