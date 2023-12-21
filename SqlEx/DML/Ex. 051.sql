/*
 * Exercise: 51
 * Find the names of the ships with the largest number of guns among all
 * ships having the same displacement (including ships in the Outcomes table).
*/
WITH cs AS (
	SELECT [name] 
	       , c.[class]
		, c.[displacement]
		, c.[numGuns]
	FROM (
		SELECT [name]
		       , [class]
		FROM [Ships] s
		UNION
		SELECT [ship]
			, [ship]
		FROM [Outcomes]) q
	JOIN [Classes] c ON c.[class] = q.[class])
SELECT cs.[name]
FROM cs JOIN (
	SELECT cs.[displacement]
		   , MAX(cs.[numGuns]) numGuns
	FROM cs
	GROUP BY cs.[displacement]
	) cs2 ON cs.[displacement] = cs2.[displacement] AND
		  cs.[numGuns] = cs2.[numGuns]