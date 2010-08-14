CREATE TABLE [dbo].[t_Team](
	[ID] [int] NOT NULL,
	[ID_Pilot] [int] NOT NULL,
	[ID_Navigator] [int] NULL,
	[ID_Tracker] [int] NULL,
	[Color] [nchar](10) NULL,
	[ID_Flag] [int] NULL,
 CONSTRAINT [PK_t_Team] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


