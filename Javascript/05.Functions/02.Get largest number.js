function solve(args) {
    let inputArr = args[0].split(' '),
        firstNum = +inputArr[0],
        secondNum = +inputArr[1],
        thirdNum = +inputArr[2],
        biggestOfTwo = Math.max(firstNum, secondNum);
    GetMax(thirdNum, biggestOfTwo);

    function GetMax(firstNum, secondNum) {
        console.log(Math.max(firstNum, secondNum));
    }

}
solve(['8 3 6']);
/*Description

Write a method GetMax() with two parameters that returns the larger of two integers.
Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

Input

On the first line you will receive 3 integers separated by spaces
Output

Print the largest of them
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input	Output
8 3 6	8
7 19 19	19*/