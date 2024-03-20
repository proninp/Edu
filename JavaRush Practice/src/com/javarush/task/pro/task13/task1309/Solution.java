package com.javarush.task.pro.task13.task1309;

import java.util.HashMap;

/* 
Успеваемость студентов
*/

public class Solution {
    public static HashMap<String, Double> grades = new HashMap<>();

    public static void main(String[] args) {
        addStudents();
        System.out.println(grades);
    }

    public static void addStudents() {
        grades.put("Klark Kent", 5.0);
        grades.put("Thomas Anderson", 4.8);
        grades.put("Bilbo Baggins", 4.7);
        grades.put("Luke Skywalker", 4.65);
        grades.put("Peter Parker", 5.0);
    }
}
