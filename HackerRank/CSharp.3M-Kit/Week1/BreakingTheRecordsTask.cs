namespace Week1;

/*
 * Breaking the Records
 * 
 * Maria plays college basketball and wants to go pro.
 * Each season she maintains a record of her play.
 * She tabulates the number of times she breaks her season record for most points and least points in a game.
 * Points scored in the first game establish her record for the season, and she begins counting from there.
 * 
 * Example
 * scores = [12, 24, 10, 24]
 * Scores are in the same order as the games played. She tabulates her results as follows:
 *                                  Count
 *   Game  Score  Minimum  Maximum   Min Max
 *    0      12     12       12       0   0
 *    1      24     12       24       0   1
 *    2      10     10       24       1   1
 *    3      24     10       24       1   1
 *    
 * Given the scores for a season, determine the number of times
 * Maria breaks her records for most and least points scored during the season.
 */

public class BreakingTheRecordsTask
{
    public static List<int> BreakingRecords(List<int> scores)
    {
        var res = new List<int> { 0, 0 };
        var maxMin = new int[] { scores[0], scores[0] };
        for (int i = 1; i < scores.Count; i++)
        {
            if (scores[i] > maxMin[0])
            {
                maxMin[0] = scores[i];
                res[0]++;
            }
            else if (scores[i] < maxMin[1])
            {
                maxMin[1] = scores[i];
                res[1]++;
            }
        }
        return res;
    }
}
