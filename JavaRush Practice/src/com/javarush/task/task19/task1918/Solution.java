package com.javarush.task.task19.task1918;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.parser.Parser;
import org.jsoup.select.Elements;

import java.io.*;

/* 
Знакомство с тегами
*/

public class Solution {
    public static void main(String[] args) {
        String tag = args[0];
        StringBuilder sb = new StringBuilder();
        try(BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
            BufferedReader fileReader = new BufferedReader(new FileReader(reader.readLine()))) {
            while (fileReader.ready()) {
                sb.append((char)fileReader.read());
            }
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

        Document document = Jsoup.parse(sb.toString(), "", Parser.xmlParser());
        Elements elements = document.getElementsByTag(tag);
        elements.forEach(System.out::println);
    }
}
