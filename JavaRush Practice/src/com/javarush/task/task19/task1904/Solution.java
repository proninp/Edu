package com.javarush.task.task19.task1904;

import java.io.IOException;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;
import java.util.Scanner;

/* 
И еще один адаптер
*/

public class Solution {

    public static void main(String[] args) {
    }

    public static class PersonScannerAdapter implements PersonScanner {
        private final Scanner fileScanner;

        public PersonScannerAdapter(Scanner fileScanner) {
            this.fileScanner = fileScanner;
        }

        @Override
        public Person read() throws IOException {
            String[] lineParts = fileScanner.nextLine().split(" ");

            int year = Integer.parseInt(lineParts[5]);
            int month = Integer.parseInt(lineParts[4]) - 1;
            int day = Integer.parseInt(lineParts[3]);

            GregorianCalendar calendar = new GregorianCalendar(year, month, day);
            return new Person(lineParts[1], lineParts[2], lineParts[0], calendar.getTime());
        }

        @Override
        public void close() throws IOException {
            fileScanner.close();
        }
    }
}
