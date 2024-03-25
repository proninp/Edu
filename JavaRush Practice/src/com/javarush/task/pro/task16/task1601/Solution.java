package com.javarush.task.pro.task16.task1601;

import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.Locale;

/* 
Лишь бы не в понедельник :)
*/

public class Solution {

    static Date birthDate = new Date(2000, Calendar.APRIL, 1);

    public static void main(String[] args) {
        System.out.println(getDayOfWeek(birthDate));
    }

    static String getDayOfWeek(Date date) {
        return new SimpleDateFormat("EEEE", new Locale("ru", "RU")).format(date);
    }
}
