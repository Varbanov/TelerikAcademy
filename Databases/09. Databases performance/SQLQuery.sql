--USE master
--GO
--CREATE DATABASE PerformanceDB
--GO
--USE PerformanceDB
--GO

--CREATE TABLE Messages(
--  MsgId int NOT NULL IDENTITY,
--  MsgText nvarchar(300),
--  MsgDate datetime,
--)
--GO

--use PerformanceDB
--go

--SET NOCOUNT ON
--DECLARE @MessageCount int = (SELECT COUNT(*) FROM Messages)
--DECLARE @RowCount int = 0
--WHILE @RowCount < 1000000
--BEGIN
--  DECLARE @Text nvarchar(100) = 
--    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
--    CONVERT(nvarchar(100), newid())
--  DECLARE @Date datetime = 
--	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
--  INSERT INTO Messages(MsgText,MsgDate)
--  VALUES(@Text, @Date)
--  SET @RowCount = @RowCount + 1
--END
--SET NOCOUNT OFF


--SELECT COUNT(*) 
--FROM Messages

----Empty the SQL Server cache
--CHECKPOINT; DBCC DROPCLEANBUFFERS; 

----Test search by date before adding index
--SELECT MsgDate FROM Messages WHERE MsgDate 
--		BETWEEN CONVERT(datetime, '1990-01-01') AND CONVERT(datetime, '1995-01-01')

---- Add an index to the date column
--CREATE INDEX IDX_OnMsgDate ON Messages(MsgDate);

----Empty cache
--CHECKPOINT; DBCC DROPCLEANBUFFERS; 
--SELECT MsgDate FROM Messages WHERE MsgDate 
--		BETWEEN CONVERT(datetime, '2013-07-19 11:59:21') AND CONVERT(datetime, '2013-07-19 11:59:25');

--3
CREATE FULLTEXT CATALOG MsgFulltext
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Messages(MsgText)
KEY INDEX MsgText
ON MsgFulltext
WITH CHANGE_TRACKING AUTO

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT * FROM Messages
WHERE MsgText LIKE '% 1256789'

--Empty the SQL Server cache
CHECKPOINT; DBCC DROPCLEANBUFFERS;
--Search from full text
SELECT MsgText FROM Messages
WHERE MsgText LIKE '%125678%'