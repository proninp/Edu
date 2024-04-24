package com.javarush.task.task17.task1711;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

/* 
CRUD 2
*/

public class Solution {
    public static volatile List<Person> allPeople = new ArrayList<Person>();
    private static SimpleDateFormat argsDf = new SimpleDateFormat("dd/MM/yyyy", Locale.ENGLISH);
    private static SimpleDateFormat df = new SimpleDateFormat("dd-MMM-yyyy", Locale.ENGLISH);

    static {
        allPeople.add(Person.createMale("Иванов Иван", new Date()));  //сегодня родился    id=0
        allPeople.add(Person.createMale("Петров Петр", new Date()));  //сегодня родился    id=1
    }

    public static void main(String[] args) {
        if (args == null || args.length < 1) {
            throw new RuntimeException();
        }

        switch (args[0]) {
            case "-c": {
                synchronized (allPeople) {
                    for (int i = 1; i < args.length; i++) {
                        create(args[i++], Sex.fromString(args[i++]), parseDate(argsDf, args[i]));
                    }
                }
                break;
            }
            case "-i": {
                synchronized (allPeople) {
                    for (int i = 1; i < args.length; i++) {
                        read(Integer.parseInt(args[i]));
                    }
                }
                break;
            }
            case "-u": {
                synchronized (allPeople) {
                    for (int i = 1; i < args.length; i++) {
                        update(Integer.parseInt(args[i++]), args[i++],
                                Sex.fromString(args[i++]), parseDate(argsDf, args[i]));
                    }
                }
                break;
            }
            case "-d": {
                synchronized (allPeople) {
                    for (int i = 1; i < args.length; i++) {
                        delete(Integer.parseInt(args[i]));
                    }
                }
                break;
            }
        }
    }
    private static void read(int index) {
        if (!checkIndex(index))
            return;
        Person p = allPeople.get(index);
        StringBuilder sb = new StringBuilder();
        sb.append(p.getName()).append(" ");
        sb.append(p.getSex().getText()).append(" ");

        sb.append(df.format(p.getBirthDate()));

        System.out.println(sb);
    }

    private static void create(String name, Sex sex, Date bd) {
        Person p = null;
        if (sex == Sex.MALE) {
            p = Person.createMale(name, bd);
        } else {
            p = Person.createFemale(name, bd);
        }
        allPeople.add(p);
        System.out.println(allPeople.size() - 1);
    }

    private static void update(int index, String name, Sex sex, Date bd) {
        if (!checkIndex(index))
            return;
        Person p = allPeople.get(index);
        p.setSex(sex);
        p.setName(name);
        p.setBirthDate(bd);
    }

    private static void delete(int index) {
        if (!checkIndex(index))
            return;
        Person p = allPeople.get(index);
        p.setName(null);
        p.setSex(null);
        p.setBirthDate(null);
    }

    private static boolean checkIndex(int index) {
        if (index > allPeople.size() - 1)
            return false;
        return true;
    }

    private static Date parseDate(SimpleDateFormat df, String date) {
        Date retVal;
        try {
            retVal = df.parse(date);
        } catch (ParseException e) {
            throw new RuntimeException(e);
        }
        return retVal;
    }
}
