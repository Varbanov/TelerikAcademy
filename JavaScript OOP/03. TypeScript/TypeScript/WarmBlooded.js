var WarmBlooded;
(function (WarmBlooded) {
    var deerHornDamage = 5;

    var Deer = (function () {
        function Deer(age, bodyTemperature, hornsLength) {
            this._animalType = 1 /* WarmBlooded */;
            this.bodyTemperature = bodyTemperature;
            this._hornsLength = hornsLength;
            this.isAlive = true;
            this.age = age;
        }
        Object.defineProperty(Deer.prototype, "liveExpectancy", {
            get: function () {
                return Deer._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Deer.prototype, "bodyTemperature", {
            get: function () {
                return this._bodyTemperature;
            },
            set: function (newTemperature) {
                this._bodyTemperature = newTemperature;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Deer.prototype, "animalType", {
            get: function () {
                return this._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Deer.prototype, "hornsLength", {
            get: function () {
                return this._hornsLength;
            },
            enumerable: true,
            configurable: true
        });

        Deer.prototype.breakHorns = function () {
            this._hornsLength = 0;
        };

        Deer.prototype.fightForHind = function (anotherDeer) {
            if (this._hornsLength === 0 && anotherDeer.hornsLength != 0) {
                this.isAlive = false;
            } else if (this.hornsLength >= deerHornDamage) {
                this._hornsLength -= deerHornDamage;
            }
        };
        return Deer;
    })();
    WarmBlooded.Deer = Deer;

    var Kangaroo = (function () {
        function Kangaroo(age, bodyTemperature, jumpLength) {
            this.age = age;
            this.bodyTemperature = bodyTemperature;
            this.jumpLength = jumpLength;
            this._jumpsCounter = 0;
            this._animalType = 1 /* WarmBlooded */;
            this._isAlive = true;
        }
        Object.defineProperty(Kangaroo.prototype, "liveExpectancy", {
            get: function () {
                return Kangaroo._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Kangaroo.prototype, "animalType", {
            get: function () {
                return this._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Kangaroo.prototype, "isAlive", {
            get: function () {
                return this._isAlive;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Kangaroo.prototype, "jumpsCounter", {
            get: function () {
                return this._jumpsCounter;
            },
            enumerable: true,
            configurable: true
        });

        Kangaroo.prototype.jump = function () {
            this._jumpsCounter++;
        };

        Kangaroo.prototype.sleepInPouch = function () {
            this.isAsleepInPouch = true;
        };

        Kangaroo.prototype.awake = function () {
            this.isAsleepInPouch = false;
        };
        Kangaroo._liveExpectancy = 8;
        return Kangaroo;
    })();
    WarmBlooded.Kangaroo = Kangaroo;
})(WarmBlooded || (WarmBlooded = {}));
//# sourceMappingURL=WarmBlooded.js.map
