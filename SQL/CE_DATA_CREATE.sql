USE [cryptoeditor]
GO
/****** Object:  Table [dbo].[CE_DATA]    Script Date: 03/09/2008 17:49:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CE_DATA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nchar](64) COLLATE Latin1_General_CI_AI NOT NULL,
	[profile] [nchar](64) COLLATE Latin1_General_CI_AI NOT NULL,
	[plugin] [nchar](64) COLLATE Latin1_General_CI_AI NOT NULL,
	[data] [xml] NULL,
	[lastupdate] [datetime] NOT NULL CONSTRAINT [DF_CE_DATA_lastupdate]  DEFAULT ((0)),
 CONSTRAINT [PK_CE_DATA] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
