function stringFormat() {
    //validation
    if (arguments.length < 1) {
        return undefined;
    }
    else if (arguments.length == 1) {
        return arguments[0].toString();
    }

    var str = arguments[0];
    var regex = new RegExp("{\\s*(\\d){1,2}\\s*}", "g");
    var placeholders = str.match(regex);

    //if placeholder index is greater than the number of arguments
    for (var i = 0; i < placeholders.length; i++) {
        if (placeholders[i][1] > arguments.length - 1) {
            return undefined;
        }
    }
    //if first placeholder index != 0
    if (placeholders[0][1] != 0) {
        return undefined;
    }

    var tempPlaceholder = regex.exec(str);

    while (tempPlaceholder) {
        //if the index of the placeholder is greater than the number of arguments available, return
        if (tempPlaceholder[1] > arguments.length - 1 || tempPlaceholder[1] < 0) {
            return undefined;
        }
        //new regex to extract all occurences of placeholders in str with the tempPlaceholder index
        var numberedRegex = new RegExp("{\\s*" + tempPlaceholder[1] + "\\s*}", "g");
        var numberedPlaceHolder = numberedRegex.exec(str);
        while (numberedPlaceHolder) {
            var argNum = parseInt(tempPlaceholder[1]) + 1;
            str = str.replace(numberedPlaceHolder[0], arguments[argNum]);
            numberedPlaceHolder = numberedRegex.exec(str);
        }
        tempPlaceholder = regex.exec(str);
    }
    return str;
}


//test
jsConsole.writeLine('INPUT: stringFormat("Hello {0} {1}!", "Peter", "Ivanov", "Dimitrov")');
jsConsole.writeLine("OUTPUT: " + stringFormat("Hello {0} {1}!", "Peter", "Ivanov", "Dimitrov"));
jsConsole.writeLine("");

jsConsole.writeLine('INPUT: stringFormat("Hello {0} {2}!", "Peter", "Ivanov", "Dimitrov")');
jsConsole.writeLine("OUTPUT: " + stringFormat("Hello {0} {2}!", "Peter", "Ivanov", "Dimitrov"));
jsConsole.writeLine("");

jsConsole.writeLine('INPUT: var format = "{0}, {1}, {0} text {2}"; var s = stringFormat(format, 1, "Pesho", "Gosho"); ');
var format = "{0}, {1}, {0} text {2}";
jsConsole.writeLine("OUTPUT: " + stringFormat(format, 1, "Pesho", "Gosho"));