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
        while(true)
        {
            var phrase = Console.ReadLine();
            if (phrase is null)
                break;
            inputLines.Add(phrase);
        }
        var resSb = new StringBuilder();
        foreach (var line in inputLines)
        {
            var sbLine = new StringBuilder();
            var inLine = line.Split(';');
            if (inLine[0] == "S")
            {
                if (inLine[1] == "M")
                    inLine[2] = string.Concat(inLine[2].Substring(0, 1).ToUpper(), 
                                              inLine[2].Substring(1, inLine[2].Length - 3));
                foreach (var c in inLine[2])
                {
                    if (char.IsUpper(c) && sbLine.Length > 0)
                        sbLine.Append(' ');
                    sbLine.Append(char.ToLower(c));
                }
            }
            else if (inLine[0] == "C")
            {
                var words = inLine[2].Split(' ');
                if (inLine[1] == "C")
                    sbLine.Append(string.Concat(words[0].Substring(0, 1).ToUpper(),
                                            words[0].Substring(1)));
                else
                    sbLine.Append(words[0]);
                sbLine.Append(string.Join("",
                                      words.Skip(1)
                                            .Select(e => string.Concat(e.Substring(0, 1).ToUpper(),
                                                                       e.Substring(1)))
                                            .ToArray()));
                if (inLine[1] == "M")
                    sbLine.Append("()");
            }
            else
            {
                throw new NotImplementedException();
            }
            resSb.Append(sbLine.ToString());
            resSb.Append(Environment.NewLine);
        }
        Console.WriteLine(resSb.ToString());
    }
}

