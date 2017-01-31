function solve(args) {
    let size = +args[0],
        arr = args[1].split(' ');
    FindLargerNeighbours(arr, size);

    function FindLargerNeighbours(arr, size) {
        let count = 0;
        for (var i = 1; i < size - 1; i += 1) {
            let test = +arr[i];
            if (+arr[i] > +arr[i - 1] && +arr[i] > +arr[i + 1]) {
                count++;
                i++;
            }
        }
        console.log(count);
    }
}
solve(['6', '-26 -25 -28 31 2 27']);
/*Description

Write a method that checks if the element at given position in given array of integers
is larger than its two neighbours (when such exist). Write program that reads an array of
numbers and prints how many of them are larger than their neighbours.

Input

On the first line you will receive the number N - the size of the array
On the second line you will receive N numbers separated by spaces - the array
Output

Print how many numbers in the array are larger than their neighbours
Constraints

1 <= N <= 1024
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input	                    Output
6
-26 -25 -28 31 2 27	        2*/