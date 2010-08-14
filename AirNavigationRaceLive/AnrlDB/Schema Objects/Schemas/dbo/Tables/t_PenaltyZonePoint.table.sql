CREATE TABLE [dbo].[t_PenaltyZonePoint](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[longitude] [decimal](24, 14) NOT NULL,
	[latitude] [decimal](24, 14) NOT NULL,
	[altitude] [decimal](24, 14) NOT NULL,
	[ID_Polygon] [int] NOT NULL,
 CONSTRAINT [PK_t_PolygonPoints] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


