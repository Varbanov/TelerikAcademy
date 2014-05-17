//var args = [
//"def func sum[5, 3, 7, 2, 6, 3]",
//"def func2 [5, 3, 7, 2, 6, 3]",
//"def func3 min[func2]",
//"def func4 max[5, 3, 7, 2, 6, 3]",
//"def func5 avg[5, 3, 7, 2, 6, 3]",
//"def func6 sum[func2, func3, func4 ]",
//"sum[func6, func4]"]
//console.log(Solve(args));

function Solve(args) {
    var command;
    var name;
    var operation;
    var arr;
    var i;
    var j;
    var cmdNum;
    var variables = {};
    var resultOfOperation;

    for (cmdNum = 0; cmdNum < args.length - 1; cmdNum++) {
        command = args[cmdNum];
        command = command.trim();
        if (command.substr(0, 3) != "def") {
            continue;
        }

        command = command.slice("def".length).trim();
        name = extractName(command);
        command = command.slice(name.length).trim();
        if (command[0] == '[') {
            operation = "";
            command = command.slice(operation.length + 1).trim();
            command = command.slice(0, command.length - 1).trim();
            arr = readArray(command, variables);
            variables[name] = arr;
        } else {
            operation = readOperation(command);
            command = command.slice(operation.length + 1).trim();
            command = command.slice(0, command.length - 1).trim();
            arr = readArray(command, variables);

            if (operation == "sum") {
                resultOfOperation = findSum(arr);
                variables[name] = resultOfOperation;
            } else if (operation == "avg") {
                resultOfOperation = findAverage(arr);
                variables[name] = resultOfOperation;
            } else if (operation == "min") {
                resultOfOperation = findMin(arr);
                variables[name] = resultOfOperation;
            } else if (operation == "max") {
                resultOfOperation = findMax(arr);
                variables[name] = resultOfOperation;
            }
        }
    }

    //last line
    command = args[args.length - 1].trim();
    if (command[0] == "[") {
        command = command.substring(1, command.length - 1);
        resultOfOperation = variables[command];

    } else {
        operation = readOperation(command);
        command = command.slice(operation.length + 1).trim();
        command = command.slice(0, command.length - 1).trim();
        arr = readArray(command, variables);

        if (operation == "sum") {
            resultOfOperation = findSum(arr);
        } else if (operation == "avg") {
            resultOfOperation = findAverage(arr);
        } else if (operation == "min") {
            resultOfOperation = findMin(arr);
        } else if (operation == "max") {
            resultOfOperation = findMax(arr);
        }
    }

    ///end
    return resultOfOperation;

    function findSum(arr) {
        var sum = 0;
        find(arr);

        function find(arr) {
            for (var i = 0; i < arr.length; i++) {
                if (typeof (arr[i]) == "number") {
                    sum += arr[i];
                } else {
                    find(arr[i]);
                }
            }
        };

        return sum;
    }

    function findMin(arr) {
        var firstMinFound = false;
        var min;

        (function find(arr) {
            for (var i = 0; i < arr.length; i++) {
                if (typeof (arr[i]) == "number") {
                    if (!firstMinFound) {
                        min = arr[i];
                        firstMinFound = true;
                    }

                    if (arr[i] < min) {
                        min = arr[i];
                    }
                } else {
                    find(arr[i]);
                }
            }

        })(arr);

        return min;
    }

    function findMax(arr) {
        var firstMaxFound = false;
        var max;

        (function find(arr) {
            for (var i = 0; i < arr.length; i++) {
                if (typeof (arr[i]) == "number") {
                    if (!firstMaxFound) {
                        max = arr[i];
                        firstMaxFound = true;
                    }
                    if (arr[i] > max) {
                        max = arr[i];
                    }
                } else {
                    find(arr[i]);
                }
            }
        })(arr);

        return max;
    }

    function findAverage(arr) {
        var sum = findSum(arr);
        return parseInt(sum / arr.length);
    }



    function readArray(cmd, variables) {
        var arr = command.split(",");
        for (var j = 0; j < arr.length; j++) {
            arr[j] = arr[j].trim();
            var num = parseInt(arr[j]);
            if (!isNaN(num)) {
                arr[j] = num;
            } else {
                arr[j] = variables[arr[j]];
            }
        }

        return arr;
    }

    function readOperation(cmd) {
        var res = "";
        var i = 0;
        while (cmd[i] != '[') {
            res += cmd[i];
            i++;
        }

        return res;
    }

    function extractName(cmd) {
        var res = "";
        var i = 0;
        while (cmd[i] != '[' && cmd[i] != ' ') {
            res += cmd[i];
            i++;
        }

        return res;
    }
}