#include <iostream>
#include <vector>
#include <time.h>
#include <stdlib.h>
#include <stdio.h>

namespace RSA {

class Key{
	
	/*
	RSA Key Generator
	
	*/
	
	public:
	
	Key(long &p, long &q); // Pass random primes p and q, create RSA Key object
	
	std::vector<long> currentKey(); // Stores current RSA Key : e, d and n
	
	void genKey(); // Generates new key from the passed primes
	
	private:
	
	long randomP, randomQ, nProduct, phiProduct;
	
};

class NumberGenerator{
	
	/*
	Number Generator
	
	Generate a random number, increment until its a prime
	
	Store primes p and q in the vector currentPrimes
	
	*/
	
	public:
	
	NumberGenerator();
	
	std::vector<long> currentPrimes;
	
	private:
	
	long randomNumber();
	
	long randomToPrime(long &newRandom);
	
	bool isPrime(long &checkPrime);
		
};

RSA::Key::Key(long &p, long &q)
{
	this -> randomP = p;
	this -> randomQ = q;
}

}
RSA::NumberGenerator::NumberGenerator(){
	/*
	
	Generate a random number using randomNumber, push it to vector currentPrimes
	pass it to randomToPrime 
	and overwrite it in vector currentPrimes[currentPrimes.size + 1]
	
	*/
	
	this -> currentPrimes.push_back(this -> randomNumber());
	
	long primeRandom = this -> randomToPrime(currentPrimes.back());
	
	this -> currentPrimes.back() = primeRandom;
	
	for (int i = 0; i < currentPrimes.size();i++){std::cout << currentPrimes[i] << std::endl;}
	
}


long RSA::NumberGenerator::randomNumber(){
	
	if (this -> currentPrimes.empty()){return rand() % 420 * 69;}
	
	else {return currentPrimes.back() + rand() % 420 * 69;}
	
}

bool RSA::NumberGenerator::isPrime(long &checkRandom){
	
	for (int i = 2; i <= checkRandom; i++){
		
		if (checkRandom % i == 0){return true;}
		
	}
	
}

long RSA::NumberGenerator::randomToPrime(long &newRandom){
	
	long lastNumber = this -> currentPrimes.back();
	
	// increment lastPrime by 1 until it returns isPrime true
	
	while (!isPrime (lastNumber)){
		
		lastNumber += 1;
		
	}
	
	this -> currentPrimes.back() = lastNumber;
	
	return lastNumber;
	
}

void menu(){ 
	
	/*
	
	Generate two random primes using NumberGenerator > Pass them to RSA Key > 
	> cout welcome & login/register form
	
	*/
	
	srand(time(NULL));

	RSA::NumberGenerator randomP, randomQ;

}


int main(int argc, char *argv[])
{
	
	menu();
	
}