SELECT TOP 1 WITH TIES name,
                       tripCount
FROM
(
    SELECT pit.ID_psg,
(
    SELECT COUNT(trip_no)
    FROM Pass_in_trip p
    WHERE p.ID_psg = pit.ID_psg
) tripCount
    FROM Pass_in_trip pit
         JOIN Trip t ON pit.trip_no = t.trip_no
    GROUP BY ID_psg
    HAVING COUNT(DISTINCT ID_comp) = 1
) q
JOIN Passenger p ON p.ID_psg = q.ID_psg
ORDER BY tripCount DESC;