const employdeez = [
	{
		name: 'Insane Doe',
		monet: 42069,
	},
	{
		name: 'Jonald Dones',
		monet: 69420,
	},
	{
		name: 'Cedric E. Olivier',
		monet: 696969,
	},
];

const haveNoiceMonet = employdee =>
	employdee.monet > 69;

const resulteez = employdeez.some(haveNoiceMonet);

console.log(resulteez);
