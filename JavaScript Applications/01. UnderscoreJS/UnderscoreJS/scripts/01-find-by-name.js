/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//01. Write a method that from a given array of students finds all students whose first name is before its
//last name alphabetically. Print the students in descending order by full name. Use Underscore.js

define(['data/students', 'underscore'], function (students, _) {
    var result = _.chain(students.students)
        .filter(function (student) {
            return student.fname.toLocaleLowerCase() < student.lname.toLocaleLowerCase();
        })
        .sortBy(function (student) {
            return student.fname + student.lname;
        })
        .reverse()
        .value();

    return {
        students: result,
        task: "01. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js: ",
    };
})