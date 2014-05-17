function findMax(n) {
    n = n.split(' ');
    var min = parseInt(n[0]);
    var max = parseInt(n[0]);
    for (var i = 0; i < n.length; i++) {
        if (parseInt(n[i]) > max) {
            max = n[i];
        }
        if (parseInt(n[i]) < min) {
            min = n[i];
        }
    }
    jsConsole.writeLine("min: " + min);
    jsConsole.writeLine("max: " + max);

}