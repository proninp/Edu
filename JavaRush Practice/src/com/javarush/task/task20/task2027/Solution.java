package com.javarush.task.task20.task2027;

import java.util.ArrayList;
import java.util.List;

/* 
Кроссворд
*/

public class Solution {
    public static void main(String[] args) {
        int[][] crossword = new int[][]{
                {'f', 'd', 'e', 'r', 'l', 'k'},
                {'u', 's', 'a', 'm', 'e', 'o'},
                {'l', 'n', 'g', 'r', 'o', 'v'},
                {'m', 'l', 'p', 'r', 'r', 'h'},
                {'p', 'o', 'e', 'e', 'j', 'j'}
        };
        List<Word> wordsList = detectAllWords(crossword, "home", "same");
        wordsList.forEach(System.out::println);
        /*
Ожидаемый результат
home - (5, 3) - (2, 0)
same - (1, 1) - (4, 1)
         */
    }

    public static List<Word> detectAllWords(int[][] crossword, String... words) {
        List<Word> wordsList = new ArrayList<>();
        for (String word: words) {
            wordsList.add(detectWord(crossword, word));
        }
        return wordsList;
    }
    public static Word detectWord(int[][] crossword, String word) {
        Word wordToAdd = new Word(word);
        for (int y = 0; y < crossword.length; y++) {
            for (int x = 0; x < crossword[y].length; x++) {
                if ((char)crossword[y][x] == word.charAt(0)) {
                    wordToAdd.setStartPoint(x, y);
                    if (checkWord(wordToAdd, crossword, word, y, x, -1, -1)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, 1, -1)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, -1, 1)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, 1, 1)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, -1, 0)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, 1, 0)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, 0, -1)) {
                        return wordToAdd;
                    }
                    if (checkWord(wordToAdd, crossword, word, y, x, 0, 1)) {
                        return wordToAdd;
                    }
                }
            }
        }
        return wordToAdd;
    }

    public static boolean checkWord(Word wordToAdd, int[][] crossword, String seekWord, int y, int x, int stepY, int stepX) {
        int wordSize = seekWord.length();
        int lastX = x + stepX * (wordSize - 1);
        int lastY = y + stepY * (wordSize - 1);
        if (lastX < 0 || lastX >= crossword[y].length || lastY < 0 || lastY >= crossword.length)
            return false;
        for (int i = 1; i < wordSize; i++) {
            x += stepX;
            y += stepY;
            if (seekWord.charAt(i) != crossword[y][x])
                return false;
        }
        wordToAdd.setEndPoint(lastX, lastY);
        return true;
    }

    public static class Word {
        private String text;
        private int startX;
        private int startY;
        private int endX;
        private int endY;

        public Word(String text) {
            this.text = text;
        }

        public void setStartPoint(int i, int j) {
            startX = i;
            startY = j;
        }

        public void setEndPoint(int i, int j) {
            endX = i;
            endY = j;
        }

        @Override
        public String toString() {
            return String.format("%s - (%d, %d) - (%d, %d)", text, startX, startY, endX, endY);
        }
    }
}
