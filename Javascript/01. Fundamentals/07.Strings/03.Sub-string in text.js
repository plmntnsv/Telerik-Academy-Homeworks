function solve(args) {
    var word = args[0].toLowerCase(),
        text = args[1].toLowerCase(),
        nxtPos = 0,
        count = 0;
    while (true) {
        var testBefore = text.indexOf(word, nxtPos);
        if ( text.indexOf(word, nxtPos) > -1) {
            count++;
        } else {
            break;
        }
        nxtPos = text.indexOf(word, nxtPos)+1;
    }
    console.log(count);
}
solve([
    'In',
    'We are livIng In an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);
/*Description

Write a JavaScript function that finds how many times a substring
is contained in a given text (perform case insensitive search).

Input
The input will consist of an array containing one string

Output
The output should be consisted of one line - the number of matches

Constraints
Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input
[
    'in',
    'We are living in an yellow submarine.
    We don\'t have anything else.
    inside the submarine is very tight.
    So we are drinking all the day.
    We will move out of it in 5 days.'
]
Output
9

Explanation

We are liv*IN*1g *IN*2 an yellow submar*IN*3e.
We don't have anyth*IN*4g else.
*IN*5side the submar*IN*6e is very tight.
So we are dr*IN*7k*IN*8g all the day.
We will move out of it *IN*9 5 days.*/