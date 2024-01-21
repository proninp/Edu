namespace Namespace;

/*
 * Mars Exploration
 * 
 * A space explorer's ship crashed on Mars! They send a series of SOS
 * messages to Earth for help.
 * Letters in some of the SOS messages are altered by cosmic radiation during
 * ransmission. Given the signal received by Earth as a string, s, determine
 * how many letters of the SOS message have been changed by radiation.
 * 
 * Function Description
 * Complete the MarsExploration function in the editor below.
 * MarsExploration has the following parameter(s):
 *  string s: the string as received on Earth
 * Returns
 *  int: the number of letters changed during transmission
 */
public class MarsExplorationTask
{
    public static int MarsExploration(string s)
    {
        var template = "SOS";
        var changedLettersCount = 0;
        for(int i = 0; i < s.Length; i++)
            if (s[i] != template[i % 3])
                changedLettersCount++;
        return changedLettersCount;
    }
}
