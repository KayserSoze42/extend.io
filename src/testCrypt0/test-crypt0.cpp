#include <iostream>
#include <string>
#include <cstring>
#include <ctime>
#include <stdlib.h>
#include <fstream>
#include <math.h>
#include <vector>
#include <sstream>

using namespace std;

time_t now = time(0);

tm *timeNow = localtime(&now);

string getUserInput(){
	
	string userInput;
	
	cout << ">>";
	cin >> userInput;
	
	return userInput;
	
	}
	
vector<long> primePairs;
vector<long> currentPairs;

void savePairs(int sE, int sD, int sN){
	
	ofstream crypt0pairs;
	
	crypt0pairs.open("crypt0pairs.csv", ofstream::app);
	
	crypt0pairs << sE << ',' << sD << ',' << sN << '\n';
	
	crypt0pairs.close();
	
}

void saveEncryptedCredentials (string sID, string sPW){
	
	ofstream crypt0text;
	
	crypt0text.open("crypt0text.csv", ofstream::app);
	
	crypt0text << sID << ',' << sPW << '\n';
	
	crypt0text.close();
	
	}
	
bool isPrime(int number){
	
	for (int i = 2; i < number; i++){
		
		if (number % i == 0){
			
			return false;
			
			}
		
		}
		
		return true;
			
	}
	
bool isCoprime(long tempE, long overPhi){
	
	long localPhi = overPhi;
	long localE = tempE;
	
	while (localE != localPhi){
		
		if (localE > localPhi){
			
			localE -= localPhi;}
			
		else{
			
			localPhi -= localE;}
		
	}
	
	if (localE == 1){
		
		return true;
		
	}
	
	else {
		
		return false;
		
	}
	
}
	
long greatestE(long constPhi){
	
	long temp = 2;
	
	while(temp<constPhi){
		
		if (isCoprime(temp, constPhi)){
			
			return temp;
			
		}
		
		else{
			
			temp++;
			
		}
		
	}
}
	
long randomPrime(){
	
	srand(timeNow->tm_sec * 4);
	
	long randomNumber = random() % 100;
	
	if (primePairs.size()>0){
		
		randomNumber += primePairs[0];
		primePairs.clear();
		
		}
	
	int i = 0;
	
	while (isPrime(randomNumber + i) == false){i++;}
	
	primePairs.push_back(randomNumber + i);
	
	return randomNumber + i;
	
}
	
void getKey(int clearFlag){
	
	// Clear the old key and generate a new one, save to vector currentKey
	
	if (clearFlag == 1){
		
	currentPairs.clear();
	
	long p = randomPrime();
	long q = randomPrime();
	
	long n = p * q;
	
	long phi = (p-1) * (q-1);
	
	long e = greatestE(phi);
	
	int k = 2;
	
	int d = ( 1 + (k * phi))/e;
	
	currentPairs.push_back(e);
	currentPairs.push_back(d);
	currentPairs.push_back(n);
	
	savePairs(e, d, n);
	
	}
	
	// ELSE >> Use the previously generated key stored at vector >>currentKey<<
	
	}
	
bool checkCredentials (string tryID, string tryPW){
	
	ifstream crypt0pairs, crypt0text;
	
	vector<string> currentKey;
	
	crypt0pairs.open("crypt0pairs.csv");
	
	crypt0text.open("crypt0text.csv");
	
	while (crypt0pairs.good() && !crypt0pairs.eof()){
		
		string crypt0ID, crypt0PW, savedID, savedPW, e, d, n = "";
	
		int sizeID = tryID.size();
	
		int sizePW = tryPW.size();
	
		char IDArray[sizeID+1];
	
		char PWArray[sizePW+1];
	
		strcpy(IDArray, tryID.c_str());
	
		strcpy(PWArray, tryPW.c_str());
		
		currentKey.clear();
		
		getline (crypt0pairs, e, ',');
		currentKey.push_back(e);
		
		getline (crypt0pairs, d, ',');
		currentKey.push_back(d);
		
		getline (crypt0pairs, n, '\n');
		currentKey.push_back(n);
		
		cout << e << " & " << d << " & " << n << endl;
		
		// encrypt the input ID
		
		for (int i = 0; i < sizeID; i++){
			
			try {
			
			int valueE = stoi(e);
			
			int valueN = stoi(n);
			
			long crypt0 = pow((int)IDArray[i], valueE);
			
			crypt0 = fmod(crypt0, valueN);
			
			char currentChar = (int)crypt0;
			
			crypt0ID += currentChar;
			
			}
			
			catch (...) { continue;}
			
			cout << "ID >> " << crypt0ID << endl;  
			
		}
		
		// encrypt the input PW
		
		for (int i = 0; i < sizePW; i++){
			
			try {
			
			int valueE = stoi(e);
			
			int valueN = stoi(n);
			
			long crypt0 = pow((int)PWArray[i], valueE);
			
			crypt0 = fmod(crypt0, valueN);
			
			char currentChar = (int)crypt0;
			
			crypt0PW += currentChar;
			
			}
			
			catch (...) { continue;}
			
			cout << "PW >> " << crypt0PW << endl;
			
		}
		
		while (crypt0text.good() and !crypt0text.eof()){
			
			getline(crypt0text, savedID, ',');
			getline(crypt0text, savedPW, '\n');
			
			cout << "Saved ID >> " << savedID << endl;
			cout << "Saved PW >> " << savedPW << endl;
			
			// On even sequenceDivider check the UID against the Saved one
			
			if (crypt0ID == savedID && crypt0PW == savedPW){return true;}
			
			else{continue;}
			
			}
		
	}
		
	crypt0text.close();
	crypt0pairs.close();
	
}
	
string encryptText(string userInput, int clearPrevKey){
	
	int inputSize = userInput.size();
	
	char userInputArray[inputSize + 1];
	
	string encryptedString;
	
	strcpy(userInputArray, userInput.c_str());
	
	// RSA starts here
	
	getKey(clearPrevKey);
	
	long e = currentPairs[0];
	
	long n = currentPairs[2];
	
	//cout << "P - " << p << "\nQ - " << q << "\nModulus - " << n << "\nPsi - " << phi << "\nE and D - " << e << " " << d << endl;
	
	// Go through the characters and modify them
	
	for (int i = 0; i < inputSize; i++){
		
		long crypt0 = pow((int)userInputArray[i], e);
		crypt0 = fmod(crypt0, n);
		
		char currentChar = (int)crypt0;
		encryptedString += currentChar;
		
		}
		
	return encryptedString;
	
	}
	
void menuLogin(){
	
	cout << "Type in login or register";
	
	string menuInput = getUserInput();
	
	if (menuInput == "login"){
		
		// Get ID and PW, encrypt with crypt0pairs, check for match
		// cout Login correct! else Login failed!, loop back
		
		string userID, userPW = "";
		
		cout << "Enter the User ID" << endl;
		
		userID = getUserInput();
		
		cout << "Enter the Password" << endl;
		
		userPW = getUserInput();
			
		if (checkCredentials(userID, userPW)){
				
				cout << "Correct login!" << endl;
			}
			
		else {
			
			cout << "Login failed!" << endl;
		}	
		
		}
		
	if (menuInput == "register"){
		
		//Get ID and PW, create pairs, save to crypt0pairs, save the text to crypt0Text
		// continue to menu
		
	cout << "Enter the user name" << endl;
	
	string userID = getUserInput();
	
	cout << "Enter the password" << endl;
	
	string userPW = getUserInput();
	
	int clearPrevKey;
	
	string encryptedID = encryptText(userID, clearPrevKey = 1);
	string encryptedPW = encryptText(userPW, clearPrevKey = 0);
	
	saveEncryptedCredentials(encryptedID, encryptedPW);
	
	cout << "Registered! Please login." << endl;
	
	}
	}

int main(int argc, char *argv[])
{
	
	while(true){
		
		cout << "-_-_-_-_-" << endl;
	
		menuLogin();
	
	}
	
}