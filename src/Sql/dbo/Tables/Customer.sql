CREATE TABLE [dbo].[Customer](
	[CustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[ShopCode] [nvarchar](50) NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[CustomerKana] [nvarchar](100) NULL,	
	[StaffName] [nvarchar](100) NULL,
	[Gender] [nvarchar](50) NULL,
	[CardPoint] [int] NULL
PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC	
)
)