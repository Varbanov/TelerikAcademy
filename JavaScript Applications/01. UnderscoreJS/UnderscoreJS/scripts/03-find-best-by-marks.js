/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//03. Write a function that by a given array of students finds the student with highest marks

define(['data/students', 'underscore'], function (students, _) {
    var maxStudentMark = _.chain(students.students)
        .max(function (student) {
            return student.mark;
        })
        .value();

    var result = _.chain(students.students)
        .filter(function (student) {
            return student.mark === maxStudentMark.mark;
        }).sortBy(function (student) {
            return student.fname + student.lname;
        })
        .value();

    return {
        students: result,
        task: '03. Write a function that by a given array of students finds the student with highest marks: ',
    };
})