namespace Week3;

/*
 * Maximum Perimeter Triangle
 * 
 * Given an array of stick lengths, use 3 of them to construct a non-degenerate triangle with the maximum
 * possible perimeter. Return an array of the lengths of its sides as 3 integers in non-decreasing order.
 * If there are several valid triangles having the maximum perimeter:
 * 1. Choose the one with the longest maximum side.
 * 2. If more than one has that maximum, choose from them the one with the longest minimum side.
 * 3. If more than one has that maximum as well, print any one them.
 * If no non-degenerate triangle exists, return [-1].
 * 
 * Function Description
 * Complete the MaximumPerimeterTriangle function in the editor below.
 * MaximumPerimeterTriangle has the following parameter(s):
 *  int sticks[n]: the lengths of sticks available
 *  
 * Returns
 *  int[3] or int[1]: the side lengths of the chosen triangle in non-decreasing order or -1
 */


public class MaximumPerimeterTriangleTask
{
    public static List<int> MaximumPerimeterTriangle(List<int> sticks)
    {
        var sides = sticks.OrderByDescending(x => x).ToList();
        for (int i = 0; i < sides.Count - 2; i++)
        {
            if (sides[i] < sides[i + 1] + sides[i + 2])
                return new List<int>() { sides[i + 2], sides[i + 1], sides[i] };
        }
        return new List<int>() { -1 };
    }
}
