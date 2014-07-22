/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js3

define(['data/students', 'underscore'], function (students, _) {
    var result = _.chain(students.students)
        .filter(function (student) {
            return student.age >= 18 && student.age <= 24;
        })
        .value();

    return {
        students: result,
        task: '02. Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js:',
    };
})