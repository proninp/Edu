/*
 * Exercise: 33
 * Get the ships sunk in the North Atlantic battle.
 * Result set: ship.
*/
SELECT ship
FROM [Outcomes]
WHERE [result] = 'sunk' AND [battle] = 'North Atlantic'