function findMaxSeq(n) {
    var arr = n.split(' ');
    var maxSoFar = 1;
    var temp = 1;
    var firstElem = arr[0];
    for (var i = 1, len = arr.length; i < len; i++) {
        if (arr[i] > arr[i - 1]) {
            temp++;
            if (i == len - 1 && temp > maxSoFar) {
                maxSoFar = temp;
                firstElem = i - maxSoFar + 1;
            }
        }
        else {
            if (temp > maxSoFar) {
                maxSoFar = temp;
                firstElem = i - maxSoFar;
            }
            temp = 1;
        }
    }
    jsConsole.writeLine("The maximal sequence is: ");
    for (var i = 0; i < maxSoFar; i++) {
        jsConsole.write(arr[firstElem] + " ");
        firstElem++;
    }
}