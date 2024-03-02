package level.l003.lecture03;

import java.io.*;
import java.util.ArrayList;

public class Solution11 {
    public static void main(String[] args) throws IOException {
        BufferedReader reader =
                new BufferedReader(new InputStreamReader(System.in));
        String filePath = reader.readLine();
        reader.close();

        ArrayList<Integer> list = new ArrayList<>();

        InputStreamReader r = new FileReader(filePath);
        BufferedReader fileReader = new BufferedReader(r);
        while(fileReader.ready()) {
            int n = Integer.parseInt(fileReader.readLine());
            if (n % 2 == 0)
                list.add(n);
        }
        fileReader.close();
        list.stream().sorted().forEach(System.out::println);
    }
}
