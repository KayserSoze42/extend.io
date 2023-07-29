const Somebody = ({ data, number }) => {

	var _data = data;
	var _number = number;

	return {

		getData: () => _data,
		getNumber: () => _number,

		setData: newData => _data = newData,

	};

}

const somebodyElse = Somebody({data: "howdy", number: 5});

console.log(somebodyElse.getData());

somebodyElse.setData('hiya');

console.log(somebodyElse.getData());
