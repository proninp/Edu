/*
 * Exercise: 39
 * Find the ships that `survived for future battles`; that is, after being damaged in a battle,
 * they participated in another one, which occurred later.
*/
WITH sub AS (
	SELECT o.[ship]
	       , o.[result]
		   , b.[date]
	FROM [Outcomes] o
	JOIN [Battles] b ON o.[battle] = b.[name])
SELECT DISTINCT [ship]
FROM sub f
WHERE [result] = 'damaged' AND EXISTS (
	SELECT 1
	FROM sub s
	WHERE s.ship = f.ship AND s.[date] > f.[date]
)