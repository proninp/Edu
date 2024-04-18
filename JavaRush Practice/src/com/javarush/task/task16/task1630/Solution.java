package com.javarush.task.task16.task1630;

/*
Последовательный вывод файлов
*/

import java.io.*;

public class Solution {
    public static String firstFileName;
    public static String secondFileName;

    static {
        try (BufferedReader consoleReader = new BufferedReader(new InputStreamReader(System.in))) {
            firstFileName = consoleReader.readLine();
            secondFileName = consoleReader.readLine();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void main(String[] args) throws InterruptedException {
        systemOutPrintln(firstFileName);
        systemOutPrintln(secondFileName);
    }

    public static void systemOutPrintln(String fileName) throws InterruptedException {
        ReadFileInterface f = new ReadFileThread();
        f.setFileName(fileName);
        f.start();
        f.join();
        System.out.println(f.getFileContent());
    }

    public interface ReadFileInterface {

        void setFileName(String fullFileName);

        String getFileContent();

        void join() throws InterruptedException;

        void start();
    }

    public static class ReadFileThread extends Thread implements ReadFileInterface {
        private String fullFileName;
        private StringBuffer fileContent;

        public ReadFileThread() {
            this.fileContent = new StringBuffer("");
        }

        @Override
        public void run() {
            try (BufferedReader reader = new BufferedReader(new FileReader(this.fullFileName))) {
                while (reader.ready()) {
                    this.fileContent.append(reader.readLine()).append(" ");
                }
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        }

        @Override
        public void setFileName(String fullFileName) {
            this.fullFileName = fullFileName;
        }
        @Override
        public String getFileContent() {
            return fileContent.toString();
        }
    }
}
