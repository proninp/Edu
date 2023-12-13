/*
 * Exercise: 47
 * Find the countries that have lost all their ships in battles.
*/
WITH sub AS (
	SELECT c.[country]
			, COUNT(*) [cnt]
	FROM [Outcomes] o
	FULL JOIN [Ships] s ON s.[name] = o.[ship]
	LEFT JOIN [Classes] c ON c.[class] = s.[class] OR c.[class] = o.[ship]
	WHERE o.[result] = 'sunk'
	GROUP BY c.[country]
)
SELECT [country]
FROM (
	SELECT s.[name]
		   , c.[class]
		   , c.[country]
	FROM [Ships] s
	JOIN [Classes] c ON c.[class] = s.[class]
	UNION
	SELECT o.[ship]
		   , c.[class]
		   , c.[country]
	FROM [Outcomes] o
	JOIN [Classes] c ON c.[class] = o.[ship]) q
GROUP BY q.[country]
HAVING COUNT(*) = (SELECT [cnt] FROM sub WHERE sub.[country] = q.[country])