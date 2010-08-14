CREATE TABLE [dbo].[t_Log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[timestamp] [datetime] NOT NULL,
	[level] [int] NOT NULL,
	[project] [text] NULL,
	[Text] [text] NULL,
 CONSTRAINT [PK_t_Log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


