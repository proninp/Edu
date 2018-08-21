SELECT maker
FROM product
EXCEPT
SELECT maker
FROM Product p
     JOIN
(
    SELECT model
    FROM Product
    WHERE type LIKE 'PC'
    EXCEPT
    SELECT model
    FROM PC
) m ON m.Model = p.Model;