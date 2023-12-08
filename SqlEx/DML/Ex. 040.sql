/*
 * Exercise: 40
 * Get the makers who produce only one product type and more than one model. Output: maker, type.
*/
SELECT DISTINCT [maker]
       , MIN([type]) [type]
FROM [product]
GROUP BY [maker]
HAVING COUNT([model]) > 1 AND
	   COUNT(DISTINCT [type]) = 1