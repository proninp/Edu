SELECT DISTINCT
       maker
FROM Product
WHERE type = 'PC'
EXCEPT
SELECT maker
FROM Product p1
WHERE type = 'PC'
      AND model NOT IN
(
    SELECT p2.model
    FROM Product p2
         JOIN pc ON p2.model = pc.model
    WHERE p2.maker = p1.maker
);