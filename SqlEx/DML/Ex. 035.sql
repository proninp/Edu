/*
 * Exercise: 35
 * Find models in the Product table consisting either of digits only or Latin letters (A-Z, case insensitive) only.
 * Result set: model, type.
*/
SELECT [model]
       , [type]
FROM Product
WHERE ([model] NOT LIKE '%[^0-9]%') OR
      ([model] NOT LIKE '%[^A-Za-z]%')