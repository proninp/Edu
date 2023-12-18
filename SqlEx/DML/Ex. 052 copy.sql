/*
 * Exercise: 53
 * With a precision of two decimal places, determine the
 * average number of guns for the battleship classes.
*/
SELECT CAST(AVG([numGuns] * 1.00) AS NUMERIC(16, 2)) [Avg-numGuns]
FROM [Classes] c
WHERE [type] = 'bb'