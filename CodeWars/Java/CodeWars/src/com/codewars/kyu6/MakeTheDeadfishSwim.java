package com.codewars.kyu6;

import java.util.ArrayList;

public class MakeTheDeadfishSwim {
    public static int[] parse(String data) {
        int res = 0;
        ArrayList<Integer> list = new ArrayList<>();
        for (int i = 0; i < data.length(); i++) {
            if ((data.charAt(i) == 'i'))
                res++;
            else if (data.charAt(i) == 'd')
                res--;
            else if (data.charAt(i) == 's')
                res *= res;
            else if (data.charAt(i) == 'o')
                list.add(res);
        }
        return list.stream().mapToInt(i -> i).toArray();
    }
}
