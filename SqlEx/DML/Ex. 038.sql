/*
 * Exercise: 38
 * Find countries that ever had classes of both battleships (‘bb’) and cruisers (‘bc’).
*/
SELECT [country]
FROM [Classes]
WHERE [type] = 'bb' 
INTERSECT
SELECT [country]
FROM [Classes]
WHERE [type] = 'bc'