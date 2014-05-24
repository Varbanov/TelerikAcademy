//var args = [
//"20",
//"11" ,
//"200" ,
//"300" ,

//];

//console.log(solve(args));

function solve(args) {
    var money = parseInt(args[0]);
    var price1 = parseInt(args[1]);
    var price2 = parseInt(args[2]);
    var price3 = parseInt(args[3]);

    var max1 = Math.floor(money / price1);
    var max2 = Math.floor(money / price1);
    var max3 = Math.floor(money / price3);
    var i;
    var j;
    var k;

    var result = 0;
    var spent;

    for (i = 0; i <= max1; i++) {
        spent = price1 * i;

        for (j = 0; j <= max2; j++) {
            spent = (price1 * i) + (price2 * j);

            for (k = 0; k <= max3; k++) {
                spent = (price1 * i) + (price2 * j) + (price3 * k);

                if (spent <= money && spent >= result) {
                    result = spent;
                }
            }

        }
    }


    return result;
}