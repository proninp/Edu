/*
 * Exercise: 22
 * For each value of PC speed that exceeds 600 MHz, find out the average price of PCs with identical speeds.
 * Result set: speed, average price.
*/
SELECT speed
       , AVG(Price) avg_price
FROM PC pc
WHERE speed > 600
GROUP BY speed