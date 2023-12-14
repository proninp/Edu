/*
 * Exercise: 50
 * Find the battles in which Kongo-class ships from the Ships table were engaged.
*/
SELECT DISTINCT o.battle
FROM [Ships] s
JOIN [Outcomes] o ON o.ship = s.[name]
WHERE s.[class] = 'Kongo'