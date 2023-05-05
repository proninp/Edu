/*
 * 184. Department Highest Salary
 * +--------------+---------+
 * | Column Name  | Type    |
 * +--------------+---------+
 * | id           | int     |
 * | name         | varchar |
 * | salary       | int     |
 * | departmentId | int     |
 * +--------------+---------+
 * id is the primary key column for this table.
 * departmentId is a foreign key of the ID from the Department table.
 * Each row of this table indicates the ID, name, and salary of an employee. It also contains the ID of their department.
 *
 * +-------------+---------+
 * | Column Name | Type    |
 * +-------------+---------+
 * | id          | int     |
 * | name        | varchar |
 * +-------------+---------+
 * id is the primary key column for this table. It is guaranteed that department name is not NULL.
 * Each row of this table indicates the ID of a department and its name.
 *
 * Write an SQL query to find employees who have the highest salary in each of the departments.
 * Return the result table in any order.
 */

 SELECT d.name Department,
       e.name Employee,
       e.salary Salary
FROM Employee e
LEFT JOIN Department d ON d.id = e.departmentId
WHERE e.Salary = (SELECT MAX(salary) FROM Employee
                    WHERE e.departmentId = departmentId)