function printNums(n) {
    for (var i = 1; i <= n; i++) {
        if (i % 21 != 0) {
            jsConsole.write(i + " ");
        }
    }
}