/*
 * Exercise: 48
 * Find the ship classes having at least one ship sunk in battles.
*/
WITH o AS (
	SELECT [ship]
	FROM [Outcomes] o
	WHERE o.[result] = 'sunk')
SELECT s.[class]
FROM o
JOIN [Ships] s ON s.[name] = o.[ship]
UNION
SELECT c.[class]
FROM o
JOIN [Classes] c ON c.[class] = o.[ship]