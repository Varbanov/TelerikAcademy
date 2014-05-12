var text = "hehe asd@abv.bg afasf dd@haha.com. d ";
jsConsole.writeLine("Text: " + text);

function extractMails(input) {
    var regex = new RegExp("\\b\\w+@\\w+.\\w+\\b", "g");
    var matches = input.match(regex);

    return matches;
}

var mailsArr = extractMails(text);

//print result
jsConsole.writeLine("");
jsConsole.write("Mails: ");
for (var i = 0; i < mailsArr.length; i++) {
    jsConsole.write(mailsArr[i] + ", ");
}