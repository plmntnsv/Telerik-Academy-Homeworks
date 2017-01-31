function solve(args) {
     var firstNum = +args[0],
         secondNum = +args[1];
     if (firstNum > secondNum) {
         return secondNum +' '+firstNum;
     }
     return firstNum +' '+secondNum;
}
solve(['5', '2']);
/*Description

Write an if statement that takes two double variables a and b 
and exchanges their values if the first one is greater than the 
second. As a result print the values a and b, separated by a space.

Input

The input will consist of an array containing two values - a and b represented as strings
Output

The output should be a single line containing two numbers
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5', '2']
Output

2 5
Sample test 2

Input

['3', '4']
Output

3 4
Sample test 3

Input

['5.5', '4.5']
Output

4.5 5.5*/