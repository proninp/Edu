package level.l003.lecture03;

import java.io.*;

public class Solution03 {
    public static void main(String[] args) throws IOException {
        BufferedReader reader =
                new BufferedReader(new InputStreamReader(System.in));
        String filePath = reader.readLine();
        reader.close();

        InputStream inStream = new FileInputStream(filePath);
        BufferedInputStream buffer = new BufferedInputStream(inStream);
        while(buffer.available() > 0) {
            System.out.print((char)buffer.read());
        }
        buffer.close();
    }
}
