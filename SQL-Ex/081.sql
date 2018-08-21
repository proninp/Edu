WITH summary
     AS (SELECT TOP 1 WITH TIES DATEPART(month, date) month_Val,
                                DATEPART(year, date) year_Val,
                                SUM(out) max_Sum
         FROM Outcome
         GROUP BY DATEPART(month, date),
                  DATEPART(year, date) ORDER BY max_Sum DESC)
     SELECT o.code,
            o.point,
            o.date,
            o.out
     FROM Outcome o
          JOIN summary s ON s.month_Val = DATEPART(month, o.date)
                            AND s.year_Val = DATEPART(year, date);