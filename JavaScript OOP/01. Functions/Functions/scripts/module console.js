var specialConsole = (function () {

    function writeLine() {
        var args = arguments;
        var message = processInputMesssage(args);
        console.log(message);
    }

    function writeError() {
        var args = arguments;
        var message = processInputMesssage(args);
        console.error(message);
    }

    function writeWarning() {
        var args = arguments;
        var message = processInputMesssage(args);
        console.warn(message);
    }

    function processInputMesssage(args) {
        //validation
        if (args.length < 1) {
            return undefined;
        }
        else if (args.length == 1) {
            return args[0];
        }

        var str = args[0];
        var regex = new RegExp("{\\s*(\\d){1,2}\\s*}", "g");
        var placeholders = str.match(regex);

        //validation
        //if placeholder index is greater than the number of args
        for (var i = 0; i < placeholders.length; i++) {
            if (placeholders[i][1] > args.length - 1) {
                return undefined;
            }
        }
        //if first placeholder index != 0
        if (placeholders[0][1] != 0) {
            return undefined;
        }

        var tempPlaceholder = regex.exec(str);

        while (tempPlaceholder) {
            //if the index of the placeholder is greater than the number of args available, return
            if (tempPlaceholder[1] > args.length - 1 || tempPlaceholder[1] < 0) {
                return undefined;
            }
            //new regex to extract all occurences of placeholders in str with the tempPlaceholder index
            //e.g. if we have "Message {0}, {0}, {0}", "Ivan,"Ivanov", "Petrov" -->"Message: Ivan, Ivan, Ivan"
            var numberedRegex = new RegExp("{\\s*" + tempPlaceholder[1] + "\\s*}", "g");
            var numberedPlaceHolder = numberedRegex.exec(str);
            while (numberedPlaceHolder) {
                var argNum = parseInt(tempPlaceholder[1]) + 1;
                str = str.replace(numberedPlaceHolder[0], args[argNum].toString());
                numberedPlaceHolder = numberedRegex.exec(str);
            }
            tempPlaceholder = regex.exec(str);
        }

        return str;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning,
    }
})();

//test
specialConsole.writeLine("I am a test print");
specialConsole.writeError("Hello {0} {1}!", "Peter", "Ivanov", "Dimitrov");
specialConsole.writeLine("---");

specialConsole.writeWarning("Hello {0} {2} {1}!", "Peter", "Ivanov", "Dimitrov");
specialConsole.writeLine("---");

var format = "{0}, {1}, {0} text {2}";
specialConsole.writeLine(format, 1, "Pesho", "Gosho");