// Time limit 60/100 using replace on input string
function solve(args) {
    var input = args[0],//.split(""),
        startIndex = input.indexOf("<a"),
        endIndex = input.indexOf("</a>", startIndex),
        midIndex = input.indexOf(">",startIndex),
        text = "",
        site = "";
     while (startIndex > -1) {
         site = "(" + extractText(startIndex+9, midIndex-1) + ")";
         text = "[" + extractText(midIndex + 1, endIndex) + "]";
         var toBeReplaced = input.slice(startIndex, endIndex + 4);
         input = input.replace(toBeReplaced, text + site);
         //input.splice(startIndex, endIndex + 4);
         startIndex = input.indexOf('<a', startIndex + 1);
         endIndex = input.indexOf("</a>", startIndex);
         midIndex = input.indexOf(">", startIndex);
    }
    function extractText(startIndex, endIndex) {
        var result = "";
        for (var i = startIndex; i < endIndex; i+=1) {
            result += input[i];
        }
        return result;
     }
    console.log(input);
}
solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);
/*Description

Write a JavaScript function that replaces in a HTML document given as
string all the tags <a href="…">…</a> with corresponding tags [TEXT](URL).

Input

The input will consist of an array containing one string
Output

The output should be consisted of one line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[ '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.
Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>' ]
Output

<p>Please visit [our site](http://academy.telerik.com) to choose a training course.
Also visit [our forum](www.devbg.org) to discuss the courses.</p>*/