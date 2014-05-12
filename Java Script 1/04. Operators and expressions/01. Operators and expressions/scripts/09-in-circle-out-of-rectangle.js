function inCircleAndRectangle(x, y) {
    x = parseFloat(x);
    y = parseFloat(y);
    var inCircle = true;
    var inRectangle = true;
    if (x < -1 || x > 5 || y < -1 || y > 1) {
        inRectangle = false;
    }
    var distToCenter = Math.sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1));
    if (distToCenter > 3) {
        inCircle = false;
    }
    jsConsole.writeLine("In the circle - " + inCircle + ", in the rectangle: " + inRectangle);
}