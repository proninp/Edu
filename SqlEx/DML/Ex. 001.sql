/*
 * Exercise: 1
 * Find the model number, speed and hard drive capacity for all the PCs with prices below $500.
 * Result set: model, speed, hd.
*/
SELECT model,
       speed,
	   hd
FROM [dbo].[PC]
WHERE [price] < 500