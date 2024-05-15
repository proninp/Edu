package com.javarush.task.task19.task1921;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.*;

/* 
Хуан Хуанович
*/

public class Solution {
    public static final List<Person> PEOPLE = new ArrayList<Person>();

    public static void main(String[] args) {
        try(BufferedReader reader = new BufferedReader(new FileReader(args[0]))) {
            while (reader.ready()) {
                String[] words = reader.readLine().split(" ");
                String dateText = String.join(" ",
                        Arrays.stream(words).skip(words.length - 3).toArray(String[]::new));
                SimpleDateFormat format = new SimpleDateFormat("dd MM yyyy");
                String username = String.join(" ",
                        Arrays.stream(words).limit(words.length - 3).toArray(String[]::new));
                PEOPLE.add(new Person(username, format.parse(dateText)));
            }
        } catch (IOException | ParseException e) {
            throw new RuntimeException(e);
        }
    }
}
