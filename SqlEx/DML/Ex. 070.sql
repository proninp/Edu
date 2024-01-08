/*
 * Exercise: 70
 * Get the battles in which at least three ships from the same country took part.
*/
SELECT DISTINCT s.[battle]
FROM (
	SELECT ISNULL(s.[name], o.[ship]) [name]
		   , ISNULL(s.[class], o.[ship]) [class]
		   , [battle]
	FROM [Outcomes] o
	LEFT JOIN [Ships] s ON s.[name] = o.[ship]) s
JOIN [Classes] c ON c.[class] = s.[class]
GROUP BY s.[battle]
	   , c.[country]
HAVING COUNT(s.[name]) > 2