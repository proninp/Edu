package com.javarush.task.task19.task1917;

import java.io.*;

/* 
Свой FileWriter
*/

public class FileConsoleWriter {
    private FileWriter fileWriter;
    private BufferedWriter console = new BufferedWriter(new OutputStreamWriter(System.out));

    public FileConsoleWriter(String fileName) throws IOException {
        fileWriter = new FileWriter(fileName);
    }

    public FileConsoleWriter(String fileName, boolean append) throws IOException {
        fileWriter = new FileWriter(fileName, append);
    }

    public FileConsoleWriter(File file) throws IOException {
        fileWriter = new FileWriter(file);
    }

    public FileConsoleWriter(File file, boolean append) throws IOException {
        fileWriter = new FileWriter(file, append);
    }

    public FileConsoleWriter(FileDescriptor fd) {
        fileWriter = new FileWriter(fd);
    }

    public void write(char[] cbuf, int off, int len) throws IOException {
        fileWriter.write(cbuf, off, len);
        console.write(cbuf, off, len);
        console.flush();
    }

    public void write(int c) throws IOException {
        fileWriter.write(c);
        console.write(c);
        console.flush();
    }

    public void write(String str) throws IOException {
        fileWriter.write(str);
        console.write(str);
        console.flush();
    }

    public void write(String str, int off, int len) throws IOException {
        fileWriter.write(str, off, len);
        console.write(str, off, len);
        console.flush();
    }

    public void write(char[] cbuf) throws IOException {
        fileWriter.write(cbuf);
        console.write(cbuf);
        console.flush();
    }

    public void close() throws IOException {
        fileWriter.close();
        console.flush();
        console.close();
    }

    public static void main(String[] args) {

    }

}
