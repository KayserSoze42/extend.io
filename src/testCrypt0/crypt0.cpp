#include <iostream>
#include <stdlib.h>
#include <ctime>
#include <cstring>
#include <vector>

char IDCharArray[50], PWCharArray[50], encCharArray[50];

bool didAsk (false);

std::string menuInput;

int passwordLength (0);

int p, q, e, d;

std::vector<int> encryptionKey = {};

void menu(){
	
	std::cout << "°•=•°•=•°•=•°•=•°•=•°•=•°•=•°\n• • • • • [ EDM - @ ] • • • • •\n°•=•°•=•°•=•°•=•°•=•°•=•°•=•°\n>>" ;
	
	std::getline(std::cin, menuInput);
	
	if (menuInput == "login"){
		
		menuInput = "";
		
		std::cout << "• • •\nUID>>";
		
		std::cin >> IDCharArray;
		
		std::cout << "• • •\nPassword>>";
		
		std::cin >> PWCharArray;
		
		didAsk = true;
		
	}
	
	else {
		
		return;
		
	}
	
}

void encryptText(char charArray[50]){
	
	for (int i = 0; i < 50; i++) {
		
		bool isChar = charArray[i];
		
		std::time_t time = std::time(0);
			
		tm *currentTime = localtime(&time);
		
		if (isChar){
			
			passwordLength++;
		
			int randomModifier (rand() % 100 - (int)charArray[i] * i);
		
			int randomNumber (rand() % randomModifier + currentTime->tm_sec);
			
			encryptionKey.push_back(randomNumber);
		
			char tempChar = (int)charArray[i] + randomNumber;
		
			encCharArray[i] = tempChar;
		}	
		
		else{
			
			char tempChar = rand() % 150 + currentTime->tm_sec;
			
			encCharArray[i] = tempChar;
			
		}
		
		}
	
	std::cout << "• • •\nEncrypted :" << encCharArray << "\nLength :" << passwordLength << "\n• • •" << std::endl;
	
	charArray = encCharArray;
	
	memset(encCharArray, 0, sizeof(encCharArray));
	
	encryptionKey.push_back(passwordLength);
	
	encryptionKey.push_back(0);
	
	passwordLength = 0;
	
	return;
	
}

int main(int argc, char *argv[])
{
	
	while (true){
		
		if(!didAsk){
			
			menu();
	
		}
		
		else {
	
	encryptText(IDCharArray);
	encryptText(PWCharArray);
	
	for (int i = 0; i < encryptionKey.size(); i++){
		
		std::cout << " × " << encryptionKey[i];
		
	}
	
	memset(IDCharArray, 0, sizeof(IDCharArray));
	memset(PWCharArray, 0, sizeof(PWCharArray));
	
	std::cout << std::endl;
	
	didAsk = false;
	
		}
	
	}
	
}