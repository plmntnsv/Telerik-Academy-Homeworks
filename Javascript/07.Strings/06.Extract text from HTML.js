"use strict"
function solve(args) {
    var input = "",
        result = "",
        next = 0,
        i,
        start,
        end;
    for (i = 0; i < args.length; i += 1) {
        input += args[i].trim();
    }
    input = input.split("");
    while (true) {
        start = input.indexOf(">", next);
        if (start > -1) {
            end = input.indexOf("<", start);
        }
        if (start > -1 && input[start + 1] !== "<") {
            for (i = start+1; i < end; i+=1) {
                result += input[i];
            }
        } else if (start === -1) {
            break;
        }
        next = start+1;
    }
    console.log(result);
}
solve([
    'body>',    
    '<article>',
    '    <p>Proceding text</p>',       
    '    <ol class="I">',
    '            <li>List Item 1',
    '                    <ol type="a">',
    '                            <li>Nested item 1.1</li>',
    '                            <li>Nested item 1.2</li>',
    '                    </ol>',
    '            </li>',
    '            <li>List Item 2',
    '                    <ol class="decimal">',
    '                            <li>Nested Item 2.1</li>',
    '                            <li>Nested Item 2.2',
    '                                    <ul class="circle">',
    '                                            <li>Nested Item 2.2.1</li>',
    '                                            <li>Nested Item 2.2.2',
    '                                                    <ul class="square">',
    '                                                            <li>Nested Item 2.2.2.1</li>',
    '                                                            <li>Nested Item 2.2.2.2</li>',
    '                                                    </ul>',
    '                                            </li>',
    '                                            <li>Nested Item 2.2.3</li>',
    '                                    </ul>',
    '                            </li>',
    '                            <li>Nested Item 2.3</li>',
    '                    </ol>',
    '            </li>',
    '            <li>List Item 3',
    '                    <ul class="disc">',
    '                            <li>Nested Item 3.1</li>',
    '                            <li>Nested Item 3.1</li>',
    '                            <li>Nested Item 3.1</li>',
    '                    </ul>',
    '            </li>',
    '    </ol>',
    '    </article>',
    '</body>',
]);
solve(['<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '<div> test </div>',
    '  </body>',
    '</html>'
]);
//"<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>"
/*Description

Write a function that extracts the content of a html page given as text.
The function should return anything that is in a tag, without the tags.

Input

The input will consist of an array of strings
Output

The output should be consisted of one line - text inside tags
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]
Output

Sample sitetextmore textand more...in body*/