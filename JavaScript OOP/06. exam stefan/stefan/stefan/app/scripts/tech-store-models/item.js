define(function () {
    var Item = (function () {
        var Types = {
            accessory: 'accessory',
            smartphone: 'smart-phone',
            notebook: 'notebook',
            pc: 'pc',
            tablet: 'tablet',
        }

        var minNameLength = 6;
        var maxNameLength = 40;

        function Item(type, name, price) {
            if (type !== Types.accessory && type != Types.smartphone &&
                type !== Types.notebook && type !== Types.pc && type !== Types.tablet) {
                throw 'Invalid item type';
            }
                
            if (name.length < minNameLength || name.length > maxNameLength) {
                throw 'Invalid item name: the length of name must be between ' + minNameLength + " and " + maxNameLength;
            }

            if (typeof price != 'number' || price < 0) {
                throw 'Invalid price: price must be a positive number';
            }

            this.type = type;
            this.name = name;
            this.price = price;
        }

        return Item;
    })();

    return Item;
})