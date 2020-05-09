SELECT maker
FROM Product p
WHERE type IN ('PC','Printer')
EXCEPT
SELECT maker
FROM Product
GROUP BY maker
HAVING COUNT(DISTINCT type) > 1
EXCEPT
SELECT maker
FROM Product p
WHERE p.type = 'PC'
GROUP BY maker
HAVING COUNT(model) < 3