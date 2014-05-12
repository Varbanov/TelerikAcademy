function checkIfDivisible(num) {
    num = parseInt(num);
    if (num % 35 == 0) {
        jsConsole.writeLine("The number " + num + " can be divided by 5 and 7");
    }
    else {
        jsConsole.writeLine("The number " + num + " cannot be divided by 5 and 7")
    }
}