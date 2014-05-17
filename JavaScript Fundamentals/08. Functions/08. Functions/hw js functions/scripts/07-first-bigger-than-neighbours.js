function onCheckBtnClick(inputArr, index) {
    var arr = inputArr.split(' ');
    jsConsole.writeLine(checkNeighbours(arr));
}

function checkNeighbours(arr) {
    index = parseInt(index);
    for (var index = 0; index < arr.length; index++) {
        if (arr[index - 1] && arr[index + 1]) {
            if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
                return index;
            }
        }
    }
    return -1;
}