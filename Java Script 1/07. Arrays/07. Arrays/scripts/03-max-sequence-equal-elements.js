function findMaxSeq(n) {
    var arr = n.split(' ');
    var maxSoFar = 1;
    var temp = 1;
    var elem = arr[0];
    for (var i = 1, len = arr.length; i < len; i++) {
        if (arr[i] == arr[i - 1]) {
            temp++;
        }
        else {
            if (temp > maxSoFar) {
                maxSoFar = temp;
                elem = arr[i - 1];
            }
            temp = 1;
        }

        if (i == len - 1) {
            if (temp > maxSoFar) {
                maxSoFar = temp;
                elem = arr[i - 1];
            }
        }
    }

    jsConsole.writeLine("The maximal sequence is: ");
    for (var i = 0; i < maxSoFar; i++) {
        jsConsole.write(elem + " ");
    }
}