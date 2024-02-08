package week1;

/**
 * Time Conversion
 * *
 * Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
 * Note:
 * - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
 * - 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
 * *
 * Example
 * s = '12:01:00PM'
 * Return '12:01:00'.
 * *
 * s = '12:01:00AM'
 * Return '00:01:00'.
 * *
 * Function Description
 * Complete the timeConversion function in the editor below.
 * It should return a new string representing the input time in 24 hour format.
 * timeConversion has the following parameter(s):
 * string s: a time in 12 hour format
 * Returns
 * string: the time in 24 hour format
 */
public class TimeConversion {
    public static String timeConversion(String s) {
        String dayPart = s.substring(8);
        String[] timeParts = s.substring(0, 8).split(":");
        return String.format("%s:%s:%s",
                String.format("%02d",
                        Integer.parseInt(timeParts[0]) % 12 + (dayPart.equals("PM") ? 12 : 0)),
                timeParts[1],
                timeParts[2]);
    }
}
