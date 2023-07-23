const readline = require('readline').createInterface({

	input: process.stdin,
	output: process.stdout

});

function isPrimo(agen) {

	if (agen / 2 == 1) {
		return true;
	}

	if (agen % 2 == 0) {
		return false;
	}

	for (var i=3; i<(agen/2); i+=2) {
		if (agen % i == 0) {
			return false;
		}
	}

	return true;
}

readline.question('Enter the range start: ', rangeStart => {

	rangeStart = parseInt(rangeStart);

	readline.question('Enter the range end: ', rangeEnd => {

		rangeEnd = parseInt(rangeEnd);

		for (var i=rangeStart; i<rangeEnd; i++) {

			console.log(`Number ${i} is primo = ${isPrimo(i)}`);

		}

		process.exit();

	});

});
