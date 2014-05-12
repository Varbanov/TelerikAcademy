function reverseDigits(n) {
    var reversed = "";
    var isNegative = false;
    for (var i = n.length - 1; i >= 0; i--) {
        if (n[i] != "-") {
            reversed += n[i];
        }
        else {
            isNegative = true;
        }
    }
    if (!isNegative) {
        jsConsole.writeLine(reversed);
    }
    else {
        reversed = "-" + reversed;
        jsConsole.writeLine(reversed);
    }
}