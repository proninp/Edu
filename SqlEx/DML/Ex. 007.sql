/*
 * Exercise: 7
 *
 * Get the models and prices for all commercially available products (of any type) produced by maker B.
 */

SELECT pc.model,
       price
FROM [dbo].[PC] pc
JOIN [dbo].[Product] p ON pc.model = p.model
WHERE p.maker = 'B'
UNION
SELECT l.model,
       price
FROM [dbo].[Laptop] l
JOIN [dbo].[Product] p ON l.model = p.model
WHERE p.maker = 'B'
UNION
SELECT pr.model,
       price
FROM [dbo].[Printer] pr
JOIN [dbo].[Product] p ON pr.model = p.model
WHERE p.maker = 'B'