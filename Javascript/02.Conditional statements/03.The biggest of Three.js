function solve(args) {
    var biggest = +args[0],
        secondNum = +args[1],
        thirdNum = +args[2];
    if (secondNum > biggest) {
        biggest = secondNum;
        if (thirdNum > biggest) {
            biggest = thirdNum;
        }
    } else if (thirdNum > biggest) {
        biggest = thirdNum;
    }
    console.log(biggest);
}
solve(['-2', '-2', '1']); 
/*Description

Write a script that finds the biggest of three numbers. Use nested if statements.

Input

The input will consist of an array containing three values represented as strings
Output

The output should be a single line containing a number
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '2', '2']
Output

5
Sample test 2

Input

['-2', '-2', '1']
Output

1
Sample test 3

Input

['-2', '4', '3']
Output

4
Sample test 4

Input

['0', '-2.5', '5']
Output

5
Sample test 5

Input

['-0.1', '-0.5', '-1.1']
Output

-0.1*/