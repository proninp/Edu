/*
 * Exercise: 13
 * Find out the average speed of the PCs produced by maker A.

 */

SELECT AVG(speed) speed
FROM PC
JOIN [dbo].[Product] p ON p.model = pc.model
WHERE p.type = 'PC' AND p.maker = 'A'
