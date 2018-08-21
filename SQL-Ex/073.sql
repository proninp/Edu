SELECT c.country,
       b.name
FROM Classes c,
     Battles b
EXCEPT
(
    SELECT c.country,
           o.battle
    FROM Outcomes o
         JOIN Ships s ON s.name = o.ship
         JOIN Classes c ON c.class = s.class
    UNION
    SELECT c.country,
           o.battle
    FROM Outcomes o
         JOIN Classes c ON c.class = o.ship
);