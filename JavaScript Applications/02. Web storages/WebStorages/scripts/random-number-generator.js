define(function () {
    var checkNumber = function checkNumber() {
        var number = "" + generateRndNum(1000, 9999);
        var digits = {};

        for (var i = 0; i < number.length; i++) {
            if (digits[number[i]]) {
                return checkNumber();
            } else {
                digits[number[i]] = true;
            }
        }

        return number;
    };

    function generateRndNum(min, max) {
        var num = Math.floor(Math.random() * (max - min + 1)) + min;
        return num;
    }

    var number = checkNumber();
    return number;
});