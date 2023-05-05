/*
 * Exercise: 17
 * Get the laptop models that have a speed smaller than the speed of any PC.
 * Result set: type, model, speed.
 */

SELECT DISTINCT 'Laptop' [Type],
       l.model,
	   l.speed
FROM [dbo].[Laptop] l
WHERE l.speed < ALL (SELECT speed FROM pc)