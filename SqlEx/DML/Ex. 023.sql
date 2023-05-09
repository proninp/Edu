/*
 * Exercise: 23
 * Get the makers producing both PCs having a speed of 750 MHz or higher and laptops with a speed of 750 MHz or higher.
 * Result set: maker
*/
SELECT maker
FROM Product p
JOIN PC pc ON p.model = pc.model
WHERE pc.speed >= 750
INTERSECT
SELECT maker
FROM Product p
JOIN Laptop l ON p.model = l.model
WHERE l.speed >= 750