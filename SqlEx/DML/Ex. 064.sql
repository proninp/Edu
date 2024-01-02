/*
 * Exercise: 64
 * Using the Income and Outcome tables, determine for each buy-back center the days
 * when it received funds but made no payments, and vice versa.
 * Result set: point, date, type of operation (inc/out), sum of money per day.
*/
WITH I AS (SELECT [point]
                  , [date]
	              , SUM([inc]) [amt]
		   FROM [Income] 
		   GROUP BY [point]
                    , [date])
, O AS (SELECT [point]
                  , [date]
	              , SUM([out]) [amt]
		   FROM [Outcome] 
		   GROUP BY [point]
                    , [date])
SELECT ISNULL(I.[point], O.[point]) [point]
       , ISNULL(I.[date], O.[date]) [date]
	   , CASE WHEN O.[point] IS NULL THEN 'inc' ELSE 'out' END [type]
	   , ISNULL(I.[amt], O.[amt]) [amt]
FROM I
FULL JOIN O ON I.[point] = O.[point] AND I.[date] = O.[date]
WHERE I.[amt] IS NULL OR O.[amt] IS NULL