USE [ASPVulnerableLab]
GO
/****** Object:  Table [dbo].[AppSettings]    Script Date: 12-07-2020 9.22.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppSettings](
	[Name] [nvarchar](50) NOT NULL,
	[Value] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 12-07-2020 9.22.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] NOT NULL,
	[title] [ntext] NULL,
	[content] [ntext] NULL,
	[user_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12-07-2020 9.22.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](64) NULL,
	[privilege] [int] NULL,
	[secret] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[AppSettings] ([Name], [Value]) VALUES (N'AppTitle', N'ASP Vulnerable Lab')
GO
INSERT [dbo].[Posts] ([Id], [title], [content], [user_id]) VALUES (1, N'test', N'test', NULL)
GO
INSERT [dbo].[Posts] ([Id], [title], [content], [user_id]) VALUES (2, N'Post 2', N'Post 2 content .. ', NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [username], [password], [privilege], [secret]) VALUES (7, N'a', N'a', 1, N'test')
GO
INSERT [dbo].[Users] ([Id], [username], [password], [privilege], [secret]) VALUES (9, N'test1', N'test1', 1, N'test1')
GO
INSERT [dbo].[Users] ([Id], [username], [password], [privilege], [secret]) VALUES (11, N'test', N'test1', 1, N'Hackeds')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
