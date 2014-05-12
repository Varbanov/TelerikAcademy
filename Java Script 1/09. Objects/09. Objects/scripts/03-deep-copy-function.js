
function clone(object) {
    if (typeof object != "object") {
        return object;
    }
    else if (object instanceof Array) {
        var copyObj = [];
        for (var i = 0; i < object.length; i++) {
            copyObj[i] = clone(object[i]);
        }
        return copyObj;
    }
    else {
        var copyObj = {};
        for (var prop in object) {
            if (object.hasOwnProperty(prop)) {
                copyObj[prop] = clone(object[prop]);
            }
        }
        return copyObj;
    }
}

//test
function printStudent(student) {
    jsConsole.writeLine("<strong>" + student.name + "</strong>");
    for (var i in marks) {
        jsConsole.writeLine("<strong>" + student.marks[i].subject + "</strong>" + " : " + student.marks[i].score);
    }
    jsConsole.writeLine("--------------------------");
}

var marks = [
    { subject: "JavaScript", score: 5.50 },
    { subject: "OOP", score: 5.00 }];

var m2 = clone(marks);

var student = { name: "Doncho Minkov", marks: m2};
printStudent(student);
marks[1].score = 5.50;
printStudent(student);
jsConsole.writeLine("The value of the OOP mark is changed to 5.50, but the copy being deep still holds the initial value of 5.00 :)");
