/*
 * Exercise: 30
 * Under the assumption that receipts of money (inc) and payouts (out)
 * can be registered any number of times a day for each collection point [i.e. the code column is the primary key],
 * display a table with one corresponding row for each operating date of each collection point.
 * Result set: point, date, total payout per day (out), total money intake per day (inc).
 * Missing values are considered to be NULL.
*/
SELECT point
       , [date]
	   , SUM(Outcome) Outcome
	   , SUM(Income) Income
FROM (
	SELECT point
		   , [date]
		   , NULL Outcome
		   , i.inc Income
	FROM [dbo].[Income] i
	UNION ALL
	SELECT point
		   , [date]
		   , [out] Outcome
		   , NULL Income
	FROM [dbo].[Outcome] i) oi
GROUP BY point
       , [date]