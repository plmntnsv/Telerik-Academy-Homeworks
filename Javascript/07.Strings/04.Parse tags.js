function solve(args) {
    var input = args[0].split('');
    let result = '';
    //input = input.replace(/<orgcase>/g, '').replace(/<\/orgcase>/g, '');
    for (var i = 0; i < input.length;) {
        if (input[i] + input[i + 1] === '<u') {
            result += toUpper(i + 8);
        } else if (input[i] + input[i + 1] === '<l') {
            result += toLower(i + 9);
        } else if (input[i] + input[i + 1] === '<o') {
            result += orgCase(i + 9);
        } else {
            result += input[i];
            i += 1;
        }
    }

    function toUpper(startIndex) {
        i = startIndex;
        let result = '';
        while (true) {
            if (input[i] + input[i + 1] + input[i + 2] === '</u') {
                i += 9;
                return result;
            } else if (input[i] + input[i + 1] === '<u') {
                result += toUpper(i + 8);
            } else if (input[i] + input[i + 1] === '<l') {
                result += toLower(i + 9);
            } else if (input[i] + input[i + 1] === '<o') {
                result += orgCase(i + 9);
            } else {
                result += input[i].toUpperCase();
                i += 1;
            }
        }
    }

    function toLower(startIndex) {
        i = startIndex;
        let result = '';
        while (true) {
            if (input[i] + input[i + 1] + input[i + 2] === '</l') {
                i += 10;
                return result;
            } else if (input[i] + input[i + 1] === '<u') {
                result += toUpper(i + 8);
            } else if (input[i] + input[i + 1] === '<l') {
                result += toLower(i + 9);
            } else if (input[i] + input[i + 1] === '<o') {
                result += orgCase(i + 9);
            } else {
                result += input[i].toLowerCase();
                i += 1;
            }
        }
    }

    function orgCase(startIndex) {
        i = startIndex;
        let result = '';
        while (true) {
            if (input[i] + input[i + 1] + input[i + 2] === '</o') {
                i += 10;
                return result;
            } else if (input[i] + input[i + 1] === '<u') {
                result += toUpper(i + 8);
            } else if (input[i] + input[i + 1] === '<l') {
                result += toLower(i + 9);
            } else if (input[i] + input[i + 1] === '<o') {
                result += orgCase(i + 9);
            } else {
                result += input[i];
                i += 1;
            }
        }
    }
    console.log(result);
}
//solve(['izvun izvun <orgcase>OrG <orgcase>oRg </orgcase>dr OrG</orgcase> izvun']);
//solve(['Asd <orgcase>OrG <upcase>up <lowcase>LOW <orgcase>OrG </orgcase></lowcase>up </upcase>OrG </orgcase>Dsa <lowcase>LOW</lowcase> J']);
//solve(['aSDf<upcase>upcase<lowcase>LOWCASE<upcase>upcase</upcase></lowcase></upcase><lowcase>LOWCASE</lowcase>']);
//solve(['<orgcase>OrGcAsE<lowcase>LOWCASE<upcase>upcase</upcase>LOWCASE</lowcase>OrGcAsE</orgcase>']);
//solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow <lowcase>PSHH</lowcase> submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.']);
/*Description

You are given a text. Write a function that changes the text in all regions:

<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<orgcase>text</orgcase> does not change casing
Note: Regions can be nested.

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]
Output

We are liViNg in a YELLOW SUBMARINE. We doN't have anything else.*/