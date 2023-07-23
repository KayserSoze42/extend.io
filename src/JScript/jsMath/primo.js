import { createInterface } from 'node:readline/promises'
import { stdin, stdout } from 'process'

const readline = createInterface({ input: stdin, output: stdout });

const rangeStart = await readline.question('Enter the range start: ');

const rangeEnd = await readline.question('Enter the range end: ');

readline.close();

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

for (var i=rangeStart; i<rangeEnd; i++) {

	console.log(`Number ${i} is primo = ${isPrimo(i)}`);

}

process.exit();
