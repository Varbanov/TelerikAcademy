function greatestOfFive(a, b, c, d, e) {
    a = parseInt(a);
    b = parseInt(b);
    c = parseInt(c);
    d = parseInt(d);
    e = parseInt(e);
    var greatest = a;
    if (b > greatest) {
        greatest = b;
    }
    if (c > greatest) {
        greatest = c;
    }
    if (d > greatest) {
        greatest = d;
    }
    if (e > greatest) {
        greatest = e;
    }
    jsConsole.writeLine("The greatest number is: " + greatest.toString());
}