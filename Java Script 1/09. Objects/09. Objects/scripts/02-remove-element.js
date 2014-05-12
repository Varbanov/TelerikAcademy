if (!Array.prototype.removeElement) {
    Array.prototype.removeElement = function (arr, value) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] === value) {
                arr.splice(i, 1);
                i--;
            }
        }
    }
}

function onCheckBtnClick(arr, value) {
    arr.removeElement(arr, value); //here the already attached function removeElement() is called on an Array object
    jsConsole.writeLine(arr.join(", "));
}