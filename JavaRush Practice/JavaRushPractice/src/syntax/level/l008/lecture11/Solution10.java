package syntax.level.l008.lecture11;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.List;

public class Solution10 {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        String monthString = reader.readLine();
        List<String> months = new ArrayList<>(12);
        months.add("january");
        months.add("february");
        months.add("march");
        months.add("april");
        months.add("may");
        months.add("june");
        months.add("july");
        months.add("august");
        months.add("september");
        months.add("october");
        months.add("november");
        months.add("december");
        int monthNumber = months.indexOf(monthString.toLowerCase()) + 1;
        System.out.printf("%s is the %d month", monthString, monthNumber);
    }
}
