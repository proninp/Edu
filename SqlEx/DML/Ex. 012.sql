/*
 * Exercise: 12
 * Find out the average speed of the laptops priced over $1000.
 */

SELECT AVG(speed) speed
FROM Laptop
WHERE price > 1000
