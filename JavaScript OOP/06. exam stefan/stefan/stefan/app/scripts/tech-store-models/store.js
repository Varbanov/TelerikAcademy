define(['tech-store-models/item'], function (Item) {
    var Store = (function () {
        var Types = {
            accessory: 'accessory',
            smartphone: 'smart-phone',
            notebook: 'notebook',
            pc: 'pc',
            tablet: 'tablet',
        }

        var minNameLength = 6;
        var maxNameLength = 30;

        function Store(storeName) {
            if (storeName.length < minNameLength || storeName.length > maxNameLength) {
                throw 'Invalid store name: the length of name must be between ' + minNameLength + " and " + maxNameLength;
            }

            this.name = storeName;
            this.items = [];
        }

        function sortItemsByName(item1, item2) {
            return item1.name.localeCompare(item2.name);
        }

        function sortItemsByPrice(item1, item2) {
            return item1.price - item2.price;
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw 'Stores can add only instances of type Item'
                }

                this.items.push(item);
                return this;
            },

            getAll: function () {
                var items = this.items.slice(0);
                items.sort(sortItemsByName);

                return items;
            },

            getSmartPhones: function () {
                var items = [];
                var i;
                var currentItem;
                //extract smartphones
                for (i = 0, len = this.items.length; i < len; i++) {
                    currentItem = this.items[i];
                    if (currentItem.type === Types.smartphone) {
                        items.push(Object.create(currentItem));
                    }
                }

                //sort
                items.sort(sortItemsByName);

                return items;
            },

            getMobiles: function () {
                var items = [];
                var i;
                var currentItem;
                //extract mobiles
                for (i = 0, len = this.items.length; i < len; i++) {
                    currentItem = this.items[i];
                    if (currentItem.type === Types.smartphone || currentItem.type === Types.tablet) {
                        items.push(Object.create(currentItem));
                    }
                }

                //sort
                items.sort(sortItemsByName);

                return items;
            },

            getComputers: function () {
                var items = [];
                var i;
                var currentItem;
                //extract pc
                for (i = 0, len = this.items.length; i < len; i++) {
                    currentItem = this.items[i];
                    if (currentItem.type === Types.pc || currentItem.type === Types.notebook) {
                        items.push(Object.create(currentItem));
                    }
                }

                //sort
                items.sort(sortItemsByName);

                return items;
            },

            filterItemsByType: function (type) {
                var items = [];
                var i;
                var currentItem;
                //extract by type
                for (i = 0, len = this.items.length; i < len; i++) {
                    currentItem = this.items[i];
                    if (currentItem.type === type) {
                        items.push(Object.create(currentItem));
                    }
                }

                //sort
                items.sort(sortItemsByName);

                return items;
            },

            filterItemsByPrice: function (params) {
                var items = [];
                var i;
                var currentItem;

                if (params) {
                    if (params.min && params.max) {
                        for (i = 0, len = this.items.length; i < len; i++) {
                            currentItem = this.items[i];
                            if (currentItem.price >= params.min && currentItem.price <= params.max) {
                                items.push(Object.create(currentItem));
                            }
                        }
                    } else if (params.min) {
                        for (i = 0, len = this.items.length; i < len; i++) {
                            currentItem = this.items[i];
                            if (currentItem.price >= params.min) {
                                items.push(Object.create(currentItem));
                            }
                        }
                    } else if (params.max) {
                        for (i = 0, len = this.items.length; i < len; i++) {
                            currentItem = this.items[i];
                            if (currentItem.price <= params.max) {
                                items.push(Object.create(currentItem));
                            }
                        }
                    }
                } else {
                    items = this.getAll();
                }

                //sort
                items.sort(sortItemsByPrice);

                return items;
            },

            countItemsByType: function () {
                var result = {};
                var i;
                var currentItem;

                for (i = 0, len = this.items.length; i < len; i++) {
                    currentItem = this.items[i];
                    if (result[currentItem.type]) {
                        result[currentItem.type] += 1;
                    } else {
                        result[currentItem.type] = 1;
                    }
                }

                return result;
            },

            filterItemsByName: function (partOfname) {
                var items = [];
                var i;
                var currentItem;
                var currentName;
                partOfname = partOfname.toLowerCase();
                //extract
                for (i = 0, len = this.items.length; i < len; i++) {

                    currentItem = this.items[i];
                    currentName = currentItem.name.toLowerCase();

                    if (currentName.indexOf(partOfname) > -1) {
                        items.push(Object.create(currentItem));
                    }
                }

                //sort
                items.sort(sortItemsByName);

                return items;
            },
        }

        return Store;
    })();

    return Store;
})