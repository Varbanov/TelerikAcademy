module AnimalCollections {
    export class List<T> {
        private _collection: T[];

        add(item: T) {
            this._collection.push(item);
        }

        remove(item: T) {
            var index = this._collection.indexOf(item);
            if (index >= 0) {
                var last = this._collection.pop();
                if (item !== last) {
                    this._collection[index] = last;
                }
            }
        }

        get count() {
            return this._collection.length;
        }
    }
}  