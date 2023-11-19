/*
 * Exercise: 25
 * Find the printer makers also producing PCs with the lowest RAM capacity
 * and the highest processor speed of all PCs having the lowest RAM capacity.
 * Result set: maker.
*/
WITH q AS (
	SELECT p.[model]
		   , p.[maker]
		   , pc.[speed]
	FROM [dbo].[PC] pc
	JOIN [dbo].[Product] p ON p.model = pc.model
	WHERE [ram] = (SELECT MIN([ram]) FROM [dbo].[PC]))
SELECT DISTINCT q.[maker]
FROM q
JOIN (
	SELECT [maker]
	FROM [dbo].[Product]
	WHERE [type] = 'Printer' AND [maker] IN
	(SELECT [maker] FROM [dbo].[Product] WHERE [type] = 'PC')) sub
ON q.maker = sub.maker
WHERE q.[speed] = (SELECT MAX([speed]) FROM q)