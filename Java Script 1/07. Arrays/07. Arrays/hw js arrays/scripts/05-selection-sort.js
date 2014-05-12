function selectionSort(n) {
    var arr = n.split(' ');
    for (var i = 0, len = arr.length; i < len; i++) {
        var min = arr[i];
        var minIndex = i;
        for (var j = i + 1; j < len; j++) {
            if (parseInt(arr[j]) < min) {
                min = arr[j];
                minIndex = j;
            }
        }
        if (min != arr[i]) {
            var temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
    jsConsole.writeLine(arr.join(" "));
}