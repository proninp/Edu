/*
 * 176. Second Highest Salary
 * 
 * +-------------+------+
 * | Column Name | Type |
 * +-------------+------+
 * | id          | int  |
 * | salary      | int  |
 * +-------------+------+
 * id is the primary key column for this table.
 * Each row of this table contains information about the salary of an employee.
 * Write an SQL query to report the second highest salary from the Employee table.
 * If there is no second highest salary, the query should report null.
 */

-- Vol. 1
SELECT CASE
	WHEN (SELECT COUNT(DISTINCT salary) FROM Employee) < 2 THEN
		NULL
	ELSE
		MIN(salary)
END SecondHighestSalary
FROM (
	SELECT DISTINCT TOP 2 salary
	FROM Employee
	ORDER BY salary DESC) s;

-- Vol. 2
SELECT MAX(Salary) AS SecondHighestSalary
FROM Employee
WHERE Salary < (SELECT MAX(Salary) FROM Employee)