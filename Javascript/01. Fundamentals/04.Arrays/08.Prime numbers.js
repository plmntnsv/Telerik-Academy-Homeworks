function solve(args) {
    let lastNum = +args[0],
        checkedArr = new Array(lastNum);
    for (let i = 2; i <= Math.ceil(Math.sqrt(lastNum)); i++) {
        if (checkedArr[i] !== 1) {
            for (let j = i * i; j <= lastNum; j += i) {
                checkedArr[j] = 1;
            }
        }
    }
    for (let i = lastNum; i >= 2; i--) {
        if (checkedArr[i] !== 1) {
            console.log(i);
            break;
        }
    }
    //bez masiv ot zad napred 100/100
    // for (let i = lastNum; i >= 2; i -= 1) {
    //     let isPrime = true;
    //     for (let j = 2; j < Math.ceil(Math.sqrt(lastNum)); j+=1) {
    //         if (i % j === 0 && j !== i) {
    //             isPrime = false;
    //             break;
    //         }
    //     }
    //     if (isPrime) {
    //         console.log(i);
    //         break;
    //     }
    // }
}
solve(['126']);
/*Description

Write a program that finds all prime numbers in the range [1 ... N]. Use the Sieve of Eratosthenes algorithm. The program should print the biggest prime number which is <= N.

Input

On the first line you will receive the number N
Output

Print the biggest prime number which is <= N
Constraints

2 <= N <= 10 000 000
Time limit: 0.3s
Memory limit: 64MB
Sample tests

Input	Output
13	13
126	113
26	23*/