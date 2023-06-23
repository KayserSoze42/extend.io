from datetime import datetime

import subprocess
import time
import csv

def timeCheck():
	
	informed = 0
	
	while True:
		
		##Get current time and date'
		
		today = datetime.now()
		
		##Every 30 mins run a speed test
		##Save results in a csv file
		##Post results on twitter
		##eg 12:30, 13:00 etc
		
		if today.minute == 30 or today.minute == 00:
			
			print ('Running test')
			
			##Run speedtest-cli
	
			speed = subprocess.check_output(['speedtest', '--simple'])
			
			##Extract the text and format it
			
			speedStr = speed.decode('utf-8')
			linesOfSpeed = speedStr.split('\n')

			p = linesOfSpeed[0][6:-3]
			d = linesOfSpeed[1][10:-7]
			u = linesOfSpeed[2][8:-7]
			
			##Print the results
			
			print ('-=-=-=-=-=-=-=-=-=-=')
			print('Results for:', str(today.day).strip(), '.', str(today.month).strip(), '.', str(today.year).strip(), '@', str(today.hour).strip(), ':', str(today.minute).strip())
			print(p, 'ms')
			print(d, 'Mbps download')
			print(u, 'Mbps upload')
			print ('-=-=-=-=-=-=-=-=-=-=')
			
			
			informed = 0
			
			##Print processing while saving and posting
			
			print('Processing')
			
			##Save results in a csv file
			
			with open ('results.csv', 'a', newline = '') as resultsFile:
				results = csv.writer(resultsFile, delimiter = ',', quotechar = ' ', quoting = csv.QUOTE_MINIMAL)
				
				dateStr = '{:d}.{:d}.{:d} {:d}:{:d}'.format(today.day, today.month, today.year, today.hour, today.minute)
				
				results.writerow([p, d, u, dateStr])
				
				print('Saved results')
			
			##Post results on twitter
			
			##Print done when finished
			print('Wait')
			time.sleep(10)
			print('Done')
			
		##Every 30 mins check the
		##number of devices on the network
		##and calculate the used bandwith
		##save results in a csv file
		##post results on twitter?
		##eg 12:15, 12:45
		
		elif today.minute == 15 or today.minute == 45:
			
			print('Checking network')
			
			time.sleep(59)
			
			##Check connected devices
			
		else:
			
			##Print
			##time until the next test and time now
			
			if informed == 0:
				
				print ('-=-=-=-=-=-=-=-=-=-=')
				
				if today.minute < 30:
					
					print ('Next test in', 30 - today.minute, 'minutes')
				
					informed = 1
					timeNow = ""
					timeNow += str(today.hour).strip()
					if today.minute <9 :
						timeNow += ':0'
					else:
						timeNow += ':'
					timeNow += str(today.minute).strip()
					print ('Current Time', timeNow)
					print ('-=-=-=-=-=-=-=-=-=-=')
					
				else:
					
					print ('Next test in', 60 - today.minute, 'minutes')
				
					informed = 1
					timeNow = ""
					timeNow += str(today.hour).strip()
					timeNow += ":"
					timeNow += str(today.minute).strip()
					print ('Current Time', timeNow)
					print ('-=-=-=-=-=-=-=-=-=-=')
				
##Call the main app				
										
timeCheck()

