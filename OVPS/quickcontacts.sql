USE [Nigeria]
GO

/****** Object:  Table [dbo].[QuickContacts]    Script Date: 12/28/2012 16:41:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[QuickContacts](
	[QueryId] [int] IDENTITY(1,1) NOT NULL,
	[PersonName] [varchar](150) NULL,
	[EmailId] [varchar](150) NOT NULL,
	[QueryDesc] [varchar](550) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


