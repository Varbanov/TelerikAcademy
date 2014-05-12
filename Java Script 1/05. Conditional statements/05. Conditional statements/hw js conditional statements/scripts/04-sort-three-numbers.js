function findBiggest(input1, input2, input3) {
    firstInt = parseFloat(input1);
    secondInt = parseFloat(input2);
    thirdInt = parseFloat(input3);
    var smallest;
    var middle;
    var biggest;
    if ((firstInt >= secondInt && firstInt < thirdInt) || (firstInt < secondInt && firstInt > thirdInt)) {
        middle = firstInt;
        if (firstInt >= secondInt) {
            biggest = thirdInt;
            smallest = secondInt;
        }
        else {
            biggest = secondInt;
            smallest = thirdInt;
        }
    }
    else if ((secondInt >= firstInt && secondInt < thirdInt) || (secondInt <= firstInt && secondInt > thirdInt)) {
        middle = secondInt;
        if (secondInt >= firstInt) {
            biggest = thirdInt;
            smallest = firstInt;
        }
        else {
            biggest = firstInt;
            smallest = thirdInt;
        }
    }
    else {
        middle = thirdInt;
        if (firstInt >= secondInt) {
            biggest = firstInt;
            smallest = secondInt;
        }
        else {
            biggest = secondInt;
            smallest = firstInt;
        }
    }
    jsConsole.writeLine(biggest + "; " + middle + "; " + smallest);
}