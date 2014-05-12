function findMostFrequentElem(n) {
    var arr = n.split(' ');
    var dict = {};
    for (var i in arr) {
        if (dict[arr[i]]) {
            dict[arr[i]]++;
        }
        else {
            dict[arr[i]] = 1;
        }
    }
    var max = 1;
    var maxNum = arr[0];
    for (var i in dict) {
        if (dict[i] > max) {
            max = dict[i];
            maxNum = i;
        }
    }

    jsConsole.writeLine(maxNum + " (" + max + " times)");
}