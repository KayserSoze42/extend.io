
const readline = require('readline').createInterface({

	input: process.stdin,
	output: process.stdout

});

readline.question('Enter the range start: ', rangeStart => {

	rangeStart = parseInt(rangeStart);

	readline.question('Enter the range end: ', rangeEnd => {

		rangeEnd = parseInt(rangeEnd);

		readline.question('Enter the fizz condition: ' , fizzCon => {

			fizzCon = parseInt(fizzCon);

			readline.question('Enter the buzz condition: ', buzzCon => {

				buzzCon = parseInt(buzzCon);

				var output = "";
				var result;

				for (var i=rangeStart; i<rangeEnd; i++){

					result = "NaFB";

					if (i % fizzCon == 0) { 

						output += "Fizz";
						result = `Divisible by ${fizzCon}`;
					}

					if (i % buzzCon == 0) { 

						output += "Buzz";
						result = `Divisible by ${buzzCon}`;
					}

					if (i % fizzCon == 0 && i % buzzCon == 0) {

						result = `Divisible by both ${fizzCon} and ${buzzCon}`;

					}

					console.log(`Number: ${i}, Result: ${result}`)


				}


				process.exit();
			});

		});

	});

	readline.close;

});
