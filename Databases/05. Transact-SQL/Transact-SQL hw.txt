USE TelerikAcademy
GO

--Task 1

CREATE TABLE Persons (
PersonId int IDENTITY PRIMARY KEY,
FirstName NVARCHAR(50) NULL,
LastName NVARCHAR(50) NULL,
SSN NVARCHAR(50) NULL,
)

CREATE TABLE Accounts (
AccountId int IDENTITY PRIMARY KEY,
PersonId int,
Balance money,
CONSTRAINT FK_PersonId FOREIGN KEY(PersonId)
REFERENCES Persons(PersonId)
)

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Pesho', 'Petrov', 'pesho1')

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Ivan', 'Ivanov', 'ivan1')

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES ('Maria', 'Dimitrova', 'maria1')

INSERT INTO Accounts (PersonId, Balance)
VALUES (1, 1000)

INSERT INTO Accounts (PersonId, Balance)
VALUES (2, 500)

INSERT INTO Accounts (PersonId, Balance)
VALUES (3, 2000)

CREATE PROC dbo.usp_SelectNamesFromPersons
AS
SELECT FirstName + ' ' + LastName AS [Full Name]
FROM dbo.Persons
GO

EXEC dbo.usp_SelectNamesFromPersons

--Task 2

--CREATE PROC dbo.usp_SelectPersonsWithMoreMoney (@balance INT = 100)
--AS
--SELECT p.FirstName, p.LastName
--FROM dbo.Persons p
--JOIN dbo.Accounts a
--ON a.PersonId = p.PersonId
--WHERE a.Balance >= @balance
--GO

--EXEC dbo.usp_SelectPersonsWithMoreMoney 1000

--Task 3

--CREATE FUNCTION dbo.usf_CalculateSumWithInterest (
--@balance money,
--@interestRate money,
--@months int
--)
--RETURNS MONEY
--AS
--BEGIN
--	DECLARE @result money
--	SET @result = @balance + (@months/12.0)*((@interestRate*@balance)/100)
--	RETURN @result
--END
--GO

--SELECT dbo.usf_CalculateSumWithInterest(1000, 10, 1)

--Task 4

--CREATE PROC dbo.usp_CalculatePersonInterest 
--	@accountId INT, @interestRate FLOAT
--AS
--	DECLARE @accountMoney MONEY = (
--		SELECT Balance 
--		FROM Accounts 
--		WHERE AccountId = @accountId)

--	SELECT dbo.usf_CalculateSumWithInterest(@accountMoney, @interestRate, 1)
--GO

--EXEC dbo.usp_CalculatePersonInterest 1, 15

--Task 5

--CREATE PROC dbo.usp_WithdrawMoney (
--	@AccountID int,
--	@money money,
--	@result money OUTPUT
--)
--AS
--	DECLARE @currentBalance money
--	SET @currentBalance = (
--		SELECT a.Balance
--		FROM dbo.Accounts a
--		WHERE a.AccountID = @AccountID
--		)
--	SET @result = @currentBalance - @money
--	UPDATE dbo.Accounts
--		SET Balance = @result
--		WHERE(Accounts.AccountID = @AccountID)
--GO

--DECLARE @answer money
--EXEC usp_WithdrawMoney 3, 10, @answer OUTPUT
--SELECT @answer

--CREATE PROC dbo.usp_DepositMoney (
--	@AccountID int,
--	@money money,
--	@result money OUTPUT
--)
--AS
--	DECLARE @curBalance money
--	SET @curBalance = (
--		SELECT a.Balance
--		FROM dbo.Accounts a
--		WHERE a.AccountID = @AccountID
--		)
--	SET @result = @curBalance + @money
--	UPDATE dbo.Accounts
--		SET Balance = @result
--		WHERE(Accounts.AccountID = @AccountID)
--GO

--DECLARE @answer money
--EXEC usp_DepositMoney 3, 150, @answer OUTPUT
--SELECT @answer

--Task 6

--CREATE TABLE Logs(
--LogId int IDENTITY PRIMARY KEY,
--AccountId int,
--NewSum money,
--CONSTRAINT FK_AccountId FOREIGN KEY(AccountId)
--REFERENCES Accounts(AccountId)
--)

--CREATE TRIGGER tr_AccountsUpdate ON dbo.Accounts FOR UPDATE
--AS
--BEGIN
--INSERT INTO dbo.Logs
--SELECT a.AccountId,
--a.Balance AS NewSum
--FROM inserted a
--END
--GO

--DECLARE @answer money
--EXEC usp_WithdrawMoney 1, 50, @answer OUTPUT
--SELECT @answer
--
--SELECT * 
--FROM Logs


--Task 7 

--CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
--RETURNS BIT
--AS
--BEGIN

--DECLARE @lettersLen int = LEN(@letters),
--@matches int = 0,
--@currentChar nvarchar(1)

--WHILE(@lettersLen > 0)
--BEGIN
--	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
--	IF(CHARINDEX(@currentChar, @word, 0) > 0)
--		BEGIN
--			SET @matches += 1
--			SET @lettersLen -= 1
--		END
--	ELSE
--		SET @lettersLen -= 1
--END

--IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
--	RETURN 1

--RETURN 0
--END

--GO

--CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
--RETURNS @ResultTable TABLE
--(
--Name varchar(50) NOT NULL
--)
--AS
--BEGIN

--INSERT INTO @ResultTable
--SELECT LastName  FROM Employees

--INSERT INTO @ResultTable
--SELECT FirstName FROM Employees

--INSERT INTO @ResultTable
--SELECT towns.Name FROM Towns towns

--DELETE FROM @ResultTable
--WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

--RETURN
--END

--GO

--SELECT * FROM dbo.NamesAndTowns('oistmiahf')


--Task 8
--CREATE PROCEDURE uspEmployeesInTown @results CURSOR VARYING OUTPUT
--AS
--BEGIN

--	SET @results = CURSOR FOR

--	SELECT emp.LastName, towns.Name FROM Employees emp
--	JOIN Addresses addr
--	ON emp.AddressID = addr.AddressID
--	JOIN Towns towns
--	ON addr.TownID = towns.TownID
--	GROUP BY towns.TownID, towns.Name, emp.LastName

--	OPEN @results
--END

--GO

--DECLARE @employeesInTown CURSOR
--DECLARE @LastName varchar(20), @TownName varchar(20)
--EXEC uspEmployeesInTown @results = @employeesInTown OUTPUT

--WHILE @@FETCH_STATUS = 0
--BEGIN
--	PRINT @LastName + ' ' + @TownName
--	FETCH NEXT FROM @employeesInTown
--	INTO @LastName, @TownName
--END

--CLOSE @employeesInTown
--DEALLOCATE @employeesInTown

--Task 9

--SELECT t.Name AS Town, e.FirstName + ' ' + e.LastName AS [Full Name]  
--FROM Towns t
--JOIN Addresses a
--ON t.TownID = a.TownID
--JOIN Employees e
--ON e.AddressID = a.AddressID
--GROUP BY t.Name, e.FirstName, e.LastName


--Task 10
--sp_configure 'clr enabled', 1
--GO
--RECONFIGURE
--GO
--CREATE ASSEMBLY StrConcat
--FROM 'D:\Documents\Telerik Courses homeworks\Databases\05.T-SQL\StrConcat.dll';
--GO
--CREATE AGGREGATE StrConcat (@input nvarchar(200)) RETURNS nvarchar(max)
--EXTERNAL NAME StrConcat.Concatenate;
--GO
--SELECT dbo.StrConcat(FirstName + ' ' + LastName)
--FROM Employees;
--GO