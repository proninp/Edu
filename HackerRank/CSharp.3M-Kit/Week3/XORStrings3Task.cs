using System.Text;

namespace Week3;

/*
 * XOR Strings 3
 * 
 * In this challenge, the task is to debug the existing code to successfully execute all provided test files.
 * Given two strings consisting of digits 0 and 1 only, find the XOR of the two strings.
 * Debug the given function Strings_xor to find the XOR of the two given strings appropriately.
 * Note: You can modify at most three lines in the given code and you cannot add or remove lines to the code.
 * To restore the original code, click on the icon to the right of the language selector.
 * 
 * Input Format
 * The input consists of two lines. The first line of the input contains the first string, s, and the second line contains
 * the second string, t.
 * 
 * Output Format
 * Print the string obtained by the XOR of the two input strings in a single line.
 */

public class XORStrings3Task
{
    public static string Strings_xor(string s, string t)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[i])
                sb.Append('0');
            else
                sb.Append('1');
        }
        return sb.ToString();
    }
}
