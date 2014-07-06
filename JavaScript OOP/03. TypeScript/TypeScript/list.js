var AnimalCollections;
(function (AnimalCollections) {
    var List = (function () {
        function List() {
        }
        List.prototype.add = function (item) {
            this._collection.push(item);
        };

        List.prototype.remove = function (item) {
            var index = this._collection.indexOf(item);
            if (index >= 0) {
                var last = this._collection.pop();
                if (item !== last) {
                    this._collection[index] = last;
                }
            }
        };

        Object.defineProperty(List.prototype, "count", {
            get: function () {
                return this._collection.length;
            },
            enumerable: true,
            configurable: true
        });
        return List;
    })();
    AnimalCollections.List = List;
})(AnimalCollections || (AnimalCollections = {}));
//# sourceMappingURL=list.js.map
