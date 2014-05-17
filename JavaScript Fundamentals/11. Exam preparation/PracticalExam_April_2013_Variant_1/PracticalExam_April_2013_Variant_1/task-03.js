//var args = [
//"(def func   10)                                ",
//"(def newFunc (+  func 2))                      ",
//"(def sumFunc (+ func func newFunc 0 0 0))      ",
//"(* sumFunc 2)                                  ",
//]

////var args = [
////"(def func (+ 5 2))             ",
////"(def func2 (/  func 5 2 1 0))  ",
////"(def func3 (/ func 2))         ",
////"(+ func3 func)                 ",
////]

//console.log(solve(args));


function solve(args) {
    var i;
    var j;
    var commandLine;
    var name;
    var variables = {};
    var currentValue;
    var operation;
    var arr;
    var currentResult;

    for (i = 0; i < args.length - 1; i++) {

        //get rid of multiple whitespaces
        commandLine = args[i].trim();
        while (commandLine.indexOf("  ") >= 0) {
            commandLine = commandLine.replace("  ", " ");
        }

        //make commandLine start with the name of the function
        commandLine = commandLine.substring(1, commandLine.length - 1).trim();
        commandLine = commandLine.substring("def".length).trim();

        //extract name and exclude it from commandLine
        name = extractName(commandLine);
        commandLine = commandLine.substring(name.length).trim();

        if (commandLine[0] != '(') {
            //if there is no operation to be executed, take the value as it is
            currentValue = parseInt(commandLine);
            if (isNaN(currentValue)) {
                //if value is a variable instead
                currentValue = variables[commandLine];
            }

            variables[name] = currentValue;
        } else {
            //if there is an operation
            commandLine = commandLine.substring(1, commandLine.length - 1).trim();
            operation = commandLine[0];
            commandLine = commandLine.substring(1).trim();
            arr = parseArray(commandLine, variables);

            if (operation == '+') {
                currentResult = sumArray(arr);
            } else if (operation == '-') {
                currentResult = substractArray(arr);
            } else if (operation == '*') {
                currentResult = multiplyArray(arr);
            } else if (operation == '/') {
                if (checkArrayDivision(arr)) {
                    currentResult = divideArray(arr);
                } else {
                    currentResult = "Division by zero! At Line:" + (i + 1);
                    return currentResult;
                }
            }

            variables[name] = currentResult;
        }
    }

    //process last line
    commandLine = args[args.length - 1].trim();
    while (commandLine.indexOf("  ") >= 0) {
        commandLine = commandLine.replace("  ", " ");
    }

    commandLine = commandLine.substring(1, commandLine.length - 1).trim();
    operation = commandLine[0];
    commandLine = commandLine.substring(1).trim();
    arr = parseArray(commandLine, variables);

    if (operation == '+') {
        currentResult = sumArray(arr);
    }
    else if (operation == '-') {
        currentResult = substractArray(arr);
    }
    else if (operation == '*') {
        currentResult = multiplyArray(arr);
    }
    else if (operation == '/') {
        if (checkArrayDivision(arr)) {
            currentResult = divideArray(arr);
        }
        else {
            currentResult = "Division by zero! At Line:" + (i + 1);
            return currentResult;
        }
    }

    return currentResult;


    function sumArray(arr) {
        var sum = 0;
        for (var i = 0; i < arr.length; i++) {
            sum += arr[i];
        }

        return sum;
    }

    function substractArray(arr) {
        var result = arr[0];
        for (var i = 1; i < arr.length; i++) {
            result -= arr[i];
        }

        return result;
    }

    function multiplyArray(arr) {
        var result = 1;
        for (var i = 0; i < arr.length; i++) {
            result *= arr[i];
        }

        return result;
    }

    function divideArray(arr) {
        var result = arr[0];
        for (var i = 1; i < arr.length; i++) {
            result = parseInt(result / arr[i]);
        }

        return parseInt(result);
    }

    function checkArrayDivision(arr) {
        for (var i = 1; i < arr.length; i++) {
            if (arr[i] == 0) {
                return false;
            }
        }

        return true;
    }

    function parseArray(cmd, variables) {
        var arr = cmd.split(" ");
        for (var i = 0; i < arr.length; i++) {

            var num = parseInt(arr[i].trim());
            if (isNaN(num)) {
                arr[i] = variables[arr[i]];
            }
            else {
                arr[i] = num;
            }
        }

        return arr;
    }

    function extractName(cmd) {
        var name = "";
        var i = 0;
        while (cmd[i] != ' ') {
            name += cmd[i];
            i++;
        }
        return name;
    }
}