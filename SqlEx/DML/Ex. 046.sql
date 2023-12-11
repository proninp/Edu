/*
 * Exercise: 46
 * For each ship that participated in the Battle of Guadalcanal,
 * get its name, displacement, and the number of guns.
*/
SELECT DISTINCT o.[ship]
       , ISNULL(cs.[displacement], co.[displacement]) [displacement]
	   , ISNULL(cs.[numGuns], co.[numGuns]) [numGuns]
FROM [Outcomes] o
LEFT JOIN [Ships] s ON s.[name] = o.[ship]
LEFT JOIN [Classes] cs ON cs.[class] = s.[class]
LEFT JOIN [Classes] co ON co.[class] = o.[ship]
WHERE o.[battle] = 'Guadalcanal'