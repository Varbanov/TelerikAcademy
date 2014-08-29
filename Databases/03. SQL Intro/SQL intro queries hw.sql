USE TelerikAcademy

--Task 1
--SQL, DML ans DDL are Sequenced Query Language, Data Manipulation Language and
--Data Definition Language. 
--DML: SELECT, INSERT, UPDATE, DELETE. 
--DDL: CREATE, DROP, ALTER, GRANT, REVOKE

--Task 2
--T-SQL stands for Transact-SQL - an extension to the standart SQL developed by Microsoft. 
--T-SQL is used mainly for writing procedures, functions, triggers and supports ifs, loops 
--and exceptions 

--Task 3
--Here I am, connected to TelerikAcademy database. Have a nice time checking
--the next tasks! Hope you find something new for you! :)

--Task 4
SELECT *
FROM Departments

--Task 5
SELECT Departments.Name as [Department name]
FROM Departments

--Task 6
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Name], Employees.Salary
FROM Employees
ORDER BY Employees.FirstName + Employees.LastName

--Task 7
SELECT Employees.FirstName + ' ' + Employees.LastName
FROM Employees
ORDER BY Employees.FirstName + Employees.LastName

--Task 8
SELECT Employees.FirstName + '.' + Employees.LastName + '@telerik.com' AS [Full Email Addresses]
FROM  Employees

--Task 9
SELECT DISTINCT Employees.Salary AS [Different Salaries]
FROM Employees

--Task 10
SELECT *
FROM Employees
WHERE Employees.JobTitle = 'Sales Representative'

--Task 11
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Names With ''Sa'']
FROM Employees
WHERE Employees.FirstName LIKE 'SA%'

--Task 12
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Names With ''ei'' In LastName ]
FROM Employees
WHERE Employees.LastName LIKE '%EI%'

--Task 13
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Name],  Employees.Salary as [Salary]
FROM Employees
WHERE Employees.Salary BETWEEN 20000 AND 30000

--Task 14
SELECT Employees.FirstName + ' ' + Employees.LastName AS [Name],  Employees.Salary as [Salary]
FROM Employees
WHERE Employees.Salary IN (25000, 14000, 12500, 23600)
ORDER BY Employees.Salary

--Task 15
SELECT *
FROM Employees
WHERE Employees.ManagerID IS NULL

--Task 16
SELECT *
FROM Employees
WHERE Employees.Salary > 50000
ORDER BY Employees.Salary DESC

--Task 17
SELECT TOP 5 Employees.Salary AS [Salary], Employees.FirstName + ' ' + Employees.LastName
FROM Employees
ORDER BY Employees.Salary DESC

--Task 18
SELECT Employees.FirstName, Towns.Name AS [Town], Addresses.AddressText AS [Address]
FROM Employees
INNER  JOIN Addresses 
ON Addresses.AddressID = Employees.AddressID
INNER JOIN Towns
ON Towns.TownID = Addresses.TownID
ORDER BY Employees.FirstName

--Task 19
SELECT Employees.FirstName, Towns.Name, Addresses.AddressText
FROM Employees, Towns, Addresses
WHERE Employees.AddressID = Addresses.AddressID AND Addresses.TownID = Towns.TownID
ORDER BY Employees.FirstName

--Task 20
SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager]
FROM Employees e, Employees m
WHERE e.ManagerID = m.EmployeeID

--Task 21
SELECT e.FirstName + ' ' + e.LastName AS [Employee], m.FirstName + ' ' + m.LastName AS [Manager], a.AddressText AS [Address]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID 
LEFT OUTER JOIN Addresses a
ON a.AddressID = e.AddressID
ORDER BY e.EmployeeID

--Task 22
SELECT Departments.Name AS [Departments and towns]
FROM Departments
UNION
SELECT Towns.Name as [Departments and towns]
FROM Towns

--Task 23

--right join
SELECT e.FirstName AS [Employee], m.FirstName AS [Manager]
FROM Employees m
RIGHT OUTER JOIN Employees e
ON e.ManagerID = m. EmployeeID

--left join
SELECT e.FirstName AS [Employee], m.FirstName AS [Manager]
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m. EmployeeID

--Task 24
SELECT e.FirstName + ' ' + e.LastName as [Name], d.Name AS [Department], e.HireDate
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales', 'Finance')
AND YEAR(e.HireDate) BETWEEN 1995 AND 2005