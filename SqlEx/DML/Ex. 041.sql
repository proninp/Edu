/*
 * Exercise: 41
 * For each maker who has models at least in one of the tables PC, Laptop, or Printer,
 * determine the maximum price for his products.
 * Output: maker; if there are NULL values among the prices for the products of a given maker,
 * display NULL for this maker, otherwise, the maximum price.
*/
WITH sub AS (
	SELECT p.[maker]
	       , q.[model]
		, q.[price]
       FROM (
		SELECT [model]
			, [price]
			, 'pc' [type]
		FROM [pc]
		UNION ALL
		SELECT [model]
			, [price]
			, 'laptop' [type]
		FROM [laptop]
		UNION ALL
		SELECT [model]
			, [price]
			, 'printer' [type]
		FROM [printer]) q
       JOIN [Product] p ON p.[model] = q.model AND p.[type] = q.[type])
SELECT [maker]
       , CASE WHEN EXISTS (
              SELECT 1
              FROM sub
		WHERE sub.maker = s.maker AND 
			sub.[price] IS NULL)
		THEN
			NULL
		ELSE
			MAX([price])
	END [price]
FROM sub s
GROUP BY [maker]