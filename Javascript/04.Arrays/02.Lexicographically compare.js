function solve(args) {
    let firstArr = args[0],
        secondArr = args[1];
    // console.log(Array.isArray(args));
    // console.log(firstArr);
    // console.log(secondArr);
    // console.log(args);
    // var chArr = new Array(2);
    // chArr[0] = firstArr;
    // chArr[1] = secondArr;
    // console.log(chArr);
    // console.log(args === chArr);
    // console.log(args === chArr.join(","));
    // console.log(typeof args);
    // console.log(typeof chArr);
    // return;
    if (firstArr > secondArr) {
        console.log('>');//return '>';
    } else if (firstArr < secondArr) {
       console.log('<');// return '<';
    } else {
        console.log('=');//return '=';
    }
}
solve(['hello', 'halo']);
/*Write a program that compares two char arrays lexicographically (letter by letter).

Input

On the first line you will receive the first char array as a string
On the second line you will receive the second char array as a string
Output

Print < if the first array is lexicographically smaller
Print > if the second array is lexicographically smaller
Print = if the arrays are equal
Constraints

1 <= size of arrays <= 128
Time limit: 0.1s
Memory limit: 16MB
Sample tests

Sample test 1

Input

['hello', 'halo']
Output

>
Sample test 2

Input

['food', 'food']
Output

=*/