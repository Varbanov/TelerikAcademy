var minDoc = "";
var maxDoc = "";
var minWin = "";
var maxWin = "";
var minNav = "";
var maxNav = "";

//document
for (var property in document) {
    if (minDoc == "" || property.localeCompare(minDoc) < 0) {
        minDoc = property;
    }
    if (maxDoc == "" || property.localeCompare(maxDoc) > 0) {
        maxDoc = property;
    }
}

//window
for (var property in window) {
    if (minWin == "" || property.localeCompare(minWin) < 0) {
        minWin = property;
    }
    if (maxWin == "" || property.localeCompare(maxWin) > 0) {
        maxWin = property;
    }
}

//navigator
for (var property in navigator) {
    if (minNav == "" || property.localeCompare(minNav) < 0) {
        minNav = property;
    }
    if (maxNav == "" || property.localeCompare(maxNav) > 0) {
        maxNav = property;
    }
}

jsConsole.writeLine("Document:");
jsConsole.writeLine("smallest: " + minDoc);
jsConsole.writeLine("largest: " + maxDoc);
jsConsole.writeLine("Window:");
jsConsole.writeLine("smallest " + minWin);
jsConsole.writeLine("largest " + maxWin);
jsConsole.writeLine("Navigator:");
jsConsole.writeLine("smallest " + minNav);
jsConsole.writeLine("largest " + maxNav);