const numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

const isPhteven = x => x % 2 == 0;

const phtevenNumbers = numbers.filter(isPhteven);

console.log(phtevenNumbers);

const worldz = [

	'this',
	'other',
	'another',

];

const testLongz = length => world => world.length > length;

const is5Longz = testLongz(5);

const longzWorldz = worldz.filter(is5Longz);

console.log(longzWorldz);
