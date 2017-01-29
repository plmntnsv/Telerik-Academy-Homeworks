// 100/100. Not replacing the input, but concatenating to a new finalResult string variable parts of the input
function solve(args) {
    var input = args[0],
        startIndex = input.indexOf("<a"),
        endIndex = input.indexOf("</a>", startIndex),
        midIndex = input.indexOf(">", startIndex),
        finalResult = input.slice(0, startIndex),
        text = "",
        site = "";
     while (startIndex > -1) {
         site = "(" + extractText(startIndex+9, midIndex-1) + ")";
         text = "[" + extractText(midIndex + 1, endIndex) + "]";
         finalResult += text + site;
         startIndex = input.indexOf('<a', startIndex + 1);
         if (startIndex > -1) {
             finalResult += input.slice(endIndex + 4, startIndex);
         } else {
             finalResult += input.slice(endIndex + 4, input.length);
         }
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
    console.log(finalResult);
}
solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);