/*
 * Exercise: 24
 * List the models of any type having the highest price of all products present in the database.
*/
WITH q AS (
    SELECT model
        , price
    FROM PC
    UNION
    SELECT model
        , price
    FROM Laptop
    UNION
    SELECT model
        , price
    FROM Printer)
SELECT TOP 1 WITH TIES model
FROM q
ORDER BY price DESC