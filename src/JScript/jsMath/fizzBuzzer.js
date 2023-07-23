import { createInterface } from 'node:readline/promises'
import { stdin, stdout } from 'process'

const readline = createInterface({ input: stdin, output: stdout });

const rangeStart = await readline.question('Enter the range start: ');
const rangeEnd = await readline.question('Enter the range end: ');

const fizzCon = await readline.question('Enter the fizz condition: ');

const buzzCon = await readline.question('Enter the buzz condition: ');

readline.close();

var result;
var reason;

for (var i=rangeStart; i<rangeEnd; i++){

	result = "";
	reason = "";

	if (i % fizzCon == 0) { 

		result += "Fizz";
		reason = `Divisible by ${fizzCon}`;
	}

	if (i % buzzCon == 0) { 

		result += "Buzz";
		reason = `Divisible by ${buzzCon}`;
	}

	if (result === "FizzBuzz") {

		result = "2Fizzey&2Buzzey";
		reason = `Divisible by both ${fizzCon} and ${buzzCon}`;

	}

	if (result === "") {

		result = "NaFBN";
		reason = "Not a Fizz Buzzer Number";
	}

	console.log(`Number: ${i}, Result: ${result}, Reason: ${reason}`)


}
