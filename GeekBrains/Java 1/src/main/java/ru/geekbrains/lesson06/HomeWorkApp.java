package ru.geekbrains.lesson06;

import ru.geekbrains.lesson06.animals.Animal;
import ru.geekbrains.lesson06.animals.Cat;
import ru.geekbrains.lesson06.animals.Dog;

public class HomeWorkApp {
    public static void main(String[] args) {
        Animal animal = new Animal();
        Cat barsik = new Cat("Barsik", 200, 0);
        Cat rizhik = new Cat("Rizhik", 150, 0);
        Dog chap = new Dog("Chap", 500, 20);
        Dog juja = new Dog("Juja", 550, 10);

        barsik.run(160);
        barsik.swim(5);
        rizhik.run(160);
        rizhik.swim(5);
        chap.run(520);
        chap.swim(10);
        juja.run(520);
        juja.swim(10);

        System.out.println("Total animals count: " + Animal.getAnimalsCount());
        System.out.println("Cats count: " + Cat.getCatsCount());
        System.out.println("Dogs count: " + Dog.getDogsCount());
    }
}
