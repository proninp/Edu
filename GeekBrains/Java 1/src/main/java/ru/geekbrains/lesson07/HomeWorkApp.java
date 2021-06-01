package ru.geekbrains.lesson07;

public class HomeWorkApp {
    /*
    I have improved the ability to gradually reduce the appetite variable.
    A cat is considered as hungry until its appetite is not equals to zero.
    If there is not enough food in the plate to feed the cat, then its appetite will decrease by the amount of food that was in the plate.
    After that, the plate is filled with food.
     */
    public static void main(String[] args) {
        Cat[] cats = new Cat[]{new Cat("Rizhik", 15), new Cat("Barsik", 20), new Cat("Busya", 10),
                new Cat("Leya", 18), new Cat("Tom", 20), new Cat("Jerry", 12)};
        boolean[] skipInfo = new boolean[cats.length];
        Plate plate = new Plate(40); // overloaded constructor will call another constructor with two parameters
        plate.info();
        boolean isAllCatsWellFed;
        do {
            isAllCatsWellFed = true;
            for (int i = 0; i < cats.length; i++) {
                if (cats[i].isHungry()) {
                    if (!cats[i].eat(plate)) {
                        isAllCatsWellFed = false;
                    }
                }
                if (!skipInfo[i]) { // Why should we print info about well-fed cats if we've already known that they are not hungry?
                    cats[i].info();
                    skipInfo[i] = !cats[i].isHungry();
                }
            }
        } while (!isAllCatsWellFed);
        System.out.println("All cats well-fed!");
        plate.info();
    }
}
