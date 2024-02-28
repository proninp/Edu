package core.level.l003.lecture03;

import java.io.*;

public class Solution04 {
    public static void main(String[] args) throws IOException {
        BufferedReader reader =
                new BufferedReader(new InputStreamReader(System.in));
        String filePath = reader.readLine();

        FileWriter fileWriter = new FileWriter(filePath);
        BufferedWriter bfWriter = new BufferedWriter(fileWriter);

        String line = "";
        StringBuilder sb = new StringBuilder();
        while(line != null && !line.equals("exit")) {
            line = reader.readLine();
            sb.append(line).append("\n");
        }
        reader.close();

        bfWriter.write(sb.toString());
        bfWriter.close();
    }
}
