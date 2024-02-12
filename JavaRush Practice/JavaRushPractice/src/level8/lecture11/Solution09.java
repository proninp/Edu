package level8.lecture11;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.Locale;

public class Solution09 {

    public static void main(String[] args) throws ParseException {
        try
        {
            System.out.println(isDateOdd("JANUARY 2 2020"));
        }
        catch(ParseException ignored)
        {

        }

    }
    public static boolean isDateOdd(String date) throws ParseException {
        SimpleDateFormat formatter =
                new SimpleDateFormat("MMMM d yyyy", Locale.ENGLISH);
        Calendar calendar = new GregorianCalendar();
        calendar.setTime(formatter.parse(date));
        int dayOfYear = calendar.get(Calendar.DAY_OF_YEAR);
        return (dayOfYear & 1) == 1;
    }
}
