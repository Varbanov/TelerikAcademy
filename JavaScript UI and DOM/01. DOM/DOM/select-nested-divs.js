
function onCheckDivsBtnClick() {
    //printNestedDivs();
    printNestedDivsByTagName();
}

function printNestedDivs() {
    var nestedDivs = document.querySelectorAll('div > div');
    for (var i = 0; i < nestedDivs.length; i++) {
        console.log(nestedDivs[i].outerHTML);
    }
}

function printNestedDivsByTagName() {
    var divs = document.getElementsByTagName("div");

    for (var i = 0, len = divs.length; i < len; i++) {
        if (divs[i].parentNode.tagName == "DIV") {
            console.log(divs[i].outerHTML);
        }
    }

}