USE [cryptoeditor]
GO
/****** Object:  Table [dbo].[CE_USER]    Script Date: 03/09/2008 17:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CE_USER](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[profile] [nchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fullname] [nchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[license] [uniqueidentifier] NOT NULL,
	[encrypted_license] [nchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[status] [int] NOT NULL,
	[expiration] [datetime] NOT NULL,
	[lastupdate] [datetime] NOT NULL,
 CONSTRAINT [PK_CE_USER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
