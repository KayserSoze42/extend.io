#include <iostream>
#include <regex>

std::regex pat("([\\w\\.]+@[\\w\\.]+\\.(com|org|net))");
std::string userInput;
std::vector<std::string> matches;

bool didAsk (false);

void findMatch(std::string usr, std::regex pat){
	
	std::smatch match;
	
	bool foundMatch = std::regex_search(usr, match, pat);
	
	if (foundMatch){
		
		std::cout << "Found match : " << match[0] <<std::endl;
		
		matches.push_back(match[0]);
		
	}
	
	else {
		
		std::cout << "Nothing found!" << std::endl;
	}
	
	didAsk = false;
	
}

int main(int argc, char *argv[])

{
	
	while (true) {
		
		if (!didAsk) {
			
			std::cout << "• • • ° ° ° • • • ° ° ° • • • ° ° °" << std::endl;
	
			std::cout << "Aloha, type in some text\n>>";
			
			didAsk = true;
	
		}
		
		else {
	
			std::getline(std::cin, userInput);
			
			std::cout << "• • • ° ° ° • • • ° ° ° • • • ° ° °" << std::endl;
	
			std::cout << "Input : " << userInput << std::endl;
	
			findMatch(userInput, pat);
	
		}
	
	}
	
}
