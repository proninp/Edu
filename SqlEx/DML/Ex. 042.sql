/*
 * Exercise: 42
 * Find the names of ships sunk at battles, along with the names of the corresponding battles.
*/
SELECT [ship]
       , [battle]
FROM [Outcomes]
WHERE [result] = 'sunk'