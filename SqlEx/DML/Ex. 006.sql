/*
 * Exercise: 6
 *
 * For each maker producing laptops with a hard drive capacity of 10 Gb or higher,
 * find the speed of such laptops. Result set: maker, speed.
 */

SELECT DISTINCT maker,
       speed
FROM [dbo].[Laptop] l
JOIN [dbo].[Product] p ON p.model = l.model
WHERE p.[type] = 'Laptop' AND l.hd >= 10;