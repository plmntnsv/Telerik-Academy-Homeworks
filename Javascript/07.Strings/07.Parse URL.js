function solve(args) {
    var input = args[0].split(""),
        start = 0,
        end = input.length,
        prot = "protocol: ",
        serv = "server: ",
        reso = "resource: ";
    Array.prototype.extract = extract;
    prot += input.extract(start, end, ':');
    console.log(prot);
    serv += input.extract(start + 3, end, '/');
    console.log(serv);
    reso += input.extract(start, end);
    console.log(reso);

     function extract(startIndex, endIndex, breakSymbol) {
        let result = "";
        for (var i = startIndex; i < endIndex; i += 1) {
            if (input[i] === breakSymbol) {
                start = i;
                return result;
            }
            result += input[i];
        }
        return result; 
    }
}
solve(['http://telerikacademy.com/Courses/Courses/Details/239']);
/*Description

Write a script that parses an URL address given in the format:
[protocol]://[server]/[resource]
and extracts from it the [protocol], [server] and [resource] elements.

Input

The input will consist of an array containing one string
Output

The output should be consisted of three line
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Input

[ 'http://telerikacademy.com/Courses/Courses/Details/239' ]
Output

protocol: http
server: telerikacademy.com
resource: /Courses/Courses/Details/239*/