/*
 * Exercise: 61
 * For the database with money transactions being recorded not more than once a day,
 * calculate the total cash balance of all buy-back centers.
*/
SELECT SUM([Amount]) [Amount]
FROM (
	SELECT i.[inc] [Amount]
	FROM [dbo].[Income_o] i
	UNION ALL
	SELECT -o.[out]
	FROM [dbo].[Outcome_o] o) sub
