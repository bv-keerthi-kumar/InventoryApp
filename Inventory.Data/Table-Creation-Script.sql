-------------------------------------------------------------------------------------------------------

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Inventory')
BEGIN
	PRINT 'Create Inventory Table'
	CREATE TABLE [dbo].[Inventory](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[ProductName] [nvarchar](50) NOT NULL,
		[Quantity] [int] NOT NULL,
		[Price] [money] NULL,
		[CreatedOn] [datetime] NOT NULL DEFAULT (GETDATE()),
		[ModifiedOn] [datetime] NULL,
	 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY];
END
--------------------------------------------------------------------------------------------------------