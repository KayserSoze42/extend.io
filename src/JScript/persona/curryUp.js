const form = (number, verbOne, verbTwo) => {
	
	var remainDeer = 100 - number;
	return `${number}% of success is ${verbOne}, the other ${remainDeer}% is ${verbTwo}.`;

};

const madLibCurry = number =>
	verbOne =>
		verbTwo =>
			form(number, verbOne, verbTwo);

const madLib = madLibCurry(31)("hardcore memeing")("chatting with jabberwacky");
console.log(madLib);

