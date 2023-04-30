/*
 * Exercise: 9
 * Find the makers of PCs with a processor speed of 450 MHz or more. Result set: maker.
 */

SELECT DISTINCT maker
FROM Product p
JOIN [dbo].[PC] pc ON pc.model = p.model
WHERE type = 'PC' AND speed >= 450