package ru.geekbrains.lesson07;

public class Cat {
    private String name;
    private int appetite;
    private int maxAppetite;
    private boolean isWellFed;

    public boolean isHungry() {
        return !isWellFed;
    }

    public Cat(String name, int appetite) {
        this.name = name;
        this.appetite = appetite;
        this.maxAppetite = this.appetite;
        this.isWellFed = false;
    }

    public boolean eat(Plate p) {
        appetite = p.decreaseFood(appetite);
        this.isWellFed = appetite == 0;
        if (!this.isWellFed) {
            System.out.printf("There is no enough food for %s with maximum appetite %d.\n", name, maxAppetite);
            p.fillPlate();
        }
        return this.isWellFed;
    }

    public void info() {
        if (isWellFed) {
            System.out.printf("Cat %s with maximum value of appetite %d is well-fed.\n", name, maxAppetite);
        } else {
            System.out.printf("Cat %s with remaining appetite %d is hungry.\n", name, appetite);
        }
    }

}
