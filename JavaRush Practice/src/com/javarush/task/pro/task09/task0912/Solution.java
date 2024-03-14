package com.javarush.task.pro.task09.task0912;

/* 
Проверка URL-адреса
*/

public class Solution {
    public static void main(String[] args) {
        String[] urls = {"https://javarush.ru", "https://google.com", "http://wikipedia.org", "facebook.com", "https://instagram", "codegym.cc"};
        for (String url : urls) {
            String protocol = checkProtocol(url);
            String domain = checkDomain(url);

            System.out.println("У URL-адреса - " + url + ", сетевой протокол - " + protocol + ", домен - " + domain);
        }
    }

    public static String checkProtocol(String url) {
        String https = "https";
        String http = "http";
        if (url.startsWith(https))
            return https;
        if (url.startsWith(http))
            return http;
        return "неизвестный";
    }

    public static String checkDomain(String url) {
        String com = "com";
        String net = "net";
        String org = "org";
        String ru = "ru";
        if (url.endsWith(".".concat(com))) {
            return com;
        } else if (url.endsWith(".".concat(net))) {
            return net;
        } else if (url.endsWith(".".concat(org))) {
            return org;
        } else if (url.endsWith(".".concat(ru))) {
            return ru;
        } else
            return "неизвестный";
    }
}
