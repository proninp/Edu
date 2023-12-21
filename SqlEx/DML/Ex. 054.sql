/*
 * Exercise: 54
 * With a precision of two decimal places, determine the average
 * number of guns for all battleships (including the ones in the Outcomes table).
*/
SELECT CAST(AVG(c.[numGuns] * 1.00) AS NUMERIC(16, 2)) [Avg_numG]
FROM (
	SELECT [name]
		   , [class]
	FROM [Ships]
	UNION
	SELECT [ship]
		   , [ship]
	FROM [Outcomes]) all_ships
JOIN [Classes] c ON c.[class] = all_ships.class AND c.[type] = 'bb' 