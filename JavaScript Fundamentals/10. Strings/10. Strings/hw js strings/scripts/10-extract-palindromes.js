﻿var text = "elena abba ivan exe? bulgaria lamal ";

function extractPalindromes(input) {
    var regex = new RegExp("\\b\\w+?\\b", "g");
    var word;
    var res = [];

    //extract words one by one using regex
    while (word = regex.exec(input)) {
        word = word.toString();
        var reversed = "";
        for (var i = word.length - 1; i >= 0; i--) {
            reversed += word[i];
        }

        //if current word is a palindrome, add it to the result
        if (reversed == word) {
            res.push(word);
        }
    }
    return res;
}

var palindromes = extractPalindromes(text);

//print result
jsConsole.writeLine("Text: " + text);
jsConsole.write("Palindromes: ");
for (var i = 0; i < palindromes.length; i++) {
    jsConsole.write(palindromes[i] + ", ");
}