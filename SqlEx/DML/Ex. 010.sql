/*
 * Exercise: 10
 * Find the printer models having the highest price. Result set: model, price.
 */

SELECT model,
       price
FROM [dbo].[Printer]
WHERE price = (SELECT MAX(price)
               FROM [dbo].[Printer])