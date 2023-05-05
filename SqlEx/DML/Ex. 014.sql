/*
 * Exercise: 14
 * For the ships in the Ships table that have at least 10 guns, get the class, name, and country.

 */

SELECT s.class,
       s.name,
	   c.country
FROM [dbo].[Ships] s
JOIN [dbo].[Classes] c ON c.class = s.class
WHERE c.numGuns >= 10