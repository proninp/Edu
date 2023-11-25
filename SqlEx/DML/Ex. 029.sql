/*
 * Exercise: 29
 * Under the assumption that receipts of money (inc) and payouts (out) are registered
 * not more than once a day for each collection point [i.e. the primary key consists of (point, date)],
 * write a query displaying cash flow data (point, date, income, expense).
 * Use Income_o and Outcome_o tables.
*/
SELECT ISNULL(i.[point], o.[point]) point
		, ISNULL(i.[date], o.[date]) [date]
		, i.[inc]
		, o.[out]
FROM [dbo].[Income_o] i
FULL JOIN [dbo].[Outcome_o] o
ON i.point = o.point AND i.[date] = o.[date]
