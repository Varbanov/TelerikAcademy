function isThirdDigitSeven(num) {
    num = parseInt(num);
    parseInt(num / 100) % 10 == 7 ? jsConsole.writeLine("The third digit is 7") : jsConsole.writeLine("The third digit is not 7");
}