
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

				var result = "";
				var reason;

				for (var i=rangeStart; i<rangeEnd; i++){

					reason = "NaFB";
					result = "";

					if (i % fizzCon == 0) { 

						result += "Fizz";
						reason = `Divisible by ${fizzCon}`;
					}

					if (i % buzzCon == 0) { 

						result += "Buzz";
						reason = `Divisible by ${buzzCon}`;
					}

					if (i % fizzCon == 0 && i % buzzCon == 0) {

						result = "2Fizzey&2Buzzey";
						reason = `Divisible by both ${fizzCon} and ${buzzCon}`;

					}

					console.log(`Number: ${i}, Result: ${result}, Reason: ${reason}`)


				}


				process.exit();
			});

		});

	});

	readline.close;

});
