/*
 * Exercise: 66
 * For all days between 2003-04-01 and 2003-04-07 find the number of trips from Rostov with passengers aboard.
 * Result set: date, number of trips.
*/
WITH dates AS (
	SELECT CAST('2003-04-01' AS DATETIME) [date]
	UNION ALL
	SELECT CAST('2003-04-02' AS DATETIME) 
	UNION ALL
	SELECT CAST('2003-04-03' AS DATETIME) 
	UNION ALL
	SELECT CAST('2003-04-04' AS DATETIME) 
	UNION ALL
	SELECT CAST('2003-04-05' AS DATETIME) 
	UNION ALL
	SELECT CAST('2003-04-06' AS DATETIME) 
	UNION ALL
	SELECT CAST('2003-04-07' AS DATETIME))
SELECT d.[date]
       , ISNULL(sub.[trips], 0) [flights]
FROM [dates] d
LEFT JOIN (
	SELECT pt.[date]
	       , COUNT(DISTINCT t.[trip_no]) [trips]
	FROM [Trip] t
	JOIN [Pass_in_trip] pt ON pt.[trip_no] = t.[trip_no]
	WHERE [town_from] = 'Rostov'
	GROUP BY pt.[date]
) sub ON sub.[date] = d.[date]