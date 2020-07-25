Create database ProductDb
go

USE ProductDb
GO

/****** Object:  Table [dbo].[Category]    Script Date: 4/7/2016 9:59:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Product]    Script Date: 4/7/2016 9:59:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[ProductPrice] [smallmoney] NOT NULL,
	[ProductQuantity] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[ProductCategory]    Script Date: 4/7/2016 10:00:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductCategory](
	[CategoryId] [int] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Category]
GO

ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_Product]
GO

/****** Object:  Table [dbo].[User]    Script Date: 4/7/2016 11:18:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[User](
    [UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[UserHashedPassword] [varchar](50) NOT NULL,
	[UserFailedPasswordAttempts] [bit] NOT NULL,
	[UserLockedOut] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[UserEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, 
     IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Order]    Script Date: 4/7/2016 11:17:31 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [smalldatetime] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
        ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO

/****** Object:  Table [dbo].[OrderItem]    Script Date: 4/7/2016 11:17:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderItem](
	[OrderId] [int] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ProductPrice] [smallmoney] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[Sequence] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
        ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([OrderId])
GO

ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Order]
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_OrderItem_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO

ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_OrderItem_Product]
GO

    /****** Object:  Table [dbo].[ShoppingCartItem]    Script Date: 4/14/2016 9:24:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCartItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_ShoppingCartItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_Product]
GO
ALTER TABLE [dbo].[ShoppingCartItem]  WITH CHECK ADD  CONSTRAINT [FK_ShoppingCartItem_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ShoppingCartItem] CHECK CONSTRAINT [FK_ShoppingCartItem_User]
GO

-- Add product data

declare @productId int

declare @booksCategoryId int
declare @electronicsCategoryId int
declare @sportsCategoryId int
declare @automotiveCategoryId int
declare @toysCategoryId int
declare @clothingCategoryId int

insert into Category (CategoryName)
		values ('Books')
SELECT @booksCategoryId=SCOPE_IDENTITY()

insert into Category (CategoryName)
		values ('Electronics')
SELECT @electronicsCategoryId=SCOPE_IDENTITY()

insert into Category (CategoryName)
		values ('Sports')
SELECT @sportsCategoryId=SCOPE_IDENTITY()

insert into Category (CategoryName)
		values ('Automotive')
SELECT @automotiveCategoryId=SCOPE_IDENTITY()

insert into Category (CategoryName)
		values ('Toys')
SELECT @toysCategoryId=SCOPE_IDENTITY()

insert into Category (CategoryName)
		values ('Clothing')
SELECT @clothingCategoryId=SCOPE_IDENTITY()

-- Book data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('The Whale', 13.45, 20)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@booksCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Cat in the Hat', 16.75, 13)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@booksCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Little Red Horse', 6.15, 2)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@booksCategoryId, @productId)

-- electronics data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Tracking watch', 119.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@electronicsCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Pulse Ox watch', 79.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@electronicsCategoryId, @productId)

-- sports data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Ankle weights', 11.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@sportsCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Yoga mat', 23.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@sportsCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('TreadClimber', 1399.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@sportsCategoryId, @productId)

-- automotive data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Jump starter', 69.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@automotiveCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Battery tender', 23.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@automotiveCategoryId, @productId)

-- toy data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Thomas Train', 7.83, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('James Train', 8.83, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Henry Train', 7.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Emily Train', 8.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('LEGO Star Wars X-Wing Fighter 75102 Building Kit', 34.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('LEGO Star Wars Imperial Troop Transport', 37.83, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Jenga', 8.83, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Uno', 5.95, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Catan', 37.95, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@toysCategoryId, @productId)

-- clothing data
insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Shoshanna Women''s Zoe Shirt Dress', 350.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@clothingCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Lilly Pulitzer Women''s Windward Dress', 108.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@clothingCategoryId, @productId)

insert into Product (ProductName, ProductPrice, ProductQuantity)
		values ('Tadashi Shoji Women''s Sleeveless Lace Sheath Dress', 408.99, 12)
SELECT @productId=SCOPE_IDENTITY()
insert into ProductCategory (CategoryId, ProductId)
		values(@clothingCategoryId, @productId)

GO