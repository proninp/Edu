using System.Text;

namespace Week1;

/*
 * Camel Case 4
 * 
 * Camel Case is a naming style common in many programming languages.
 * In Java, method and variable names typically start with a lowercase letter,
 * with all subsequent words starting with a capital letter (example: startThread).
 * Names of classes follow the same pattern, except that they start with a capital letter (example: BlueCar).
 * Your task is to write a program that creates or splits Camel Case variable, method, and class names.
 * 
 * Input Format
 * Each line of the input file will begin with an operation (S or C) followed by a semi-colon followed by M, C,
 * or V followed by a semi-colon followed by the words you'll need to operate on.
 * The operation will either be S (split) or C (combine)
 * M indicates method, C indicates class, and V indicates variable
 * In the case of a split operation, the words will be a camel case method,
 * class or variable name that you need to split into a space-delimited list
 * of words starting with a lowercase letter.
 * In the case of a combine operation, the words will be a space-delimited list
 * of words starting with lowercase letters that you need to combine into the appropriate camel case String.
 * Methods should end with an empty set of parentheses to differentiate them from variable names.
 */

public class CamelCase4Task
{
    public static void CamelCase4()
    {
        var inputLines = new List<string>();
        string phrase;
        while ((phrase = Console.ReadLine()) != null)
        {
            inputLines.Add(phrase);
        }
        var resSb = new StringBuilder();
        foreach (var line in inputLines)
        {
            resSb.AppendLine(ConvertToCamelCase(line));
        }
        Console.WriteLine(resSb.ToString());
    }

    private static string ConvertToCamelCase(string input)
    {
        var parts = input.Split(';');
        string part;
        switch (parts[0])
        {
            case "S":
                part = parts[1] == "M" ? char.ToUpper(parts[2][0]).ToString() + parts[2].Substring(1, parts[2].Length - 3) : parts[2];
                return string.Join("", part.Select((x, i) => (i > 0 && char.IsUpper(x) ? " " : "") + char.ToLower(x)));
            case "C":
                var words = parts[2].Split(' ');
                part = parts[1] == "C" ? $"{char.ToUpper(words[0][0])}{words[0].Substring(1)}" : words[0];
                var rest = string.Join("", words.Skip(1).Select(w => $"{char.ToUpper(w[0])}{w.Substring(1)}"));
                return $"{part}{rest}{(parts[1] == "M" ? "()" : "")}";
            default:
                throw new NotImplementedException();
        }
    }
}

