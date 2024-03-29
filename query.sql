USE [nxtSol]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 10/9/2019 1:02:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[departmentId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[Adress] [text] NULL,
	[description] [text] NULL,
	[active] [bit] NOT NULL,
	[dateTimeEntered] [datetime] NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[departmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/9/2019 1:02:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NOT NULL,
	[Country] [varchar](250) NOT NULL,
	[Address] [text] NOT NULL,
	[Desciption] [text] NOT NULL,
	[depId] [int] NOT NULL,
	[active] [bit] NOT NULL,
	[dateTimeEntered] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

GO
INSERT [dbo].[Departments] ([departmentId], [name], [Adress], [description], [active], [dateTimeEntered]) VALUES (1, N'Sales', N'upper', N'nothing', 1, NULL)
GO
INSERT [dbo].[Departments] ([departmentId], [name], [Adress], [description], [active], [dateTimeEntered]) VALUES (2, N'Management ', N'upcoming ', N'none ', 1, NULL)
GO
INSERT [dbo].[Departments] ([departmentId], [name], [Adress], [description], [active], [dateTimeEntered]) VALUES (3, N'Blue', N'nnn', N'nnn', 1, CAST(0x0000AAE000EF381B AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Departments] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserId], [firstName], [LastName], [Country], [Address], [Desciption], [depId], [active], [dateTimeEntered]) VALUES (1, N'umer', N'asif', N'pakistan', N'lahore', N'none ', 1, 1, NULL)
GO
INSERT [dbo].[Users] ([UserId], [firstName], [LastName], [Country], [Address], [Desciption], [depId], [active], [dateTimeEntered]) VALUES (2, N'abdullah', N'asif', N'pakistan', N'lahore', N'none ', 1, 1, NULL)
GO
INSERT [dbo].[Users] ([UserId], [firstName], [LastName], [Country], [Address], [Desciption], [depId], [active], [dateTimeEntered]) VALUES (3, N'zeeshan', N'asif', N'pakistan', N'lahore', N'none ', 2, 1, NULL)
GO
INSERT [dbo].[Users] ([UserId], [firstName], [LastName], [Country], [Address], [Desciption], [depId], [active], [dateTimeEntered]) VALUES (5, N'Ahmad', N'plo', N'pk', N'lh', N'pp', 1, 1, CAST(0x0000AAE000F0797A AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([depId])
REFERENCES [dbo].[Departments] ([departmentId])
GO
