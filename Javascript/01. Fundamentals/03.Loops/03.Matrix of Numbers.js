function solve(args) {
    var size = +args[0],
        start = 1,
        next = start;
        index = 0,
        tempArr = new Array(size);
         for (var i = 1; i <= size*size; i+=1) {
             tempArr[index] = next;
             index += 1;
             next += 1;
             if (index === size) {
                 console.log(tempArr.join(" "));
                 tempArr.splice(0, size);
                 start += 1;
                 next = start;
                 index = 0;
             }
         }
}
solve([2]);
/*Description

Write a javascript function that prints a matrix like in the examples below by a given integer N. Use two nested loops.

Challenge: achieve the same effect without nested loops.
Input

The input array will contain a single number as string, the integer N.
Output

See the examples.
Constraints

1 <= N <= 20
N will always be a valid integer number
Time limit: 0.2s
Memory limit: 32MB
Sample tests

Sample test 1

Input

['2']
Output

1 2
2 3
Sample test 2

Input

['3']
Output

1 2 3
2 3 4
3 4 5
Sample test 3

Input

['4']
Output

1 2 3 4
2 3 4 5
3 4 5 6
4 5 6 7*/