/*
 * Exercise: 15
 * Get hard drive capacities that are identical for two or more PCs.
 * Result set: hd.
 */

SELECT hd
FROM [dbo].PC
GROUP BY hd
HAVING COUNT(*) > 1
