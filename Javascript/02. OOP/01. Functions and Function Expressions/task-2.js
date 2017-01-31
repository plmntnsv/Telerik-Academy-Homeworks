/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {
	return function findPrimes(firstNum, secondNum) {
		if (isNaN(+firstNum) || isNaN(+secondNum)) {
			throw "Err";
		}
		let arr = [];

		for (let i = +firstNum; i <= +secondNum; i += 1) {
			if (i <= 1) {
				continue;
			}
			let isPrime = true;
			for (let j = 2; j <= i; j += 1) {
				if (i % j === 0 && i !== j) {
					isPrime = false;
					break;
				}
			}
			if (isPrime) {
				arr.push(i);
			}
		}
		return arr;
	}
}
module.exports = solve;