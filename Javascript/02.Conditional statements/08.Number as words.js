function solve(args) {
    var input = +args[0],
        oneToNine = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'],
        tenToTeens = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'],
        twentyToNinety = ['twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
    if (input <= 9) { //ako e edna cifra
        return oneToNine[input].charAt(0).toUpperCase() + oneToNine[input].slice(1);
    } else if (input >= 10 && input <= 19) { //ako e ot 10 do 19
        return tenToTeens[input - 10].charAt(0).toUpperCase() + tenToTeens[input - 10].slice(1);
    } else if (input >= 20 && input <= 99) { //ako e ot 20 do 99
        return twentyToNinety[Math.trunc(input / 10 - 2)].charAt(0).toUpperCase() + twentyToNinety[Math.trunc(input / 10 - 2)].slice(1) + ' ' + oneToNine[input % 10];
    } else if (input >= 100) { //ako e nad 100
        var firstDigit = Math.trunc(input / 100),
            secondDigit = Math.trunc(input / 10) % 10,
            thirdDigit = input % 10;
        if (secondDigit === 0 && thirdDigit === 0) { //ako e 100-200-300 i t.n.
            return (oneToNine[firstDigit].charAt(0).toUpperCase() + oneToNine[firstDigit].slice(1) + ' hundred');
        } else if (secondDigit === 0) { //ako e ot 100 do 109
            return oneToNine[firstDigit].charAt(0).toUpperCase() + oneToNine[firstDigit].slice(1) + ' hundred and ' + oneToNine[thirdDigit];
        } else if (thirdDigit === 0) { //ako e 110-120-130-210-220-230 i t.n.
            return (oneToNine[firstDigit].charAt(0).toUpperCase() + oneToNine[firstDigit].slice(1) + ' hundred and ' + twentyToNinety[secondDigit - 2]);
        } else if (input % 100 >= 10 && input % 100 <= 19) { //ako e ot 110 do 119, 210 do 219 i t.n.
            return oneToNine[firstDigit].charAt(0).toUpperCase() + oneToNine[firstDigit].slice(1) + ' hundred and ' + tenToTeens[thirdDigit];
        } else { //ako e ot 120 nagore
            return oneToNine[firstDigit].charAt(0).toUpperCase() + oneToNine[firstDigit].slice(1) + ' hundred and ' + twentyToNinety[secondDigit - 2] + ' ' + oneToNine[thirdDigit];
        }

    }
}
solve(['0']);
solve(['9']);
solve(['10']);
solve(['12']);
solve(['19']);
solve(['25']);
solve(['98']);
solve(['273']);
solve(['400']);
solve(['501']);
solve(['617']);
solve(['711']);
solve(['999']);
/*Description

Write a script that converts a number in the range [0…999] to words, corresponding to its English pronunciation.

Input

The input will consist of an array containing the number as a string
Output

The output should be a single line containing the answer
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample test 1 Input ['0'] Output Zero

Sample test 2 Input ['9'] Output Nine

Sample test 3 Input ['10'] Output Ten

Sample test 4 Input ['12'] Output Twelve

Sample test 5 Input ['19'] Output Nineteen

Sample test 6 Input ['25'] Output Twenty five

Sample test 7 Input ['98'] Output Ninety eight

Sample test 8 Input ['273'] Output Two hundred and seventy three

Sample test 9 Input ['400'] Output Four hundred

Sample test 10 Input ['501'] Output Five hundred and one

Sample test 11 Input ['617'] Output Six hundred and seventeen

Sample test 12 Input ['711'] Output Seven hundred and eleven

Sample test 13 Input ['999'] Output Nine hundred and ninety nine*/