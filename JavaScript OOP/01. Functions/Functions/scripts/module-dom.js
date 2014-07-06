var domModule = (function domModule() {
    var buffer = {};

    function appendChild(elementTag, selector, innerHtml) {
        var element = document.createElement(elementTag);
        element.innerHTML = innerHtml;
        var parent = document.querySelector(selector);
        parent.appendChild(element);
    }

    function removeChild(parentSelector, childSelector) {
        var parent = document.querySelector(parentSelector);
        var child = document.querySelector(childSelector);
        parent.removeChild(child);
    }

    function addHandler(elementSelector, eventType, handler) {
        var element = document.querySelector(elementSelector);
        //if browser supports addEventListener
        if (element.addEventListener) {
            element.addEventListener(eventType, handler, false);
        } else {
            //for IE 9 or previous versions
            eventType = 'on' + eventType;
            element.attachEvent(eventType, handler);
        }
    }

    function appendToBuffer(parentSelector, elementTag, innerHtml) {
        var element = document.createElement(elementTag);
        element.innerHTML = innerHtml;

        //if the parent element has not been used yet, add it to the buffer
        if (!buffer[parentSelector]) {
            buffer[parentSelector] = document.createDocumentFragment();
        }

        //append the element
        buffer[parentSelector].appendChild(element);

        //check if buffer size is exceeded and if so, append to DOM and empty buffer
        if (buffer[parentSelector].childNodes.length == 100) {
            var domParent = document.querySelector(parentSelector);
            domParent.appendChild(buffer[parentSelector]);
            buffer[parentSelector] = null;
        }
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
    }
})();

////check append and remove
domModule.appendChild('div', 'body', 'this is div');
domModule.appendChild('div', 'body', 'this is div 2');
//domModule.removeChild('body', 'div:nth-of-type(2)');

////check event handler
domModule.addHandler('div:first-of-type', 'click', function () { alert('Clicked!') });

////check buffer
//for (var i = 0; i < 100; i++) {
//    domModule.appendToBuffer('body', 'div', "div " + i);
//}