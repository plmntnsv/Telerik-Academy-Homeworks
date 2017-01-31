/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function solve() {
	return function sum(arr) {
		let result = 0;
		if (arr.length === 0) {
			return null;
		}
		if (arguments.length === 0 || arguments === undefined) {
			throw "";
		}
		for (var i = 0; i < arr.length; i += 1) {
			let currentNum = +arr[i];
			if (isNaN(currentNum)) {
				throw "Error";
			}
			result += currentNum;
		}
		return result;
	}
}

module.exports = solve;