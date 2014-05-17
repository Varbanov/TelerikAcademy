var people = [
          { firstname: "Gosho", lastname: "Petrov", age: 32 },
          { firstname: "Ivan", lastname: "Ivanov", age: 20 },
          { firstname: "Pesho", lastname: "Georgiev", age: 57 },
          { firstname: "Stamat", lastname: "Petrov", age: 32 },
          { firstname: "Sevdalin", lastname: "Stamatov", age: 61 },
          { firstname: "Pesho", lastname: "Peshev", age: 17 },
]
var groupedByFname = group(people, "firstname");
var groupedByLname = group(people, "lastname");
var groupedByAge = group(people, "age");
jsConsole.writeLine("Please use F12 in your browser to insert a breakpoint on this line and inspect the three variables above it. :)")

function group(people, group) {
    var res = {}
    if (group == "firstname") {
        for (var i = 0; i < people.length; i++) {
            if (res[people[i].firstname]) {
                res[people[i].firstname][res[people[i].firstname].length] = people[i]; //add the new person to the bottom of the array (position = length)
            }
            else {
                res[people[i].firstname] = [people[i]]; // if the group does not exist, create it and add the new person
            }
        }
    }
    else if (group == "lastname") {
        for (var i = 0; i < people.length; i++) {
            if (res[people[i].lastname]) {
                res[people[i].lastname][res[people[i].lastname].length] = people[i]; //add the new person to the bottom of the array (position = length)
            }
            else {
                res[people[i].lastname] = [people[i]]; // if the group does not exist, create it and add the new person
            }
        }
    }
    else if (group == "age") {
        for (var i = 0; i < people.length; i++) {
            if (res[people[i].age]) {
                res[people[i].age][res[people[i].age].length] = people[i]; //add the new person to the bottom of the array (position = length)
            }
            else {
                res[people[i].age] = [people[i]]; // if the group does not exist, create it and add the new person
            }
        }
    }
    return res;
}