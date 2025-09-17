package main.java.com.codewars.kyu7.сomplementaryDNA;

public class DnaStrand {
    public static String makeComplement(String dna) {
        var sb = new StringBuilder(dna.length());
        for (int i = 0; i < dna.length(); i++) {
            switch (dna.charAt(i)) {
                case 'A':
                    sb.append('T');
                    break;
                case 'T':
                    sb.append('A');
                    break;
                case 'C':
                    sb.append('G');
                    break;
                case 'G':
                    sb.append('C');
                    break;
            }
        }
        return sb.toString();
    }
}
