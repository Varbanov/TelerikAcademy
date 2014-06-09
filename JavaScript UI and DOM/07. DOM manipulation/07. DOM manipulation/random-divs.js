var log = console.log;
function onCreateBtnClick(count) {
    removeOldDivs();
    var fragment = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var div = document.createElement("div");
        div.style.width = generateSize(20, 100) + "px";
        div.style.height = generateSize(20, 100) + "px";
        div.style.backgroundColor = generateColor();
        div.style.color = generateColor();
        div.style.position = "absolute";
        div.style.borderRadius = generateSize(0, 20) + "px";
        var border = generateSize(1, 20) + "px solid " + generateColor();
        div.style.border = border;
        div.style.top = generateSize(0, window.innerHeight) + "px";
        div.style.left = generateSize(0, window.innerWidth) + "px";


        var content = document.createElement("strong");
        content.innerHTML = "div";
        div.appendChild(content);
        fragment.appendChild(div);
    }
    document.body.appendChild(fragment);
}

function removeOldDivs() {
    var divs = document.body.getElementsByTagName("div");
    while (divs.length > 0) {
        document.body.removeChild(divs[0]);
    }
}

function generateSize(min, max) {
    var num = Math.floor(Math.random() * (max - min + 1)) + min;
    return num;
}

function generateColor() {
    var color = "#";
    var chars = "0123456789ABCDEF".split('');
    for (var i = 0; i < 6; i++) {
        color += chars[generateSize(0, 15)];
    }
    return color;
}