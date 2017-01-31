function solve(args) {
    var coefA = +args[0],
        coefB = +args[1],
        coefC = +args[2],
        discriminant = (coefB * coefB) - (4 * coefA * coefC),
        x1 = +((-coefB + Math.sqrt(discriminant)) / (2 * coefA)),
        x2 = +((-coefB - Math.sqrt(discriminant)) / (2 * coefA));
    if (discriminant === 0) {
        console.log('x1=x2=' + x1.toFixed(2));
    } else if (discriminant > 0) {
        if (x1 > x2) {
            console.log('x1=' + x2.toFixed(2) + '; ' + 'x2=' + x1.toFixed(2));
        } else if (x2 > x1) {
            console.log('x1=' + x1.toFixed(2) + '; ' + 'x2=' + x2.toFixed(2));
        }
    } else {
        console.log('no real roots');
    }
}
solve(['2', '5', '-3']);
solve(['-1', '3', '0']);
solve(['-0.5', '4', '-8']);
solve(['5', '2', '8']);
solve(['0.2', '9.572', '0.2']);
/*Description

Write a script that reads the coefficients a, b and c of a quadratic equation
ax^2 + bx + c = 0 and solves it (prints its real roots). Calculates and prints its real roots.

Note: Quadratic equations may have 0, 1 or 2 real roots.

Input

The input will consist of an array containing three values - a, b and c represented as strings
Output

The output should be a single line containing the real roots (see sample tests)
Print numbers with two digits of precision after the floating point
If there are two roots then x1 < x2
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input
['2', '5', '-3']
Output
x1=-3.00; x2=0.50

Sample test 2

Input
['-1', '3', '0']
Output
x1=0.00; x2=3.00

Sample test 3

Input
['-0.5', '4', '-8']
Output
x1=x2=4.00

Sample test 4

Input
['5', '2', '8']
Output
no real roots

Sample test 5

Input
['0.2', '9.572', '0.2']
Output
x1=-47.84; x2=-0.02*/