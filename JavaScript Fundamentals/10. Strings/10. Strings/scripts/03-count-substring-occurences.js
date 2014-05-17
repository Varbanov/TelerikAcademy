function onCheckBtnClick(text, substring) {
    jsConsole.writeLine(countOccurence(text, substring));
}

function countOccurence(text, substring) {
    var counter = 0;
    text = text.toLowerCase();
    var index = 0;
    var index = text.indexOf(substring, 0);
    while (index > -1) {
        counter++;
        index = text.indexOf(substring, index + 1);
    }
    return counter;
}