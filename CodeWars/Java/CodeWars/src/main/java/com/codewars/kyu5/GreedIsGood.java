package main.java.com.codewars.kyu5;

import java.util.HashMap;
import java.util.Map;

public class GreedIsGood {
    public static int greedy(int[] dice){
        Map<Integer, Integer> map = new HashMap<>();
        for (int d : dice) {
            map.put(d, map.containsKey(d) ? (map.get(d) + 1) : 1);
        }
        int score = 0;
        for(Map.Entry<Integer, Integer> entry: map.entrySet()) {
            int key = entry.getKey();
            int value = entry.getValue();
            int triple = value / 3;
            int remain = value - (triple * 3);
            switch (key) {
                case 1 -> score += triple * 1000 + remain * 100;
                case 2 -> score += triple * 200;
                case 3 -> score += triple * 300;
                case 4 -> score += triple * 400;
                case 5 -> score += triple * 500 + remain * 50;
                case 6 -> score += triple * 600;
            }
        }
        return score;
    }
}
