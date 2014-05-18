function onButtonClick(event, args) {
    var currentWindow = window;
    var browser = currentWindow.navigator.appCodeName;
    var browserIsMozilla = (browser == "Mozilla") ? true : false;
    if (browserIsMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
