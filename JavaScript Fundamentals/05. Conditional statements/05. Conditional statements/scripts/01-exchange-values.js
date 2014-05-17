function checkIntegers(a, b) {
    jsConsole.writeLine("first int: " + a + ", second int: " + b);
    if (a > b) {
        var c = a;
        a = b;
        b = c;
    }
    jsConsole.writeLine("Result: first int: " + a + ", second int: " + b);
}