package ru.geekbrains.lesson05;

public class HomeWorkApp {
    public static void main(String[] args) {
        lesson5HW();
    }
    public static void lesson5HW() {
        Person[] personArray = new Person[5];
        personArray[0] = new Person("Ivan", "Petrovich", "Ivanov",
                "CIO", "IvanovIP@gb.ru", "79990000000",300_000, 58);
        personArray[1] = new Person("Petr", "Ivanovich", "Sergeev",
                "Team Lead", "SergeevPI@gb.ru", "79990000001",180_000, 42);
        personArray[2] = new Person("Timur", "Andreevich", "Kolokolov",
                "Senior Developer", "KolokolovTA@gb.ru", "79990000002",150_000, 40);
        personArray[3] = new Person("Andrey", "Andreevich", "Nosov",
                "Senior Developer", "NosovAA@gb.ru", "79990000003",150_000, 38);
        personArray[4] = new Person("Ekaterina", "Petrovna", "Popova",
                "Accauntant", "PopovaEP@gb.ru", "79990000004",140_000, 48);
        for (int i = 0; i < personArray.length; i++) {
            if (personArray[i].getAge() > 40) {
                personArray[i].getInformation();
            }
        }
    }
}