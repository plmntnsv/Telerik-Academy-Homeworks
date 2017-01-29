function solve(args) {
    var input = +args[0],
        numHolder = '';
    for (var index = 1; index <= input; index += 1) {
             if (index === input) {
                 numHolder += index;
                 return numHolder;
             }
             numHolder += index + ' ';
    }   
}
solve([5]);
/*Description

Implement a javascript function that accepts an array with a single element -
positive integer N as string and prints all the numbers from 1 to N inclusive, on a single line, separated by a whitespace.

Input

The input will consist of an array with a single element - the number N.
Output

The output should consist of a single line - the numbers from 1 to N, separated by a whitespace.
Constraints

N will be a valid positive 32-bit integer
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5']
Output

1 2 3 4 5
Sample test 2

Input

['1']
Output

1*/