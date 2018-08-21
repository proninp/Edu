WITH q
     AS (SELECT CASE
                    WHEN country LIKE 'Russia'
                    THEN 1
                    ELSE 0
                END val,
                country,
                class
         FROM Classes)
     SELECT TOP 1 WITH TIES country,
                            class
     FROM q
     ORDER BY val DESC;