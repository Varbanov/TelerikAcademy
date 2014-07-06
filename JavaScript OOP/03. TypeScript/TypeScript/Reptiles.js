var Reptiles;
(function (Reptiles) {
    var Frog = (function () {
        function Frog(age) {
            this._isAmphibian = true;
            this.age = age;
        }
        Object.defineProperty(Frog.prototype, "animalType", {
            get: function () {
                return Frog._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Frog.prototype, "isAmphibian", {
            get: function () {
                return this._isAmphibian;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Frog.prototype, "liveExpectancy", {
            get: function () {
                return Frog._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Frog.prototype.makeSound = function () {
            console.log("A frog croaked!");
        };

        Frog.prototype.jump = function () {
            console.log('A frog jumped!');
        };
        Frog._liveExpectancy = 3;
        Frog._animalType = 0 /* Reptile */;
        return Frog;
    })();
    Reptiles.Frog = Frog;

    var Crocodile = (function () {
        function Crocodile(age) {
            this._isAmphibian = true;
            this._teethNumber = 100;
            this.age = age;
        }
        Object.defineProperty(Crocodile.prototype, "animalType", {
            get: function () {
                return Crocodile._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Crocodile.prototype, "isAmphibian", {
            get: function () {
                return this._isAmphibian;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Crocodile.prototype, "liveExpectancy", {
            get: function () {
                return Crocodile._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Crocodile.prototype, "teethNumber", {
            get: function () {
                return this._teethNumber;
            },
            enumerable: true,
            configurable: true
        });

        Crocodile.prototype.kill = function (animal) {
            animal.isAlive = false;
        };

        Crocodile.prototype.breakTooth = function () {
            this._teethNumber--;
        };
        Crocodile._liveExpectancy = 17;
        Crocodile._animalType = 0 /* Reptile */;
        return Crocodile;
    })();
    Reptiles.Crocodile = Crocodile;

    var Lizard = (function () {
        function Lizard(age) {
            this._isAmphibian = false;
            this.age = age;
        }
        Object.defineProperty(Lizard.prototype, "animalType", {
            get: function () {
                return Lizard._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Lizard.prototype, "isAmphibian", {
            get: function () {
                return this._isAmphibian;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Lizard.prototype, "liveExpectancy", {
            get: function () {
                return Lizard._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Lizard.prototype.fight = function () {
            this.brokenTail = true;
        };
        Lizard._liveExpectancy = 4;
        Lizard._animalType = 0 /* Reptile */;
        return Lizard;
    })();
    Reptiles.Lizard = Lizard;

    var Eel = (function () {
        function Eel(age) {
            this._isAmphibian = true;
            this.age = age;
        }
        Object.defineProperty(Eel.prototype, "animalType", {
            get: function () {
                return Eel._animalType;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Eel.prototype, "isAmphibian", {
            get: function () {
                return this._isAmphibian;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Eel.prototype, "liveExpectancy", {
            get: function () {
                return Eel._liveExpectancy;
            },
            enumerable: true,
            configurable: true
        });

        Eel.prototype.eat = function () {
            this.length++;
        };
        Eel._liveExpectancy = 5;
        Eel._animalType = 0 /* Reptile */;
        return Eel;
    })();
    Reptiles.Eel = Eel;
})(Reptiles || (Reptiles = {}));
//# sourceMappingURL=Reptiles.js.map
