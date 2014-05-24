////args = [
////'3 5',
////'54561',
////'43328',
////'52388',
////];

//args = [
//'3 5',
//'54361',
//'43326',
//'52188',
//];



//console.log(solve(args));

function solve(args) {
    var rows = parseInt(args[0].split(" ")[0]);
    var cols = parseInt(args[0].split(" ")[1]);
    var moves = fillMoves(rows, cols);
    var arr = fillArray(rows, cols);
    var result;

    var currentRow = rows - 1;
    var currentCol = cols - 1;

    var points = 0;
    var jumps = 0;




    while (true) {
        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            result = "Go go Horsy! Collected " + points + " weeds";
            return result;
        }

        if (arr[currentRow][currentCol] == "visited") {
            result = "Sadly the horse is doomed in " + jumps + " jumps";
            return result;
        }

        points += arr[currentRow][currentCol];
        arr[currentRow][currentCol] = "visited";
        jumps++;
        

        //moves 
        if (moves[currentRow][currentCol] == 1) {
            currentRow -= 2;
            currentCol += 1;
        }
        else if (moves[currentRow][currentCol] == 2) {
            currentRow -= 1;
            currentCol += 2;
        }
        else if (moves[currentRow][currentCol] == 3) {
            currentRow += 1;
            currentCol += 2;
        }
        else if (moves[currentRow][currentCol] == 4) {
            currentRow += 2;
            currentCol += 1;
        }
        else if (moves[currentRow][currentCol] == 5) {
            currentRow += 2;
            currentCol -= 1;
        }
        else if (moves[currentRow][currentCol] == 6) {
            currentRow += 1;
            currentCol -= 2;
        }
        else if (moves[currentRow][currentCol] == 7) {
            currentRow -= 1;
            currentCol -= 2;
        }
        else if (moves[currentRow][currentCol] == 8) {
            currentRow -= 2;
            currentCol -= 1;
        }





    }






    var p = 5;


    function fillArray(rows, cols) {
        var arr = [rows];
        var counter;
        var i;
        var j;

        for (i = 0; i < rows; i++) {
            arr[i] = [cols];

            counter = Math.pow(2, i);


            for (j = 0; j < cols; j++) {

                arr[i][j] = counter;
                counter--;
            }
        }

        return arr;
    }

    function fillMoves(rows, cols) {
        var arr = [rows];
        var i;
        var j;

        for (i = 0; i < rows; i++) {
            arr[i] = [cols];

            for (j = 0; j < cols; j++) {

                arr[i][j] = parseInt(args[i + 1][j]);
            }
        }

        return arr;
    }



}