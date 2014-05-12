function showSign(firstInt, secondInt, thirdInt) {
    if (firstInt == 0 || secondInt == 0 || thirdInt == 0) {
        jsConsole.writeLine("The product of the numbers is 0");
    }
    else {
        if (firstInt > 0) {
            if (secondInt > 0 && thirdInt < 0 || secondInt < 0 && thirdInt > 0) {
                jsConsole.writeLine('The sign is "-"');
            }
            else {
                jsConsole.writeLine('The sign is "+"');
            }
        }
        else {
            if ((secondInt > 0 && thirdInt < 0) || (secondInt < 0 && thirdInt > 0)) {
                jsConsole.writeLine('The sign is "+"');
            }
            else {
                jsConsole.writeLine('The sign is "-"');
            }
        }
    }
}