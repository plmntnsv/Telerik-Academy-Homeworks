function solve(args) {
    var length = +args[0],
        searchedNum = +args[args.length - 1],
        middleIndex = Math.floor(length / 2),
        begin = 0,
        end = length - 1;
    args.splice(0, 1);
    args.splice(args.length - 1, 1);
    while (begin !== end) {
        if (+args[middleIndex] === searchedNum) {
            var checkLeft = middleIndex-1;
            while (+args[checkLeft]===searchedNum) {
                middleIndex--;
                checkLeft--;
            }
            console.log(middleIndex);
            return;
        }
        if (+args[middleIndex] > searchedNum) {
            end = middleIndex - 1;
        } else if (+args[middleIndex] < searchedNum) {
            begin = middleIndex + 1;
        }
        middleIndex = Math.floor((((end - begin) / 2) + begin));
    }
    if (+args[middleIndex]===searchedNum) {
        console.log(middleIndex);
        return;
    }
    return -1;
}
solve(['5', '1', '2', '3', '4', '5', '2']);

/*Description

Write a program that finds the index of given element X in a sorted array of N integers by using the Binary search algorithm.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
On the last line you will receive the number X
Output

Print the index where X is in the array
If there is more than one occurence print the first one
If there are no occurences print -1
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['10', '1', '2', '4', '8', '16', '31', '32', '64', '77', '99', '32']
Output

6*/