function solve(args) {
    var smallest,
        indexOfSmallest,
        tempSmallest;
    for (var i = 1; i < args.length; i += 1) {
        smallest = +args[i];
        indexOfSmallest = i;
        tempSmallest = smallest;
        for (var j = i+1; j < args.length; j += 1) {
            if (+args[j] < smallest) {
                smallest = +args[j];
                args[indexOfSmallest] = smallest;
                args[j] = tempSmallest;
                tempSmallest = smallest;
            }
        }
        console.log(smallest);
    }
    //console.log(args.join('\n'));
}
solve(['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']);
/*Description

Sorting an array means to arrange its elements in increasing order. Write a program to sort an array.
Use the Selection sort algorithm: Find the smallest element, move it at the first position,
find the smallest from the rest, move it at the second position, etc.

Input

On the first line you will receive the number N
On the next N lines the numbers of the array will be given
Output

Print the sorted array
Each number should be on a new line
Constraints

1 <= N <= 1024
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['6', '3', '4', '1', '5', '2', '6']
Output

1
2
3
4
5
6
Sample test 2

Input

['10', '36', '10', '1', '34', '28', '38', '31', '27', '30', '20']
Output

1
10
20
27
28
30
31
34
36
38*/