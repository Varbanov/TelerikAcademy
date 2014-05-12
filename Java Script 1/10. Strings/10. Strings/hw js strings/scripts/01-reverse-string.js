function onCheckBtnClick(input) {
    jsConsole.writeLine(reverseString(input));
}

function reverseString(input) {
    var res = "";
    for (var i = input.length - 1; i >= 0; i--) {
        res += input[i];
    }
    return res;
}