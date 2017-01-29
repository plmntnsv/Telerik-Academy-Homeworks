function solve(args) {
     var input = +args[0];
     if(input%5 === 0 && input%7===0) {
         console.log('true '+input);
     }else{
         console.log('false '+input);
     }
}
solve(['35']);
/*Description

Implement a javascript function that does the following:

Accepts an array containing a single integer number as string.
Stores in a variable if the number can be divided by 7 and 5 without remainder.
Prints on the console "true NUMBER" if the number is divisible without remainder by 7 and 5. Otherwise prints "false NUMBER". In place of NUMBER print the value of the input number.
Input

The input will consist of an array containing a single integer value as a string.
Output

The output must always follow the format specified in the description. See the sample tests.
You can use console.log to print the results or you can use return to return the answer. Both are correct.
Constraints

The input will always consist of valid integers and follow the format in the description.
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['3']
Output

false 3
Sample test 2

Input

['0']
Output

true 0
Sample test 3

Input

['5']
Output

false 5
Sample test 4

Input

['7']
Output

false 7
Sample test 5

Input

['35']
Output

true 35
Sample test 6

Input

['140']
Output

true 140*/
