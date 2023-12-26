/*
 * Exercise: 60
 * For the database with money transactions being recorded not more than once a day,
 * calculate the cash balance of each buy-back center at the beginning of 4/15/2001.
 * Note: exclude centers not having any records before the specified date.
 * Result set: point, balance
*/
SELECT [point]
       , SUM([Amount]) [Remain]
FROM (
SELECT i.[point]
       , i.[date]
	   , i.[inc] [Amount]
FROM [dbo].[Income_o] i

UNION ALL
SELECT o.[point]
       , o.[date]
       , -o.[out]
FROM [dbo].[Outcome_o] o) sub
WHERE [date] < '2001-04-15'
GROUP BY sub.[point]