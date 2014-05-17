var window = this.window;
var appName = window.navigator.appName;
var addScroll = false;
var document = this.document;
var navigator = this.navigator;

if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

var off = 0;
var txt = "";
var pageX = 0;
var pageY = 0;
document.onmousemove = mouseMove;

if (appName === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(event) {
    if (appName === "Netscape") {
        pageX = event.pageX - 5;
        pageY = event.pageY;
    } else {
        pageX = event.x - 5;
        pageY = event.y;
    }

    if (appName === "Netscape" && (document.layers.ToolTip.visibility === 'show')) {
        PopTip();
    } else if (document.all.ToolTip.style.visibility === 'visible') {
        PopTip();
    }
}

function PopTip() {
    if (appName === "Netscape") {
        var layer = document.layers.ToolTip;
        if ((pageX + 120) > window.innerWidth) {
            pageX = window.innerWidth - 150;
        }

        layer.left = pageX + 10;
        layer.top = pageY + 15;
        layer.visibility = 'show';
    } else {
        var layer = document.all.ToolTip;
        if (layer) {
            pageX = event.x - 5;
            pageY = event.y;

            if (addScroll) {
                pageX = pageX + document.body.scrollLeft;
                pageY = pageY + document.body.scrollTop;
            }

            if ((pageX + 120) > document.body.clientWidth) {
                pageX = pageX - 150;
            }

            layer.style.pixelLeft = pageX + 10;
            layer.style.pixelTop = pageY + 15;
            layer.style.visibility = 'visible';
        }
    }
}

function HideTip() {
    if (appName === "Netscape") {
        document.layers.ToolTip.visibility = 'hide';
    } else {
        document.all.ToolTip.style.visibility = 'hidden';
    }
}

function HideMenu1() {
    if (appName === "Netscape") {
        document.layers.menu1.visibility = 'hide';
    } else {
        document.all.menu1.style.visibility = 'hidden';
    }
}

function ShowMenu1() {
    if (appName === "Netscape") {
        var layer = document.layers.menu1;
        layer.visibility = 'show';
    } else {
        var layer = document.all.menu1;
        layer.style.visibility = 'visible';
    }
}

function HideMenu2() {
    if (appName === "Netscape") {
        document.layers.menu2.visibility = 'hide';
    } else {
        document.all.menu2.style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (appName === "Netscape") {
        var layer = document.layers.menu2;
        layer.visibility = 'show';
    } else {
        var layer = document.all.menu2;
        layer.style.visibility = 'visible';
    }
}