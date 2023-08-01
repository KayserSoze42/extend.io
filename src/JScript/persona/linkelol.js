
function add(a, b) {

	return a+b;

}

const result = add.call(null, 5, 10);
console.log(result);


const addAgain = (a,b) => a+b;

const addTwo = addAgain.call(null, 5, 10);

console.log(addTwo);
