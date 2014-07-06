module WarmBlooded {

    var deerHornDamage = 5;

    export class Deer implements IWarmBlooded, IAnimal {
        private _bodyTemperature;
        private _animalType = AnimalType.WarmBlooded;
        private _hornsLength: number;
        isAlive;
        age;
        private static _liveExpectancy;

        constructor(age: number, bodyTemperature: number, hornsLength) {
            this.bodyTemperature = bodyTemperature;
            this._hornsLength = hornsLength;
            this.isAlive = true;
            this.age = age;
        }

        get liveExpectancy() {
            return Deer._liveExpectancy;
        }

        get bodyTemperature() {
            return this._bodyTemperature;
        }

        set bodyTemperature(newTemperature: number) {
            this._bodyTemperature = newTemperature;
        }

        get animalType(): AnimalType {
            return this._animalType;
        }

        get hornsLength(): number {
            return this._hornsLength;
        }

        breakHorns(): void {
            this._hornsLength = 0;
        }

        fightForHind(anotherDeer: Deer): void {
            if (this._hornsLength === 0 && anotherDeer.hornsLength != 0) {
                this.isAlive = false;
            } else if (this.hornsLength >= deerHornDamage) {
                this._hornsLength -= deerHornDamage;
            }
        }
    }

    export class Kangaroo implements IWarmBlooded, IAnimal {
        private static _liveExpectancy = 8;
        private _animalType: AnimalType;
        private _isAlive;
        private _jumpsCounter = 0;
        isAsleepInPouch;

        constructor(public age: number, public bodyTemperature: number, public jumpLength: number) {
            this._animalType = AnimalType.WarmBlooded;
            this._isAlive = true;
        }

        get liveExpectancy() {
            return Kangaroo._liveExpectancy;
        }

        get animalType() {
            return this._animalType;
        }

        get isAlive() {
            return this._isAlive;
        }

        get jumpsCounter() {
            return this._jumpsCounter;
        }

        jump(): void {
            this._jumpsCounter++;
        }

        sleepInPouch(): void {
            this.isAsleepInPouch = true;
        }

        awake(): void {
            this.isAsleepInPouch = false;
        }
    }
} 