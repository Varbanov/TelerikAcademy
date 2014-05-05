var x0 = 250;
var y0 = 150;
var radius = 100;
var divSize = 40;
var delay = 100;

//draw circumference
function drawCircumference(x, y, r) {
    var div = document.createElement("div");
    var style = div.style;
    style.border = "1px solid black";
    style.width = 2 * r + "px";
    style.height = 2 * r + "px";
    style.position = "absolute";
    style.top = y - r + "px";
    style.left = x - r + "px";
    style.borderRadius = "50%";
    document.body.appendChild(div);
}
drawCircumference(x0, y0, radius);

//create divs
var fragment = document.createDocumentFragment();
var initialAngle = generateRndNum(0, 360);
var divs = new Array(5);

for (var i = 0; i < divs.length; i++) {
    divs[i] = document.createElement("div");
    //set data-angle attribute to memorize the current angle each div is rotated by
    divs[i].setAttribute("data-angle", initialAngle);
    divs[i].className = "rotate";
    var inner = document.createElement("span");
    divs[i].appendChild(inner);
    divs[i].getElementsByTagName("span")[0].innerHTML = 1 + i;
    divs[i].style.textAlign = "center";
    divs[i].style.width = divSize + "px";
    divs[i].style.height = divSize + "px";
    divs[i].style.position = "absolute";
    divs[i].style.borderRadius = "50%";
    divs[i].style.border = "1px solid" + generateColor(0, 15);
    divs[i].style.backgroundColor = generateColor(4, 15);

    updatePosition(x0, y0, 100, divs[i]);
    fragment.appendChild(divs[i]);
    //next div should be 360/5 = 72 degrees away from the current one
    initialAngle += 72;
}
document.body.appendChild(fragment);

//update position function
function updatePosition(xO, yO, radius, div) {
    var angleSoFar = parseFloat(div.getAttribute("data-angle"));
    var y = radius * Math.sin(((angleSoFar + 1) * Math.PI) / 180) + yO;
    var x = radius * Math.cos(((angleSoFar + 1) * Math.PI) / 180) + xO;
    div.setAttribute("data-angle", ++angleSoFar);
    div.style.top = (y - divSize / 2) + "px";
    div.style.left = (x - divSize / 2) + "px";
}

//engine to rotate the divs
(function engine(e) {
    timer = setInterval(function () {
        var divs = document.body.getElementsByClassName("rotate");
        for (var i = 0, len = divs.length; i < len; i++) {
            updatePosition(x0, y0, radius, divs[i]);
        }
    }, delay);

})();

//auxiliary function to generate random integers in a range
function generateRndNum(min, max) {
    var num = Math.floor(Math.random() * (max - min + 1)) + min;
    return num;
}
//auxiliary function to generate random colors in a range
function generateColor(min, max) {
    var color = "#";
    var chars = "0123456789ABCDEF".split('');
    for (var i = 0; i < 6; i++) {
        color += chars[generateRndNum(min, max)];
    }
    return color;
}