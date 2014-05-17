var text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
function extractHtml(input) {
    var regex = new RegExp("<.+?>");
    var res = "";
    var match = input.match(regex);
    while (match != null) {
        //while matches are found, delete them
        input = input.replace(regex, "");
        match = input.match(regex);
    }

    jsConsole.write(input);
}

extractHtml(text);