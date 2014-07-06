var CanvasDrawer = (function (id) {
    var Drawer = function (id) {
        this.color = 'black';
        this.width = 3;
        this.context = (function () {
            var canvas = document.getElementById(id);
            if (!canvas) {
                throw 'Incorect canvas id';
            }

            var context = canvas.getContext('2d');
            return context;
        })(id);
    }
   
    Drawer.prototype = {
        rectangle: function rectangle(x, y, width, height, color) {
            this.context.fillStyle = color || this.color;
            this.context.fillRect(x, y, width, height);
        },

        circle: function circle(x, y, radius, color) {
            this.context.fillStyle = color || this.color;
            this.context.beginPath();
            this.context.arc(x, y, radius, 0, 2 * Math.PI, true);
            this.context.fill();
            this.context.closePath();
        },

        line: function line(x1, y1, x2, y2, color, width) {
            this.context.strokeStyle = color || this.color;
            this.context.lineWidth = width || this.width;
            this.context.beginPath();
            this.context.moveTo(x1, y1);
            this.context.lineTo(x2, y2);
            this.context.stroke();
            this.context.closePath();
        }
    }

    return Drawer;
})();

//test
var drawer = new CanvasDrawer('canvas');
drawer.rectangle(10, 15, 60, 40, 'red');
drawer.circle(100, 100, 40, 'green');
drawer.line(150, 50, 250, 200, 'yellowgreen', 5);