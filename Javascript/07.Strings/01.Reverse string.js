function solve(args) {
    var chArr = args[0].split(''),
        i = 0,
        length = chArr.length-1,
        result = '';
    for (i = length; i >=0; i-=1) {
        result += chArr[i];
    }
console.log(result);
}
solve(['12345678910']);
solve(['qwertytrewq']);
/*Description

Write a JavaScript function that reverses a string.

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line - the reversed string
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input

[ 'sample' ]
Output

elpmas
Sample Test 2

Input

[ 'qwertytrewq' ]
Output

qwertytrewq*/