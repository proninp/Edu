/*
 * Exercise: 32
 * One of the characteristics of a ship is one-half the cube of the calibre of its main guns (mw).
 * Determine the average ship mw with an accuracy of
 * two decimal places for each country having ships in the database.
*/
SELECT country,
       CAST(AVG(q.bore * q.bore * q.bore / 2) AS NUMERIC(6, 2)) [weight]
FROM
(
    SELECT s.[name]
           , c.[country]
           , c.[bore]
    FROM Ships s
    JOIN Classes c ON s.[class] = c.[class]
    UNION
    SELECT o.[ship]
           , c.[country]
           , c.[bore]
    FROM Outcomes o
    JOIN Classes c ON o.ship = c.class
) q
GROUP BY country
