function findBinary(arr, num) {
    arr = arr.split(' ');
    var index = binarySearch(arr, num, 0, arr.length - 1);
    jsConsole.writeLine(index);
}

function binarySearch(arr, num, start, end) {
    if (end < start) {
        return -1;
    }
    else {
        var middle = start + (parseInt((end - start) / 2));
        if (arr[middle] > num) {
            return binarySearch(arr, num, start, middle - 1);
        }
        else if (arr[middle] < num) {
            return binarySearch(arr, num, middle + 1, end);
        }
        else {
            return middle;
        }
    }
}