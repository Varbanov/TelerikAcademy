function onCheckBtnClick(text, word) {
    jsConsole.writeLine("Case insensitive: " + countWord(text, word));
    jsConsole.writeLine("Case sensitive: " + countWord(text, word, true));
}

function countWord(text, word, isCaseSensitive) {
    isCaseSensitive = isCaseSensitive || false;
    var counter = 0;

    if (isCaseSensitive == false) {
        word = new Array(" " + word.toLowerCase() + " ", " " + word.toLowerCase() + ".", " " + word.toLowerCase() + ",", " " + word.toLowerCase() + "!", " " + word.toLowerCase() + "?", " " + word.toLowerCase() + ";")
        text = " " + text.toLowerCase();
        for (var i = 0; i < word.length; i++) {
            var tempIndex = text.indexOf(word[i]);
            while (tempIndex >= 0) {
                counter++;
                tempIndex = text.indexOf(word[i], tempIndex + 1);
            }
        }
        return counter;
    }
    else {
        word = new Array(" " + word + " ", " " + word + ".", " " + word + ",", " " + word + "!", " " + word + "?", " " + word + ";")
        text = " " + text;
        for (var i = 0; i < word.length; i++) {
            var tempIndex = text.indexOf(word[i]);
            while (tempIndex >= 0) {
                counter++;
                tempIndex = text.indexOf(word[i], tempIndex + 1);
            }
        }
        return counter;
    }
}