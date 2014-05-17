function primeChecker(num) {
    num = parseInt(num);
    if (num == 1 || num == 0) {
        jsConsole.writeLine("The number " + num + " is neither prime, nor composite");
        return;
    }
    var maxBound = Math.sqrt(num);
    var divisors = 0;
    for (var i = 1; i <= maxBound; i++) {
        if (num % i == 0) {
            divisors++;
        }
    }
    if (divisors != 1) {
        jsConsole.writeLine("The number " + num + " is not prime");
    }
    else {
        jsConsole.writeLine("The number " + num + " is prime");
    }
}