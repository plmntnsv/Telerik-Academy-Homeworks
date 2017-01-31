function deepCopy(obj) {
     if (obj !== null && Object.prototype.toString.call(obj) === '[object Array]') {
      var out = [], i = 0, len = obj.length;
        for ( ; i < len; i++ ) {
            out[i] = arguments.callee(obj[i]);
        }
        return out;
    }
    if (typeof obj === 'object') {
        var out = {}, i;
        for ( i in obj ) {
            out[i] = arguments.callee(obj[i]);
        }
        return out;
    }
    return obj;   
}
var arr1 = deepCopy([[1, 2, 3], [1, 2, 3], [1, 2, 3]]);
var arr2 = deepCopy(arr1);
arr1[0] = 'ddz';
console.log(arr1+'\n'+arr2);
deepCopy(['replaced', [1, 2, 3], [1, 2, 3]]);
var primitive = deepCopy(5);
var anotherPrimitive = primitive;
console.log(primitive + ' ' + anotherPrimitive);
anotherPrimitive = 3;
console.log(primitive + ' ' + anotherPrimitive);
/*Description
http://james.padolsey.com/javascript/deep-copying-of-objects-and-arrays/
Write a function that makes a deep copy of an object.
The function should work for both primitive and reference types.*/