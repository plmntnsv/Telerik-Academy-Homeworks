function solve(args) {
    var searchedNum = +args[+args.length - 1];
        args = args.slice(1, +args.length - 1);
    var left = 0,
        right = +args.length - 1;
    while (left <= right) {
        var middle = Math.floor((right + left) / 2);
        if (+args[middle] === searchedNum) {
            console.log(middle);
            break;
        }
        if (+args[middle] < searchedNum) {
            left = middle + 1;
        }
        else if (+args[middle] > searchedNum) {
            right = middle - 1;
        }
    }
    if (left > right) {
        console.log(-1);
    }
}
/// return dava greshka na 1 ot testovete...
//return args.indexOf(searchedNum.toString());
function solve(args) {
    var searchedNum = +args[args.length - 1];
    args.splice(0, 1);
    args.splice(args.length - 1, 1);
    var begin = 0,
        end = +args.length - 1;
    //return args.indexOf(searchedNum.toString());
    while (begin <= end) {
        var middleIndex = Math.floor((end + begin) / 2);
        if (+args[middleIndex] === searchedNum) {
            // var checkLeft = middleIndex-1;
            // while (+args[checkLeft]===searchedNum) {
            //     middleIndex--;
            //     checkLeft--;
            // }
            console.log(middleIndex);
            return;
        }
        if (+args[middleIndex] < searchedNum) {
            begin = middleIndex + 1;
        } else if (+args[middleIndex] > searchedNum) {
            end = middleIndex - 1;
        }
    }
    return -1;
}