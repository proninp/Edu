/*
 * Exercise: 63
 * Find the names of different passengers that ever travelled more than once occupying
 * seats with the same number.
*/
SELECT p.[name]
FROM [Passenger] p 
WHERE p.[ID_psg] IN (
	SELECT DISTINCT pt.[ID_psg]
	FROM [Pass_in_trip] pt
	GROUP BY pt.[ID_psg], pt.[place]
	HAVING COUNT(*) > 1)