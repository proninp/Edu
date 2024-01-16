namespace Week2;

/*
 * Grading Students
 * 
 * HackerLand University has the following grading policy:
 *  Every student receives a grade in the inclusive range from 0 to 100.
 *  Any grade less than 40 is a failing grade.
 * Sam is a professor at the university and likes to round each student's grade according to these rules:
 *  If the difference between the grade and the next multiple of 5 is less than 3, round grade up to the next multiple of 5.
 *  If the value of grade is less than 38, no rounding occurs as the result will still be a failing grade.
 *  
 * Examples:
 *  grade = 84 round to 85 (85 - 84 is less than 3)
 *  grade = 29 do not round (result is less than 40)
 *  grade = 57 do not round (60 - 57 is 3 or higher)
 * 
 * Given the initial value of grade for each of Sam's  students, write
 * code to automate the rounding process.
 * 
 * Function Description
 * Complete the function GradingStudents in the editor below.
 * GradingStudents has the following parameter(s):
 *  int grades[n]: the grades before rounding
 *  
 * Returns
 *  int[n]: the grades after rounding as appropriate
 */

public class GradingStudentsTask
{
    public static List<int> GradingStudents(List<int> grades)
    {
        var roundedGrades = new List<int>(grades.Count);
        foreach(var grade in grades)
        {
            var newGrade = grade;
            if (grade > 37 && grade % 5 != 0)
            {
                var nextMultipleOf5 = ((grade / 5) + 1) * 5;
                if (nextMultipleOf5 - grade < 3)
                    newGrade = nextMultipleOf5;
            }
            roundedGrades.Add(newGrade);
        }
        return roundedGrades;
    }
}
