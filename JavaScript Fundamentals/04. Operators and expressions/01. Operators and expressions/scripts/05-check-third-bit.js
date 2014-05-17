function thirdBit(num) {
    num = parseInt(num);
    jsConsole.writeLine("The third bit of " + num + " is " + ((num >> 2) & 1));
}