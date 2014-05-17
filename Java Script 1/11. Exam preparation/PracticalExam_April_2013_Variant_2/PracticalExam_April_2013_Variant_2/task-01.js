//var input = [8, 1, 6, -9, 4, 4, -2, 10, -1];
//var input = [6, 1, 3, -5, 8, 7, -6];
//var input = [9,-9,-8,-8,-7,-6,-5,-1,-7,-6];

//console.log(solve(input));


function solve(args) {
    var n = parseInt(args[0]);
    var arr = [n];
    for (var i = 0; i < n; i++) {
        arr[i] = parseInt(args[i + 1]);
    }

    var maxSum = arr[0];


    for (var start = 0; start < n; start++) {
        var tempSum = 0;
        for (var end = start; end < n; end++) {
            tempSum += arr[end];
            if (tempSum > maxSum) {
                maxSum = tempSum;
            }
        }
    }

    return maxSum;
}