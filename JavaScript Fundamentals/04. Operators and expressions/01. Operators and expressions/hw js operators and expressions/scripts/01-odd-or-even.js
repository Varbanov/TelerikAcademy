function checkOddEvenNum(num) {
    num = parseInt(num);
    if (num % 2 == 0) {
        jsConsole.writeLine("The number " + num + " is even");
    }
    else {
        jsConsole.writeLine("The number " + num + " is odd")
    }
}