package com.javarush.task.task20.task2014;

import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Date;

/* 
Serializable Solution
*/

public class Solution implements Serializable {
    public static void main(String[] args) {
        try {
            File tmpFile = File.createTempFile("task2014", ".tmp");
            BufferedOutputStream writer = new BufferedOutputStream(new FileOutputStream(tmpFile));
            Solution savedObject = new Solution(22);
            ObjectOutputStream outputStream = new ObjectOutputStream(writer);
            outputStream.writeObject(savedObject);
            writer.close();
            outputStream.close();

            BufferedInputStream reader = new BufferedInputStream(new FileInputStream(tmpFile));
            ObjectInputStream objectInputStream = new ObjectInputStream(reader);
            Solution loadedObject = (Solution) objectInputStream.readObject();
            reader.close();
            objectInputStream.close();
            System.out.println(loadedObject);
        } catch (IOException | ClassNotFoundException e) {
            throw new RuntimeException(e);
        }
    }

    private transient final String pattern = "dd MMMM yyyy, EEEE";
    private transient Date currentDate;
    private transient int temperature;
    String string;

    public Solution() { }

    public Solution(int temperature) {
        this.currentDate = new Date();
        this.temperature = temperature;

        string = "Today is %s, and the current temperature is %s C";
        SimpleDateFormat format = new SimpleDateFormat(pattern);
        this.string = String.format(string, format.format(currentDate), temperature);
    }

    @Override
    public String toString() {
        return this.string;
    }
}
