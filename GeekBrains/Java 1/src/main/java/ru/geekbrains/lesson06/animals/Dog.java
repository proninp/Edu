package ru.geekbrains.lesson06.animals;

public class Dog extends Animal{
    private static int dogsCount = 0;

    public static int getDogsCount() {
        return dogsCount;
    }

    public Dog(String name, int runLimit, int swimLimit) {
        super(name);
        this.runLimit = runLimit;
        this.swimLimit = swimLimit;
        dogsCount++;
    }

    @Override
    public void swim(int distance) {
        if (swimLimit == 0) {
            System.out.println("Dog " + name + " can't swim at all.");
        } else if (distance > swimLimit) {
            System.out.println("Dog " + name + " can't swim more than " + swimLimit + " meters.");
        } else {
            System.out.println("Dog " + name + " swim " + distance + " meters.");
        }
    }

    @Override
    public void run(int distance) {
        if (runLimit == 0) {
            System.out.println("Dog " + name + " can't run at all.");
        } else if (distance > runLimit) {
            System.out.println("Dog " + name + " can't run more than " + runLimit + " meters.");
        } else {
            System.out.println("Dog " + name + " run " + distance + " meters.");
        }
    }
}
