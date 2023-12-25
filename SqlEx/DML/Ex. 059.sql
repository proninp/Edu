/*
 * Exercise: 59
 * Calculate the cash balance of each buy-back center for the database
 * with money transactions being recorded not more than once a day.
 * Result set: point, balance.
*/
SELECT [point]
       , SUM([Amount]) [Remain]
FROM (
SELECT i.[point]
       , i.[inc] [Amount]
FROM [dbo].[Income_o] i
UNION ALL
SELECT o.[point]
       , -o.[out]
FROM [dbo].[Outcome_o] o) sub
GROUP BY sub.[point]