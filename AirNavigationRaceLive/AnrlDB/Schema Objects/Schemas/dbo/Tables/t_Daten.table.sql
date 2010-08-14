CREATE TABLE [dbo].[t_Daten](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tracker] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Longitude] [decimal](24, 18) NOT NULL,
	[Latitude] [decimal](24, 18) NOT NULL,
	[Altitude] [decimal](24, 18) NOT NULL,
	[Speed] [decimal](24, 18) NOT NULL,
	[Penalty] [int] NOT NULL,
	[ID_Polygon] [int] NOT NULL,
 CONSTRAINT [PK_t_Daten] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


