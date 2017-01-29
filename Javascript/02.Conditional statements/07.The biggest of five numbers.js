function solve(args) {
    var firstNum = +args[0],
        secondNum = +args[1],
        thirdNum = +args[2],
        fourthNum = +args[3],
        fifthNum = +args[4],
        biggest;
    if (firstNum >= secondNum) {
        biggest = firstNum;
        if (thirdNum >= biggest) {
            biggest = thirdNum;
            if (fourthNum >= biggest) {
                biggest = fourthNum;
                if (fifthNum >= biggest) {
                    biggest = fifthNum;
                }
            } else if (fifthNum >= biggest) {
                biggest = fifthNum;
            }
        } else if(fourthNum >= biggest) {
            biggest = fourthNum;
            if (fifthNum > biggest) {
                biggest = fifthNum;
            }
        } else if (fifthNum >= biggest) {
            biggest = fifthNum;
        }
    } else {
        biggest = secondNum;
        if (thirdNum >= biggest) {
            biggest = thirdNum;
            if (fourthNum >= biggest) {
                biggest = fourthNum;
                if (fifthNum >= biggest) {
                    biggest = fifthNum;
                }
            } else if (fifthNum >= biggest) {
                biggest = fifthNum;
            }
        } else if(fourthNum >= biggest) {
            biggest = fourthNum;
            if (fifthNum > biggest) {
                biggest = fifthNum;
            }
        } else if (fifthNum >= biggest) {
            biggest = fifthNum;
        }
    }
    return biggest;
}
solve(['5', '2', '2', '4', '1']);
solve(['-2', '-22', '1', '0', '0']);
solve(['-2', '4', '3', '2', '0']);
solve(['0', '-2.5', '0', '5', '5']);
solve(['-3', '-0.5', '-1.1', '-2', '-0.1']);
/*Description

Write a script that finds the biggest of given 5 variables. Use nested if statements.

Input

The input will consist of an array containing five values represented as strings
Output

The output should be a single line containing the answer
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '2', '2', '4', '1']
Output

5
Sample test 2

Input

['-2', '-22', '1', '0', '0']
Output

1
Sample test 3

Input

['-2', '4', '3', '2', '0']
Output

4
Sample test 4

Input

['0', '-2.5', '0', '5', '5']
Output

5
Sample test 5

Input

['-3', '-0.5', '-1.1', '-2', '-0.1']
Output

-0.1*/