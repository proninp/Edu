/*
 * Exercise: 49
 * Find the names of the ships having a gun caliber of 16 inches (including ships in the Outcomes table).
*/
SELECT [name]
FROM [Ships] s
JOIN [Classes] c ON s.[class] = c.[class] AND c.[bore] = 16
UNION
SELECT [ship]
FROM [Outcomes] o
JOIN [Classes] c ON o.[ship] = c.[class] AND c.[bore] = 16