function solve(args) {
     var firstNum = +args[0],
         secondNum = +args[1],
         thirdNum = +args[2];
    if (firstNum === 0 || secondNum === 0 || thirdNum === 0) { //ako edno chislo e nula
        return 0;
    } else if(firstNum > 0 && secondNum > 0 && thirdNum > 0){ //ako trite sa +
        return '+';
    } else if (firstNum < 0 && secondNum < 0 && thirdNum < 0){ // ako trite sa -
        return '-';
    } else if (((firstNum < 0 || secondNum < 0) && thirdNum < 0) || ((firstNum < 0 || thirdNum < 0) && secondNum < 0) || ((secondNum < 0 || thirdNum < 0) && firstNum < 0)) { //ako ima dva minusa
        return '+';
    } else { //edin -
        return '-';
    }
}
solve(['-2', '4', '3']);
/*Description

Write a script that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators.

Input

The input will consist of an array containing three values - a, b and c represented as strings
Output

The output should be a single line containing +, - or 0
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '2', '2']
Output

+
Sample test 2

Input

['-2', '-2', '1']
Output

+
Sample test 3

Input

['-2', '4', '3']
Output

-
Sample test 4

Input

['0', '-2.5', '4']
Output

0
Sample test 5

Input

['-1', '-0.5', '-5.1']
Output

-*/