package com.javarush.task.task17.task1711;

public enum Sex {
    MALE("м"),
    FEMALE("ж");

    private final String text;

    Sex(String text) {
        this.text = text;
    }

    public String getText() {
        return this.text;
    }

    public static Sex fromString(String text) {
        for (Sex x : Sex.values()) {
            if (x.text.equalsIgnoreCase(text)) {
                return x;
            }
        }
        return null;
    }
}