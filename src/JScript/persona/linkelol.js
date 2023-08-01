
function add(a, b) {return a+b;}

const result = add.call(null, 5, 10);

// -------------------------------------

const addAgain = (a,b) => a+b;

const resultAgain = addAgain.call(null, 5, 10);

// -------------------------------------

const addTwoForm = (what, a, b) => add.call(what, a, b);

const addTwoCurry = a =>
	b=>
		addTwoForm(null, a, b);

const resultOnceAgain = addTwoCurry(5)(10);

console.log(result);
console.log(resultAgain);
console.log(resultOnceAgain);

