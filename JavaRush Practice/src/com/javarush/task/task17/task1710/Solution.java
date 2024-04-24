package com.javarush.task.task17.task1710;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;

/* 
CRUD
*/

public class Solution {
    public static List<Person> allPeople = new ArrayList<Person>();

    static {
        allPeople.add(Person.createMale("Иванов Иван", new Date()));  //сегодня родился    id=0
        allPeople.add(Person.createMale("Петров Петр", new Date()));  //сегодня родился    id=1
    }

    public static void main(String[] args) {
        SimpleDateFormat df = new SimpleDateFormat("dd/MM/yyyy", Locale.ENGLISH);
        if (args[0].equals("-c")) {
            create(args[1], Sex.fromString(args[2]), parseDate(df, args[3]));
        } else if (args[0].equals("-r")) {
            read(Integer.parseInt(args[1]));
        } else if (args[0].equals("-u")) {
            update(Integer.parseInt(args[1]), args[2], Sex.fromString(args[3]), parseDate(df, args[4]));
        } else if (args[0].equals("-d")) {
            delete(Integer.parseInt(args[1]));
        }
    }
    private static void read(int index) {
        if (!checkIndex(index))
            return;
        Person p = allPeople.get(index);
        StringBuilder sb = new StringBuilder();
        sb.append(p.getName()).append(" ");
        sb.append(p.getSex().getText()).append(" ");

        SimpleDateFormat df = new SimpleDateFormat("dd-MMM-yyyy", Locale.ENGLISH);
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
