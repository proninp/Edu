/*
 * Exercise: 58
 * For each product type and maker in the Product table, find out, with a precision of two decimal places, the percentage
 * ratio of the number of models of the actual type produced by the actual maker to the total number of models by this maker.
 * Result set: maker, product type, the percentage ratio mentioned above.
*/
WITH maker_model_cnt AS (
	SELECT [maker]
		   , COUNT([model]) [models_cnt]
	FROM [Product]
	GROUP BY [maker])
, maker_type_model_cnt AS (
	SELECT [maker]
		   , [type]
		   , COUNT([model]) [models_cnt]
	FROM [Product]
	GROUP BY [maker]
			 , [type])
SELECT DISTINCT p.[maker], t.[type]
               , CAST((ISNULL(mtmc.[models_cnt], 0) * 100.0 / mmc.[models_cnt]) AS NUMERIC(16, 2)) perc
FROM [Product] p
CROSS JOIN [Product] t
LEFT JOIN maker_model_cnt mmc ON p.[maker] = mmc.[maker]
LEFT JOIN maker_type_model_cnt mtmc ON p.[maker] = mtmc.[maker] AND t.[type] = mtmc.[type]