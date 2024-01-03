/*
 * Exercise: 65
 * Number the unique pairs {maker, type} in the Product table, ordering them as follows:
 * - maker name in ascending order;
 * - type of product (type) in the order PC, Laptop, Printer.
 * 
 * If a manufacturer produces more than one type of product, its name should be displayed in the first row only;
 * other rows for THIS manufacturer should contain an empty string (').
*/
SELECT [num]
       , CASE WHEN [num_sub] = 1 THEN [maker] ELSE '' END [maker]
	   , [type]
FROM (
	SELECT ROW_NUMBER() OVER(ORDER BY p.[maker], p.[type_sort]) [num]
	       , ROW_NUMBER() OVER(PARTITION BY p.[maker] ORDER BY p.[maker], p.[type_sort]) [num_sub]
	       , p.[maker]
	       , p.[type]
		   , p.[type_sort]
	FROM (
		SELECT DISTINCT [maker]
		                , [type]
						, CASE [type] WHEN 'PC' THEN 0
	                                  WHEN 'Laptop' THEN 1
					                  ELSE 2
		                  END [type_sort]
		FROM [Product]) p
) q