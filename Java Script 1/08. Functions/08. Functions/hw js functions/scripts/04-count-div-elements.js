function countDivs() {
    var divs = document.getElementsByTagName("div");
    jsConsole.writeLine("Number of divs in the document: " + divs.length);
}
countDivs();