package com.javarush.task.task18.task1813;

import java.io.*;

/* 
AmigoOutputStream
*/

public class AmigoOutputStream extends FileOutputStream {
    protected FileOutputStream amigoOutputStream;
    public static String fileName = "C:/tmp/result.txt";

    public AmigoOutputStream(FileOutputStream fileOutputStream) throws FileNotFoundException {
        super(fileName);
        this.amigoOutputStream = fileOutputStream;
    }

    @Override
    public void write(int b) throws IOException {
        amigoOutputStream.write(b);
    }

    @Override
    public void write(byte[] b) throws IOException {
        amigoOutputStream.write(b);
    }

    @Override
    public void write(byte[] b, int off, int len) throws IOException {
        amigoOutputStream.write(b, off, len);
    }

    @Override
    public void close() throws IOException {
        amigoOutputStream.flush();
        amigoOutputStream.write("JavaRush © All rights reserved.".getBytes());
        amigoOutputStream.close();
    }

    @Override
    public void flush() throws IOException {
        amigoOutputStream.flush();
    }

    public static void main(String[] args) throws FileNotFoundException {
        new AmigoOutputStream(new FileOutputStream(fileName));
    }

}
