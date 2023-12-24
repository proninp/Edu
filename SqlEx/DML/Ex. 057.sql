/*
 * Exercise: 57
 * For classes having irreparable combat losses and at least three ships in the database,
 * display the name of the class and the number of ships sunk.
*/
WITH sh AS (
	SELECT [class]
	FROM (
		SELECT [name]
			   , [class]
		FROM [Ships]
		UNION
		SELECT [ship]
			   , [ship]
		FROM [Outcomes]) q
	GROUP BY [class]
	HAVING COUNT([name]) > 2)
SELECT qs.[class]
	   , COUNT(qs.[ship]) [ships_count]
FROM (
	SELECT ISNULL(s.[class], o.[ship]) [class]
			, ISNULL(s.[name], o.[ship]) [ship]
	FROM [Outcomes] o
	LEFT JOIN [Ships] s ON o.[ship] = s.[name]
	WHERE o.[result] = 'sunk') qs
JOIN sh ON sh.[class] = qs.[class]
GROUP BY qs.[class]