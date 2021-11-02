-- Create database named [AcmeCorp]
CREATE DATABASE [AcmeCorp]
GO

-- Create table named [Customer]
CREATE TABLE Customer
(
	CustomerID BIGINT PRIMARY KEY IDENTITY (1,1) NOT NULL,
	FirstName NVARCHAR (100) NOT NULL,
	MiddleName NVARCHAR (100) NULL,
	LastName  NVARCHAR (100) NOT NULL,
	Age INT NOT NULL,
	Birthdate DATE NOT NULL
)