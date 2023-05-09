/*
 * Exercise: 21
 * Find out the maximum PC price for each maker having models in the PC table.
 * Result set: maker, maximum price.
*/
SELECT maker
       , MAX(Price) max_price
FROM PC pc
JOIN Product p ON p.model = PC.model
GROUP BY maker