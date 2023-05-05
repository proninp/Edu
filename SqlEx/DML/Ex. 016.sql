/*
 * Exercise: 16
 * Get pairs of PC models with identical speeds and the same RAM capacity.
 * Each resulting pair should be displayed only once, i.e. (i, j) but not (j, i).
 * Result set: model with the bigger number, model with the smaller number, speed, and RAM.
 */

SELECT DISTINCT p1.model,
       p2.model,
	   p1.speed,
	   p1.ram
FROM PC p1, PC p2
WHERE p1.speed = p2.speed AND
      p1.ram = p2.ram AND
	  p1.model > p2.model