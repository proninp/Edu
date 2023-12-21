/*
 * Exercise: 55
 * If the lead ship’s year of launch is not known, get the minimum year of launch for the ships of this class.
 * Result set: class, year.
*/
SELECT c.[class]
       , MIN(s.launched) [launched]
FROM [Classes] c
LEFT JOIN [Ships] s ON s.[class] = c.[class]
GROUP BY c.[class]