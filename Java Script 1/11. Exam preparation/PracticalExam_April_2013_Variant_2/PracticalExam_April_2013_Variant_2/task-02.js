
//var args = [
// "3 4",
// "1 3",
// "lrrd",
// "dlll",
// "rddd"];

//var args = [
// "5 8",
// "0 0",
// "rrrrrrrd",
// "rludulrd",
// "durlddud",
// "urrrldud",
// "ulllllll"]

//var args = [
// "5 8",
// "0 0",
// "rrrrrrrd",
// "rludulrd",
// "lurlddud",
// "urrrldud",
// "ulllllll"]


//console.log(solve(args));


function solve(args) {
    //cols
    var m = parseInt(args[0].split(" ")[0]);
    //rows
    var n = parseInt(args[0].split(" ")[1]);
    var startRow = parseInt(args[1].split(" ")[0]);
    var startCol = parseInt(args[1].split(" ")[1]);

    var arr = [m];
    var directions = [m];
    var counter = 1;
    for (var i = 0; i < m; i++) {
        arr[i] = [n];
        directions[i] = [n];
        for (var j = 0; j < n; j++) {
            arr[i][j] = counter;
            counter++;
            directions[i][j] = args[i + 2][j];
        }
    }

    var stepsCounter = 1;
    var points = arr[startRow][startCol];
    arr[startRow][startCol] = "visited";

    while (true) {
        var currentChar = directions[startRow][startCol];

        if (currentChar == 'l') {
            startCol--;
            if (startCol < 0) {
                var result = "out " + points;
                return result;
            }
        }
        else if (currentChar == 'r') {
            startCol++;
            if (startCol >= n) {
                var result = "out " + points;
                return result;
            }
        }
        else if (currentChar == 'u') {
            startRow--;
            if (startRow < 0) {
                var result = "out " + points;
                return result;
            }
        }
        else if (currentChar == 'd') {
            startRow++;
            if (startRow >= m) {
                var result = "out " + points;
                return result;
            }
        }

        if (arr[startRow][startCol] === "visited") {
            var result = "lost " + stepsCounter;
            return result;
        }
        else {
            points += arr[startRow][startCol];
            stepsCounter++;
            arr[startRow][startCol] = "visited";
        }
    }
}
