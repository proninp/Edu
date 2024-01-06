/*
 * Exercise: 67
 * Find out the number of routes with the greatest number of flights (trips).
 * Notes.
 * 1) A - B and B - A are to be considered DIFFERENT routes.
 * 2) Use the Trip table only.
*/
WITH sub AS (
	SELECT COUNT(*) [Cnt]
	FROM [Trip]
	GROUP BY [town_from], [town_to])
SELECT COUNT(*) [Cnt]
FROM sub s
WHERE s.[Cnt] = (SELECT MAX(Cnt) FROM sub)