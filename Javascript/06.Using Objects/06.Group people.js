var people = [
  { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'John', lastname: 'Doe', age: 42 },
  { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
  { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
  { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];

var groupByAge = {};
var currentPersonAge;
for (var i = 0; i < people.length; i += 1) {
    if (!(groupByAge.hasOwnProperty(people[i].age))) {
      groupByAge[[people[i].age]] = [];
    } 
  AddElementsToArrPropInObj(groupByAge, people[i]);
}
function AddElementsToArrPropInObj(obj, person) {
  for (var key in obj) {
    if (key == person.age) {
      obj[key].push(person);
      return;
    }
  }
}
// for (var key in groupByAge) {
  
//   console.log(key);
//   console.log(groupByAge[key]);
// }
console.log(groupByAge);
/*Description

Write a function that groupByAge an array of people by age.
The function must return an associative array, with keys -
the groupByAge, and values - arrays with people in this groupByAge.
Use function overloading (i.e. just one function)

Example:

var people = [
  { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
  { firstname: 'Bay', lastname: 'Ivan', age: 81 },
  { firstname: 'John', lastname: 'Doe', age: 42 },
  { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
  { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
  { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];

var groupedByAge = group(people);
groupedByAge must be:
{
  '22': [
    { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
    { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
  ],
  '32': [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 }
  ],
  '42': [
    { firstname: 'John', lastname: 'Doe', age: 42 }
  ],
  '81': [
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'Asdf', lastname: 'Xyz', age: 81 }
  ]
}*/