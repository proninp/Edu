/*
 * Exercise: 37
 * Find classes for which only one ship exists in the database (including the Outcomes table).
*/
SELECT [class]
FROM (
	SELECT s.[class]
               , s.[name]
	FROM [Ships] s
	JOIN [Classes] c ON c.class = s.[class]
	UNION
	SELECT o.[ship]
               , o.[ship]
	FROM [Outcomes] o
	JOIN [Classes] c ON c.class = o.[ship]) q
GROUP BY [class]
HAVING COUNT([name]) = 1