package ru.geekbrains.lesson06.animals;

public class Animal {
    private static int animalsCount = 0;
    protected String name;
    protected int runLimit;
    protected int swimLimit;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public static final int getAnimalsCount() {
        return animalsCount;
    }

    public Animal() {
        animalsCount++;
    }

    public Animal(String name) {
        this.name = name;
        animalsCount++;
    }

    public void swim(int distance) {
        System.out.println("Animal swim " + distance + " meters");
    }

    public void run(int distance) {
        System.out.println("Animal run " + distance + " meters");
    }
//    public void swim(int distance) {
//        if (swimLimit == 0) {
//            System.out.println("This " + this.getClass() + " can't swim at all.");
//        } else if (distance > swimLimit) {
//            System.out.println(this.getClass() + " " + name + " can't swim more than " + swimLimit + " meters.");
//        } else {
//            System.out.println(this.getClass() + " " + name + " swim " + distance + " meters.");
//        }
//    }
//    public void run(int distance) {
//        if (runLimit == 0) {
//            System.out.println("This " + this.getClass() + " can't run at all.");
//        } else if (distance > runLimit) {
//            System.out.println(this.getClass() + " " + name + " can't run more than " + runLimit + " meters.");
//        } else {
//            System.out.println(this.getClass() + " " + name + " run " + distance + " meters.");
//        }
//    }
}
