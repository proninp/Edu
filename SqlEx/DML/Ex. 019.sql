/*
 * Exercise: 19
 * For each maker having models in the Laptop table, find out the average screen size of the laptops he produces.
 * Result set: maker, average screen size.
 */
SELECT maker,
       AVG(screen) screen
FROM Product p
JOIN Laptop l ON p.model = l.model
GROUP BY maker