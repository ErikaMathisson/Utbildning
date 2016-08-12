
-- DROP TABLE [dbo].[OrderRows];
-- DROP TABLE [dbo].[Orders];
--DROP TABLE [dbo].[Movies];
--DROP TABLE [dbo].[Customers];
--DROP DATABASE [SQLDatabase];
-- CREATE DATABASE [SQLDatabase];

--CREATE TABLE [dbo].[Customers]
--(
--	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
--    [Firstname] VARCHAR(50) NOT NULL, 
--    [Lastname] VARCHAR(50) NOT NULL, 
--    [BillingAddress] VARCHAR(50) NOT NULL, 
--    [BillingZip] NCHAR(10) NOT NULL, 
--    [BillingCity] VARCHAR(50) NOT NULL,
--    [DeliveryAddress] VARCHAR(50) NOT NULL, 
--    [DeliveryZip] NCHAR(10) NOT NULL, 
--    [DeliveryCity] VARCHAR(50) NOT NULL, 
--    [EmailAddress] VARCHAR(50) NOT NULL, 
--    [PhoneNo] NCHAR(10) NOT NULL
--)

--CREATE TABLE [dbo].[Movies](
--[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
--[Title] VARCHAR(50) NOT NULL,
--[Director] VARCHAR(50) NOT NULL,
--[ReleaseYear] NCHAR(10) NOT NULL,
--[Price] NCHAR(10) NOT NULL
--)

--CREATE TABLE [dbo].[Orders](
--[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
--[OrderDate] NCHAR(10) NOT NULL,
--[CustomerId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Customers]([Id])
--)

--CREATE TABLE [dbo].[OrderRows](
--[Id] INT PRIMARY KEY NOT NULL IDENTITY(1,1),
--[OrderId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Orders]([Id]),
--[MovieId] INT NOT NULL FOREIGN KEY REFERENCES [dbo].[Movies]([Id]),
--[Price] NCHAR(10) NOT NULL
--)