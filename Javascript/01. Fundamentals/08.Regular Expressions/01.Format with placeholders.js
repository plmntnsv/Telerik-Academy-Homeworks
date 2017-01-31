function solve(args) {
    let obj = JSON.parse(args[0]),
        str = args[1],
        final = str,
        reg = /#{(.*?)}/g,
        match = reg.exec(str);
    String.prototype.formatString = formatString;
   console.log(final.formatString(obj, final, match));
    // while (match) {
    //     final = formatString(obj, final, match);
    //     match = reg.exec(str);
    // }

    function formatString(obj, final, match) {
        for (let key in obj) {
            final = final.replace(new RegExp('#{' + key + '}', 'g'), obj[key]);
            // if (key === match[1]) {
            //     let result = strTest.replace(match[0], obj[key]);
            // }
        }
        return final;
    }
}
solve([
    '{ "name": "John", "age": 13, "_": 3 }',
"My name is #{name} and I am #{age}-years-old #{_}"
]);
// solve([
//     '{ "name": "John" }',
//     "Hello, there! Are you #{name}?"
// ]);
/*Description

Write a function that formats a string.
The function should have placeholders, as shown in the example
Add the function to the String.prototype
Input

The input array will look like that:
[
    '{ "name": "John", age: 13 }', // options as JSON
    'My name is #{name} and I am #{age}-years-old' // template
]
Hint: you can use JSON.parse method to convert the options to an object.
Output

Output the formatted string.
Constraints

The options will always be passed as a JSON-stringified object
The input will be relatively small
The options will be 6-7 at most
The longest template string will be shorter than 2000 symbols
Time limit: 0.2s
Memory limit: 32MB
Sample tests

Input	                                        Output
[                                               'Hello, there! Are you John'
'{ "name": "John" }',
"Hello, there! Are you #{name}?"
]
            
[                                               'My name is John and I am 13-years-old'   
'{ "name": "John", "age": 13 }',
"My name is #{name} and I am #{age}-years-old"
]	*/