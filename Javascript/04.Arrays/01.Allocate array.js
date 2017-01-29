function solve(args) {
    var arrSize = +args[0],
        numsArr = new Array(arrSize);
    for (var i = 0; i < arrSize; i+=1) {
        numsArr[i] = i * 5;
        console.log(numsArr[i]);
    }
}
solve(['5']);
/*Description

Write a program that allocates array of N integers, initializes each element by its index multiplied by 5 and the prints the obtained array on the console.

Input

On the only line you will receive the number N
Output

Print the obtained array on the console.
Each number should be on a new line
Constraints

1 <= N <= 20
N will always be a valid integer number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['5']
Output

0
5
10
15
20*/