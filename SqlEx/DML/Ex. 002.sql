/*
 * Exercise: 2
 *
 * List all printer makers. Result set: maker. 
*/

SELECT DISTINCT [maker]
FROM [dbo].[Product]
WHERE [type] = 'Printer'