function onCheckBtnClick(arr, num) {
    var input = arr.split(' ');
    jsConsole.writeLine(countOccurence(input, num));
    testOnCheckBtnClickFunc();

}

function countOccurence(arr, num) {
    var counter = 0;

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == num) {
            counter++;
        }
    }
    return counter;
}

function testOnCheckBtnClickFunc() {
    var testArr = new Array(1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6);
    for (var i = 1; i <= 6; i++) {
        console.assert(countOccurence(testArr, i) == 3, "countOccurence() incorrect");
    }
}