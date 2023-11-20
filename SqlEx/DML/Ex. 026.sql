/*
 * Exercise: 26
 * Find out the average price of PCs and laptops produced by maker A.
 * Result set: one overall average price for all items.
*/
SELECT AVG([price]) [price]
FROM (
	SELECT [price]
	FROM [dbo].[PC] pc
	JOIN [dbo].[Product] p ON p.model = pc.model AND p.maker = 'A'
	UNION ALL
	SELECT [price]
	FROM [dbo].[Laptop] l
	JOIN [dbo].[Product] p ON p.model = l.model AND p.maker = 'A'
) q