function calcTrapezoidArea(a, b, h) {
    a = parseFloat(a);
    b = parseFloat(b);
    h = parseFloat(h);
    var area = ((a + b) / 2) * h;
    jsConsole.writeLine("The trapezoid's area is " + area);
}