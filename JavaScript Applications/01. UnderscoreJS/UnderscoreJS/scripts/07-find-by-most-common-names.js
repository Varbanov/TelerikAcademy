/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />

//07. By an array of people find the most common first and last name. Use underscore: 

define(['data/students', 'underscore'], function (students, _) {
    var groupedByFirstName = _.chain(students.students)
        .groupBy(function (student) {
            return student.fname;
        })
        .max(function (item) {
            return item.length;
        })
        .value();


    var groupedByLastName = _.chain(students.students)
        .groupBy(function (student) {
            return student.lname;
        })
        .max(function (item) {
            return item.length;
        })
        .value();

    //fit the handlebars template
    var result = [];
    result.push({ fname: groupedByFirstName[0].fname });
    result.push({ fname: groupedByLastName[0].lname });

    return {
        students: result,
        task: '07. By an array of people find the most common first and last name. Use underscore: ',
    };
})