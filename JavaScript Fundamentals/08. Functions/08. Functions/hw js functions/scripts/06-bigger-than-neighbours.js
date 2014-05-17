function onCheckBtnClick(inputArr, index) {
    var arr = inputArr.split(' ');
    checkNeighbours(arr, index);
}

function checkNeighbours(arr, index) {
    index = parseInt(index);
    if (arr[index - 1] && arr[index + 1]) {
        if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
            jsConsole.writeLine("The element at position " + index + " is bigger than its neighbours");
        }
        else {
            jsConsole.writeLine("The element at position " + index + " is NOT bigger than its neighbours");
        }
    }
    else {
        jsConsole.writeLine("The element at position " + index + " does not have two neighbours")
    }
}