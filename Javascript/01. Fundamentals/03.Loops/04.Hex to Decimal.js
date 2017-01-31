function solve(args) {
    var input = args[0],
        result = 0;
    for (var i = 0; i < input.length; i += 1) {
        var test = +input.charAt(i);
        var trueTest = Number.isInteger(+input.charAt(i)) ? true : false;
        if (Number.isInteger(+input.charAt(i))) {
            result = result * 16 + (+input.charAt(i));
        } else {
            switch (input.charAt(i)) { //baven
                case 'A':
                    result = result * 16 + 10;
                    break;
                case 'B':
                    result = result * 16 + 11;
                    break;
                case 'C':
                    result = result * 16 + 12;
                    break;
                case 'D':
                    result = result * 16 + 13;
                    break;
                case 'E':
                    result = result * 16 + 14;
                    break;
                case 'F':
                    result = result * 16 + 15;
                    break;
                default:
                    break;
            }
        // if (input.charAt(i) === 'A') { ////po-burzo
        //     result = (result * 16) + 10;
        // }
        // else if (input.charAt(i) === 'B') {
        //     result = (result * 16) + 11;
        // }
        // else if (input.charAt(i) === 'C') {
        //     result = (result * 16) + 12;
        // }
        // else if (input.charAt(i) === 'D') {
        //     result = (result * 16) + 13;
        // }
        // else if (input.charAt(i) === 'E') {
        //     result = (result * 16) + 14;
        // }
        // else if (input.charAt(i) === 'F') {
        //     result = (result * 16) + 15;
        //     }
        }
    }
    return result;
}
solve(['FE']);
/*
Description

Using loops implement a javascript function that converts a hex number number to its decimal representation.

Input

The input will consists of a single line containing a single hexadecimal number as string.
Output

The output should consist of a single line - the decimal representation of the number as string.
Constraints

All numbers will be valid 64-bit integers.
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['FE']
Output

254
Sample test 2

Input

['1AE3']
Output

6883
Sample test 3

Input

['4ED528CBB4']
Output

338583669684*/