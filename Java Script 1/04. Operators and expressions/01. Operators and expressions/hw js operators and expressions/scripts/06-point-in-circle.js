function pointInCircle05(x, y) {
    x = parseFloat(x);
    y = parseFloat(y);
    var distance = Math.sqrt(x * x + y * y);
    distance <= 5 ? jsConsole.writeLine("The point (" + x + "," + y + ") is within the circle (0,5)") : jsConsole.writeLine("The point (" + x + "," + y + ") is outside the circle (0,5)");
}