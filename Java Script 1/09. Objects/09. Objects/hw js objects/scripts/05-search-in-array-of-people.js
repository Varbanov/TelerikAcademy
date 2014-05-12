var people = [
           { firstname: "Gosho", lastname: "Petrov", age: 32 },
           { firstname: "Ivan", lastname: "Petrov", age: 20 },
           { firstname: "Pesho", lastname: "Petrov", age: 57 },
           { firstname: "Stamat", lastname: "Petrov", age: 43 },
           { firstname: "Sevdalin", lastname: "Petrov", age: 61 },
]
var youngest = findYoungestPerson(people);
jsConsole.writeLine(youngest.firstname + " " + youngest.lastname + ", age: " + youngest.age);

function findYoungestPerson(people) {
    var minAge = 2000;
    var youngestIndex = -1;
    for (var i = 0; i < people.length; i++) {
        if (people[i].hasOwnProperty("age") && people[i].age < minAge) {
            minAge = people[i].age;
            youngestIndex = i;
        }
    }
    return people[youngestIndex];
}