package ru.geekbrains.lesson07;

public class Plate {
    private int currentFoodValue;
    private int maxFoodValue;

    public Plate(int currentFoodValue, int maxFoodValue) {
        if (currentFoodValue < 0) {
            System.out.println("Current food value must not be lesser than zero!");
            currentFoodValue = 0;
        }
        if (currentFoodValue > maxFoodValue) {
            System.out.println("Current food value must not be greater than the maximum food value!");
            maxFoodValue = currentFoodValue;
        }
        if (maxFoodValue == 0) {
            System.out.println("Max food value must be greater than zero!");
            maxFoodValue = 1;
        }
        this.currentFoodValue = currentFoodValue;
        this.maxFoodValue = maxFoodValue;
    }

    public Plate(int food) {
        this(food, food);
    }

    public int getMaxFoodValue() {
        return maxFoodValue;
    }

    public int decreaseFood(int n) {
        if (n > currentFoodValue) {
            n -= currentFoodValue;
            currentFoodValue = 0;
            return n;
        }
        currentFoodValue -= n;
        return 0;
    }

    public void fillPlate() {
        System.out.println("The plate will be filled.");
        currentFoodValue = maxFoodValue;
    }

    public void info() {
        System.out.println(currentFoodValue > 0 ? "Food in plate: " + currentFoodValue : "The plate is empty!");
    }

}
