/*
 * Exercise: 18
 * Find the makers of the cheapest color printers.
 * Result set: maker, price.
 */
SELECT DISTINCT c.maker, a.priceA price
FROM (SELECT MIN(price) priceA 
      FROM Printer 
      WHERE color ='y' AND price IS NOT NULL) a
JOIN Printer b ON a.priceA = b.price AND b.color = 'y'
JOIN Product c ON b.model = c.model