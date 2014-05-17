function findBiggest(input1, input2, input3) {
    firstInt = parseFloat(input1);
    secondInt = parseFloat(input2);
    thirdInt = parseFloat(input3);
    if (firstInt > secondInt) {
        if (firstInt > thirdInt) {
            jsConsole.writeLine("The first int is the biggest.");
        }
        else {
            jsConsole.writeLine("The third is the biggest.");
        }
    }
    else if (secondInt > thirdInt) {
        jsConsole.writeLine("The second int is the biggest.");
    }
    else {
        jsConsole.writeLine("The third int is the biggest");
    }
}