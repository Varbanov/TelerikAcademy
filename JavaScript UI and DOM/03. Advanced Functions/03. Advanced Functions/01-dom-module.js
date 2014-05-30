var domModule = (function () {
    var buffer = {};

    function appendChild(elementTag, selector, innerHtml) {
        var element = document.createElement(elementTag);
        element.innerHTML = innerHtml;
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    }

    function removeChild(childSelector, parentSelector) {
        var parent = document.querySelector(parentSelector);
        var child = parent.querySelector(childSelector);
        parent.removeChild(child);
    }

    function appendToBuffer(parentSelector, elementTag, innerHTML) {
        var element = document.createElement(elementTag);
        element.innerHTML = innerHTML;

        //if the parent element has not been used yet, add it to the buffer
        if (!buffer.parentSelector) {
            buffer.parentSelector = document.createDocumentFragment();
        }

        //append the child element
        buffer.parentSelector.appendChild(element);

        //check if buffer size is exceeded and if so, append to DOM and empty buffer
        if (buffer.parentSelector.childNodes.length == 100) {
            var domParent = document.querySelector(parentSelector);
            domParent.appendChild(buffer.parentSelector);
            buffer.parentSelector = null;
        }
    }

    function addHandler(elementSelector, event, handler) {
        var element = document.querySelector(elementSelector);
        //if browser supports addEventListener
        if (element.addEventListener) {
            element.addEventListener(event, handler, false);
        }
        else {
            //for IE 9 or previous versions
            event = "on" + event;
            element.attachEvent(event, handler);
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        appendToBuffer: appendToBuffer,
        addHandler: addHandler
    }
})();

//// check append and remove
domModule.appendChild("div", "body", "this is div 1");
domModule.appendChild("div", "body", "this is div 2");
//domModule.removeChild("div:nth-of-type(2)", "body");

//// check event handler
domModule.addHandler("div:first-of-type", 'click', function () { alert("Clicked!") });

//// check buffer
//for (var i = 0; i < 100; i++) {
//    domModule.appendToBuffer("body", "div", i);
//}