import socket 

##Common ports

ports = [67, 68, 53, 143, 5037, 694, 5228, 20, 21, 22, 23, 25, 80, 111, 443, 445, 631, 993, 995, 135, 137, 138, 139, 548]

def deviceFind(IP):
	
	try:
		
		socket_obj = socket.socket(socket.AF_INET, socket.SOCK_STREAM) 
		socket.setdefaulttimeout(0.05) 
		result = socket_obj.connect_ex((IP, port)) 
		socket_obj.close()
		if result == 0:
			
			if IP not in addresses:
				
				addresses.append(IP)
				
				print('^')
				
				intName = socket.gethostname(IP)
				
				print(intName)
				
	except:
		
		print('#')
		
addresses = []
names = []

for a in ports:
	
	print('_-=-_-=-_-=-_-=-_-=-_')
	
	port = a
	print('For port :', a)

	for i in range(0, 255):
	
		addr = "192.168.1." + str(i)
		
		print(addr)
		
		deviceFind(IP = addr)
	
	print ('Finished for port :', a)
	
print('_-=-_-=-_-=-_-=-_-=-_')
	
if len(addresses) > 0:
	
	for address in addresses:
		
		print ('Device found @', address)
		
		print('~~')
		
elif len(addresses) == 0:
	
	print('No devices were found with current configuration')
		
print ('Done')