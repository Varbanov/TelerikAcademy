function spellNum(num) {
    num = parseInt(num);
    if (num == 0) {
        jsConsole.writeLine("zero");
        return;
    }
    if (num >= 100) {
        switch (parseInt(num / 100)) {
            case 1: jsConsole.write("one hundred ");
                break;
            case 2: jsConsole.write("two hundred ");
                break;
            case 3: jsConsole.write("three hundred ");
                break;
            case 4: jsConsole.write("four hundred ");
                break;
            case 5: jsConsole.write("five hundred ");
                break;
            case 6: jsConsole.write("six hundred ");
                break;
            case 7: jsConsole.write("seven hundred ");
                break;
            case 8: jsConsole.write("eight hundred ");
                break;
            case 9: jsConsole.write("nine hundred ");
                break;
        }
    }
    if (parseInt(num % 100) >= 20) {
        switch (parseInt(parseInt(num % 100) / 10)) {
            case 2: jsConsole.write("twenty ");
                break;
            case 3: jsConsole.write("thirty ");
                break;
            case 4: jsConsole.write("fourty ");
                break;
            case 5: jsConsole.write("fifty ");
                break;
            case 6: jsConsole.write("sixty ");
                break;
            case 7: jsConsole.write("seventy ");
                break;
            case 8: jsConsole.write("eighty ");
                break;
            case 9: jsConsole.write("ninety ");
                break;
        }
        switch (parseInt(num % 10)) {
            case 1: jsConsole.write("one");
                break;
            case 2: jsConsole.write("two");
                break;
            case 3: jsConsole.write("three");
                break;
            case 4: jsConsole.write("four");
                break;
            case 5: jsConsole.write("five");
                break;
            case 6: jsConsole.write("six");
                break;
            case 7: jsConsole.write("seven");
                break;
            case 8: jsConsole.write("eight");
                break;
            case 9: jsConsole.write("nine");
                break;
        }
    }
    else if (parseInt(num % 100) >= 10) {
        switch (parseInt(num % 100)) {
            case 10: jsConsole.writeLine("ten");
                break;
            case 11: jsConsole.writeLine("eleven");
                break;
            case 12: jsConsole.writeLine("twelve");
                break;
            case 13: jsConsole.writeLine("thirteen");
                break;
            case 14: jsConsole.writeLine("fourteen");
                break;
            case 15: jsConsole.writeLine("fifteen");
                break;
            case 16: jsConsole.writeLine("sixteen");
                break;
            case 17: jsConsole.writeLine("seventeen");
                break;
            case 18: jsConsole.writeLine("eighteen");
                break;
            case 19: jsConsole.writeLine("nineteen");
                break;
        }
    }
    else {
        if (num > 19 && num % 100 != 0) {
            jsConsole.write("and ");
        }
        switch (parseInt(num % 10)) {
            case 1: jsConsole.write("one");
                break;
            case 2: jsConsole.write("two");
                break;
            case 3: jsConsole.write("three");
                break;
            case 4: jsConsole.write("four");
                break;
            case 5: jsConsole.write("five");
                break;
            case 6: jsConsole.write("six");
                break;
            case 7: jsConsole.write("seven");
                break;
            case 8: jsConsole.write("eight");
                break;
            case 9: jsConsole.write("nine");
                break;
        }
    }
    jsConsole.writeLine("");
}