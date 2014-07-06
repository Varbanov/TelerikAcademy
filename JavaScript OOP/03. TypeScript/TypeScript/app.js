var deer1 = new WarmBlooded.Deer(3, 35, 20);
var deer2 = new WarmBlooded.Deer(3, 35, 15);
deer1.fightForHind(deer2);

var frog = new Reptiles.Frog(2);
var kangaroo = new WarmBlooded.Kangaroo(7, 40, 2);
frog.jump;
kangaroo.sleepInPouch();
var crock = new Reptiles.Crocodile(30);
var list = new AnimalCollections.List();
list.add(deer1);
list.add(deer2);
list.add(frog);
list.add(kangaroo);
list.remove(deer2);
list.add(crock);
//# sourceMappingURL=app.js.map
