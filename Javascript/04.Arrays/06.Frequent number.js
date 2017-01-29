function solve(args) {
    var length = +args[0];
    args.splice(0, 1);
    var checkIfVisitedArr = new Array(args.length),
        counter = 1,
        finalCounter = 1,
        biggestNum;
    for (var i = 0; i < args.length; i += 1) {
        if (+checkIfVisitedArr[i]===1) {
            continue;
        }
        for (var j = i + 1; j < args.length; j += 1) {
            if (+args[i]===+args[j]) {
                counter += 1;
                checkIfVisitedArr[j] = 1;
            }
        }
        if (counter > finalCounter) {
            finalCounter = counter;
            biggestNum = +args[i];
        }
        counter = 1;
    }
      console.log(biggestNum+' ('+finalCounter+' times)');   
}
solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);
/*Description

Write a program that finds the most frequent number in an array of N elements.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the most frequent number and how many time it is repeated
Output should be REPEATING_NUMBER (REPEATED_TIMES times)
Constraints

1 <= N <= 1024
0 <= each number in the array <= 10000
There will be only one most frequent number
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']
Output

4 (5 times)*/