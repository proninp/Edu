/*
 * Exercise: 62
 * For the database with money transactions being recorded not more than once a day,
 * calculate the total cash balance of all buy-back centers at the beginning of 04/15/2001.
*/
SELECT SUM([Amount]) [Amount]
FROM (
	SELECT i.[inc] [Amount]
	       , i.[date]
	FROM [dbo].[Income_o] i
	UNION ALL
	SELECT -o.[out]
	       , o.[date]
	FROM [dbo].[Outcome_o] o) sub
WHERE sub.[date] < '2001-04-15'