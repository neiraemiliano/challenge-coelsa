CREATE DATABASE [CoelsaChallenge]
GO

USE [CoelsaChallenge]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 19/12/2020 19:35:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contacts]') AND type in (N'U'))
DROP TABLE [dbo].[Contacts]
GO

CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Company] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NOT NULL,
	[PhoneNumber] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


