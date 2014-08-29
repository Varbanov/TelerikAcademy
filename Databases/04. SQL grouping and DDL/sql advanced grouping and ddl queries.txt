USE TelerikAcademy

--Task 1
SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE E.Salary = 
(SELECT MIN(Salary)
FROM Employees)

--Task 2
--SELECT *
--FROM Employees
--WHERE Salary <=
--(SELECT MIN(Salary) * 1.1 FROM Employees)

--Task 3
--SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.Name, e.Salary
--FROM Employees e
--JOIN Departments d
--ON e.DepartmentID = d.DepartmentID
--WHERE e.Salary = 
--(SELECT MIN(Salary) FROM Employees WHERE e.DepartmentID = Employees.DepartmentID)

--Task 4
--SELECT d.Name as [Department], AVG(e.Salary) as [Average Salary]
--FROM Employees e
--JOIN Departments d
--ON d.DepartmentID = e.DepartmentID
--WHERE e.DepartmentID = 1
--GROUP BY d.Name

--Task 5
--SELECT d.Name as [Department], AVG(e.Salary) as [Average Salary]
--FROM Employees e
--JOIN Departments d
--ON d.DepartmentID = e.DepartmentID
--WHERE d.Name IN ('Sales')
--GROUP BY d.Name

--Task 6
--SELECT d.Name, COUNT(e.EmployeeID)
--FROM Employees e
--JOIN Departments d
--ON e.DepartmentID = d.DepartmentID
--WHERE d.Name IN ('Sales')
--GROUP BY d.Name

--Task 7
--SELECT COUNT(*)
--FROM Employees
--WHERE Employees.ManagerID IS NOT NULL

--Task 8
--SELECT COUNT(*)
--FROM Employees
--WHERE Employees.ManagerID IS NULL

--Task 9
--SELECT d.Name, AVG(e.Salary) AS [Average Salary]
--FROM Employees e
--JOIN Departments d
--ON d.DepartmentID = e.DepartmentID
--GROUP BY d.Name

--Task 10
--SELECT t.Name AS [Town], d.Name AS [Department], COUNT(e.EmployeeID) AS [Employees Count]
--FROM Employees e
--JOIN Addresses a
--ON e.AddressID = a.AddressID
--JOIN Towns t
--ON t.TownID = a.TownID
--JOIN Departments d
--ON d.DepartmentID = e.DepartmentID
--GROUP BY d.Name, t.Name

--Task 11
--SELECT m.FirstName + ' ' + m.LastName as [Manager], COUNT(m.EmployeeID) AS [Employees Count]
--FROM Employees m
--JOIN Employees e
--ON e.ManagerID = m.EmployeeID
--GROUP BY m.FirstName, m.LastName
--HAVING COUNT(m.EmployeeID) = 5

--Task 12
--SELECT e.FirstName + ' ' + e.LastName AS [Employee], COALESCE(m.FirstName + ' ' + m.LastName, 'no manager') AS [Manager]
--FROM Employees e
--LEFT JOIN Employees m
--ON e.ManagerID = m.EmployeeID
--ORDER BY m.FirstName, m.LastName

--Task 13
--SELECT FirstName, LastName
--FROM Employees
--WHERE LEN(LastName) = 5

--Task 14
--SELECT  CONVERT(VARCHAR(50), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(50), GETDATE(), 114) AS [Date]

--Task 15
--CREATE TABLE Users (
--UserId int IDENTITY NOT NULL,
--Username varchar(50) NOT NULL UNIQUE,
--UserPassword varchar(50) NOT NULL CHECK(LEN(UserPassword) > 5),
--FullName varchar(50) NOT NULL,
--LastLogin date
--CONSTRAINT PK_Users PRIMARY KEY (UserId)
--)
--GO

--Task 16
--GO
--CREATE VIEW LoggedUsersToday AS
--SELECT * 
--FROM Users
--WHERE DAY(GETDATE() - LastLogin) = 1
--GO

--Task 17
--CREATE TABLE Groups (
--GroupId int IDENTITY NOT NULL,
--Name varchar(50) UNIQUE,
--CONSTRAINT PK_GROUPS PRIMARY KEY (GroupId)
--)

--Task 18
--ALTER TABLE Users
--ADD GroupId int
--
--ALTER TABLE Users
--ADD CONSTRAINT FK_USERS_GROUPS FOREIGN KEY (GroupId)
--REFERENCES GROUPS(GroupId)
--GO

--Task 19
--INSERT INTO Users (UserName, UserPassword, FullName)
--VALUES ('peshoivanov', 'peshoivanov', 'Pesho Ivanov')

--INSERT INTO Users (UserName, UserPassword, FullName)
--VALUES ('martinapetkova', 'martinapetkova', 'Martina Petkova')

--INSERT INTO Users (UserName, UserPassword, FullName)
--VALUES ('goshogoshev', 'goshogoshev', 'Gosho Goshev')

--INSERT INTO Groups (Name)
--VALUES ('first group')

--INSERT INTO Groups (Name)
--VALUES ('second group')

--Task 20
--UPDATE Users
--SET UserName = 'editedUser'
--WHERE Username = 'gerganaIvanova'
--
--UPDATE Groups
--SET Name = 'editedGroup'
--WHERE Name = 'first group'

--Task 21
--DELETE FROM Users
--WHERE UserName = 'goshogoshev'

--Task 22
--INSERT INTO Users (Username, UserPassword, FullName)
--SELECT LOWER(SUBSTRING(FirstName, 1,3) + LastName),
--		LOWER(SUBSTRING(FirstName, 1,3) + LastName + 'pass'),
--		FirstName + ' ' + LastName
--FROM Employees

--Task 23
--since LastLogin of all users is null, I set additional where clause to update all users
--UPDATE Users
--SET UserPassword = 'default'
--WHERE LastLogin <= CAST('2010-03-10' AS date) OR LastLogin IS NULL

--Task 24
--DELETE FROM Users
--WHERE UserPassword = 'default'

--Task 25
--SELECT d.Name, e.JobTitle, AVG(e.Salary)
--FROM Employees e
--JOIN Departments d
--ON d.DepartmentID = e.DepartmentID
--GROUP BY d.Name, e.JobTitle

--Task 26
--SELECT E.JobTitle, D.Name as [Department], e.Salary, FirstName, LastName
--FROM Employees e
--JOIN Departments d
--ON e.DepartmentID = d.DepartmentID
--WHERE e.Salary = 
--(SELECT MIN(em.Salary) FROM Employees em 
--WHERE e.DepartmentID = em.DepartmentID AND e.JobTitle = em.JobTitle
--GROUP BY EM.DepartmentID, em.JobTitle
--)

--Task 27
--SELECT TOP 1 t.Name AS [Town], COUNT(e.EmployeeID) AS [Employees]
--FROM Towns t
--JOIN Addresses a
--ON a.TownID = t.TownID
--JOIN Employees e
--ON e.AddressID = a.AddressID
--GROUP BY t.Name
--ORDER BY COUNT(*) DESC

--Task 28
--SELECT t.Name, COUNT(DISTINCT m.EmployeeID)
--FROM Employees e
--JOIN Employees m
--ON e.ManagerID = m.EmployeeID
--JOIN Addresses a
--ON m.AddressID = a.AddressID
--JOIN Towns t
--ON a.TownID = t.TownID
--GROUP BY t.Name
--ORDER BY COUNT(*) DESC

--Task 29
--CREATE TABLE WorkHours	
--(
--	WorkHoursId int IDENTITY(1,1) PRIMARY KEY,
--	EmployeeId int FOREIGN KEY(EmployeeId) REFERENCES Employees(EmployeeID) NOT NULL,
--	[Date] date NOT NULL,
--	Task nvarchar(50),
--	[Hours] int,
--	Comments nvarchar(250),
--)
--
--CREATE TABLE WorkHoursLog
--(
--	LogID int IDENTITY PRIMARY KEY,
--	Command nvarchar(20),
--	OldEmployeeId int FOREIGN KEY(OldEmployeeId) REFERENCES Employees(EmployeeID) NULL,
--	[Date] date NULL,
--	OldTask nvarchar(50),
--	[OldHours] int NULL,
--	OldComments nvarchar(250) NULL,
--
--	NewEmployeeID int FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID) NULL,
--	NewTask nvarchar(50),
--	[NewHours] int NULL,
--	NewComments nvarchar(250) NULL
--)
--
--GO
--CREATE TRIGGER TR_WorkHoursInsert ON WorkHours FOR INSERT
--AS
--	INSERT INTO WorkHoursLog(Command, NewEmployeeID, [Date], NewTask, NewHours, NewComments)
--	Values('INSERT',
--	(SELECT EmployeeID FROM INSERTED),
--	GETDATE(),
--	(SELECT Task FROM INSERTED),
--	(SELECT [Hours] FROM INSERTED),
--	(SELECT Comments FROM INSERTED))
--GO
--
--GO
--CREATE TRIGGER TR_WorkHoursUpdate ON WorkHours FOR UPDATE
--AS
--	INSERT INTO WorkHoursLog(Command, OldEmployeeId, NewEmployeeID, [Date], OldTask, NewTask, OldHours, NewHours, OldComments, NewComments)
--	Values('UPDATE',
--	(SELECT EmployeeID FROM DELETED),
--	(SELECT EmployeeID FROM INSERTED),
--	GETDATE(),
--	(SELECT Task FROM DELETED),
--	(SELECT Task FROM INSERTED),
--
--	(SELECT [Hours] FROM DELETED),
--	(SELECT [Hours] FROM INSERTED),
--
--	(SELECT Comments FROM DELETED),
--	(SELECT Comments FROM INSERTED))
--GO
--
--GO
--CREATE TRIGGER TR_WorkHoursDelete ON WorkHours FOR DELETE
--AS
--	INSERT INTO WorkHoursLog(Command, OldEmployeeId, [Date], OldTask, OldHours, OldComments)
--	Values('DELETE',
--	(SELECT EmployeeID FROM DELETED),
--	GETDATE(),
--	(SELECT Task FROM DELETED),
--	(SELECT [Hours] FROM DELETED),
--	(SELECT Comments FROM DELETED))
--GO
--
--
--INSERT INTO WorkHours (EmployeeId, [Date], Task, Comments)
--VALUES(10, '2014-08-24', 'the task', 'the comments')
--
--INSERT INTO WorkHours (EmployeeId, [Date], Task, Comments)
--VALUES(10, '2014-08-24', 'the taskk', 'the comments')
--
--INSERT INTO WorkHours (EmployeeId, [Date], Task, Comments)
--VALUES(10, '2014-08-24', 'the taskk', 'the comments')
--
--UPDATE WorkHours
--SET Task = 'editedrecord'
--WHERE Task = 'edited user'
--
--DELETE FROM WorkHours
--WHERE WorkHoursId = 2

--Task 30
--BEGIN TRAN 
--ALTER TABLE Departments DROP [FK_Departments_Employees]
--DELETE FROM Employees 
--WHERE DepartmentID = (SELECT DepartmentID FROM Departments WHERE Name = 'Sales')
--DELETE FROM Departments 
--WHERE Name = 'Sales'
--ROLLBACK TRAN
--GO

--Task 31
--BEGIN TRAN 
--DROP TABLE EmployeesProjects
--ROLLBACK TRAN
--GO

--Task 32
--BEGIN TRAN
--SELECT * INTO #TempTable FROM EmployeesProjects
--DROP TABLE EmployeesProjects
--COMMIT
--
--CREATE TABLE [dbo].[EmployeesProjects](
--	[EmployeeID] [int] NOT NULL,
--	[ProjectID] [int] NOT NULL,
-- CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY CLUSTERED 
--(
--	[EmployeeID] ASC,
--	[ProjectID] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--
--GO
--
--ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeID])
--REFERENCES [dbo].[Employees] ([EmployeeID])
--GO
--
--ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Employees]
--GO
--
--ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY([ProjectID])
--REFERENCES [dbo].[Projects] ([ProjectID])
--GO
--
--ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Projects]
--GO
--
----Add to EmployeesProjects from backup
--
--INSERT INTO EmployeesProjects
--SELECT * FROM #TempTable
--GO