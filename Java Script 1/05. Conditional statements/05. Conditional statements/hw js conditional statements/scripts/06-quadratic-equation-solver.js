function solveEquation(a, b, c) {
    a = parseFloat(a);
    b = parseFloat(b);
    c = parseFloat(c);
    var d = b * b - 4 * a * c;

    if (d > 0) {
        var x1 = (-b + Math.sqrt(d)) / 2 * a;
        var x2 = (-b - Math.sqrt(d)) / 2 * a;
        jsConsole.writeLine("Roots: " + x1.toString() + "; " + x2.toString());
    }
    else if (d == 0) {
        var x1 = (-b + Math.sqrt(d)) / 2 * a;
        jsConsole.writeLine("One double root: " + x1);
    }
    else {
        jsConsole.writeLine("No real roots");
    }
}