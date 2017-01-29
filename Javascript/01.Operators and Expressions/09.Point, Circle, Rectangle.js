function solve(args) {
     var xCoord = +args[0],
         yCoord = +args[1],
         r = 1.5,
         insideCircle = true,
         insideRect = true,
         posInCircle = Math.sqrt((xCoord-1)*(xCoord-1)+(yCoord-1)*(yCoord-1));
         if (posInCircle>r) {
             insideCircle = false;
         }
         if ((xCoord < -1 || xCoord > 5) || (yCoord > 1 || yCoord < -1)) {
             insideRect = false;
         }
         if (insideCircle && insideRect) {
             return "inside circle inside rectangle";
         } else if(insideCircle && !insideRect) {
             return "inside circle outside rectangle";
         } else if (!insideCircle && insideRect) {
             return "outside circle inside rectangle";
         } else{
              return "outside circle outside rectangle";
         }
}
solve(['2.5', '2']);
/*Description

Implement a javascript function that accepts an array with a pair of coordinates 
x and y and uses an expression to checks for given point (x, y) if it is within 
the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).

Input

You will receive the pair of coordinates as two elements of an array - the first element will be x, and the second - y.
Output

Print inside circle if the point is inside the circle and outside circle if it's outside. 
Then print a single whitespace followed by inside rectangle if the point is inside the 
rectangle and outside rectangle otherwise. See the sample tests for a visual description.
You can use console.log to print the results or you can use return to return the answer. 
Both are correct.
Constraints

The coordinates x and y will always be valid floating-point numbers in the range [-1000, 1000].
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['2.5', '2']
Output

outside circle outside rectangle
Sample test 2

Input

['0', '1']
Output

inside circle inside rectangle
Sample test 3

Input

['2.5', '1']
Output

inside circle inside rectangle
Sample test 4

Input

['1', '2']
Output

inside circle outside rectangle*/