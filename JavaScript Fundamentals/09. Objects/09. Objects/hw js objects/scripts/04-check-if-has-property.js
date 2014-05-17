var student = { name: "Pesho", company: "Telerik" };
var hasPropStudent = hasProperty(student, "name");
jsConsole.writeLine("The student has property 'name': " + hasPropStudent);

var car = { brand: "Toyota", year: 2009 };
var hasPropCar = hasProperty(car, "name");
jsConsole.writeLine("The car has property 'name': " + hasPropCar);

function hasProperty(obj, prop) {
    var res = obj.hasOwnProperty(prop) ? true : false;
    return res;
}