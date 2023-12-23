/*
 * Exercise: 56
 * For each class, find out the number of ships of this class that were sunk in battles.
 * Result set: class, number of ships sunk.
*/
WITH so AS (
	SELECT ISNULL(s.[name], o.[ship]) [ship]
		   , ISNULL(s.[class], o.[ship]) [class]
	FROM [Outcomes] o
	LEFT JOIN [Ships] s ON o.[ship] = s.[name]
	WHERE o.[result] = 'sunk')
SELECT c.[class]
       , COUNT(so.[ship]) [sunk_count]
FROM [Classes] c
LEFT JOIN so ON so.[class] = c.[class]
GROUP BY c.[class]