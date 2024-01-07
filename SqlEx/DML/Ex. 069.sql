/*
 * Exercise: 69
 * Using the Income and Outcome tables, find out the balance for each buy-back center
 * by the end of each day when funds were received or payments were made.
 * Note that the cash isn’t withdrawn, and the unspent balance/debt is carried forward to the next day.
 * Result set: buy-back center ID (point), date in dd/mm/yyyy format, unspent balance/debt by the end of this day.
*/
WITH res AS (
	SELECT [code]
		   , [point]
		   , [date]
		   , [inc] [Remain]
	FROM [Income]
	UNION ALL
	SELECT [code]
		   , [point]
		   , [date]
		   , -[out]
	FROM [Outcome])
SELECT [point]
       , CONVERT(VARCHAR, [date], 103) [date]
	   , SUM([Remain]) OVER (PARTITION BY [point]
	                   ORDER BY [date] RANGE UNBOUNDED PRECEDING) [Remain]
FROM (
	SELECT [point]
	       , [date]
		   , SUM([Remain]) [Remain]
	FROM res
	GROUP BY [point]
	         , [date]
	) [sub]
ORDER BY [point]
       , [date]