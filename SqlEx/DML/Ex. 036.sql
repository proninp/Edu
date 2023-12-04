/*
 * Exercise: 36
 * List the names of lead ships in the database (including the Outcomes table).
*/
SELECT [name]
FROM [Ships] s
JOIN [Classes] c ON c.class = s.[name]
UNION
SELECT [ship]
FROM [Outcomes] o
JOIN [Classes] c ON c.class = o.[ship]