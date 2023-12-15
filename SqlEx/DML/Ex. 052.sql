/*
 * Exercise: 52
 * Determine the names of all ships in the Ships table that can be a Japanese
 * battleship having at least nine main guns with a caliber of less than 19 inches 
 * and a displacement of not more than 65 000 tons.
*/
SELECT [name]
FROM [Ships] s
JOIN [Classes] c ON c.[class] = s.[class]
WHERE c.[country] = 'Japan' AND
      c.[type] = 'bb' AND
	  ISNULL(c.[numGuns], 9) > 8 AND
	  ISNULL(c.[bore], 0) < 19 AND
	  ISNULL(c.[displacement], 0) < 65001