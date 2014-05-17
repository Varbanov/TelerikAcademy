function onCheckBtnClick(input) {
    jsConsole.writeLine(replaceWhitespace(input));
}

function replaceWhitespace(text) {
    while (text.indexOf(" ") > -1) {
        text = text.replace(" ", "$nbsp;");
    }
    return text;
}