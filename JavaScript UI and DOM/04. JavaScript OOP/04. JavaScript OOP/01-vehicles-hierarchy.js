var vehicles = (function () {
    Function.prototype.inherit = function (Parent) {
        this.prototype = new Parent();
        this.prototype.constructor = this;
    }

    Function.prototype.extends = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var property = arguments[i];
            this.prototype[property] = parent.prototype[property];
        }

        return this;
    }

    //enums
    var PropellerDirection = {
        "CLOCKWISE": 1,
        "COUNTERCLOCKWISE": 2,
    }

    var AmphibiousVehicleMode = {
        "LAND": 1,
        "WATER": 2,
    }

    var AfterBurnerMode = {
        "ON": 1,
        "OFF": 2,
    }

    //propulsion type root
    function PropulsionUnit() {
        //since there's no common and equal attribute of any children, nothing here..
    }

    //wheel
    function Wheel(radius) {
        var self = this;
        self.radius = radius;
    }

    Wheel.inherit(PropulsionUnit);
    Wheel.prototype.getAcceleration = function () {
        return parseInt(Math.PI * 2 * this.radius);
    }

    //propelling nozzle
    function PropellingNozzle(power) {
        var self = this;
        self.power = power;
        self.afterBurner = false;
    }

    PropellingNozzle.inherit(PropulsionUnit);
    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterBurner) {
            return this.power * 2;
        } else {
            return this.power;
        }
    }

    //propeller
    function Propeller(finsNumber, rotation) {
        var self = this;
        self.finsNumber = finsNumber;
        self.rotation = rotation;
    }

    Propeller.inherit(PropulsionUnit);
    Propeller.prototype.getAcceleration = function () {
        if (this.rotation === PropellerDirection.CLOCKWISE) {
            return this.finsNumber;
        } else {
            return this.finsNumber * -1;
        }
    }

    //vehicle
    function Vehicle(speed, propulsionUnits) {
        var self = this;
        self.speed = speed;
        self.propulsionUnits = propulsionUnits;
    }

    Vehicle.prototype.accelerate = function () {
        for (var i = 0, len = this.propulsionUnits.length; i < len; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    //land vehicle
    function LandVehicle(speed, radius) {
        var propulsionUnits = new Array(4);
        for (var i = 0; i < propulsionUnits.length; i++) {
            propulsionUnits[i] = new Wheel(radius);
        }
        Vehicle.call(this, speed, propulsionUnits);
    }

    LandVehicle.inherit(Vehicle);

    //aircrafts
    function Aircraft(speed, power) {
        Vehicle.call(this, speed, new PropellingNozzle(power));
    }

    Aircraft.inherit(Vehicle);
    Aircraft.prototype.afterBurnerToggle = function () {
        if (this.propulsionUnits.afterBurner == true) {
            this.propulsionUnits.afterBurner = false;
        } else {
            this.propulsionUnits.afterBurner = true;
        }
    }

    //water vehicles
    function WaterVehicle(speed, propellersNumber, propellerFins) {
        var propellers = new Array(propellersNumber);
        for (var i = 0; i < propellers.length; i++) {
            propellers[i] = new Propeller(propellerFins, PropellerDirection.CLOCKWISE);
        }
        Vehicle.call(this, speed, propellers);
    }

    WaterVehicle.inherit(Vehicle);
    WaterVehicle.prototype.DirectionToggle = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i].rotation == PropellerDirection.CLOCKWISE) {
                this.propulsionUnits[i].rotation = PropellerDirection.COUNTERCLOCKWISE;
            } else {
                this.propulsionUnits[i].rotation = PropellerDirection.CLOCKWISE;
            }
        }
    }

    //amphibious
    function AmphibiousVehicle(speed, propellerFins, propellersNumber, wheelRadius, mode) {
        var self = this;
        var propulsion = [];
        for (var i = 0; i < propellersNumber; i++) {
            propulsion.push(new Propeller(propellerFins, PropellerDirection.CLOCKWISE));
        }

        for (var i = 0; i < 4; i++) {
            propulsion.push(new Wheel(wheelRadius));
        }

        Vehicle.call(this, speed, propulsion);
        self.mode = mode;
    }

    AmphibiousVehicle.inherit(Vehicle);
    //attach direction toggle property for water mode
    AmphibiousVehicle.extends(WaterVehicle, "DirectionToggle");

    AmphibiousVehicle.prototype.accelerate = function () {
        if (this.mode == AmphibiousVehicleMode.WATER) {

            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else if (this.mode == AmphibiousVehicleMode.LAND) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }

    return {
        PropellerDirection: PropellerDirection,
        AmphibiousVehicleMode: AmphibiousVehicleMode,
        AfterBurnerMode: AfterBurnerMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        WaterVehicle: WaterVehicle,
        Aircraft: Aircraft,
        AmphibiousVehicle: AmphibiousVehicle,
    }

})();

//test
var landVehicle = new vehicles.LandVehicle(100, 40);
var aircraft = new vehicles.Aircraft(1000, 500);
var waterVehicle = new vehicles.WaterVehicle(30, 5, 8);
var amphibiousVehicle = new vehicles.AmphibiousVehicle(70, 6, 2, 40, vehicles.AmphibiousVehicleMode.LAND);

print(landVehicle);
//print(aircraft);
//print(waterVehicle);
//print(amphibiousVehicle);

//function to print on the console all properties of an object (recursively taken)
function print(obj) {
    var identation = "";

    (function printFunction(obj) {
        if (typeof obj != "object") {
            console.log(identation + obj);
        }

        for (var property in obj) {
            if (obj.hasOwnProperty(property)) {
                console.log(identation + property + ":");
                identation += "--";
                printFunction(obj[property]);
                identation = identation.substr(0, identation.length - 2);
            }
        }
    })(obj);
}
