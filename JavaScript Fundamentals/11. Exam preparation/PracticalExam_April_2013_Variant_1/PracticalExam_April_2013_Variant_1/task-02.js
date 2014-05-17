//var args = [
//"6 7 3", 
//"0 0",
//"2 2",
//"-2 2",
//"3 -1"
//]

//console.log(solve(args));

//N - rows
//M - columns
//J - number of jumps
//args[1] - start position
//args[2] - args[j+2] - jumps

function solve(args) {
    var rowsNumber = parseInt(args[0].split(" ")[0]);
    var colsNumber = parseInt(args[0].split(" ")[1]);
    var jumpsNumber = parseInt(args[0].split(" ")[2]);
    var currentRow = parseInt(args[1].split(" ")[0]);
    var currentCol = parseInt(args[1].split(" ")[1]);

    var currentJump = 2;
    var numbersCounter;
    var commandRow;
    var commandCol;
    var result;

    //matrix
    var arr = fillMatrix(rowsNumber, colsNumber);
    numbersCounter = 0; //arr[currentRow][currentCol];

    //engine
    while (true) {
        if (returnEscaped(rowsNumber, colsNumber, currentRow, currentCol)) {
            result = "escaped " + numbersCounter;
            return result;
        }

        if (arr[currentRow][currentCol] == "visited") {
            result = "caught " + numbersCounter;
            return result;
        }

        if (currentJump == jumpsNumber + 2) {
            currentJump = 2;
        }

        numbersCounter += arr[currentRow][currentCol];
        arr[currentRow][currentCol] = "visited";

        commandRow = parseInt(args[currentJump].split(" ")[0]);
        commandCol = parseInt(args[currentJump].split(" ")[1]);
        currentRow += commandRow;
        currentCol += commandCol;
        currentJump++;
    }
  
    function returnEscaped(rows, cols, currentRow, currentCol) {
        var escaped = true;

        if (currentRow >= 0 && currentRow < rows && 
            currentCol >=0 && currentCol < cols) {
            escaped = false;
        }

        return escaped;
    }

    function fillMatrix(rows, cols) {
        var arr = [rows];
        var counter = 1;
        var i;
        var j;

        for (i = 0; i < rows; i++) {
            arr[i] = [cols];
            for (j = 0; j < cols; j++) {
                arr[i][j] = counter;
                counter++;
            }
        }

        return arr;
    }
}