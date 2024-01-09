/*
 * Exercise: 71
 * Find the PC makers with all personal computer models produced by them being present in the PC table.
*/
SELECT p.[maker]
FROM [Product] p
LEFT JOIN [PC] pc ON pc.[model] = p.[model]
WHERE [type] = 'PC'
GROUP BY p.[maker]
HAVING COUNT(p.[model]) = SUM(CASE WHEN pc.[model] IS NULL THEN 0 ELSE 1 END)