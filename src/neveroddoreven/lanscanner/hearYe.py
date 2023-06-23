import socket

def socketListen ():
	
	print("starting")
	
	hostIP = "127.0.0.1"
	openPort = 42069
	
	with socket.socket (socket.AF_INET, socket.SOCK_STREAM) as sOctet:
		
		sOctet.bind(hostIp, openPort)
		
		print("binded")
		
		sOctet.listen()
		
		print("listening")
		
		connection, guestIP = sOctet.accept()
		
		with connection:
			
			print(guestIP , " has connected")
			
			break
			
while True:
	
	socketListen()