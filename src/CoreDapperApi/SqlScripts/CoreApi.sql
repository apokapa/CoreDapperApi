CREATE SCHEMA coreDapperApi
GO


--Drop all tables
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'orderDetails' AND type = 'U') DROP TABLE coreDapperApi.orderDetails
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'orders' AND type = 'U') DROP TABLE coreDapperApi.orders
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'customers' AND type = 'U') DROP TABLE coreDapperApi.customers



--Customers
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'customers' AND type = 'U') DROP TABLE coreDapperApi.customers
GO
CREATE TABLE coreDapperApi.Customers (
	id				int		NOT NULL	IDENTITY(1, 1) PRIMARY KEY,	
	vat				nvarchar(100)	NOT NULL	UNIQUE,	
	email			nvarchar(100)	NOT NULL,		
	firstName		nvarchar(100)	NULL,
	lastName		nvarchar(100)	NULL,
	phone			nvarchar(100)	NULL
);
GO


DELETE coreDapperApi.Customers
SET IDENTITY_INSERT coreDapperApi.Customers ON
GO
INSERT coreDapperApi.Customers (id, vat,email,firstName,lastName,phone) SELECT 1, '1235064695','johndoe1@gmail.com','John','Doe','6902064695'
INSERT coreDapperApi.Customers (id, vat,email,firstName,lastName,phone) SELECT 2, '1235364691','maryfoe@gmail.com','Mary','Foe','6905364695'
INSERT coreDapperApi.Customers (id, vat,email,firstName,lastName,phone) SELECT 3, '1235664692','billdem@gmail.com','Bill','Test','6907064695'
INSERT coreDapperApi.Customers (id, vat,email,firstName,lastName,phone) SELECT 4, '1235264693','frankcass@gmail.com','Frank','Cass','6909064695'
INSERT coreDapperApi.Customers (id, vat,email,firstName,lastName,phone) SELECT 5, '1235864694','raycarl@gmail.com','Ray','Carl','6934084695'
GO
SET IDENTITY_INSERT coreDapperApi.Customers OFF
GO

--Orders
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'orders' AND type = 'U') DROP TABLE coreDapperApi.orders
GO
CREATE TABLE coreDapperApi.orders (
	id				int				NOT NULL	IDENTITY(1, 1) PRIMARY KEY,	
	customerId		int				NOT NULL    ,--REFERENCES Customers(Id),
	number			nvarchar(100)	NOT NULL	UNIQUE,
	descr			nvarchar(500)	NOT NULL,
	date			datetime		NOT NULL
);
GO


DELETE coreDapperApi.orders
SET IDENTITY_INSERT coreDapperApi.orders ON
GO
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 1,1,'O23241','Order O23241','2016-10-16'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 2,2,'O23242','Order O23242','2016-10-26'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 3,3,'O23243','Order O23243','2016-09-13'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 4,4,'O23244','Order O23244','2016-12-06'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 5,1,'O23245','Order O23245','2016-11-11'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 6,5,'O23246','Order O23246','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 7,1,'O23247','Order O23247','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 8,2,'O23248','Order O23248','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 9,2,'O23249','Order O23249','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 10,4,'O23210','Order O23210','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 11,2,'O23211','Order O23211','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 12,3,'O23212','Order O23212','2016-11-12'
INSERT coreDapperApi.orders (id,customerId,number,descr,date) SELECT 13,5,'O23213','Order O23213','2016-11-12'
GO
SET IDENTITY_INSERT coreDapperApi.orders OFF
GO


--OrderDetails
IF EXISTS (SELECT name FROM sysobjects WHERE name = 'orderDetails' AND type = 'U') DROP TABLE coreDapperApi.orderDetails
GO
CREATE TABLE coreDapperApi.orderDetails (
	id				int				NOT NULL	IDENTITY(1, 1) PRIMARY KEY,	
	orderId			int				NOT NULL	,--REFERENCES Orders(id) ON DELETE CASCADE,
	product			nvarchar(100)	NOT NULL,
	quantity		int   			NULL,
	price			money			NULL
);
GO


