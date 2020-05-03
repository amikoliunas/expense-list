IF DB_ID('FirstDatabase') IS NULL
CREATE DATABASE FirstDatabase; 
GO
USE [FirstDatabase];
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'expenses_2018'))
begin
	CREATE TABLE [dbo].expenses_2018(
		[number] INT PRIMARY KEY IDENTITY (1,1),
		[month] NVARCHAR(255),
		[expenses] INT);
end
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'expenses_2019'))
begin
	CREATE TABLE [dbo].expenses_2019(
		[number] INT PRIMARY KEY IDENTITY (1,1),
		[month] NVARCHAR(255),
		[expenses] INT);
end
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'expenses_2020'))
begin
	CREATE TABLE [dbo].expenses_2020(
		[number] INT PRIMARY KEY IDENTITY (1,1),
		[month] NVARCHAR(255),
		[expenses] INT);
end
GO