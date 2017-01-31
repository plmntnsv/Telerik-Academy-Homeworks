/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework 
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults @@
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
      let presentationArr;
      let studentsArr;
  var Course = {
    init: function (title, presentations) {
      presentationArr = [];
      studentsArr = [];
      // /(^\s)|(\s$)|(\s{2,})/ - catches spaces in the beginning of the string, at the end of it and all spaces two or more next to each other
      let notLegitTitle = /(^\s)|(\s$)|(\s{2,})/.test(title) || title === "",
        notLegitPresentationTitle = presentations.some(t => (/(^\s)|(\s$)|(\s{2,})/.test(t) || t === "")) || presentations.length === 0;
      if (notLegitTitle || notLegitPresentationTitle) {
        throw `Invalid white space before or after title, too many white spaces next to each other, 
              title too short, empty title or empty presentations array error.`;
      }
      presentations.forEach(p => presentationArr.push(p));
      return this;
    },
    addStudent: function (name) {
      let names = name.split(" "),
          legitName = names.every(n => /^[A-Z][a-z]*\b/.test(n)) && names.length === 2;
          if (!legitName) {
            throw "First and last names must start with capital letter and to be followed by only 0 ot many lower case letters.";
          }
      let studentId = studentsArr.length + 1;
      studentsArr.push({firstname: names[0], lastname: names[1], id: studentId});
      return studentId;
    },
    getAllStudents: function () {
      return studentsArr;
    },
    submitHomework: function (studentID, homeworkID) {
      if (studentID < 1 || studentID % 1 !== 0 || !studentsArr.some(s => s.id === studentID)) {
        throw "Invalid student ID. ID must be a positive integer, a whole number and must exist.";
      }
      if (homeworkID < 1 || homeworkID % 1 !== 0 || presentationArr.length < homeworkID) {
        throw "Invalid homework ID. ID must be a positive integer, a whole number and must exist.";
      }
    },
    pushExamResults: function (results) {
      if (results === undefined || results.constructor !== Array) {
        throw "No argument given or the argument is not an array";
      }
      if (results.some(s => s.score === undefined || isNaN(s.score))) {
        throw "Missing scores or score is not a number.";
      }

      for (let i = 0; i < results.length; i+=1) {
        if (results[i].StudentID < 1 || !studentsArr.some(s => s.id === results[i].StudentID)) {
          throw "Student with invalid ID detected.";
        }
        for (let j = 0; j < results.length; j+=1) {
          if (i === j) {
            continue;
          }
          if (results[i].StudentID === results[j].StudentID) {
            throw "Same student detected.";
          }
        }
      }
      
    },
    getTopStudents: function () {}
  };
  studentsArr = [];
  return Course;
}
// var jsoop = solve()
//             .init("Modules and Patterns", ["Modules and Patterns"]);
//           console.log(jsoop.getAllStudents());
// id = jsoop.addStudent('Valid Name');
// jsoop.submitHomework(1, 2);


module.exports = solve;