//var args = [
//"7", 
//"1",
//"2",
//"-3",
//"4",
//"4",
//"0",
//"1"
//]

//var args = [
//"6" ,
//"1" ,
//"3" ,
//"-5",
//"8" ,
//"7" ,
//"-6",
//]

//var args = [
//"9",
//"1",
//"8",
//"8",
//"7",
//"6",
//"5",
//"7",
//"7",
//"6",
//]

//console.log(solve(args));

function solve(args) {
    args = args.slice(1);
    args = args.map(Number);
    var i;

    var currentCounter = 1;
    for (i = 0; i < args.length - 1; i++) {
        if (args[i] <= args[i + 1]) {
            continue;
        } else {
            currentCounter++;
        }
    }

    return currentCounter;
}