/*
 * Exercise: 68
 * Find out the number of routes with the greatest number of flights (trips).
 * Notes.
 * 1) A - B and B - A are to be considered the SAME route.
 * 2) Use the Trip table only.
*/
WITH sub AS (
	SELECT [Route]
		, COUNT([trip_no]) [Cnt]
	FROM (
	SELECT CASE WHEN [town_from] > [town_to] THEN [town_from] + [town_to]
		ELSE [town_to] + [town_from] END [Route]
		, [trip_no]
		FROM [Trip]) sub
	GROUP BY [Route])
SELECT COUNT(*) [Cnt]
FROM sub s
WHERE s.[Cnt] = (SELECT MAX(Cnt) FROM sub)