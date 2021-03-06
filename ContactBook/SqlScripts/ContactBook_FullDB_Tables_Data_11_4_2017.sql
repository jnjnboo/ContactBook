USE [ContactBook]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Address]
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[AddressTypeId] [int] NULL,
	[Address1] [nvarchar](60) NULL,
	[Address2] [nvarchar](60) NULL,
	[City] [nvarchar](50) NULL,
	[StateProvince] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](60) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AddressType]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[AddressType]
GO
CREATE TABLE [dbo].[AddressType](
	[AddressTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AddressType] PRIMARY KEY CLUSTERED 
(
	[AddressTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Email]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Email]
GO
CREATE TABLE [dbo].[Email](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [nvarchar](256) NOT NULL,
	[EmailTypeId] [int] NULL,
	[ContactId] [int] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmailType]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[EmailType]
GO
CREATE TABLE [dbo].[EmailType](
	[EmailTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_EmailType] PRIMARY KEY CLUSTERED 
(
	[EmailTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Event]
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[EventTypeId] [int] NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[EventType]
GO
CREATE TABLE [dbo].[EventType](
	[EventTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[EventTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Phone]
GO
CREATE TABLE [dbo].[Phone](
	[PhoneId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](20) NOT NULL,
	[PhoneTypeId] [int] NULL,
	[ContactId] [int] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[PhoneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhoneType]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[PhoneType]
GO
CREATE TABLE [dbo].[PhoneType](
	[PhoneTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhoneType] PRIMARY KEY CLUSTERED 
(
	[PhoneTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Website]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Website]
GO
CREATE TABLE [dbo].[Website](
	[WebsiteId] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NOT NULL,
	[URL] [nvarchar](256) NOT NULL,
	[WebsiteTypeId] [int] NULL,
 CONSTRAINT [PK_Website] PRIMARY KEY CLUSTERED 
(
	[WebsiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebsiteType]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[WebsiteType]
GO
CREATE TABLE [dbo].[WebsiteType](
	[WebsiteTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_WebsiteType] PRIMARY KEY CLUSTERED 
(
	[WebsiteTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[Contact]
GO
CREATE TABLE [dbo].[Contact](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[PreferredName] [nvarchar](50) NULL,
	[PreviousNames] [nvarchar](250) NULL,
	[Notes] [nvarchar](500) NULL,
	[Relationship] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NULL,
	[JobTitle] [nvarchar](50) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/4/2017 8:28:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
DROP TABLE IF EXISTS [dbo].[User]
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[PreferredName] [nvarchar](50) NULL,
	[LogonName] [nvarchar](50) NULL,
	[Photo] [varbinary](max) NULL,
	[Active] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

/****** Object:  Index [IX_User]    Script Date: 11/4/2017 8:28:30 PM ******/
CREATE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (sysutcdatetime()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_CreatedDate]  DEFAULT (sysutcdatetime()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_AddressType] FOREIGN KEY([AddressTypeId])
REFERENCES [dbo].[AddressType] ([AddressTypeId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_AddressType]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Contact]
GO
ALTER TABLE [dbo].[Contact]  WITH CHECK ADD  CONSTRAINT [FK_Contact_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Contact] CHECK CONSTRAINT [FK_Contact_User]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Contact]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_EmailType] FOREIGN KEY([EmailTypeId])
REFERENCES [dbo].[EmailType] ([EmailTypeId])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_EmailType]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Contact]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([EventTypeId])
REFERENCES [dbo].[EventType] ([EventTypeId])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Contact]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_PhoneType] FOREIGN KEY([PhoneTypeId])
REFERENCES [dbo].[PhoneType] ([PhoneTypeId])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_PhoneType]
GO
ALTER TABLE [dbo].[Website]  WITH CHECK ADD  CONSTRAINT [FK_Website_Contact] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contact] ([ContactId])  ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Website] CHECK CONSTRAINT [FK_Website_Contact]
GO
ALTER TABLE [dbo].[Website]  WITH CHECK ADD  CONSTRAINT [FK_Website_WebsiteType] FOREIGN KEY([WebsiteTypeId])
REFERENCES [dbo].[WebsiteType] ([WebsiteTypeId])
GO
ALTER TABLE [dbo].[Website] CHECK CONSTRAINT [FK_Website_WebsiteType]
GO

USE [ContactBook]
GO
SET IDENTITY_INSERT [dbo].[AddressType] ON 

INSERT [dbo].[AddressType] ([AddressTypeId], [Name]) VALUES (1, N'Home')
INSERT [dbo].[AddressType] ([AddressTypeId], [Name]) VALUES (2, N'Work')
INSERT [dbo].[AddressType] ([AddressTypeId], [Name]) VALUES (3, N'Vacation Home')
INSERT [dbo].[AddressType] ([AddressTypeId], [Name]) VALUES (4, N'Other')
SET IDENTITY_INSERT [dbo].[AddressType] OFF
SET IDENTITY_INSERT [dbo].[EmailType] ON 

INSERT [dbo].[EmailType] ([EmailTypeId], [Name]) VALUES (1, N'Personal')
INSERT [dbo].[EmailType] ([EmailTypeId], [Name]) VALUES (2, N'Business')
INSERT [dbo].[EmailType] ([EmailTypeId], [Name]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[EmailType] OFF
SET IDENTITY_INSERT [dbo].[EventType] ON 

INSERT [dbo].[EventType] ([EventTypeId], [Name]) VALUES (1, N'Birthday')
INSERT [dbo].[EventType] ([EventTypeId], [Name]) VALUES (2, N'Anniversary')
INSERT [dbo].[EventType] ([EventTypeId], [Name]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[EventType] OFF
SET IDENTITY_INSERT [dbo].[PhoneType] ON 

INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (1, N'Mobile')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (2, N'Home')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (3, N'Business')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (4, N'Main')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (5, N'Other')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (6, N'Home Fax')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (7, N'Business Fax')
INSERT [dbo].[PhoneType] ([PhoneTypeId], [Name]) VALUES (8, N'Pager')
SET IDENTITY_INSERT [dbo].[PhoneType] OFF
SET IDENTITY_INSERT [dbo].[WebsiteType] ON 

INSERT [dbo].[WebsiteType] ([WebsiteTypeId], [Name]) VALUES (1, N'Personal')
INSERT [dbo].[WebsiteType] ([WebsiteTypeId], [Name]) VALUES (2, N'Business')
INSERT [dbo].[WebsiteType] ([WebsiteTypeId], [Name]) VALUES (3, N'Blog')
INSERT [dbo].[WebsiteType] ([WebsiteTypeId], [Name]) VALUES (4, N'Profile')
SET IDENTITY_INSERT [dbo].[WebsiteType] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [FullName], [PreferredName],[LogonName]) VALUES (1, N'Jennifer Parry', N'Jenn', N'jenn@jnjnboo.com')
SET IDENTITY_INSERT [dbo].[User] OFF

USE [master]
GO
ALTER DATABASE [ContactBook] SET  READ_WRITE 
GO
