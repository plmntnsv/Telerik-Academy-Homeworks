function solve(args) {
    let num = +args[0];
    GetLastDigitAsWord(num);

    function GetLastDigitAsWord(number) {
        let digitsAsWord = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
        if (number <= 9 && number >= 0) {
            console.log(digitsAsWord[number]);
        } else {
            let lastDigit = number % 10;
            console.log(digitsAsWord[lastDigit]);
        }
    }

}
solve(['52']);
/*Description

Write a method that returns the last digit of given integer as an English word.
Write a program that reads a number and prints the result of the method.

Input

On the first line you will receive a number
Output

Print the last digit of the number as an English word
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input	Output
42	    two*/