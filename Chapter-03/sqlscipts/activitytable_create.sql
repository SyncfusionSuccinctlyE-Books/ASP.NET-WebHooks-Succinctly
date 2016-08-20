USE [Activity]
GO

/****** Object:  Table [dbo].[ActivityModels]    Script Date: 6/14/2016 4:03:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActivityModels](
	[ActivityId] [int] IDENTITY(1,1) NOT NULL,
	[Activity] [nvarchar](10) NULL,
	[Action] [nvarchar](25) NULL,
	[Description] [nvarchar](65) NULL,
	[Data] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ActivityModels] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO