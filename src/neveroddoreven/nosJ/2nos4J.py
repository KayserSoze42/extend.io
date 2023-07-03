import requests, sys, json, time, csv

baseUrl = "<<REDACTED>>?id="
downloadUrl = "<<REDACTED>>"
fileName = "data.csv"

def fetchJson():

    itemNo = 0

    with open(fileName, "w") as csv_file:

        csvWriter = csv.writer(csv_file, delimiter = ",", quotechar = '"', quoting=csv.QUOTE_MINIMAL)

        csvWriter.writerow(["No.", "Torrent name", "Torrent size", "Torrent category", "Torrent page url", "Torrent file url"])

        ## >>>>>>> Change XX this number for page limit
        for n in range(0, 50, 10):

            i = n
        
            while i < (n+10):

                i += 1

                itemCurrentList = 0

                try:

                    response = requests.post(

                        "<<REDACTED>>",
                        json = {"username":"<<REDACTED>>",
                                  "passkey":"<<REDACTED>>",
                                  "limit": 100,
                                  "category":[1,2,3,4,5,6,8],
                                  "page": i
                                  }

                        )
                except:
                    
                    i -= 1
                    print("\nRequest Error, sleeping for 30 sec")
                    time.sleep(30)
                    continue
                
                currentResponse = response.json()

                currentTorrentList = currentResponse['data']

                for torrent in currentTorrentList:

                    print("-", end="")
                    
                    if torrent["freeleech"] == "yes":

                        if torrent["type_category"] == 1:
                            category = "Movie"
                        elif torrent["type_category"] == 2:
                            category = "TV"
                        elif torrent["type_category"] == 3:
                            category = "Documentary"
                        elif torrent["type_category"] == 4:
                            category = "Music"
                        elif torrent["type_category"] == 5:
                            category = "Sport"
                        elif torrent["type_category"] == 6:
                            category = "Audio Track"
                        elif torrent["type_category"] == 8:
                            category = "MISC/Demo"

                        itemCurrentList += 1

                        currentFileSize = str(round(torrent["size"] / 1073741824, 2)) + " GB"

                        itemNo += 1

                        print( "\nPage no: " + str(i) + ", " + str(itemNo) + " Found freeleech: " + str(torrent["id"]) + " / " + currentFileSize)

                        try:

                            csvWriter.writerow([str(itemNo), torrent["name"], str(currentFileSize), category, baseUrl + str(torrent["id"]), downloadUrl + torrent["filename"] + "?id=" + str(torrent["id"])])

                        except:

                            print("\nWriting Error, exiting script")

                        time.sleep(0.5)

                response = None

                if itemCurrentList <= 5:
                    time.sleep(2)
                elif itemCurrentList <= 2:
                    time.sleep(5)

                time.sleep(2)
        

def start():

    try:
        fetchJson()

    except:
        print("\nInternal error, panik!")
        
    finally:
        print("\nAll done!")

start()
    
