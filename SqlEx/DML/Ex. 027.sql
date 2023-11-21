/*
 * Exercise: 27
 * Find out the average hard disk drive capacity of PCs produced by makers who also manufacture printers.
 * Result set: maker, average HDD capacity.
*/
SELECT p.maker
       , AVG(pc.hd) avg_hd
FROM [dbo].[Product] p
JOIN [dbo].[PC] pc ON pc.model = p.model
WHERE [type] = 'PC' AND maker IN (SELECT maker
                                  FROM [dbo].[Product]
                                  WHERE [type] = 'Printer')
GROUP BY p.maker