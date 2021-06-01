package ru.geekbrains.lesson06.animals;

public class Cat extends Animal {
    private static int catsCount = 0;

    public static int getCatsCount() {
        return catsCount;
    }

    public Cat(String name, int runLimit, int swimLimit) {
        super(name);
        this.runLimit = runLimit;
        this.swimLimit = swimLimit;
        catsCount++;
    }

    @Override
    public void swim(int distance) {
        if (swimLimit == 0) {
            System.out.println("Cat " + name + " can't swim at all.");
        } else if (distance > swimLimit) {
            System.out.println("Cat " + name + " can't swim " + distance + " meters. " + name + " can't swim more than " + swimLimit + " meters.");
        } else {
            System.out.println("Cat " + name + " swim " + distance + " meters.");
        }
    }

    @Override
    public void run(int distance) {
        if (runLimit == 0) {
            System.out.println("Cat " + name + " can't run at all.");
        } else if (distance > runLimit) {
            System.out.println("Cat " + name + " can't run " + distance + " meters. " + name + " can't run more than " + runLimit + " meters.");
        } else {
            System.out.println("Cat " + name + " run " + distance + " meters.");
        }
    }
}
