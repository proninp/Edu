/*
 * Exercise: 44
 * Find all ship names beginning with the letter R.
*/
SELECT [name]
FROM [Ships]
WHERE [name] LIKE 'R%'
UNION
SELECT [ship]
FROM [Outcomes]
WHERE [ship] LIKE 'R%'