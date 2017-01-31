function solve(args) {
    let size = +args[0],
        arr = args[1].split(' ');

    console.log(SortArray(arr, size).join(' '));

    function FindIndexOfLargest(arr, startingIndex) {
        let largestNum = +arr[startingIndex],
            indexOfLargest = startingIndex;

        for (let i = startingIndex - 1; i >= 0; i--) {
            if (+arr[i] > largestNum) {
                largestNum = arr[i];
                indexOfLargest = i;
            }
        }
        return indexOfLargest;
    }

    function SortArray(arr, size) {
        for (let i = size - 1; i >= 0; i--) {
            let indexOfLargest = FindIndexOfLargest(arr, i),
                temp = +arr[i];
            arr[i] = +arr[indexOfLargest];
            arr[indexOfLargest] = temp;
        }
        return arr;
    }
}
solve(['6', '3 4 1 5 2 6']);
/*Description

Write a method that returns the maximal element in a portion of
array of integers starting at given index. Using it write another
method that sorts an array in ascending / descending order.
Write a program that sorts a given array.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print the sorted array
Elements must be separated by spaces
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input	                        Output
6
3 4 1 5 2 6	                    1 2 3 4 5 6
10
36 10 1 34 28 38 31 27 30 20	1 10 20 27 28 30 31 34 36 38*/