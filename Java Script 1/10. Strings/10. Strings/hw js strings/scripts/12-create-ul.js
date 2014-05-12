function generateList(people, template) {
    var ul = document.createElement("ul");
    var regex = new RegExp('-{(\\w+?)}-');

    for (var i = 0; i < people.length; i++) {
        //for each person in people
        var li = document.createElement("li");
        var currentTemplate = template;
        var match = currentTemplate.match(regex);

        while (match != null) {
            //iterate over the current person's properties with names == those in the template
            //and update currentTemplate of the current li element
            var attributeName = match[1];
            currentTemplate = currentTemplate.replace(match[0], people[i][attributeName]);
            match = currentTemplate.match(regex);
        }
        li.innerHTML = currentTemplate;
        ul.appendChild(li);
    }
    return ul;
}

//test
var people = [
    { name: "Milena", age: "20" },
    { name: "Elena", age: "21" },
    { name: "Georgi", age: "22" },
    { name: "Ivan", age: "23" },
    { name: "Dimitar", age: "24" },
];

//var templateDiv = document.createElement("div");
//templateDiv.setAttribute("data-type", "template");
//templateDiv.setAttribute("id", "list-item");
//templateDiv.innerHTML = "<strong>-{name}-</strong> <span>-{age}-</span>";

var template = "<strong>-{name}-</strong> <span>-{age}-</span>";
var peopleList = generateList(people, template);

document.body.appendChild(peopleList);

