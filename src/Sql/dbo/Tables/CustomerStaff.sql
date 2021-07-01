CREATE TABLE [dbo].[CustomerStaff](
	[CustomerStaffId] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](50) NOT NULL,	
	[ShopCode] [nvarchar](50) NULL,
	[StaffName] [nvarchar](100) NOT NULL
UNIQUE NONCLUSTERED 
(
	[CustomerCode] ASC,
	[ShopCode] ASC
)
)
GO

ALTER TABLE [dbo].[CustomerStaff]  WITH CHECK ADD  CONSTRAINT [FK_CustomerStaff_ShopCode] FOREIGN KEY([ShopCode])
REFERENCES [dbo].[Shop] ([ShopCode])
GO

ALTER TABLE [dbo].[CustomerStaff] CHECK CONSTRAINT [FK_CustomerStaff_ShopCode]
GO
