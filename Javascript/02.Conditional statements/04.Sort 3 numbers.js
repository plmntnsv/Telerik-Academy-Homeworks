function solve(args) {
    var firstNum = +args[0],
        secondNum = +args[1],
        thirdNum = +args[2],
        result = '';
    if (firstNum >= secondNum && firstNum >= thirdNum) {
        result += firstNum + ' ';
        if (secondNum >= thirdNum) {
            result += secondNum + ' ' + thirdNum;
        } else {
            result += thirdNum + ' ' + secondNum;
        }
    }
    else if (secondNum >= firstNum && secondNum >= thirdNum) {
        result += secondNum + ' ';
        if (firstNum >= thirdNum) {
            result += firstNum + ' ' + thirdNum;
        } else {
            result += thirdNum + ' ' + firstNum;
        }
    }
    else if (thirdNum>=firstNum && thirdNum>=secondNum) {
        result += thirdNum + ' ';
        if (firstNum>=secondNum) {
            result += firstNum + ' ' + secondNum;
        } else {
            result += secondNum + ' ' + firstNum;
        }
    }
    return result;
}
solve(['5', '1', '2']);
/*Description

Sort 3 real values in descending order. Use nested if statements.

Note: Don’t use arrays and the built-in sorting functionality.

Input

The input will consist of an array containing three values represented as strings
Output

The output should be a single line containing three numbers separated by spaces
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '1', '2']
Output

5 2 1
Sample test 1

Input

['-2', '-2', '1']
Output

1 -2 -2
Sample test 2

Input

['-2', '4', '3']
Output

4 3 -2
Sample test 3

Input

['0', '-2.5', '5']
Output

5 0 -2.5
Sample test 4

Input

['-1.1', '-0.5', '-0.1']
Output

-0.1 -0.5 -1.1
Sample test 5

Input

['10', '20', '30']
Output

30 20 10
Sample test 6

Input

['1', '1', '1']
Output

1 1 1*/