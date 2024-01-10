namespace Week1;
/*
* Time Conversion
* 
* Given a time in 12-hour AM/PM format, convert it to military (24-hour) time.
* Note:
* - 12:00:00AM on a 12-hour clock is 00:00:00 on a 24-hour clock.
* - 12:00:00PM on a 12-hour clock is 12:00:00 on a 24-hour clock.
* 
* Example
* s = '12:01:00PM'
* Return '12:01:00'.
* 
* s = '12:01:00AM'
* Return '00:01:00'.
* 
* Function Description
* Complete the timeConversion function in the editor below.
* It should return a new string representing the input time in 24 hour format.
* timeConversion has the following parameter(s):
* string s: a time in 12 hour format
* Returns
* string: the time in 24 hour format
* 
*/
public class TimeConversionTask
{
    public static string TimeConversion(string s)
    {
        var timeParts = s.Split(':');
        var ampm = timeParts[2].Substring(2);
        var hours = string.Format("{0:00}", int.Parse(timeParts[0]) % 12 + (ampm == "AM" ? 0 : 12));
        return $"{hours}:{timeParts[1]}:{timeParts[2].Substring(0, 2)}";
    }
    
}

