var first = new Array('a', 'c', 'c', 'd');
var second = new Array('a', 'b', 'c', 'd');

var minLength = first.length < second.length ? first.length : second.length;
var firstIsFirst = false;
var areEqualToMinLength = true;

for (var i = 0; i < minLength; i++) {
    if (first[i].toLowerCase() < second[i].toLowerCase()) {
        firstIsFirst = true;
        areEqualToMinLength = false;
        break;
    }
    else if (first[i].toLowerCase() > second[i].toLowerCase()) {
        areEqualToMinLength = false;
        break;
    }
}

if (areEqualToMinLength) {
    first.length < second.length ? firstIsFirst = true : firstIsFirst = false;
}

if (firstIsFirst) {
    jsConsole.writeLine("Lexicographically first is  : " + first.join(" "));
    jsConsole.writeLine("Lexicographically second is : " + second.join(" "));
}
else {
    jsConsole.writeLine("Lexicographically first is : " + second.join(" "));
    jsConsole.writeLine("Lexicographically second is  : " + first.join(" "));
}