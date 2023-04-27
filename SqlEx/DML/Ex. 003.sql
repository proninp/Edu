/*
 * Exercise: 3
 *
 * Find the model number, RAM and screen size of the laptops with prices over $1000.
*/

SELECT [model],
       [ram],
	   [screen]
FROM [dbo].[Laptop]
WHERE [price] > 1000