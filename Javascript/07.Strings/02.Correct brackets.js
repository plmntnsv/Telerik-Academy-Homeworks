function solve(args) {
    var inputArr = args[0].split(''),
        i,
        j,
        len = inputArr.length,
        correctBracket = true;
    for (i = 0; i < len; i += 1) {
        if (inputArr[i] === ')' || correctBracket === false) {
            correctBracket = false;
            break;
        } else if (inputArr[i] === '(') {
            for (j = i; j < len; j += 1) {
                if (inputArr[j] === ')') {
                    inputArr[j] = '-';
                    correctBracket = true;
                    break;
                }
                correctBracket = false;
            }
        }
    }
    console.log(correctBracket ? 'Correct' : 'Incorrect');
}
solve(['((a+b)/5-d)(']);
solve([')(a+b))']);
/*Description

Write a JavaScript function to check if in a given expression the brackets are put correctly.

Input

The input will consist of an array containing a string
Output

The output should be consisted of one line
Correct or Incorrect
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input

[ '((a+b)/5-d)' ]
Output

Correct
Sample Test 2

Input

[ ')(a+b))' ]
Output

Incorrect*/