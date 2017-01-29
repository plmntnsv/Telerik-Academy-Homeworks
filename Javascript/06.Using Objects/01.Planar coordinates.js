function solve(args) {
    var arrNum = args.map(Number);
    var LineA, LineB, LineC;

    function makeLine(x1, y1, x2, y2) {
        return {
            x1: x1,
            y1: y1,
            x2: x2,
            y2: y2,
            length: function () {
                return Math.sqrt((this.x2 - this.x1) * (this.x2 - this.x1) + (this.y2 - this.y1) * (this.y2 - this.y1));
            }
        }
    }
    LineA = new makeLine(arrNum[0], arrNum[1], arrNum[2], arrNum[3]);
    aLength = LineA.length();
    console.log(aLength.toFixed(2));
    LineB = new makeLine(arrNum[4], arrNum[5], arrNum[6], arrNum[7]);
    bLength = LineB.length();
    console.log(bLength.toFixed(2));
    LineC = new makeLine(arrNum[8], arrNum[9], arrNum[10], arrNum[11]);
    cLength = LineC.length();
    console.log(cLength.toFixed(2));

    if (aLength + bLength > cLength &&
        bLength + cLength > aLength &&
        cLength + aLength > bLength) {
        console.log('Triangle can be built');
    } else {
        console.log('Triangle can not be built');
    }
}
solve(['5', '6', '7', '8', '1', '2', '3', '4', '9', '10', '11', '12']);
/*Description

Write functions for working with shapes in standard Planar coordinate system.

Points are represented by coordinates
Lines are represented by two points, marking their beginning and ending
You will be given three line segments. Calculate their length.
Check if the line segments can form a triangle.
Input

The input will consist of an array containing twelve values
Line 1, Point 1 X
Line 1, Point 1 Y
Line 1, Point 2 X
Line 1, Point 2 Y
Line 2, Point 1 X
...
Output

The output should be consisted of four lines
Three lines showing the length of each line segment
Use 2 digits of precision
Fourth line should be one of:
Triangle can be formed
Triangle can't be formed
Constraints

Time limit: 0.2s
Memory limit: 16MB
Sample tests

Sample Test 1

Input

[
  '5', '6', '7', '8',
  '1', '2', '3', '4',
  '9', '10', '11', '12'
]
Output

2.83
2.83
2.83
Triangle can be built
Sample Test 2

Input

[
  '7', '7', '2', '2',
  '5', '6', '2', '2',
  '95', '-14.5', '0', '-0.123'
]
Output

7.07
5.00
96.08
Triangle can not be built*/