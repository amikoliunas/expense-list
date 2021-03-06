IF DB_ID('Expenses') IS NULL
CREATE DATABASE Expenses; 
GO
USE [Expenses];
GO
IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'expenses'))
begin
	CREATE TABLE [dbo].expenses(
		[Id] INT PRIMARY KEY IDENTITY (1,1),
		[date] DATE,
		[expenses] DECIMAL(6,2),
		[expense_type_ID] INT,
		[user_ID] INT);
end
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'expense_types'))
begin
	CREATE TABLE [dbo].expense_types(
		[Id] INT PRIMARY KEY IDENTITY (1,1),
		[expense_type] NVARCHAR(255));
end
GO

IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'users'))
begin
	CREATE TABLE [dbo].users(
		[Id] INT PRIMARY KEY IDENTITY (1,1),
		[user] NVARCHAR(255));
end
GO