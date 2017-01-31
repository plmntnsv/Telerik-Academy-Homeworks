function solve(args) {
    var input = args[0];
    switch (input) {
        case '0':
            console.log('zero');
            break;
        case '1':
            console.log('one');
            break;
        case '2':
            console.log('two');
            break;
        case '3':
            console.log('three');
            break;
        case '4':
            console.log('four');
            break;
        case '5':
            console.log('five');
            break;
        case '6':
            console.log('six');
            break;
        case '7':
            console.log('seven');
            break;
        case '8':
            console.log('eight');
            break;
        case '9':
            console.log('nine');
            break;
        default:
            console.log('not a digit');
            break;
    }
}
solve(['5']);
/*Description

Write a script that asks for a digit (0-9), and depending on the input, shows the digit as a word (in English). Print not a digit in case of invalid input. Use a switch statement.

Input

The input will consist of an array containing a single string
Output

The output should be a single line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['2']
Output

two
Sample test 2

Input

['1']
Output

one
Sample test 3

Input

['0']
Output

zero
Sample test 4

Input

['5']
Output

five
Sample test 5

Input

['-0.1']
Output

not a digit
Sample test 6

Input

['hi']
Output

not a digit
Sample test 7

Input

['9']
Output

nine
Sample test 8

Input

['10']
Output

not a digit*/