/*
 * Exercise: 20
 * Find the makers producing at least three distinct models of PCs.
 * Result set: maker, number of PC models.
 */
SELECT maker,
       COUNT(model) [Count_Model]
FROM Product
WHERE [Type]= 'PC'
GROUP BY maker
HAVING COUNT(model) > 2