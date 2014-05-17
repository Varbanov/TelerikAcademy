function onDistBtnClick(point1, point2) {
    var dist = calcDistance(point1, point2);
    jsConsole.writeLine("Distance: " + dist);
}

function calcDistance(point1, point2) {
    var pointX = {
        x: parseFloat(point1.split(" ")[0]),
        y: parseFloat(point1.split(" ")[1]),
    }

    var pointY = {
        x: parseFloat(point2.split(" ")[0]),
        y: parseFloat(point2.split(" ")[1]),
    }
    var distance = Math.sqrt((pointX.x - pointY.x) * (pointX.x - pointY.x) + (pointX.y - pointY.y) * (pointX.y - pointY.y));
    return distance;
}

function onTriangleBtnClick(line1, line2, line3) {
    var lineStart = line1.split(" ")[0] + " " + line1.split(" ")[1];
    var lineEnd = line1.split(" ")[2] + " " + line1.split(" ")[3];
    line1 = calcDistance(lineStart, lineEnd);

    lineStart = line2.split(" ")[0] + " " + line2.split(" ")[1];
    lineEnd = line2.split(" ")[2] + " " + line2.split(" ")[3];
    line2 = calcDistance(lineStart, lineEnd);

    lineStart = line3.split(" ")[0] + " " + line3.split(" ")[1];
    lineEnd = line3.split(" ")[2] + " " + line3.split(" ")[3];
    line3 = calcDistance(lineStart, lineEnd);
    if (line1 < line2 + line3 && line2 < line1 + line3 && line3 < line1 + line2) {
        jsConsole.writeLine("The segment lines can form a triangle.");
    }
    else {
        jsConsole.writeLine("The segment lines cannot form a triangle.");

    }
}