USE [ElectronicDb]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 27-08-2023 11:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ProductId] [int] NULL,
	[Quantity] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreadtedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK__Shopping__51BCD7B766F363B6] PRIMARY KEY CLUSTERED 
(
	[CartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryTitle] [varchar](100) NULL,
	[CategoryDecription] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreadtedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK__Categori__19093A0BB761CFE4] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Amount] [decimal](10, 2) NULL,
	[PaymentDate] [datetime] NULL,
	[CreadtedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK__Payments__9B556A381CE4F4E0] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[DOB] [datetime] NULL,
	[Gender] [int] NULL,
	[Address] [nvarchar](200) NULL,
	[Disctrict] [nvarchar](200) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[User_Id] [int] NULL,
 CONSTRAINT [PK__Person__AA2FFBE5F89D00DE] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[SubcategoryId] [int] NULL,
	[Description] [varchar](200) NULL,
	[IsActive] [bit] NULL,
	[Price] [decimal](10, 2) NULL,
	[ComparePrice] [decimal](10, 2) NULL,
	[CostPrice] [decimal](10, 2) NULL,
	[ImagePath] [nvarchar](max) NULL,
	[UploadPath] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreadtedOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK__Products__B40CC6CD4E0D1469] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK__Roles__8AFACE1AAE3B8A03] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcategories]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcategories](
	[SubcategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](250) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CategoryId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreadetOn] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK__Subcateg__9C4E705DFCA789A8] PRIMARY KEY CLUSTERED 
(
	[SubcategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[PasswordSalt] [nchar](200) NULL,
	[RoleId] [int] NULL,
	[PersonId] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[LastPasswordChange] [datetime] NULL,
	[IP] [nvarchar](200) NULL,
 CONSTRAINT [PK__UsersLog__1788CC4C9F974683] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Electronic].[OrderDetails]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Electronic].[OrderDetails](
	[order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_id] [int] NULL,
	[quantity] [int] NULL,
	[price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Electronic].[Orders]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Electronic].[Orders](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[order_date] [datetime] NULL,
	[shipping_address] [nvarchar](512) NULL,
	[billing_address] [nvarchar](512) NULL,
	[total_amount] [decimal](10, 2) NULL,
	[order_status] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Electronic].[Reviews]    Script Date: 27-08-2023 11:47:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Electronic].[Reviews](
	[review_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NULL,
	[user_id] [int] NULL,
	[rating] [int] NULL,
	[review_text] [nvarchar](max) NULL,
	[review_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[review_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryTitle], [CategoryDecription], [IsActive], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (1, N'Electronic', N'some lectronic product', 1, NULL, NULL, CAST(N'2023-05-27T02:03:15.457' AS DateTime), NULL, NULL)
INSERT [dbo].[Categories] ([CategoryId], [CategoryTitle], [CategoryDecription], [IsActive], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (2, N'Electrical', N'some product', 1, NULL, NULL, CAST(N'2023-05-27T14:33:14.903' AS DateTime), NULL, NULL)
INSERT [dbo].[Categories] ([CategoryId], [CategoryTitle], [CategoryDecription], [IsActive], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (3, N'Grocery', N'some product', 1, NULL, NULL, CAST(N'2023-05-27T14:33:44.410' AS DateTime), NULL, NULL)
INSERT [dbo].[Categories] ([CategoryId], [CategoryTitle], [CategoryDecription], [IsActive], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (4, N'Electrical5', N'l', 1, NULL, NULL, CAST(N'2023-06-02T00:37:26.317' AS DateTime), NULL, NULL)
INSERT [dbo].[Categories] ([CategoryId], [CategoryTitle], [CategoryDecription], [IsActive], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (5, N'new title', N'desc', 1, NULL, NULL, CAST(N'2023-06-04T01:02:46.303' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [DOB], [Gender], [Address], [Disctrict], [IsActive], [CreatedOn], [CreatedBy], [UpdatedBy], [UpdatedOn], [User_Id]) VALUES (1, N'saurabh', N'shukla', N'user@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [Email], [DOB], [Gender], [Address], [Disctrict], [IsActive], [CreatedOn], [CreatedBy], [UpdatedBy], [UpdatedOn], [User_Id]) VALUES (9, N'saurabh', N'shukla', N'user12@gmail.com', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (1, N'Title', NULL, N'desc', 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2023-05-28T01:02:04.523' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (2, N'cloth', NULL, N'desc', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2023-05-28T01:19:30.893' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (3, N'title', NULL, N'desc', 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2023-05-28T01:27:01.943' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (4, N'pro', NULL, N'desd', 0, NULL, NULL, NULL, NULL, N'E:\Local\Electronics\Electronics.Web\wwwroot\uploads\565de6bf099249b7b5e3e4e1e450131d.jpg', NULL, NULL, CAST(N'2023-06-04T13:05:45.767' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (5, N'eedwefsdffsf', 2, N'wedfwe', 1, CAST(121.00 AS Decimal(10, 2)), CAST(324.00 AS Decimal(10, 2)), CAST(23432.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-25T23:41:29.003' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (6, N'pd-1', 1, N'ctdgfdgf', 1, CAST(121.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), CAST(2.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-26T11:17:14.140' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (7, N'product-new', 2, N'wedfwe', 1, CAST(121.00 AS Decimal(10, 2)), CAST(324.00 AS Decimal(10, 2)), CAST(23432.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-26T11:21:53.333' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (8, N'mobile', 2, N'cvhsjhdsjhd', 1, CAST(1200.00 AS Decimal(10, 2)), CAST(44.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-26T16:15:09.070' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (9, N'product-new', 2, N'wedfwe', 1, CAST(121.00 AS Decimal(10, 2)), CAST(324.00 AS Decimal(10, 2)), CAST(23432.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-26T17:36:55.917' AS DateTime), NULL, NULL)
INSERT [dbo].[Products] ([ProductId], [Title], [SubcategoryId], [Description], [IsActive], [Price], [ComparePrice], [CostPrice], [ImagePath], [UploadPath], [IsDeleted], [CreatedBy], [CreadtedOn], [UpdatedBy], [UpdatedOn]) VALUES (10, N'Jeans', 2, N'black jeans', 1, CAST(1211.00 AS Decimal(10, 2)), CAST(3242.00 AS Decimal(10, 2)), CAST(2343.00 AS Decimal(10, 2)), NULL, NULL, NULL, NULL, CAST(N'2023-08-26T17:41:42.320' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleId], [RoleName], [CreatedOn], [CreatedBy]) VALUES (1, N'Admin', NULL, NULL)
INSERT [dbo].[Roles] ([RoleId], [RoleName], [CreatedOn], [CreatedBy]) VALUES (3, N'User', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Subcategories] ON 

INSERT [dbo].[Subcategories] ([SubcategoryId], [Title], [Description], [IsActive], [IsDeleted], [CategoryId], [CreatedBy], [CreadetOn], [UpdatedBy], [UpdatedOn]) VALUES (1, N'Cloth', N'desc', 1, NULL, 2, NULL, CAST(N'2023-05-27T15:39:16.197' AS DateTime), NULL, NULL)
INSERT [dbo].[Subcategories] ([SubcategoryId], [Title], [Description], [IsActive], [IsDeleted], [CategoryId], [CreatedBy], [CreadetOn], [UpdatedBy], [UpdatedOn]) VALUES (2, N'Electrical', N'electrical product', 1, NULL, 2, NULL, CAST(N'2023-05-27T15:52:42.357' AS DateTime), NULL, NULL)
INSERT [dbo].[Subcategories] ([SubcategoryId], [Title], [Description], [IsActive], [IsDeleted], [CategoryId], [CreatedBy], [CreadetOn], [UpdatedBy], [UpdatedOn]) VALUES (3, N'Electronic', N'electronic product', 1, NULL, 1, NULL, CAST(N'2023-05-27T15:53:19.257' AS DateTime), NULL, NULL)
INSERT [dbo].[Subcategories] ([SubcategoryId], [Title], [Description], [IsActive], [IsDeleted], [CategoryId], [CreatedBy], [CreadetOn], [UpdatedBy], [UpdatedOn]) VALUES (4, N'Grocery', N'Grocery product', 1, NULL, 3, NULL, CAST(N'2023-05-27T15:53:47.900' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Subcategories] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [PasswordSalt], [RoleId], [PersonId], [IsActive], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [LastLoginDate], [LastPasswordChange], [IP]) VALUES (1, N'admin', N'admin@gmail.com', N'Admin@123', NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [Email], [Password], [PasswordSalt], [RoleId], [PersonId], [IsActive], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [LastLoginDate], [LastPasswordChange], [IP]) VALUES (2, N'admin22', N'user12@gmail.com', N'Admin@123', N'9978ab6937                                                                                                                                                                                              ', 3, 9, 1, NULL, CAST(N'2023-05-23T22:34:58.460' AS DateTime), NULL, CAST(N'2023-05-23T22:34:58.633' AS DateTime), CAST(N'2023-05-23T22:34:58.883' AS DateTime), CAST(N'2023-05-23T22:34:59.033' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Person__A9D10534284F7BB8]    Script Date: 27-08-2023 11:48:16 ******/
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [UQ__Person__A9D10534284F7BB8] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__UsersLog__A9D1053439FDB744]    Script Date: 27-08-2023 11:48:16 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UQ__UsersLog__A9D1053439FDB744] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Electronic].[Orders] ADD  DEFAULT (getdate()) FOR [order_date]
GO
ALTER TABLE [Electronic].[Reviews] ADD  DEFAULT (getdate()) FOR [review_date]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__ShoppingC__Produ__4AB81AF0] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__ShoppingC__Produ__4AB81AF0]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK__ShoppingC__UserI__49C3F6B7] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK__ShoppingC__UserI__49C3F6B7]
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK__Payments__Update__4D94879B] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK__Payments__Update__4D94879B]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Products__Subcat__440B1D61] FOREIGN KEY([SubcategoryId])
REFERENCES [dbo].[Subcategories] ([SubcategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Products__Subcat__440B1D61]
GO
ALTER TABLE [dbo].[Subcategories]  WITH CHECK ADD  CONSTRAINT [FK__Subcatego__Categ__412EB0B6] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Subcategories] CHECK CONSTRAINT [FK__Subcatego__Categ__412EB0B6]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Roles]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_UsersLogin] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_UsersLogin]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UsersLogin_Person] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UsersLogin_Person]
GO
ALTER TABLE [Electronic].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [Electronic].[Orders] ([order_id])
GO
ALTER TABLE [Electronic].[OrderDetails]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [Electronic].[Orders]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [Electronic].[Reviews]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [Electronic].[Reviews]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [Electronic].[Reviews]  WITH CHECK ADD CHECK  (([rating]>=(1) AND [rating]<=(5)))
GO
