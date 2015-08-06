# SRTest
Trying to get Proligence Module to work with custom [unsuccessfully]

Run the following SQL script and make sure AJAX Get url is correct re: Local port number

---------------------

USE [BlogDemos]
GO

/****** Object:  Table [dbo].[Messages]    Script Date: 10/16/2014 12:43:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](50) NULL,
	[EmptyMessage] [nvarchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_Date]  DEFAULT (getdate()) FOR [Date]
GO

---------------

Plus, run this:
ALTER DATABASE BlogDemos SET ENABLE_BROKER WITH ROLLBACK IMMEDIATE
