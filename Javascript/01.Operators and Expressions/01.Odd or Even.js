function solve(args) {
     var input = +args[0];
     if(input % 2 === 0){
         console.log('even '+input);
     }else {
         console.log('odd ' + input);
     }
}
solve(['5']);
/*input

You will receive the input as an array with only one element - the integer number as a javascript string.
Output

Output a single value - if the number is even, output even, followed by a space and the value of the number.
Otherwise, print odd, again followed by a space and the number's value. See the sample tests.
You can use console.log to print the results or you can use return to return the answer. Both are correct.
Constraints

The input number will always be a valid integer number.
The input number will always be in the range [-30, 30].
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input

['3']
Output

odd 3
Sample Test 2

Input

['2']
Output

even 2
Sample Test 3

Input

['-2']
Output

even -2
Sample Test 4

Input

['-1']
Output

odd -1
Sample Test 5

Input

['0']
Output

even 0
*/
