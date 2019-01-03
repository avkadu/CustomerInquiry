CREATE DATABASE CustomerInquiry

use CustomerInquiry
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int]  NOT NULL Identity PRIMARY KEY,
	[CustomerName] [varchar](30) NULL,
	[ContactEmail] [varchar] (25)NULL,
	[MobileNo] varchar (10) NULL
)

CREATE TABLE [dbo].[Transaction](
	[TransactionID] [int]  NOT NULL Identity PRIMARY KEY,
	[TransactionDateTime] DateTime NULL,
	[Amount] decimal(18,2) NULL,
	[CurrencyCode] [varchar] (3) null,
	[Status] varchar(10) null,
	[CustomerID] [int]  
)


ALTER TABLE [Transaction]
ADD CONSTRAINT FK_CustomerID
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID);
