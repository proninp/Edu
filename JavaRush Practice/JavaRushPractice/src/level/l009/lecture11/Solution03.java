package level.l009.lecture11;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution03 {
    public static void main(String[] args) {
        readData();
    }

    public static void readData() {
        ArrayList<Integer> nums = new ArrayList<>();
        boolean isException = false;
        while(!isException)
        {
            try
            {
                BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
                String input = reader.readLine();
                int number = Integer.parseInt(input);
                nums.add(number);
            }
            catch(NumberFormatException | IOException e)
            {
                isException = true;
            }
        }
        for (int e : nums)
            System.out.println(e);
    }
}
