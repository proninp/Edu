package org.Stepik.JavaBasicCourse;
import java.lang.CharSequence;
import java.lang.reflect.Array;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;

public class AsciiCharSequence implements CharSequence{
    private final byte[] bArray;
    public AsciiCharSequence(byte[] array) {
        bArray = array;
    }
    @Override
    public int length() {
        return bArray.length;
    }

    @Override
    public char charAt(int index) {
        return (index >= 0 && index < bArray.length) ? (char)bArray[index] : '\u0000';
    }

    @Override
    public CharSequence subSequence(int start, int end) {
        return new AsciiCharSequence(Arrays.copyOfRange(this.bArray, start, end));
    }

    @Override
    public String toString() {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < bArray.length; i++) {
            stringBuilder.append((char)bArray[i]);
        }
        return stringBuilder.toString();
    }
}