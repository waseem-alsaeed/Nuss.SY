USE [News]
GO
/****** Object:  StoredProcedure [dbo].[GetAllNews]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllNews] 
	@ID int
AS
BEGIN
	select * from News where DID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetNews]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetNews]

AS
BEGIN
select News.*  , IsNull((select top(1)Name from Departments where News.DID = Departments.DID),'') as DName
from News
END

GO
/****** Object:  StoredProcedure [dbo].[SearchUser]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchUser] 
@Name nvarchar(50) , @Password nvarchar(50)
AS
BEGIN
	select * from Users where UserName = @Name and Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IsMain]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_IsMain] 
AS
BEGIN
select top(3)* from News where IsMain = 1 order by ID desc
END
GO
/****** Object:  StoredProcedure [dbo].[SP_News]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_News]

AS
BEGIN
	select * from News where IsMain = 0 order by ID desc
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Sliders]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Sliders]

AS
BEGIN

  select * from Slider order by ID desc

END

GO
/****** Object:  StoredProcedure [dbo].[SP_TopVideos]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 

CREATE PROCEDURE [dbo].[SP_TopVideos] 

AS
BEGIN
	select top(5)* from Videos order by VID desc
END

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](250) NULL,
	[IsMain] [bit] NULL,
	[CssName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[DID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[IsMain] [bit] NULL,
	[VideoUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Content] [nvarchar](500) NULL,
	[Image] [nvarchar](150) NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Videos]    Script Date: 8/30/2016 11:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[VID] [int] IDENTITY(1,1) NOT NULL,
	[VideoUrl] [nvarchar](250) NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[VID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (1, N'Drama', N'/Images/landscape1.jpg', 1, N'studio')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (2, N'Sport', N'/Images/landscape2.jpg', 1, N'studio')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (3, N'Policy', N'/Images/landscape3.jpg', 1, N'studio')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (4, N'Weather', N'/Images/landscape4.jpg', 1, N'studio')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (5, N'Medicine', N'/Images/landscape5.jpg', 0, N'landscape')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (6, N'Students', N'/Images/landscape6.jpg', 0, N'landscape')
INSERT [dbo].[Departments] ([DID], [Name], [Image], [IsMain], [CssName]) VALUES (7, N'Mix', N'/Images/landscape7.jpg', 0, N'landscape')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1, N'Any Header', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/Headers/6.png', 1, CAST(0x0000A67200000000 AS DateTime), 1, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (2, N'Any Header', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/Headers/3.png', 1, CAST(0x0000A67200000000 AS DateTime), 1, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (3, N'Any Header', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/Headers/4.png', 2, CAST(0x0000A67200000000 AS DateTime), 1, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1002, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/5.png', 3, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1005, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/6.png', 4, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1006, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/7.png', 5, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1007, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/8.png', 6, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1008, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/9.png', 5, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1010, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/10.png', 7, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1011, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/11.png', 7, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
INSERT [dbo].[News] ([ID], [Title], [Content], [Image], [DID], [CreatedDate], [IsMain], [VideoUrl]) VALUES (1012, N'Some New', N'Mauris dapibus quam id turpis dignissim rutrum. Phasellus placerat nunc in nulla pretium pellentesque. Aliquam erat volutpat. In nec enim dui, in hendrerit enim. Vestibulum ante ipsum primis in faucibus adipcising elit. Lorem ipsum Dolor sit amet adipcising elit mauris dapibus dignisim.', N'/Images/11.png', 7, CAST(0x0000A67200000000 AS DateTime), 0, N'https://www.youtube.com/embed/XGSy3_Czz8k')
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [Name], [IsAdmin]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Roles] ([RoleID], [Name], [IsAdmin]) VALUES (2, N'Users', 0)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([ID], [Title], [Content], [Image]) VALUES (1, N'Google wants more women in tech.', N'Donec bibendum dolor at ante. Proin neque dui, pre tium quis fringilla ut,  sodales sed. ', N'/Content/news/img/flexslider/1.png')
INSERT [dbo].[Slider] ([ID], [Title], [Content], [Image]) VALUES (2, N'Small Businesses Surge against all expectations.', N'Donec bibendum dolor at ante. Proin neque dui, pre tium quis fringilla ut,  sodales sed.', N'/Content/news/img/flexslider/3.png')
INSERT [dbo].[Slider] ([ID], [Title], [Content], [Image]) VALUES (3, N'Drones: Future of disaster response?', N' Donec bibendum dolor at ante. Proin neque dui, pre tium quis fringilla ut,  sodales sed.', N'/Content/news/img/flexslider/5.png')
INSERT [dbo].[Slider] ([ID], [Title], [Content], [Image]) VALUES (4, N'Hollywood cowboys'' retreat.', N' Donec bibendum dolor at ante. Proin neque dui, pre tium quis fringilla ut,  sodales sed.', N'/Content/news/img/flexslider/4.png')
INSERT [dbo].[Slider] ([ID], [Title], [Content], [Image]) VALUES (5, N'Stress may cause cravings.', N'Donec bibendum dolor at ante. Proin neque dui, pre tium quis fringilla ut,  sodales sed. ', N'/Content/news/img/flexslider/2.png')
SET IDENTITY_INSERT [dbo].[Slider] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [UserName], [Password], [RoleID]) VALUES (1, N'admin', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[Videos] ON 

INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (1, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (2, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (3, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (4, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (5, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (6, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (7, N'https://player.vimeo.com/video/180255453')
INSERT [dbo].[Videos] ([VID], [VideoUrl]) VALUES (8, N'https://player.vimeo.com/video/180255453')
SET IDENTITY_INSERT [dbo].[Videos] OFF
