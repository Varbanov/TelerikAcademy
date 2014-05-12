function onCheckBtnClick(input) {
    checkBrackets(input) ? jsConsole.writeLine("Correct!") : jsConsole.writeLine("Incorrect!");
}

function checkBrackets(input) {
    var leftCount = 0;
    for (var i = 0; i < input.length; i++) {
        if (input[i] == "(") {
            leftCount++;
        }
        else if (input[i] == ")") {
            leftCount--;
        }
        if (leftCount < 0) {
            return false;
        }
    }
    if (leftCount != 0) {
        //if there is an opening bracket that is not closed
        return false;
    }
    return true;
}