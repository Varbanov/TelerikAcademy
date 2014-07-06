module Reptiles {
    export class Frog implements IAnimal, IReptile{
        private _isAmphibian = true;
        private static _liveExpectancy = 3;
        private static _animalType = AnimalType.Reptile;
        isAlive;
        age;


        constructor(age: number) {
            this.age = age;
        }

        get animalType() {
            return Frog._animalType;
        }

        get isAmphibian() {
            return this._isAmphibian;
        }

        get liveExpectancy() {
            return Frog._liveExpectancy;
        }

        makeSound() : void {
            console.log("A frog croaked!");
        }

        jump(): void {
            console.log('A frog jumped!');
        }
    }

    export class Crocodile implements IAnimal, IReptile {
        private _isAmphibian = true;
        private static _liveExpectancy = 17;
        private static _animalType = AnimalType.Reptile;
        private _teethNumber = 100;
        isAlive;
        age;

        constructor(age: number) {
            this.age = age;
        }

        get animalType() {
            return Crocodile._animalType;
        }

        get isAmphibian() {
            return this._isAmphibian;
        }

        get liveExpectancy() {
            return Crocodile._liveExpectancy;
        }

        get teethNumber() {
            return this._teethNumber;
        }

        kill(animal: IAnimal): void {
            animal.isAlive = false;
        }

        breakTooth(): void {
            this._teethNumber--;
        }

    }

    export class Lizard implements IAnimal, IReptile {
        private _isAmphibian = false;
        private static _liveExpectancy = 4;
        private static _animalType = AnimalType.Reptile;
        isAlive: boolean;
        age: number;
        brokenTail: boolean;

        constructor(age: number) {
            this.age = age;
        }

        get animalType() {
            return Lizard._animalType;
        }

        get isAmphibian() {
            return this._isAmphibian;
        }

        get liveExpectancy() {
            return Lizard._liveExpectancy;
        }

        fight(): void {
            this.brokenTail = true;
        }
    }

    export class Eel implements IAnimal, IReptile {
        private _isAmphibian = true;
        private static _liveExpectancy = 5;
        private static _animalType = AnimalType.Reptile;
        isAlive: boolean;
        age: number;
        length: number;

        constructor(age: number) {
            this.age = age;
        }

        get animalType() {
            return Eel._animalType;
        }

        get isAmphibian() {
            return this._isAmphibian;
        }

        get liveExpectancy() {
            return Eel._liveExpectancy;
        }

        eat(): void {
            this.length++;
        }
    }

} 