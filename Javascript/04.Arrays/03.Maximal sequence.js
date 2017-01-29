function solve(args) {
    var length = +args[0],
        biggestSeq = 1,
        currentSeq = 1;
     for (var i = 2; i <= length; i+=1) {
         if (+args[i] === +args[i-1]) {
             currentSeq += 1;
             if (currentSeq > biggestSeq) {
                 biggestSeq = currentSeq;
             }
         } else {
             currentSeq = 1;
         }
    }
     return biggestSeq;
}
solve(['3', '2', '1', '1']);
// solve(['10', '1', '1', '1', '1', '3', '3', '2', '2', '2', '1']);
// solve(['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '2']);
// solve(['10', '2', '2', '2', '2', '2', '2', '2', '2', '2', '1']);
/*Description

Write a program that finds the length of the maximal sequence of equal elements in an array of N integers.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the length of the maximal sequence
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['10', '2', '1', '1', '2', '3', '3', '2', '2', '2', '1']
Output

3*/