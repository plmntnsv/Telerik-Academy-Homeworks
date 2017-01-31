function solve(args) {
     var sideA = +args[0],
         sideB = +args[1],
         height = +args[2];
         return (((sideA + sideB) / 2) * height).toFixed(7);
}
solve(['5', '7', '12']);
/*Description

Implement a javascript function that calculates trapezoid's area 
by given sides a and b and height h. The three values should be 
read from the console in the order shown below. All three value 
will be floating-point numbers.

Input

The input will consist of an array with exactly 3 numbers as elements: a, b and h, all as strings.
Output

Output a single line containing a single value - the area of the trapezoid. Output the area with exactly 7-digit precision after the floating point.
You can use console.log to print the results or you can use return to return the answer. Both are correct.
Constraints

All numbers will always be valid floating-point numbers in the range [-500, 500].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '7', '12']
Output

72.0000000
Sample test 2

Input

['2', '1', '33']
Output

49.5000000
Sample test 3

Input

['8.5', '4.3', '2.7']
Output

17.2800000
Sample test 4

Input

['100', '200', '300']
Output

45000.0000000
Sample test 5

Input

['0.222', '0.333', '0.555']
Output

0.1540125*/